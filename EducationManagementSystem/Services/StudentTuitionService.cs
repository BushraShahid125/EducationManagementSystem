using EducationManagementSystem.Common;
using EducationManagementSystem.ViewModels;

public class StudentTuitionService : IStudentTuitionService
{
    private readonly IStudentTuitionRepository _repository;

    public StudentTuitionService(IStudentTuitionRepository repository)
    {
        _repository = repository;
    }

    public async Task<StudentTuitionResponseViewModel?> GetStudentTuitionAsync(string studentId)
    {
        var tuition = await _repository.GetStudentTuitionByIdAsync(studentId);
        if (tuition == null) return null;

        return Mapper.MapStudentTuitionToTuitionResponse(tuition);
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