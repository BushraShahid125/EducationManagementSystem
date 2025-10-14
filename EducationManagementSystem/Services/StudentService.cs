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

        public async Task<ApplicationUser> AddStudentDetailsAsync(StudentCreateViewModel model)
        {
            var student = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PreferredName = model.PreferredName,
                IsMale = model.IsMale,
                DateOfBirth = model.DateOfBirth,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode,
                Country = model.Country,
                ClientId = model.ClientId,
                ApplicationUserTypeId = (int)ApplicationUserTypeEnum.Student,
                AppStatus = true,
                UserName = model.Email,   
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(student, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(student, "Student");
                return student;
            }
            _context.Users.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}