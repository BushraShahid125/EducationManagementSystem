namespace EducationManagementSystem.Models
{
    public class HomeWork
    {
        public int HomeWorkId { get; set; }
        public DateTime Date { get; set; }
        //   FK
        public Guid SubjectId { get; set; }
        public  Subject  Subject { get; set; }
        public String TutorId { get; set; }
        public ApplicationUser Tuitor { get; set; }

        public ICollection<ApplicationUser> Student { get; set; }
    }
}
