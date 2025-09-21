namespace EducationManagementSystem.Models
{
    public class Subject
    {
        public Guid SubjectId {  get; set; }
        public string SubjectName { get; set; }

        //FK 
        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public ICollection<SubjectExamMapping> StudentExam { get; set; }

    }
}
