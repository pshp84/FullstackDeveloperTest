using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class User : BaseEntity
    {
        [MaxLength(200)]
        public string UserName { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }
        public string MobileToken { get; set; } 
    }
}
