using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EducationManagementSystem.Common;

public class StudentSubjectService : IStudentSubjectService
{
    private readonly IStudentSubjectRepository _repository;
    private readonly ISubjectExamMappingRepository _mappingRepository;

    public StudentSubjectService(IStudentSubjectRepository repository, ISubjectExamMappingRepository mappingRepository)
    {
        _repository = repository;
        _mappingRepository = mappingRepository;
    }

    public async Task<StudentSubjectResponseViewModel> AssignAsync(StudentSubjectRequestViewModel request)
    {
        var existingSubjects = await _repository.GetByStudentIdAsync(request.StudentId);
        if (existingSubjects.Count() >= 5)
            return null;

        if (existingSubjects.Any(x => x.SubjectExamMapping.SubjectId == request.SubjectId &&
                                  x.SubjectExamMapping.ExamId == request.ExamBoardId))
            return null;

        var mapping = await _mappingRepository.GetMappingAsync(request.SubjectId, request.ExamBoardId);
        if (mapping == null)
            return null;

        var studentSubject = Mapper.MapRequestToStudentSubject(request, mapping);
        var savedEntity = await _repository.AddAsync(studentSubject);
        return Mapper.MapStudentSubjectToResponseViewModel(savedEntity);
    }

    public async Task<IEnumerable<StudentSubjectResponseViewModel>> GetStudentSubjectsAsync(string studentId)
    {
        var entities = await _repository.GetByStudentIdAsync(studentId);
        return entities.Select(Mapper.MapStudentSubjectToResponseViewModel);
    }

    public async Task RemoveAsync(Guid studentSubjectId)
    {
        await _repository.RemoveAsync(studentSubjectId);
    }
}
