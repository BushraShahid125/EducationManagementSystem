using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using static EducationManagementSystem.Common.Enums;

namespace EducationManagementSystem.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> AddClientAsync(ClientCreateViewModel dto)
        {
            var client = new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Mobile = dto.Mobile,
                Building = dto.Building,
                Street = dto.Street,
                AddressLine2 = dto.AddressLine2,
                Town = dto.Town,
                County = dto.County,
                PostCode = dto.PostCode,
                Country = dto.Country,
                ContactTelephone = dto.ContactTelephone,   
                ContactEmail = dto.ContactEmail,
                ApplicationUserTypeId = (int)ApplicationUserTypeEnum.Client,
                AppStatus = dto.Status
            };

            _context.Users.Add(client);   
            await _context.SaveChangesAsync();

            return client;
        }

        //   GetAllClient
        public async Task<List<ApplicationUser>> GetAllClientsAsync()
        {
            return await _context.Users
                .Where(u => u.ApplicationUserTypeId == (int)ApplicationUserTypeEnum.Client)
                .ToListAsync();
        }

    }
}
