using AutoMapper;
using Dapper;
using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.ApprovalManagement;
using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.ApprovalManagement;
using Inspection.Application.Contracts.Repositories.Query.ApprovalManagement;
using Inspection.Application.Contracts.Services.ApprovalManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.ApprovalManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Inspection.Application.Services.ApprovalManagement
{
    public class ApprovalService : AccountsServiceBase, IApprovalService
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ITenantResolver _tenantResolver;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUserApprovalService _userApprovalService;

        public ApprovalService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, IConfiguration configuration, HttpClient httpClient, ITenantResolver tenantResolver, IHttpContextAccessor httpContextAccessor) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _tenantResolver = tenantResolver;
            _httpContextAccessor = httpContextAccessor;
            _userApprovalService = new UserApprovalService(accountUoW, queriesManager, mapper, exceptionManager);
        }

        public async Task<ReturnBase<ApprovalUpdateDto>> GetApprovalEntityForUpdate(EntityKeyValueDictionary keys)
        {
            var findResult = await this._commands.GetEntityAsync(keys);
            if (findResult.Succeeded)
            {
                var mappingResult = this._mapper.Map<ApprovalUpdateDto>(findResult.Result);
                return ReturnBase<ApprovalUpdateDto>.Success(mappingResult);
            }
            else
            {
                return ReturnBase<ApprovalUpdateDto>.Fail(findResult.Errors);
            }
        }

        public async Task<ReturnBase<IEnumerable<ApprovalDto>>> GetApprovalIndexAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.Approval.GetApprovalIndexAsync(queryOptions);
            return result;
        }

        public async Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> GetApprovalUserCountLookUpAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.Approval.GetApprovalUserCountLookUpAsync(queryOptions);
            return result;
        }

        public async Task<ReturnBase<ApprovalDto>> InsertApprovalAsync(ApprovalInsertDto insertDto)
        {
            try
            {
                // 1️ Map DTO → Entity
                var entity = _mapper.Map<Approval>(insertDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // 3️ INSERT HEADER + DETAILS (من الريبو)
                await _commands.InsertWithDetailsAsync(entity);

                // 4️ Map result
                var resultDto = _mapper.Map<ApprovalDto>(entity);

                return ReturnBase<ApprovalDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ApprovalDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ApprovalDto>> UpdateApprovalAsync(ApprovalUpdateDto dto)
        {
            try
            {
                // ✅ STEP 1: Load existing entity
                var entity = await _queriesManager.Approval.GetById(dto.Id);

                if (entity == null)
                {
                    return ReturnBase<ApprovalDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Approval with Id {dto.Id} was not found" }
            });
                }

                // ✅ STEP 2: Map main fields
                _mapper.Map(dto, entity);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // ✅ STEP 3: Handle children (LIKE CashPayment)


                //await UpdateApprovalDetails(entity, dto);

                // ✅ STEP 4: Save
                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ApprovalDto>.Fail(saveResult.Errors);

                return ReturnBase<ApprovalDto>.Success(_mapper.Map<ApprovalDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ApprovalDto>.Fail(ex, _exceptionManager);
            }
        }
        //private async Task UpdateApprovalDetails(Approval entity, ApprovalUpdateDto dto)
        //{
        //    var existing = entity.Approval_ds?.ToList() ?? new List<Approval_d>();

        //    // ✅ CASE 1: No data sent → delete all
        //    if (dto.ApprovalDs == null || !dto.ApprovalDs.Any())
        //    {
        //        var allIds = existing.Select(x => x.IDScrAproval).ToList();

        //        if (allIds.Any())
        //            await _commands.DeleteApprovalDetailsByIds(allIds);

        //        return;
        //    }

        //    // ✅ IDs from DTO (existing ones)
        //    var dtoIds = dto.ApprovalDs
        //        .Where(x => x.IDScrAproval > 0)
        //        .Select(x => x.IDScrAproval)
        //        .ToHashSet();

        //    foreach (var itemDto in dto.ApprovalDs)
        //    {
        //        if (itemDto.IDScrAproval == 0)
        //        {
        //            // ➕ NEW
        //            var newEntity = _mapper.Map<Approval_d>(itemDto);

        //            newEntity.IDScrAproval = entity.Id; // FK
        //            newEntity.Tenant_ID = entity.Tenant_ID;

        //            entity.Approval_ds.Add(newEntity);
        //        }
        //        else
        //        {
        //            // 🔄 UPDATE
        //            var existingEntity = existing
        //                .FirstOrDefault(x => x.IDScrAproval == itemDto.IDScrAproval);

        //            if (existingEntity != null)
        //            {
        //                _mapper.Map(itemDto, existingEntity);
        //            }
        //        }
        //    }

        //    // ❌ REMOVE deleted ones
        //    var removed = existing
        //        .Where(x => !dtoIds.Contains(x.IDScrAproval))
        //        .Select(x => x.IDScrAproval)
        //        .ToList();

        //    if (removed.Any())
        //        await _commands.DeleteApprovalDetailsByIds(removed);
        //}


        //public async Task<ReturnBase<ApprovalUpdateDto>> UpdateApprovalAsync(ApprovalUpdateDto updateDto)
        //{
        //    try
        //    {
        //        var entity = this._mapper.Map<Approval>(updateDto);
        //        entity.Tenant_ID = _tenantResolver.GetTenantName();

        //        var updateResult = await this._commands.UpdateAsync(entity);
        //        if (updateResult.Succeeded)
        //        {
        //            var saveResult = await this._accountUoW.SaveAsync();
        //            if (saveResult.Succeeded)
        //            {
        //                var updatedEntity = this._mapper.Map<ApprovalUpdateDto>(updateResult.Result);

        //                return ReturnBase<ApprovalUpdateDto>.Success(updatedEntity);
        //            }
        //            return ReturnBase<ApprovalUpdateDto>.Fail(saveResult.Errors);
        //        }
        //        return ReturnBase<ApprovalUpdateDto>.Fail(updateResult.Errors);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<ApprovalUpdateDto>.Fail(ex, this._exceptionManager);
        //    }
        //}

        public async Task<ReturnBase<ApprovalDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Approval.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $" Approval with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ApprovalDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ApprovalDto>(entity);

                return ReturnBase<ApprovalDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ApprovalDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UserApprovalInsertDto>> RequestApproval(RequestApprovalDto requestApprovalDto)
        {
            // 1. Validate input DTO
            if (requestApprovalDto == null)
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
      new ReturnBaseError
      {
          Source = "RequestApproval",
          ErrorMessage = "Request body is required."
      }
  });
            }

            if (string.IsNullOrWhiteSpace(requestApprovalDto.ScreenId))
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
      new ReturnBaseError
      {
          Source = "RequestApproval",
          ErrorMessage = "ScreenId is required."
      }
  });
            }

            if (requestApprovalDto.PrimaryKey_ID <= 0)
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
      new ReturnBaseError
      {
          Source = "RequestApproval",
          ErrorMessage = "PrimaryKey_ID must be greater than zero."
      }
  });
            }

            // ----------------------------------------------------
            // 2. Validate dependencies (DI safety)
            // ----------------------------------------------------
            if (_userApprovalService == null)
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
      new ReturnBaseError
      {
          Source = "RequestApproval",
          ErrorMessage = "UserApprovalService is not initialized."
      }
  });
            }

            var userData = _tenantResolver?.GetCommonUserData();
            if (userData == null || string.IsNullOrWhiteSpace(userData.UserName))
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
      new ReturnBaseError
      {
          Source = "RequestApproval",
          ErrorMessage = "Authenticated user context not found."
      }
  });
            }

            // ----------------------------------------------------
            // 3. Prepare variables
            // ----------------------------------------------------
            string screenID = requestApprovalDto.ScreenId;
            string primaryKeyValue = requestApprovalDto.PrimaryKey_ID.ToString();
            DateTime requestDate = requestApprovalDto.Date;
            DateTime actionDate = DateTime.Now;

            string? connectionString = _configuration.GetConnectionString("Inspection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
      new ReturnBaseError
      {
          Source = "RequestApproval",
          ErrorMessage = "Inspection connection string not configured."
      }
  });
            }

            string tableName;
            string screenName;

            // ----------------------------------------------------
            // 4. Load screen configuration
            // ----------------------------------------------------
            using (var connection = new SqlConnection(connectionString))
            {
                const string sql = @"
      SELECT TabelMasterName, Screen_Name
      FROM Screen_Code
      WHERE ScreenId = @ScreenID";

                var screenConfig = connection.QueryFirstOrDefault(sql, new { ScreenID = screenID });

                if (screenConfig == null)
                {
                    return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                    {
          new ReturnBaseError
          {
              Source = "RequestApproval",
              ErrorMessage = $"Screen configuration not found for ScreenId = {screenID}"
          }
      });
                }

                tableName = screenConfig.TabelMasterName;
                screenName = screenConfig.Screen_Name;

                if (string.IsNullOrWhiteSpace(tableName))
                {
                    return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                    {
          new ReturnBaseError
          {
              Source = "RequestApproval",
              ErrorMessage = "TableMasterName is not configured for this screen."
          }
      });
                }
            }

            // ----------------------------------------------------
            // 5. Check if approval already exists
            // ----------------------------------------------------
            using (var connection = new SqlConnection(connectionString))
            {
                const string checkSql = @"
      SELECT 1
      FROM User_Approval
      WHERE TableMasterName = @TableName
        AND [Values] = @PrimaryKey
        AND [Status] = 0
        AND ActionDate IS NULL";

                var exists = connection.QueryFirstOrDefault<int?>(
                    checkSql,
                    new { TableName = tableName, PrimaryKey = primaryKeyValue });

                if (exists.HasValue)
                {
                    return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                    {
          new ReturnBaseError
          {
              Source = "RequestApproval",
              ErrorMessage = $"Approval already exists for record {primaryKeyValue}."
          }
      });
                }
            }

            // ----------------------------------------------------
            // 6. Get first approver (RecordID = 1)
            // ----------------------------------------------------
            long firstApprover;

            using (var connection = new SqlConnection(connectionString))
            {
                const string sql = @"
      SELECT d.User_CodeId
      FROM Approval_d d
      INNER JOIN Approval a ON a.ID = d.IDScrAproval
      WHERE a.ScreenId = @ScreenID
        AND d.RecordID = 1";

                firstApprover = connection.QueryFirstOrDefault<long>(sql, new { ScreenID = screenID });

                if (firstApprover == 0)
                {
                    return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                    {
                        new ReturnBaseError
                        {
                            Source = "RequestApproval",
                            ErrorMessage = "Approval workflow is missing first approver (RecordID = 1)."
                        }
                    });
                }
            }
            //we should userid in resorver 
            // we make query to get userid from User_Code where username = userdata.username and tenantid = tenantid
            long currentUser_CodeId;

            using (var connection = new SqlConnection(connectionString))
            {
                const string userSql = @"
                     SELECT Id
                     FROM User_Code
                     WHERE User_Name = @UserName";

                currentUser_CodeId = connection.QueryFirstOrDefault<long>(
                    userSql,
                    new
                    {
                        UserName = userData.UserName,
                    });

                if (currentUser_CodeId == 0)
                {
                    return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                    {
            new ReturnBaseError
            {
                Source = "RequestApproval",
                ErrorMessage = "Current user is not mapped to User_Code."
            }
        });
                }
            }

            // ----------------------------------------------------
            // 7. Insert INITIALIZED record (Status = 0)
            // ----------------------------------------------------
            var initDto = new UserApprovalInsertDto
            {
                Date = requestDate,
                ActionDate = actionDate,
                ScreenId = screenID,
                TableMasterName = tableName,
                ScreenName = screenName,
                Values = primaryKeyValue,
                Status = 0,
                // User_CodeId = userData.UserId,
                User_CodeId = currentUser_CodeId,
                User_CodeId_SentTo = firstApprover
            };

            var initResult = await _userApprovalService.InsertUserApprovalAsync(initDto);
            if (!initResult.Succeeded)
                return ReturnBase<UserApprovalInsertDto>.Fail(initResult.Errors);

            // ----------------------------------------------------
            // 8. Insert REQUESTED record (Status = 1)
            // ----------------------------------------------------
            initDto.ActionDate = null;
            initDto.Status = 1;
            initDto.Confirm_No = 1;
            initDto.User_CodeId = firstApprover;
            initDto.User_CodeId_SentTo = null;
            initDto.ReceivedDate = actionDate;

            var requestResult = await _userApprovalService.InsertUserApprovalAsync(initDto);

            return requestResult.Succeeded
                ? ReturnBase<UserApprovalInsertDto>.Success(requestResult.Result)
                : ReturnBase<UserApprovalInsertDto>.Fail(requestResult.Errors);
        }
        //public async Task<ReturnBase<UserApprovalInsertDto>> DoApproval(DoApprovalDto doApprovalDto)
        //{
        //    try
        //    {
        //        string? connectionString = _configuration.GetConnectionString("Inspection");

        //        string? screenID;
        //        string? tableName;
        //        string? screenName;
        //        string? sql;
        //        string? primarykeyID;
        //        int status;
        //        DateTime date;
        //        DateTime actionDate;


        //        screenID = doApprovalDto.ScreenId;
        //        primarykeyID = doApprovalDto.PrimaryKey_ID.ToString();
        //        date = doApprovalDto.Date;
        //        actionDate = DateTime.Now;
        //        status = doApprovalDto.Status;
        //        sql = "select TabelMasterName,Screen_Name from Screen_Code where ScreenId = @ScreenID";


        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            var res = connection.QueryFirstOrDefault<dynamic>(sql, new { ScreenID = screenID });
        //            tableName = res.TabelMasterName;
        //            screenName = res.Screen_Name;

        //            if (string.IsNullOrEmpty(tableName))
        //            {
        //                throw new Exception("Table master name not found.");
        //            }
        //        }


        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            try
        //            {
        //                UserApprovalInsertDto userApprovalInsertDto2 = new UserApprovalInsertDto();
        //                UserApprovalUpdateDto? updApprovalDto = new UserApprovalUpdateDto();


        //                userApprovalInsertDto2.ScreenName = screenName;

        //                int confirmNo = 0;
        //                try
        //                {
        //                    switch (status)
        //                    {
        //                        case 2:

        //                            // Case Approve Status:2
        //                            // ______________________________________________________________________
        //                            // update the status in the same entry to 2
        //                            // set the action date to current date in the same entry
        //                            // make a new entry corresponding to the next approval in case it exists
        //                            // if no next entry, status --> complete
        //                            // ______________________________________________________________________

        //                            // Check if there is a next entry in the details

        //                            // Get the current entry (Normal Case)
        //                            sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 1 and ActionDate is null ";
        //                            updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();

        //                            if (updApprovalDto != null)
        //                            {
        //                                confirmNo = updApprovalDto.Confirm_No;
        //                                sql = "select User_ID from Approval_d where IDScrAproval = (select ID from Approval where ScreenId = @ScreenID) and RecordID = @RecordID";
        //                                string? nextApprovalUserID = connection.QueryFirstOrDefault<string>(sql, new { ScreenID = screenID, RecordID = confirmNo + 1 });

        //                                // No next entry
        //                                if (nextApprovalUserID.IsNullOrEmpty())
        //                                {
        //                                    // status: 7 --> complete
        //                                    goto case 7;
        //                                }
        //                                // Next entry exists
        //                                else
        //                                {
        //                                    return await statusApproveHelper(updApprovalDto, actionDate, nextApprovalUserID, userApprovalInsertDto2, confirmNo, date, screenID, primarykeyID, tableName, connection);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                // Get the current entry (Hold Case)
        //                                sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 5";
        //                                updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();

        //                                if (updApprovalDto != null)
        //                                {
        //                                    confirmNo = updApprovalDto.Confirm_No;
        //                                    sql = "select User_ID from Approval_d where IDScrAproval = (select ID from Approval where ScreenId = @ScreenID) and RecordID = @RecordID";
        //                                    string? nextApprovalUserID = connection.QueryFirstOrDefault<string>(sql, new { ScreenID = screenID, RecordID = confirmNo + 1 });

        //                                    // No next entry
        //                                    if (nextApprovalUserID.IsNullOrEmpty())
        //                                    {
        //                                        // status: 7 --> complete
        //                                        goto case 7;
        //                                    }
        //                                    // Next entry exists
        //                                    else
        //                                    {
        //                                        return await statusApproveHelper(updApprovalDto, actionDate, nextApprovalUserID, userApprovalInsertDto2, confirmNo, date, screenID, primarykeyID, tableName, connection);
        //                                    }
        //                                }
        //                            }
        //                            break;

        //                        case 3:

        //                            // Case Reject Staus:3
        //                            // ______________________________________________________
        //                            // update the status in the same entry to 3
        //                            // set the action date to current date in the same entry
        //                            // ______________________________________________________

        //                            // Get the current entry
        //                            sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 1 and ActionDate is null ";
        //                            updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                            if (updApprovalDto != null)
        //                            {
        //                                updApprovalDto.Status = 3;
        //                                updApprovalDto.ActionDate = DateTime.Now;
        //                                updApprovalDto.Rejected_Reasons = doApprovalDto.Rejected_Reasons;
        //                                var responseUPD = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);
        //                                if (responseUPD.Succeeded)
        //                                {
        //                                    var res = responseUPD.Result;
        //                                    var result = new UserApprovalInsertDto
        //                                    {
        //                                        ScreenId = res.ScreenId,
        //                                        TableMasterName = res.TableMasterName,
        //                                        Values = res.Values,
        //                                        Status = res.Status,
        //                                        ActionDate = res.ActionDate,
        //                                        Rejected_Reasons = res.Rejected_Reasons
        //                                    };
        //                                    return ReturnBase<UserApprovalInsertDto>.Success(result);
        //                                }
        //                                else
        //                                {
        //                                    var errorContent = responseUPD.Errors;
        //                                    var errors = new List<ReturnBaseError>
        //                            {
        //                                new ReturnBaseError
        //                                {
        //                                    Source = "Approval Process Reject Status",
        //                                    ErrorMessage = $"API Error:{errorContent}"
        //                                }
        //                            };
        //                                    return ReturnBase<UserApprovalInsertDto>.Fail(errors);

        //                                }
        //                            }
        //                            break;

        //                        case 4:

        //                            // Case Return Status:4
        //                            // ________________________________________________________________
        //                            // update the status in the same entry to 4
        //                            // set the action date to current date in the same entry
        //                            // make a new entry using user in status 0 as the returned to user
        //                            // ________________________________________________________________

        //                            // Get the current entry (Normal Case)
        //                            sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 1 and ActionDate is null ";
        //                            updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                            if (updApprovalDto != null)
        //                            {
        //                                return await statusReturnHelper(updApprovalDto, doApprovalDto);
        //                            }
        //                            // Hold Case
        //                            else
        //                            {
        //                                sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 5";
        //                                updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                                if (updApprovalDto != null)
        //                                {
        //                                    return await statusReturnHelper(updApprovalDto, doApprovalDto);
        //                                }
        //                                // Delegate Case
        //                                else
        //                                {
        //                                    sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 6";
        //                                    updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                                    if (updApprovalDto != null)
        //                                    {
        //                                        return await statusReturnHelper(updApprovalDto, doApprovalDto);
        //                                    }
        //                                }
        //                            }

        //                            break;

        //                        case 5:

        //                            // Case Hold Status:5
        //                            // ______________________________________________________
        //                            // update the status in the same entry to 5
        //                            // set the action date to current date in the same entry
        //                            // ______________________________________________________

        //                            // Get the current entry (Normal Case)
        //                            sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 1 and ActionDate is null ";
        //                            updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                            if (updApprovalDto != null)
        //                            {
        //                                return await statusHoldHelper(updApprovalDto, doApprovalDto);
        //                            }
        //                            // Delegate Case
        //                            else
        //                            {
        //                                sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 6";
        //                                updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                                if (updApprovalDto != null)
        //                                {
        //                                    return await statusHoldHelper(updApprovalDto, doApprovalDto);
        //                                }
        //                            }

        //                            break;

        //                        case 6:

        //                            // Case Delegate Status:6
        //                            // ____________________________________________________________________________________
        //                            // update the status in the same entry to 6
        //                            // set the action date to current date in the same entry
        //                            // make a new entry corresponding to the delegateTo user sent within the dto parameter
        //                            // ____________________________________________________________________________________

        //                            // Get the current entry
        //                            sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 1 and ActionDate is null ";
        //                            updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();

        //                            // Normal Case
        //                            if (updApprovalDto != null)
        //                            {
        //                                return await statusDelegateHelper(updApprovalDto, doApprovalDto);
        //                            }
        //                            // Hold Case
        //                            else
        //                            {
        //                                // Get the current entry
        //                                sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 5";
        //                                updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();

        //                                if (updApprovalDto != null)
        //                                {
        //                                    return await statusDelegateHelper(updApprovalDto, doApprovalDto);
        //                                }
        //                            }

        //                            break;

        //                        case 7:

        //                            // Case Complete Status:7
        //                            // _________________________________________
        //                            // update the status in the same entry to 7
        //                            // _________________________________________

        //                            // Get the current entry
        //                            sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 1 and ActionDate is null ";
        //                            updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();
        //                            if (updApprovalDto != null)
        //                            {
        //                                await SendNotification(updApprovalDto.User_ID, "Approval Completed", $"Your request for {tableName} - ID: {primarykeyID} has been approved and completed.", screenID);

        //                                return await statusCompleteHelper(updApprovalDto);
        //                            }
        //                            else
        //                            {
        //                                // Get the current entry (Hold Case)
        //                                sql = "select * from User_Approval where ScreenId = @ScreenID and [Values] = @PrimaryKeyID and [Status] = 5";
        //                                updApprovalDto = connection.Query<UserApprovalUpdateDto>(sql, new { ScreenID = screenID, PrimaryKeyID = primarykeyID }).FirstOrDefault();

        //                                if (updApprovalDto != null)
        //                                {
        //                                    await SendNotification(updApprovalDto.User_ID, "Approval Completed", $"Your request for {tableName} - ID: {primarykeyID} has been approved and completed.", screenID);

        //                                    return await statusCompleteHelper(updApprovalDto);
        //                                }
        //                            }
        //                            break;

        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    //return ReturnBase<UserApprovalInsertDto>.Fail(ex, this._exceptionManager);

        //                    var Error = new List<ReturnBaseError>
        //                                {
        //                                    new ReturnBaseError
        //                                    {
        //                                        Source = "Approval Process Status",
        //                                        ErrorCode = "",
        //                                        ErrorMessage = $"API Error: Switch"
        //                                    }
        //                                };
        //                    return ReturnBase<UserApprovalInsertDto>.Fail(Error);
        //                }

        //                var Errors = new List<ReturnBaseError>
        //                                {
        //                                    new ReturnBaseError
        //                                    {
        //                                        Source = "Approval Process Status",
        //                                        ErrorCode = "",
        //                                        ErrorMessage = $"API Error: Wrong Status Value"
        //                                    }
        //                                };
        //                return ReturnBase<UserApprovalInsertDto>.Fail(Errors);

        //            }
        //            catch (Exception ex)
        //            {
        //                //return ReturnBase<UserApprovalInsertDto>.Fail(ex, this._exceptionManager);

        //                var Errors = new List<ReturnBaseError>
        //                                {
        //                                    new ReturnBaseError
        //                                    {
        //                                        Source = "Approval Process Status",
        //                                        ErrorCode = "",
        //                                        ErrorMessage = $"API Error: Switch not entered"
        //                                    }
        //                                };
        //                return ReturnBase<UserApprovalInsertDto>.Fail(Errors);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //return ReturnBase<UserApprovalInsertDto>.Fail(ex, this._exceptionManager);

        //        var Errors = new List<ReturnBaseError>
        //                                {
        //                                    new ReturnBaseError
        //                                    {
        //                                        Source = "Approval Process Status",
        //                                        ErrorCode = "",
        //                                        ErrorMessage = $"API Error: do approval definitions"
        //                                    }
        //                                };
        //        return ReturnBase<UserApprovalInsertDto>.Fail(Errors);
        //    }
        //}
        public async Task<ReturnBase<UserApprovalInsertDto>> DoApproval(DoApprovalDto dto)
        {
            // -------------------------------
            // 1. Basic validation
            // -------------------------------
            if (dto == null)
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
            new ReturnBaseError
            {
                Source = "DoApproval",
                ErrorMessage = "Request body is required."
            }
        });
            }

            if (string.IsNullOrWhiteSpace(dto.ScreenId))
                return Error("ScreenId is required.");

            if (dto.PrimaryKey_ID <= 0)
                return Error("PrimaryKey_ID must be greater than zero.");

            // Allowed statuses
            var validStatuses = new[] { 2, 3, 4, 5, 6, 7 };
            if (!validStatuses.Contains(dto.Status))
                return Error("Invalid Status value.");

            string connectionString = _configuration.GetConnectionString("Inspection")!;
            string primaryKey = dto.PrimaryKey_ID.ToString();

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            // -------------------------------
            // 2. Get current approval record
            // -------------------------------
            var sql = @"
        SELECT TOP 1 *
        FROM User_Approval
        WHERE ScreenId = @ScreenID
          AND [Values] = @PrimaryKey
          AND ActionDate IS NULL
        ORDER BY ID DESC";

            var currentApproval =
                connection.Query<UserApprovalUpdateDto>(sql, new
                {
                    ScreenID = dto.ScreenId,
                    PrimaryKey = primaryKey
                }).FirstOrDefault();

            if (currentApproval == null)
                return Error("No pending approval found for this record.");

            // -------------------------------
            // 3. Status routing
            // -------------------------------
            return dto.Status switch
            {
                2 => await HandleApprove(currentApproval, dto, connection),
                3 => await HandleReject(currentApproval, dto),
                4 => await statusReturnHelper(currentApproval, dto),
                5 => await statusHoldHelper(currentApproval, dto),
                6 => await statusDelegateHelper(currentApproval, dto),
                7 => await statusCompleteHelper(currentApproval),
                _ => Error("Unhandled status value.")
            };
        }
        private ReturnBase<UserApprovalInsertDto> Error(string message)
        {
            return ReturnBase<UserApprovalInsertDto>.Fail(new[]
            {
        new ReturnBaseError
        {
            Source = "Approval Process",
            ErrorMessage = message
        }
    });
        }
        private async Task<ReturnBase<UserApprovalInsertDto>> HandleApprove(
    UserApprovalUpdateDto current,
    DoApprovalDto dto,
    SqlConnection connection)
        {
            int confirmNo = current.Confirm_No;

            var sql = @"
        SELECT User_ID
        FROM Approval_d
        WHERE IDScrAproval = (
            SELECT ID FROM Approval WHERE ScreenId = @ScreenID
        )
        AND RecordID = @NextRecord";

            // Change nextUser from string to long?
            var nextUser = connection.QueryFirstOrDefault<long?>(sql, new
            {
                ScreenID = dto.ScreenId,
                NextRecord = confirmNo + 1
            });

            // No next approver → complete
            if (!nextUser.HasValue)
                return await statusCompleteHelper(current);

            return await statusApproveHelper(
                current,
                DateTime.Now,
                nextUser.Value, // Pass as long
                new UserApprovalInsertDto(),
                confirmNo,
                dto.Date,
                dto.ScreenId,
                dto.PrimaryKey_ID.ToString(),
                current.TableMasterName!,
                connection
            );
        }
        private async Task<ReturnBase<UserApprovalInsertDto>> HandleReject(
    UserApprovalUpdateDto updApprovalDto,
    DoApprovalDto doApprovalDto)
        {
            // 1. Update current approval record
            updApprovalDto.Status = 3; // Rejected
            updApprovalDto.ActionDate = DateTime.Now;
            updApprovalDto.Rejected_Reasons = doApprovalDto.Rejected_Reasons;

            var updateResult = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);

            if (!updateResult.Succeeded)
            {
                return ReturnBase<UserApprovalInsertDto>.Fail(new[]
                {
            new ReturnBaseError
            {
                Source = "Approval Process Reject Status",
                ErrorMessage = "Failed to update rejection status."
            }
        });
            }

            var res = updateResult.Result;

            // 2. Return mapped result
            var result = new UserApprovalInsertDto
            {
                ScreenId = res.ScreenId,
                TableMasterName = res.TableMasterName,
                Values = res.Values,
                Status = res.Status,
                ActionDate = res.ActionDate,
                Rejected_Reasons = res.Rejected_Reasons
            };

            return ReturnBase<UserApprovalInsertDto>.Success(result);
        }

        public async Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> GetApprovalHlpScrScreenCodedApprovalLookUpAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.Approval.GetApprovalHlpScrScreenCodedApprovalLookUpAsync(queryOptions);
            return result;
        }

        public async Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> GetApprovalUser_CodeMLookUpAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.Approval.GetApprovalUser_CodeMLookUpAsync(queryOptions);
            return result;
        }

        public async Task<ReturnBase<IEnumerable<ApprovalUser_CodeDLookUpDto>>> GetApprovalUser_CodeDLookUpAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.Approval.GetApprovalUser_CodeDLookUpAsync(queryOptions);
            return result;
        }

        public List<ApprovalUser_CodeDLookUpDto> filterHlp(LookUpRequest request, ReturnBase<IEnumerable<ApprovalUser_CodeDLookUpDto>> lookupData)
        {
            var existingSelection = request.UserSelections ?? new List<UserSelectionDto>();
            var filteredLookup = lookupData.Result.Where(
                lookup => !existingSelection.Any(
                    selected => (selected.UserId == lookup.User_CodeId && selected.UserName == lookup.User_Name)
                )
            ).ToList();

            return (filteredLookup);
        }

        // Add this helper method to forward authentication headers
        private void ForwardAuthenticationHeaders()
        {
            var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(authHeader))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authHeader.Replace("Bearer ", ""));
            }
            else
            {
                throw new UnauthorizedAccessException("[Inspection Error]. No Authorization token found in the request headers.");
            }

            // Forward additional headers if needed
            _httpClient.DefaultRequestHeaders.Add("FiscalYear", _httpContextAccessor.HttpContext.Request.Headers["FiscalYear"].ToString());
            _httpClient.DefaultRequestHeaders.Add("Company", _httpContextAccessor.HttpContext.Request.Headers["Company"].ToString());
            _httpClient.DefaultRequestHeaders.Add("Language", _httpContextAccessor.HttpContext.Request.Headers["Language"].ToString());
        }

        private async Task SendNotification(string userId, string subject, string description, string formId)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Inspection")))
            {
                connection.Open();

                string sql = @"
            INSERT INTO User_Notification
            (User_ID, Form_ID, NotficationSubject, Descrp, Unread, Date, Deleted) 
            VALUES 
            (@UserID, @FormID, @Subject, @Descrp, @Unread, @Date, @Deleted)";

                var notificationParams = new
                {
                    UserID = userId,
                    FormID = formId,
                    Subject = subject,
                    Descrp = description,
                    Unread = true,
                    Date = DateTime.Now,
                    Deleted = false
                };

                connection.Execute(sql, notificationParams);
            }

            // Push Notification via SignalR
            PushNotification(description, subject, userId);

            // Send Email Alert
            string emailApiUrl = _configuration["EmailAPI"];
            var emailPayload = new
            {
                ToUserID = userId,
                Subject = subject,
                Body = description
            };
            await _httpClient.PostAsJsonAsync(emailApiUrl, emailPayload);
        }

        public void PushNotification(string message, string tagMsg, string userId)
        {
            NewNotificationHub.HubContext.Clients.User(userId).SendNotification(message, tagMsg);
        }

        private async Task<ReturnBase<UserApprovalInsertDto>> statusReturnHelper(UserApprovalUpdateDto updApprovalDto, DoApprovalDto doApprovalDto)
        {
            updApprovalDto.Status = 4;
            updApprovalDto.ActionDate = DateTime.Now;
            updApprovalDto.Returned_Reasons = doApprovalDto.Returned_Reasons;
            updApprovalDto.ReturnedUser_CodeId = doApprovalDto.ReturnedUser_CodeId;
            updApprovalDto.ReturnedUser_CodeId = doApprovalDto.ReturnedUser_CodeId;
            var responseUPD = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);

            if (responseUPD.Succeeded)
            {
                var res = responseUPD.Result;
                var result = new UserApprovalInsertDto
                {
                    ScreenId = res.ScreenId,
                    TableMasterName = res.TableMasterName,
                    Values = res.Values,
                    Status = res.Status,
                    ActionDate = res.ActionDate,
                    Returned_Reasons = res.Returned_Reasons,
                    User_CodeId_SentTo = res.User_CodeId_SentTo,
                    ReturnedUser_CodeId = res.ReturnedUser_CodeId
                };
                return ReturnBase<UserApprovalInsertDto>.Success(result);
            }
            else
            {
                var errorContent = responseUPD.Errors;
                var errors = new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        Source = "Approval Process Return Status",
                        ErrorMessage = $"API Error:{errorContent}"
                    }
                };
                return ReturnBase<UserApprovalInsertDto>.Fail(errors);

            }
        }

        private async Task<ReturnBase<UserApprovalInsertDto>> statusHoldHelper(UserApprovalUpdateDto updApprovalDto, DoApprovalDto doApprovalDto)
        {
            updApprovalDto.Status = 5;
            updApprovalDto.ActionDate = DateTime.Now;
            updApprovalDto.Hold_Reasons = doApprovalDto.Hold_Reasons;
            var responseUPD = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);

            if (responseUPD.Succeeded)
            {
                var res = responseUPD.Result;
                var result = new UserApprovalInsertDto
                {
                    ScreenId = res.ScreenId,
                    TableMasterName = res.TableMasterName,
                    Values = res.Values,
                    Status = res.Status,
                    ActionDate = res.ActionDate,
                    Hold_Reasons = res.Hold_Reasons
                };
                return ReturnBase<UserApprovalInsertDto>.Success(result);
            }
            else
            {
                var errorContent = responseUPD.Errors;
                var errors = new List<ReturnBaseError>
                                    {
                                        new ReturnBaseError
                                        {
                                            Source = "Approval Process Hold Status",
                                            ErrorMessage = $"API Error:{errorContent}"
                                        }
                                    };
                return ReturnBase<UserApprovalInsertDto>.Fail(errors);

            }
        }



        private async Task<ReturnBase<UserApprovalInsertDto>> statusDelegateHelper(UserApprovalUpdateDto updApprovalDto, DoApprovalDto doApprovalDto)
        {
            updApprovalDto.Status = 6;
            updApprovalDto.ActionDate = DateTime.Now;
            updApprovalDto.Delegate_Reasons = doApprovalDto.Delegate_Reasons;
            updApprovalDto.User_CodeId_SentTo = doApprovalDto.User_CodeId_Delegated;
            updApprovalDto.User_CodeId_Delegated = doApprovalDto.User_CodeId_Delegated;
            var responseUPD = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);

            if (responseUPD.Succeeded)
            {
                var res = responseUPD.Result;
                var result = new UserApprovalInsertDto
                {
                    ScreenId = res.ScreenId,
                    TableMasterName = res.TableMasterName,
                    Values = res.Values,
                    Status = res.Status,
                    ActionDate = res.ActionDate,
                    Delegate_Reasons = res.Delegate_Reasons,
                    User_CodeId_Delegated = res.User_CodeId_Delegated,
                    User_CodeId_SentTo = res.User_CodeId_SentTo
                };
                return ReturnBase<UserApprovalInsertDto>.Success(result);
            }
            else
            {
                var errorContent = responseUPD.Errors;
                var errors = new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        Source = "Approval Process Delegate Status",
                        ErrorMessage = $"API Error:{errorContent}"
                    }
                };
                return ReturnBase<UserApprovalInsertDto>.Fail(errors);

            }
        }

        private async Task<ReturnBase<UserApprovalInsertDto>> statusCompleteHelper(UserApprovalUpdateDto updApprovalDto)
        {
            updApprovalDto.Status = 7;
            updApprovalDto.ActionDate = DateTime.Now;
            var responseUPD = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);

            if (responseUPD.Succeeded)
            {
                var res = responseUPD.Result;
                var result = new UserApprovalInsertDto
                {
                    ScreenId = res.ScreenId,
                    TableMasterName = res.TableMasterName,
                    Values = res.Values,
                    Status = res.Status,
                    ActionDate = res.ActionDate
                };
                return ReturnBase<UserApprovalInsertDto>.Success(result);
            }
            else
            {
                var errorContent = responseUPD.Errors;
                var errors = new List<ReturnBaseError>
                                        {
                                            new ReturnBaseError
                                            {
                                                Source = "Approval Process Complete Status",
                                                ErrorMessage = $"API Error:{errorContent}"
                                            }
                                        };
                return ReturnBase<UserApprovalInsertDto>.Fail(errors);
            }
        }
        private async Task<ReturnBase<UserApprovalInsertDto>> statusApproveHelper(UserApprovalUpdateDto updApprovalDto, DateTime actionDate, long nextApprovalUserID, UserApprovalInsertDto userApprovalInsertDto2, int confirmNo, DateTime date, string screenID, string primarykeyID, string tableName, SqlConnection connection)
        {
            // Update the status and Set the ActionDate of the current entry
            updApprovalDto.Status = 2;
            updApprovalDto.ActionDate = actionDate;
            updApprovalDto.User_CodeId_SentTo = nextApprovalUserID;

            var responseUPD = await _userApprovalService.UpdateUserApprovalAsync(updApprovalDto);

            if (!responseUPD.Succeeded)
            {
                Console.WriteLine(updApprovalDto);
                var errorContent = responseUPD.Errors;
                var errors = new List<ReturnBaseError>
                                        {
                                            new ReturnBaseError
                                            {
                                                Source = "Approval Process Approve Status",
                                                ErrorMessage = $"API Error: upd else {errorContent}"
                                            }
                                        };
                return ReturnBase<UserApprovalInsertDto>.Fail(errors);
            }

            userApprovalInsertDto2.ActionDate = null;
            userApprovalInsertDto2.Status = 1;
            userApprovalInsertDto2.Confirm_No = confirmNo + 1;
            userApprovalInsertDto2.Date = date;
            userApprovalInsertDto2.ScreenId = screenID;
            userApprovalInsertDto2.Values = primarykeyID;
            userApprovalInsertDto2.TableMasterName = tableName;
            userApprovalInsertDto2.ReceivedDate = actionDate;

            // Get the userID of the next one in the approval detail list --Get ID from Approval using the ScreenID --Get the userID from approval detail using IDScrAproval and RecordID = 1
            string sql = "select User_ID from Approval_d where IDScrAproval = (select ID from Approval where ScreenId = @ScreenID) and RecordID = @RecordID";
            long? userID = connection.QueryFirstOrDefault<long>(sql, new { ScreenID = screenID, RecordID = userApprovalInsertDto2.Confirm_No });
            userApprovalInsertDto2.User_CodeId = userID;

            var responseINSERT = await _userApprovalService.InsertUserApprovalAsync(userApprovalInsertDto2);

            if (responseINSERT.Succeeded)
            {
                return ReturnBase<UserApprovalInsertDto>.Success(responseINSERT.Result);
            }
            else
            {
                var errorContent = responseINSERT.Errors;
                var errors = new List<ReturnBaseError>
                                        {
                                            new ReturnBaseError
                                            {
                                                Source = "Approval Process Approve Status",
                                                ErrorMessage = $"API Error: INSERT ELSE {errorContent}"
                                            }
                                        };
                return ReturnBase<UserApprovalInsertDto>.Fail(errors);
            }
        }

        public async Task<ReturnBase<ApprovalDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Approval.GetById(id);
                if (entity == null)
                    return ReturnBase<ApprovalDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Approval with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<ApprovalDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<ApprovalDto>.Fail(saveResult.Errors);

                return ReturnBase<ApprovalDto>.Success(_mapper.Map<ApprovalDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ApprovalDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteApprovalAsync(IEnumerable<EntityKeyValueDictionary> keysList)
        {
            try
            {
                var deleteResult = await this._commands.BulkDeleteAsync(keysList, this._accountUoW.SaveAsync);
                if (deleteResult.Succeeded)
                {
                    var results = deleteResult.Result.Select(x => new DeleteResultDto
                    {
                        Deleted = x.Succeeded,
                        Errors = x.Errors
                    });

                    return ReturnBase<IEnumerable<DeleteResultDto>>.Success(results);
                }

                var failedResults = keysList.Select(x => new DeleteResultDto
                {
                    Deleted = false,
                    Errors = deleteResult.Errors
                });

                return ReturnBase<IEnumerable<DeleteResultDto>>.Fail(deleteResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DeleteResultDto>>.Fail(ex, this._exceptionManager);
            }
        }

        private IApprovalCommandRepository _commands
        {
            get { return this._accountUoW.Approval; }
        }

        private IApprovalQueryRepository _queries
        {
            get { return this._queriesManager.Approval; }
        }
    }
}
