using AutoMapper;
using EducationManagementSystem.Models;
using EducationManagementSystem.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<StudentGroupRequestViewModel, StudentGroup>();
        CreateMap<StudentGroup, StudentGroupResponseViewModel>();
        CreateMap<StudentGroup, StudentGroupListViewModel>();
    }
}
