using EducationManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

public class SubjectExamMapping
{
    [Key]
    public int SubjectExamMappingId { get; set; }

    public Guid SubjectId { get; set; }  
    public Subject Subject { get; set; }

    public Guid ExamId { get; set; }
    public ExamBoard Exam { get; set; }
    public ICollection<StudentSubject> StudentSubjects { get; set; }
}
