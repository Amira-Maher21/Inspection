using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF
{
    public class JobOrderLinegGetListDto
    {

        [Key]
        public long Id { get; set; }
        public long InspectorId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime ScheduledFromTime { get; set; }
        public DateTime ScheduledToTime { get; set; }




    }

}
