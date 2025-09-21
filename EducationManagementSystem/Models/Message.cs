using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationManagementSystem.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public DateOnly DateSend { get; set; }
        public string Content { get; set; }

        // FK
        public string FromUserId { get; set; }
        [ForeignKey("FromUserId")]
        [InverseProperty("SentMessages")]
        public ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }
        [ForeignKey("ToUserId")]
        [InverseProperty("ReceivedMessages")]
        public ApplicationUser ToUser { get; set; }
    }
}
