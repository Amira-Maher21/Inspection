using AutoMapper;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Posting;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Services.Accounting.AccountBalances;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.BankAccounts;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.Banks;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.Branches;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.Cashing;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.CostUnits;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.FiscalYears;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.ILedger;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Application.Contracts.Services.Accounting.AccountSystem;
using Inspection.Application.Contracts.Services.Accounting.AccountSystem.PaymentTerms;
using Inspection.Application.Contracts.Services.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Services.Accounting.AR.PurchaseReturns;
using Inspection.Application.Contracts.Services.Accounting.AR.SalesInvoices;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Contracts.Services.Accounting.Assets.AssetTransactions;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetGroups;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Services.Accounting.ChartOfAccounts;
using Inspection.Application.Contracts.Services.Accounting.Payments;
using Inspection.Application.Contracts.Services.Accounting.Payments.CashPayments;
using Inspection.Application.Contracts.Services.Accounting.Payments.CashReceipts;
using Inspection.Application.Contracts.Services.Accounting.Payments.CashTransfers;
using Inspection.Application.Contracts.Services.Accounting.Payments.CreditNotes;
using Inspection.Application.Contracts.Services.Accounting.Payments.DebitNotes;
using Inspection.Application.Contracts.Services.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Services.Accounting.PR.MasterData.SupplierGroups;
using Inspection.Application.Contracts.Services.Accounting.PR.MasterData.Suppliers;
using Inspection.Application.Contracts.Services.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Services.AccountResolution;
using Inspection.Application.Contracts.Services.ApprovalManagement;
using Inspection.Application.Contracts.Services.Constracting.Setup.Commitment;
using Inspection.Application.Contracts.Services.Contracting.Setup.Activitys;
using Inspection.Application.Contracts.Services.Contracting.Setup.CostCodes;
using Inspection.Application.Contracts.Services.Contracting.Setup.Divisions;
using Inspection.Application.Contracts.Services.Contracting.Setup.IBOQs;
using Inspection.Application.Contracts.Services.Contracting.Setup.ISubcontractBOQs;
using Inspection.Application.Contracts.Services.Contracting.Setup.WBSs;
using Inspection.Application.Contracts.Services.DMS.DocumentComments;
using Inspection.Application.Contracts.Services.DMS.Documents;
using Inspection.Application.Contracts.Services.DMS.DocumentShares;
using Inspection.Application.Contracts.Services.DMS.FolderPermissions;
using Inspection.Application.Contracts.Services.DMS.Folders;
using Inspection.Application.Contracts.Services.DMS.ShareAccessLogs;
using Inspection.Application.Contracts.Services.DMS.Tags;
using Inspection.Application.Contracts.Services.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Services.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentTypes;
using Inspection.Application.Contracts.Services.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Services.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Services.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Services.HRManagement.Department;
using Inspection.Application.Contracts.Services.HRManagement.Employees;
using Inspection.Application.Contracts.Services.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Services.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Services.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Services.HRManagement.JobRequests;
using Inspection.Application.Contracts.Services.HRManagement.JobTitles;
using Inspection.Application.Contracts.Services.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Contracts.Services.Inspection.Techinal.Certificates;
using Inspection.Application.Contracts.Services.Inspection.Techinal.Checklists;
using Inspection.Application.Contracts.Services.Inspection.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Services.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Services.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Contracts.Services.Inspection.Techinal.Inspectors;
using Inspection.Application.Contracts.Services.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Services.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionMethods;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Services.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Services.Inventory.Batchs;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Items;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.UnitOfMeasureConversionConversion;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Services.Inventory.ItemGroups;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryBalances;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Services.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Services.LocalizationManagement;
using Inspection.Application.Contracts.Services.Manufacturing.Setup.ProductionOrders;
using Inspection.Application.Contracts.Services.MenuManagement;
using Inspection.Application.Contracts.Services.MenuManagement.AreaF;
using Inspection.Application.Contracts.Services.MenuManagement.BranchF;
using Inspection.Application.Contracts.Services.MenuManagement.Programs;
using Inspection.Application.Contracts.Services.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Services.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Services.SalesManagment.sales;
using Inspection.Application.Contracts.Services.SalesManagment.sales.DeliveryNotes;
using Inspection.Application.Contracts.Services.SalesManagment.sales.JobOrderDashboard;
using Inspection.Application.Contracts.Services.SalesManagment.sales.SalesOrder;
using Inspection.Application.Contracts.Services.SalesManagment.sales.SalesQuotationDashboard;
using Inspection.Application.Contracts.Services.SalesManagment.Setup.SalesPersons;
using Inspection.Application.Contracts.Services.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Contracts.Services.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Contracts.Services.Sample.CurrencyExchangeRate;
using Inspection.Application.Contracts.Services.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Services.Setting.ModuleSettings;
using Inspection.Application.Contracts.Services.System;
using Inspection.Application.Contracts.Services.System.Languages;
using Inspection.Application.Contracts.Services.System.TaxCategorys;
using Inspection.Application.Contracts.Services.SystemConfigurations.Cities;
using Inspection.Application.Contracts.Services.SystemConfigurations.Companies;
using Inspection.Application.Contracts.Services.SystemConfigurations.Country;
using Inspection.Application.Contracts.Services.SystemConfigurations.Currencies;
using Inspection.Application.Contracts.Services.SystemConfigurations.CurrencyExchangeRateMasters;
using Inspection.Application.Contracts.Services.SystemConfigurations.Operations;
using Inspection.Application.Contracts.Services.TestTableMasters;
using Inspection.Application.Contracts.Services.UserNotificationManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Posting.Posting.Engine;
using Inspection.Application.Posting.Posting.Handlers;
using Inspection.Application.Services.Accounting.AccountBalanceServices;
using Inspection.Application.Services.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Services.Accounting.AccountSetup.BankAccounts;
using Inspection.Application.Services.Accounting.AccountSetup.Banks;
using Inspection.Application.Services.Accounting.AccountSetup.Branches;
using Inspection.Application.Services.Accounting.AccountSetup.Cashing;
using Inspection.Application.Services.Accounting.AccountSetup.CostUnits;
using Inspection.Application.Services.Accounting.AccountSetup.FiscalYears;
using Inspection.Application.Services.Accounting.AccountSetup.LedgerService;
using Inspection.Application.Services.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Application.Services.Accounting.AccountSystem;
using Inspection.Application.Services.Accounting.AccountSystem.PaymentTerms;
using Inspection.Application.Services.Accounting.AR.MasterData;
using Inspection.Application.Services.Accounting.AR.PurchaseReturns;
using Inspection.Application.Services.Accounting.AR.SalesInvoices;
using Inspection.Application.Services.Accounting.AssetAccountingEvent.AssetAccountingEvent;
using Inspection.Application.Services.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Services.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Application.Services.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Services.Accounting.Assets.AssetTransactions;
using Inspection.Application.Services.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Services.Accounting.Assets.Setup.AssetComponents;
using Inspection.Application.Services.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Services.Accounting.Assets.Setup.AssetGroups;
using Inspection.Application.Services.Accounting.Assets.Setup.AssetLocations;
using Inspection.Application.Services.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Services.Accounting.ChartOfAccounts;
using Inspection.Application.Services.Accounting.Payments.CashPayments;
using Inspection.Application.Services.Accounting.Payments.CashReceipts;
using Inspection.Application.Services.Accounting.Payments.CashTransfers;
using Inspection.Application.Services.Accounting.Payments.CreditNotes;
using Inspection.Application.Services.Accounting.Payments.DebitNotes;
using Inspection.Application.Services.Accounting.Payments.JournalEntrys;
using Inspection.Application.Services.Accounting.Payments.JournalEntryTemplates;
using Inspection.Application.Services.Accounting.PR.MasterData.SupplierGroup;
using Inspection.Application.Services.Accounting.PR.MasterData.Suppliers;
using Inspection.Application.Services.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Services.AccountResolution;
using Inspection.Application.Services.ApprovalManagement;
using Inspection.Application.Services.Contracting.Setup.Activitys;
using Inspection.Application.Services.Contracting.Setup.BOQs;
using Inspection.Application.Services.Contracting.Setup.Commitments;
using Inspection.Application.Services.Contracting.Setup.CostCodes;
using Inspection.Application.Services.Contracting.Setup.Divisions;
using Inspection.Application.Services.Contracting.Setup.SubcontractSubcontractBOQs;
using Inspection.Application.Services.Contracting.Setup.WBSs;
using Inspection.Application.Services.DMS.DocumentComments;
using Inspection.Application.Services.DMS.Documents;
using Inspection.Application.Services.DMS.DocumentShares;
using Inspection.Application.Services.DMS.FolderPermissions;
using Inspection.Application.Services.DMS.Folders;
using Inspection.Application.Services.DMS.ShareAccessLogs;
using Inspection.Application.Services.DMS.Tags;
using Inspection.Application.Services.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Services.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Services.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Services.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Services.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Services.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Services.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Application.Services.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Services.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Services.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Services.HRManagement.ApplicantCVs;
using Inspection.Application.Services.HRManagement.Departments;
using Inspection.Application.Services.HRManagement.Employees;
using Inspection.Application.Services.HRManagement.InterviewEvaluations;
using Inspection.Application.Services.HRManagement.JobAdvertisements;
using Inspection.Application.Services.HRManagement.JobOfferNegotiations;
using Inspection.Application.Services.HRManagement.JobRequests;
using Inspection.Application.Services.HRManagement.JobTitles;
using Inspection.Application.Services.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Services.Inspection.Techinal.Certificates;
using Inspection.Application.Services.Inspection.Techinal.Checklists;
using Inspection.Application.Services.Inspection.Techinal.ChecklistTemplates;
using Inspection.Application.Services.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Services.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Services.Inspection.Techinal.Inspectors;
using Inspection.Application.Services.InspectionManagement.CustomerLocations;
using Inspection.Application.Services.InspectionManagement.CustomerProjects;
using Inspection.Application.Services.InspectionManagement.EquipmentTypes;
using Inspection.Application.Services.InspectionManagement.InspectionCertificates;
using Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Services.InspectionManagement.InspectionChecklists;
using Inspection.Application.Services.InspectionManagement.InspectionMethods;
using Inspection.Application.Services.InspectionManagement.InspectionReports;
using Inspection.Application.Services.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Application.Services.InspectionManagement.InspectionRequestLinesF;
using Inspection.Application.Services.InspectionManagement.InspectionRequests;
using Inspection.Application.Services.InspectionManagement.InspectionServiceOrders;
using Inspection.Application.Services.InspectionManagement.InspectionTypes;
using Inspection.Application.Services.InspectionManagement.InspectorCategory;
using Inspection.Application.Services.InspectionManagement.ServicesItemsF;
using Inspection.Application.Services.InspectionManagement.ServiceTypes;
using Inspection.Application.Services.Inventory.InventorySetup;
using Inspection.Application.Services.Inventory.InventorySetup.Batchs;
using Inspection.Application.Services.Inventory.InventorySetup.Brands;
using Inspection.Application.Services.Inventory.InventorySetup.Colors;
using Inspection.Application.Services.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Services.Inventory.InventorySetup.Items;
using Inspection.Application.Services.Inventory.InventorySetup.Models;
using Inspection.Application.Services.Inventory.InventorySetup.Sizes;
using Inspection.Application.Services.Inventory.InventorySetup.UnitOfMeasure;
using Inspection.Application.Services.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Application.Services.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Services.Inventory.ItemGroups;
using Inspection.Application.Services.Inventory.System.InventoryBalances;
using Inspection.Application.Services.Inventory.System.InventoryCostLayers;
using Inspection.Application.Services.Inventory.System.InventoryLedgers;
using Inspection.Application.Services.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Services.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Services.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Services.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Services.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Services.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Services.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Services.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Services.LocalizationManagement;
using Inspection.Application.Services.Manufacturing.Setup.Contracting.ProductionOrders;
using Inspection.Application.Services.MenuManagement;
using Inspection.Application.Services.MenuManagement.AreaF;
using Inspection.Application.Services.MenuManagement.BranchF;
using Inspection.Application.Services.MenuManagement.Programs;
using Inspection.Application.Services.MenuManagement.Screen_permissions;
using Inspection.Application.Services.MenuManagement.SeriesF;
using Inspection.Application.Services.MenuManagement.User_Codes;
using Inspection.Application.Services.MenuManagement.User_Groups;
using Inspection.Application.Services.SalesManagment.sales;
using Inspection.Application.Services.SalesManagment.sales.JobOrderDashboard;
using Inspection.Application.Services.SalesManagment.sales.SalesOrderService;
using Inspection.Application.Services.SalesManagment.SalesQuotationDashboard;
using Inspection.Application.Services.SalesManagment.Setup.SalesPersons;
using Inspection.Application.Services.SalesManagment.Transactions.DeliveryNotes;
using Inspection.Application.Services.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Services.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Services.Sample.CurrencyExchangeRate;
using Inspection.Application.Services.Setting.ModuleSettings;
using Inspection.Application.Services.System;
using Inspection.Application.Services.System.Languages;
using Inspection.Application.Services.System.TaxCategorys;
using Inspection.Application.Services.SystemConfigurations.Cities;
using Inspection.Application.Services.SystemConfigurations.Companies;
using Inspection.Application.Services.SystemConfigurations.Countris;
using Inspection.Application.Services.SystemConfigurations.Currencies;
using Inspection.Application.Services.SystemConfigurations.CurrencyExchangeRateMastes;
using Inspection.Application.Services.SystemConfigurations.Operations;
using Inspection.Application.Services.TestTableMasters;
using Inspection.Application.Services.UserNotificationManagement;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.Exceptions;


namespace Inspection.Application.Managers
{
    public partial class AccountsServicesManger : IAccountsServicesManger
    {
        private readonly IAccountUnitOfWork _accountUoW;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IMapper _mapper;
        private readonly DbContext _dbcontext;
        private readonly IExceptionManager _exceptionManager;
        private readonly IConfiguration _configuration;
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        // private readonly IEventHandler<GoodsReceiptPostedEvent> _eventHandler;
        // private readonly IEventBus _eventBus;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountBalanceService _AccountBalanceService;

        private readonly IPostingHandler<IPostingEntity> _postingHandler;
        private readonly IJournalEntryQueryRepository _journalEntryQueryRepository;
        private readonly IEnumerable<IPostingHandler<IPostingEntity>> _handlers;


        public AccountsServicesManger(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            IConfiguration configuration,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator,
            /* IEventHandler<GoodsReceiptPostedEvent> eventHandler*//*, IEventBus eventBus */
            IServiceProvider serviceProvider,
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            DbContext dbContext,
            IEnumerable<IPostingHandler<IPostingEntity>> handlers,
            IJournalEntryQueryRepository journalEntryQueryRepository,
            IAccountBalanceService AccountBalanceService
        )
        {
            this._accountUoW = accountUoW;
            this._dbcontext = dbContext;
            this._queriesManager = queriesManager;
            this._mapper = mapper;
            this._exceptionManager = exceptionManager;
            this._configuration = configuration;
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;
            //this._eventHandler = eventHandler;
            //this._eventBus = eventBus;
            this._serviceProvider = serviceProvider;
            this._httpClient = httpClient;
            this._httpContextAccessor = httpContextAccessor;

            this._handlers = handlers;
            this._journalEntryQueryRepository = journalEntryQueryRepository;

            this._AccountBalanceService = AccountBalanceService;

            //_equipmentLookupRepository = equipmentLookupRepository;

            //Sample 

            this._scurrencyExchangeRateService = new Lazy<ISCurrencyExchangeRateService>(new SCurrencyExchangeRateService(this._accountUoW, _queriesManager, _mapper, _exceptionManager));
            //Sample

            this._inspectionReportService = new Lazy<IInspectionReportService>(new InspectionReportAppService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._inspectionRequestService = new Lazy<IInspectionRequestService>(() => new InspectionRequestService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value));
            this._inspectionDashboardService = new Lazy<IInspectionDashboardService>(() => new InspectionDashboardService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._salesQuotationDashboardService = new Lazy<ISalesQuotationDashboardService>(() => new SalesQuotationDashboardService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._inspectionServiceOrder = new Lazy<IInspectionServiceOrder>(() => new InspectionServiceOrder(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value));
            this._serviceTypeService = new Lazy<IServiceTypeService>(new ServiceTypeServices(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            //this._equipmentService = new Lazy<IEquipmentService>(new EquipmentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._equipmentService = new Lazy<IEquipmentService>(() => new EquipmentService(_accountUoW, _queriesManager, _mapper, _exceptionManager, this._tenantResolver, this._seriesService.Value));
            this._equipmentInspectionService = new Lazy<IEquipmentInspectionService>(new EquipmentInspectionService(this._accountUoW, this._queriesManager, this._mapper, _exceptionManager));
            this._maintenanceReportService = new Lazy<IMaintenanceReportService>(new MaintenanceReportService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._maintenanceScheduleService = new Lazy<IMaintenanceScheduleService>(new MaintenanceScheduleService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._localizationService = new Lazy<ILocalizationService>(new LocalizationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._menuService = new Lazy<IMenuService>(new MenuService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._approvalService = new Lazy<IApprovalService>(new ApprovalService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, _configuration, _httpClient, tenantResolver, _httpContextAccessor));
            this._userApprovalService = new Lazy<IUserApprovalService>(new UserApprovalService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._approvalDelegationService = new Lazy<IApprovalDelegationService>(new ApprovalDelegationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._userNotificationsService = new Lazy<IUserNotificationsService>(new UserNotificationsService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, _configuration, _httpClient));
            this._seriesService = new Lazy<ISeriesService>(new SeriesService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._CustomerLocationService = new Lazy<ICustomerLocationService>(new CustomerLocationServices(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._CustomerProjectService = new Lazy<ICustomerProjectService>(new CustomerProjectServices(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._serviceItemService = new Lazy<IServiceItemService>(new ServiceItemService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));

            this._salesOrderService = new Lazy<ISalesOrderService>(new SalesOrderService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value));

            this._customerBranchService = new Lazy<ICustomerBranchService>(new CustomerBranchService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._areaService = new Lazy<IAreaService>(new AreaService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._inspectionMethodService = new Lazy<IInspectionMethodService>(new InspectionMethodService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._equipmentTypeService = new Lazy<IEquipmentTypeService>(new EquipmentTypeServices(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._jobOrderService = new Lazy<IJobOrderService>(new JobOrderService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value));
            this._inspectionCertificate = new Lazy<IInspectionCertificateService>(new InspectionCertificateService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionRequestLinesService = new Lazy<IInspectionRequestLinesService>(new InspectionRequestLinesServices(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._InspectionRequestDetailSubcontractorService = new Lazy<IInspectionRequestDetailSubcontractorService>(new InspectionRequestDetailSubcontractorServices(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._equipmentsMoreInformationService = new Lazy<IEquipmentsMoreInformationService>(new EquipmentsMoreInformationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._applicantCVService = new Lazy<IApplicantCVService>(new ApplicantCVService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._departmentService = new Lazy<IDepartmentService>(new DepartmentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._employeeService = new Lazy<IEmployeeService>(new EmployeeService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._testTableMasterService = new Lazy<ITestTableMasterService>(new TestTableMasterService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._companyEquipmentService = new Lazy<ICompanyEquipmentService>(new CompanyEquipmentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentAccessoriesService = new Lazy<IEquipmentAccessoriesService>(new EquipmentAccessoryService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentSoftwareService = new Lazy<IEquipmentSoftwareService>(new EquipmentSoftwareService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentCalibrationHistoryService = new Lazy<IEquipmentCalibrationHistoryService>(new EquipmentCalibrationHistoryService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentPreventiveMaintenanceService = new Lazy<IEquipmentPreventiveMaintenanceService>(new EquipmentPreventiveMaintenanceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentMaintenanceAndRepairRecordService = new Lazy<IEquipmentMaintenanceAndRepairRecordService>(new EquipmentMaintenanceAndRepairRecordService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._jobRequestService = new Lazy<IJobRequestService>(new JobRequestservice(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._jobTitleService = new Lazy<IJobTitleService>(new JobTitleService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._interviewEvaluationService = new Lazy<IInterviewEvaluationService>(new InterviewEvaluationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._jobAdvertisementService = new Lazy<IJobAdvertisementService>(new JobAdvertisementService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._jobOfferNegotiationService = new Lazy<IJobOfferNegotiationService>(new JobOfferNegotiationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));
            this._EquipmentsMoreInformationDetailService = new Lazy<IEquipmentsMoreInformationDetailService>(new EquipmentsMoreInformationDetailService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentCategoryService = new Lazy<IEquipmentCategoryService>(new EquipmentCategoryService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentsMoreInformationTemplateDetailService = new Lazy<IEquipmentsMoreInformationTemplateDetailService>(new EquipmentsMoreInformationTemplateDetailService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._EquipmentsMoreInformationTemplateService = new Lazy<IEquipmentsMoreInformationTemplateService>(new EquipmentsMoreInformationTemplateService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionChecklistService = new Lazy<IInspectionChecklistService>(new InspectionChecklistService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionChecklistMoreInformationService = new Lazy<IInspectionChecklistMoreInformationService>(new InspectionChecklistMoreInformationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionChecklistMoreInformationDetailService = new Lazy<IInspectionChecklistMoreInformationDetailService>(new InspectionChecklistMoreInformationDetailService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionChecklistMoreInformationTemplateService = new Lazy<IInspectionChecklistMoreInformationTemplateService>(new InspectionChecklistMoreInformationTemplateService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionChecklistMoreInformationTemplateDetailService = new Lazy<IInspectionChecklistMoreInformationTemplateDetailService>(new InspectionChecklistMoreInformationTemplateDetailService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InspectionTypeService = new Lazy<IInspectionTypeService>(new InspectionTypeService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._User_GroupService = new Lazy<IUser_GroupService>(new User_GroupService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._Screen_permissionService = new Lazy<IScreen_permissionService>(new Screen_permissionService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));

            // Inspector Management
            this._inspectorCategoryService = new Lazy<IInspectorCategoryService>(new InspectorCategoryService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));

            // SystemConfigurations
            this._companyService = new Lazy<ICompanyService>(new CompanyService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._currencyService = new Lazy<ICurrencyService>(() => new CurrencyService(_accountUoW, _queriesManager, _mapper, _tenantResolver, _exceptionManager, _templateGenerator));
            this._currencyExchangeRateMasteService = new Lazy<ICurrencyExchangeRateMasteService>(new CurrencyExchangeRateMasteService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._countryService = new Lazy<ICountryService>(new CountryService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager));
            this._cityService = new Lazy<ICityService>(new CityService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._operationServic = new Lazy<IOperationService>(new OperationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            //System
            this._taxServise = new Lazy<ITaxTypeServise>(new TaxTypeServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._taxCategory = new Lazy<ITaxCategoryServise>(new TaxCategoryServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._Languages = new Lazy<ILanguageServise>(new LanguageServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            // Sales Management
            this._salesQuotationService = new Lazy<ISalesQuotationService>(new SalesQuotationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._SalesReturn = new Lazy<ISalesReturnService>(new SalesReturnService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value));

            // Accounting
            this._costCenterService = new Lazy<ICostCenterService>(new CostCenterService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._costUnitService = new Lazy<ICostUnitService>(new CostUnitService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._bankService = new Lazy<IBankService>(new BankService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._bankAccountService = new Lazy<IBankAccountService>(new BankAccountService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._fiscalYearService = new Lazy<IFiscalYearService>(new FiscalYearService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._accountingPeriodService = new Lazy<IAccountingPeriodService>(new AccountingPeriodService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._JobOrderDetailService = new Lazy<IJobOrderDetailService>(new JobOrderDetailService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._accountTypeService = new Lazy<IAccountTypeService>(new AccountTypeService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._chartOfAccountService = new Lazy<IChartOfAccountService>(new ChartOfAccountService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._defaultAccountTypeService = new Lazy<IDefaultAccountTypeService>(new DefaultAccountTypeService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._defaultAccountGroupService = new Lazy<IDefaultAccountGroupService>(new DefaultAccountGroupService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._defaultAccountAssignment = new Lazy<IDefaultAccountAssignmentService>(new DefaultAccountAssignmentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._paymentTerm = new Lazy<IPaymentTermService>(new PaymentTermService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._supplierService = new Lazy<ISupplierService>(new SupplierService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._customerGroupService = new Lazy<ICustomerGroupService>(new CustomerGroupService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._supplierGroupService = new Lazy<ISupplierGroupService>(new SupplierGroupService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._customerService = new Lazy<ICustomerServiceMaster>(new CustomerService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._cashReceiptService = new Lazy<ICashReceiptService>(new CashReceiptService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._cashPaymentService = new Lazy<ICashPaymentService>(new CashPaymentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._salesInvoiceService = new Lazy<ISalesInvoiceService>(new SalesInvoiceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._PurchaseInvoice = new Lazy<IPurchaseInvoiceService>(() => new PurchaseInvoiceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._templateGenerator, this._tenantResolver, this._seriesService.Value));
            this._DeliveryNote = new Lazy<IDeliveryNoteService>(() => new DeliveryNoteService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value, this._templateGenerator));
            this._GoodsIssue = new Lazy<IGoodsIssueService>(new GoodsIssueService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._creditNoteService = new Lazy<ICreditNoteService>(new CreditNoteService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._PurchaseReturn = new Lazy<IPurchaseReturnService>(new PurchaseReturnService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._debitNoteService = new Lazy<IDebitNoteService>(new DebitNoteService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._cashTransferService = new Lazy<ICashTransferService>(new CashTransferService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._assetCustodyService = new Lazy<IAssetCustodyService>(new AssetCustodyService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));

            // Account Resolver
            this._accountResolverService = new Lazy<IAccountResolverService>(new AccountResolverService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            // Posting Engine
            this._postingEngine = new Lazy<IPostingEngine>(
                () => new PostingEngine(
                    this._accountUoW,
                    this._queriesManager,
                    this._mapper,
                    this._AccountBalanceService,
                    this._exceptionManager,
                    this._tenantResolver,
                    this._serviceProvider
                )
            );

            this._ledgerService = new Lazy<ILedgerService>(new LedgerService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));

            this._cashService = new Lazy<ICashService>(new CashService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._branchService = new Lazy<IBranchService>(new BranchService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._warehouseService = new Lazy<IWarehouseService>(new WarehouseService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._brandService = new Lazy<IBrandService>(new BrandService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._modelService = new Lazy<IModelService>(new ModelService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._unitOfMeasureService = new Lazy<IUnitOfMeasureService>(new UnitOfMeasureService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._unitOfMeasureConversionService = new Lazy<IUnitOfMeasureConversionService>(new UnitOfMeasureConversionService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._itemGroupService = new Lazy<IItemGroupService>(new ItemGroupService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._colorService = new Lazy<IColorService>(new ColorService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator));
            this._sizeService = new Lazy<ISizeService>(new SizeService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator));
            this._itemService = new Lazy<IItemService>(new ItemService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._inventoryCostLayersService = new Lazy<IInventoryCostLayersService>(new InventoryCostLayerService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator));
            this._warehouseLocationService = new Lazy<IWarehouseLocationService>(new WarehouseLocationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._inventoryOpeningBalanceService = new Lazy<IInventoryOpeningBalanceService>(new InventoryOpeningBalanceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._inventoryLedgerService = new Lazy<IInventoryLedgerService>(new InventoryLedgerService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._journalEntryService = new Lazy<IJournalEntryService>(new JournalEntryService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));

            this._journalEntryTemplateService = new Lazy<IJournalEntryTemplateService>(new JournalEntryTemplateService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator, this._seriesService.Value));
            this._modeOfPaymentService = new Lazy<IModeOfPaymentService>(new ModeOfPaymentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            // Fixed Asset
            this._assetDepreciationScheduleService = new Lazy<IAssetDepreciationScheduleService>(new AssetDepreciationScheduleService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._fixedAssetService = new Lazy<IFixedAssetService>(new FixedAssetService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._assetTransactionService = new Lazy<IAssetTransactionService>(new AssetTransactionService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator));
            this._assetCategoryService = new Lazy<IAssetCategoryService>(new AssetCategoryService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator));
            this._assetAccountingEventService = new Lazy<IAssetAccountingEventService>(new AssetAccountingEventService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._assetAccountingEventAccountService = new Lazy<IAssetAccountingEventAccountService>(new AssetAccountingEventAccountService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._inventoryBalanceService = new Lazy<IInventoryBalanceService>(new InventoryBalanceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._goodsReceiptService = new Lazy<IGoodsReceiptService>(new GoodsReceiptService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._serviceProvider, this._seriesService.Value));
            this._inspectionStandardService = new Lazy<IInspectionStandardService>(new InspectionStandardService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._checklistTemplateService = new Lazy<IChecklistTemplateService>(new ChecklistTemplateService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator, this._seriesService.Value));
            this._assetGroupService = new Lazy<IAssetGroupService>(new AssetGroupService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._iSalesPersonServise = new Lazy<ISalesPersonServise>(new SalesPersonServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._iModuleSettingServise = new Lazy<IModuleSettingServise>(new ModuleSettingServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._ProgramService = new Lazy<IProgramService>(new ProgramService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._User_CodeServise = new Lazy<IUser_CodeServise>(new User_CodeServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._assetComponentService = new Lazy<IAssetComponentService>(() => new AssetComponentService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator));
            this._assetMaintenanceService = new Lazy<IAssetMaintenanceService>(new AssetMaintenanceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));

            // Inventory
            this._itemAttributeService = new Lazy<IItemAttributeService>(new ItemAttributeService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._goodsTransferOutService = new Lazy<IGoodsTransferOutService>(new GoodsTransferOutService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._goodsTransferInService = new Lazy<IGoodsTransferInService>(new GoodsTransferInService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._Batch = new Lazy<IBatchServise>(new BatchServise(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._inventoryAdjustmentService = new Lazy<IInventoryAdjustmentService>(new InventoryAdjustmentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._ScrapReasonService = new Lazy<IScrapReasonService>(() => new ScrapReasonService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver));
            this._InventoryScrapService = new Lazy<IInventoryScrapService>(() => new InventoryScrapService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._seriesService.Value));
            // Inspection
            this._inspectorService = new Lazy<IInspectorService>(new InspectorService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._certificateService = new Lazy<ICertificateService>(new CertificateService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._checklistService = new Lazy<IChecklistService>(new ChecklistService(this._accountUoW, this._queriesManager, this._mapper, this._tenantResolver, this._exceptionManager, this._templateGenerator, this._seriesService.Value));
            this._JobOrderDashboardService = new Lazy<IJobOrderDashboardService>(new JobOrderDashboardService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager));

            this._inspectorCompetencyService = new Lazy<IInspectorCompetencyService>(new InspectorCompetencyService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));
            this._accreditationBodyService = new Lazy<IAccreditationBodyService>(new AccreditationBodyService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            // DMS
            this._folderService = new Lazy<IFolderService>(new FolderService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._folderPermissionService = new Lazy<IFolderPermissionService>(new FolderPermissionService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._documentShareService = new Lazy<IDocumentShareService>(new DocumentShareService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this.User_CodeServise));
            this._tagService = new Lazy<ITagService>(new TagService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._documentService = new Lazy<IDocumentService>(new DocumentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._ShareAccessLogService = new Lazy<IShareAccessLogService>(new ShareAccessLogService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._documentCommentService = new Lazy<IDocumentCommentService>(new DocumentCommentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));

            this._accountBalanceService = new Lazy<IAccountBalanceService>(new AccountBalanceService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            // Contracting
            this._boqService = new Lazy<IBOQService>(new BOQService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));
            this._subcontractBOQService = new Lazy<ISubcontractBOQService>(new SubcontractBOQService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator, this._seriesService.Value));


            this._wBSService = new Lazy<IWBSService>(() =>
                new WBSService(_accountUoW, _queriesManager, _mapper, _exceptionManager, _tenantResolver, _seriesService.Value));

            this._divisionService = new Lazy<IDivisionService>(() =>
                new DivisionService(_accountUoW, _queriesManager, _mapper, _exceptionManager, _tenantResolver, _templateGenerator));

            this._costCodeService = new Lazy<ICostCodeService>(() =>
                new CostCodeService(_accountUoW, _queriesManager, _mapper, _exceptionManager, _tenantResolver, _templateGenerator));

            this._activityService = new Lazy<IActivityService>(() =>
                new ActivityService(_accountUoW, _queriesManager, _mapper, _exceptionManager, _tenantResolver, _seriesService.Value));


            // Commitment
            this._commitmentService = new Lazy<ICommitmentService>(new CommitmentService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            // Manufacturing
            this._productionOrderService = new Lazy<IProductionOrderService>(new ProductionOrderService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

            // Asset Location
            this._assetLocationService = new Lazy<IAssetLocationService>(new AssetLocationService(this._accountUoW, this._queriesManager, this._mapper, this._exceptionManager, this._tenantResolver, this._templateGenerator));

        }
    }
}