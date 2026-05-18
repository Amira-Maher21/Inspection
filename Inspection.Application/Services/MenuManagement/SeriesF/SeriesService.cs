using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Dto.MenuManagement.Series;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesDetailsF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.MenuManagement.SeriesF
{
    public class SeriesService : AccountsServiceBase, ISeriesService
    {
        private readonly ITenantResolver _tenantResolver;
        private IScreenCodeQueryRepository _screenCodeQueries => _queriesManager.ScreenCode;
        //private readonly ISeriesDetailsCommandRepository _seriesDetailsCommandRepository;

        public SeriesService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager,
            ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }

        private ISeriesCommandRepository _commands => _accountUoW.Series;
        private ISeriesDetailsCommandRepository _seriesDetailsCommandRepository => _accountUoW.SeriesDetails;
        private ISeriesQueryRepository _queries => _queriesManager.Series;


        public async Task<ReturnBase<Dictionary<string, string>>> GetSeriesCodeWithCustomDate(string screenId, DateTime customDate, string tableName, string seriesTableColumn)
        {
            try
            {
                var seriesCodeResult = await GetSeriesCodeByDate(screenId, customDate);

                if (seriesCodeResult.ContainsKey("errorid") && Convert.ToInt32(seriesCodeResult["errorid"]) != 0)
                {
                    return ReturnBase<Dictionary<string, string>>.Fail(new Exception(seriesCodeResult["errormas"]), _exceptionManager);
                }

                string finalSeriesCode = seriesCodeResult["CodePattern"];

                var seriesNumberResult = await _queries.GetSeriesTableNumberAsync(tableName, seriesTableColumn, screenId, finalSeriesCode);

                return ReturnBase<Dictionary<string, string>>.Success(seriesNumberResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<Dictionary<string, string>>.Fail(ex, _exceptionManager);
            }
        }

        // Add this new private method
        private async Task<Dictionary<string, string>> GetSeriesCodeByDate(string screenId, DateTime requestDate)
        {
            Dictionary<string, string> dickres = new Dictionary<string, string>();

            if (screenId == null)
            {
                dickres.Add("errorid", "100");
                dickres.Add("errormas", "Screen_ID cannot be null");
                dickres.Add("CodePattern", "");
                return dickres;
            }

            var seriesDef = await _queries.GetByScreen_IDAsync(screenId);
            if (seriesDef is null)
            {
                dickres.Add("errorid", "100");
                dickres.Add("errormas", "Series configuration not found for this screen");
                dickres.Add("CodePattern", "");
                return dickres;
            }

            // Use the provided requestDate instead of DateTime.Now
            string formattedPrefix = seriesDef.CodePattern
                .Replace("YYYY", requestDate.Year.ToString())
                .Replace("YY", (requestDate.Year % 100).ToString("D2"))
                .Replace("MM", requestDate.Month.ToString("D2"))
                .Replace("DD", requestDate.Day.ToString("D2"));

            dickres.Add("errorid", "0");
            dickres.Add("errormas", "SAVED");
            dickres.Add("CodePattern", formattedPrefix);
            dickres.Add("PaddingLength", seriesDef.PaddingLength.ToString());

            return dickres;
        }

        public async Task<ReturnBase<SeriesDto>> GetAsync(long id)
        {

            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<SeriesDto>(Item);
                return new ReturnBase<SeriesDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<SeriesDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<SeriesDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<SeriesDto>>.Success(_mapper.Map<List<SeriesDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<SeriesDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<Dictionary<string, string>>> GetSeriesAndNumber(string TableName, string SeriesTableColumn, string Screen_ID)
        {
            try
            {
                var res = await GetSeiresCode(Screen_ID);

                if (res.ContainsKey("errorid") && Convert.ToInt32(res["errorid"]) != 0)
                {
                    return ReturnBase<Dictionary<string, string>>.Fail(new Exception(res["errormas"]), _exceptionManager);

                }

                string FinalCodePattern = res["CodePattern"];

                var list = await _queries.GetSeriesTableNumberAsync(TableName, SeriesTableColumn, Screen_ID, FinalCodePattern);

                return ReturnBase<Dictionary<string, string>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<Dictionary<string, string>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SeriesDto>> CreateAsync(CreateSeriesDto input)
        {
            try
            {
                var entity = _mapper.Map<Series>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<SeriesDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<SeriesDto>.Fail(saveResult.Errors);

                var res = await GetSeiresCode(entity.ScreenCode_Id);

                if (res.ContainsKey("errorid") && Convert.ToInt32(res["errorid"]) != 0)
                {
                    return ReturnBase<SeriesDto>.Fail(new Exception(res["errormas"]), _exceptionManager);
                }

                entity.CodePattern = res["CodePattern"];
                return ReturnBase<SeriesDto>.Success(_mapper.Map<SeriesDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SeriesDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SeriesDto>> UpdateAsync(long id, UpdateSeriesDto input)
        {
            try
            {
                var entity = await _queries.GetByIdAsync(id);
                if (entity == null) return ReturnBase<SeriesDto>.Fail();

                _mapper.Map(input, entity);
                if (_commands == null)
                    throw new InvalidOperationException("_commands is not initialized");

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded) return ReturnBase<SeriesDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<SeriesDto>.Fail(saveResult.Errors);

                return ReturnBase<SeriesDto>.Success(_mapper.Map<SeriesDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SeriesDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _commands.DeleteAsync(keys);
                if (!deleteResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(deleteResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(saveResult.Errors);
                }

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }

        private async Task<Dictionary<string, string>> GetSeiresCode(string Screen_ID = null)
        {
            Dictionary<string, string> dickres = new Dictionary<string, string>();
            if (Screen_ID == null)
            {
                dickres.Add("errorid", "100");
                dickres.Add("errormas", "can not be Screen_ID");
                dickres.Add("CodePattern", "");

                return dickres;
            }

            var seriesDef = await _queries.GetByScreen_IDAsync(Screen_ID);
            if (seriesDef is null)
            {
                dickres.Add("errorid", "100");
                dickres.Add("errormas", "this page not found");
                dickres.Add("CodePattern", "");

                return dickres;
            }

            var now = DateTime.Now;
            string formattedPrefix = seriesDef.CodePattern
                .Replace("YYYY", now.Year.ToString())
                .Replace("YY", (now.Year % 100).ToString("D2"))
                .Replace("MM", now.Month.ToString("D2"))
                .Replace("DD", now.Day.ToString("D2"));

            dickres.Add("errorid", "0");
            dickres.Add("errormas", "SAVED");
            dickres.Add("CodePattern", formattedPrefix);
            return dickres;
        }

        public async Task<ReturnBase<List<ScreenCodeDto>>> GetScreenListListAsync()
        {
            try
            {
                var list = await _screenCodeQueries.GetAllAsync();

                var result = _mapper.Map<List<ScreenCodeDto>>(list.Result.ToList());

                return ReturnBase<List<ScreenCodeDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ScreenCodeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<Dictionary<string, string>>> GetSerialNumberAsync(string menuid)
        {
            try
            {
                var list = await _screenCodeQueries.GetByMenu_IDAsync(menuid);

                var scrr = list;
                if (scrr == null)
                {
                    return null;
                }

                var listm = await GetSeriesAndNumber(scrr.TabelMasterName, scrr.FieldNameCondition, scrr.Screen_ID);
                if (listm == null)
                {
                    return null;
                }

                return ReturnBase<Dictionary<string, string>>.Success(listm.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<Dictionary<string, string>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<Dictionary<string, string>>> GetSeriesCodeWithCustomDateUsingSeriesDetails(long seriesId, DateTime? requestDate)
        {
            //if (_queries == null) throw new Exception("_queries is null");
            //if (_tenantResolver == null) throw new Exception("_tenantResolver is null");
            //if (_accountUoW == null) throw new Exception("_accountUoW is null");
            //if (_accountUoW.SeriesDetails == null) throw new Exception("SeriesDetails repo is null");           

            try
            {
                var seriesData = await _queries.GetByIdAsync(seriesId);
                //if (seriesData == null) throw new Exception("seriesData is null");
                //if (seriesData.CodePattern == null) throw new Exception("CodePattern is null");
                if (seriesData == null)
                {
                    return ReturnBase<Dictionary<string, string>>.Fail();
                }

                var tenantName = _tenantResolver.GetTenantName();
                var effectiveDate = requestDate ?? DateTime.UtcNow;
                var year = effectiveDate.Year;
                var month = effectiveDate.Month;

                // Get or create SeriesDetails for this month/year
                var seriesDetails = await _accountUoW.SeriesDetails.GetOrCreateSeriesDetailsAsync(
                    seriesId,
                    year,
                    month,
                    tenantName,
                    seriesData.ResetPolicy
                );

                if (seriesDetails == null)
                {
                    return ReturnBase<Dictionary<string, string>>.Fail();
                }

                // Increment the current number
                seriesDetails.CurrentNumber++;

                // Update the SeriesDetails
                await _accountUoW.SaveAsync();

                // Pad the number
                string paddedNumber = seriesDetails.CurrentNumber.ToString().PadLeft(seriesData.PaddingLength, '0');

                // Generate the series code pattern
                string formattedPrefix = seriesData.CodePattern
                    .Replace("[YYYY]", effectiveDate.Year.ToString())
                    .Replace("[YY]", (effectiveDate.Year % 100).ToString("D2"))
                    .Replace("[MM]", effectiveDate.Month.ToString("D2"))
                    .Replace("[mm]", effectiveDate.Month.ToString("D1"))
                    .Replace("[DD]", effectiveDate.Day.ToString("D2"))
                    .Replace("[dd]", effectiveDate.Day.ToString("D1"))
                    .Replace("[SEQ]", paddedNumber);


                // Build result dictionary
                var result = new Dictionary<string, string>
                {
                    { "SeriesCode", formattedPrefix },
                    { "SeriesNumber", paddedNumber },
                    //{ "Separator", seriesData.Separator.ToString() },
                    { "FinelSeriesCodeAndSeriesNumber", $"{formattedPrefix}" },
                    { "RunningNumber", seriesDetails.CurrentNumber.ToString() }
                };

                return ReturnBase<Dictionary<string, string>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<Dictionary<string, string>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<Series?> GetSeriesByScreenCodeAsync(string screenCode)
        {
            return await _queries.GetByScreen_IDAsync(screenCode);
        }

        public async Task<ReturnBase<SeriesPatternDto>> GetSeriesPatternByScreenCodeAsync(string screenCode)
        {
            var series = await _queriesManager.Series.GetByScreen_IDAsync(screenCode);

            if (series == null || !series.IsActive)
            {
                return ReturnBase<SeriesPatternDto>.Fail(
                    new Exception($"No active series for screen '{screenCode}'"),
                    _exceptionManager
                );
            }

            var now = DateTime.Now;

            // FORMAT WITHOUT CONSUMING SEQUENCE
            var previewPattern = series.CodePattern
                .Replace("[YYYY]", now.Year.ToString())
                .Replace("[YY]", (now.Year % 100).ToString("D2"))
                .Replace("[MM]", now.Month.ToString("D2"))
                .Replace("[DD]", now.Day.ToString("D2"))
                .Replace("[SEQ]", new string('#', series.PaddingLength));

            return ReturnBase<SeriesPatternDto>.Success(
                new SeriesPatternDto
                {
                    Id = series.Id,
                    Pattern = previewPattern
                }
            );
        }




        public async Task<string> GetMaxCodeAsync(
                 string tableName,
                 string fieldName,
                 string groupFieldName = null,
                 string groupFieldValue = null,
                 int paddingLength = 5)
        {
            try
            {
                return await _screenCodeQueries.GetMaxCodeAsync(
                   tableName,
                   fieldName,
                   groupFieldName,
                   groupFieldValue,
                   paddingLength
               );
            }
            catch (Exception ex)
            {
                return 1.ToString().PadLeft(paddingLength, '0');
            }
        }
    }
}
