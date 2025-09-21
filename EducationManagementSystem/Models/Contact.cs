using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string GobTitle { get; set; }
        public string Report { get; set; }
        public ReportTrigger Trigger { get; set; }

        public String ClientId { get; set; }
        [ForeignKey("ClientId")]
        public ApplicationUser Client {  get; set; }
        public ICollection<StudentContactMapping> StudentContacts { get; set; }
    }
}
