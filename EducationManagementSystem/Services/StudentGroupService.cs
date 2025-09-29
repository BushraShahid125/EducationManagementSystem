using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementSystem.Services
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IStudentGroupRepository _repository;

        public StudentGroupService(IStudentGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<StudentGroupResponseViewModel> AddStudentGroupAsync(StudentGroupRequestViewModel model)
        {
            var exists = await _repository.GetAllStudentGroups()
                .AnyAsync(g => g.GroupName.ToLower() == model.GroupName.ToLower());

            if (exists)
                throw new Exception("A Group with this name already exists.");

            var group = Mapper.MapStudentGroupRequestViewModelToStudentGroup(model);
            var result = await _repository.AddStudentGroupAsync(group);

            return Mapper.MapStudentGroupToStudentGroupResponseViewModel(result);
        }

        public async Task<ICollection<StudentGroupListViewModel>> GetAllStudentGroupsAsync(StudentGroupSearchViewModel? filter)
        {
            var query = _repository.GetAllStudentGroups();

            if (filter != null && !string.IsNullOrWhiteSpace(filter.SearchKey))
            {
                var searchKey = filter.SearchKey.ToLower();
                query = query.Where(g =>
                    g.GroupName.ToLower().Contains(searchKey) ||
                    g.PostCode.ToLower().Contains(searchKey)
                );
            }

            int pageNumber = filter?.PageNumber > 0 ? filter.PageNumber : 1;
            int pageSize = filter?.PageSize > 0 ? filter.PageSize : 10; 

            var groups = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return groups.Select(Mapper.MapStudentGroupToStudentGroupListViewModel).ToList();
        }

    }
}
