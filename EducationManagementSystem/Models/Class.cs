using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationManagementSystem.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; } 

        [Required]
        [StringLength(5)]
        public string Section { get; set; } 

        [ForeignKey("Incharge")]
        public string? InchargeId { get; set; } 

        public virtual ApplicationUser? Incharge { get; set; }
        public virtual ICollection<ApplicationUser>? Students { get; set; }
    }
}
