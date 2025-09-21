using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Mymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserTypes",
                columns: table => new
                {
                    ApplicationUserTypeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTypes", x => x.ApplicationUserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamBoards",
                columns: table => new
                {
                    ExamBoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamBoardName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamBoards", x => x.ExamBoardId);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.StudentGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VennueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VennueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongandLat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VennueId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearningObjectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionsPerWeek = table.Column<int>(type: "int", nullable: true),
                    SesstionLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrolledSession = table.Column<int>(type: "int", nullable: true),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GuardianId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayAM = table.Column<bool>(type: "bit", nullable: true),
                    MondayPM = table.Column<bool>(type: "bit", nullable: true),
                    TuesdayAM = table.Column<bool>(type: "bit", nullable: true),
                    TuesdayPM = table.Column<bool>(type: "bit", nullable: true),
                    WednesdayAM = table.Column<bool>(type: "bit", nullable: true),
                    WednesdayPM = table.Column<bool>(type: "bit", nullable: true),
                    ThursdayAM = table.Column<bool>(type: "bit", nullable: true),
                    ThursdayPM = table.Column<bool>(type: "bit", nullable: true),
                    FridayAM = table.Column<bool>(type: "bit", nullable: true),
                    FridayPM = table.Column<bool>(type: "bit", nullable: true),
                    SaturdayAM = table.Column<bool>(type: "bit", nullable: true),
                    SaturdayPM = table.Column<bool>(type: "bit", nullable: true),
                    SundayAM = table.Column<bool>(type: "bit", nullable: true),
                    SundayPM = table.Column<bool>(type: "bit", nullable: true),
                    SubjectExamMappingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Guardian2FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardin2Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2Building = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guardian2Profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeguardingLeadContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserTypeId = table.Column<int>(type: "int", nullable: false),
                    HomeWorkId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ApplicationUserTypes_ApplicationUserTypeId",
                        column: x => x.ApplicationUserTypeId,
                        principalTable: "ApplicationUserTypes",
                        principalColumn: "ApplicationUserTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VennueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trigger = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    DateofLesson = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    TeachingYear = table.Column<int>(type: "int", nullable: false),
                    StudentArrivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TutorArrivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    AttendanceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeguardingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TutorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_AspNetUsers_TutorId",
                        column: x => x.TutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "StudentGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VennueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSend = table.Column<DateOnly>(type: "date", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentContactMappings",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    StudentContactMappingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContactMappings", x => new { x.StudentId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_StudentContactMappings_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentContactMappings_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IncidentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AspNetUsers_TutorId",
                        column: x => x.TutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonNotes",
                columns: table => new
                {
                    LessonNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonNotes", x => x.LessonNoteId);
                    table.ForeignKey(
                        name: "FK_LessonNotes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonStudentMappings",
                columns: table => new
                {
                    LessonStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonStudentMappings", x => x.LessonStudentId);
                    table.ForeignKey(
                        name: "FK_LessonStudentMappings_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonStudentMappings_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId");
                });

            migrationBuilder.CreateTable(
                name: "ConfidentialNotes",
                columns: table => new
                {
                    ConfidentialNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IncidentId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfidentialNotes", x => x.ConfidentialNoteId);
                    table.ForeignKey(
                        name: "FK_ConfidentialNotes_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfidentialNotes_AspNetUsers_TutorId",
                        column: x => x.TutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfidentialNotes_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "IncidentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfidentialNotes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    HomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TutorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuitorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorks", x => x.HomeWorkId);
                    table.ForeignKey(
                        name: "FK_HomeWorks_AspNetUsers_TuitorId",
                        column: x => x.TuitorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeWorks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectExamMappings",
                columns: table => new
                {
                    SubjectExamMappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectExamMappings", x => x.SubjectExamMappingId);
                    table.ForeignKey(
                        name: "FK_SubjectExamMappings_ExamBoards_ExamId",
                        column: x => x.ExamId,
                        principalTable: "ExamBoards",
                        principalColumn: "ExamBoardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectExamMappings_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserTypeId",
                table: "AspNetUsers",
                column: "ApplicationUserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GuardianId",
                table: "AspNetUsers",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HomeWorkId",
                table: "AspNetUsers",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VenueId",
                table: "AspNetUsers",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidentialNotes_IncidentId",
                table: "ConfidentialNotes",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidentialNotes_LessonId",
                table: "ConfidentialNotes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidentialNotes_StudentId",
                table: "ConfidentialNotes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfidentialNotes_TutorId",
                table: "ConfidentialNotes",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ClientId",
                table: "Contacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_SubjectId",
                table: "HomeWorks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_TuitorId",
                table: "HomeWorks",
                column: "TuitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_LessonId",
                table: "Incidents",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_StudentId",
                table: "Incidents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TutorId",
                table: "Incidents",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonNotes_LessonId",
                table: "LessonNotes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClientId",
                table: "Lessons",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentGroupId",
                table: "Lessons",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TutorId",
                table: "Lessons",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_VenueId",
                table: "Lessons",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonStudentMappings_LessonId",
                table: "LessonStudentMappings",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonStudentMappings_StudentId",
                table: "LessonStudentMappings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserId",
                table: "Messages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentContactMappings_ContactId",
                table: "StudentContactMappings",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectExamMappings_ExamId",
                table: "SubjectExamMappings",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectExamMappings_SubjectId",
                table: "SubjectExamMappings",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LessonId",
                table: "Subjects",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HomeWorks_HomeWorkId",
                table: "AspNetUsers",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "HomeWorkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_AspNetUsers_TuitorId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_ClientId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_TutorId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConfidentialNotes");

            migrationBuilder.DropTable(
                name: "LessonNotes");

            migrationBuilder.DropTable(
                name: "LessonStudentMappings");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "StudentContactMappings");

            migrationBuilder.DropTable(
                name: "SubjectExamMappings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ExamBoards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUserTypes");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
