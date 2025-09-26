using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.Repositories;
using EducationManagementSystem.ViewModels;

public class HomeWorkService : IHomeWorkService
{
    private readonly IHomeWorkRepository _repository;

    public HomeWorkService(IHomeWorkRepository repository)
    {
        _repository = repository;
    }

    public async Task<HomeWorkResponseViewModel> AddHomeWorkAsync(HomeWorkRequestViewModel model)
    {
        var entity = Mapper.MapHomeWorkRequestViewModelToHomeWork(model);
        var created = await _repository.AddHomeWorkAsync(entity);
        return Mapper.MapHomeWorkToHomeWorkResponse(created);
    }

    public async Task<IEnumerable<HomeWorkResponseViewModel>> GetHomeWorksAsync()
    {
        var homeworks = await _repository.GetHomeWorksAsync();
        return homeworks.Select(h => Mapper.MapHomeWorkToHomeWorkResponse(h));
    }

    public async Task<HomeWorkResponseViewModel> UpdateHomeWorkAsync(int homeworkid, HomeWorkUpdateViewModel model)
    {
        var homework = await _repository.GetHomeWorkByIdAsync(homeworkid);
        if (homework == null)
            return null;

        Mapper.MapUpdateToHomeWork(model, homework);

        var updatedHomework = await _repository.UpdateHomeWorkAsync(homework);
        return Mapper.MapHomeWorkToHomeWorkResponse(updatedHomework);
    }

}