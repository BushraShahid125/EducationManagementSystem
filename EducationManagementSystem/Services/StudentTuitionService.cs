using EducationManagementSystem.Common;
using EducationManagementSystem.ViewModels;

public class StudentTuitionService : IStudentTuitionService
{
    private readonly IStudentTuitionRepository _repository;
    //private readonly ILessonRepository _lessonRepository;

    public StudentTuitionService(IStudentTuitionRepository repository)
    {
        _repository = repository;
        //_lessonRepository=lessonRepository;
    }

    public async Task<StudentTuitionResponseViewModel?> GetStudentTuitionAsync(string studentId)
    {
        var tuition = await _repository.GetStudentTuitionByIdAsync(studentId);
        if (tuition == null) 
            return null;
        //var completedSessions = await _lessonRepository.GetCompletedSessionsAsync(studentId);

        var response = Mapper.MapStudentTuitionToTuitionResponse(tuition);

        //response.SessionsCompleted = completedSessions;

        //if (tuition.EnrolledSession <= 0)
        //{
        //    response.SessionRemaining = 0;
        //}
        //else
        //{
        //    response.SessionRemaining = Math.Max(0, tuition.EnrolledSession - completedSessions);
        //}

        return response;
    }

    public async Task<StudentTuitionResponseViewModel> AddOrUpdateStudentTuitionAsync(StudentTuitionRequestViewModel model)
    {
        var student = await _repository.GetStudentTuitionByIdAsync(model.StudentId);
        if (student == null)
            return null; 

        Mapper.MapStudentToStudentTuitionRequest(model, student);
        var updatedStudent = await _repository.AddOrUpdateStudentTuitionAsync(student);
        var response = Mapper.MapStudentTuitionToTuitionResponse(updatedStudent);
        return response;
    }
}