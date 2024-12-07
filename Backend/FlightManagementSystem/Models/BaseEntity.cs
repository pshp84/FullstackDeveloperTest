using System.ComponentModel.DataAnnotations;

namespace FlightManagementSystem.Models
{
    public class BaseEntity
    {
        public Guid? Id { get; set; }

        [MaxLength(450)]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        
        [MaxLength(450)]
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
