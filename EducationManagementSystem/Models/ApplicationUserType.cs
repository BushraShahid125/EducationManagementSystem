namespace EducationManagementSystem.Models
{
    public class ApplicationUserType
    {
        public int ApplicationUserTypeId { get; set; }
        public string Type { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
