namespace EducationManagementSystem.Models
{
    public class StudentSubject
    {
        public Guid StudentSubjectId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int SubjectExamMappingId { get; set; }
        public SubjectExamMapping SubjectExamMapping { get; set; }
    }
}