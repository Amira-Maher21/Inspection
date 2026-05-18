namespace Inspection.Application.Contracts.Dto.Inspection.JobOrderDashboard
{
    public class JobOrderDashboardDto
    {
        #region Job Orders Summary
        public int TotalJobOrders { get; set; }
        public int ActiveJobs { get; set; }
        public int CompletedJobs { get; set; }
        public int CancelledJobs { get; set; }
        public int JobsStartingToday { get; set; }
        public int DelayedJobs { get; set; }
        public double JobDelayRate { get; set; }
        #endregion

        #region Service KPIs
        public int TotalServicesRequested { get; set; }
        public int ServicesCompleted { get; set; }
        public int PendingServices { get; set; }
        public double ServiceCompletionRate { get; set; }
        #endregion

        #region Time KPIs
        public double AvgJobDurationHours { get; set; }
        public double AvgTurnaroundTimeHours { get; set; }
        #endregion

        #region Inspectors KPIs
        public int TotalInspectors { get; set; }
        public int ActiveInspectorsToday { get; set; }
        public double JobsPerInspector { get; set; }
        public List<InspectorUtilizationDto> InspectorUtilization { get; set; } = new List<InspectorUtilizationDto>();
        public double InspectorUtilizationPercent { get; set; }
        public int AvailableInspectors { get; set; }
        #endregion

        #region Equipment KPIs
        public int TotalEquipmentInspected { get; set; }
        public int PassedInspections { get; set; }
        public int FailedInspections { get; set; }
        public double EquipmentFailureRate { get; set; }
        #endregion

        #region Certificates KPIs
        public int CertificatesIssued { get; set; }
        public int CertificatesIssuedToday { get; set; }
        public int CertificatesIssuedThisMonth { get; set; }
        public int PendingCertificates { get; set; }
        #endregion

        #region Scheduling KPIs
        public int ScheduledInspectionsToday { get; set; }
        #endregion

        #region On-Time & Inspection KPIs
        public double OnTimeCompletionRate { get; set; }
        public double InspectionFailureRate { get; set; }
        #endregion

        #region Revenue KPIs
        public decimal TotalRevenue { get; set; }
        public decimal RevenuePerJob { get; set; }
        #endregion




    }

    public class InspectorUtilizationDto
    {
        public long InspectorId { get; set; }
        public double UtilizationPercent { get; set; }
    }
}