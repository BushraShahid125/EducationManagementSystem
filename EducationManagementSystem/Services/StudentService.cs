using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ApplicationUser> AddStudentDetailsAsync(StudentCreateViewModel dto)
        {
            var student = new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PreferredName = dto.PreferredName,
                IsMale = dto.IsMale,
                DateOfBirth = dto.DateOfBirth,
                Building = dto.Building,
                Street = dto.Street,
                AddressLine2 = dto.AddressLine2,
                Town = dto.Town,
                County = dto.County,
                PostCode = dto.PostCode,
                Country = dto.Country,
                ClientId = dto.ClientId,
                ApplicationUserTypeId = (int)ApplicationUserTypeEnum.Student,
                AppStatus = true
            };

            _context.Users.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}