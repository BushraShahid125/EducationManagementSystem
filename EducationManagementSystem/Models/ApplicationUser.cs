using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Models
{
    public class ApplicationUser : IdentityUser 
    {
        //   Common
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Building { get; set; }
        public string? Street { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
        public string? Mobile { get; set; }
        public string? UserEmail { get; set; }
        public bool AppStatus { get; set; }

        // Student
        public bool? IsMale { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PreferredName { get; set; }
        public String? ClientId { get; set; }
        [ForeignKey("ClientId")]
        [InverseProperty("ClientStudents")]
        public ApplicationUser Client { get; set; }

        //  Student Profile
        public string? School { get; set; }
        public string? SchoolYear { get; set; }
        public string? CurrentLevel { get; set; }
        public string? Summary { get; set; }
        public string? SEN { get; set; }
        public string? LearningObjectives { get; set; }
  
        // StudentTuition
        public int? SessionsPerWeek { get; set; }
        public string? SesstionLength { get; set; }
        public int? EnrolledSession {  get; set; }
        public Guid? VenueId { get; set; }
        public Venue Venue { get; set; }
        public string? GuardianId { get; set;}
        public ApplicationUser Guardian { get; set; }
        public string? LocationNotes { get; set; }
        public bool? MondayAM { get; set; }
        public bool? MondayPM { get; set; }
        public bool? TuesdayAM { get; set; }
        public bool? TuesdayPM { get; set; }
        public bool? WednesdayAM { get; set; }
        public bool? WednesdayPM { get; set; }
        public bool? ThursdayAM { get; set; }
        public bool? ThursdayPM { get; set; }
        public bool? FridayAM { get; set; }
        public bool? FridayPM { get; set; }
        public bool? SaturdayAM { get; set; }
        public bool? SaturdayPM { get; set; }
        public bool? SundayAM { get; set; }
        public bool? SundayPM { get; set; }

        //   Subjects
        public Guid? SubjectExamMappingId { get; set; }

        //   Guardian
        public string? Guardian2FirstName { get; set; }
        public string? Guardian2LastName { get; set; }
        public string? Guardian2Mobile { get; set; }
        public string? Guardin2Email { get; set;}
        public int? Guardian2Building { get; set; }
        public string? Guardian2Street { get; set; }
        public string? Guardian2AddressLine2 { get; set; }
        public string? Guardian2Town { get; set; }
        public string? Guardian2County { get; set; }
        public string? Guardian2PostCode { get; set; }
        public string? Guardian2Country { get; set; }
        public string? Guardian2Profile { get; set; }
        public string? Profile { get; set; }
        public string? SafeguardingLeadContact { get; set; }
        // Client
        public string? ContactTelephone { get; set; }
        public string? ContactEmail { get; set; }
        //  Tuitor
        public bool IsArchived { get; set; }

        public int ApplicationUserTypeId { get; set; }  
        [ForeignKey("ApplicationUserTypeId")]
        public ApplicationUserType UserType { get; set; }

        [InverseProperty("Tutor")]
        public ICollection<Incident> TutorIncidents { get; set; }
        [InverseProperty("Student")]
        public ICollection<Incident> StudentIncidents { get; set; }
        public ICollection<StudentContactMapping> StudentContacts { get; set; }
        [InverseProperty("FromUser")]
        public ICollection<Message> SentMessages { get; set; }

        [InverseProperty("ToUser")]
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<Contact> contacts { get; set; }
        [InverseProperty("Tutor")]
        public ICollection<Lesson> TutorLessons { get; set; }
        [InverseProperty("Client")]
        public ICollection<Lesson> ClientLessons { get; set; }
        [InverseProperty("Tutor")]
        public ICollection<ConfidentialNote> TutorConfidentialNotes { get; set; }
        [InverseProperty("Student")]
        public ICollection<ConfidentialNote> StudentConfidentialNotes { get; set; }
        [InverseProperty("Client")]
        public ICollection<ApplicationUser> ClientStudents { get; set; }
        public ICollection<LessonStudentMapping> LessonStudents { get; set; }

        [InverseProperty("Guardian")]
        public ICollection<ApplicationUser> Students { get; set; }
    }
}
