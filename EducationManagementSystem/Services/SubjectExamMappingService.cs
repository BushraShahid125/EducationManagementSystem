using EducationManagementSystem.ViewModels;
using EducationManagementSystem.Models;
using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IService;

public class SubjectExamMappingService : ISubjectExamMappingService
{
    private readonly ISubjectExamMappingRepository _repository;

    public SubjectExamMappingService(ISubjectExamMappingRepository repository)
    {
        _repository = repository;
    }

    public async Task<SubjectExamMappingResponseViewModel> CreateAsync(SubjectExamMappingRequestViewModel request)
    {
        var mapping = Mapper.MapRequestToSubjectExamMapping(request);

        var entity = await _repository.AddAsync(mapping);

        return Mapper.MapSubjectExamMappingToResponse(entity);
    }

    public async Task<IEnumerable<SubjectExamMappingResponseViewModel>> GetAllAsync()
    {
        var mappings = await _repository.GetAllAsync();
        return mappings.Select(Mapper.MapSubjectExamMappingToResponse);
    }
}
