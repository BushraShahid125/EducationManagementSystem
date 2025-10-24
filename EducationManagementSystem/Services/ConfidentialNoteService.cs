using EducationManagementSystem.ViewModels;
using EducationManagementSystem.Models;
using EducationManagementSystem.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ConfidentialNoteService : IConfidentialNoteService
{
    private readonly IConfidentialNoteRepository _repository;

    public ConfidentialNoteService(IConfidentialNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ConfidentialNoteResponseViewModel>> GetByStudentIdAsync(string studentId)
    {
        var notes = await _repository.GetByStudentIdAsync(studentId);
        if (notes == null)
            return null;
        return 
            notes.Select(Mapper.MapConfidentialNoteToConfidentialNoteResponseViewModel);
    }

    public async Task<ConfidentialNoteResponseViewModel> AddNoteAsync(ConfidentialNoteRequestViewModel model)
    {
        var entity = Mapper.MapConfidentialNoteRequestViewModelToConfidentialNote(model);
        var added = await _repository.AddNoteAsync(entity);
        return 
            Mapper.MapConfidentialNoteToConfidentialNoteResponseViewModel(added);
    }

    public async Task<ConfidentialNoteResponseViewModel> UpdateNoteAsync(int noteid, ConfidentialNoteUpdateViewModel model)
    {
        var existing = await _repository.GetByNoteIdAsync(noteid);
        if (existing == null)
            return null;

        Mapper.MapConfidentialNoteUpdateViewModeToConfidentialNote(model, existing);
        var updated = await _repository.UpdateNoteAsync(existing);
        return Mapper.MapConfidentialNoteToConfidentialNoteResponseViewModel(updated);
    }
}
