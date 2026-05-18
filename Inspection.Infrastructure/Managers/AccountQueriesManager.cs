using Inspection.Application.Contracts.Managers;
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
using Inspection.Infrastructure.DataContext;
using Inspection.Infrastructure.QueryObjects.Contracting.Setup.Activitys;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountBalances;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.BankAccounts;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.Banks;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.Branches;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.Cashing;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.ChartOfAccounts;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.CostUnits;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.FiscalYears;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSystem;
using Inspection.Infrastructure.Repositories.Query.Accounting.AccountSystem.PaymetTerms;
using Inspection.Infrastructure.Repositories.Query.Accounting.AR.MasterData;
using Inspection.Infrastructure.Repositories.Query.Accounting.AR.PurchaseReturns;
using Inspection.Infrastructure.Repositories.Query.Accounting.AR.SalesInvoices;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetAccountingEvents;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetCustodies;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetMaintenances;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.AssetTransactions;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetCategories;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetComponents;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetGroups;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetLocations;
using Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.FixedAssets;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashPayments;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashReceipts;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashTransfers;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CreditNotes;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments.DebitNotes;
using Inspection.Infrastructure.Repositories.Query.Accounting.Payments.JournalEntrys;
using Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.SupplierGroups;
using Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.Suppliers;
using Inspection.Infrastructure.Repositories.Query.Accounting.PR.PurchaseInvoices;
using Inspection.Infrastructure.Repositories.Query.ApprovalManagement;
using Inspection.Infrastructure.Repositories.Query.Contracting.CostCodes;
using Inspection.Infrastructure.Repositories.Query.Contracting.Divisions;
using Inspection.Infrastructure.Repositories.Query.Contracting.Setup.BOQs;
using Inspection.Infrastructure.Repositories.Query.Contracting.Setup.SubcontractBOQs;
using Inspection.Infrastructure.Repositories.Query.Contracting.WBSs;
using Inspection.Infrastructure.Repositories.Query.DMS.DocumentComments;
using Inspection.Infrastructure.Repositories.Query.DMS.Documents;
using Inspection.Infrastructure.Repositories.Query.DMS.DocumentShares;
using Inspection.Infrastructure.Repositories.Query.DMS.FolderPermissions;
using Inspection.Infrastructure.Repositories.Query.DMS.Folders;
using Inspection.Infrastructure.Repositories.Query.DMS.ShareAccessLogs;
using Inspection.Infrastructure.Repositories.Query.DMS.Tags;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.CompanyEquipments;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentAccessories;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentCategorys;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentInspections;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.Equipments;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentSoftwares;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentTypes;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.InspectionChecklistMoreInformationTemplateTemplates;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.MaintenanceReports;
using Inspection.Infrastructure.Repositories.Query.EquipmentManagement.MaintenanceSchedules;
using Inspection.Infrastructure.Repositories.Query.HRManagement.ApplicantCVs;
using Inspection.Infrastructure.Repositories.Query.HRManagement.Departments;
using Inspection.Infrastructure.Repositories.Query.HRManagement.Employees;
using Inspection.Infrastructure.Repositories.Query.HRManagement.InterviewEvaluations;
using Inspection.Infrastructure.Repositories.Query.HRManagement.JobAdvertisements;
using Inspection.Infrastructure.Repositories.Query.HRManagement.JobOfferNegotiations;
using Inspection.Infrastructure.Repositories.Query.HRManagement.JobRequests;
using Inspection.Infrastructure.Repositories.Query.HRManagement.JobTitles;
using Inspection.Infrastructure.Repositories.Query.Inspection;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.AccreditationBodies;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.Certificates;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.Checklists;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.ChecklistTemplates;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.InspectionStandards;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.InspectorCompetencies;
using Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.Inspectors;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.CustomerLocations;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.CustomerProjects;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionCertificates;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionChecklistsQueryRepository;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionMethods;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionReports;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequestDetailF;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequests;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionTypes;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectorCategory;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.ServicesItemsF;
using Inspection.Infrastructure.Repositories.Query.InspectionManagement.ServiceTypes;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Batchs;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Brands;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Colors;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Items;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Models;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Sizes;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.UnitOfMeasure;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Infrastructure.Repositories.Query.Inventory.ItemAttributes;
using Inspection.Infrastructure.Repositories.Query.Inventory.ItemGroups;
using Inspection.Infrastructure.Repositories.Query.Inventory.System;
using Inspection.Infrastructure.Repositories.Query.Inventory.System.InventoryBalances;
using Inspection.Infrastructure.Repositories.Query.Inventory.System.InventoryLedgers;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsIssues;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsTransferIns;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.InventoryAdjustments;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.InventoryScraps;
using Inspection.Infrastructure.Repositories.Query.Inventory.Transaction.ScrapReasons;
using Inspection.Infrastructure.Repositories.Query.LocalizationManagment;
using Inspection.Infrastructure.Repositories.Query.Manufacturing.Setup.ProductionOrders;
using Inspection.Infrastructure.Repositories.Query.MenuManagement;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.AreaF;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.BranchF;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.Programs;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.Screen_permissions;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.SeriesF;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.User_Codes;
using Inspection.Infrastructure.Repositories.Query.MenuManagement.User_Groups;
using Inspection.Infrastructure.Repositories.Query.SalesManagement;
using Inspection.Infrastructure.Repositories.Query.SalesManagment.sales;
using Inspection.Infrastructure.Repositories.Query.SalesManagment.Setup;
using Inspection.Infrastructure.Repositories.Query.SalesManagment.Transactions.DeliveryNotes;
using Inspection.Infrastructure.Repositories.Query.SalesManagment.Transactions.SalesQuotations;
using Inspection.Infrastructure.Repositories.Query.SalesManagment.Transactions.SalesReturns;
using Inspection.Infrastructure.Repositories.Query.Sample.CurrencyExchangeRate;
using Inspection.Infrastructure.Repositories.Query.Setting.ModuleSettings;
using Inspection.Infrastructure.Repositories.Query.System;
using Inspection.Infrastructure.Repositories.Query.System.Languages;
using Inspection.Infrastructure.Repositories.Query.System.TaxCategorys;
using Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Cities;
using Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Companies;
using Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Countris;
using Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Currencies;
using Inspection.Infrastructure.Repositories.Query.SystemConfigurations.CurrencyExchangeRateMasters;
using Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Operations;
using Inspection.Infrastructure.Repositories.Query.TestTableDetails;
using Inspection.Infrastructure.Repositories.Query.TestTableMasters;
using Inspection.Infrastructure.Repositories.Query.TestTableSubDetails;
using Inspection.Infrastructure.Repositories.Query.UserNotificationManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Managers
{
    public sealed class AccountQueriesManager : IAccountsQueriesManager
    {
        private readonly ISqlQueryBuilder _queryBuilder;
        private readonly DapperDbContext _dapper;
        private readonly DbInspectionContext _context;
        private readonly ITenantResolver _tenantResolver;
        private readonly IExceptionManager _exceptionManager;

        //Sample
        private readonly Lazy<ISCurrencyExchangeRateQueryRepository> _scurrencyExchangeRateQueryRepository;
        //Sample
        private readonly Lazy<ILedgerQueryRepository> _ledgerQuery;
        private readonly Lazy<ILedgerLineQueryRepository> _ledgerLineQuery;

        private readonly Lazy<IInspectionRequestQueryRepository> _inspectionRequset;
        private readonly Lazy<IInspectionDashboardQueryRepository> _inspectionDashboard;
        private readonly Lazy<IInspectionReportQueryRepository> _inspectionReport;
        private readonly Lazy<IServiceTypeQueryRepository> _serviceType;
        private readonly Lazy<IEquipmentQueryRepository> _equipmentQuery;
        private readonly Lazy<IEquipmentInspectionQueryRepository> _equipmentInspectionQuery;
        private readonly Lazy<IMaintenanceReportQueryRepository> _maintenanceReportQuery;
        private readonly Lazy<IMaintenanceScheduleQueryRepository> _maintenanceScheduleQuery;
        private readonly Lazy<ILocalizationQueryRepository> _localizationQuery;
        private readonly Lazy<IMenuQueryRepository> _menuQuery;
        private readonly Lazy<IApprovalQueryRepository> _approvalQuery;
        private readonly Lazy<IUserApprovalQueryRepository> _userApprovalQuery;
        private readonly Lazy<IApprovalDelegationQueryRepository> _approvalDelegationQuery;
        private readonly Lazy<IUserNotificationsQueryRepository> _userNotificationsQuery;
        private readonly Lazy<ISeriesQueryRepository> _series;
        private readonly Lazy<ISeriesDetailsQueryRepository> _seriesDetails;
        private readonly Lazy<ICustomerLocationQueryRepository> _CustomerLocation;
        private readonly Lazy<ICustomerProjectQueryRepository> _CustomerProject;
        private readonly Lazy<IServiceItemQueryRepository> _serviceItem;

        private readonly Lazy<ISalesOrderQueryRepository> _salesOrder;
        private readonly Lazy<ISalesOrderLineQueryRepository> _salesOrderLine;

        private readonly Lazy<ICustomerBranchQueryRepository> _customerBranch;
        private readonly Lazy<IAreaQueryRepository> _area;
        private readonly Lazy<IInspectionMethodQueryRepository> _inspectionMethod;
        private readonly Lazy<IScreenCodeQueryRepository> _screenCode;
        private readonly Lazy<IInspectorCategoryQueryRepository> _inspectorCategory;
        private readonly Lazy<IEquipmentTypeQueryRepository> _equipmentTypeQuery;
        private readonly Lazy<IJobOrderQueryRepository> _jobOrderQueryRepository;
        private readonly Lazy<IJobOrderDetailQueryRepository> _jobOrderDetailQueryRepository;
        private readonly Lazy<IInspectionCertificateQueryRepository> _inspectionCertificateRepository;
        private readonly Lazy<IEquipmentsMoreInformationQueryRepository> _equipmentsMoreInformationQueryRepository;
        private readonly Lazy<IInspectionRequestLinesQueryRepository> _inspectionRequestLinesRepository;
        private readonly Lazy<IInspectionRequestDetailSubcontractorQueryRepository> _inspectionRequestDetailSubcontractorRepository;
        private readonly Lazy<IApplicantCVQueryRepository> _applicantCVQueryRepository;
        private readonly Lazy<IDepartmentQueryRepository> _departmentQueryRepository;
        private readonly Lazy<IEmployeeQueryRepository> _employeeQueryRepository;
        private readonly Lazy<ITestTableMasterQueryRepository> _testTableMasterQueryRepository;
        private readonly Lazy<ITestTableDetailQueryRepository> _testTableDetailsQueryRepository;
        private readonly Lazy<ITestTableSubDetailsQueryRepository> _testTableSubDetailsQueryRepository;
        private readonly Lazy<ICompanyEquipmentQueryRepository> _companyEquipmentsQueryRepository;
        private readonly Lazy<IEquipmentAccessoryQueryRepository> _EquipmentAccessoriesQueryRepository;
        private readonly Lazy<IEquipmentSoftwareQueryRepository> _EquipmentSoftwareQueryRepository;
        private readonly Lazy<IEquipmentCalibrationHistoryQueryRepository> _EquipmentCalibrationHistoryQueryRepository;
        private readonly Lazy<IEquipmentPreventiveMaintenanceQueryRepository> _EquipmentPreventiveMaintenanceQueryRepository;
        private readonly Lazy<IEquipmentMaintenanceAndRepairRecordQueryRepository> _EquipmentMaintenanceAndRepairRecordQueryRepository;
        private readonly Lazy<IJobRequestQueryRepository> _jobRequestQueryRepository;
        private readonly Lazy<IJobTitleQueryRepository> _jobTitleQueryRepository;
        private readonly Lazy<IInterviewEvaluationQueryRepository> _interviewEvaluationQueryRepository;
        private readonly Lazy<IJobAdvertisementQueryRepository> _jobAdvertisementQueryRepository;
        private readonly Lazy<IJobOfferNegotiationQueryRepository> _jobOfferNegotiationQueryRepository;
        private readonly Lazy<IEquipmentsMoreInformationDetailQueryRepository> _EquipmentsMoreInformationDetailQueryRepository;
        private readonly Lazy<IEquipmentCategoryQueryRepository> _EquipmentCategoryQueryRepository;
        private readonly Lazy<IEquipmentsMoreInformationTemplateQueryRepository> _EquipmentsMoreInformationTemplateQueryRepository;
        private readonly Lazy<IEquipmentsMoreInformationTemplateDetailQueryRepository> _EquipmentsMoreInformationTemplateDetailQueryRepository;
        private readonly Lazy<IInspectionChecklistsQueryRepository> _InspectionChecklistsQueryRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationQR> _InspectionChecklistMoreInformationQueryRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationTemplateQueryRepository> _InspectionChecklistMoreInformationTemplateQueryRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationDetailQR> _InspectionChecklistMoreInformationDetailQueryRepository;
        private readonly Lazy<IInspectionChecklistMoreInformationTemplateDetailQR> _InspectionChecklistMoreInformationTemplateDetailQueryRepository;
        private readonly Lazy<IInspectionTypeQueryRepository> _inspectionTypes;
        private readonly Lazy<IUser_GroupQueryRepository> _User_Groups;
        private readonly Lazy<IScreen_permissionQueryRepository> _Screen_permissions;



        //Contracting

        private readonly Lazy<IActivityQueryRepository> _Activity;
        private readonly Lazy<ICostCodeQueryRepository> _CostCode;
        private readonly Lazy<IDivisionQueryRepository> _Division;
        private readonly Lazy<IWBSQueryRepository> _WBS;




        // Sales Management
        private readonly Lazy<ISalesQuotationQueryRepository> _salesQuotation;
        private readonly Lazy<ISalesReturnQueryRepository> _SalesReturn;

        //SystemConfigurations
        private readonly Lazy<ICompanyQueryRepository> _companyQueryRepository;
        private readonly Lazy<ICurrencyQueryRepository> _currencyQueryRepository;
        private readonly Lazy<ICountriesQueryRepository> _countriesQueryRepository;
        private readonly Lazy<ICityQueryRepository> _cityQueryRepository;
        private readonly Lazy<IOperationQueryRepository> _operationQueryRepository;

        //System
        private readonly Lazy<ITaxTypeQueryRepository> _taxTypeQueryRepository;
        private readonly Lazy<ITaxCategoryQueryRepository> _taxCategoryQueryRepository;
        private readonly Lazy<IDefaultAccountTypeQueryRepository> _defaultAccountTypeQueryRepository;
        private readonly Lazy<IDefaultAccountGroupQueryRepository> _defaultAccountGroupQueryRepository;
        private readonly Lazy<IDefaultAccountAssignmentQueryRepository> _defaultAccountAssignment;
        private readonly Lazy<IPaymentTermQueryRepository> _paymentTerm;
        private readonly Lazy<ILanguageQueryRepository> _Language;
        //Accounting
        private readonly Lazy<ICostCenterQueryRepository> _costCenterQueryRepository;
        private readonly Lazy<ICostUnitQueryRepository> _costUnitQueryRepository;
        private readonly Lazy<IBankAccountQueryRepository> _bankAccountQueryRepository;
        private readonly Lazy<IBankQueryRepository> _bankQueryRepository;
        private readonly Lazy<IFiscalYearQueryRepository> _fiscalYearQueryRepository;
        private readonly Lazy<ICurrencyExchangeRateQueryRepository> _currencyExchangeRateQueryRepository;
        private readonly Lazy<IAccountingPeriodQueryRepository> _accountingPeriodQueryRepository;
        private readonly Lazy<IAcountTypeQueryRepository> _accountTypeQueryRepository;
        private readonly Lazy<IChartOfAccountQueryRepository> _chartOfAccountQueryRepository;
        private readonly Lazy<ISupplierQueryRepository> _supplierQueryRepository;
        private readonly Lazy<ICustomerGroupQueryRepository> _customerGroupQueryRepository;
        private readonly Lazy<ICustomerQueryRepository> _customerQueryRepository;
        private readonly Lazy<ISupplierGroupQueryRepository> _supplierGroup;
        private readonly Lazy<ICashQueryRepository> _cashQueryRepository;
        private readonly Lazy<IBranchQueryRepository> _branchQueryRepository;
        private readonly Lazy<IWarehouseQueryRepository> _warehouseQueryRepository;
        private readonly Lazy<IBrandQueryRepository> _brandQueryRepository;
        private readonly Lazy<IModelQueryRepository> _modelQueryRepository;
        private readonly Lazy<IUnitOfMeasureQueryRepository> _unitOfMeasureQueryRepository;
        private readonly Lazy<IUnitOfMeasureConversionQueryRepository> _unitOfMeasureConversionQueryRepository;
        private readonly Lazy<ISizeQueryRepository> _SizeQueryRepository;
        private readonly Lazy<IColorQueryRepository> _ColorQueryRepository;
        private readonly Lazy<IAssetTransactionQueryRepository> _AssetTransaction;
        private readonly Lazy<IAssetCategoryQueryRepository> _AssetCategory;
        private readonly Lazy<IJournalEntryQueryRepository> _journalEntry;
        private readonly Lazy<IJournalEntryTemplateQueryRepository> _journalEntryTemplate;
        private readonly Lazy<IModeOfPaymentQueryRepository> _modeOfPayment;
        private readonly Lazy<ICashReceiptQueryRepository> _cashReceipt;
        private readonly Lazy<ICashPaymentQueryRepository> _cashPayment;
        private readonly Lazy<ISalesInvoiceQueryRepository> _salesInvoice;
        private readonly Lazy<IPurchaseInvoiceQueryRepository> _PurchaseInvoice;
        private readonly Lazy<IDeliveryNoteQueryRepository> _DeliveryNote;
        private readonly Lazy<IGoodsIssueQueryRepository> _GoodsIssue;
        private readonly Lazy<IPurchaseReturnQueryRepository> _PurchaseReturn;
        private readonly Lazy<ICreditNoteQueryRepository> _creditNote;
        private readonly Lazy<IInventoryScrapQueryRepository> _InventoryScrap;
        private readonly Lazy<IScrapReasonQueryRepository> _ScrapReason;

        private readonly Lazy<IDebitNoteQueryRepository> _debitNote;
        private readonly Lazy<ICashTransferQueryRepository> _cashTransfer;

        // FixedAsset
        private readonly Lazy<IFixedAssetQueryRepository> _fixedAssetQueryRepository;
        private readonly Lazy<IAssetAccountingEventQueryRepository> _assetAccountingEventQueryRepository;
        private readonly Lazy<IAssetAccountingEventAccountQueryRepository> _assetAccountingEventAccountQueryRepository;
        private readonly Lazy<IAssetDepreciationScheduleQueryRepository> _assetDepreciationScheduleQueryRepository;
        private readonly Lazy<IAssetGroupQueryRepository> _assetGroup;
        private readonly Lazy<IAssetCustodyQueryRepository> _assetCustody;
        private readonly Lazy<IAssetComponentQueryRepository> _assetComponent;
        private readonly Lazy<IAssetMaintenanceQueryRepository> _assetMaintenance;

        // Inventory 
        private readonly Lazy<IItemGroupQueryRepository> _itemGroup;
        private readonly Lazy<IItemQueryRepository> _item;
        private readonly Lazy<IItemVariantAttributeQueryRepository> _itemVariantAttribute;
        private readonly Lazy<IInventoryBalanceQueryRepository> _inventoryBalanceQueryRepository;
        private readonly Lazy<IGoodsReceiptQueryRepository> _goodsReceiptQueryRepository;
        private readonly Lazy<IInventoryCostLayerQueryRepository> _inventoryCostLayerQueryRepository;
        private readonly Lazy<IWarehouseLocationQueryRepository> _warehouseLocationQueryRepository;
        private readonly Lazy<IInventoryOpeningBalanceQueryRepository> _inventoryOpeningBalance;
        private readonly Lazy<IInventoryLedgerQueryRepository> _inventoryLedgerQueryRepository;

        private readonly Lazy<IAccountBalanceQueryRepository> _accountBalanceQueryRepository;

        private readonly Lazy<IItemAttributeQueryRepository> _itemAttribute;

        private readonly Lazy<ISalesPersonQueryRepository> _iSalesPersonQueryRepository;
        private readonly Lazy<IModuleSettingQueryRepository> _moduleSettingRepository;
        private readonly Lazy<IGoodsTransferOutQueryRepository> _goodsTransferOut;
        private readonly Lazy<IGoodsTransferInQueryRepository> _goodsTransferIn;
        private readonly Lazy<IBatchQueryRepository> _Batch;
        private readonly Lazy<IInventoryAdjustmentQueryRepository> _inventoryAdjustment;

        //MenuManagement
        private readonly Lazy<IProgramQueryRepository> _programQueryRepository;
        private readonly Lazy<IUser_CodeQueryRepository> _User_CodeQueryRepository;
        private readonly Lazy<IInspectionStandardQueryRepository> _inspectionStandardQueryRepository;
        private readonly Lazy<IChecklistTemplateQueryRepository> _checklistTemplatesQueryRepository;

        // Inspection
        private readonly Lazy<IInspectorQueryRepository> _inspector;
        private readonly Lazy<ICertificateQueryRepository> _certificate;
        private readonly Lazy<IChecklistQueryRepository> _checklists;
        private readonly Lazy<IInspectorCompetencyQueryRepository> _inspectorCompetency;
        private readonly Lazy<IAccreditationBodyQueryRepository> _accreditationBody;
        private readonly Lazy<ISalesQuotationDashboardQueryRepository> _salesQuotationDashboardQueryRepository;
        private readonly Lazy<IJobOrderDashboardQueryRepository> _jobOrderDashboardQueryRepository;

        // DMS
        private readonly Lazy<IFolderQueryRepository> _folder;
        private readonly Lazy<IFolderPermissionQueryRepository> _folderPermission;
        private readonly Lazy<IDocumentShareQueryRepository> _documentShare;
        private readonly Lazy<ITagQueryRepository> _tag;
        private readonly Lazy<IShareAccessLogQueryRepository> _ShareAccessLog;
        private readonly Lazy<IDocumentQueryRepository> _document;
        private readonly Lazy<IDocumentCommentQueryRepository> _documentComment;

        // Commitment
        private readonly Lazy<ICommitmentQueryRepository> _commitmentQueryRepository;
        // Contracting
        private readonly Lazy<IBOQQueryRepository> _bOQ;
        private readonly Lazy<ISubcontractBOQQueryRepository> _subcontractBOQ;

        // Manufacturing
        private readonly Lazy<IProductionOrderQueryRepository> _productionOrderQueryRepository;

        // Asset Location
        private readonly Lazy<IAssetLocationQueryRepository> _assetLocationQueryRepository;


        public AccountQueriesManager(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbInspectionContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager)
        {
            _queryBuilder = queryBuilder;
            _dapper = dapper;
            _context = context;
            _tenantResolver = tenantResolver;
            _exceptionManager = exceptionManager;

            //Sample
            _scurrencyExchangeRateQueryRepository = new Lazy<ISCurrencyExchangeRateQueryRepository>(new SCurrencyExchangeRateQueryRepository(queryBuilder, dapper, context, tenantResolver, exceptionManager));
            //Sample

            _ledgerQuery = new Lazy<ILedgerQueryRepository>(new LedgerQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _salesQuotationDashboardQueryRepository = new Lazy<ISalesQuotationDashboardQueryRepository>(new SalesQuotationDashboardQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionRequset = new Lazy<IInspectionRequestQueryRepository>(new InspectionRequestQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionDashboard = new Lazy<IInspectionDashboardQueryRepository>(new InspectionDashboardQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionReport = new Lazy<IInspectionReportQueryRepository>(new InspectionReportQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _serviceType = new Lazy<IServiceTypeQueryRepository>(new ServiceTypeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _equipmentQuery = new Lazy<IEquipmentQueryRepository>(new EquipmentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _equipmentInspectionQuery = new Lazy<IEquipmentInspectionQueryRepository>(new EquipmentInspectionQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _maintenanceReportQuery = new Lazy<IMaintenanceReportQueryRepository>(new MaintenanceReportQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _maintenanceScheduleQuery = new Lazy<IMaintenanceScheduleQueryRepository>(new MaintenanceScheduleQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _localizationQuery = new Lazy<ILocalizationQueryRepository>(new LocalizationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _menuQuery = new Lazy<IMenuQueryRepository>(new MenuQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _approvalQuery = new Lazy<IApprovalQueryRepository>(new ApprovalQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _userApprovalQuery = new Lazy<IUserApprovalQueryRepository>(new UserApprovalQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _approvalDelegationQuery = new Lazy<IApprovalDelegationQueryRepository>(new ApprovalDelegationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _userNotificationsQuery = new Lazy<IUserNotificationsQueryRepository>(new UserNotificationsQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _series = new Lazy<ISeriesQueryRepository>(new SeriesQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _CustomerLocation = new Lazy<ICustomerLocationQueryRepository>(new CustomerLocationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _CustomerProject = new Lazy<ICustomerProjectQueryRepository>(new CustomerProjectQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _serviceItem = new Lazy<IServiceItemQueryRepository>(new ServiceItemQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            _salesOrder = new Lazy<ISalesOrderQueryRepository>(new SalesOrderQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            _customerBranch = new Lazy<ICustomerBranchQueryRepository>(new CustomerBranchQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _area = new Lazy<IAreaQueryRepository>(new AreaQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionMethod = new Lazy<IInspectionMethodQueryRepository>(new InspectionMethodQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _screenCode = new Lazy<IScreenCodeQueryRepository>(new ScreenCodeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectorCategory = new Lazy<IInspectorCategoryQueryRepository>(new InspectorCategoryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _equipmentTypeQuery = new Lazy<IEquipmentTypeQueryRepository>(new EquipmentTypeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobOrderQueryRepository = new Lazy<IJobOrderQueryRepository>(new JobOrderQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobOrderDetailQueryRepository = new Lazy<IJobOrderDetailQueryRepository>(new JobOrderDetailQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionCertificateRepository = new Lazy<IInspectionCertificateQueryRepository>(new InspectionCertificateQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _equipmentsMoreInformationQueryRepository = new Lazy<IEquipmentsMoreInformationQueryRepository>(new EquipmentsMoreInformationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionRequestLinesRepository = new Lazy<IInspectionRequestLinesQueryRepository>(new InspectionRequestLinesQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionRequestDetailSubcontractorRepository = new Lazy<IInspectionRequestDetailSubcontractorQueryRepository>(new InspectionRequestDetailSubcontractorQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _applicantCVQueryRepository = new Lazy<IApplicantCVQueryRepository>(new ApplicantCVQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _departmentQueryRepository = new Lazy<IDepartmentQueryRepository>(new DepartmentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _employeeQueryRepository = new Lazy<IEmployeeQueryRepository>(new EmployeeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _testTableMasterQueryRepository = new Lazy<ITestTableMasterQueryRepository>(new TestTableMasterQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _testTableDetailsQueryRepository = new Lazy<ITestTableDetailQueryRepository>(new TestTableDetailsQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _testTableSubDetailsQueryRepository = new Lazy<ITestTableSubDetailsQueryRepository>(new TestTableSubDetailsQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _companyEquipmentsQueryRepository = new Lazy<ICompanyEquipmentQueryRepository>(new CompanyEquipmentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentAccessoriesQueryRepository = new Lazy<IEquipmentAccessoryQueryRepository>(new EquipmentAccessoriesQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentSoftwareQueryRepository = new Lazy<IEquipmentSoftwareQueryRepository>(new EquipmentSoftwareQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentCalibrationHistoryQueryRepository = new Lazy<IEquipmentCalibrationHistoryQueryRepository>(new EquipmentCalibrationHistoryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentPreventiveMaintenanceQueryRepository = new Lazy<IEquipmentPreventiveMaintenanceQueryRepository>(new EquipmentPreventiveMaintenanceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentMaintenanceAndRepairRecordQueryRepository = new Lazy<IEquipmentMaintenanceAndRepairRecordQueryRepository>(new EquipmentMaintenanceAndRepairRecordQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobRequestQueryRepository = new Lazy<IJobRequestQueryRepository>(new JobRequestQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobTitleQueryRepository = new Lazy<IJobTitleQueryRepository>(new jobTitleQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _interviewEvaluationQueryRepository = new Lazy<IInterviewEvaluationQueryRepository>(new InterviewEvaluationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobAdvertisementQueryRepository = new Lazy<IJobAdvertisementQueryRepository>(new JobAdvertisementQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobOfferNegotiationQueryRepository = new Lazy<IJobOfferNegotiationQueryRepository>(new JobOfferNegotiationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentsMoreInformationDetailQueryRepository = new Lazy<IEquipmentsMoreInformationDetailQueryRepository>(new EquipmentsMoreInformationDetailQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentCategoryQueryRepository = new Lazy<IEquipmentCategoryQueryRepository>(new EquipmentCategoryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentsMoreInformationTemplateQueryRepository = new Lazy<IEquipmentsMoreInformationTemplateQueryRepository>(new EquipmentsMoreInformationTemplateQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _EquipmentsMoreInformationTemplateDetailQueryRepository = new Lazy<IEquipmentsMoreInformationTemplateDetailQueryRepository>(new EquipmentsMoreInformationTemplateDetailQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _InspectionChecklistsQueryRepository = new Lazy<IInspectionChecklistsQueryRepository>(new InspectionChecklistsQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _InspectionChecklistMoreInformationQueryRepository = new Lazy<IInspectionChecklistMoreInformationQR>(new InspectionChecklistMoreInformationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _InspectionChecklistMoreInformationDetailQueryRepository = new Lazy<IInspectionChecklistMoreInformationDetailQR>(new InspectionChecklistMoreInformationDetailQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _InspectionChecklistMoreInformationTemplateQueryRepository = new Lazy<IInspectionChecklistMoreInformationTemplateQueryRepository>(new InspectionChecklistMoreInformationTemplateQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _InspectionChecklistMoreInformationTemplateDetailQueryRepository = new Lazy<IInspectionChecklistMoreInformationTemplateDetailQR>(new InspectionChecklistMoreInformationTemplateDetailQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectionTypes = new Lazy<IInspectionTypeQueryRepository>(new InspectionTypeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _User_Groups = new Lazy<IUser_GroupQueryRepository>(new User_GroupQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _Screen_permissions = new Lazy<IScreen_permissionQueryRepository>(new Screen_permissionQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            // Sales Management
            _salesQuotation = new Lazy<ISalesQuotationQueryRepository>(new SalesQuotationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _SalesReturn = new Lazy<ISalesReturnQueryRepository>(new SalesReturnQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            //SystemConfigurations
            _companyQueryRepository = new Lazy<ICompanyQueryRepository>(new CompanyQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _currencyQueryRepository = new Lazy<ICurrencyQueryRepository>(new CurrencyQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _countriesQueryRepository = new Lazy<ICountriesQueryRepository>(new CountryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _cityQueryRepository = new Lazy<ICityQueryRepository>(new CityQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _currencyExchangeRateQueryRepository = new Lazy<ICurrencyExchangeRateQueryRepository>(new CurrencyExchangeRateMasterQueries(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _operationQueryRepository = new Lazy<IOperationQueryRepository>(new OperationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            //system
            //_taxeQueryRepository = new Lazy<ITaxeQueryRepository>(new TaxeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _defaultAccountTypeQueryRepository = new Lazy<IDefaultAccountTypeQueryRepository>(new DefaultAccountTypeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _defaultAccountGroupQueryRepository = new Lazy<IDefaultAccountGroupQueryRepository>(new DefaultAccountGroupQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _defaultAccountAssignment = new Lazy<IDefaultAccountAssignmentQueryRepository>(new DefaultAccountAssignmentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _paymentTerm = new Lazy<IPaymentTermQueryRepository>(new PaymentTermQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _Language = new Lazy<ILanguageQueryRepository>(new LanguageQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            _bankAccountQueryRepository = new Lazy<IBankAccountQueryRepository>(new BankAccountQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _bankQueryRepository = new Lazy<IBankQueryRepository>(new BankQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            //Accounting
            _costUnitQueryRepository = new Lazy<ICostUnitQueryRepository>(new CostUnitQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _fiscalYearQueryRepository = new Lazy<IFiscalYearQueryRepository>(new FiscalYearQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _accountingPeriodQueryRepository = new Lazy<IAccountingPeriodQueryRepository>(new AccountingPeriodQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _accountTypeQueryRepository = new Lazy<IAcountTypeQueryRepository>(new AcountTypeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _chartOfAccountQueryRepository = new Lazy<IChartOfAccountQueryRepository>(new ChartOfAccountQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _customerGroupQueryRepository = new Lazy<ICustomerGroupQueryRepository>(new CustomerGroupQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _supplierGroup = new Lazy<ISupplierGroupQueryRepository>(new SupplierGroupQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _supplierQueryRepository = new Lazy<ISupplierQueryRepository>(new SupplierQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _customerQueryRepository = new Lazy<ICustomerQueryRepository>(new CustomerQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _cashQueryRepository = new Lazy<ICashQueryRepository>(new CashQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _costCenterQueryRepository = new Lazy<ICostCenterQueryRepository>(new CostCenterQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            _branchQueryRepository = new Lazy<IBranchQueryRepository>(new BranchQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _warehouseQueryRepository = new Lazy<IWarehouseQueryRepository>(new WarehouseQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _modelQueryRepository = new Lazy<IModelQueryRepository>(new ModelQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _brandQueryRepository = new Lazy<IBrandQueryRepository>(new BrandQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _unitOfMeasureQueryRepository = new Lazy<IUnitOfMeasureQueryRepository>(new UnitOfMeasureQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _unitOfMeasureConversionQueryRepository = new Lazy<IUnitOfMeasureConversionQueryRepository>(new UnitOfMeasureConversionQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _taxCategoryQueryRepository = new Lazy<ITaxCategoryQueryRepository>(new TaxCategoryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _taxTypeQueryRepository = new Lazy<ITaxTypeQueryRepository>(new TaxTypeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            _ColorQueryRepository = new Lazy<IColorQueryRepository>(new ColorQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _SizeQueryRepository = new Lazy<ISizeQueryRepository>(new SizeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _AssetTransaction = new Lazy<IAssetTransactionQueryRepository>(new AssetTransactionQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _AssetCategory = new Lazy<IAssetCategoryQueryRepository>(new AssetCategoryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _journalEntryTemplate = new Lazy<IJournalEntryTemplateQueryRepository>(new JournalEntryTemplateQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _modeOfPayment = new Lazy<IModeOfPaymentQueryRepository>(new ModeOfPaymentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _cashReceipt = new Lazy<ICashReceiptQueryRepository>(new CashReceiptQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _cashPayment = new Lazy<ICashPaymentQueryRepository>(new CashPaymentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _salesInvoice = new Lazy<ISalesInvoiceQueryRepository>(new SalesInvoiceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _PurchaseInvoice = new Lazy<IPurchaseInvoiceQueryRepository>(new PurchaseInvoiceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _DeliveryNote = new Lazy<IDeliveryNoteQueryRepository>(new DeliveryNoteQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _GoodsIssue = new Lazy<IGoodsIssueQueryRepository>(new GoodsIssueQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _PurchaseReturn = new Lazy<IPurchaseReturnQueryRepository>(new PurchaseReturnQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _creditNote = new Lazy<ICreditNoteQueryRepository>(new CreditNoteQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _InventoryScrap = new Lazy<IInventoryScrapQueryRepository>(new InventoryScrapQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _ScrapReason = new Lazy<IScrapReasonQueryRepository>(new ScrapReasonQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            _debitNote = new Lazy<IDebitNoteQueryRepository>(new DebitNoteQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _cashTransfer = new Lazy<ICashTransferQueryRepository>(new CashTransferQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            // FixedAsset
            _assetDepreciationScheduleQueryRepository = new Lazy<IAssetDepreciationScheduleQueryRepository>(new AssetDepreciationScheduleQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _fixedAssetQueryRepository = new Lazy<IFixedAssetQueryRepository>(new FixedAssetQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetAccountingEventQueryRepository = new Lazy<IAssetAccountingEventQueryRepository>(new AssetAccountingEventQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetAccountingEventAccountQueryRepository = new Lazy<IAssetAccountingEventAccountQueryRepository>(new AssetAccountingEventAccountQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _journalEntry = new Lazy<IJournalEntryQueryRepository>(new JournalEntryQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetGroup = new Lazy<IAssetGroupQueryRepository>(new AssetGroupQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetCustody = new Lazy<IAssetCustodyQueryRepository>(new AssetCustodyQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetComponent = new Lazy<IAssetComponentQueryRepository>(new AssetComponentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetCustody = new Lazy<IAssetCustodyQueryRepository>(new AssetCustodyQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _assetMaintenance = new Lazy<IAssetMaintenanceQueryRepository>(new AssetMaintenanceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            // Inventory
            _itemGroup = new Lazy<IItemGroupQueryRepository>(new ItemGroupQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _item = new Lazy<IItemQueryRepository>(new ItemQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _itemVariantAttribute = new Lazy<IItemVariantAttributeQueryRepository>(new ItemVariantAttributeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inventoryBalanceQueryRepository = new Lazy<IInventoryBalanceQueryRepository>(new InventoryBalanceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _goodsReceiptQueryRepository = new Lazy<IGoodsReceiptQueryRepository>(new GoodsReceiptQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inventoryCostLayerQueryRepository = new Lazy<IInventoryCostLayerQueryRepository>(new InventoryCostLayerQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _warehouseLocationQueryRepository = new Lazy<IWarehouseLocationQueryRepository>(new WarehouseLocationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inventoryOpeningBalance = new Lazy<IInventoryOpeningBalanceQueryRepository>(new InventoryOpeningBalanceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inventoryLedgerQueryRepository = new Lazy<IInventoryLedgerQueryRepository>(new InventoryLedgerQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _itemAttribute = new Lazy<IItemAttributeQueryRepository>(new ItemAttributeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _goodsTransferOut = new Lazy<IGoodsTransferOutQueryRepository>(new GoodsTransferOutQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _goodsTransferIn = new Lazy<IGoodsTransferInQueryRepository>(new GoodsTransferInQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _Batch = new Lazy<IBatchQueryRepository>(new BatchQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inventoryAdjustment = new Lazy<IInventoryAdjustmentQueryRepository>(new InventoryAdjustmentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            //Account Balance
            _accountBalanceQueryRepository = new Lazy<IAccountBalanceQueryRepository>(new AccountBalanceQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            //Setup  
            _iSalesPersonQueryRepository = new Lazy<ISalesPersonQueryRepository>(new SalesPersonQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _moduleSettingRepository = new Lazy<IModuleSettingQueryRepository>(new ModuleSettingQeryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            //MenuManagement

            _User_CodeQueryRepository = new Lazy<IUser_CodeQueryRepository>(new User_CodeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _programQueryRepository = new Lazy<IProgramQueryRepository>(new ProgramQueryRepository(_context));
            _inspectionStandardQueryRepository = new Lazy<IInspectionStandardQueryRepository>(new InspectionStandardQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            _checklistTemplatesQueryRepository = new Lazy<IChecklistTemplateQueryRepository>(new ChecklistTemplateQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            //Inspection
            _inspector = new Lazy<IInspectorQueryRepository>(new InspectorQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _certificate = new Lazy<ICertificateQueryRepository>(new CertificateQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _accreditationBody = new Lazy<IAccreditationBodyQueryRepository>(new AccreditationBodyQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _checklists = new Lazy<IChecklistQueryRepository>(new ChecklistQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _inspectorCompetency = new Lazy<IInspectorCompetencyQueryRepository>(new InspectorCompetencyQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _jobOrderDashboardQueryRepository = new Lazy<IJobOrderDashboardQueryRepository>(new JobOrderDashboardQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            // DMS
            _folder = new Lazy<IFolderQueryRepository>(new FolderQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _folderPermission = new Lazy<IFolderPermissionQueryRepository>(new FolderPermissionQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _tag = new Lazy<ITagQueryRepository>(new TagQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _documentShare = new Lazy<IDocumentShareQueryRepository>(new DocumentShareQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _ShareAccessLog = new Lazy<IShareAccessLogQueryRepository>(new ShareAccessLogQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _document = new Lazy<IDocumentQueryRepository>(new DocumentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _documentComment = new Lazy<IDocumentCommentQueryRepository>(new DocumentCommentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            //Contracting
            _Activity = new Lazy<IActivityQueryRepository>(new ActivityQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _CostCode = new Lazy<ICostCodeQueryRepository>(new CostCodeQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _Division = new Lazy<IDivisionQueryRepository>(new DivisionQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _WBS = new Lazy<IWBSQueryRepository>(new WBSQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));


            // Commitment
            _commitmentQueryRepository = new Lazy<ICommitmentQueryRepository>(new CommitmentQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            // Contracting
            _bOQ = new Lazy<IBOQQueryRepository>(new BOQQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));
            _subcontractBOQ = new Lazy<ISubcontractBOQQueryRepository>(new SubcontractBOQQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            // Manufacturing
            _productionOrderQueryRepository = new Lazy<IProductionOrderQueryRepository>(new ProductionOrderQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));

            // Asset Location
            _assetLocationQueryRepository = new Lazy<IAssetLocationQueryRepository>(new AssetLocationQueryRepository(_queryBuilder, _dapper, _context, _tenantResolver, _exceptionManager));



        }

        //Sample
        public ISCurrencyExchangeRateQueryRepository SCurrencyExchangeRates => _scurrencyExchangeRateQueryRepository.Value;
        //Sample


        //Contracting
        public IActivityQueryRepository Activity => _Activity.Value;
        public ICostCodeQueryRepository CostCode => _CostCode.Value;

        public IDivisionQueryRepository Division => _Division.Value;
        public IWBSQueryRepository WBS => _WBS.Value;


        public IInspectionRequestQueryRepository InspectionRequest => _inspectionRequset.Value;
        public IInspectionReportQueryRepository InspectionReport => _inspectionReport.Value;

        public IServiceTypeQueryRepository ServiceType => _serviceType.Value;
        public IEquipmentQueryRepository Equipment => _equipmentQuery.Value;
        public IEquipmentInspectionQueryRepository EquipmentInspection => _equipmentInspectionQuery.Value;
        public IMaintenanceReportQueryRepository MaintenanceReport => _maintenanceReportQuery.Value;
        public IMaintenanceScheduleQueryRepository MaintenanceSchedule => _maintenanceScheduleQuery.Value;
        public ILocalizationQueryRepository Localization => _localizationQuery.Value;
        public IMenuQueryRepository Menu => _menuQuery.Value;
        public IApprovalQueryRepository Approval => _approvalQuery.Value;
        public IUserApprovalQueryRepository UserApproval => _userApprovalQuery.Value;
        public IApprovalDelegationQueryRepository ApprovalDelegation => _approvalDelegationQuery.Value;
        public IUserNotificationsQueryRepository UserNotifications => _userNotificationsQuery.Value;
        public ISeriesQueryRepository Series => _series.Value;
        public ICustomerLocationQueryRepository CustomerLocations => _CustomerLocation.Value;
        public ICustomerProjectQueryRepository CustomerProject => _CustomerProject.Value;
        public IServiceItemQueryRepository ServicesItems => _serviceItem.Value;

        public ISalesOrderLineQueryRepository SalesOrderLines => _salesOrderLine.Value;
        public ISalesOrderQueryRepository SalesOrder => _salesOrder.Value;

        public ILedgerQueryRepository Ledger => _ledgerQuery.Value;
        public ILedgerLineQueryRepository LedgerLine => _ledgerLineQuery.Value;

        // Sales Management
        public ISalesQuotationQueryRepository SalesQuotation => _salesQuotation.Value;
        public ISalesReturnQueryRepository SalesReturn => _SalesReturn.Value;

        public IAreaQueryRepository Area => _area.Value;
        public ICustomerBranchQueryRepository Branch => _customerBranch.Value;
        public IInspectionMethodQueryRepository InspectionMethod => _inspectionMethod.Value;
        public IScreenCodeQueryRepository ScreenCode => _screenCode.Value;
        public IInspectorCategoryQueryRepository InspectorCategory => _inspectorCategory.Value;
        public IEquipmentTypeQueryRepository EquipmentTypes => _equipmentTypeQuery.Value;
        public IJobOrderQueryRepository JobOrder => _jobOrderQueryRepository.Value;
        public IJobOrderDetailQueryRepository JobOrderDetail => _jobOrderDetailQueryRepository.Value;
        public IInspectionCertificateQueryRepository InspectionCertificate => _inspectionCertificateRepository.Value;
        public IEquipmentsMoreInformationQueryRepository EquipmentsMoreInformation => _equipmentsMoreInformationQueryRepository.Value;
        public IInspectionRequestLinesQueryRepository InspectionRequestLines => _inspectionRequestLinesRepository.Value;
        public IInspectionDashboardQueryRepository InspectionDashboard => _inspectionDashboard.Value;
        public IInspectionRequestDetailSubcontractorQueryRepository InspectionRequestDetailSubcontractors => _inspectionRequestDetailSubcontractorRepository.Value;
        public IApplicantCVQueryRepository ApplicantCVQueryRepository => _applicantCVQueryRepository.Value;
        public IDepartmentQueryRepository DepartmentQueryRepository => _departmentQueryRepository.Value;
        public IEmployeeQueryRepository EmployeeQueryRepository => _employeeQueryRepository.Value;
        public ITestTableMasterQueryRepository TestTableMasterQueryRepository => _testTableMasterQueryRepository.Value;
        public ITestTableDetailQueryRepository TestTableDetailQueryRepository => _testTableDetailsQueryRepository.Value;
        public ITestTableSubDetailsQueryRepository TestTableSubDetailQueryRepository => _testTableSubDetailsQueryRepository.Value;
        public ICompanyEquipmentQueryRepository CompanyEquipmentsQueryRepository => _companyEquipmentsQueryRepository.Value;
        public IEquipmentAccessoryQueryRepository EquipmentAccessoriesQueryRepository => _EquipmentAccessoriesQueryRepository.Value;
        public IEquipmentSoftwareQueryRepository EquipmentSoftwareQueryRepository => _EquipmentSoftwareQueryRepository.Value;
        public IEquipmentCalibrationHistoryQueryRepository EquipmentCalibrationHistoryQueryRepository => _EquipmentCalibrationHistoryQueryRepository.Value;
        public IEquipmentPreventiveMaintenanceQueryRepository EquipmentPreventiveMaintenanceQueryRepository => _EquipmentPreventiveMaintenanceQueryRepository.Value;
        public IEquipmentMaintenanceAndRepairRecordQueryRepository EquipmentMaintenanceAndRepairRecordQueryRepository => _EquipmentMaintenanceAndRepairRecordQueryRepository.Value;
        public IJobRequestQueryRepository JobRequestQueryRepository => _jobRequestQueryRepository.Value;
        public IJobTitleQueryRepository JobTitleQueryRepository => _jobTitleQueryRepository.Value;
        public IInterviewEvaluationQueryRepository InterviewEvaluationQueryRepository => _interviewEvaluationQueryRepository.Value;
        public IJobAdvertisementQueryRepository JobAdvertisementQueryRepository => _jobAdvertisementQueryRepository.Value;
        public IJobOfferNegotiationQueryRepository JobOfferNegotiationQueryRepository => _jobOfferNegotiationQueryRepository.Value;
        public IEquipmentsMoreInformationDetailQueryRepository EquipmentsMoreInformationDetailQueryRepository => _EquipmentsMoreInformationDetailQueryRepository.Value;
        public IEquipmentCategoryQueryRepository EquipmentCategoryQueryRepository => _EquipmentCategoryQueryRepository.Value;
        public IEquipmentsMoreInformationTemplateQueryRepository EquipmentsMoreInformationTemplateQueryRepository => _EquipmentsMoreInformationTemplateQueryRepository.Value;
        public IEquipmentsMoreInformationTemplateDetailQueryRepository EquipmentsMoreInformationTemplateDetailQueryRepository => _EquipmentsMoreInformationTemplateDetailQueryRepository.Value;
        public IInspectionChecklistsQueryRepository InspectionChecklistQueryRepository => _InspectionChecklistsQueryRepository.Value;
        public IInspectionChecklistMoreInformationQR InspectionChecklistMoreInformationQueryRepository => _InspectionChecklistMoreInformationQueryRepository.Value;
        public IInspectionChecklistMoreInformationDetailQR InspectionChecklistMoreInformationDetailQueryRepository => _InspectionChecklistMoreInformationDetailQueryRepository.Value;
        public IInspectionChecklistMoreInformationTemplateQueryRepository InspectionChecklistMoreInformationTemplateQueryRepository => _InspectionChecklistMoreInformationTemplateQueryRepository.Value;
        public IInspectionChecklistMoreInformationTemplateDetailQR InspectionChecklistMoreInformationTemplateDetailQueryRepository => _InspectionChecklistMoreInformationTemplateDetailQueryRepository.Value;
        public IInspectionTypeQueryRepository InspectionTypes => _inspectionTypes.Value;
        public IUser_GroupQueryRepository User_Groups => _User_Groups.Value;
        public IScreen_permissionQueryRepository Screen_permissions => _Screen_permissions.Value;

        //System Configurations
        public ICompanyQueryRepository Companies => _companyQueryRepository.Value;
        public ICurrencyQueryRepository Currencies => _currencyQueryRepository.Value;
        public ICountriesQueryRepository Counteris => _countriesQueryRepository.Value;
        public IOperationQueryRepository OperationQueryRepository => _operationQueryRepository.Value;
        public ICityQueryRepository Cities => _cityQueryRepository.Value;

        // Accounting
        public ICostCenterQueryRepository CostCenters => _costCenterQueryRepository.Value;
        public ICostUnitQueryRepository CostUnits => _costUnitQueryRepository.Value;
        public IBankAccountQueryRepository BankAccounts => _bankAccountQueryRepository.Value;
        public IBankQueryRepository Banks => _bankQueryRepository.Value;
        public IFiscalYearQueryRepository FiscalYears => _fiscalYearQueryRepository.Value;
        public ICurrencyExchangeRateQueryRepository CurrencyExchangeRateQueryRepository => _currencyExchangeRateQueryRepository.Value;
        public IAccountingPeriodQueryRepository AccountingPeriods => _accountingPeriodQueryRepository.Value;
        public IAcountTypeQueryRepository AccountTypes => _accountTypeQueryRepository.Value;
        public IChartOfAccountQueryRepository ChartOfAccounts => _chartOfAccountQueryRepository.Value;
        public ITaxTypeQueryRepository TaxTypeQueryRepository => _taxTypeQueryRepository.Value;
        public ISupplierQueryRepository ISupplierQueryRepo => _supplierQueryRepository.Value;
        public IAssetTransactionQueryRepository AssetTransaction => _AssetTransaction.Value;
        public IAssetCategoryQueryRepository AssetCategory => _AssetCategory.Value;
        public IJournalEntryQueryRepository JournalEntryQuery => _journalEntry.Value;
        public IJournalEntryTemplateQueryRepository JournalEntryTemplate => _journalEntryTemplate.Value;
        public IModeOfPaymentQueryRepository ModeOfPayment => _modeOfPayment.Value;
        public ICashReceiptQueryRepository CashReceipt => _cashReceipt.Value;
        public ICashPaymentQueryRepository CashPayment => _cashPayment.Value;
        public ISalesInvoiceQueryRepository SalesInvoice => _salesInvoice.Value;
        public IGoodsIssueQueryRepository GoodsIssue => _GoodsIssue.Value;
        public IPurchaseReturnQueryRepository PurchaseReturn => _PurchaseReturn.Value;
        public ICreditNoteQueryRepository CreditNote => _creditNote.Value;
        public IInventoryScrapQueryRepository InventoryScrap => _InventoryScrap.Value;
        public IScrapReasonQueryRepository ScrapReason => _ScrapReason.Value;
        public ICashTransferQueryRepository CashTransfer => _cashTransfer.Value;

        // Account System
        public IDefaultAccountTypeQueryRepository DefaultAccountTypes => _defaultAccountTypeQueryRepository.Value;
        public IDefaultAccountGroupQueryRepository DefaultAccountGroups => _defaultAccountGroupQueryRepository.Value;
        public IDefaultAccountAssignmentQueryRepository DefaultAccountAssignments => _defaultAccountAssignment.Value;
        public IPaymentTermQueryRepository PaymentTerms => _paymentTerm.Value;
        public ILanguageQueryRepository LanguageQueryRepository => _Language.Value;
        public ICustomerQueryRepository CustomerQuery => _customerQueryRepository.Value;
        public ICustomerGroupQueryRepository CustomerGroups => _customerGroupQueryRepository.Value;
        public ISupplierGroupQueryRepository SupplierGroups => _supplierGroup.Value;
        public ICashQueryRepository Cashs => _cashQueryRepository.Value;
        public ICustomerBranchQueryRepository CustomerBranch => _customerBranch.Value;
        public IBranchQueryRepository Branches => _branchQueryRepository.Value;
        public IWarehouseQueryRepository Warehouses => _warehouseQueryRepository.Value;
        public IBrandQueryRepository Brands => _brandQueryRepository.Value;
        public IModelQueryRepository Models => _modelQueryRepository.Value;
        public IUnitOfMeasureQueryRepository UnitOfMeasures => _unitOfMeasureQueryRepository.Value;
        public IUnitOfMeasureConversionQueryRepository UnitOfMeasureConversions => _unitOfMeasureConversionQueryRepository.Value;
        public ITaxCategoryQueryRepository TaxCategoryQueryRepository => _taxCategoryQueryRepository.Value;
        public IDeliveryNoteQueryRepository DeliveryNote => _DeliveryNote.Value;

        // FixedAsset
        public IAssetDepreciationScheduleQueryRepository AssetDepreciationSchedules => _assetDepreciationScheduleQueryRepository.Value;
        public IFixedAssetQueryRepository FixedAsset => _fixedAssetQueryRepository.Value;
        public IAssetAccountingEventQueryRepository AssetAccountingEvents => _assetAccountingEventQueryRepository.Value;
        public IAssetAccountingEventAccountQueryRepository AssetAccountingEventAccounts => _assetAccountingEventAccountQueryRepository.Value;
        public IAssetGroupQueryRepository AssetGroup => _assetGroup.Value;
        public IAssetCustodyQueryRepository AssetCustody => _assetCustody.Value;
        public IAssetComponentQueryRepository AssetComponent => _assetComponent.Value;
        public IAssetMaintenanceQueryRepository AssetMaintenance => _assetMaintenance.Value;

        // Inventory
        public IItemGroupQueryRepository ItemGroup => _itemGroup.Value;
        public IItemQueryRepository Items => _item.Value;
        public IItemVariantAttributeQueryRepository ItemVariantAttribute => _itemVariantAttribute.Value;
        public IColorQueryRepository Color => _ColorQueryRepository.Value;
        public ISizeQueryRepository size => _SizeQueryRepository.Value;
        public IInventoryBalanceQueryRepository InventoryBalances => _inventoryBalanceQueryRepository.Value;
        public IGoodsReceiptQueryRepository GoodsReceipts => _goodsReceiptQueryRepository.Value;
        public IWarehouseLocationQueryRepository WarehouseLocationQuery => _warehouseLocationQueryRepository.Value;
        public IInventoryCostLayerQueryRepository InventoryCostLayerQuery => _inventoryCostLayerQueryRepository.Value;
        public IInventoryOpeningBalanceQueryRepository InventoryOpeningBalance => _inventoryOpeningBalance.Value;
        public IInventoryLedgerQueryRepository InventoryLedger => _inventoryLedgerQueryRepository.Value;
        public IItemAttributeQueryRepository ItemAttribute => _itemAttribute.Value;
        public ISalesPersonQueryRepository SalesPerson => _iSalesPersonQueryRepository.Value;
        public IModuleSettingQueryRepository ModuleSetting => _moduleSettingRepository.Value;
        public IGoodsTransferOutQueryRepository GoodsTransferOut => _goodsTransferOut.Value;
        public IGoodsTransferInQueryRepository GoodsTransferIn => _goodsTransferIn.Value;
        public IBatchQueryRepository Batch => _Batch.Value;
        public IInventoryAdjustmentQueryRepository InventoryAdjustment => _inventoryAdjustment.Value;

        //MenuManag 
        public IUser_CodeQueryRepository User_CodeQueryRepository => _User_CodeQueryRepository.Value;
        public IProgramQueryRepository programQueryRepository => _programQueryRepository.Value;

        public ISeriesDetailsQueryRepository SeriesDetails => _seriesDetails.Value;

        public IInspectionStandardQueryRepository InspectionStandards => _inspectionStandardQueryRepository.Value;
        public IChecklistTemplateQueryRepository ChecklistTemplates => _checklistTemplatesQueryRepository.Value;


        //Inspection
        public IInspectorQueryRepository Inspector => _inspector.Value;
        public ICertificateQueryRepository Certificate => _certificate.Value;
        public IChecklistQueryRepository Checklists => _checklists.Value;
        public IInspectorCompetencyQueryRepository InspectorCompetency => _inspectorCompetency.Value;
        public IAccreditationBodyQueryRepository AccreditationBody => _accreditationBody.Value;
        public ISalesQuotationDashboardQueryRepository ISalesQuotationDashboardQueryRepository => _salesQuotationDashboardQueryRepository.Value;
        public IJobOrderDashboardQueryRepository IJobOrderDashboardQueryRepository => _jobOrderDashboardQueryRepository.Value;

        // DMS
        public IFolderQueryRepository Folder => _folder.Value;
        public IFolderPermissionQueryRepository FolderPermission => _folderPermission.Value;
        public ITagQueryRepository Tag => _tag.Value;
        public IDocumentQueryRepository Document => _document.Value;
        public IDocumentShareQueryRepository DocumentShare => _documentShare.Value;
        public IShareAccessLogQueryRepository ShareAccessLog => _ShareAccessLog.Value;
        public IDocumentCommentQueryRepository DocumentComment => _documentComment.Value;
        public IJournalEntryQueryRepository IJournalEntry => _journalEntry.Value;

        // Account Balance
        public IAccountBalanceQueryRepository AccountBalance => _accountBalanceQueryRepository.Value;

        public IPurchaseInvoiceQueryRepository PurchaseInvoice => _PurchaseInvoice.Value;

        public IDebitNoteQueryRepository DebitNote => _debitNote.Value;

        // Commitment
        public ICommitmentQueryRepository Commitment => _commitmentQueryRepository.Value;

        // Contracting
        public IBOQQueryRepository BOQ => _bOQ.Value;
        public ISubcontractBOQQueryRepository SubcontractBOQ => _subcontractBOQ.Value;

        // Manufacturing
        public IProductionOrderQueryRepository ProductionOrder => _productionOrderQueryRepository.Value;

        // Asset Location
        public IAssetLocationQueryRepository AssetLocation => _assetLocationQueryRepository.Value;



    }
}