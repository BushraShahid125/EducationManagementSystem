namespace EducationManagementSystem.Models
{
    public class StudentGroup
    {
        public Guid StudentGroupId { get; set; }
        public string GroupName { get; set; }
        public string PostCode { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}