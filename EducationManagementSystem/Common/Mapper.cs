using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Common
{
    public class Mapper
    {
        //  Client
        public static ClientResponseViewModel MapClientToClientResponseViewModel(ApplicationUser model)
        {
            if(model==null)
            {
                return null;
            }
            return new ClientResponseViewModel
            {
                ClientId = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Mobile,
                ContactTelephone = model.ContactTelephone,
                ContactEmail = model.ContactEmail,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode,
                Country = model.Country,
                AppStatus = model.AppStatus,
            };
        }

        //         Students
        public static StudentResponseViewModel MapStudentToStudentResponseViewModel(ApplicationUser student)
        {
            if(student==null)
            {
                return null;
            }
            return new StudentResponseViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PreferredName = student.PreferredName,
                IsMale = student.IsMale,
                DateOfBirth = student.DateOfBirth,
                Building = student.Building,
                Street = student.Street,
                AddressLine2 = student.AddressLine2,
                Town = student.Town,
                County = student.County,
                PostCode = student.PostCode,
                Country = student.Country,
                ClientId = student.ClientId,
            };
        }

        //     Contacts
        public static ContactResponseViewModel MapContactToContactResponseViewModel(Contact model)
        {
            if(model==null)
            {
                return null;
            }
            return new ContactResponseViewModel
            {
                ContactId = model.ContactId,
                ContactName = model.ContactName,
                Mobile = model.Mobile,
                Email = model.Email,
                JobTitle = model.GobTitle,
                Report = model.Report,
                Trigger = model.Trigger,
                ClientId = model.ClientId
            };
        }

        // Student Profile
        public static StudentProfileViewModel MapStudentToStudentProfileViewModel(ApplicationUser student)
        {
            if (student == null)
                return null;

            return new StudentProfileViewModel
            {
                StudentId = student.Id,
                School = student.School,
                SchoolYear = student.SchoolYear,
                CurrentLevel = student.CurrentLevel,
                Summary = student.Summary,
                SEN = student.SEN,
                LearningObjectives = student.LearningObjectives
            };
        }

        public static void MapStudentProfileViewModelToStudent(StudentProfileViewModel model, ApplicationUser student)
        {
            if (model == null || student == null)
                return;

            student.School = model.School;
            student.SchoolYear = model.SchoolYear;
            student.CurrentLevel = model.CurrentLevel;
            student.Summary = model.Summary;
            student.SEN = model.SEN;
            student.LearningObjectives = model.LearningObjectives;
        }

        //   Venue
        public static VenueResponseViewModel MapVenueToVenueResponseViewModel(Venue model)
        {
            if (model == null)
                return null;

            return new VenueResponseViewModel
            {
                VenueId = model.VennueId,
                VenueName = model.VennueName,
                PostCode = model.PostCode,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                Country = model.Country,
                LongandLat = model.LongandLat,               
            };
        }

        public static VenueListViewModel MapVenueToVenueListViewModel(Venue model)
        {
            if (model == null)
                return null;

            return new VenueListViewModel
            {
                VenueName = model.VennueName,
                PostCode = model.PostCode,
                Location = $"{model.Street},{model.County},{model.Country}"
            };
        }

        public static Venue MapVenueRequestViewModelToVenue(VenueRequestViewModel model)
        {
            return new Venue
            {
                VennueName = model.VenueName,
                PostCode = model.PostCode,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                Country = model.Country,
                LongandLat = model.LongandLat
            };
        }

        // Guardian
        public static ApplicationUser MapRequestToGuardian(GuardianRequestViewModel model)
        {
            return new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Email = model.Email,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode,
                Country = model.Country,
                Profile = model.Profile,
                Guardian2FirstName = model.Guardian2FirstName,
                Guardian2LastName = model.Guardian2LastName,
                Guardian2Mobile = model.Guardian2Mobile,
                Guardin2Email = model.Guardian2Email,
                Guardian2Building = model.Guardian2Building,
                Guardian2Street = model.Guardian2Street,
                Guardian2AddressLine2 = model.Guardian2AddressLine2,
                Guardian2Town  = model.Guardian2Town,
                Guardian2County = model.Guardian2County,
                Guardian2PostCode = model.Guardian2PostCode,
                Guardian2Country = model.Guardian2Country,
                Guardian2Profile = model.Guardian2Profile,
                SafeguardingLeadContact = model.SafeguardingLeadContact,
                ApplicationUserTypeId = (int)ApplicationUserTypeEnum.Guardian,
                AppStatus = model.AppStatus
            };
        }

        public static GuardianResponseViewModel MapGuardianToResponseViewModel(ApplicationUser guardian)
        {
            if (guardian == null) 
                return null;

            return new GuardianResponseViewModel
            {
                GuardianId = guardian.Id,
                FirstName = guardian.FirstName,
                LastName = guardian.LastName,
                Mobile = guardian.Mobile,
                Email = guardian.Email,
                Building = guardian.Building,
                Street = guardian.Street,
                AddressLine2 = guardian.AddressLine2,
                Town = guardian.Town,
                County = guardian.County,
                PostCode = guardian.PostCode,
                Country = guardian.Country,
                Profile = guardian.Profile,
                Guardian2FirstName = guardian.Guardian2FirstName,
                Guardian2LastName = guardian.Guardian2LastName,
                Guardian2Mobile = guardian.Guardian2Mobile,
                Guardian2Email = guardian.Guardin2Email,
                Guardian2Building = guardian.Guardian2Building,
                Guardian2Street = guardian.Guardian2Street,
                Guardian2AddressLine2 = guardian.Guardian2AddressLine2,
                Guardian2Town = guardian.Town,
                Guardian2County = guardian.Guardian2County,
                Guardian2PostCode = guardian.Guardian2PostCode,
                Guardian2Country = guardian.Guardian2Country,
                Guardian2Profile = guardian.Guardian2Profile,
                SafeguardingLeadContact = guardian.SafeguardingLeadContact,
                AppStatus = guardian.AppStatus
            };
        }

        public static void MapUpdateToGuardian(GuardianUpdateViewModel model, ApplicationUser guardian)
        {
            if (guardian == null)
                return;

            guardian.FirstName = model.FirstName;
            guardian.LastName = model.LastName;
            guardian.Mobile = model.Mobile;
            guardian.Email = model.Email;
            guardian.Building = model.Building ?? 0;  
            guardian.Street = model.Street;
            guardian.AddressLine2 = model.AddressLine2;
            guardian.Town = model.Town;
            guardian.County = model.County;
            guardian.PostCode = model.PostCode;
            guardian.Country = model.Country;
            guardian.Profile = model.Profile;
            guardian.Guardian2FirstName = model.Guardian2FirstName;
            guardian.Guardian2LastName = model.Guardian2LastName;
            guardian.Guardian2Mobile = model.Guardian2Mobile;
            guardian.Guardin2Email = model.Guardian2Email;
            guardian.Guardian2Building = model.Guardian2Building;  
            guardian.Guardian2Street = model.Guardian2Street;
            guardian.Guardian2AddressLine2 = model.Guardian2AddressLine2;
            guardian.Guardian2Town = model.Guardian2Town;
            guardian.Guardian2County = model.Guardian2County;
            guardian.Guardian2PostCode = model.Guardian2PostCode;
            guardian.Guardian2Country = model.Guardian2Country;
            guardian.Guardian2Profile = model.Guardian2Profile;
            guardian.SafeguardingLeadContact = model.SafeguardingLeadContact;
            guardian.AppStatus = model.AppStatus ?? false; 
        }

        public static GuardianListViewModel MapGuardianToGuardianListViewModel(ApplicationUser model)
        {
            if (model == null)
                return null;

            return new GuardianListViewModel
            {
                Name = $"{model.FirstName}{model.LastName}",
                Phone = model.Mobile,
                Email = model.Email,
                SecondContact = $"{model.FirstName}{model.LastName}",
                SecondEmail = model.Guardin2Email,
                StudentName = model.Students.FirstOrDefault() is var student && student != null
                              ? $"{student.FirstName} {student.LastName}" : null,
                AppStatus = model.AppStatus
            };
        }

        //  Student Tuition
        public static void MapStudentToStudentTuitionRequest(StudentTuitionRequestViewModel model, ApplicationUser student)
        {
            if (student == null || model == null)
                return;

            student.SessionsPerWeek = model.SessionsPerWeek;
            student.SesstionLength = model.SessionLength; 
            student.EnrolledSession = model.EnrolledSession;
            student.VenueId = model.VenueId;
            student.LocationNotes = model.LocationNotes;
            student.GuardianId = model.GuardianId;
            student.ClientId = model.ClientId;
            student.MondayAM = model.MondayAM;
            student.MondayPM = model.MondayPM;
            student.TuesdayAM = model.TuesdayAM;
            student.TuesdayPM = model.TuesdayPM;
            student.WednesdayAM = model.WednesdayAM;
            student.WednesdayPM = model.WednesdayPM;
            student.ThursdayAM = model.ThursdayAM;
            student.ThursdayPM = model.ThursdayPM;
            student.FridayAM = model.FridayAM;
            student.FridayPM = model.FridayPM;
            student.SaturdayAM = model.SaturdayAM;
            student.SaturdayPM = model.SaturdayPM;
            student.SundayAM = model.SundayAM;
            student.SundayPM = model.SundayPM;
        }


        public static StudentTuitionResponseViewModel MapStudentTuitionToTuitionResponse(ApplicationUser tuition)
        {
            return new StudentTuitionResponseViewModel
            {
                SessionsPerWeek = tuition.SessionsPerWeek,
                SessionLength = tuition.SesstionLength,
                EnrolledSession = tuition.EnrolledSession,
                VenueId = tuition.VenueId,
                VenueName = tuition.Venue?.VennueName,
                GuardianId = tuition.GuardianId,
                GuardianName = tuition.Guardian?.FirstName + " " + tuition.Guardian?.LastName,
                LocationNotes = tuition.LocationNotes,
                MondayAM = tuition.MondayAM,
                MondayPM = tuition.MondayPM,
                TuesdayAM = tuition.TuesdayAM,
                TuesdayPM = tuition.TuesdayPM,
                WednesdayAM = tuition.WednesdayAM,
                WednesdayPM = tuition.WednesdayPM,
                ThursdayAM = tuition.ThursdayAM,
                ThursdayPM = tuition.ThursdayPM,
                FridayAM = tuition.FridayAM,
                FridayPM = tuition.FridayPM,
                SaturdayAM = tuition.SaturdayAM,
                SaturdayPM = tuition.SaturdayPM,
                SundayAM = tuition.SundayAM,
                SundayPM = tuition.SundayPM
            };
        }
    }
}