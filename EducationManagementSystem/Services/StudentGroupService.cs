using AutoMapper;
using EducationManagementSystem.Common;
using EducationManagementSystem.Interfaces.IRepositories;
using EducationManagementSystem.Interfaces.IService;
using EducationManagementSystem.Interfaces.IServices;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;
using EmployeeManagementSystem.Data;

namespace EducationManagementSystem.Services
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IStudentGroupRepository _repository;
        private readonly IMapper _mapper;

        public StudentGroupService(IStudentGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentGroupResponseViewModel> AddStudentGroupAsync(StudentGroupRequestViewModel model)
        {
            var existinggroups = await _repository.GetAllStudentGroupAsync();
            if (existinggroups.Any(v => v.GroupName.Equals(model.GroupName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("A Group with this name already exists.");
            }

            var group = _mapper.Map<StudentGroup>(model);
            var added = await _repository.AddStudentGroupAsync(group);
            return _mapper.Map<StudentGroupResponseViewModel>(added);
        }

        public async Task<ICollection<StudentGroupListViewModel>> GetAllStudentGroupsAsync(StudentGroupSearchViewModel filter)
        {
            var groups = await _repository.GetAllStudentGroupAsync();

            if (!string.IsNullOrWhiteSpace(filter.SearchKey))
            {
                groups = groups.Where(v =>
                    (!string.IsNullOrEmpty(v.GroupName) && v.GroupName.Contains(filter.SearchKey, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(v.PostCode) && v.PostCode.Contains(filter.SearchKey, StringComparison.OrdinalIgnoreCase))
                );
            }

            groups = groups
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

               return _mapper.Map<ICollection<StudentGroupListViewModel>>(groups.ToList());
        }
    }
}
