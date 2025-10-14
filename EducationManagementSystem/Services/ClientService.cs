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

        public async Task<ApplicationUser> AddClientAsync(ClientCreateViewModel model)
        {
            var client = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Mobile,
                Building = model.Building,
                Street = model.Street,
                AddressLine2 = model.AddressLine2,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode,
                Country = model.Country,
                ContactTelephone = model.ContactTelephone,   
                ContactEmail = model.ContactEmail,
                ApplicationUserTypeId = (int)ApplicationUserTypeEnum.Client,
                AppStatus = model.Status
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
