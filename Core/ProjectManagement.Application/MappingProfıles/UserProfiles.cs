using AutoMapper;
using ProjectManagement.Application.Features.User.Commands.AddUser;
using ProjectManagement.Application.Features.User.Commands.AddUserToken;
using ProjectManagement.Application.Features.User.Queries.GetAllUsers;
using ProjectManagement.Application.Features.User.Queries.GetUserDetails;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.MappingProfıles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<AddUserCommandRequest, User>()
                .ForMember(src => src.EmployeeId, opt => opt.MapFrom(dest => dest.EmployeeId.ToString()));
              
            CreateMap<User,AddUserTokenCommandRequest>();

            CreateMap<User, GetUserDetailsQueryResponse>()
                .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Employee.EmployeeName))
                .ForMember(src => src.Lastname, opt => opt.MapFrom(dest => dest.Employee.EmployeeLastname))
                .ForMember(src => src.Picture, opt => opt.MapFrom(dest => dest.Employee.EmployeePicture))
                .ForMember(src => src.EmployeeBirthDate, opt => opt.MapFrom(dest => dest.Employee.EmployeeBirthDate.ToShortDateString()))
                .ForMember(src => src.Username, opt => opt.MapFrom(dest => dest.Username))
                .ForMember(src => src.Role, opt => opt.MapFrom(dest => dest.Role.ToString()));


            CreateMap<User, GetAllUsersQueryResponse>()
                .ForMember(src=>src.Id,opt=>opt.MapFrom(dest=>dest.Id.ToString()))
                .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Employee.EmployeeName))
                .ForMember(src => src.Lastname, opt => opt.MapFrom(dest => dest.Employee.EmployeeLastname))
                .ForMember(src => src.Picture, opt => opt.MapFrom(dest => dest.Employee.EmployeePicture))
                .ForMember(src => src.EmployeeBirthDate, opt => opt.MapFrom(dest => dest.Employee.EmployeeBirthDate.ToShortDateString()))
                .ForMember(src => src.Username, opt => opt.MapFrom(dest => dest.Username))
                .ForMember(src => src.Role, opt => opt.MapFrom(dest => dest.Role.ToString()));
        }
    }
}
