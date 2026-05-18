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

namespace Inspection.Application.Contracts.Managers
{
    public interface IAccountsServicesManger
    {
        //Sample
        ISCurrencyExchangeRateService SCurrencyExchangeRateService { get; }
        IJobOrderDashboardService JobOrderDashboard { get; }
        //Sample

        IInspectionRequestService InspectionRequestService { get; }
        IInspectionDashboardService IInspectionDashboardService { get; }
        ISalesQuotationDashboardService ISalesQuotationDashboardService { get; }
        IInspectionServiceOrder InspectionServiceOrder { get; }
        IInspectionReportService InspectionReportService { get; }
        IServiceTypeService ServiceTypeService { get; }
        IEquipmentService EquipmentService { get; }
        IEquipmentInspectionService EquipmentInspectionService { get; }
        IMaintenanceReportService MaintenanceReportService { get; }
        IMaintenanceScheduleService MaintenanceScheduleService { get; }
        ILocalizationService LocalizationService { get; }
        IMenuService MenuService { get; }
        IApprovalService ApprovalService { get; }
        IUserApprovalService UserApprovalService { get; }
        IApprovalDelegationService ApprovalDelegationService { get; }
        IUserNotificationsService UserNotificationsService { get; }
        ICustomerLocationService CustomerLocationService { get; }

        ICustomerProjectService CustomerProjectService { get; }
        ISeriesService SeriesService { get; }
        IServiceItemService ServicesItemsService { get; }

        ISalesOrderService SalesOrderService { get; }
        ICustomerBranchService CustomerBranchService { get; }
        IAreaService AreaService { get; }
        IInspectionMethodService InspectionMethodService { get; }
        IInspectorCategoryService InspectorCategoryService { get; }

        IEquipmentTypeService EquipmentTypeService { get; }

        IJobOrderService JobOrderService { get; }
        IInspectionCertificateService InspectionCertificateService { get; }
        IEquipmentsMoreInformationService EquipmentsMoreInformationService { get; }

        IInspectionRequestLinesService InspectionRequestLinesService { get; }
        IInspectionRequestDetailSubcontractorService InspectionRequestDetailSubcontractorService { get; }
        IApplicantCVService ApplicantCVService { get; }
        IDepartmentService DepartmentService { get; }
        IEmployeeService EmployeeService { get; }
        ITestTableMasterService TestTableMasterService { get; }
        ITestTableDetailService TestTableDetailService { get; }
        ITestTableSubDetailsService TestTableSubDetailService { get; }
        ICompanyEquipmentService CompanyEquipmentService { get; }
        IEquipmentAccessoriesService EquipmentAccessoriesService { get; }
        IEquipmentSoftwareService EquipmentSoftwareService { get; }
        IEquipmentCalibrationHistoryService EquipmentCalibrationHistoryService { get; }
        IEquipmentPreventiveMaintenanceService EquipmentPreventiveMaintenanceService { get; }
        IEquipmentMaintenanceAndRepairRecordService EquipmentMaintenanceAndRepairRecordService { get; }
        IJobRequestService JobRequestService { get; }
        IJobTitleService JobTitleService { get; }
        IInterviewEvaluationService InterviewEvaluationService { get; }
        IJobAdvertisementService JobAdvertisementService { get; }
        IJobOfferNegotiationService JobOfferNegotiationService { get; }
        IEquipmentsMoreInformationDetailService EquipmentsMoreInformationDetailService { get; }
        IEquipmentCategoryService EquipmentCategoryService { get; }
        IEquipmentsMoreInformationTemplateDetailService EquipmentsMoreInformationTemplateDetailService { get; }
        IEquipmentsMoreInformationTemplateService EquipmentsMoreInformationTemplateService { get; }

        IInspectionChecklistService InspectionChecklistService { get; }
        IInspectionChecklistMoreInformationService InspectionChecklistMoreInformationService { get; }
        IInspectionChecklistMoreInformationDetailService InspectionChecklistMoreInformationDetailService { get; }
        IInspectionChecklistMoreInformationTemplateService InspectionChecklistMoreInformationTemplateService { get; }
        IInspectionChecklistMoreInformationTemplateDetailService InspectionChecklistMoreInformationTemplateDetailService { get; }
        IInspectionTypeService InspectionTypeService { get; }
        IAssetCategoryService AssetCategoryService { get; }

        IAssetTransactionService AssetTransactionService { get; }
        IUser_GroupService User_GroupService { get; }
        IScreen_permissionService Screen_permissionService { get; }

        // Sales Management
        ISalesQuotationService SalesQuotationService { get; }
        ISalesReturnService SalesReturn { get; }


        // SystemConfigurations
        ICompanyService CompanyService { get; }
        ICurrencyService CurrencyService { get; }
        ICountryService CountryService { get; }
        ICurrencyExchangeRateMasteService CurrencyExchangeRateMasteService { get; }
        ICityService CityService { get; }
        IOperationService OperationService { get; }

        //System
        ITaxTypeServise TaxService { get; }
        ITaxCategoryServise TaxCategory { get; }
        ILanguageServise Languages { get; }


        // Account Resolver
        IAccountResolverService AccountResolverService { get; }

        //Accounting
        ICostCenterService CostCenterService { get; }
        ICostUnitService CostUnitService { get; }
        IBankAccountService BankAccountService { get; }
        IBankService BankService { get; }
        IFiscalYearService FiscalYearService { get; }
        IAccountingPeriodService AccountingPeriodService { get; }
        IAccountTypeService AccountTypeService { get; }
        IChartOfAccountService ChartOfAccountService { get; }
        IDefaultAccountTypeService DefaultAccountTypeService { get; }
        IDefaultAccountGroupService DefaultAccountGroupService { get; }
        IDefaultAccountAssignmentService DefaultAccountAssignmentService { get; }
        IPaymentTermService PaymentTermService { get; }
        ISupplierService SupplierService { get; }
        ICustomerGroupService CustomerGroupService { get; }
        ICustomerServiceMaster CustomerService { get; }
        ISupplierGroupService SupplierGroupService { get; }
        ICashService CashService { get; }
        IBranchService BranchService { get; }
        IBrandService BrandService { get; }
        IModelService ModelService { get; }
        IUnitOfMeasureConversionService UnitOfMeasureConversionService { get; }
        IJournalEntryService IJournalEntryService { get; }
        IJournalEntryTemplateService JournalEntryTemplateService { get; }
        IModeOfPaymentService ModeOfPaymentService { get; }
        ICashReceiptService CashReceiptService { get; }
        ICashPaymentService CashPaymentService { get; }
        ICreditNoteService CreditNoteService { get; }
        IDebitNoteService DebitNoteService { get; }
        ICashTransferService CashTransferService { get; }

        ISalesInvoiceService SalesInvoiceService { get; }
        IPurchaseInvoiceService PurchaseInvoiceService { get; }
        IDeliveryNoteService DeliveryNote { get; }
        IPurchaseReturnService PurchaseReturn { get; }

        //Inventory 
        IItemGroupService ItemGroupService { get; }
        IItemService ItemService { get; }
        IWarehouseService WarehouseService { get; }
        IUnitOfMeasureService UnitOfMeasureService { get; }
        IAssetDepreciationScheduleService AssetDepreciationScheduleService { get; }
        IColorService ColorService { get; }
        ISizeService SizeService { get; }
        IInventoryCostLayersService InventoryCostLayersService { get; }
        IWarehouseLocationService WarehouseLocationService { get; }
        IInventoryLedgerService InventoryLedgerService { get; }
        IInventoryOpeningBalanceService InventoryOpeningBalanceService { get; }
        IItemAttributeService ItemAttributeService { get; }
        IGoodsTransferOutService GoodsTransferOutService { get; }
        IGoodsTransferInService GoodsTransferInService { get; }
        IGoodsIssueService GoodsIssue { get; }
        IBatchServise Batch { get; }
        IInventoryAdjustmentService InventoryAdjustmentService { get; }


        IScrapReasonService ScrapReasonService { get; }
        IInventoryScrapService InventoryScrapService { get; }

        // FixedAsset
        IFixedAssetService FixedAssetService { get; }
        IAssetAccountingEventService AssetAccountingEventService { get; }
        IAssetAccountingEventAccountService AssetAccountingEventAccountService { get; }
        IInventoryBalanceService InventoryBalanceService { get; }
        IGoodsReceiptService GoodsReceiptService { get; }
        IAssetGroupService AssetGroupService { get; }
        IAssetCustodyService AssetCustodyService { get; }
        IAssetComponentService AssetComponentService { get; }
        IAssetMaintenanceService AssetMaintenanceService { get; }

        //Setup  
        ISalesPersonServise SalesPerson { get; }
        IModuleSettingServise ModuleSetting { get; }
        IProgramService ProgramService { get; }
        IUser_CodeServise User_CodeServise { get; }
        IInspectionStandardService InspectionStandardService { get; }
        IChecklistTemplateService ChecklistTemplateService { get; }


        // Inspection
        IInspectorService InspectorService { get; }
        ICertificateService CertificateService { get; }
        IChecklistService ChecklistService { get; }
        IInspectorCompetencyService InspectorCompetencyService { get; }
        IAccreditationBodyService AccreditationBodyService { get; }
        IJobOrderDetailService JobOrderDetailService { get; }

        // DMS
        IFolderService FolderService { get; }
        IFolderPermissionService FolderPermissionService { get; }
        IDocumentShareService DocumentShareService { get; }
        ITagService TagService { get; }
        IShareAccessLogService ShareAccessLogService { get; }
        IDocumentService DocumentService { get; }
        IDocumentCommentService DocumentCommentService { get; }


        // Posting Engine
        IPostingEngine PostingEngine { get; }

        ILedgerService LedgerService { get; }
        IAccountBalanceService AccountBalanceService { get; }

        // Commitment
        ICommitmentService CommitmentService { get; }

        // Contracting
        IBOQService BOQService { get; }

        IWBSService WBSService { get; }
        IDivisionService DivisionService { get; }
        ICostCodeService CostCodeService { get; }
        IActivityService ActivityService { get; }
        ISubcontractBOQService SubcontractBOQService { get; }

        // Manufacturing
        IProductionOrderService ProductionOrderService { get; }

        // Asset Location
        IAssetLocationService AssetLocationService { get; }
    }
}