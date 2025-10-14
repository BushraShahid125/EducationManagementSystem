using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Common
{
    public class Mapper
    {
        //  Client
        public static ClientResponseViewModel MapClientToClientResponseViewModel(ApplicationUser model)
        {
            if (model==null)
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

        //   Students
        public static StudentResponseViewModel MapStudentToStudentResponseViewModel(ApplicationUser student)
        {
            if (student==null)
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
            if (model==null)
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
                StudentId = tuition.Id,
                SessionsPerWeek = tuition.SessionsPerWeek,
                SessionLength = tuition.SesstionLength,
                Venue = tuition.Venue?.VennueName,
                Guardian = tuition.Guardian?.FirstName + " " + tuition.Guardian?.LastName,
                Client = tuition.Client?.FirstName + " " + tuition.Client?.LastName,
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

        //  HomeWork
        public static HomeWork MapHomeWorkRequestViewModelToHomeWork(HomeWorkRequestViewModel model)
        {
            if (model == null) return null;

            return new HomeWork
            {
                Date = model.Date,
                SubjectId = model.SubjectId,
                TutorId = model.TutorId,
                Description = model.Description
            };
        }

        public static HomeWorkResponseViewModel MapHomeWorkToHomeWorkResponse(HomeWork model)
        {
            if (model == null)
                return null;

            return new HomeWorkResponseViewModel
            {
                HomeWorkId = model.HomeWorkId,
                Date = model.Date,
                Subject = model.Subject?.SubjectName,
                Tutor = model.Tutor?.FirstName + " " + model.Tutor?.LastName,
                Description = model.Description
            };
        }

        public static void MapUpdateToHomeWork(HomeWorkUpdateViewModel model, HomeWork homeWork)
        {
            if (model == null)
                return;

            model.Date = homeWork.Date;
            model.SubjectId = homeWork.SubjectId;
            model.TutorId = homeWork.TutorId;
            model.Description = homeWork.Description;
        }

        //  StudentGroup
        public static StudentGroup MapStudentGroupRequestViewModelToStudentGroup(StudentGroupRequestViewModel model)
        {
            if (model == null)
                return null;
            return new StudentGroup
            {
                GroupName = model.GroupName,
                PostCode  = model.PostCode,
            };
        }

        public static StudentGroupResponseViewModel MapStudentGroupToStudentGroupResponseViewModel(StudentGroup model)
        {
            if (model==null)
                return null;
            return new StudentGroupResponseViewModel
            {
                StudentGroupId = model.StudentGroupId,
                GroupName = model.GroupName,
                PostCode = model.PostCode
            };
        }

        public static StudentGroupListViewModel MapStudentGroupToStudentGroupListViewModel(StudentGroup entity)
        {
            return new StudentGroupListViewModel
            {
                GroupName = entity.GroupName
            };
        }
        public static StudentSubjectResponseViewModel MapStudentSubjectToResponseViewModel(StudentSubject studentSubject)
        {
            return new StudentSubjectResponseViewModel
            {
                StudentSubjectId = studentSubject.StudentSubjectId,
                StudentId = studentSubject.ApplicationUserId,
                SubjectName = studentSubject.SubjectExamMapping.Subject.SubjectName,
                ExamBoardName = studentSubject.SubjectExamMapping.Exam.ExamBoardName
            };
        }

        public static StudentSubject MapRequestToStudentSubject(StudentSubjectRequestViewModel request, SubjectExamMapping mapping)
        {
            return new StudentSubject
            {
                StudentSubjectId = Guid.NewGuid(),
                ApplicationUserId = request.StudentId,
                SubjectExamMappingId = mapping.SubjectExamMappingId
            };
        }

        // Subjects
        public static Subject MapSubjectRequestToSubject(SubjectRequestViewModel model)
        {
            if (model == null)
                return null;

            return new Subject
            {
                SubjectId = Guid.NewGuid(),
                SubjectName = model.SubjectName
            };
        }

        public static void MapSubjectUpdateToSubject(SubjectUpdateViewModel model, Subject subject)
        {
            if (model == null || subject == null)
                return;
            subject.SubjectName = model.SubjectName;
        }

        public static SubjectResponseViewModel MapSubjectToSubjectResponse(Subject model)
        {
            if (model == null)
                return null;

            return new SubjectResponseViewModel
            {
                SubjectId = model.SubjectId,
                SubjectName = model.SubjectName
            };
        }

        //ExamBoard
        public static ExamBoard MapRequestToExamBoard(ExamBoardRequestViewModel model)
        {
            if (model == null) return null;

            return new ExamBoard
            {
                ExamBoardId = Guid.NewGuid(),
                ExamBoardName = model.ExamBoardName
            };
        }

        public static void MapUpdateToExamBoard(ExamBoardUpdateViewModel model, ExamBoard board)
        {
            if (model == null || board == null) return;
            board.ExamBoardName = model.ExamBoardName;
        }

        public static ExamBoardResponseViewModel MapExamBoardToResponse(ExamBoard model)
        {
            if (model == null) return null;

            return new ExamBoardResponseViewModel
            {
                ExamBoardId = model.ExamBoardId,
                ExamBoardName = model.ExamBoardName
            };
        }

        //   SubjectExamMapping
        public static SubjectExamMapping MapRequestToSubjectExamMapping(SubjectExamMappingRequestViewModel model)
        {
            if (model == null) return null;

            return new SubjectExamMapping
            {
                SubjectId = model.SubjectId,
                ExamId = model.ExamBoardId 
            };
        }
        public static SubjectExamMappingResponseViewModel MapSubjectExamMappingToResponse(SubjectExamMapping model)
        {
            if (model == null) return null;

            return new SubjectExamMappingResponseViewModel
            {
                SubjectExamMappingId = model.SubjectExamMappingId,
                SubjectId = model.SubjectId,
                ExamBoardId = model.ExamId 
            };
        }


        // Lesson
        public static Lesson MapLessonRequestToLesson(LessonRequestViewModel model)
        {
            if (model == null)
                return null;

            return new Lesson
            {
                DateofLesson = model.DateOfLesson,
                StartTime = model.StartTime,
                Duration = model.Duration,
                TeachingYear = model.TeachingYear,
                Format = model.Format,
                VenueId = model.VenueId,
                SubjectId = Guid.Parse(model.SubjectId),
                TutorId = model.TutorId,
                StudentId = model.StudentId
            };
        }

        public static void MapLessonUpdateToLesson(LessonUpdateViewModel model, Lesson lesson)
        {
            if (model == null || lesson == null)
                return;

            lesson.StartTime = model.StartTime;
            lesson.Duration = model.Duration;
            lesson.TeachingYear = model.TeachingYear;
            lesson.Format = model.Format;
            lesson.VenueId = model.VenueId;
            lesson.SubjectId = Guid.Parse(model.SubjectId);
            lesson.TutorId = model.TutorId;
            lesson.StudentId = model.StudentId;
        }

        public static LessonResponseViewModel MapLessonToResponse(Lesson lesson)
        {
            if (lesson == null)
                return null;

            return new LessonResponseViewModel
            {
                LessonId = lesson.LessonId,
                DateOfLesson = lesson.DateofLesson.ToString("dd/MM/yyyy"),
                StartTime = lesson.StartTime.ToString("hh\\:mm"),
                Duration = lesson.Duration.ToString(),
                SubjectName = lesson.Subject?.SubjectName,
                VenueName = lesson.Venue?.VennueName,
                StudentName = lesson.Student != null
                             ? lesson.Student.FirstName + " " + lesson.Student.LastName : null,
                TutorName = lesson.Tutor != null
                             ? lesson.Tutor.FirstName + " " + lesson.Tutor.LastName : null,
                TeachingYear = lesson.TeachingYear,
                Format = lesson.Format.ToString()
            };
        }

        //  Tutor
        public static ApplicationUser MapTutorRequestToTutor(TutorRequestViewModel model)
        {
            if (model == null)
                return null;

            return new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                UserName = model.UserEmail,
                Email = model.UserEmail,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode,
                Country = model.Country,
                AppStatus = model.AppStatus,
                IsArchived = false,
                ApplicationUserTypeId = (int)ApplicationUserTypeEnum.Tutor,
            };
        }

        public static void MapTutorUpdateToTutor(TutorUpdateViewModel model, ApplicationUser tutor)
        {
            if (model == null || tutor == null)
                return;

            tutor.FirstName = model.FirstName;
            tutor.LastName = model.LastName;
            tutor.Mobile = model.Mobile;
            tutor.Building = model.Building;
            tutor.Street = model.Street;
            tutor.AddressLine2 = model.AddressLine2;
            tutor.Town = model.Town;
            tutor.County = model.County;
            tutor.PostCode = model.PostCode;
            tutor.Country = model.Country;
            tutor.AppStatus = model.AppStatus;
        }

        public static TutorResponseViewModel MapTutorToResponse(ApplicationUser tutor)
        {
            if (tutor == null)
                return null;

            return new TutorResponseViewModel
            {
                TutorId = tutor.Id,
                FullName = $"{tutor.FirstName} {tutor.LastName}",
                Mobile = tutor.Mobile,
                UserEmail = tutor.UserEmail,
                Building = tutor.Building,
                Street = tutor.Street,
                AddressLine2 = tutor.AddressLine2,
                Town = tutor.Town,
                County = tutor.County,
                PostCode = tutor.PostCode,
                Country = tutor.Country,
                AppStatus = tutor.AppStatus,
                IsArchived = tutor.IsArchived
            };
        }
        // Attendance
        public static void MapAttendanceRequestToLesson(AttendanceRequestViewModel model, Lesson lesson)
        {
            if (model == null || lesson == null)
                return;

            lesson.StudentArrivedTime = model.StudentArrivedTime;
            lesson.TutorArrivedTime = model.TutorArrivedTime;
            lesson.Attendance = model.Attendance;
            lesson.AttendanceDetails = model.AttendanceDetails;
            lesson.Objective = model.Objective;
        }
        public static void MapAttendanceUpdateToLesson(AttendanceUpdateViewModel model, Lesson lesson)
        {
            if (model == null || lesson == null)
                return;

                lesson.StudentArrivedTime = model.StudentArrivedTime;
                lesson.TutorArrivedTime = model.TutorArrivedTime;
                lesson.Attendance = model.Attendance;
                lesson.AttendanceDetails = model.AttendanceDetails;
                lesson.Objective = model.Objective;
        }
        public static AttendanceResponseViewModel MapLessonToAttendanceResponse(Lesson lesson)
        {
            if (lesson == null)
                return null;

            return new AttendanceResponseViewModel
            {
                LessonId = lesson.LessonId,
                StudentArrivedTime = lesson.StudentArrivedTime?.ToString("hh:mm tt"),
                TutorArrivedTime = lesson.TutorArrivedTime?.ToString("hh:mm tt"),
                Attendance = lesson.Attendance?.ToString(),
                AttendanceDetails = lesson.AttendanceDetails,
                Objective = lesson.Objective
            };
        }

        public static Class MapClassRequestToClass(ClassRequestViewModel model)
        {
            if (model == null) 
                return null;

            return new Class
            {
                ClassId = Guid.NewGuid(),
                ClassName = model.ClassName,
                Section = model.Section,
                InchargeId = model.InchargeId
            };
        }

        public static void MapClassUpdateToClass(ClassUpdateViewModel model, Class entity)
        {
            if (model == null || entity == null) 
                return;

                entity.ClassName = model.ClassName;
                entity.Section = model.Section;
                entity.InchargeId = model.InchargeId;
        }

        public static ClassResponseViewModel MapClassToClassResponse(Class entity)
        {
            if (entity == null) 
                return null;

            return new ClassResponseViewModel
            {
                ClassId = entity.ClassId,
                ClassName = entity.ClassName,
                Section = entity.Section,
                InchargeId = entity.InchargeId,
                InchargeName = entity.Incharge?.FirstName ?? "Not Assigned",
                StudentCount = entity.Students?.Count ?? 0
            };
        }

        //  Attendance
        public static List<Attendance> MapAttendanceRequestToAttendance(StudentAttendanceRequestViewModel model)
        {
            if (model == null)
                return new List<Attendance>();

            return model.Students.Select(s => new Attendance
            {
                AttendanceId = Guid.NewGuid(),
                ClassId = model.ClassId,
                StudentId = s.StudentId,
                Date = DateTime.Now.Date,
                Status = s.Status
            }).ToList();
        }

        public static StudentAttendanceResponseViewModel MapAttendanceToResponse(Attendance model)
        {
            if (model == null)
                return null;

            return new StudentAttendanceResponseViewModel
            {
                AttendanceId = model.AttendanceId,
                Date = model.Date,
                StudentName = model.Student?.FirstName + " " + model.Student?.LastName,
                ClassName = model.Class?.ClassName,
                Status = model.Status
            };
        }

        //   Incident
        public static Incident MapIncidentRequestViewModelToIncident (IncidentRequestViewModel model)
        {
            if (model==null)
                return null;
            return new Incident
            {
                Date = model.Date,
                TutorId = model.TutorId,
                StudentId = model.StudentId,
                IncidentTitle = model.IncidentTitle,
                Details = model.Details,
                LessonId = model.LessonId
            };
        }

        public static IncidentResponseViewModel MapIncidentToIncidentResponseViewModel (Incident incident)
        {
            if (incident==null)
                return null;
            return new IncidentResponseViewModel
            {
                Date = incident.Date,
                TutorId = incident.TutorId,
                StudentId = incident.StudentId,
                IncidentTitle = incident.IncidentTitle,
                Details = incident.Details,
                LessonId = incident.IncidentId
            };
        }

        public static IncidentListViewModel MapIncidentToIncidentListViewModel(Incident incident)
        {
            if (incident == null)
                return null;

            return new IncidentListViewModel
            {
                Date = incident.Date,
                Tutor = $"{incident.Tutor.FirstName} {incident.Tutor.LastName}",
                Student = $"{incident.Student.FirstName} {incident.Student.LastName}",
                Incident = incident.IncidentTitle,
                Details = incident.Details
            };
        }
    }
}