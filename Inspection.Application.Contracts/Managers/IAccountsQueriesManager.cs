using Inspection.Application.Contracts.Repositories.Query;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountBalances;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.BankAccounts;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Banks;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Branches;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Cashing;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.CostUnits;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.FiscalYears;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem.PaymentTerms;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.PurchaseReturns;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.SalesInvoices;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetTransactions;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetGroups;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Repositories.Query.Accounting.ChartOfAccounts;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashPayments;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashReceipts;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashTransfers;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CreditNotes;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.DebitNotes;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Repositories.Query.Accounting.PR.Master.SupplierGroups;
using Inspection.Application.Contracts.Repositories.Query.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Repositories.Query.ApprovalManagement;
using Inspection.Application.Contracts.Repositories.Query.Constracting.Setup.Commitments;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.Activitys;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.CostCodes;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.Divisions;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.IBOQs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.ISubcontractBOQs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.WBSs;
using Inspection.Application.Contracts.Repositories.Query.DMS.DocumentComments;
using Inspection.Application.Contracts.Repositories.Query.DMS.Documents;
using Inspection.Application.Contracts.Repositories.Query.DMS.DocumentShares;
using Inspection.Application.Contracts.Repositories.Query.DMS.FolderPermissions;
using Inspection.Application.Contracts.Repositories.Query.DMS.Folders;
using Inspection.Application.Contracts.Repositories.Query.DMS.ShareAccessLogs;
using Inspection.Application.Contracts.Repositories.Query.DMS.Tags;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.Departments;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.Employees;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobRequests;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobTitles;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Certificates;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Checklists;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Inspector;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.EquipmentTypes;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionMethods;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableDetails;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableMasters;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Colors;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Batchs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Items;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.UnitOfMeasures;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Sizes;
using Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryBalances;
using Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Repositories.Query.LocalizationManagement;
using Inspection.Application.Contracts.Repositories.Query.Manufacturing.Setup.ProductionOrders;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.Programs;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesDetailsF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.JobOrderDashboard;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales.SalesOrderQuery;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.SalesQuotationDashboard;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Setup.SalesPersons;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.DeliveryNotes;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Contracts.Repositories.Query.Sample.CurrencyExchangeRate;
using Inspection.Application.Contracts.Repositories.Query.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Repositories.Query.Setting.ModuleSettings;
using Inspection.Application.Contracts.Repositories.Query.System;
using Inspection.Application.Contracts.Repositories.Query.System.Languages;
using Inspection.Application.Contracts.Repositories.Query.System.TaxCategorys;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Cities;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Companies;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Countries;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Currencies;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Operations;
using Inspection.Application.Contracts.Repositories.Query.UserNotificationManagement;
using Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.Suppliers;

namespace Inspection.Application.Contracts.Managers
{
    public interface IAccountsQueriesManager
    {
        //Sample
        ISCurrencyExchangeRateQueryRepository SCurrencyExchangeRates { get; }
        //Sample

        ISalesQuotationDashboardQueryRepository ISalesQuotationDashboardQueryRepository { get; }
        IJobOrderDashboardQueryRepository IJobOrderDashboardQueryRepository { get; }

        IInspectionReportQueryRepository InspectionReport { get; }
        IInspectionRequestQueryRepository InspectionRequest { get; }
        IInspectionDashboardQueryRepository InspectionDashboard { get; }
        IServiceTypeQueryRepository ServiceType { get; }
        IEquipmentQueryRepository Equipment { get; }
        IEquipmentInspectionQueryRepository EquipmentInspection { get; }
        IMaintenanceReportQueryRepository MaintenanceReport { get; }
        IMaintenanceScheduleQueryRepository MaintenanceSchedule { get; }
        ILocalizationQueryRepository Localization { get; }
        IMenuQueryRepository Menu { get; }
        IApprovalQueryRepository Approval { get; }
        IUserApprovalQueryRepository UserApproval { get; }
        IApprovalDelegationQueryRepository ApprovalDelegation { get; }
        IUserNotificationsQueryRepository UserNotifications { get; }
        ICustomerLocationQueryRepository CustomerLocations { get; }
        ICustomerProjectQueryRepository CustomerProject { get; }
        ISeriesQueryRepository Series { get; }
        ISeriesDetailsQueryRepository SeriesDetails { get; }
        IServiceItemQueryRepository ServicesItems { get; }

        // Sales Mangement
        ISalesQuotationQueryRepository SalesQuotation { get; }
        ISalesReturnQueryRepository SalesReturn { get; }


        // Sales Order
        ISalesOrderLineQueryRepository SalesOrderLines { get; }
        ISalesOrderQueryRepository SalesOrder { get; }

        IAreaQueryRepository Area { get; }
        ICustomerBranchQueryRepository CustomerBranch { get; }
        IInspectionMethodQueryRepository InspectionMethod { get; }
        IScreenCodeQueryRepository ScreenCode { get; }
        IInspectorCategoryQueryRepository InspectorCategory { get; }
        IEquipmentTypeQueryRepository EquipmentTypes { get; }

        IJobOrderQueryRepository JobOrder { get; }
        IJobOrderDetailQueryRepository JobOrderDetail { get; }
        IInspectionCertificateQueryRepository InspectionCertificate { get; }
        IEquipmentsMoreInformationQueryRepository EquipmentsMoreInformation { get; }
        IInspectionRequestLinesQueryRepository InspectionRequestLines { get; }
        IInspectionRequestDetailSubcontractorQueryRepository InspectionRequestDetailSubcontractors { get; }
        IApplicantCVQueryRepository ApplicantCVQueryRepository { get; }
        IDepartmentQueryRepository DepartmentQueryRepository { get; }
        IEmployeeQueryRepository EmployeeQueryRepository { get; }
        ITestTableMasterQueryRepository TestTableMasterQueryRepository { get; }
        ITestTableDetailQueryRepository TestTableDetailQueryRepository { get; }
        ITestTableSubDetailsQueryRepository TestTableSubDetailQueryRepository { get; }
        ICompanyEquipmentQueryRepository CompanyEquipmentsQueryRepository { get; }
        IEquipmentAccessoryQueryRepository EquipmentAccessoriesQueryRepository { get; }
        IEquipmentSoftwareQueryRepository EquipmentSoftwareQueryRepository { get; }
        IEquipmentCalibrationHistoryQueryRepository EquipmentCalibrationHistoryQueryRepository { get; }
        IEquipmentPreventiveMaintenanceQueryRepository EquipmentPreventiveMaintenanceQueryRepository { get; }
        IEquipmentMaintenanceAndRepairRecordQueryRepository EquipmentMaintenanceAndRepairRecordQueryRepository { get; }
        IJobRequestQueryRepository JobRequestQueryRepository { get; }
        IJobTitleQueryRepository JobTitleQueryRepository { get; }
        IInterviewEvaluationQueryRepository InterviewEvaluationQueryRepository { get; }
        IJobAdvertisementQueryRepository JobAdvertisementQueryRepository { get; }
        IJobOfferNegotiationQueryRepository JobOfferNegotiationQueryRepository { get; }
        IEquipmentsMoreInformationDetailQueryRepository EquipmentsMoreInformationDetailQueryRepository { get; }
        IEquipmentCategoryQueryRepository EquipmentCategoryQueryRepository { get; }
        IEquipmentsMoreInformationTemplateDetailQueryRepository EquipmentsMoreInformationTemplateDetailQueryRepository { get; }
        IEquipmentsMoreInformationTemplateQueryRepository EquipmentsMoreInformationTemplateQueryRepository { get; }

        IInspectionChecklistsQueryRepository InspectionChecklistQueryRepository { get; }
        IInspectionChecklistMoreInformationQR InspectionChecklistMoreInformationQueryRepository { get; }
        IInspectionChecklistMoreInformationDetailQR InspectionChecklistMoreInformationDetailQueryRepository { get; }
        IInspectionChecklistMoreInformationTemplateQueryRepository InspectionChecklistMoreInformationTemplateQueryRepository { get; }
        IInspectionChecklistMoreInformationTemplateDetailQR InspectionChecklistMoreInformationTemplateDetailQueryRepository { get; }
        IInspectionTypeQueryRepository InspectionTypes { get; }

        IUser_GroupQueryRepository User_Groups { get; }
        IScreen_permissionQueryRepository Screen_permissions { get; }

        //Contracting
        IActivityQueryRepository Activity { get; }
        ICostCodeQueryRepository CostCode { get; }
        IDivisionQueryRepository Division { get; }
        IWBSQueryRepository WBS { get; }



        // System Configurations
        ICompanyQueryRepository Companies { get; }
        ICurrencyQueryRepository Currencies { get; }
        ICountriesQueryRepository Counteris { get; }
        ICityQueryRepository Cities { get; }
        ICurrencyExchangeRateQueryRepository CurrencyExchangeRateQueryRepository { get; }
        IOperationQueryRepository OperationQueryRepository { get; }
        //System
        ITaxTypeQueryRepository TaxTypeQueryRepository { get; }
        ITaxCategoryQueryRepository TaxCategoryQueryRepository { get; }
        ILanguageQueryRepository LanguageQueryRepository { get; }

        //Acconuting
        ICostCenterQueryRepository CostCenters { get; }
        ICostUnitQueryRepository CostUnits { get; }
        IBankAccountQueryRepository BankAccounts { get; }
        IBankQueryRepository Banks { get; }
        IFiscalYearQueryRepository FiscalYears { get; }
        IAccountingPeriodQueryRepository AccountingPeriods { get; }
        IAcountTypeQueryRepository AccountTypes { get; }
        IChartOfAccountQueryRepository ChartOfAccounts { get; }
        IDefaultAccountTypeQueryRepository DefaultAccountTypes { get; }
        IDefaultAccountGroupQueryRepository DefaultAccountGroups { get; }
        IDefaultAccountAssignmentQueryRepository DefaultAccountAssignments { get; }
        IPaymentTermQueryRepository PaymentTerms { get; }
        ISupplierQueryRepository ISupplierQueryRepo { get; }
        ICustomerQueryRepository CustomerQuery { get; }
        ICustomerGroupQueryRepository CustomerGroups { get; }
        ISupplierGroupQueryRepository SupplierGroups { get; }
        ICashQueryRepository Cashs { get; }
        IBranchQueryRepository Branches { get; }
        IBrandQueryRepository Brands { get; }
        IModelQueryRepository Models { get; }
        IUnitOfMeasureConversionQueryRepository UnitOfMeasureConversions { get; }
        IAssetDepreciationScheduleQueryRepository AssetDepreciationSchedules { get; }
        IAssetCategoryQueryRepository AssetCategory { get; }
        IAssetGroupQueryRepository AssetGroup { get; }
        IAssetTransactionQueryRepository AssetTransaction { get; }
        IJournalEntryTemplateQueryRepository JournalEntryTemplate { get; }
        IModeOfPaymentQueryRepository ModeOfPayment { get; }
        ICashReceiptQueryRepository CashReceipt { get; }
        ICashPaymentQueryRepository CashPayment { get; }
        ISalesInvoiceQueryRepository SalesInvoice { get; }
        IPurchaseInvoiceQueryRepository PurchaseInvoice { get; }
        IDeliveryNoteQueryRepository DeliveryNote { get; }
        IGoodsIssueQueryRepository GoodsIssue { get; }
        IPurchaseReturnQueryRepository PurchaseReturn { get; }
        ICreditNoteQueryRepository CreditNote { get; }
        IInventoryScrapQueryRepository InventoryScrap { get; }
        IScrapReasonQueryRepository ScrapReason { get; }
        IDebitNoteQueryRepository DebitNote { get; }
        ICashTransferQueryRepository CashTransfer { get; }


        //Inventory 
        IItemGroupQueryRepository ItemGroup { get; }
        IWarehouseQueryRepository Warehouses { get; }
        IUnitOfMeasureQueryRepository UnitOfMeasures { get; }
        IItemQueryRepository Items { get; }
        IItemVariantAttributeQueryRepository ItemVariantAttribute { get; }
        IColorQueryRepository Color { get; }
        ISizeQueryRepository size { get; }
        IInventoryCostLayerQueryRepository InventoryCostLayerQuery { get; }
        IWarehouseLocationQueryRepository WarehouseLocationQuery { get; }
        IInventoryOpeningBalanceQueryRepository InventoryOpeningBalance { get; }
        IInventoryLedgerQueryRepository InventoryLedger { get; }
        IItemAttributeQueryRepository ItemAttribute { get; }
        IGoodsTransferOutQueryRepository GoodsTransferOut { get; }
        IGoodsTransferInQueryRepository GoodsTransferIn { get; }
        IBatchQueryRepository Batch { get; }
        IInventoryAdjustmentQueryRepository InventoryAdjustment { get; }

        // FixedAsset
        IFixedAssetQueryRepository FixedAsset { get; }
        IAssetAccountingEventQueryRepository AssetAccountingEvents { get; }
        IAssetAccountingEventAccountQueryRepository AssetAccountingEventAccounts { get; }
        IInventoryBalanceQueryRepository InventoryBalances { get; }
        IGoodsReceiptQueryRepository GoodsReceipts { get; }
        IAssetCustodyQueryRepository AssetCustody { get; }
        IAssetComponentQueryRepository AssetComponent { get; }
        IAssetMaintenanceQueryRepository AssetMaintenance { get; }

        //Setup  
        ISalesPersonQueryRepository SalesPerson { get; }
        IModuleSettingQueryRepository ModuleSetting { get; }

        //MenuManagement
        IProgramQueryRepository programQueryRepository { get; }
        IUser_CodeQueryRepository User_CodeQueryRepository { get; }

        IInspectionStandardQueryRepository InspectionStandards { get; }
        IChecklistTemplateQueryRepository ChecklistTemplates { get; }

        // Inspection
        IInspectorQueryRepository Inspector { get; }
        ICertificateQueryRepository Certificate { get; }
        IChecklistQueryRepository Checklists { get; }
        IInspectorCompetencyQueryRepository InspectorCompetency { get; }
        IAccreditationBodyQueryRepository AccreditationBody { get; }

        // DMS
        IFolderQueryRepository Folder { get; }
        IFolderPermissionQueryRepository FolderPermission { get; }
        ITagQueryRepository Tag { get; }
        IDocumentShareQueryRepository DocumentShare { get; }
        IShareAccessLogQueryRepository ShareAccessLog { get; }
        IDocumentQueryRepository Document { get; }
        IDocumentCommentQueryRepository DocumentComment { get; }

        //Ledger
        ILedgerQueryRepository Ledger { get; }
        ILedgerLineQueryRepository LedgerLine { get; }

        IJournalEntryQueryRepository JournalEntryQuery { get; }

        // Account Balance
        IAccountBalanceQueryRepository AccountBalance { get; }

        // Commitment
        ICommitmentQueryRepository Commitment { get; }

        // Contracting
        IBOQQueryRepository BOQ { get; }
        ISubcontractBOQQueryRepository SubcontractBOQ { get; }

        // Manufacturing
        IProductionOrderQueryRepository ProductionOrder { get; }

        // AssetLocation
        IAssetLocationQueryRepository AssetLocation { get; }
    }
}