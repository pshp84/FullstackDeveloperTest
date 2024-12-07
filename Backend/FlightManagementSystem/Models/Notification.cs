using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class Notification : BaseEntity
    { 
        public Guid UserId { get; set; }
        public string FlightDetails { get; set; }

        [MaxLength(1000)]
        public string Status { get; set; } 
    }
}