using Inspection.Application.Contracts.Posting;
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

namespace Inspection.Application.Managers
{
    public partial class AccountsServicesManger
    {
        //Sample
        private readonly Lazy<ISCurrencyExchangeRateService> _scurrencyExchangeRateService;
        //Sample

        private readonly Lazy<IInspectionReportService> _inspectionReportService;
        private readonly Lazy<IJobOrderDashboardService> _JobOrderDashboardService;


        private readonly Lazy<IInspectionRequestService> _inspectionRequestService;
        private readonly Lazy<IInspectionDashboardService> _inspectionDashboardService;
        private readonly Lazy<ISalesQuotationDashboardService> _salesQuotationDashboardService;
        private readonly Lazy<IInspectionServiceOrder> _inspectionServiceOrder;
        private readonly Lazy<IServiceTypeService> _serviceTypeService;
        private readonly Lazy<IEquipmentService> _equipmentService;
        private readonly Lazy<IEquipmentInspectionService> _equipmentInspectionService;
        private readonly Lazy<IMaintenanceReportService> _maintenanceReportService;
        private readonly Lazy<IMaintenanceScheduleService> _maintenanceScheduleService;
        private readonly Lazy<ILocalizationService> _localizationService;
        private readonly Lazy<IMenuService> _menuService;
        private readonly Lazy<IApprovalService> _approvalService;
        private readonly Lazy<IUserApprovalService> _userApprovalService;
        private readonly Lazy<IApprovalDelegationService> _approvalDelegationService;
        private readonly Lazy<IUserNotificationsService> _userNotificationsService;
        private readonly Lazy<ISeriesService> _seriesService;

        private readonly Lazy<ICustomerLocationService> _CustomerLocationService;
        private readonly Lazy<ICustomerProjectService> _CustomerProjectService;
        private readonly Lazy<IServiceItemService> _serviceItemService;


        private readonly Lazy<ISalesOrderLinesService> _salesOrderItemService;
        private readonly Lazy<ISalesOrderService> _salesOrderService;

        private readonly Lazy<ICustomerBranchService> _customerBranchService;
        private readonly Lazy<IAreaService> _areaService;
        private readonly Lazy<IInspectionMethodService> _inspectionMethodService;
        private readonly Lazy<IInspectorCategoryService> _inspectorCategoryService;

        private readonly Lazy<IEquipmentTypeService> _equipmentTypeService;
        private readonly Lazy<IJobOrderService> _jobOrderService;
        private readonly Lazy<IInspectionCertificateService> _inspectionCertificate;
        private readonly Lazy<IInspectionRequestLinesService> _InspectionRequestLinesService;
        private readonly Lazy<IInspectionRequestDetailSubcontractorService> _InspectionRequestDetailSubcontractorService;
        private readonly Lazy<IEquipmentsMoreInformationService> _equipmentsMoreInformationService;
        private readonly Lazy<IApplicantCVService> _applicantCVService;
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<ITestTableMasterService> _testTableMasterService;
        private readonly Lazy<ITestTableSubDetailsService> _testTableSubDetailService;
        private readonly Lazy<ITestTableDetailService> _testTableDetailService;
        private readonly Lazy<ICompanyEquipmentService> _companyEquipmentService;
        private readonly Lazy<IEquipmentAccessoriesService> _EquipmentAccessoriesService;
        private readonly Lazy<IEquipmentSoftwareService> _EquipmentSoftwareService;
        private readonly Lazy<IEquipmentCalibrationHistoryService> _EquipmentCalibrationHistoryService;
        private readonly Lazy<IEquipmentPreventiveMaintenanceService> _EquipmentPreventiveMaintenanceService;
        private readonly Lazy<IEquipmentMaintenanceAndRepairRecordService> _EquipmentMaintenanceAndRepairRecordService;
        private readonly Lazy<IJobRequestService> _jobRequestService;
        private readonly Lazy<IJobTitleService> _jobTitleService;
        private readonly Lazy<IInterviewEvaluationService> _interviewEvaluationService;
        private readonly Lazy<IJobAdvertisementService> _jobAdvertisementService;
        private readonly Lazy<IJobOfferNegotiationService> _jobOfferNegotiationService;
        private readonly Lazy<IEquipmentsMoreInformationDetailService> _EquipmentsMoreInformationDetailService;
        private readonly Lazy<IEquipmentCategoryService> _EquipmentCategoryService;
        private readonly Lazy<IEquipmentsMoreInformationTemplateDetailService> _EquipmentsMoreInformationTemplateDetailService;
        private readonly Lazy<IEquipmentsMoreInformationTemplateService> _EquipmentsMoreInformationTemplateService;
        private readonly Lazy<IInspectionChecklistService> _InspectionChecklistService;
        private readonly Lazy<IInspectionChecklistMoreInformationService> _InspectionChecklistMoreInformationService;
        private readonly Lazy<IInspectionChecklistMoreInformationDetailService> _InspectionChecklistMoreInformationDetailService;
        private readonly Lazy<IInspectionChecklistMoreInformationTemplateService> _InspectionChecklistMoreInformationTemplateService;
        private readonly Lazy<IInspectionChecklistMoreInformationTemplateDetailService> _InspectionChecklistMoreInformationTemplateDetailService;
        private readonly Lazy<IInspectionTypeService> _InspectionTypeService;
        private readonly Lazy<IUser_GroupService> _User_GroupService;
        private readonly Lazy<IScreen_permissionService> _Screen_permissionService;

        //SystemConfigurations

        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<ICurrencyService> _currencyService;
        private readonly Lazy<ICountryService> _countryService;
        private readonly Lazy<ICurrencyExchangeRateMasteService> _currencyExchangeRateMasteService;
        private readonly Lazy<ICityService> _cityService;
        private readonly Lazy<IOperationService> _operationServic;

        //System
        private readonly Lazy<ITaxTypeServise> _taxServise;
        private readonly Lazy<ITaxCategoryServise> _taxCategory;
        private readonly Lazy<ILanguageServise> _Languages;

        // Sales Management
        private readonly Lazy<ISalesQuotationService> _salesQuotationService;
        private readonly Lazy<ISalesReturnService> _SalesReturn;

        // Account Resolver
        private readonly Lazy<IAccountResolverService> _accountResolverService;

        // Accounting
        private readonly Lazy<ICostCenterService> _costCenterService;
        private readonly Lazy<ICostUnitService> _costUnitService;
        private readonly Lazy<IBankService> _bankService;
        private readonly Lazy<IBankAccountService> _bankAccountService;
        private readonly Lazy<IFiscalYearService> _fiscalYearService;
        private readonly Lazy<IAccountingPeriodService> _accountingPeriodService;
        private readonly Lazy<IJobOrderDetailService> _JobOrderDetailService;
        private readonly Lazy<IAccountTypeService> _accountTypeService;
        private readonly Lazy<IChartOfAccountService> _chartOfAccountService;
        private readonly Lazy<IDefaultAccountTypeService> _defaultAccountTypeService;
        private readonly Lazy<IDefaultAccountGroupService> _defaultAccountGroupService;
        private readonly Lazy<IDefaultAccountAssignmentService> _defaultAccountAssignment;
        private readonly Lazy<IPaymentTermService> _paymentTerm;
        private readonly Lazy<ISupplierService> _supplierService;
        private readonly Lazy<ICustomerServiceMaster> _customerService;

        private readonly Lazy<IPostingEngine> _postingEngine;
        private readonly Lazy<ILedgerService> _ledgerService;

        private readonly Lazy<ICustomerGroupService> _customerGroupService;
        private readonly Lazy<ISupplierGroupService> _supplierGroupService;
        private readonly Lazy<ICashService> _cashService;
        private readonly Lazy<IBranchService> _branchService;
        private readonly Lazy<IWarehouseService> _warehouseService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IModelService> _modelService;
        private readonly Lazy<IUnitOfMeasureService> _unitOfMeasureService;
        private readonly Lazy<IUnitOfMeasureConversionService> _unitOfMeasureConversionService;
        private readonly Lazy<IItemGroupService> _itemGroupService;
        private readonly Lazy<ISizeService> _sizeService;
        private readonly Lazy<IItemService> _itemService;
        private readonly Lazy<IInventoryCostLayersService> _inventoryCostLayersService;
        private readonly Lazy<IColorService> _colorService;
        private readonly Lazy<IAssetCategoryService> _assetCategoryService;
        private readonly Lazy<IInventoryBalanceService> _inventoryBalanceService;
        private readonly Lazy<IGoodsReceiptService> _goodsReceiptService;
        private readonly Lazy<IAssetTransactionService> _assetTransactionService;
        private readonly Lazy<IWarehouseLocationService> _warehouseLocationService;
        private readonly Lazy<IInventoryOpeningBalanceService> _inventoryOpeningBalanceService;
        private readonly Lazy<IInventoryLedgerService> _inventoryLedgerService;
        private readonly Lazy<IJournalEntryService> _journalEntryService;
        private readonly Lazy<IJournalEntryTemplateService> _journalEntryTemplateService;
        private readonly Lazy<IModeOfPaymentService> _modeOfPaymentService;
        private readonly Lazy<ICashReceiptService> _cashReceiptService;
        private readonly Lazy<ICashPaymentService> _cashPaymentService;
        private readonly Lazy<ISalesInvoiceService> _salesInvoiceService;
        private readonly Lazy<IPurchaseInvoiceService> _PurchaseInvoice;
        private readonly Lazy<IDeliveryNoteService> _DeliveryNote;
        private readonly Lazy<IGoodsIssueService> _GoodsIssue;
        private readonly Lazy<IPurchaseReturnService> _PurchaseReturn;
        private readonly Lazy<ICreditNoteService> _creditNoteService;
        private readonly Lazy<IScrapReasonService> _ScrapReasonService;
        private readonly Lazy<IInventoryScrapService> _InventoryScrapService;

        private readonly Lazy<IDebitNoteService> _debitNoteService;
        private readonly Lazy<ICashTransferService> _cashTransferService;


        // Inventory
        private readonly Lazy<IItemAttributeService> _itemAttributeService;
        private readonly Lazy<IGoodsTransferOutService> _goodsTransferOutService;
        private readonly Lazy<IGoodsTransferInService> _goodsTransferInService;
        private readonly Lazy<IBatchServise> _Batch;
        private readonly Lazy<IInventoryAdjustmentService> _inventoryAdjustmentService;


        // FixedAsset
        private readonly Lazy<IAssetDepreciationScheduleService> _assetDepreciationScheduleService;
        private readonly Lazy<IFixedAssetService> _fixedAssetService;
        private readonly Lazy<IAssetAccountingEventService> _assetAccountingEventService;
        private readonly Lazy<IAssetAccountingEventAccountService> _assetAccountingEventAccountService;
        private readonly Lazy<IAssetComponentService> _assetComponentService;

        private readonly Lazy<IAssetGroupService> _assetGroupService;
        private readonly Lazy<IAssetCustodyService> _assetCustodyService;


        private readonly Lazy<ISalesPersonServise> _iSalesPersonServise;
        private readonly Lazy<IModuleSettingServise> _iModuleSettingServise;
        private readonly Lazy<IProgramService> _ProgramService;
        private readonly Lazy<IUser_CodeServise> _User_CodeServise;
        private readonly Lazy<IAssetMaintenanceService> _assetMaintenanceService;


        //Inspection 
        private readonly Lazy<IInspectionStandardService> _inspectionStandardService;
        private readonly Lazy<IChecklistTemplateService> _checklistTemplateService;


        // Inspection
        private readonly Lazy<ICertificateService> _certificateService;
        private readonly Lazy<IInspectorService> _inspectorService;
        private readonly Lazy<IChecklistService> _checklistService;
        private readonly Lazy<IInspectorCompetencyService> _inspectorCompetencyService;
        private readonly Lazy<IAccreditationBodyService> _accreditationBodyService;

        // DMS
        private readonly Lazy<IFolderService> _folderService;
        private readonly Lazy<IFolderPermissionService> _folderPermissionService;
        private readonly Lazy<IDocumentShareService> _documentShareService;
        private readonly Lazy<ITagService> _tagService;
        private readonly Lazy<IDocumentService> _documentService;
        private readonly Lazy<IShareAccessLogService> _ShareAccessLogService;
        private readonly Lazy<IDocumentCommentService> _documentCommentService;
        private readonly Lazy<IAccountBalanceService> _accountBalanceService;

        // Commitment
        private readonly Lazy<ICommitmentService> _commitmentService;
        // Contracting


        private readonly Lazy<IProductionOrderService> _productionOrderService;
        private readonly Lazy<IBOQService> _boqService;
        private readonly Lazy<ISubcontractBOQService> _subcontractBOQService;

        private readonly Lazy<IWBSService> _wBSService;
        private readonly Lazy<IDivisionService> _divisionService;
        private readonly Lazy<ICostCodeService> _costCodeService;
        private readonly Lazy<IActivityService> _activityService;


        // Asset Location
        private readonly Lazy<IAssetLocationService> _assetLocationService;


        //Sample  
        public ISCurrencyExchangeRateService SCurrencyExchangeRateService { get { return this._scurrencyExchangeRateService.Value; } }
        //Sample

        public IInspectionReportService InspectionReportService { get { return this._inspectionReportService.Value; } }
        public ISalesQuotationDashboardService ISalesQuotationDashboardService { get { return this._salesQuotationDashboardService.Value; } }
        public IInspectionRequestService InspectionRequestService { get { return this._inspectionRequestService.Value; } }
        public IInspectionDashboardService IInspectionDashboardService { get { return this._inspectionDashboardService.Value; } }
        public IInspectionServiceOrder InspectionServiceOrder { get { return this._inspectionServiceOrder.Value; } }
        public IServiceTypeService ServiceTypeService { get { return this._serviceTypeService.Value; } }
        public IEquipmentService EquipmentService { get { return this._equipmentService.Value; } }
        public IEquipmentInspectionService EquipmentInspectionService { get { return this._equipmentInspectionService.Value; } }
        public IMaintenanceReportService MaintenanceReportService { get { return this._maintenanceReportService.Value; } }
        public IMaintenanceScheduleService MaintenanceScheduleService { get { return this._maintenanceScheduleService.Value; } }
        public ILocalizationService LocalizationService { get { return this._localizationService.Value; } }
        public IMenuService MenuService { get { return this._menuService.Value; } }
        public IApprovalService ApprovalService { get { return this._approvalService.Value; } }
        public IUserApprovalService UserApprovalService { get { return this._userApprovalService.Value; } }
        public IApprovalDelegationService ApprovalDelegationService { get { return this._approvalDelegationService.Value; } }
        public IUserNotificationsService UserNotificationsService { get { return this._userNotificationsService.Value; } }
        public ISeriesService SeriesService { get { return this._seriesService.Value; } }

        public ICustomerLocationService CustomerLocationService { get { return this._CustomerLocationService.Value; } }
        public ICustomerProjectService CustomerProjectService { get { return this._CustomerProjectService.Value; } }
        public IServiceItemService ServicesItemsService { get { return this._serviceItemService.Value; } }
        public ISalesOrderService SalesOrderService { get { return this._salesOrderService.Value; } }
        public ICustomerBranchService CustomerBranchService { get { return this._customerBranchService.Value; } }
        public IAreaService AreaService { get { return this._areaService.Value; } }
        public IInspectionMethodService InspectionMethodService { get { return this._inspectionMethodService.Value; } }
        public IInspectorCategoryService InspectorCategoryService { get { return this._inspectorCategoryService.Value; } }
        public IEquipmentTypeService EquipmentTypeService { get { return this._equipmentTypeService.Value; } }
        public IJobOrderService JobOrderService { get { return this._jobOrderService.Value; } }
        public IEquipmentsMoreInformationService EquipmentsMoreInformationService { get { return this._equipmentsMoreInformationService.Value; } }
        public IInspectionCertificateService InspectionCertificateService { get { return this._inspectionCertificate.Value; } }
        public IInspectionRequestLinesService InspectionRequestLinesService { get { return this._InspectionRequestLinesService.Value; } }
        public IInspectionRequestDetailSubcontractorService InspectionRequestDetailSubcontractorService { get { return this._InspectionRequestDetailSubcontractorService.Value; } }
        public IApplicantCVService ApplicantCVService { get { return this._applicantCVService.Value; } }
        public IDepartmentService DepartmentService { get { return this._departmentService.Value; } }
        public IEmployeeService EmployeeService { get { return this._employeeService.Value; } }
        public ITestTableMasterService TestTableMasterService { get { return this._testTableMasterService.Value; } }
        public ITestTableDetailService TestTableDetailService { get { return this._testTableDetailService.Value; } }
        public ITestTableSubDetailsService TestTableSubDetailService { get { return this._testTableSubDetailService.Value; } }
        public ICompanyEquipmentService CompanyEquipmentService { get { return this._companyEquipmentService.Value; } }
        public IEquipmentAccessoriesService EquipmentAccessoriesService { get { return this._EquipmentAccessoriesService.Value; } }
        public IEquipmentSoftwareService EquipmentSoftwareService { get { return this._EquipmentSoftwareService.Value; } }
        public IEquipmentCalibrationHistoryService EquipmentCalibrationHistoryService { get { return this._EquipmentCalibrationHistoryService.Value; } }
        public IEquipmentPreventiveMaintenanceService EquipmentPreventiveMaintenanceService { get { return this._EquipmentPreventiveMaintenanceService.Value; } }
        public IEquipmentMaintenanceAndRepairRecordService EquipmentMaintenanceAndRepairRecordService { get { return this._EquipmentMaintenanceAndRepairRecordService.Value; } }

        public IJobRequestService JobRequestService { get { return this._jobRequestService.Value; } }
        public IJobTitleService JobTitleService { get { return this._jobTitleService.Value; } }

        public IInterviewEvaluationService InterviewEvaluationService { get { return this._interviewEvaluationService.Value; } }
        public IJobAdvertisementService JobAdvertisementService { get { return this._jobAdvertisementService.Value; } }
        public IJobOfferNegotiationService JobOfferNegotiationService { get { return this._jobOfferNegotiationService.Value; } }
        public IEquipmentsMoreInformationDetailService EquipmentsMoreInformationDetailService { get { return this._EquipmentsMoreInformationDetailService.Value; } }
        public IEquipmentCategoryService EquipmentCategoryService { get { return this._EquipmentCategoryService.Value; } }
        public IEquipmentsMoreInformationTemplateDetailService EquipmentsMoreInformationTemplateDetailService { get { return this._EquipmentsMoreInformationTemplateDetailService.Value; } }
        public IEquipmentsMoreInformationTemplateService EquipmentsMoreInformationTemplateService { get { return this._EquipmentsMoreInformationTemplateService.Value; } }

        public IInspectionChecklistService InspectionChecklistService { get { return this._InspectionChecklistService.Value; } }
        public IInspectionChecklistMoreInformationService InspectionChecklistMoreInformationService { get { return this._InspectionChecklistMoreInformationService.Value; } }
        public IInspectionChecklistMoreInformationDetailService InspectionChecklistMoreInformationDetailService { get { return this._InspectionChecklistMoreInformationDetailService.Value; } }
        public IInspectionChecklistMoreInformationTemplateService InspectionChecklistMoreInformationTemplateService { get { return this._InspectionChecklistMoreInformationTemplateService.Value; } }
        public IInspectionChecklistMoreInformationTemplateDetailService InspectionChecklistMoreInformationTemplateDetailService { get { return this._InspectionChecklistMoreInformationTemplateDetailService.Value; } }
        public IInspectionTypeService InspectionTypeService { get { return this._InspectionTypeService.Value; } }
        public IUser_GroupService User_GroupService { get { return this._User_GroupService.Value; } }
        public IScreen_permissionService Screen_permissionService { get { return this._Screen_permissionService.Value; } }


        //SystemConfigurations
        public ICompanyService CompanyService { get { return this._companyService.Value; } }
        public ICurrencyService CurrencyService { get { return this._currencyService.Value; } }
        public ICountryService CountryService { get { return this._countryService.Value; } }
        public ICityService CityService { get { return this._cityService.Value; } }
        public ICurrencyExchangeRateMasteService CurrencyExchangeRateMasteService { get { return this._currencyExchangeRateMasteService.Value; } }
        public IOperationService OperationService { get { return this._operationServic.Value; } }

        //System 
        public ITaxTypeServise TaxService { get { return this._taxServise.Value; } }
        public ITaxCategoryServise TaxCategory { get { return this._taxCategory.Value; } }
        public ILanguageServise Languages { get { return this._Languages.Value; } }

        // Sales Management
        public ISalesQuotationService SalesQuotationService { get { return this._salesQuotationService.Value; } }
        public ISalesReturnService SalesReturn { get { return this._SalesReturn.Value; } }

        // Accounting
        public ICostCenterService CostCenterService { get { return this._costCenterService.Value; } }
        public ICostUnitService CostUnitService { get { return this._costUnitService.Value; } }
        public IFiscalYearService FiscalYearService { get { return this._fiscalYearService.Value; } }
        public IAccountingPeriodService AccountingPeriodService { get { return this._accountingPeriodService.Value; } }
        public IJobOrderDetailService JobOrderDetailService { get { return this._JobOrderDetailService.Value; } }
        public IAccountTypeService AccountTypeService { get { return this._accountTypeService.Value; } }
        public IDefaultAccountTypeService DefaultAccountTypeService { get { return this._defaultAccountTypeService.Value; } }
        public IChartOfAccountService ChartOfAccountService { get { return this._chartOfAccountService.Value; } }
        public IDefaultAccountGroupService DefaultAccountGroupService { get { return this._defaultAccountGroupService.Value; } }
        public IDefaultAccountAssignmentService DefaultAccountAssignmentService { get { return this._defaultAccountAssignment.Value; } }
        public IPaymentTermService PaymentTermService { get { return this._paymentTerm.Value; } }
        public ISupplierService SupplierService { get { return this._supplierService.Value; } }
        public ICustomerServiceMaster CustomerService { get { return this._customerService.Value; } }
        public ICashReceiptService CashReceiptService { get { return this._cashReceiptService.Value; } }
        public ICashPaymentService CashPaymentService { get { return this._cashPaymentService.Value; } }
        public ISalesInvoiceService SalesInvoiceService { get { return this._salesInvoiceService.Value; } }
        public IDeliveryNoteService DeliveryNote { get { return this._DeliveryNote.Value; } }
        public IGoodsIssueService GoodsIssue { get { return this._GoodsIssue.Value; } }
        public IPurchaseReturnService PurchaseReturn { get { return this._PurchaseReturn.Value; } }
        public ICreditNoteService CreditNoteService { get { return this._creditNoteService.Value; } }
        public IDebitNoteService DebitNoteService { get { return this._debitNoteService.Value; } }
        public ICashTransferService CashTransferService { get { return this._cashTransferService.Value; } }


        public IScrapReasonService ScrapReasonService { get { return this._ScrapReasonService.Value; } }
        public IInventoryScrapService InventoryScrapService { get { return this._InventoryScrapService.Value; } }

        // Account Resolver
        public IAccountResolverService AccountResolverService { get { return this._accountResolverService.Value; } }

        // Posting engine
        public IPostingEngine PostingEngine { get { return this._postingEngine.Value; } }

        public ILedgerService LedgerService { get { return this._ledgerService.Value; } }

        public ICustomerGroupService CustomerGroupService { get { return this._customerGroupService.Value; } }
        public ISupplierGroupService SupplierGroupService { get { return this._supplierGroupService.Value; } }
        public ICashService CashService { get { return this._cashService.Value; } }
        public IBankAccountService BankAccountService { get { return this._bankAccountService.Value; } }
        public IBankService BankService { get { return this._bankService.Value; } }
        public IBranchService BranchService { get { return this._branchService.Value; } }
        public IWarehouseService WarehouseService { get { return this._warehouseService.Value; } }
        public IModelService ModelService { get { return this._modelService.Value; } }
        public IBrandService BrandService { get { return this._brandService.Value; } }
        public IUnitOfMeasureService UnitOfMeasureService { get { return this._unitOfMeasureService.Value; } }
        public IUnitOfMeasureConversionService UnitOfMeasureConversionService { get { return this._unitOfMeasureConversionService.Value; } }
        public IItemGroupService ItemGroupService { get { return this._itemGroupService.Value; } }
        public ISizeService SizeService { get { return this._sizeService.Value; } }
        public IColorService ColorService { get { return this._colorService.Value; } }
        public IItemService ItemService { get { return this._itemService.Value; } }
        public IInventoryCostLayersService InventoryCostLayersService { get { return this._inventoryCostLayersService.Value; } }
        public IWarehouseLocationService WarehouseLocationService { get { return this._warehouseLocationService.Value; } }
        public IInventoryOpeningBalanceService InventoryOpeningBalanceService { get { return this._inventoryOpeningBalanceService.Value; } }
        public IInventoryLedgerService InventoryLedgerService { get { return this._inventoryLedgerService.Value; } }
        public IJournalEntryService IJournalEntryService { get { return this._journalEntryService.Value; } }

        public IJournalEntryTemplateService JournalEntryTemplateService { get { return this._journalEntryTemplateService.Value; } }
        public IModeOfPaymentService ModeOfPaymentService { get { return this._modeOfPaymentService.Value; } }
        // FixedAsset
        public IAssetDepreciationScheduleService AssetDepreciationScheduleService { get { return this._assetDepreciationScheduleService.Value; } }
        public IFixedAssetService FixedAssetService { get { return this._fixedAssetService.Value; } }
        public IAssetAccountingEventService AssetAccountingEventService { get { return this._assetAccountingEventService.Value; } }
        public IAssetAccountingEventAccountService AssetAccountingEventAccountService { get { return this._assetAccountingEventAccountService.Value; } }
        public IAssetTransactionService AssetTransactionService { get { return this._assetTransactionService.Value; } }
        public IAssetCategoryService AssetCategoryService { get { return this._assetCategoryService.Value; } }
        public IInventoryBalanceService InventoryBalanceService { get { return this._inventoryBalanceService.Value; } }
        public IGoodsReceiptService GoodsReceiptService { get { return this._goodsReceiptService.Value; } }
        public IAssetGroupService AssetGroupService { get { return this._assetGroupService.Value; } }
        public IInspectionStandardService InspectionStandardService { get { return this._inspectionStandardService.Value; } }
        public IChecklistTemplateService ChecklistTemplateService { get { return this._checklistTemplateService.Value; } }
        public IAssetCustodyService AssetCustodyService { get { return this._assetCustodyService.Value; } }
        public IAssetComponentService AssetComponentService { get { return this._assetComponentService.Value; } }
        public IAssetMaintenanceService AssetMaintenanceService { get { return this._assetMaintenanceService.Value; } }

        //Inventory
        public IItemAttributeService ItemAttributeService { get { return this._itemAttributeService.Value; } }
        public IGoodsTransferOutService GoodsTransferOutService { get { return this._goodsTransferOutService.Value; } }
        public IGoodsTransferInService GoodsTransferInService { get { return this._goodsTransferInService.Value; } }
        public IBatchServise Batch { get { return this._Batch.Value; } }
        public IInventoryAdjustmentService InventoryAdjustmentService { get { return this._inventoryAdjustmentService.Value; } }


        //Setup  
        public ISalesPersonServise SalesPerson { get { return this._iSalesPersonServise.Value; } }
        public IModuleSettingServise ModuleSetting { get { return this._iModuleSettingServise.Value; } }
        public IProgramService ProgramService { get { return this._ProgramService.Value; } }
        public IUser_CodeServise User_CodeServise { get { return this._User_CodeServise.Value; } }

        // Inspection
        public IInspectorService InspectorService { get { return this._inspectorService.Value; } }
        public ICertificateService CertificateService { get { return this._certificateService.Value; } }
        public IChecklistService ChecklistService { get { return this._checklistService.Value; } }
        public IInspectorCompetencyService InspectorCompetencyService { get { return this._inspectorCompetencyService.Value; } }
        public IAccreditationBodyService AccreditationBodyService { get { return this._accreditationBodyService.Value; } }
        public IJobOrderDashboardService JobOrderDashboard { get { return this._JobOrderDashboardService.Value; } }

        // DMS
        public IFolderService FolderService { get { return this._folderService.Value; } }
        public IFolderPermissionService FolderPermissionService { get { return this._folderPermissionService.Value; } }
        public IDocumentShareService DocumentShareService { get { return this._documentShareService.Value; } }
        public ITagService TagService { get { return this._tagService.Value; } }
        public IDocumentService DocumentService { get { return this._documentService.Value; } }
        public IShareAccessLogService ShareAccessLogService { get { return this._ShareAccessLogService.Value; } }
        public IDocumentCommentService DocumentCommentService { get { return this._documentCommentService.Value; } }

        public IAccountBalanceService AccountBalanceService { get { return this._accountBalanceService.Value; } }
        public IPurchaseInvoiceService PurchaseInvoiceService { get { return this._PurchaseInvoice.Value; } }

        // Commitment
        public ICommitmentService CommitmentService { get { return this._commitmentService.Value; } }

        // Contracting
        public IBOQService BOQService { get { return this._boqService.Value; } }



        public IWBSService WBSService { get { return this._wBSService.Value; } }
        public IDivisionService DivisionService { get { return this._divisionService.Value; } }
        public ICostCodeService CostCodeService { get { return this._costCodeService.Value; } }
        public IActivityService ActivityService { get { return this._activityService.Value; } }
        public ISubcontractBOQService SubcontractBOQService { get { return this._subcontractBOQService.Value; } }

        // Manufacturing
        public IProductionOrderService ProductionOrderService { get { return this._productionOrderService.Value; } }

        // Asset Location
        public IAssetLocationService AssetLocationService { get { return this._assetLocationService.Value; } }

    }
}