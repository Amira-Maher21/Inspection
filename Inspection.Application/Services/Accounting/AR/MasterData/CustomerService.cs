using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Services.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AR.MasterData
{

    public class CustomerService : AccountsServiceBase, ICustomerServiceMaster
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;

        private readonly IExcelTemplateGenerator _templateGenerator;

        private readonly ISeriesService _seriesService;


        public CustomerService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
            , ISeriesService seriesService
        )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));

            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }



        private ICustomerCommandRepository _commands => _accountUoW.CustomerCommandRepository;

        private ICustomerQueryRepository _queries => _queriesManager.CustomerQuery ?? throw new NullReferenceException("ISupplierQueryRepo is null");



        public async Task<ReturnBase<CustomerDto>> Create(CustomerCreateDto dto)
        {
            try
            {
                EmailValidator.Validate(dto.Email);
                //dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();



                var entity = _mapper.Map<Customer>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();



                // SCREEN CODE
                const string SCREEN_CODE = "Customer";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<CustomerDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate series number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id, null
                     );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<CustomerDto>.Fail(seriesResult.Errors);

                entity.Code =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);



                // Addd Customer Contacts
                if (dto.CustomerContact != null && dto.CustomerContact.Any())
                {
                    entity.CustomerContact = _mapper.Map<List<CustomerContact>>(dto.CustomerContact);

                    foreach (var contact in entity.CustomerContact)
                    {
                        contact.Customer = entity;
                    }
                }
                else
                {
                    entity.CustomerContact = new List<CustomerContact>();
                }
                // Add Customer Locations
                if (dto.CustomerLocation != null && dto.CustomerLocation.Any())
                {
                    entity.CustomerLocation = _mapper.Map<List<CustomerLocation>>(dto.CustomerLocation);
                    foreach (var location in entity.CustomerLocation)
                    {
                        location.Customers = entity;
                    }
                }
                else
                {
                    entity.CustomerLocation = new List<CustomerLocation>();
                }
                // Add Customer Projects
                if (dto.CustomerProject != null && dto.CustomerProject.Any())
                {
                    entity.CustomerProject = _mapper.Map<List<CustomerProject>>(dto.CustomerProject);
                    foreach (var project in entity.CustomerProject)
                    {
                        project.Customers = entity;
                    }
                }
                else
                {
                    entity.CustomerProject = new List<CustomerProject>();
                }



                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CustomerDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<CustomerDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<CustomerDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<CustomerDto>.Success(_mapper.Map<CustomerDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerDto>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<CustomerDto>> Update(CustomerUpdateDto dto)
        //{
        //    try
        //    {
        //        EmailValidator.Validate(dto.Email);
        //        dto.Code.ValidateAsCode();
        //        dto.Name.ValidateAsName();
        //        var entity = await _queriesManager.CustomerQuery.GetById(dto.Id);
        //        if (entity == null)
        //        {
        //            return ReturnBase<CustomerDto>.Fail(new List<ReturnBaseError>
        //    {
        //        new() { ErrorCode = "404", ErrorMessage = "Item Not Found" }
        //    });
        //        }


        //        entity.Tenant_ID = _tenantResolver.GetTenantName();


        //        // Update Item main fields
        //        _mapper.Map(dto, entity);

        //        var existingVariants = entity.CustomerContact.ToList();

        //        // Case 1: User sent NO variants → HARD DELETE ALL
        //        if (dto.CustomerContact == null || !dto.CustomerContact.Any())
        //        {
        //            await _commands.DeleteCustomerByItemId(entity.Id);
        //        }
        //        else
        //        {
        //            var dtoVariantIds = dto.CustomerContact
        //                .Where(v => v.Id > 0)
        //                .Select(v => v.Id)
        //                .ToHashSet();

        //            // CREATE & UPDATE
        //            foreach (var ContactDto in dto.CustomerContact)
        //            {
        //                // CREATE
        //                if (ContactDto.Id == 0)
        //                {
        //                    var newContact = _mapper.Map<CustomerContact>(ContactDto);
        //                    newContact.CustomerId = entity.Id;

        //                    entity.CustomerContact.Add(newContact);
        //                }
        //                else
        //                {
        //                    // UPDATE
        //                    var existingVariant =
        //                        existingVariants.FirstOrDefault(v => v.Id == ContactDto.Id);

        //                    if (existingVariant != null)
        //                    {
        //                        _mapper.Map(ContactDto, existingVariant);
        //                    }
        //                }
        //            }

        //            // HARD DELETE removed variants
        //            var removedVariants = existingVariants
        //                .Where(v => !dtoVariantIds.Contains(v.Id))
        //                .Select(v => v.Id)
        //                .ToList();

        //            if (removedVariants.Any())
        //            {
        //                await _commands.DeleteCustomerByIds(removedVariants);
        //            }
        //        }

        //        // Save
        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //            return ReturnBase<CustomerDto>.Fail(saveResult.Errors);


        //        return ReturnBase<CustomerDto>.Success(_mapper.Map<CustomerDto>(entity));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<CustomerDto>.Fail(ex, _exceptionManager);
        //    }

        public async Task<ReturnBase<CustomerDto>> Update(CustomerUpdateDto dto)
        {
            try
            {
                EmailValidator.Validate(dto.Email);
                dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();

                var entity = await _queriesManager.CustomerQuery.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<CustomerDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Customer Not Found" }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // MAIN FIELDS
                _mapper.Map(dto, entity);

                // CONTACTS
                await SyncCustomerContacts(entity, dto);

                // LOCATIONS
                await SyncCustomerLocations(entity, dto);

                // PROJECTS
                await SyncCustomerProjects(entity, dto);


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CustomerDto>.Fail(saveResult.Errors);

                return ReturnBase<CustomerDto>.Success(_mapper.Map<CustomerDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerDto>.Fail(ex, _exceptionManager);
            }
        }

        private async Task SyncCustomerContacts(Customer entity, CustomerUpdateDto dto)
        {
            var existingContacts = entity.CustomerContact.ToList();

            if (dto.CustomerContact == null || !dto.CustomerContact.Any())
            {
                await _commands.DeleteCustomerContactsByCustomerId(entity.Id);
                return;
            }

            var dtoIds = dto.CustomerContact
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var contactDto in dto.CustomerContact)
            {
                if (contactDto.Id == 0)
                {
                    var newContact = _mapper.Map<CustomerContact>(contactDto);
                    newContact.CustomerId = entity.Id;
                    entity.CustomerContact.Add(newContact);
                }
                else
                {
                    var existing = existingContacts.FirstOrDefault(x => x.Id == contactDto.Id);
                    if (existing != null)
                        _mapper.Map(contactDto, existing);
                }
            }

            var removedIds = existingContacts
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteCustomerContactsByIds(removedIds);
        }

        private async Task SyncCustomerLocations(Customer entity, CustomerUpdateDto dto)
        {
            var existingLocations = entity.CustomerLocation.ToList();

            if (dto.CustomerLocation == null || !dto.CustomerLocation.Any())
            {
                await _commands.DeleteCustomerLocationsByCustomerId(entity.Id);
                return;
            }

            var dtoIds = dto.CustomerLocation
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var locationDto in dto.CustomerLocation)
            {
                if (locationDto.Id == 0)
                {
                    var newLocation = _mapper.Map<CustomerLocation>(locationDto);
                    newLocation.CustomerId = entity.Id;
                    entity.CustomerLocation.Add(newLocation);
                }
                else
                {
                    var existing = existingLocations.FirstOrDefault(x => x.Id == locationDto.Id);
                    if (existing != null)
                        _mapper.Map(locationDto, existing);
                }
            }

            var removedIds = existingLocations
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteCustomerLocationsByIds(removedIds);
        }

        private async Task SyncCustomerProjects(Customer entity, CustomerUpdateDto dto)
        {
            var existingProjects = entity.CustomerProject.ToList();

            if (dto.CustomerProject == null || !dto.CustomerProject.Any())
            {
                await _commands.DeleteCustomerProjectsByCustomerId(entity.Id);
                return;
            }

            var dtoIds = dto.CustomerProject
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var projectDto in dto.CustomerProject)
            {
                if (projectDto.Id == 0)
                {
                    var newProject = _mapper.Map<CustomerProject>(projectDto);
                    newProject.CustomerId = entity.Id;
                    entity.CustomerProject.Add(newProject);
                }
                else
                {
                    var existing = existingProjects.FirstOrDefault(x => x.Id == projectDto.Id);
                    if (existing != null)
                        _mapper.Map(projectDto, existing);
                }
            }

            var removedIds = existingProjects
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteCustomerProjectsByIds(removedIds);
        }







        public async Task<ReturnBase<CustomerDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<CustomerDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Customer Not Found" }
                    });

                return ReturnBase<CustomerDto>.Success(_mapper.Map<CustomerDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<CustomerDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CustomerQuery.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Color Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CustomerDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CustomerDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CustomerDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CustomerDto>(entity);

                return ReturnBase<CustomerDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CustomerDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded) return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result.Select(c => _mapper.Map<CustomerReturnSearchDto>(c)).ToList();
                return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        //Add List 

        public async Task<ReturnBase<IEnumerable<CustomerLocationDto>>> AddLocations(List<CreateCustomerLocationDto> locations)
        {
            try
            {
                if (locations == null || !locations.Any())
                    return ReturnBase<IEnumerable<CustomerLocationDto>>.Fail(
                        new List<ReturnBaseError> { new() { ErrorCode = "400", ErrorMessage = "Locations list is empty" } });

                var customerId = locations.First().CustomerId;

                var customer = await _queriesManager.CustomerQuery.GetById(customerId);
                if (customer == null)
                    return ReturnBase<IEnumerable<CustomerLocationDto>>.Fail(
                        new List<ReturnBaseError> { new() { ErrorCode = "404", ErrorMessage = "Customer Not Found" } });

                var newLocations = _mapper.Map<List<CustomerLocation>>(locations);

                foreach (var location in newLocations)
                {
                    location.CustomerId = customer.Id;
                    customer.CustomerLocation.Add(location);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerLocationDto>>.Fail(saveResult.Errors);

                var resultDto = newLocations.Select(l => _mapper.Map<CustomerLocationDto>(l)).ToList();

                return ReturnBase<IEnumerable<CustomerLocationDto>>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerLocationDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CustomerProjectDto>>> AddProjects(List<CreateCustomerProjectDto> projects)
        {
            try
            {
                if (projects == null || !projects.Any())
                    return ReturnBase<IEnumerable<CustomerProjectDto>>.Fail(
                        new List<ReturnBaseError> { new() { ErrorCode = "400", ErrorMessage = "Projects list is empty" } });

                var customerId = projects.First().CustomerId;

                var customer = await _queriesManager.CustomerQuery.GetById(customerId);
                if (customer == null)
                    return ReturnBase<IEnumerable<CustomerProjectDto>>.Fail(
                        new List<ReturnBaseError> { new() { ErrorCode = "404", ErrorMessage = "Customer Not Found" } });

                var newProjects = _mapper.Map<List<CustomerProject>>(projects);

                foreach (var project in newProjects)
                {
                    project.CustomerId = customer.Id;
                    customer.CustomerProject.Add(project);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerProjectDto>>.Fail(saveResult.Errors);

                var resultDto = newProjects.Select(p => _mapper.Map<CustomerProjectDto>(p)).ToList();

                return ReturnBase<IEnumerable<CustomerProjectDto>>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerProjectDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CustomerContactDto>>> AddContacts(List<CustomerContactCreateDto> contacts)
        {
            try
            {
                if (contacts == null || !contacts.Any())
                    return ReturnBase<IEnumerable<CustomerContactDto>>.Fail(
                        new List<ReturnBaseError> { new() { ErrorCode = "400", ErrorMessage = "Contacts list is empty" } });

                var customerId = contacts.First().CustomerId;

                var customer = await _queriesManager.CustomerQuery.GetById(customerId);
                if (customer == null)
                    return ReturnBase<IEnumerable<CustomerContactDto>>.Fail(
                        new List<ReturnBaseError> { new() { ErrorCode = "404", ErrorMessage = "Customer Not Found" } });

                var newContacts = _mapper.Map<List<CustomerContact>>(contacts);

                foreach (var contact in newContacts)
                {
                    contact.CustomerId = customer.Id;
                    customer.CustomerContact.Add(contact);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerContactDto>>.Fail(saveResult.Errors);

                var resultDto = newContacts.Select(c => _mapper.Map<CustomerContactDto>(c)).ToList();

                return ReturnBase<IEnumerable<CustomerContactDto>>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerContactDto>>.Fail(ex, _exceptionManager);
            }
        }


        //public async Task<ReturnBase<CustomerDto>> Delete(long id)
        //{
        //    try
        //    {
        //        var entity = await _queriesManager.CustomerQuery.GetById(id);
        //        if (entity == null)
        //            return ReturnBase<CustomerDto>.Fail(new List<ReturnBaseError>
        //            {
        //                new() { ErrorCode = "404", ErrorMessage = "Supplier Not Found" }
        //            });

        //        entity.DisableCustomer();
        //        var updateResult = await _commands.UpdateAsync(entity);
        //        if (!updateResult.Succeeded) return ReturnBase<CustomerDto>.Fail(updateResult.Errors);

        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded) return ReturnBase<CustomerDto>.Fail(saveResult.Errors);

        //        return ReturnBase<CustomerDto>.Success(_mapper.Map<CustomerDto>(entity));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<CustomerDto>.Fail(ex, _exceptionManager);
        //    }
        //}
    }
}
