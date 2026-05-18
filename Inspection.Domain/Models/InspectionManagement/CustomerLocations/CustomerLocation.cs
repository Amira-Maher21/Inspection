using Inspection.Domain.Models.Accounting.AR.MasterData;
using NDS.Shared.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.CustomerLocations
{
    public class CustomerLocation : IRootEntity
    {

        public long Id { get; set; }

        [ForeignKey("Customers")]
        public long? CustomerId { get; set; }
        public Customer Customers { get; set; }


        public string Location { get; set; }
        public string? BuildingNumber { get; set; }
        public string? StreetName { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? AdditionalNumber { get; set; }
        public string? GPSLatitude { get; set; }
        public string? GPSLongitude { get; set; }
        public string? Notes { get; set; }
    }
}
