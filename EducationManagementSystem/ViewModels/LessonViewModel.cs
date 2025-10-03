using System.ComponentModel.DataAnnotations;
using static EducationManagementSystem.Common.Enums;

public class LessonRequestViewModel
{
    [DataType(DataType.Date)]
    public DateOnly DateOfLesson { get; set; }
    public TimeOnly StartTime { get; set; }
    public LessonDuration Duration { get; set; }
    public string SubjectId { get; set; }
    public string TutorId { get; set; }
    public string StudentId { get; set; }
    public Guid VenueId { get; set; }
    public int TeachingYear { get; set; }
    public ClassFormat Format { get; set; }
}

public class LessonUpdateViewModel
{
    public TimeOnly StartTime { get; set; }
    public LessonDuration Duration { get; set; }
    public int TeachingYear { get; set; }
    public ClassFormat Format { get; set; }
    public Guid VenueId { get; set; }
    public string SubjectId { get; set; }
    public string TutorId { get; set; }
    public string StudentId { get; set; }
}

public class LessonResponseViewModel
{
    public int LessonId { get; set; }
    public string DateOfLesson { get; set; }
    public string StartTime { get; set; }
    public string Duration { get; set; }
    public string SubjectName { get; set; }
    public string VenueName { get; set; }
    public string StudentName { get; set; }
    public string TutorName { get; set; }
    public int TeachingYear { get; set; }
    public string Format { get; set; }
}
