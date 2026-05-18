using Inspection.Domain.Models.Accounting.AccountBalance;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;
using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using Inspection.Domain.Models.Accounting.AccountingSystem;
using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryLines;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Inspection.Domain.Models.ApprovalManagement;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.Commitment;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.DMS.DocumentComments;
using Inspection.Domain.Models.DMS.Documents;
using Inspection.Domain.Models.DMS.DocumentShares;
using Inspection.Domain.Models.DMS.FolderPermissions;
using Inspection.Domain.Models.DMS.Folders;
using Inspection.Domain.Models.DMS.ShareAccessLogs;
using Inspection.Domain.Models.DMS.Tags;
using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using Inspection.Domain.Models.HRManagement.JobRequests;
using Inspection.Domain.Models.HRManagement.JobTitles;
using Inspection.Domain.Models.HRManagement.TrainingPrograms;
using Inspection.Domain.Models.HRManagement.TrainingSessionAttendances;
using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using Inspection.Domain.Models.Inspection.Techinal.Certificates;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using Inspection.Domain.Models.InspectionManagement.InspectorCategories;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;
using Inspection.Domain.Models.Inventory.ItemGroups;
using Inspection.Domain.Models.Inventory.Ledger;
using Inspection.Domain.Models.Inventory.System.InventoryBalances;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using Inspection.Domain.Models.Localizations;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using Inspection.Domain.Models.Seeting.ModuleSettings;
using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using Inspection.Domain.Models.System;
using Inspection.Domain.Models.System.Languages;
using Inspection.Domain.Models.System.Taxestegories;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using Inspection.Domain.Models.SystemConfigurations.DetailTables;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using Inspection.Domain.Models.TestTableMaster;
using Inspection.Domain.Models.TestTableMasters;
using Inspection.Domain.Models.UserNotificationManagement;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.AccountingPeriods;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.BankAccounts;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.Banks;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.Branches;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.Caching;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.CostUnits;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.FiscalYears;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.ModeOfPayments;
using Inspection.Infrastructure.Configurations.Accounting.AccountingSystem;
using Inspection.Infrastructure.Configurations.Accounting.AR.MasterData;
using Inspection.Infrastructure.Configurations.Accounting.AR.SalesInvoices;
using Inspection.Infrastructure.Configurations.Accounting.Assets.AssetAccountingEventAccounts;
using Inspection.Infrastructure.Configurations.Accounting.Assets.AssetAccountingEvents;
using Inspection.Infrastructure.Configurations.Accounting.Assets.AssetDepreciationSchedules;
using Inspection.Infrastructure.Configurations.Accounting.Assets.AssetMaintenances;
using Inspection.Infrastructure.Configurations.Accounting.Assets.AssetTransactions;
using Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetCategories;
using Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetComponents;
using Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetGroups;
using Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.FixedAssets;
using Inspection.Infrastructure.Configurations.Accounting.ChartOfAccounts;
using Inspection.Infrastructure.Configurations.Accounting.Payment.CashPayments;
using Inspection.Infrastructure.Configurations.Accounting.Payment.CashReceipts;
using Inspection.Infrastructure.Configurations.Accounting.Payment.CashTransfers;
using Inspection.Infrastructure.Configurations.Accounting.Payment.CreditNotes;
using Inspection.Infrastructure.Configurations.Accounting.Payment.DebitNotes;
using Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntryLines;
using Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntrys;
using Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntryTemplateLines;
using Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntryTemplates;
using Inspection.Infrastructure.Configurations.Accounting.PostingEngine;
using Inspection.Infrastructure.Configurations.Accounting.PR.MasterData.SupplierContacts;
using Inspection.Infrastructure.Configurations.Accounting.PR.MasterData.Suppliers;
using Inspection.Infrastructure.Configurations.Accounting.PR.PurchaseInvoices;
using Inspection.Infrastructure.Configurations.ApprovalManagement;
using Inspection.Infrastructure.Configurations.Contracting.Setup.BOQs;
using Inspection.Infrastructure.Configurations.Contracting.Setup.Commitments;
using Inspection.Infrastructure.Configurations.Contracting.Setup.SubcontractBOQs;
using Inspection.Infrastructure.Configurations.DMS.DocumentComments;
using Inspection.Infrastructure.Configurations.DMS.Documents;
using Inspection.Infrastructure.Configurations.DMS.DocumentShares;
using Inspection.Infrastructure.Configurations.DMS.FolderPermissions;
using Inspection.Infrastructure.Configurations.DMS.Folders;
using Inspection.Infrastructure.Configurations.DMS.ShareAccessLogs;
using Inspection.Infrastructure.Configurations.DMS.Tags;
using Inspection.Infrastructure.Configurations.EquipmentManagement.CompanyEquipments;
using Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentAccessories;
using Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentCategorys;
using Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformationDetails;
using Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformations;
using Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformationTemplateDetails;
using Inspection.Infrastructure.Configurations.EquipmentManagement.EquipmentMoreInformationTemplates;
using Inspection.Infrastructure.Configurations.EquipmentManagement.Equipments;
using Inspection.Infrastructure.Configurations.HRManagement.Employees;
using Inspection.Infrastructure.Configurations.HRManagement.JobRequests;
using Inspection.Infrastructure.Configurations.Inspection.Techinal;
using Inspection.Infrastructure.Configurations.Inspection.Techinal.AccreditationBodies;
using Inspection.Infrastructure.Configurations.Inspection.Techinal.Certificates;
using Inspection.Infrastructure.Configurations.Inspection.Techinal.Checklists;
using Inspection.Infrastructure.Configurations.Inspection.Techinal.Checklists.ChecklistTemplateLines;
using Inspection.Infrastructure.Configurations.Inspection.Techinal.InspectorCompetencies;
using Inspection.Infrastructure.Configurations.InspectionManagement.CustomerLocations;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionCertificates;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformaionTemplateDetails;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformaionTemplates;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionMethods;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionRequests;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectionTypes;
using Inspection.Infrastructure.Configurations.InspectionManagement.InspectorCategories;
using Inspection.Infrastructure.Configurations.Inventory.InventorySetup;
using Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemAttributeConfigurations;
using Inspection.Infrastructure.Configurations.Inventory.InventorySetup.ItemConfigurations;
using Inspection.Infrastructure.Configurations.Inventory.InventorySetup.UnitOfMeasureConversionConversions;
using Inspection.Infrastructure.Configurations.Inventory.ItemGroups;
using Inspection.Infrastructure.Configurations.Inventory.LedgerConfig;
using Inspection.Infrastructure.Configurations.Inventory.System;
using Inspection.Infrastructure.Configurations.Inventory.System.InventoryLedgers;
using Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsTransferIns;
using Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Infrastructure.Configurations.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Infrastructure.Configurations.LocalizationManagement;
using Inspection.Infrastructure.Configurations.Manufacturing.Setup.ProductionOrders;
using Inspection.Infrastructure.Configurations.MenuManagement;
using Inspection.Infrastructure.Configurations.SalesManagement.JobOrders;
using Inspection.Infrastructure.Configurations.SalesManagement.Setup.SalesPersons;
using Inspection.Infrastructure.Configurations.SalesManagement.Transactions.SalesQuotations;
using Inspection.Infrastructure.Configurations.Sample.CurrencyExchangeRate;
using Inspection.Infrastructure.Configurations.ServiceCatalog.ServiceItems;
using Inspection.Infrastructure.Configurations.ServiceCatalog.ServiceTypes;
using Inspection.Infrastructure.Configurations.Setting.ModuleSettings;
using Inspection.Infrastructure.Configurations.System.Languages;
using Inspection.Infrastructure.Configurations.System.Taxes;
using Inspection.Infrastructure.Configurations.SystemConfigurations.Cities;
using Inspection.Infrastructure.Configurations.SystemConfigurations.Companies;
using Inspection.Infrastructure.Configurations.SystemConfigurations.Countriess;
using Inspection.Infrastructure.Configurations.SystemConfigurations.Currencies;
using Inspection.Infrastructure.Configurations.SystemConfigurations.CurrencyExchangRates;
using Inspection.Infrastructure.Configurations.SystemConfigurations.Operations;
using Inspection.Infrastructure.Configurations.UserNotificationManagement;
using Inspection.Infrastructure.Persistence.Configurations.Inspection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Inspection.Infrastructure.DataContext;

public partial class DbInspectionContext : DbContext
{
    public DbInspectionContext()
    {
    }

    //public DbInspectionContext(DbContextOptions<DbInspectionContext> options)
    //    : base(options)
    //{
    //}
    private readonly IConfiguration _configuration;

    public DbInspectionContext(DbContextOptions<DbInspectionContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    //Sample
    public DbSet<SCurrencyExchangeRateHeader> SCurrencyExchangeRateHeaders { get; set; }
    //Sample

    public DbSet<InspectionRequest> InspectionRequest { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Localization> Localization { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<Screen_permission> Screen_Permission { get; set; }
    public DbSet<Screen_Code> Screen_Code { get; set; }
    public DbSet<User_Code_dGroup> User_Code_dGroup { get; set; }
    public DbSet<Program> Program { get; set; }
    public DbSet<User_Code> User_Code { get; set; }
    public DbSet<Tenant_Code> Tenant_Code { get; set; }
    public DbSet<User_Group> User_Group { get; set; }
    public DbSet<ApplicantCV> ApplicantCVs { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<InterviewEvaluation> InterviewEvaluations { get; set; }
    public DbSet<JobOfferNegotiation> JobOfferNegotiations { get; set; }
    public DbSet<JobRequest> JobRequests { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<JobAdvertisement> JobAdvertisements { get; set; }
    public DbSet<TrainingProgram> TrainingPrograms { get; set; }
    public DbSet<TrainingSessionAttendance> TrainingSessionAttendances { get; set; }
    public DbSet<Approval> Approval { get; set; }
    public DbSet<User_Approval> User_Approval { get; set; }
    public DbSet<Approval_d> Approval_d { get; set; }
    public DbSet<Approval_Delegation> Approval_Delegation { get; set; }

    public DbSet<User_Notification> User_Notification { get; set; }
    public DbSet<MenuLocalization> MenuLocalization { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<SeriesDetails> SeriesDetails { get; set; }
    public DbSet<CustomerLocation> CustomerLocation { get; set; }
    public DbSet<CustomerProject> CustomerProject { get; set; }
    public DbSet<ServiceItem> serviceItems { get; set; }

    // Sales Management
    public DbSet<SalesQuotation> SalesQuotation { get; set; }
    public DbSet<SalesQuotationLine> SalesQuotationLine { get; set; }

    // Sales Order
    public DbSet<SalesOrder> SalesOrder { get; set; }
    public DbSet<SalesOrderLines> SalesOrderLine { get; set; }

    public DbSet<EquipmentsMoreInformation> EquipmentsMoreInformations { get; set; }
    public DbSet<EquipmentsMoreInformationDetail> EquipmentsMoreInformationDetails { get; set; }
    public DbSet<EquipmentsMoreInformationTemplate> EquipmentsMoreInformationTemplates { get; set; }
    public DbSet<EquipmentsMoreInformationTemplateDetail> EquipmentsMoreInformationTemplateDetails { get; set; }
    public DbSet<Area> Area { get; set; }
    public DbSet<CustomerBranch> CustomerBranch { get; set; }
    public DbSet<InspectionMethod> InspectionMethod { get; set; }
    public DbSet<JobOrder> JobOrder { get; set; }
    public DbSet<JobOrderLine> JobOrderLine { get; set; }
    public DbSet<InspectionCertificate> InspectionCertificate { get; set; }
    public DbSet<InspectionRequestLines> InspectionRequestLines { get; set; }
    public DbSet<InspectionRequestSubcontractorDetail> InspectionRequestSubcontractorDetails { get; set; }
    public DbSet<TestTableMaster> TestTableMaster { get; set; }
    public DbSet<TestTableDetail> TestTableDetail { get; set; }
    public DbSet<TestTableSubDetail> TestTableSubDetail { get; set; }
    public DbSet<EquipmentType> EquipmentTypes { get; set; }
    public DbSet<CompanyEquipment> CompanyEquipment { get; set; }
    public DbSet<EquipmentAccessory> EquipmentAccessory { get; set; }
    public DbSet<EquipmentSoftware> EquipmentSoftware { get; set; }
    public DbSet<EquipmentCalibrationHistory> EquipmentCalibrationHistory { get; set; }
    public DbSet<EquipmentPreventiveMaintenance> EquipmentPreventiveMaintenance { get; set; }
    public DbSet<EquipmentMaintenanceAndRepairRecord> EquipmentMaintenanceAndRepairRecord { get; set; }
    public DbSet<EquipmentCategory> EquipmentCategory { get; set; }
    public DbSet<InspectionChecklist> InspectionChecklist { get; set; }
    public DbSet<InspectionChecklistMoreInformation> InspectionChecklistMoreInformation { get; set; }
    public DbSet<InspectionChecklistMoreInformationDetail> InspectionChecklistMoreInformationDetail { get; set; }
    public DbSet<InspectionChecklistMoreInformationTemplate> InspectionChecklistMoreInformationTemplate { get; set; }
    public DbSet<InspectionChecklistMoreInformationTemplateDetail> InspectionChecklistMoreInformationTemplateDetail { get; set; }


    // Inspection Management

    public DbSet<InspectorCategory> InspectorCategory { get; set; }
    public DbSet<InspectionType> InspectionTypes { get; set; }

    //SystemConfigurations
    public DbSet<Company> Company { get; set; }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<DetailTable> DetailTable { get; set; }
    public DbSet<CurrencyExchangRate> CurrencyExchangRate { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Operation> Operation { get; set; }
    //public DbSet<TaxType> TaxType { get; set; }
    public DbSet<TaxCategory> TaxCategory { get; set; }
    public DbSet<TaxTypeLine> TaxTypeLine { get; set; }
    public DbSet<Language> Language { get; set; }

    // Accounting
    public DbSet<CostCenter> CostCenter { get; set; }
    public DbSet<CostUnit> CostUnit { get; set; }
    public DbSet<AccountingPeriod> AccountingPeriod { get; set; }
    public DbSet<FiscalYear> FiscalYear { get; set; }
    public DbSet<AccountType> AccountType { get; set; }
    public DbSet<ChartOfAccount> ChartOfAccount { get; set; }
    public DbSet<DefaultAccountType> DefaultAccountType { get; set; }
    public DbSet<DefaultAccountGroup> DefaultAccountGroup { get; set; }
    public DbSet<DefaultAccountAssignment> DefaultAccountAssignment { get; set; }
    public DbSet<SupplierContact> SupplierContact { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
    public DbSet<PaymentTerm> PaymentTerm { get; set; }
    public DbSet<CustomerGroup> CustomerGroup { get; set; }
    public DbSet<SupplierGroup> SupplierGroup { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<CustomerContact> CustomerContact { get; set; }
    public DbSet<Cash> Cash { get; set; }
    public DbSet<Branch> Branch { get; set; }
    public DbSet<Warehouse> Warehouse { get; set; }
    public DbSet<Bank> Bank { get; set; }
    public DbSet<BankAccount> BankAccount { get; set; }
    public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
    public DbSet<UnitOfMeasureConversion> UnitOfMeasureConversion { get; set; }
    public DbSet<ItemGroup> ItemGroup { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<JournalEntryLine> JournalEntryLine { get; set; }
    public DbSet<JournalEntry> JournalEntry { get; set; }
    public DbSet<AccountBalance> AccountBalance { get; set; }
    public DbSet<CashReceipt> CashReceipt { get; set; }
    public DbSet<CashReceiptAdjustment> CashReceiptAdjustment { get; set; }
    public DbSet<CashReceiptLine> CashReceiptLine { get; set; }
    public DbSet<SalesInvoiceAllocation> SalesInvoiceAllocation { get; set; }
    public DbSet<SalesInvoice> SalesInvoice { get; set; }
    public DbSet<SalesInvoiceLine> SalesInvoiceLine { get; set; }
    public DbSet<CashPayment> CashPayment { get; set; }
    public DbSet<CashPaymentLine> CashPaymentLine { get; set; }
    public DbSet<CashPaymentAdjustment> CashPaymentAdjustment { get; set; }
    public DbSet<PurchaseInvoiceAllocation> PurchaseInvoiceAllocation { get; set; }
    public DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
    public DbSet<PurchaseInvoiceLine> PurchaseInvoiceLine { get; set; }
    public DbSet<CreditNote> CreditNote { get; set; }
    public DbSet<CreditNoteLine> CreditNoteLine { get; set; }
    public DbSet<CreditNoteAdjustment> CreditNoteAdjustment { get; set; }
    public DbSet<DebitNote> DebitNote { get; set; }
    public DbSet<DebitNoteLine> DebitNoteLine { get; set; }
    public DbSet<DebitNoteAdjustment> DebitNoteAdjustment { get; set; }
    public DbSet<CashTransfer> CashTransfer { get; set; }
    public DbSet<CashTransferLine> CashTransferLine { get; set; }


    // Assets
    public DbSet<FixedAsset> FixedAsset { get; set; }
    public DbSet<AssetDepreciationSchedule> AssetDepreciationSchedule { get; set; }
    public DbSet<AssetCategory> AssetCategory { get; set; }
    public DbSet<AssetGroup> AssetGroup { get; set; }
    public DbSet<AssetTransaction> AssetTransaction { get; set; }
    public DbSet<AssetAccountingEvent> AssetAccountingEvent { get; set; }
    public DbSet<AssetAccountingEventAccount> AssetAccountingEventAccount { get; set; }
    public DbSet<InventoryBalance> InventoryBalance { get; set; }
    public DbSet<InventoryLedger> InventoryLedger { get; set; }
    public DbSet<GoodsReceipt> GoodsReceipt { get; set; }
    public DbSet<GoodsReceiptLine> GoodsReceiptLine { get; set; }
    public DbSet<AssetComponent> AssetComponent { get; set; }
    public DbSet<AssetMaintenance> AssetMaintenance { get; set; }
    public DbSet<AssetMaintenanceLine> AssetMaintenanceLine { get; set; }


    //SalesPerson
    public DbSet<SalesPerson> SalesPerson { get; set; }
    public DbSet<ModuleSetting> ModuleSetting { get; set; }

    // Inspection
    public DbSet<Inspector> Inspector { get; set; }
    public DbSet<InspectorCompetency> InspectorCompetency { get; set; }
    public DbSet<Certificate> Certificate { get; set; }
    public DbSet<InspectorCompetencyLine> InspectorCompetencyLine { get; set; }
    public DbSet<Checklist> Checklist { get; set; }
    public DbSet<ChecklistTemplateLine> ChecklistTemplateLine { get; set; }
    public DbSet<ChecklistTemplate> ChecklistTemplate { get; set; }
    public DbSet<AccreditationBody> AccreditationBody { get; set; }
    public DbSet<AccreditationBodyLine> AccreditationBodyLine { get; set; }

    // DMS
    public DbSet<Folder> Folder { get; set; }
    public DbSet<FolderPermission> FolderPermission { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<ModeOfPayment> ModeOfPayment { get; set; }
    public DbSet<JournalEntryTemplate> JournalEntryTemplate { get; set; }
    public DbSet<JournalEntryTemplateLine> JournalEntryTemplateLine { get; set; }
    public DbSet<DocumentShare> DocumentShare { get; set; }
    public DbSet<ShareAccessLog> ShareAccessLog { get; set; }
    public DbSet<Document> Document { get; set; }
    public DbSet<DocumentTag> DocumentTag { get; set; }
    public DbSet<DocumentComment> DocumentComment { get; set; }

    // Inventory
    public DbSet<ItemReorderPerWarehouse> ItemReorderPerWarehouse { get; set; }
    public DbSet<ItemAttribute> ItemAttribute { get; set; }
    public DbSet<ItemAttributeValue> ItemAttributeValue { get; set; }
    public DbSet<GoodsTransferOut> GoodsTransferOut { get; set; }
    public DbSet<GoodsTransferOutLine> GoodsTransferOutLine { get; set; }
    public DbSet<GoodsTransferIn> GoodsTransferIn { get; set; }
    public DbSet<GoodsTransferInLine> GoodsTransferInLine { get; set; }
    public DbSet<InventoryOpeningBalance> InventoryOpeningBalance { get; set; }
    public DbSet<InventoryOpeningBalanceLine> InventoryOpeningBalanceLine { get; set; }

    // Accounting - Posting Engine
    public DbSet<PostingDocumentType> PostingDocumentType { get; set; }
    public DbSet<PostingAccountMapping> PostingAccountMapping { get; set; }
    public DbSet<ItemVariantAttribute> ItemVariantAttribute { get; set; }

    public DbSet<Ledger> Ledger { get; set; }
    public DbSet<LedgerLine> LedgerLine { get; set; }

    // Commitment
    public DbSet<Commitment> Commitment { get; set; }
    public DbSet<CommitmentLine> CommitmentLine { get; set; }

    // Contracting
    public DbSet<BOQ> BOQ { get; set; }
    public DbSet<SubcontractBOQ> SubcontractBOQ { get; set; }

    // Manufacturing
    public DbSet<ProductionOrder> ProductionOrder { get; set; }
    public DbSet<ProductionOrderLine> ProductionOrderLine { get; set; }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Data Source=Circleserp.com;Initial Catalog=NDSInspection;Persist Security Info=True;User ID=mahmoud;Password=50%admin;MultipleActiveResultSets=True;Trust Server Certificate=True");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)

        {
            var connectionString = _configuration.GetConnectionString("Inspection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbInspectionContext).Assembly);
        base.OnModelCreating(modelBuilder);

        // Customer Seed
        //modelBuilder.BuildMainData();

        //Sample
        modelBuilder.ApplyConfiguration(new SCurrencyExchangeRateHeaderConfiguration());
        modelBuilder.ApplyConfiguration(new SCurrencyExchangeRateLineConfiguration());
        //Sample

        modelBuilder.ApplyConfiguration(new InspectionRequestConfig());
        modelBuilder.ApplyConfiguration(new InspectionRequestLinesConfig());

        modelBuilder.ApplyConfiguration(new ServiceTypeConfig());
        modelBuilder.ApplyConfiguration(new EquipmentConfig());
        modelBuilder.ApplyConfiguration(new LocalizationConfig());
        modelBuilder.ApplyConfiguration(new MenuConfig());
        modelBuilder.ApplyConfiguration(new ScreenPermissionConfig());
        modelBuilder.ApplyConfiguration(new ScreenCodeConfig());
        modelBuilder.ApplyConfiguration(new User_CodedGroupConfig());
        modelBuilder.ApplyConfiguration(new ProgramConfig());
        modelBuilder.ApplyConfiguration(new User_CodeConfig());
        modelBuilder.ApplyConfiguration(new TenantCodeConfig());
        modelBuilder.ApplyConfiguration(new UserGroupConfig());
        modelBuilder.ApplyConfiguration(new ApprovalConfig());
        modelBuilder.ApplyConfiguration(new Approval_dConfig());
        modelBuilder.ApplyConfiguration(new ApprovalDelegationConfig());
        modelBuilder.ApplyConfiguration(new UserApprovalConfig());
        modelBuilder.ApplyConfiguration(new UserNotificationConfig());
        modelBuilder.ApplyConfiguration(new MenuLocalizationConfig());
        modelBuilder.ApplyConfiguration(new SeriesConfig());
        modelBuilder.ApplyConfiguration(new SeriesDetailsConfig());
        modelBuilder.ApplyConfiguration(new InspectionCertificateConfig());
        modelBuilder.ApplyConfiguration(new CompanyEquipmentConfig());
        modelBuilder.ApplyConfiguration(new EquipmentAccessoriesConfig());

        modelBuilder.ApplyConfiguration(new JobOrderConfig());
        modelBuilder.ApplyConfiguration(new JobOrderLinesConfig());
        modelBuilder.ApplyConfiguration(new InspectionMethodConfig());
        modelBuilder.ApplyConfiguration(new ServiceItemConfig());
        modelBuilder.ApplyConfiguration(new EquipmentCategoryConfig());
        modelBuilder.ApplyConfiguration(new JobRequestsConfig());
        modelBuilder.ApplyConfiguration(new EmployeesConfig());
        modelBuilder.ApplyConfiguration(new EquipmentMoreInformationConfig());
        modelBuilder.ApplyConfiguration(new EquipmentMoreInformationDetailConfig());
        modelBuilder.ApplyConfiguration(new EquipmentMoreInformationTemplateConfig());
        modelBuilder.ApplyConfiguration(new EquipmentMoreInformationTemplateDetailConfig());
        modelBuilder.ApplyConfiguration(new InspectionChecklistMoreInformationConfig());
        modelBuilder.ApplyConfiguration(new InspectionChecklistMoreInformationDetailConfig());
        modelBuilder.ApplyConfiguration(new InspectionChecklistMoreInformaionTemplateConfig());
        modelBuilder.ApplyConfiguration(new InspectionChecklistMoreInformaionTemplateDetailConfig());
        modelBuilder.ApplyConfiguration(new ChecklistConfiguration());

        // Sales Management
        modelBuilder.ApplyConfiguration(new SalesQuotationConfiguration());
        modelBuilder.ApplyConfiguration(new SalesQuotationLineConfiguration());

        //Inspection Management
        modelBuilder.ApplyConfiguration(new InspectorCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new InspectionTypeConfiguration());

        //SystemConfigurations
        modelBuilder.ApplyConfiguration(new CompanyConfig());
        modelBuilder.ApplyConfiguration(new CurrencyConfig());
        modelBuilder.ApplyConfiguration(new Countriesfiguration());
        modelBuilder.ApplyConfiguration(new CityConfig());
        modelBuilder.ApplyConfiguration(new CurrencyExchangRateConfig());
        modelBuilder.ApplyConfiguration(new OperationConfig());
        modelBuilder.ApplyConfiguration(new TaxTypeConfig());
        modelBuilder.ApplyConfiguration(new CashConfigration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());

        //Accounting
        modelBuilder.ApplyConfiguration(new CostUnitConfig());
        modelBuilder.ApplyConfiguration(new CostCenterConfiguration());
        modelBuilder.ApplyConfiguration(new FiscalYearConfig());
        modelBuilder.ApplyConfiguration(new DetailTableConfig());
        modelBuilder.ApplyConfiguration(new CurrencyExchangRateConfig());
        modelBuilder.ApplyConfiguration(new AccountingPeriodConfig());
        modelBuilder.ApplyConfiguration(new ChartOfAccountConfiguration());
        modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DefaultAccountTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DefaultAccountGroupConfiguration());
        modelBuilder.ApplyConfiguration(new DefaultAccountAssignmentConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierContactConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentTermConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerGroupConfigration());
        modelBuilder.ApplyConfiguration(new SupplierGroupConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new CustomerContactConfig());
        modelBuilder.ApplyConfiguration(new BranchConfigration());
        modelBuilder.ApplyConfiguration(new WarehouseConfigration());
        modelBuilder.ApplyConfiguration(new BankAccountCnfiguration());
        modelBuilder.ApplyConfiguration(new BankCnfiguration());
        modelBuilder.ApplyConfiguration(new UnitOfMeasureConfigration());
        modelBuilder.ApplyConfiguration(new UnitOfMeasureConversionConfigration());
        modelBuilder.ApplyConfiguration(new ItemGroupConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new AssetDepreciationScheduleConfigration());
        modelBuilder.ApplyConfiguration(new AssetTransactionConfiguration());
        modelBuilder.ApplyConfiguration(new AssetGroupConfigration());
        modelBuilder.ApplyConfiguration(new AssetCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new AssetGroupConfigration());
        modelBuilder.ApplyConfiguration(new FixedAssetConfiguration());
        modelBuilder.ApplyConfiguration(new AssetAccountingEventConfiguration());
        modelBuilder.ApplyConfiguration(new AssetAccountingEventAccountConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryBalanceConfiguration());
        modelBuilder.ApplyConfiguration(new GoodsReceiptConfiguration());
        modelBuilder.ApplyConfiguration(new GoodsReceiptLineConfigration());
        modelBuilder.ApplyConfiguration(new SalesPersonConfiguration());
        modelBuilder.ApplyConfiguration(new ModuleSettingConfiguration());
        modelBuilder.ApplyConfiguration(new JournalEntryConfigration());
        modelBuilder.ApplyConfiguration(new JournalEntryLineConfiguration());
        modelBuilder.ApplyConfiguration(new CashReceiptConfiguration());
        modelBuilder.ApplyConfiguration(new CashReceiptLineConfiguration());
        modelBuilder.ApplyConfiguration(new CashReceiptAdjustmentConfiguration());
        modelBuilder.ApplyConfiguration(new SalesInvoiceAllocationConfiguration());
        modelBuilder.ApplyConfiguration(new SalesInvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new SalesInvoiceLineConfiguration());
        modelBuilder.ApplyConfiguration(new CashPaymentConfiguration());
        modelBuilder.ApplyConfiguration(new CashPaymentLineConfiguration());
        modelBuilder.ApplyConfiguration(new CashPaymentAdjustmentConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseInvoiceAllocationConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseInvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseInvoiceLineConfiguration());
        modelBuilder.ApplyConfiguration(new CreditNoteConfiguration());
        modelBuilder.ApplyConfiguration(new CreditNoteLineConfiguration());
        modelBuilder.ApplyConfiguration(new CreditNoteAdjustmentConfiguration());
        modelBuilder.ApplyConfiguration(new DebitNoteConfiguration());
        modelBuilder.ApplyConfiguration(new DebitNoteLineConfiguration());
        modelBuilder.ApplyConfiguration(new DebitNoteAdjustmentConfiguration());
        modelBuilder.ApplyConfiguration(new CashTransferConfiguration());
        modelBuilder.ApplyConfiguration(new CashTransferLineConfiguration());

        // Fixed Assets
        modelBuilder.ApplyConfiguration(new AssetComponentConfiguration());
        modelBuilder.ApplyConfiguration(new AssetMaintenanceConfiguration());
        modelBuilder.ApplyConfiguration(new AssetMaintenanceLineConfiguration());

        // Inspection
        modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        modelBuilder.ApplyConfiguration(new InspectorConfiguration());
        modelBuilder.ApplyConfiguration(new InspectorCompetencyConfiguration());
        modelBuilder.ApplyConfiguration(new InspectorCompetencyLineConfiguration());
        modelBuilder.ApplyConfiguration(new ChecklistTemplateLineConfigration());
        modelBuilder.ApplyConfiguration(new ChecklistTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new AccreditationBodyConfiguration());
        modelBuilder.ApplyConfiguration(new AccreditationBodyLineConfiguration());

        // DMS
        modelBuilder.ApplyConfiguration(new FolderConfiguration());
        modelBuilder.ApplyConfiguration(new FolderPermissionConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ModeOfPaymentConfiguration());
        modelBuilder.ApplyConfiguration(new JournalEntryTemplateConfigration());
        modelBuilder.ApplyConfiguration(new JournalEntryTemplateLineConfigration());
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentTagConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentShareConfiguration());
        modelBuilder.ApplyConfiguration(new ShareAccessLogConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentCommentConfiguration());

        // Inventory
        modelBuilder.ApplyConfiguration(new ItemReorderPerWarehouseConfiguration());
        modelBuilder.ApplyConfiguration(new ItemAttributeConfiguration());
        modelBuilder.ApplyConfiguration(new ItemAttributeValueConfiguration());
        modelBuilder.ApplyConfiguration(new GoodsTransferOutConfiguration());
        modelBuilder.ApplyConfiguration(new GoodsTransferOutLineConfiguration());
        modelBuilder.ApplyConfiguration(new GoodsTransferInConfiguration());
        modelBuilder.ApplyConfiguration(new GoodsTransferInLineConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryOpeningBalanceConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryOpeningBalanceLineConfiguration());

        // Accounting - Posting Engine
        modelBuilder.ApplyConfiguration(new PostingDocumentTypeConfig());
        modelBuilder.ApplyConfiguration(new PostingAccountMappingConfig());

        modelBuilder.ApplyConfiguration(new LedgerConfig());
        modelBuilder.ApplyConfiguration(new LedgerLineConfig());

        // Account Balance
        modelBuilder.ApplyConfiguration(new AccountBalanceConfiguration());
        modelBuilder.ApplyConfiguration(new ItemVariantAttributeConfiguration());

        // Contracting
        modelBuilder.ApplyConfiguration(new CommitmentConfig());
        modelBuilder.ApplyConfiguration(new CommitmentLinesConfig());
        modelBuilder.ApplyConfiguration(new BOQConfiguration());
        modelBuilder.ApplyConfiguration(new BOQLineConfiguration());
        modelBuilder.ApplyConfiguration(new SubcontractBOQConfiguration());
        modelBuilder.ApplyConfiguration(new SubcontractBOQLineConfiguration());

        // Manufacturing
        modelBuilder.ApplyConfiguration(new ProductionOrderConfig());
        modelBuilder.ApplyConfiguration(new ProductionOrderLineConfig());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}