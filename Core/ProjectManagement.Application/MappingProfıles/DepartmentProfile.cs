using AutoMapper;
using ProjectManagement.Application.Features.Department.Commands.AddDepartment;
using ProjectManagement.Application.Features.Department.Commands.UpdateDepartment;
using ProjectManagement.Application.Features.Department.Queries.GetAllDepartments;
using ProjectManagement.Application.Features.Department.Queries.GetDepartmentByName;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.MappingProfıles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, GetAllDepartmentsQueryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<AddDepartmentCommandRequest, Department>();

            CreateMap<UpdateDepartmentCommandRequest, Department>();

        }
    }
}
