namespace EducationManagementSystem.Common
{
    public class Enums
    {
        public enum ApplicationUserTypeEnum
        {
            Admin=1,
            Student=2,
            Client=3,
            Tutor=4,
            Guardian=5,
        }
        public enum ResponseStatus
        {
            Success,
            Error
        }
        public enum ClassFormat
        {
            Online,
            Offline,
            FaceToFace
        }
        public enum AttendanceStatus
        {
            Planned,
            Completed,
            NotAttended,
            Cancelled
        }
        public enum LessonStatus
        {
            NotAttendedByTutor,
            NotAttendedByStudent,
            EndedEarly,
            SessionDelivered
        }
        public enum NoteType
        {
            General,
            Lesson
        }
        public enum ReportTrigger
        {
            None,
            LessonApproval,
            EndOfMonth
        }
        public enum LessonDuration
        {
            OneHour = 1,
            TwoHours = 2
        }

    }
}
