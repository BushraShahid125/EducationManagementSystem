using System.ComponentModel.DataAnnotations;

namespace EducationManagementSystem.ViewModels
{
    public class ClassRequestViewModel
    {
        [Required]
        public string ClassName { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        public string InchargeId { get; set; } 
    }
    public class ClassResponseViewModel
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string InchargeName { get; set; }
        public string InchargeId { get; set; }
        public int StudentCount { get; set; }
    }
   
    public class ClassUpdateViewModel
    {
        public string? ClassName { get; set; }
        public string? Section { get; set; }
        public string? InchargeId { get; set; }
    }
    public class AddStudentToClassViewModel
    {
        public Guid ClassId { get; set; }
        public string StudentId { get; set; }
    }
}
