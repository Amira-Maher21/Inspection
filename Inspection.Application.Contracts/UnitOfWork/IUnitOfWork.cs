using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountBalances;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.BankAccounts;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Banks;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Branches;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Cashing;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.CostUnits;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.FiscalYears;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ILedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.LedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem.PaymentTerm;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.PurchaseReturns;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.SalesInvoices;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetAccountingEvents;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetMaintenances;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetTransactions;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Repositories.Command.Accounting.ChartOfAccounts;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashPayments;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashReceipts;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashTransfers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CreditNotes;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.DebitNotes;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.SupplierGroups;
using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.Suppliers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Repositories.Command.ApprovalManagement;
using Inspection.Application.Contracts.Repositories.Command.Constracting.Setup.Commitments;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.Activitys;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.CostCodes;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.Divisions;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.IBOQs;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.ISubcontractBOQs;
using Inspection.Application.Contracts.Repositories.Command.Contracting.WBSs;
using Inspection.Application.Contracts.Repositories.Command.DMS.DocumentComments;
using Inspection.Application.Contracts.Repositories.Command.DMS.Documents;
using Inspection.Application.Contracts.Repositories.Command.DMS.DocumentShares;
using Inspection.Application.Contracts.Repositories.Command.DMS.FolderPermissions;
using Inspection.Application.Contracts.Repositories.Command.DMS.Folders;
using Inspection.Application.Contracts.Repositories.Command.DMS.ShareAccessLogs;
using Inspection.Application.Contracts.Repositories.Command.DMS.Tags;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateTemplateTemplates;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentTypes;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.Departments;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.Employees;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobRequests;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobTitles;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.AccreditationBodies;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Certificates;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Checklists;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Inspector;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectorCompetencies;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionMethods;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.Locations;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Batchs;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Brands;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Colors;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Items;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Models;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Sizes;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Repositories.Command.Inventory.ItemGroups;
using Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryBalances;
using Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryScraps;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Repositories.Command.LocalizationManagement;
using Inspection.Application.Contracts.Repositories.Command.Manufacturing.Setup.ProductionOrders;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.BranchF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesDetailsF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.DeliveryNotes;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.SalesOrderCommandRepository;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Setup.SalesPersons;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesQuotations;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesReturns;
using Inspection.Application.Contracts.Repositories.Command.Sample.CurrencyExchangeRate;
using Inspection.Application.Contracts.Repositories.Command.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Repositories.Command.Setting.ModuleSettings;
using Inspection.Application.Contracts.Repositories.Command.System;
using Inspection.Application.Contracts.Repositories.Command.System.Languages;
using Inspection.Application.Contracts.Repositories.Command.System.TaxCategorys;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Cities;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Companies;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Countries;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Currencies;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Operations;
using Inspection.Application.Contracts.Repositories.Command.TestTableDetails;
using Inspection.Application.Contracts.Repositories.Command.TestTableMasters;
using Inspection.Application.Contracts.Repositories.Command.TestTableSubDetails;
using Inspection.Application.Contracts.Repositories.Command.UserNotificationManagement;
using NDS.Shared.Application.UnitOfWorkBase;

namespace Inspection.Application.Contracts.UnitOfWork
{
    public interface IAccountUnitOfWork : IUnitOfWorkBase
    {
        //Sample
        ISCurrencyExchangeRateCommandRepository SCurrencyExchangeRates { get; }
        //Sample

        IInspectionReportCommandRepository InspectionReport { get; }
        IInspectionRequestCommandRepository InspectionRequest { get; }
        IServiceTypeCommandRepository ServiceType { get; }
        IEquipmentCommandRepository Equipment { get; }
        IEquipmentInspectionCommandRepository EquipmentInspection { get; }
        IMaintenanceReportCommandRepository MaintenanceReport { get; }
        IMaintenanceScheduleCommandRepository MaintenanceSchedule { get; }
        ILocalizationCommandRepository Localization { get; }
        IApprovalCommandRepository Approval { get; }
        IUserApprovalCommandRepository UserApproval { get; }
        IApprovalDelegationCommandRepository ApprovalDelegation { get; }
        IUserNotificationsCommandRepository UserNotifications { get; }
        ISeriesCommandRepository Series { get; }
        ISeriesDetailsCommandRepository SeriesDetails { get; }
        ICustomerLocationCommandRepository CustomerLocation { get; }
        ICustomerProjectCommandRepository CustomerProject { get; }
        IServiceItemCommandRepository ServicesItems { get; }

        // Sales Management  
        ISalesQuotationCommandRepository SalesQuotation { get; }


        // Sales Order
        ISalesOrderCommandRepository SalesOrder { get; }
        ISalesOrderLinesCommandRepository SalesOrderLines { get; }

        IAreaCommandRepository Area { get; }
        ICustomerBranchCommandRepository CustomerBranch { get; }
        IInspectionMethodCommandRepository InspectionMethod { get; }
        IInspectorCategoryCommandRepository InspectorCategory { get; }
        IEquipmentTypeCommandRepository EquipmentType { get; }
        IJobOrderCommandRepository JobOrder { get; }
        IJobOrderDetailCommandRepository JobOrderDetail { get; }
        IInspectionCertificateCommandRepository InspectionCertificate { get; }
        IInspectionRequestLinesCommandRepository InspectionRequestLines { get; }
        IInspectionRequestDetailSubcontractorCommandRepository InspectionRequestDetailSubcontractor { get; }
        IEquipmentsMoreInformationCommandRepository EquipmentsMoreInformation { get; }
        IApplicantCVCommandRepository ApplicantCVCommandRepository { get; }
        IDepartmentCommandRepository DepartmentCommandRepository { get; }
        IEmployeeCommandRepository EmployeeCommandRepository { get; }
        ITestTableMasterCommandRepository TestTableMasterCommandRepository { get; }
        ITestTableDetailsCommandRepository TestTableDetailCommandRepository { get; }
        ITestTableSubDetailsCommandRepository TestTableSubDetailCommandRepository { get; }
        ICompanyEquipmentCommandRepository CompanyEquipmentCommandRepository { get; }
        IEquipmentAccessoryCommandRepository EquipmentAccessoriesCommandRepository { get; }
        IEquipmentSoftwareCommandRepository EquipmentSoftwareCommandRepository { get; }
        IEquipmentCalibrationHistoryCommandRepository EquipmentCalibrationHistoryCommandRepository { get; }
        IEquipmentPreventiveMaintenanceCommandRepository EquipmentPreventiveMaintenanceCommandRepository { get; }
        IEquipmentMaintenanceAndRepairRecordCommandRepository EquipmentMaintenanceAndRepairRecordCommandRepository { get; }
        IJobRequestCommandRepository JobRequestCommandRepository { get; }
        IJobTitleCommandRepository JobTitleCommandRepository { get; }
        IInterviewEvaluationCommandRepository InterviewEvaluationCommandRepository { get; }
        IJobAdvertisementCommandRepository JobAdvertisementCommandRepository { get; }
        IJobOfferNegotiationCommandRepository JobOfferNegotiationCommandRepository { get; }
        IEquipmentsMoreInformationDetailCommandRepository EquipmentsMoreInformationDetailCommandRepository { get; }
        IEquipmentCategoryCommandRepository EquipmentCategoryCommandRepository { get; }
        IEquipmentsMoreInformationTemplateCommandRepository EquipmentsMoreInformationTemplateCommandRepository { get; }
        IEquipmentsMoreInformationTemplateDetailCommandRepository EquipmentsMoreInformationTemplateDetailCommandRepository { get; }

        IInspectionChecklistMoreInformationTemplateCommandRepository InspectionChecklistMoreInformationTemplateCommandRpository { get; }
        IInspectionChecklistMoreInformationTemplateDetailCR InspectionChecklistMoreInformationTemplateDetailCR { get; }
        IInspectionChecklistMoreInformationDetailCommandRepository InspectionChecklistMoreInformationDetailCommandRepository { get; }

        IInspectionChecklistMoreInformationCommandRepository InspectionChecklistMoreInformationCommandRepository { get; }
        IInspectionChecklistCommandRepository InspectionChecklistCommandRepository { get; }
        IInspectionTypeCommandRepository InspectionTypesCommandRepository { get; }

        IUser_GroupCommandRepository User_GroupCommandRepository { get; }
        IScreen_permissionCommandRepository Screen_permissionCommandRepository { get; }


        // SystemConfigurations
        ICompanyCommandRepository Company { get; }
        ICurrencyCommandRepository Currency { get; }
        ICityCommandRepository City { get; }
        ICountriesCommandRepository Country { get; }
        ICurrencyExchangeRateCommandRepository CurrencyExchangeRate { get; }
        IOperationCommandRepository Operations { get; }
        ISupplierCommandRepository SupplierCommand { get; }
        IJournalEntryCommandRepository IJournalEntry { get; }
        ILanguageCommandRepository Languages { get; }

        //System
        ITaxTypeCommandRepository Taxes { get; }
        ITaxCategoryCommandRepository TaxCategory { get; }

        // ICurrencyExchangeRateDetailCommandRepository CurrencyExchangeRateDetailCommand { get; }

        //Accounting
        IBankCommandRepository Bank { get; }
        IBankAccountCommandRepository BankAccount { get; }
        ICostCenterCommandRepository CostCenter { get; }
        ICostUnitCommandRepository CostUnit { get; }
        IFiscalYearCommandRepository FiscalYear { get; }
        IAccountingPeriodCommandRepository AccountingPeriod { get; }
        IChartOfAccountCommandRepository ChartOfAccount { get; }
        IDefaultAccountTypeCommandRepository DefaultAccountType { get; }
        IDefaultAccountGroupCommandRepository DefaultAccountGroup { get; }
        IDefaultAccountAssignmentCommandRepository DefaultAccountAssignment { get; }
        IPaymentTermCommandRepository PaymentTerm { get; }
        ICustomerGroupCommandRepository CustomerGroup { get; }
        ICustomerCommandRepository CustomerCommandRepository { get; }
        ICustomerContactCommandRepository CustomerContactCommandRepository { get; }
        ISupplierGroupCommandRepository SupplierGroup { get; }
        ICashCommandRepository Cash { get; }
        IBranchCommandRepository Branch { get; }
        IAssetTransactionCommandRepository AssetTransaction { get; }
        IAssetCategoryCommandRepository AssetCategory { get; }
        IJournalEntryTemplateCommandRepository JournalEntryTemplate { get; }
        IModeOfPaymentCommandRepository ModeOfPayment { get; }
        ICashReceiptCommandRepository CashReceipt { get; }
        ICashPaymentCommandRepository CashPayment { get; }
        ICreditNoteCommandRepository CreditNote { get; }
        IDebitNoteCommandRepository DebitNote { get; }
        ICashTransferCommandRepository CashTransfer { get; }

        ISalesInvoiceCommandRepository SalesInvoice { get; }
        IPurchaseInvoiceCommandRepository PurchaseInvoice { get; }
        IDeliveryNoteCommandRepository DeliveryNote { get; }
        IPurchaseReturnCommandRepository PurchaseReturn { get; }

        //Inventory
        IWarehouseCommandRepository Warehouse { get; }
        IBrandCommandRepository Brand { get; }
        IModelCommandRepository Model { get; }
        IUnitOfMeasureCommandRepository UnitOfMeasure { get; }
        IUnitOfMeasureConversionCommandRepository UnitOfMeasureConversion { get; }
        IAssetDepreciationScheduleCommandRepository AssetDepreciationSchedule { get; }
        IItemGroupCommandRepository ItemGroup { get; }
        IItemCommandRepository Item { get; }
        IItemVariantAttributeCommandRepository ItemVariantAttribute { get; }
        IColorCommandRepository Color { get; }
        ISizeCommandRepository Size { get; }
        IInventoryCostLayerCommandRepository InventoryCostLayer { get; }
        IWarehouseLocationCommandRepository WarehouseLocation { get; }
        IInventoryOpeningBalanceCommandRepository InventoryOpeningBalance { get; }
        IInventoryLedgerCommandRepository InventoryLedger { get; }
        IItemAttributeCommandRepository ItemAttribute { get; }
        IGoodsIssueCommandRepository GoodsIssue { get; }
        IGoodsTransferOutCommandRepository GoodsTransferOut { get; }
        IGoodsTransferInCommandRepository GoodsTransferIn { get; }
        IBatchCommandRepository Batch { get; }
        IInventoryAdjustmentCommandRepository InventoryAdjustment { get; }
        IScrapReasonCommandRepository ScrapReason { get; }
        IInventoryScrapCommandRepository InventoryScrap { get; }


        // FixedAsset
        IFixedAssetCommandRepository FixedAsset { get; }
        IAssetCustodyCommandRepository AssetCustody { get; }
        IAssetGroupCommandRepository AssetGroup { get; }
        IAssetAccountingEventCommandRepository AssetAccountingEvent { get; }
        IAssetAccountingEventAccountCommandRepository AssetAccountingEventAccount { get; }
        IInventoryBalanceCommandRepository InventoryBalance { get; }
        IGoodsReceiptCommandRepository GoodsReceipt { get; }
        IAssetComponentCommandRepository AssetComponent { get; }
        IAssetMaintenanceCommandRepository AssetMaintenance { get; }



        //Sales
        ISalesPersonCommandRepository SalesPerson { get; }
        IModuleSettingCommandRepository ModuleSetting { get; }
        ISalesReturnCommandRepository SalesReturn { get; }

        //MenuManagement
        IUser_CodeCommandRepository User_CodeCommandRepository { get; }
        IInspectionStandardCommandRepository InspectionStandard { get; }
        IChecklistTemplateCommandRepository ChecklistTemplate { get; }


        // Inspection
        IInspectorCommandRepository Inspector { get; }
        ICertificateCommandRepository Certificate { get; }
        IChecklistCommandRepository Checklist { get; }

        IInspectorCompetencyCommandRepository InspectorCompetency { get; }
        IAccreditationBodyCommandRepository AccreditationBody { get; }

        // DMS
        IFolderCommandRepository Folder { get; }
        IFolderPermissionCommandRepository FolderPermission { get; }
        IDocumentShareCommandRepository IDocumentShare { get; }
        ITagCommandRepository Tag { get; }
        IShareAccessLogCommandRepository ShareAccessLog { get; }
        IDocumentCommandRepository Document { get; }
        IDocumentEntityLinkCommandRepository DocumentEntityLink { get; }
        IDocumentCommentCommandRepository DocumentComment { get; }

        //Ledger
        ILedgerCommandRepository Ledger { get; }
        ILedgerLineCommandRepository LedgerLine { get; }

        IAccountBalanceCommandRepository AccountBalance { get; }

        // Commitment
        ICommitmentCommandRepository Commitment { get; }

        // Contracting
        IBOQCommandRepository BOQ { get; }
        IWBSCommandRepository WBS { get; }
        IDivisionCommandRepository Division { get; }
        ICostCodeCommandRepository CostCode { get; }
        IActivityCommandRepository Activity { get; }
        ISubcontractBOQCommandRepository SubcontractBOQ { get; }

        // Manufacturing
        IProductionOrderCommandRepository ProductionOrder { get; }

        // Asset Location
        IAssetLocationCommandRepository AssetLocation { get; }
    }
}