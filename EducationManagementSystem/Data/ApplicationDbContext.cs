using EducationManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Claims;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<ApplicationUser>ApplicationUsers { get; set; }
        public DbSet<ApplicationUserType> ApplicationUserTypes { get; set; }
        public DbSet<ConfidentialNote> ConfidentialNotes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ExamBoard> ExamBoards { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonNote> LessonNotes { get; set; }
        public DbSet<LessonStudentMapping> LessonStudentMappings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<StudentContactMapping> StudentContactMappings { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectExamMapping> SubjectExamMappings { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Venue> Venues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser relationships
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.UserType)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.ApplicationUserTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUserType>(entity =>
            {
                entity.Property(e => e.ApplicationUserTypeId).ValueGeneratedNever();
                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Client)
                .WithMany(c => c.ClientStudents)
                .HasForeignKey(u => u.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Venue)
                .WithMany(v => v.Students)
                .HasForeignKey(u => u.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            // StudentContactMapping
            modelBuilder.Entity<StudentContactMapping>()
                .HasKey(sc => new { sc.StudentId, sc.ContactId });

            modelBuilder.Entity<StudentContactMapping>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentContacts)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentContactMapping>()
                .HasOne(sc => sc.Contact)
                .WithMany(c => c.StudentContacts)
                .HasForeignKey(sc => sc.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            // Lesson
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Tutor)
                .WithMany(u => u.TutorLessons)
                .HasForeignKey(l => l.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Client)
                .WithMany(u => u.ClientLessons)
                .HasForeignKey(l => l.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Venue)
                .WithMany(v => v.Lessons)
                .HasForeignKey(l => l.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Student)
                .WithMany(u => u.StudentLessons)
                .HasForeignKey(l => l.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ConfidentialNote
            modelBuilder.Entity<ConfidentialNote>()
                .HasOne(cn => cn.Lesson)
                .WithMany(l => l.ConfidentialNotes)
                .HasForeignKey(cn => cn.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConfidentialNote>()
                .HasOne(cn => cn.Tutor)
                .WithMany(u => u.TutorConfidentialNotes)
                .HasForeignKey(cn => cn.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConfidentialNote>()
                .HasOne(cn => cn.Student)
                .WithMany(u => u.StudentConfidentialNotes)
                .HasForeignKey(cn => cn.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConfidentialNote>()
                .HasOne(cn => cn.Incident)
                .WithMany(i => i.ConfidentialNotes)
                .HasForeignKey(cn => cn.IncidentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Messages
            modelBuilder.Entity<Message>()
                .HasOne(m => m.FromUser)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ToUser)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Tutor)
                .WithMany(u => u.TutorIncidents)
                .HasForeignKey(i => i.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Student)
                .WithMany(u => u.StudentIncidents)
                .HasForeignKey(i => i.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Lesson)
                .WithMany(l => l.Incidents)
                .HasForeignKey(i => i.LessonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}