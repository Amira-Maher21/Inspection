using AutoMapper;
using Inspection.Application.Contracts.Dto.TestTableMasters;
using Inspection.Application.Contracts.Managers;

using Inspection.Application.Contracts.Repositories.Command.TestTableDetails;
using Inspection.Application.Contracts.Repositories.Command.TestTableMasters;
using Inspection.Application.Contracts.Repositories.Command.TestTableSubDetails;
using Inspection.Application.Contracts.Services.TestTableMasters;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.TestTableMaster;
using Inspection.Domain.Models.TestTableMasters;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.TestTableMasters
{

    public class TestTableMasterService : AccountsServiceBase, ITestTableMasterService
    {
        private readonly ITenantResolver _tenantResolver;

        public TestTableMasterService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;

        }
        private ITestTableDetailsCommandRepository _commandsTestTableDetails => _accountUoW.TestTableDetailCommandRepository;
        private ITestTableSubDetailsCommandRepository _commandsTestTableSubDetails => _accountUoW.TestTableSubDetailCommandRepository;


        public async Task<ReturnBase<CreateTestTableMasterDto>> InsertTestTableMasterAsync(CreateTestTableMasterDto insertDto)
        {
            try
            {
                var masterEntity = _mapper.Map<TestTableMaster>(insertDto);

                var masterInsertResult = await _commands.InsertAsync(masterEntity);
                if (!masterInsertResult.Succeeded)
                    return ReturnBase<CreateTestTableMasterDto>.Fail(masterInsertResult.Errors);

                await _accountUoW.SaveAsync(); // get Master Id


                if (insertDto.TestTableDetails != null && insertDto.TestTableDetails.Any())
                {
                    foreach (var detailDto in insertDto.TestTableDetails)
                    {
                        var detailEntity = _mapper.Map<TestTableDetail>(detailDto);
                        detailEntity.TestTableMasterId = masterEntity.Id;

                        var detailInsertResult = await _commandsTestTableDetails.InsertAsync(detailEntity);
                        if (!detailInsertResult.Succeeded)
                            return ReturnBase<CreateTestTableMasterDto>.Fail(detailInsertResult.Errors);


                        if (detailDto.TestTableSubDetails != null && detailDto.TestTableSubDetails.Any())
                        {
                            foreach (var subDto in detailDto.TestTableSubDetails)
                            {
                                var subEntity = _mapper.Map<TestTableSubDetail>(subDto);
                                subEntity.TestTableDetailId = detailEntity.Id;

                                var subInsertResult = await _commandsTestTableSubDetails.InsertAsync(subEntity);
                                if (!subInsertResult.Succeeded)
                                    return ReturnBase<CreateTestTableMasterDto>.Fail(subInsertResult.Errors);

                            }
                            await _accountUoW.SaveAsync();
                        }


                    }
                }

                var resultDto = _mapper.Map<CreateTestTableMasterDto>(masterEntity);
                return ReturnBase<CreateTestTableMasterDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CreateTestTableMasterDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<UpdateTestTableMasterDto>> UpdateTestTableMasterAsync(UpdateTestTableMasterDto updateDto)
        {
            try
            {
                var masterEntity = await _queriesManager.TestTableMasterQueryRepository.GetByIdAsync(updateDto.Id);
                if (masterEntity == null)
                    return ReturnBase<UpdateTestTableMasterDto>.Fail();

                _mapper.Map(updateDto, masterEntity);
                masterEntity.TestTableDetails = null;
                var masterUpdate = await _commands.UpdateAsync(masterEntity);
                if (!masterUpdate.Succeeded)
                    return ReturnBase<UpdateTestTableMasterDto>.Fail(masterUpdate.Errors);


                if (updateDto.TestTableDetails != null && updateDto.TestTableDetails.Any())
                {
                    foreach (var detailDto in updateDto.TestTableDetails)
                    {
                        // Try to find existing detail
                        var existingDetail = await _queriesManager.TestTableDetailQueryRepository.GetByIdAsync(detailDto.Id);

                        TestTableDetail detailEntity;
                        if (existingDetail != null)
                        {
                            // Update existing
                            _mapper.Map(detailDto, existingDetail);
                            existingDetail.TestTableSubDetails = null;
                            existingDetail.TestTableMasterId = masterEntity.Id;
                            var updateResult = await _commandsTestTableDetails.UpdateAsync(existingDetail);
                            if (!updateResult.Succeeded)
                                return ReturnBase<UpdateTestTableMasterDto>.Fail(updateResult.Errors);
                        }
                        else
                        {
                            // Insert new
                            detailEntity = _mapper.Map<TestTableDetail>(detailDto);
                            detailEntity.TestTableMasterId = masterEntity.Id;
                            var insertResult = await _commandsTestTableDetails.InsertAsync(detailEntity);
                            if (!insertResult.Succeeded)
                                return ReturnBase<UpdateTestTableMasterDto>.Fail(insertResult.Errors);
                            detailDto.Id = detailEntity.Id;
                        }


                        if (detailDto.TestTableSubDetails != null && detailDto.TestTableSubDetails.Any())
                        {
                            foreach (var subDto in detailDto.TestTableSubDetails)
                            {
                                var existingSub = await _queriesManager.TestTableSubDetailQueryRepository.GetByIdAsync(subDto.Id);

                                TestTableSubDetail subEntity;
                                if (existingSub != null)
                                {
                                    _mapper.Map(subDto, existingSub);
                                    existingSub.TestTableDetailId = detailDto.Id;
                                    var subUpdate = await _commandsTestTableSubDetails.UpdateAsync(existingSub);
                                    if (!subUpdate.Succeeded)
                                        return ReturnBase<UpdateTestTableMasterDto>.Fail(subUpdate.Errors);
                                }
                                else
                                {
                                    subEntity = _mapper.Map<TestTableSubDetail>(subDto);
                                    subEntity.TestTableDetailId = detailDto.Id;
                                    var subInsert = await _commandsTestTableSubDetails.InsertAsync(subEntity);
                                    if (!subInsert.Succeeded)
                                        return ReturnBase<UpdateTestTableMasterDto>.Fail(subInsert.Errors);
                                }
                            }
                        }
                    }
                }


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateTestTableMasterDto>.Fail(saveResult.Errors);

                var NewMaster = await _queriesManager.TestTableMasterQueryRepository.GetByIdAsync(updateDto.Id);


                var mappedResult = _mapper.Map<UpdateTestTableMasterDto>(NewMaster);
                return ReturnBase<UpdateTestTableMasterDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateTestTableMasterDto>.Fail(ex, _exceptionManager);
            }
        }



        public Task<ReturnBase> DeleteByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<TestTableMaster>> GetEntityAsync(EntityKeyValueDictionary keys)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<TestTableMaster>> InsertAsync(TestTableMaster entity)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<TestTableMaster>> UpdateAsync(TestTableMaster updatedEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<TestTableMaster>> DeleteAsync(EntityKeyValueDictionary keys)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<IEnumerable<ReturnBase<TestTableMaster>>>> BulkDeleteAsync(IEnumerable<EntityKeyValueDictionary> keysList, Func<Task<ReturnBase<int>>> saveFunc)
        {
            throw new NotImplementedException();
        }








        private ITestTableMasterCommandRepository _commands
        {
            get { return _accountUoW.TestTableMasterCommandRepository; }
        }


    }
}
