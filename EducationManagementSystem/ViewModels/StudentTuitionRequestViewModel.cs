namespace EducationManagementSystem.ViewModels
{
    public class StudentTuitionRequestViewModel
    {
        public string StudentId { get; set; }
        public int? SessionsPerWeek { get; set; }
        public string? SessionLength { get; set; }
        public int? EnrolledSession { get; set; }
        public Guid? VenueId { get; set; }
        public string? LocationNotes { get; set; }
        public string GuardianId { get; set; }
        public string? ClientId { get; set; }

        // Weekly Availability
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
    }
}
