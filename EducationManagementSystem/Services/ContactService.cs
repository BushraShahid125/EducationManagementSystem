using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementSystem.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context)
        {
            _context = context;
        }

        //  AddContact
        public async Task<Contact> AddContactAsync(ContactCreateViewModel model)
        {
            var contact = new Contact
            {
                ContactName = model.ContactName,
                Mobile = model.Mobile,
                Email = model.Email,
                GobTitle = model.JobTitle,
                Report = model.Report,
                Trigger = model.Trigger,
                ClientId = model.ClientId
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        // GetAllContacts with optional search
        public async Task<List<Contact>> GetAllContactsAsync(string? searchName = null)
        {
            var query = _context.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(c => c.ContactName.Contains(searchName));
            }

            return await query.ToListAsync();
        }

        //  GetContactById
        public async Task<List<Contact>> GetContactsByStudentAsync(string studentId)
        {
            return await _context.StudentContactMappings
                                 .Where(x => x.StudentId == studentId)
                                 .Select(x => x.Contact)
                                 .ToListAsync();
        }

        //   AssignContactToStudent
        public async Task AssignContactsToStudentAsync(string studentId, List<ContactSelection> contactSelections)
        {
            var existingMappings = await _context.StudentContactMappings
                .Where(m => m.StudentId == studentId)
                .ToListAsync();

            var existingContactIds = existingMappings.Select(m => m.ContactId).ToHashSet();

            foreach (var cs in contactSelections)
            {
                if (cs.IsSelected && !existingContactIds.Contains(cs.ContactId))
                {
                    // Add new mapping
                    _context.StudentContactMappings.Add(new StudentContactMapping
                    {
                        StudentId = studentId,
                        ContactId = cs.ContactId
                    });
                }
                else if (!cs.IsSelected && existingContactIds.Contains(cs.ContactId))
                {
                    // Remove mapping
                    var mappingToRemove = existingMappings.First(m => m.ContactId == cs.ContactId);
                    _context.StudentContactMappings.Remove(mappingToRemove);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
