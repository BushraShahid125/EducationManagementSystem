namespace EducationManagementSystem.Models
{
    public class Subject
    {
        public Guid SubjectId {  get; set; }
        public string SubjectName { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<SubjectExamMapping> StudentExam { get; set; }
    }
}
