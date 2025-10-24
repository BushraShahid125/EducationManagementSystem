using EducationManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IConfidentialNoteRepository
{
    Task<IEnumerable<ConfidentialNote>> GetByStudentIdAsync(string studentId);
    Task<ConfidentialNote?> GetByNoteIdAsync(int noteid);
    Task<ConfidentialNote> AddNoteAsync(ConfidentialNote note);
    Task<ConfidentialNote> UpdateNoteAsync(ConfidentialNote note);
}