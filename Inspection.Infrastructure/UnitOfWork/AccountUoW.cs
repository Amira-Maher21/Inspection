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
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Infrastructure.DataContext;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountBalances;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.BankAccounts;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.Banks;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.Branches;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.Cashing;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.CostUnits;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.FiscalYears;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.LedgerCommandRepository;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSystem;
using Inspection.Infrastructure.Repositories.Command.Accounting.AccountSystem.PaymentTerms;
using Inspection.Infrastructure.Repositories.Command.Accounting.AR.MasterData.Customers;
using Inspection.Infrastructure.Repositories.Command.Accounting.AR.PurchaseReturns;
using Inspection.Infrastructure.Repositories.Command.Accounting.AR.SalesInvoices;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.AssetAccountingEvents;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.AssetMaintenances;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.AssetTransactions;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.Setup.AssetCategories;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.Setup.AssetComponents;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.Setup.AssetCustodies;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.Setup.AssetGroups;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.Setup.AssetLocations;
using Inspection.Infrastructure.Repositories.Command.Accounting.Assets.Setup.FixedAssets;
using Inspection.Infrastructure.Repositories.Command.Accounting.ChartOfAccounts;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CashPayments;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CashReceipts;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CashTransfers;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.Commitments;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CreditNotes;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.DebitNotes;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.JournalEntrys;
using Inspection.Infrastructure.Repositories.Command.Accounting.Payments.JournalEntryTemplates;
using Inspection.Infrastructure.Repositories.Command.Accounting.PR.MasterData.SupplierGroups;
using Inspection.Infrastructure.Repositories.Command.Accounting.PR.MasterData.Suppliers;
using Inspection.Infrastructure.Repositories.Command.Accounting.PR.PurchaseInvoices;
using Inspection.Infrastructure.Repositories.Command.ApprovalManagement;
using Inspection.Infrastructure.Repositories.Command.Contracting.Activitys;
using Inspection.Infrastructure.Repositories.Command.Contracting.CostCodes;
using Inspection.Infrastructure.Repositories.Command.Contracting.Divisions;
using Inspection.Infrastructure.Repositories.Command.Contracting.Setup.BOQs;
using Inspection.Infrastructure.Repositories.Command.Contracting.Setup.SubcontractBOQs;
using Inspection.Infrastructure.Repositories.Command.Contracting.WBSs;
using Inspection.Infrastructure.Repositories.Command.DMS.DocumentComments;
using Inspection.Infrastructure.Repositories.Command.DMS.Documents;
using Inspection.Infrastructure.Repositories.Command.DMS.DocumentShares;
using Inspection.Infrastructure.Repositories.Command.DMS.FolderPermissions;
using Inspection.Infrastructure.Repositories.Command.DMS.Folders;
using Inspection.Infrastructure.Repositories.Command.DMS.ShareAccessLogs;
using Inspection.Infrastructure.Repositories.Command.DMS.Tags;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.CompanyEquipments;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentAccessories;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentCategorys;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentInspections;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.Equipments;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentSoftwares;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentTypes;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.MaintenanceReports;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.MaintenanceSchedules;
using Inspection.Infrastructure.Repositories.Command.HRManagement.ApplicantCVs;
using Inspection.Infrastructure.Repositories.Command.HRManagement.Departments;
using Inspection.Infrastructure.Repositories.Command.HRManagement.Employees;
using Inspection.Infrastructure.Repositories.Command.HRManagement.InterviewEvaluations;
using Inspection.Infrastructure.Repositories.Command.HRManagement.JobAdvertisements;
using Inspection.Infrastructure.Repositories.Command.HRManagement.JobOfferNegotiations;
using Inspection.Infrastructure.Repositories.Command.HRManagement.JobRequests;
using Inspection.Infrastructure.Repositories.Command.HRManagement.JobTitles;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.AccreditationBodies;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.Certificates;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.Checklists;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.ChecklistTemplates;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.InspectionStandards;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.Inspector;
using Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.InspectorCompetencies;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionCertificates;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformations.Inspection.Infrastructure.Repositories.Command.EquipmentManagement.InspectionChecklistMoreInformations;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklists;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionMethods;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionReports;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionRequestDetailF;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionRequests;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionTypes;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectorCategory;
using Inspection.Infrastructure.Repositories.Command.InspectionManagement.ServicesItemsF;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Batchs;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Brands;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Colors;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Items;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Models;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.Sizes;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.UnitOfMeasure;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Infrastructure.Repositories.Command.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Infrastructure.Repositories.Command.Inventory.ItemAttributes;
using Inspection.Infrastructure.Repositories.Command.Inventory.ItemGroups;
using Inspection.Infrastructure.Repositories.Command.Inventory.System.InventoryBalances;
using Inspection.Infrastructure.Repositories.Command.Inventory.System.InventoryCostLayers;
using Inspection.Infrastructure.Repositories.Command.Inventory.System.InventoryLedgers;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.GoodsIssues;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.GoodsReceipts;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.GoodsTransferIns;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.InventoryAdjustments;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.InventoryScraps;
using Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.ScrapReasons;
using Inspection.Infrastructure.Repositories.Command.LocalizationManagement;
using Inspection.Infrastructure.Repositories.Command.Manufacturing.Setup.ProductionOrders;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.AreaF;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.BranchF;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.Screen_permissions;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.SeriesDetailsF;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.SeriesF;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.User_Codes;
using Inspection.Infrastructure.Repositories.Command.MenuManagement.User_Groups;
using Inspection.Infrastructure.Repositories.Command.SalesManagment.sales;
using Inspection.Infrastructure.Repositories.Command.SalesManagment.sales.DeliveryNotes;
using Inspection.Infrastructure.Repositories.Command.SalesManagment.Setup;
using Inspection.Infrastructure.Repositories.Command.SalesManagment.Transactions.SalesQuotations;
using Inspection.Infrastructure.Repositories.Command.SalesManagment.Transactions.SalesReturns;
using Inspection.Infrastructure.Repositories.Command.Sample.CurrencyExchangeRate;
using Inspection.Infrastructure.Repositories.Command.Setting.ModuleSettings;
using Inspection.Infrastructure.Repositories.Command.System;
using Inspection.Infrastructure.Repositories.Command.System.Languages;
using Inspection.Infrastructure.Repositories.Command.System.TaxCategorys;
using Inspection.Infrastructure.Repositories.Command.SystemConfigurations.Cities;
using Inspection.Infrastructure.Repositories.Command.SystemConfigurations.Companies;
using Inspection.Infrastructure.Repositories.Command.SystemConfigurations.Countris;
using Inspection.Infrastructure.Repositories.Command.SystemConfigurations.Currencies;
using Inspection.Infrastructure.Repositories.Command.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Infrastructure.Repositories.Command.SystemConfigurations.Operations;
using Inspection.Infrastructure.Repositories.Command.TestTableDetails;
using Inspection.Infrastructure.Repositories.Command.TestTableMasters;
using Inspection.Infrastructure.Repositories.Command.TestTableSubDetails;
using Inspection.Infrastructure.Repositories.Command.UserNotificationManagement;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.UnitOfWorkBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.UnitOfWork
{
    public sealed class AccountUoW : UnitOfWorkBase, IAccountUnitOfWork
    {

        //Sample
        private readonly Lazy<ISCurrencyExchangeRateCommandRepository> _scurrencyExchangeRates;
        //Sample


        private readonly Lazy<ILedgerCommandRepository> _ledger;
        private readonly Lazy<ILedgerLineCommandRepository> _ledgerLine;

        // Inspection Repo
        private readonly Lazy<IInspectionRequestCommandRepository> _inspectionRequset;
        private readonly Lazy<IInspectionReportCommandRepository> _inspectionReport;
        private readonly Lazy<IServiceTypeCommandRepository> _serviceType;
        // Equipment Repo
        private readonly Lazy<IEquipmentCommandRepository> _equipment;
        private readonly Lazy<IEquipmentInspectionCommandRepository> _equipmentInspection;
        private readonly Lazy<IMaintenanceReportCommandRepository> _maintenanceReport;
        private readonly Lazy<IMaintenanceScheduleCommandRepository> _maintenanceSchedule;
        // Localization Repo
        private readonly Lazy<ILocalizationCommandRepository> _localization;
        private readonly Lazy<IApprovalCommandRepository> _approval;
        private readonly Lazy<IUserApprovalCommandRepository> _userApproval;
        private readonly Lazy<IApprovalDelegationCommandRepository> _approvalDelegation;
        private readonly Lazy<IUserNotificationsCommandRepository> _userNotifications;
        private readonly Lazy<ICustomerCommandRepository> _customer;
        private readonly Lazy<ICustomerLocationCommandRepository> _CustomerLocation;
        private readonly Lazy<ICustomerProjectCommandRepository> _CustomerProject;
        private readonly Lazy<ISeriesCommandRepository> _series;
        private readonly Lazy<ISeriesDetailsCommandRepository> _seriesDetails;
        private readonly Lazy<IServiceItemCommandRepository> _serviceItem;

        private readonly Lazy<ICustomerBranchCommandRepository> _customerBranch;
        private readonly Lazy<IAreaCommandRepository> _area;
        private readonly Lazy<IInspectionMethodCommandRepository> _inspectionMethod;
        private readonly Lazy<IInspectorCategoryCommandRepository> _inspectorCategory;
        private readonly Lazy<IEquipmentTypeCommandRepository> _equipmentTypeQuery;
        private readonly Lazy<IJobOrderCommandRepository> _jobOrder;
        private readonly Lazy<IJobOrderDetailCommandRepository> _jobOrderDetail;
        private readonly Lazy<IInspectionCertificateCommandRepository> _inspectionCertificateQuery;
        private readonly Lazy<IInspectionRequestLinesCommandRepository> _inspectionRequestLinesQuery;
        private readonly Lazy<IInspectionRequestDetailSubcontractorCommandRepository> _inspectionRequestDetailSubcontractorQuery;
        private readonly Lazy<IEquipmentsMoreInformationCommandRepository> _iEquipmentsMoreInformation;
        private readonly Lazy<IApplicantCVCommandRepository> _applicantCVCommandRepository;
        private readonly Lazy<IDepartmentCommandRepository> _departmentCommandRepository;
        private readonly Lazy<IEmployeeCommandRepository> _employeeCommandRepository;
        private readonly Lazy<ITestTableMasterCommandRepository> _testTableMasterCommandRepository;
        private readonly Lazy<ITestTableDetailsCommandRepository> _testTableDetailsCommandRepository;
        private readonly Lazy<ITestTableSubDetailsCommandRepository> _testTableSubDetailsCommandRepository;
        private readonly Lazy<ICompanyEquipmentCommandRepository> _companyEquipmentsCommandRepository;
        private readonly Lazy<IEquipmentAccessoryCommandRepository> _EquipmentAccessoriesCommandRepository;
        private readonly Lazy<IEquipmentSoftwareCommandRepository> _EquipmentSoftwareCommandRepository;
        private readonly Lazy<IEquipmentCalibrationHistoryCommandRepository> _EquipmentCalibrationHistoryCommandRepository;
        private readonly Lazy<IEquipmentPreventiveMaintenanceCommandRepository> _EquipmentPreventiveMaintenanceCommandRepository;
        private readonly Lazy<IEquipmentMaintenanceAndRepairRecordCommandRepository> _EquipmentMaintenanceAndRepairRecordCommandRepository;
        private readonly Lazy<IJobRequestCommandRepository> _jobRequestCommandRepository;
        private readonly Lazy<IJobTitleCommandRepository> _jobTitleCommandRepository;
        private readonly Lazy<IInterviewEvaluationCommandRepository> _interviewEvaluationCommandRepository;
        private readonly Lazy<IJobAdvertisementCommandRepository> _jobAdvertisementCommandRepository;
        private readonly Lazy<IJobOfferNegotiationCommandRepository> _jobOfferNegotiationCommandRepository;
        private readonly Lazy<IEquipmentsMoreInformationDetailCommandRepository> _EquipmentsMoreInformationDetailCommandRepository;
        private readonly Lazy<IEquipmentCategoryCommandRepository> _EquipmentCategoryCommandRepository;
        private readonly Lazy<IEquipmentsMoreInformationTemplateDetailCommandRepository> _EquipmentsMoreInformationTemplateDetailCommandRepository;
        private readonly Lazy<IEquipmentsMoreInformationTemplateCommandRepository> _EquipmentsMoreInformationTemplateCommandRepository;
        private readonly Lazy<IInspectionChecklistCommandRepository> _InspectionChecklistCommandRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationTemplateDetailCR> _InspectionChecklistMoreInformationTemplateDetailCommandRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationTemplateCommandRepository> _InspectionChecklistMoreInformationTemplateCommandRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationCommandRepository> _InspectionChecklistMoreInformationCommandRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationDetailCommandRepository> _InspectionChecklistMoreInformationDetailCommandRepository;
        private readonly Lazy<IUser_GroupCommandRepository> _User_GroupsCommandRepository;
        private readonly Lazy<IScreen_permissionCommandRepository> _Screen_permissionCommandRepository;
        private readonly Lazy<ISalesInvoiceCommandRepository> _SalesInvoice;
        private readonly Lazy<IPurchaseInvoiceCommandRepository> _PurchaseInvoice;
        private readonly Lazy<IDeliveryNoteCommandRepository> _DeliveryNote;

        //SystemConfigurations
        private readonly Lazy<ICompanyCommandRepository> _company;
        private readonly Lazy<ICurrencyCommandRepository> _currency;
        private readonly Lazy<ICountriesCommandRepository> _countries;
        private readonly Lazy<ICurrencyExchangeRateCommandRepository> _currencyExchangeRates;
        private readonly Lazy<ICityCommandRepository> _city;
        private readonly Lazy<IOperationCommandRepository> _operation;


        // Contracting

        private readonly Lazy<IWBSCommandRepository> _WBS;
        private readonly Lazy<IDivisionCommandRepository> _Division;
        private readonly Lazy<ICostCodeCommandRepository> _CostCode;
        private readonly Lazy<IActivityCommandRepository> _Activity;




        //System
        private readonly Lazy<ITaxTypeCommandRepository> _Taxes;
        private readonly Lazy<ITaxCategoryCommandRepository> _TaxCategory;
        private readonly Lazy<ILanguageCommandRepository> _Languages;

        // Sales Mangement
        private readonly Lazy<ISalesQuotationCommandRepository> _salesQuotation;

        // Accounting
        private readonly Lazy<IBankCommandRepository> _bank;
        private readonly Lazy<IBankAccountCommandRepository> _bankAccount;
        private readonly Lazy<ICostCenterCommandRepository> _costCenter;
        private readonly Lazy<ICostUnitCommandRepository> _costUnit;
        private readonly Lazy<IFiscalYearCommandRepository> _fiscalYear;
        private readonly Lazy<IAccountingPeriodCommandRepository> _accountingPeriod;
        private readonly Lazy<IInspectionTypeCommandRepository> _inspectionTypes;
        private readonly Lazy<IChartOfAccountCommandRepository> _chartOfAccount;
        private readonly Lazy<IDefaultAccountTypeCommandRepository> _defaultAccountType;
        private readonly Lazy<IDefaultAccountGroupCommandRepository> _defaultAccountGroup;
        private readonly Lazy<IDefaultAccountAssignmentCommandRepository> _defaultAccountAssignment;
        private readonly Lazy<ISupplierGroupCommandRepository> _supplierGroupCommandRepository;
        private readonly Lazy<IPaymentTermCommandRepository> _paymentTerm;
        private readonly Lazy<ISupplierCommandRepository> _supplierCommandRepository;
        private readonly Lazy<ICustomerCommandRepository> _customerCommandRepository;
        private readonly Lazy<ICustomerGroupCommandRepository> _customerGroupCommandRepository;
        private readonly Lazy<ICustomerContactCommandRepository> _customerContactCommandRepository;
        private readonly Lazy<ICashCommandRepository> _cashCommandRepository;
        private readonly Lazy<IBranchCommandRepository> _branchCommandRepository;
        private readonly Lazy<IWarehouseCommandRepository> _warehouseCommandRepository;
        private readonly Lazy<IBrandCommandRepository> _brandCommandRepository;
        private readonly Lazy<IModelCommandRepository> _modelCommandRepository;
        private readonly Lazy<IUnitOfMeasureCommandRepository> _unitOfMeasureCommandRepository;
        private readonly Lazy<IAssetTransactionCommandRepository> _assetTransactionCommandRepository;
        private readonly Lazy<IAssetCategoryCommandRepository> _assetCategoryCommandRepository;
        private readonly Lazy<IAssetAccountingEventCommandRepository> _assetAccountingEventCommandRepository;
        private readonly Lazy<IAssetAccountingEventAccountCommandRepository> _assetAccountingEventAccountCommandRepository;
        private readonly Lazy<IInventoryBalanceCommandRepository> _inventoryBalanceCommandRepository;
        private readonly Lazy<IGoodsReceiptCommandRepository> _goodsReceiptCommandRepository;
        private readonly Lazy<IJournalEntryCommandRepository> _journalEntryCommandRepository;
        private readonly Lazy<IJournalEntryTemplateCommandRepository> _journalEntryTemplateCommandRepository;
        private readonly Lazy<IModeOfPaymentCommandRepository> _modeOfPaymentCommandRepository;
        private readonly Lazy<ICashReceiptCommandRepository> _cashReceipt;
        private readonly Lazy<ICashPaymentCommandRepository> _cashPayment;
        private readonly Lazy<IPurchaseReturnCommandRepository> _PurchaseReturn;
        private readonly Lazy<ICreditNoteCommandRepository> _creditNote;
        private readonly Lazy<IDebitNoteCommandRepository> _debitNote;
        private readonly Lazy<ICashTransferCommandRepository> _cashTransfer;

        // FixedAsset
        private readonly Lazy<IFixedAssetCommandRepository> _fixedAssetCommandRepository;
        private readonly Lazy<IAssetGroupCommandRepository> _assetGroupCommandRepository;
        private readonly Lazy<IAssetDepreciationScheduleCommandRepository> _assetDepreciationScheduleCommandRepository;
        private readonly Lazy<IAssetCustodyCommandRepository> _assetCustodyCommandRepository;
        private readonly Lazy<IAssetComponentCommandRepository> _assetComponent;
        private readonly Lazy<IAssetMaintenanceCommandRepository> _assetMaintenance;


        // Inventory
        private readonly Lazy<IUnitOfMeasureConversionCommandRepository> _unitOfMeasureConversionCommandRepository;
        private readonly Lazy<IItemGroupCommandRepository> _itemGroupCommandRepository;
        private readonly Lazy<IItemCommandRepository> _itemCommandRepository;
        private readonly Lazy<IItemVariantAttributeCommandRepository> _itemVariantAttribute;
        private readonly Lazy<IColorCommandRepository> _colorCommandRepository;
        private readonly Lazy<ISizeCommandRepository> _sizeCommandRepository;
        private readonly Lazy<IInventoryCostLayerCommandRepository> _inventoryCostLayerCommandRepository;
        private readonly Lazy<IWarehouseLocationCommandRepository> _warehouseLocationCommandRepository;
        private readonly Lazy<IInventoryOpeningBalanceCommandRepository> _inventoryOpeningBalance;
        private readonly Lazy<IInventoryLedgerCommandRepository> _inventoryLedgerCommandRepository;
        private readonly Lazy<IItemAttributeCommandRepository> _itemAttribute;
        private readonly Lazy<IGoodsIssueCommandRepository> _GoodsIssue;
        private readonly Lazy<IGoodsTransferOutCommandRepository> _goodsTransferOut;
        private readonly Lazy<IGoodsTransferInCommandRepository> _goodsTransferIn;
        private readonly Lazy<IBatchCommandRepository> _Batch;
        private readonly Lazy<IInventoryAdjustmentCommandRepository> _inventoryAdjustment;
        private readonly Lazy<IInventoryScrapCommandRepository> _InventoryScrap;
        private readonly Lazy<IScrapReasonCommandRepository> _ScrapReason;


        //Sales
        private readonly Lazy<ISalesPersonCommandRepository> _iSalesPersonCommandRepository;
        private readonly Lazy<IModuleSettingCommandRepository> _moduleSettingCommandRepository;
        private readonly Lazy<ISalesReturnCommandRepository> _SalesReturn;

        //MenuManagement

        private readonly Lazy<IUser_CodeCommandRepository> _User_CodeCommandRepository;
        private readonly Lazy<IInspectionStandardCommandRepository> _inspectionStandardCommandRepository;
        private readonly Lazy<IChecklistTemplateCommandRepository> _checklistTemplateCommandRepository;


        // Inspection
        private readonly Lazy<IInspectorCommandRepository> _inspector;
        private readonly Lazy<ICertificateCommandRepository> _certificate;
        private readonly Lazy<IChecklistCommandRepository> _checklist;
        private readonly Lazy<IInspectorCompetencyCommandRepository> _inspectorCompetency;
        private readonly Lazy<IAccreditationBodyCommandRepository> _accreditationBody;

        // Sales Order
        private readonly Lazy<ISalesOrderCommandRepository> _salesOrderCommandRepository;
        private readonly Lazy<ISalesOrderLinesCommandRepository> _salesOrderLinesCommandRepository;

        // DMS
        private readonly Lazy<IFolderCommandRepository> _folder;
        private readonly Lazy<IFolderPermissionCommandRepository> _folderPermission;
        private readonly Lazy<IDocumentShareCommandRepository> _documentShare;
        private readonly Lazy<ITagCommandRepository> _Tag;
        private readonly Lazy<IShareAccessLogCommandRepository> _ShareAccessLog;
        private readonly Lazy<ITagCommandRepository> _tag;
        private readonly Lazy<IDocumentCommandRepository> _document;
        private readonly Lazy<IDocumentEntityLinkCommandRepository> _documentEntityLink;
        private readonly Lazy<IDocumentCommentCommandRepository> _documentComment;

        //Account Balance
        private readonly Lazy<IAccountBalanceCommandRepository> _accountBalanceCommandRepository;

        // Commmitment
        private readonly Lazy<ICommitmentCommandRepository> _commitmentCommandRepository;

        // Contracting
        private readonly Lazy<IBOQCommandRepository> _bOQ;
        private readonly Lazy<ISubcontractBOQCommandRepository> _subcontractBOQ;

        // Manufacturing
        private readonly Lazy<IProductionOrderCommandRepository> _productionOrderCommandRepository;

        // Asset Location
        private readonly Lazy<IAssetLocationCommandRepository> _assetLocationCommandRepository;

        public AccountUoW(DbInspectionContext context,
                                        ITenantResolver tenantResolver,
                                        IExceptionManager exceptionManager)
                                        : base(context, tenantResolver, exceptionManager)
        {

            // Contracting

            //private readonly Lazy<IWBSCommandRepository> _WBS;
            //private readonly Lazy<IDivisionCommandRepository> _Division;
            //private readonly Lazy<ICostCodeCommandRepository> _CostCode;
            //private readonly Lazy<IActivityCommandRepository> _Activity;


            _WBS = new Lazy<IWBSCommandRepository>(new WBSCommandRepository(context, tenantResolver, exceptionManager));
            _Division = new Lazy<IDivisionCommandRepository>(new DivisionCommandRepository(context, tenantResolver, exceptionManager));

            _CostCode = new Lazy<ICostCodeCommandRepository>(new CostCodeCommandRepository(context, tenantResolver, exceptionManager));
            _Activity = new Lazy<IActivityCommandRepository>(new ActivityCommandRepository(context, tenantResolver, exceptionManager));



            //Sample
            _scurrencyExchangeRates = new Lazy<ISCurrencyExchangeRateCommandRepository>(() =>
                            new SCurrencyExchangeRateCommandRepository(_context, _tenantResolver, _exceptionManager));            //Sample

            _ledger = new Lazy<ILedgerCommandRepository>(new LedgerCommandRepository(context, tenantResolver, exceptionManager));
            _ledgerLine = new Lazy<ILedgerLineCommandRepository>(new LedgerLineCommandRepository(context, tenantResolver, exceptionManager));

            _inspectionRequset = new Lazy<IInspectionRequestCommandRepository>(new InspectionRequestCommandRepository(context, tenantResolver, exceptionManager));
            _inspectionReport = new Lazy<IInspectionReportCommandRepository>(new InspectionReportCommandRepository(context, tenantResolver, exceptionManager));
            _serviceType = new Lazy<IServiceTypeCommandRepository>(new ServiceTypeCommandRepository(context, tenantResolver, exceptionManager));
            // Equipment Repo
            _equipment = new Lazy<IEquipmentCommandRepository>(new EquipmentCommandRepository(context, tenantResolver, exceptionManager));
            _equipmentInspection = new Lazy<IEquipmentInspectionCommandRepository>(new EquipmentInspectionCommandRepository(context, tenantResolver, exceptionManager));
            _maintenanceReport = new Lazy<IMaintenanceReportCommandRepository>(new MaintenanceReportCommandRepository(context, tenantResolver, exceptionManager));
            _maintenanceSchedule = new Lazy<IMaintenanceScheduleCommandRepository>(new MaintenanceScheduleCommandRepository(context, tenantResolver, exceptionManager));
            // Localization
            _localization = new Lazy<ILocalizationCommandRepository>(new LocalizationCommandRepository(context, tenantResolver, exceptionManager));

            _approval = new Lazy<IApprovalCommandRepository>(new ApprovalCommandRepository(context, tenantResolver, exceptionManager));
            _userApproval = new Lazy<IUserApprovalCommandRepository>(new UserApprovalCommandRepository(context, tenantResolver, exceptionManager));
            _approvalDelegation = new Lazy<IApprovalDelegationCommandRepository>(new ApprovalDelegationCommandRepository(context, tenantResolver, exceptionManager));
            _userNotifications = new Lazy<IUserNotificationsCommandRepository>(new UserNotificationsCommandRepository(context, tenantResolver, exceptionManager));
            _series = new Lazy<ISeriesCommandRepository>(new SeriesCommandRepository(context, tenantResolver, exceptionManager));
            _seriesDetails = new Lazy<ISeriesDetailsCommandRepository>(new SeriesDetailsCommandRepository(context, tenantResolver, exceptionManager));
            // _customer = new Lazy<ICustomerCommandRepository>(new CustomerCommandRepository(context, tenantResolver, exceptionManager));
            _CustomerLocation = new Lazy<ICustomerLocationCommandRepository>(new CustomerLocationCommandRepository(context, tenantResolver, exceptionManager));
            _CustomerProject = new Lazy<ICustomerProjectCommandRepository>(new CustomerProjectCommandRepository(context, tenantResolver, exceptionManager));
            _serviceItem = new Lazy<IServiceItemCommandRepository>(new ServiceItemCommandRepository(context, tenantResolver, exceptionManager));

            _customerBranch = new Lazy<ICustomerBranchCommandRepository>(new CustomerBranchCommandRepository(context, tenantResolver, exceptionManager));
            _area = new Lazy<IAreaCommandRepository>(new AreaCommandRepository(context, tenantResolver, exceptionManager));
            _inspectionMethod = new Lazy<IInspectionMethodCommandRepository>(new InspectionMethodCommandRepository(context, tenantResolver, exceptionManager));
            _inspectorCategory = new Lazy<IInspectorCategoryCommandRepository>(new InspectorCategoryCommandRepository(context, tenantResolver, exceptionManager));
            _equipmentTypeQuery = new Lazy<IEquipmentTypeCommandRepository>(new EquipmentTypeCommandRepository(context, tenantResolver, exceptionManager));
            _jobOrder = new Lazy<IJobOrderCommandRepository>(new JobOrderCommandRepository(context, tenantResolver, exceptionManager));
            _jobOrderDetail = new Lazy<IJobOrderDetailCommandRepository>(new JobOrderDetailCommandRepository(context, tenantResolver, exceptionManager));
            _inspectionCertificateQuery = new Lazy<IInspectionCertificateCommandRepository>(new InspectionCertificateCommandRepository(context, tenantResolver, exceptionManager));
            _inspectionRequestLinesQuery = new Lazy<IInspectionRequestLinesCommandRepository>(new InspectionRequestLinesCommandRepository(context, tenantResolver, exceptionManager));
            _inspectionRequestDetailSubcontractorQuery = new Lazy<IInspectionRequestDetailSubcontractorCommandRepository>(new InspectionRequestDetailSubcontractorCommandRepository(context, tenantResolver, exceptionManager));
            _iEquipmentsMoreInformation = new Lazy<IEquipmentsMoreInformationCommandRepository>(new EquipmentsMoreInformationCommandRepository(context, tenantResolver, exceptionManager));

            _applicantCVCommandRepository = new Lazy<IApplicantCVCommandRepository>(new ApplicantCVCommandRepository(context, tenantResolver, exceptionManager));
            _departmentCommandRepository = new Lazy<IDepartmentCommandRepository>(new DepartmentCommandRepository(context, tenantResolver, exceptionManager));
            _employeeCommandRepository = new Lazy<IEmployeeCommandRepository>(new EmployeeCommandRepository(context, tenantResolver, exceptionManager));
            _testTableMasterCommandRepository = new Lazy<ITestTableMasterCommandRepository>(new TestTableMasterCommandRepository(context, tenantResolver, exceptionManager));
            _testTableDetailsCommandRepository = new Lazy<ITestTableDetailsCommandRepository>(new TestTableDetailCommandRepository(context, tenantResolver, exceptionManager));
            _testTableSubDetailsCommandRepository = new Lazy<ITestTableSubDetailsCommandRepository>(new TestTableSubDetailsCommandRepository(context, tenantResolver, exceptionManager));
            _companyEquipmentsCommandRepository = new Lazy<ICompanyEquipmentCommandRepository>(new CompanyEquipmentCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentAccessoriesCommandRepository = new Lazy<IEquipmentAccessoryCommandRepository>(new EquipmentAccessoriesCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentSoftwareCommandRepository = new Lazy<IEquipmentSoftwareCommandRepository>(new EquipmentSoftwaresCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentCalibrationHistoryCommandRepository = new Lazy<IEquipmentCalibrationHistoryCommandRepository>(new EquipmentCalibrationHistoryCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentPreventiveMaintenanceCommandRepository = new Lazy<IEquipmentPreventiveMaintenanceCommandRepository>(new EquipmentPreventiveMaintenanceCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentMaintenanceAndRepairRecordCommandRepository = new Lazy<IEquipmentMaintenanceAndRepairRecordCommandRepository>(new EquipmentMaintenanceAndRepairRecordCommandRepository(context, tenantResolver, exceptionManager));

            _jobRequestCommandRepository = new Lazy<IJobRequestCommandRepository>(new JobRequestCommandRepository(context, tenantResolver, exceptionManager));
            _jobTitleCommandRepository = new Lazy<IJobTitleCommandRepository>(new JobTitleCommandRepository(context, tenantResolver, exceptionManager));

            _interviewEvaluationCommandRepository = new Lazy<IInterviewEvaluationCommandRepository>(new InterviewEvaluationCommandRepository(context, tenantResolver, exceptionManager));
            _jobAdvertisementCommandRepository = new Lazy<IJobAdvertisementCommandRepository>(new JobAdvertisementCommandRepository(context, tenantResolver, exceptionManager));
            _jobOfferNegotiationCommandRepository = new Lazy<IJobOfferNegotiationCommandRepository>(new JobOfferNegotiationCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentsMoreInformationDetailCommandRepository = new Lazy<IEquipmentsMoreInformationDetailCommandRepository>(new EquipmentsMoreInformationDetailCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentCategoryCommandRepository = new Lazy<IEquipmentCategoryCommandRepository>(new EquipmentCategoryCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentsMoreInformationTemplateDetailCommandRepository = new Lazy<IEquipmentsMoreInformationTemplateDetailCommandRepository>(new EquipmentsMoreInformationTemplateDetailCommandRepository(context, tenantResolver, exceptionManager));
            _EquipmentsMoreInformationTemplateCommandRepository = new Lazy<IEquipmentsMoreInformationTemplateCommandRepository>(new EquipmentsMoreInformationTemplateCommandRepository(context, tenantResolver, exceptionManager));

            _InspectionChecklistCommandRepository = new Lazy<IInspectionChecklistCommandRepository>(new InspectionChecklistCommandRepository(context, tenantResolver, exceptionManager));
            _InspectionChecklistMoreInformationDetailCommandRepository = new Lazy<IInspectionChecklistMoreInformationDetailCommandRepository>(new InspectionChecklistMoreInformationDetailCommandRepository(context, tenantResolver, exceptionManager));
            _InspectionChecklistMoreInformationTemplateCommandRepository = new Lazy<IInspectionChecklistMoreInformationTemplateCommandRepository>(new InspectionChecklistMoreInformationTemplateCommandRepository(context, tenantResolver, exceptionManager));
            _InspectionChecklistMoreInformationCommandRepository = new Lazy<IInspectionChecklistMoreInformationCommandRepository>(new InspectionChecklistMoreInformationCommandRepository(context, tenantResolver, exceptionManager));
            _InspectionChecklistMoreInformationTemplateDetailCommandRepository = new Lazy<IInspectionChecklistMoreInformationTemplateDetailCR>(new InspectionChecklistMoreInformationTemplateDetailCR(context, tenantResolver, exceptionManager));
            _User_GroupsCommandRepository = new Lazy<IUser_GroupCommandRepository>(new User_GroupCommandRepository(context, tenantResolver, exceptionManager));
            _Screen_permissionCommandRepository = new Lazy<IScreen_permissionCommandRepository>(new Screen_permissionCommandRepository(context, tenantResolver, exceptionManager));
            _SalesInvoice = new Lazy<ISalesInvoiceCommandRepository>(new SalesInvoiceCommandRepository(context, tenantResolver, exceptionManager));

            //SystemConfigurations
            _company = new Lazy<ICompanyCommandRepository>(new CompanyCommandRepository(context, tenantResolver, exceptionManager));
            _currency = new Lazy<ICurrencyCommandRepository>(new CurrencyCommandRepository(context, tenantResolver, exceptionManager));
            _countries = new Lazy<ICountriesCommandRepository>(new CountryCommandRepository(context, tenantResolver, exceptionManager));
            _city = new Lazy<ICityCommandRepository>(new CityCommandRepository(context, tenantResolver, exceptionManager));
            _operation = new Lazy<IOperationCommandRepository>(new OperationCommandRepository(context, tenantResolver, exceptionManager));


            //System
            _Taxes = new Lazy<ITaxTypeCommandRepository>(new TaxTypeCommandRepository(context, tenantResolver, exceptionManager));
            _TaxCategory = new Lazy<ITaxCategoryCommandRepository>(new TaxCategoryCommandRepository(context, tenantResolver, exceptionManager));
            _Languages = new Lazy<ILanguageCommandRepository>(new LanguageCommandRepository(context, tenantResolver, exceptionManager));

            // Sales Mangement
            _salesQuotation = new Lazy<ISalesQuotationCommandRepository>(new SalesQuotationCommandRepository(context, tenantResolver, exceptionManager));
            _SalesReturn = new Lazy<ISalesReturnCommandRepository>(new SalesReturnCommandRepository(context, tenantResolver, exceptionManager));


            //Accounting
            _costUnit = new Lazy<ICostUnitCommandRepository>(new CostUnitCommandRepository(context, tenantResolver, exceptionManager));
            _fiscalYear = new Lazy<IFiscalYearCommandRepository>(new FiscalYearCommandRepository(context, tenantResolver, exceptionManager));
            _accountingPeriod = new Lazy<IAccountingPeriodCommandRepository>(new AccountingPeriodCommandRepository(context, tenantResolver, exceptionManager));
            _currencyExchangeRates = new Lazy<ICurrencyExchangeRateCommandRepository>(new CurrencyExchangeRateCommandRepository(context, tenantResolver, exceptionManager));
            _inspectionTypes = new Lazy<IInspectionTypeCommandRepository>(new InspectionTypeCommandRepository(context, tenantResolver, exceptionManager));
            _chartOfAccount = new Lazy<IChartOfAccountCommandRepository>(new ChartOfAccountCommandRepository(context, tenantResolver, exceptionManager));
            _defaultAccountType = new Lazy<IDefaultAccountTypeCommandRepository>(new DefaultAccountTypeCommandRepository(context, tenantResolver, exceptionManager));
            _defaultAccountGroup = new Lazy<IDefaultAccountGroupCommandRepository>(new DefaultAccountGroupCommandRepository(context, tenantResolver, exceptionManager));
            _defaultAccountAssignment = new Lazy<IDefaultAccountAssignmentCommandRepository>(new DefaultAccountAssignmentCommandRepository(context, tenantResolver, exceptionManager));
            _paymentTerm = new Lazy<IPaymentTermCommandRepository>(new PaymentTermCommandRepository(context, tenantResolver, exceptionManager));
            _customerCommandRepository = new Lazy<ICustomerCommandRepository>(new CustomerCommandRepository(context, tenantResolver, exceptionManager));
            _customerContactCommandRepository = new Lazy<ICustomerContactCommandRepository>(new CustomerContactCommandRepository(context, tenantResolver, exceptionManager));
            _supplierCommandRepository = new Lazy<ISupplierCommandRepository>(new SupplierCommandRepository(context, tenantResolver, exceptionManager));
            _customerGroupCommandRepository = new Lazy<ICustomerGroupCommandRepository>(new CustomerGroupCommandRepository(context, tenantResolver, exceptionManager));
            _supplierGroupCommandRepository = new Lazy<ISupplierGroupCommandRepository>(new SupplierGroupCommandRepository(context, tenantResolver, exceptionManager));
            _costCenter = new Lazy<ICostCenterCommandRepository>(new CostCenterCommandRepository(context, tenantResolver, exceptionManager));
            _cashCommandRepository = new Lazy<ICashCommandRepository>(new CashCommandRepository(context, tenantResolver, exceptionManager));
            _branchCommandRepository = new Lazy<IBranchCommandRepository>(new BranchCommandRepository(context, tenantResolver, exceptionManager));
            _warehouseCommandRepository = new Lazy<IWarehouseCommandRepository>(new WarehouseCommandRepository(context, tenantResolver, exceptionManager));
            _brandCommandRepository = new Lazy<IBrandCommandRepository>(new BrandCommandRepository(context, tenantResolver, exceptionManager));
            _modelCommandRepository = new Lazy<IModelCommandRepository>(new ModelCommandRepository(context, tenantResolver, exceptionManager));
            _unitOfMeasureCommandRepository = new Lazy<IUnitOfMeasureCommandRepository>(new UnitOfMeasureCommandRepository(context, tenantResolver, exceptionManager));
            _unitOfMeasureConversionCommandRepository = new Lazy<IUnitOfMeasureConversionCommandRepository>(new UnitOfMeasureConversionCommandRepository(context, tenantResolver, exceptionManager));
            _assetCategoryCommandRepository = new Lazy<IAssetCategoryCommandRepository>(new AssetCategoryCommandRepository(context, tenantResolver, exceptionManager));
            _assetTransactionCommandRepository = new Lazy<IAssetTransactionCommandRepository>(new AssetTransactionCommandRepository(context, tenantResolver, exceptionManager));
            _journalEntryTemplateCommandRepository = new Lazy<IJournalEntryTemplateCommandRepository>(new JournalEntryTemplateCommandRepository(context, tenantResolver, exceptionManager));
            _modeOfPaymentCommandRepository = new Lazy<IModeOfPaymentCommandRepository>(new ModeOfPaymentCommandRepository(context, tenantResolver, exceptionManager));
            _bank = new Lazy<IBankCommandRepository>(new BankCommandRepository(context, tenantResolver, exceptionManager));
            _bankAccount = new Lazy<IBankAccountCommandRepository>(new BankAccountCommandRepository(context, tenantResolver, exceptionManager));
            _journalEntryCommandRepository = new Lazy<IJournalEntryCommandRepository>(new JournalEntryCommandRepository(context, tenantResolver, exceptionManager));
            _cashReceipt = new Lazy<ICashReceiptCommandRepository>(new CashReceiptCommandRepository(context, tenantResolver, exceptionManager));
            _cashPayment = new Lazy<ICashPaymentCommandRepository>(new CashPaymentCommandRepository(context, tenantResolver, exceptionManager));
            _PurchaseInvoice = new Lazy<IPurchaseInvoiceCommandRepository>(new PurchaseInvoiceCommandRepository(context, tenantResolver, exceptionManager));
            _DeliveryNote = new Lazy<IDeliveryNoteCommandRepository>(new DeliveryNoteCommandRepository(context, tenantResolver, exceptionManager));
            _PurchaseReturn = new Lazy<IPurchaseReturnCommandRepository>(new PurchaseReturnCommandRepository(context, tenantResolver, exceptionManager));
            _creditNote = new Lazy<ICreditNoteCommandRepository>(new CreditNoteCommandRepository(context, tenantResolver, exceptionManager));
            _debitNote = new Lazy<IDebitNoteCommandRepository>(new DebitNoteCommandRepository(context, tenantResolver, exceptionManager));
            _cashTransfer = new Lazy<ICashTransferCommandRepository>(new CashTransferCommandRepository(context, tenantResolver, exceptionManager));

            // FixedAsset
            _assetDepreciationScheduleCommandRepository = new Lazy<IAssetDepreciationScheduleCommandRepository>(new AssetDepreciationScheduleCommandRepository(context, tenantResolver, exceptionManager));
            _fixedAssetCommandRepository = new Lazy<IFixedAssetCommandRepository>(new FixedAssetCommandRepository(context, tenantResolver, exceptionManager));
            _assetGroupCommandRepository = new Lazy<IAssetGroupCommandRepository>(new AssetGroupCommandRepository(context, tenantResolver, exceptionManager));
            _assetAccountingEventCommandRepository = new Lazy<IAssetAccountingEventCommandRepository>(new AssetAccountingEventCommandRepository(context, tenantResolver, exceptionManager));
            _assetAccountingEventAccountCommandRepository = new Lazy<IAssetAccountingEventAccountCommandRepository>(new AssetAccountingEventAccountCommandRepository(context, tenantResolver, exceptionManager));
            _assetCustodyCommandRepository = new Lazy<IAssetCustodyCommandRepository>(new AssetCustodyCmmandRepository(context, tenantResolver, exceptionManager));
            _assetComponent = new Lazy<IAssetComponentCommandRepository>(new AssetComponentCommandRepository(context, tenantResolver, exceptionManager));
            _assetMaintenance = new Lazy<IAssetMaintenanceCommandRepository>(new AssetMaintenanceCommandRepository(context, tenantResolver, exceptionManager));

            // Inventory
            _itemGroupCommandRepository = new Lazy<IItemGroupCommandRepository>(new ItemGroupCommandRepository(context, tenantResolver, exceptionManager));
            _itemCommandRepository = new Lazy<IItemCommandRepository>(new ItemCommandRepository(context, tenantResolver, exceptionManager));
            _itemVariantAttribute = new Lazy<IItemVariantAttributeCommandRepository>(new ItemVariantAttributeCommandRepository(context, tenantResolver, exceptionManager));

            _sizeCommandRepository = new Lazy<ISizeCommandRepository>(new SizeCommandRepository(context, tenantResolver, exceptionManager));
            _colorCommandRepository = new Lazy<IColorCommandRepository>(new ColorCommandRepository(context, tenantResolver, exceptionManager));
            _inventoryBalanceCommandRepository = new Lazy<IInventoryBalanceCommandRepository>(new InventoryBalanceCommandRepository(context, tenantResolver, exceptionManager));
            _goodsReceiptCommandRepository = new Lazy<IGoodsReceiptCommandRepository>(new GoodsReceiptCommandRepository(context, tenantResolver, exceptionManager));

            _inventoryCostLayerCommandRepository = new Lazy<IInventoryCostLayerCommandRepository>(new InventoryCostLayerCommandRepository(context, tenantResolver, exceptionManager));
            _warehouseLocationCommandRepository = new Lazy<IWarehouseLocationCommandRepository>(new WarehouseLocationCommandRepository(context, tenantResolver, exceptionManager));
            _inventoryOpeningBalance = new Lazy<IInventoryOpeningBalanceCommandRepository>(new InventoryOpeningBalanceCommandRepository(context, tenantResolver, exceptionManager));
            _inventoryLedgerCommandRepository = new Lazy<IInventoryLedgerCommandRepository>(new InventoryLedgerCommandRepository(context, tenantResolver, exceptionManager));
            _itemAttribute = new Lazy<IItemAttributeCommandRepository>(new ItemAttributeCommandRepository(context, tenantResolver, exceptionManager));

            _accountBalanceCommandRepository = new Lazy<IAccountBalanceCommandRepository>(new AccountBalanceCommandRepository(context, tenantResolver, exceptionManager));

            _iSalesPersonCommandRepository = new Lazy<ISalesPersonCommandRepository>(new SalesPersonCommandRepository(context, tenantResolver, exceptionManager));
            _moduleSettingCommandRepository = new Lazy<IModuleSettingCommandRepository>(new ModuleSettingCommandRepository(context, tenantResolver, exceptionManager));
            _GoodsIssue = new Lazy<IGoodsIssueCommandRepository>(new GoodsIssueCommandRepository(context, tenantResolver, exceptionManager));
            _goodsTransferOut = new Lazy<IGoodsTransferOutCommandRepository>(new GoodsTransferOutCommandRepository(context, tenantResolver, exceptionManager));
            _goodsTransferIn = new Lazy<IGoodsTransferInCommandRepository>(new GoodsTransferInCommandRepository(context, tenantResolver, exceptionManager));
            _Batch = new Lazy<IBatchCommandRepository>(new BatchCommandRepository(context, tenantResolver, exceptionManager));
            _inventoryAdjustment = new Lazy<IInventoryAdjustmentCommandRepository>(new InventoryAdjustmentCommandRepository(context, tenantResolver, exceptionManager));
            _InventoryScrap = new Lazy<IInventoryScrapCommandRepository>(new InventoryScrapCommandRepository(context, tenantResolver, exceptionManager));
            _ScrapReason = new Lazy<IScrapReasonCommandRepository>(new ScrapReasonCommandRepository(context, tenantResolver, exceptionManager));


            //MenuManagement
            _User_CodeCommandRepository = new Lazy<IUser_CodeCommandRepository>(new User_CodeCommandRepository(context, tenantResolver, exceptionManager));

            _inspectionStandardCommandRepository = new Lazy<IInspectionStandardCommandRepository>(new InspectionStandardCommandRepository(context, tenantResolver, exceptionManager));
            _checklistTemplateCommandRepository = new Lazy<IChecklistTemplateCommandRepository>(new ChecklistTemplateCommandRepository(context, tenantResolver, exceptionManager));
            // Inspection
            _checklist = new Lazy<IChecklistCommandRepository>(new ChecklistCommandRepository(context, tenantResolver, exceptionManager));
            _inspector = new Lazy<IInspectorCommandRepository>(new InspectorCommandRepository(context, tenantResolver, exceptionManager));
            _certificate = new Lazy<ICertificateCommandRepository>(new CertificateCommandRepository(context, tenantResolver, exceptionManager));
            _accreditationBody = new Lazy<IAccreditationBodyCommandRepository>(new AccreditationBodyCommandRepository(context, tenantResolver, exceptionManager));
            _inspectorCompetency = new Lazy<IInspectorCompetencyCommandRepository>(new InspectorCompetencyCommandRepository(context, tenantResolver, exceptionManager));

            _salesOrderCommandRepository = new Lazy<ISalesOrderCommandRepository>(new SalesOrderCommandRepository(context, tenantResolver, exceptionManager));
            _salesOrderLinesCommandRepository = new Lazy<ISalesOrderLinesCommandRepository>(new SalesOrderLineCommandRepository(context, tenantResolver, exceptionManager));

            // DMS
            _folder = new Lazy<IFolderCommandRepository>(new FolderCommandRepository(context, tenantResolver, exceptionManager));
            _folderPermission = new Lazy<IFolderPermissionCommandRepository>(new FolderPermissionCommandRepository(context, tenantResolver, exceptionManager));
            _documentShare = new Lazy<IDocumentShareCommandRepository>(new DocumentShareCommandRepository(context, tenantResolver, exceptionManager));
            _Tag = new Lazy<ITagCommandRepository>(new TagCommandRepository(context, tenantResolver, exceptionManager));
            _ShareAccessLog = new Lazy<IShareAccessLogCommandRepository>(new ShareAccessLogCommandRepository(context, tenantResolver, exceptionManager));


            _tag = new Lazy<ITagCommandRepository>(new TagCommandRepository(context, tenantResolver, exceptionManager));
            _document = new Lazy<IDocumentCommandRepository>(new DocumentCommandRepository(context, tenantResolver, exceptionManager));
            _documentEntityLink = new Lazy<IDocumentEntityLinkCommandRepository>(new DocumentEntityLinkCommandRepository(context, tenantResolver, exceptionManager));
            _documentComment = new Lazy<IDocumentCommentCommandRepository>(new DocumentCommentCommandRepository(context, tenantResolver, exceptionManager));

            // Commitment
            _commitmentCommandRepository = new Lazy<ICommitmentCommandRepository>(new CommitmentCommandRepository(context, tenantResolver, exceptionManager));
            // Contracting
            _bOQ = new Lazy<IBOQCommandRepository>(new BOQCommandRepository(context, tenantResolver, exceptionManager));
            _subcontractBOQ = new Lazy<ISubcontractBOQCommandRepository>(new SubcontractBOQCommandRepository(context, tenantResolver, exceptionManager));

            // Manufacturing
            _productionOrderCommandRepository = new Lazy<IProductionOrderCommandRepository>(new ProductionOrderCommandRepository(context, tenantResolver, exceptionManager));

            // Asset Location
            _assetLocationCommandRepository = new Lazy<IAssetLocationCommandRepository>(new AssetLocationCommandRepository(context, tenantResolver, exceptionManager));


        }



        //Sample
        public ISCurrencyExchangeRateCommandRepository SCurrencyExchangeRates => _scurrencyExchangeRates.Value;
        //Sample

        public IInterviewEvaluationCommandRepository InterviewEvaluationCommandRepository => _interviewEvaluationCommandRepository.Value;
        public IJobAdvertisementCommandRepository JobAdvertisementCommandRepository => _jobAdvertisementCommandRepository.Value;
        public IJobOfferNegotiationCommandRepository JobOfferNegotiationCommandRepository => _jobOfferNegotiationCommandRepository.Value;
        public IInspectionRequestCommandRepository InspectionRequest => _inspectionRequset.Value;
        public IInspectionReportCommandRepository InspectionReport => _inspectionReport.Value;
        public IServiceTypeCommandRepository ServiceType => _serviceType.Value;
        // Equipment Repo
        public IEquipmentCommandRepository Equipment => _equipment.Value;
        public IEquipmentInspectionCommandRepository EquipmentInspection => _equipmentInspection.Value;
        public IMaintenanceReportCommandRepository MaintenanceReport => _maintenanceReport.Value;
        public IMaintenanceScheduleCommandRepository MaintenanceSchedule => _maintenanceSchedule.Value;
        public ILocalizationCommandRepository Localization => _localization.Value;
        public IApprovalCommandRepository Approval => _approval.Value;
        public IUserApprovalCommandRepository UserApproval => _userApproval.Value;
        public IApprovalDelegationCommandRepository ApprovalDelegation => _approvalDelegation.Value;
        public IUserNotificationsCommandRepository UserNotifications => _userNotifications.Value;
        public ICustomerCommandRepository Customer => _customer.Value;
        public ICustomerLocationCommandRepository CustomerLocation => _CustomerLocation.Value;
        public ICustomerProjectCommandRepository CustomerProject => _CustomerProject.Value;
        public ISeriesCommandRepository Series => _series.Value;
        public ISeriesDetailsCommandRepository SeriesDetails => _seriesDetails.Value;
        public IServiceItemCommandRepository ServicesItems => _serviceItem.Value;
        public IAreaCommandRepository Area => _area.Value;
        public ICustomerBranchCommandRepository CustomerBranch => _customerBranch.Value;
        public IInspectionMethodCommandRepository InspectionMethod => _inspectionMethod.Value;
        public IInspectorCategoryCommandRepository InspectorCategory => _inspectorCategory.Value;
        public IEquipmentTypeCommandRepository EquipmentType => _equipmentTypeQuery.Value;
        public IJobOrderCommandRepository JobOrder => _jobOrder.Value;
        public IJobOrderDetailCommandRepository JobOrderDetail => _jobOrderDetail.Value;
        public IInspectionCertificateCommandRepository InspectionCertificate => _inspectionCertificateQuery.Value;
        public IInspectionRequestLinesCommandRepository InspectionRequestLines => _inspectionRequestLinesQuery.Value;
        public IInspectionRequestDetailSubcontractorCommandRepository InspectionRequestDetailSubcontractor => _inspectionRequestDetailSubcontractorQuery.Value;
        public IEquipmentsMoreInformationCommandRepository EquipmentsMoreInformation => _iEquipmentsMoreInformation.Value;
        public IApplicantCVCommandRepository ApplicantCVCommandRepository => _applicantCVCommandRepository.Value;
        public IDepartmentCommandRepository DepartmentCommandRepository => _departmentCommandRepository.Value;
        public IEmployeeCommandRepository EmployeeCommandRepository => _employeeCommandRepository.Value;
        public ITestTableSubDetailsCommandRepository TestTableSubDetailCommandRepository => _testTableSubDetailsCommandRepository.Value;
        public ITestTableDetailsCommandRepository TestTableDetailCommandRepository => _testTableDetailsCommandRepository.Value;
        public ITestTableMasterCommandRepository TestTableMasterCommandRepository => _testTableMasterCommandRepository.Value;
        public ICompanyEquipmentCommandRepository CompanyEquipmentCommandRepository => _companyEquipmentsCommandRepository.Value;
        public IEquipmentAccessoryCommandRepository EquipmentAccessoriesCommandRepository => _EquipmentAccessoriesCommandRepository.Value;
        public IEquipmentSoftwareCommandRepository EquipmentSoftwareCommandRepository => _EquipmentSoftwareCommandRepository.Value;
        public IEquipmentCalibrationHistoryCommandRepository EquipmentCalibrationHistoryCommandRepository => _EquipmentCalibrationHistoryCommandRepository.Value;
        public IEquipmentPreventiveMaintenanceCommandRepository EquipmentPreventiveMaintenanceCommandRepository => _EquipmentPreventiveMaintenanceCommandRepository.Value;
        public IEquipmentMaintenanceAndRepairRecordCommandRepository EquipmentMaintenanceAndRepairRecordCommandRepository => _EquipmentMaintenanceAndRepairRecordCommandRepository.Value;
        public IJobRequestCommandRepository JobRequestCommandRepository => _jobRequestCommandRepository.Value;
        public IJobTitleCommandRepository JobTitleCommandRepository => _jobTitleCommandRepository.Value;
        public IEquipmentsMoreInformationDetailCommandRepository EquipmentsMoreInformationDetailCommandRepository => _EquipmentsMoreInformationDetailCommandRepository.Value;
        public IEquipmentCategoryCommandRepository EquipmentCategoryCommandRepository => _EquipmentCategoryCommandRepository.Value;
        public IEquipmentsMoreInformationTemplateDetailCommandRepository EquipmentsMoreInformationTemplateDetailCommandRepository => _EquipmentsMoreInformationTemplateDetailCommandRepository.Value;
        public IEquipmentsMoreInformationTemplateCommandRepository EquipmentsMoreInformationTemplateCommandRepository => _EquipmentsMoreInformationTemplateCommandRepository.Value;

        public IInspectionChecklistMoreInformationDetailCommandRepository InspectionChecklistMoreInformationDetailCommandRepository => _InspectionChecklistMoreInformationDetailCommandRepository.Value;
        public IInspectionChecklistMoreInformationCommandRepository InspectionChecklistMoreInformationCommandRepository => _InspectionChecklistMoreInformationCommandRepository.Value;
        public IInspectionChecklistCommandRepository InspectionChecklistCommandRepository => _InspectionChecklistCommandRepository.Value;
        public IInspectionChecklistMoreInformationTemplateCommandRepository InspectionChecklistMoreInformationTemplateCommandRpository => _InspectionChecklistMoreInformationTemplateCommandRepository.Value;
        public IInspectionChecklistMoreInformationTemplateDetailCR InspectionChecklistMoreInformationTemplateDetailCR => _InspectionChecklistMoreInformationTemplateDetailCommandRepository.Value;

        public IUser_GroupCommandRepository User_GroupCommandRepository => _User_GroupsCommandRepository.Value;
        public IScreen_permissionCommandRepository Screen_permissionCommandRepository => _Screen_permissionCommandRepository.Value;
        public ISalesInvoiceCommandRepository SalesInvoice => _SalesInvoice.Value;

        //SystemConfigurations
        public ICompanyCommandRepository Company => _company.Value;

        public ICurrencyCommandRepository Currency => _currency.Value;
        public ICityCommandRepository City => _city.Value;
        public ICountriesCommandRepository Country => _countries.Value;

        //System
        public ITaxTypeCommandRepository Taxes => _Taxes.Value;
        public ITaxCategoryCommandRepository TaxCategory => _TaxCategory.Value;

        // Sales Mangement
        public ISalesQuotationCommandRepository SalesQuotation => _salesQuotation.Value;
        public ISalesReturnCommandRepository SalesReturn => _SalesReturn.Value;


        //Accounting
        public ICostCenterCommandRepository CostCenter => _costCenter.Value;
        public ICostUnitCommandRepository CostUnit => _costUnit.Value;
        public IFiscalYearCommandRepository FiscalYear => _fiscalYear.Value;
        public IOperationCommandRepository Operations => _operation.Value;
        public ICurrencyExchangeRateCommandRepository CurrencyExchangeRate => _currencyExchangeRates.Value;
        public IInspectionTypeCommandRepository InspectionTypesCommandRepository => _inspectionTypes.Value;
        public IAccountingPeriodCommandRepository AccountingPeriod => _accountingPeriod.Value;
        public IChartOfAccountCommandRepository ChartOfAccount => _chartOfAccount.Value;

        public IDefaultAccountTypeCommandRepository DefaultAccountType => _defaultAccountType.Value;
        public IDefaultAccountGroupCommandRepository DefaultAccountGroup => _defaultAccountGroup.Value;
        public IDefaultAccountAssignmentCommandRepository DefaultAccountAssignment => _defaultAccountAssignment.Value;
        public IPaymentTermCommandRepository PaymentTerm => _paymentTerm.Value;
        public ISupplierCommandRepository SupplierCommand => _supplierCommandRepository.Value;
        public ICustomerGroupCommandRepository CustomerGroup => _customerGroupCommandRepository.Value;
        public ICustomerCommandRepository CustomerCommandRepository => _customerCommandRepository.Value;
        public ICustomerContactCommandRepository CustomerContactCommandRepository => _customerContactCommandRepository.Value;
        public IBranchCommandRepository Branch => _branchCommandRepository.Value;
        public IWarehouseCommandRepository Warehouse => _warehouseCommandRepository.Value;
        public IModelCommandRepository Model => _modelCommandRepository.Value;
        public IBrandCommandRepository Brand => _brandCommandRepository.Value;
        public IBankCommandRepository Bank => _bank.Value;
        public IBankAccountCommandRepository BankAccount => _bankAccount.Value;
        public ISupplierGroupCommandRepository SupplierGroup => _supplierGroupCommandRepository.Value;
        public ICashCommandRepository Cash => _cashCommandRepository.Value;
        public IUnitOfMeasureCommandRepository UnitOfMeasure => _unitOfMeasureCommandRepository.Value;
        public IJournalEntryCommandRepository IJournalEntry => _journalEntryCommandRepository.Value;

        public IJournalEntryTemplateCommandRepository JournalEntryTemplate => _journalEntryTemplateCommandRepository.Value;
        public IModeOfPaymentCommandRepository ModeOfPayment => _modeOfPaymentCommandRepository.Value;
        public ICashReceiptCommandRepository CashReceipt => _cashReceipt.Value;
        public ICashPaymentCommandRepository CashPayment => _cashPayment.Value;
        public IPurchaseInvoiceCommandRepository PurchaseInvoice => _PurchaseInvoice.Value;
        public IDeliveryNoteCommandRepository DeliveryNote => _DeliveryNote.Value;
        public IPurchaseReturnCommandRepository PurchaseReturn => _PurchaseReturn.Value;
        public ICreditNoteCommandRepository CreditNote => _creditNote.Value;
        public IDebitNoteCommandRepository DebitNote => _debitNote.Value;
        public ICashTransferCommandRepository CashTransfer => _cashTransfer.Value;

        // FixedAsset
        public IFixedAssetCommandRepository FixedAsset => _fixedAssetCommandRepository.Value;
        public IAssetCustodyCommandRepository AssetCustody => _assetCustodyCommandRepository.Value;
        public IAssetGroupCommandRepository AssetGroup => _assetGroupCommandRepository.Value;
        public IAssetDepreciationScheduleCommandRepository AssetDepreciationSchedule => _assetDepreciationScheduleCommandRepository.Value;
        public IAssetComponentCommandRepository AssetComponent => _assetComponent.Value;
        public IAssetMaintenanceCommandRepository AssetMaintenance => _assetMaintenance.Value;



        // Inventory
        public IItemGroupCommandRepository ItemGroup => _itemGroupCommandRepository.Value;
        public IItemCommandRepository Item => _itemCommandRepository.Value;
        public IItemVariantAttributeCommandRepository ItemVariantAttribute => _itemVariantAttribute.Value;
        public IUnitOfMeasureConversionCommandRepository UnitOfMeasureConversion => _unitOfMeasureConversionCommandRepository.Value;
        public IColorCommandRepository Color => _colorCommandRepository.Value;
        public ISizeCommandRepository Size => _sizeCommandRepository.Value;
        public IAssetTransactionCommandRepository AssetTransaction => _assetTransactionCommandRepository.Value;
        public IAssetCategoryCommandRepository AssetCategory => _assetCategoryCommandRepository.Value;
        public IAssetAccountingEventCommandRepository AssetAccountingEvent => _assetAccountingEventCommandRepository.Value;
        public IAssetAccountingEventAccountCommandRepository AssetAccountingEventAccount => _assetAccountingEventAccountCommandRepository.Value;
        public IInventoryBalanceCommandRepository InventoryBalance => _inventoryBalanceCommandRepository.Value;
        public IGoodsReceiptCommandRepository GoodsReceipt => _goodsReceiptCommandRepository.Value;
        public IInventoryCostLayerCommandRepository InventoryCostLayer => _inventoryCostLayerCommandRepository.Value;
        public IWarehouseLocationCommandRepository WarehouseLocation => _warehouseLocationCommandRepository.Value;
        public IInventoryOpeningBalanceCommandRepository InventoryOpeningBalance => _inventoryOpeningBalance.Value;
        public IInventoryLedgerCommandRepository InventoryLedger => _inventoryLedgerCommandRepository.Value;
        public IItemAttributeCommandRepository ItemAttribute => _itemAttribute.Value;
        public IGoodsIssueCommandRepository GoodsIssue => _GoodsIssue.Value;
        public IGoodsTransferOutCommandRepository GoodsTransferOut => _goodsTransferOut.Value;
        public IGoodsTransferInCommandRepository GoodsTransferIn => _goodsTransferIn.Value;
        public IBatchCommandRepository Batch => _Batch.Value;
        public IInventoryAdjustmentCommandRepository InventoryAdjustment => _inventoryAdjustment.Value;
        public IInventoryScrapCommandRepository InventoryScrap => _InventoryScrap.Value;
        public IScrapReasonCommandRepository ScrapReason => _ScrapReason.Value;


        //IInventoryScrapCommandRepository
        //IScrapReasonCommandRepository
        //Setup  
        public ISalesPersonCommandRepository SalesPerson => _iSalesPersonCommandRepository.Value;
        public IModuleSettingCommandRepository ModuleSetting => _moduleSettingCommandRepository.Value;

        //MenuManagement
        public IUser_CodeCommandRepository User_CodeCommandRepository => _User_CodeCommandRepository.Value;
        public IInspectionStandardCommandRepository InspectionStandard => _inspectionStandardCommandRepository.Value;
        public IChecklistTemplateCommandRepository ChecklistTemplate => _checklistTemplateCommandRepository.Value;

        // Inspection
        public IInspectorCommandRepository Inspector => _inspector.Value;
        public ICertificateCommandRepository Certificate => _certificate.Value;
        public IAccreditationBodyCommandRepository AccreditationBody => _accreditationBody.Value;
        public IChecklistCommandRepository Checklist => _checklist.Value;
        public IInspectorCompetencyCommandRepository InspectorCompetency => _inspectorCompetency.Value;

        public ISalesOrderCommandRepository SalesOrder => _salesOrderCommandRepository.Value;
        public ISalesOrderLinesCommandRepository SalesOrderLines => _salesOrderLinesCommandRepository.Value;

        // DMS
        public IFolderCommandRepository Folder => _folder.Value;
        public IFolderPermissionCommandRepository FolderPermission => _folderPermission.Value;

        public IDocumentShareCommandRepository IDocumentShare => _documentShare.Value;
        public ITagCommandRepository Tag => _tag.Value;
        public IDocumentCommandRepository Document => _document.Value;
        public IDocumentEntityLinkCommandRepository DocumentEntityLink => _documentEntityLink.Value;
        public IShareAccessLogCommandRepository ShareAccessLog => _ShareAccessLog.Value;
        public IDocumentCommentCommandRepository DocumentComment => _documentComment.Value;

        public ILedgerCommandRepository Ledger => _ledger.Value;
        public ILedgerLineCommandRepository LedgerLine => _ledgerLine.Value;
        public IAccountBalanceCommandRepository AccountBalance => _accountBalanceCommandRepository.Value;
        public ILanguageCommandRepository Languages => _Languages.Value;


        // Contracting
        public IBOQCommandRepository BOQ => _bOQ.Value;
        public IWBSCommandRepository WBS => _WBS.Value;
        public IDivisionCommandRepository Division => _Division.Value;
        public ICostCodeCommandRepository CostCode => _CostCode.Value;
        public IActivityCommandRepository Activity => _Activity.Value;
        public ISubcontractBOQCommandRepository SubcontractBOQ => _subcontractBOQ.Value;


        public ICommitmentCommandRepository Commitment => _commitmentCommandRepository.Value;

        // Manufacturing
        public IProductionOrderCommandRepository ProductionOrder => _productionOrderCommandRepository.Value;

        // Asset Location
        public IAssetLocationCommandRepository AssetLocation => _assetLocationCommandRepository.Value;

    }
}