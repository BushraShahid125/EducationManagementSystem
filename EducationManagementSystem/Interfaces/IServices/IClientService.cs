using EducationManagementSystem.ViewModels;
using EducationManagementSystem.Models;
using System.Threading.Tasks;

namespace EducationManagementSystem.Interfaces.IService
{
    public interface IClientService
    {
        Task<ApplicationUser> AddClientAsync(ClientCreateViewModel dto);
        Task<List<ApplicationUser>> GetAllClientsAsync();
    }
}