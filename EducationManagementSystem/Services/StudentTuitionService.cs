using EducationManagementSystem.Common;
using EducationManagementSystem.ViewModels;
using static EducationManagementSystem.Common.Enums;

public class StudentTuitionService : IStudentTuitionService
{
    private readonly IStudentTuitionRepository _repository;
    private readonly ILessonRepository _lessonRepository;

    public StudentTuitionService(IStudentTuitionRepository repository, ILessonRepository lessonRepository)
    {
        _repository = repository;
        _lessonRepository = lessonRepository;
    }

    public async Task<StudentTuitionResponseViewModel?> GetStudentTuitionAsync(string studentId)
    {
        var tuition = await _repository.GetStudentTuitionByIdAsync(studentId);
        if (tuition == null)
            return null;

        var lessons = await _lessonRepository.GetLessonsByStudentIdAsync(studentId);

        int completedSessions = lessons.Count(l => l.Status == LessonStatus.SessionDelivered);
        int enrolledSessions = lessons.Count();
        int remainingSessions = Math.Max(0, enrolledSessions - completedSessions);

        var response = Mapper.MapStudentTuitionToTuitionResponse(tuition);

        response.EnrolledSession = enrolledSessions;
        response.SessionRemaining = remainingSessions;

        return response;
    }

    public async Task<StudentTuitionResponseViewModel?> AddOrUpdateStudentTuitionAsync(StudentTuitionRequestViewModel model)
    {
        var student = await _repository.GetStudentTuitionByIdAsync(model.StudentId);
        if (student == null)
            return null;

        Mapper.MapStudentToStudentTuitionRequest(model, student);
        var updatedStudent = await _repository.AddOrUpdateStudentTuitionAsync(student);

        var lessons = await _lessonRepository.GetLessonsByStudentIdAsync(model.StudentId);
        int completedSessions = lessons.Count(l => l.Status == LessonStatus.SessionDelivered);
        int enrolledSessions = lessons.Count();
        int remainingSessions = Math.Max(0, enrolledSessions - completedSessions);

        var response = Mapper.MapStudentTuitionToTuitionResponse(updatedStudent);

        response.EnrolledSession = enrolledSessions;
        response.SessionsCompleted = completedSessions;
        response.SessionRemaining = remainingSessions;

        return response;
    }
}
