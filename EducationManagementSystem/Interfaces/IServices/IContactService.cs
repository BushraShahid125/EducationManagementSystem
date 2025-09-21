using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IService
{
    public interface IContactService
    {
        Task<Contact> AddContactAsync(ContactCreateViewModel dto);
        Task<List<Contact>> GetAllContactsAsync(string? searchName = null);
        Task<List<Contact>> GetContactsByStudentAsync(string studentId);
        Task AssignContactsToStudentAsync(string studentId, List<ContactSelection> contactSelections);
    }
}