using AutoMapper;
using ProjectManagement.Application.Features.Employee.Commands.AddEmployee;
using ProjectManagement.Application.Features.Employee.Commands.UpdateEmployee;
using ProjectManagement.Application.Features.Employee.Queries.GetAllEmployeesByDepartment;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.MappingProfıles
{
    public class EmployeeProfiles:Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, GetAllEmployeesByDepartmentQueryResponse>()
                .ForMember(src=>src.DepartmentName,opt=>opt.MapFrom(dest=>dest.Department.DepartmentName))
                .ForMember(src => src.EmployeeId, opt => opt.MapFrom(dest => dest.Id.ToString()))
                .ForMember(dest => dest.EmployeeBirthDate, opt => opt.MapFrom(src => src.EmployeeBirthDate.ToShortDateString()));


            CreateMap<AddEmployeeCommandRequest, Employee>()
                .ForMember(src => src.DepartmentId, opt => opt.MapFrom(dest => Guid.Parse(dest.DepartmentId)));

            CreateMap<UpdateEmployeeCommandRequest, Employee>()
                .ForMember(src => src.Id, opt => opt.MapFrom(dest => Guid.Parse(dest.Id)))
                .ForMember(src => src.DepartmentId, opt => opt.MapFrom(dest => Guid.Parse(dest.DepartmentId)));

        }
    }
}
