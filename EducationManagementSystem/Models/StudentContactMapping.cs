using System.ComponentModel.DataAnnotations;

namespace EducationManagementSystem.Models
{
    public class StudentContactMapping
    {
        [Key]
        public int StudentContactMappingId { get; set; }
        public String StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
