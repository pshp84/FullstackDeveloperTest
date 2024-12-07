using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.DTOs
{
    public class NotificationReqDTO
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public string FlightDetails { get; set; }

        [MaxLength(1000)]
        public string Status { get; set; }
    }
}
