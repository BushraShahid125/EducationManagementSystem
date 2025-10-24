using EducationManagementSystem.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IConfidentialNoteService
{
    Task<IEnumerable<ConfidentialNoteResponseViewModel>> GetByStudentIdAsync(string studentId);
    Task<ConfidentialNoteResponseViewModel> AddNoteAsync(ConfidentialNoteRequestViewModel model);
    Task<ConfidentialNoteResponseViewModel> UpdateNoteAsync(int noteid, ConfidentialNoteUpdateViewModel model);
}