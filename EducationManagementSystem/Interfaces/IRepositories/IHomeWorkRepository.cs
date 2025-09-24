using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

public interface IHomeWorkRepository
{
    Task<HomeWork> AddHomeWorkAsync(HomeWork homework);
    Task<IEnumerable<HomeWork>> GetHomeWorksAsync();
    Task<HomeWork> GetHomeWorkByIdAsync(int homeworkId);
    Task<HomeWork> UpdateHomeWorkAsync(HomeWork homeWork);
}
