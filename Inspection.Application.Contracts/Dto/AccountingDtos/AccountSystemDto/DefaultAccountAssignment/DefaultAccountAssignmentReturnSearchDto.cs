public class DefaultAccountAssignmentReturnSearchDto
{
    public long Id { get; set; }
    public string Tenant_ID { get; set; } = string.Empty;

    // Account Group
    public long DefaultAccountGroupID { get; set; }
    public string GroupCode { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;


    public long DefaultAccountTypeID { get; set; }
    public string DefaultAccountTypeCode { get; set; } = string.Empty;


    // Chart Of Account
    public long AccountID { get; set; }
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;

    public long CurrencyID { get; set; }



}
