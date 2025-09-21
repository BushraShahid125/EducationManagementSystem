using System.Collections.Generic;
namespace EducationManagementSystem.ViewModels

{
    public class AddContactsToStudentViewModel
    {
        public string StudentId { get; set; }
        public List<ContactSelection> Contacts { get; set; }
    }

    public class ContactSelection
    {
        public int ContactId { get; set; }
        public bool IsSelected { get; set; }
    }
}
