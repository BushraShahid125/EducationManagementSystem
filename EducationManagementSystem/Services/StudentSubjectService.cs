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
            throw new Exception("Maximum 5 subjects can be assigned.");

        if (existingSubjects.Any(x => x.SubjectExamMapping.SubjectId == request.SubjectId &&
                                  x.SubjectExamMapping.ExamId == request.ExamBoardId))
        {
            throw new Exception("This subject with the selected exam board is already assigned to the student.");
        }

        var mapping = await _mappingRepository.GetMappingAsync(request.SubjectId, request.ExamBoardId);
        if (mapping == null)
            throw new Exception("Invalid Subject and Exam Board mapping.");

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
