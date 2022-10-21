using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQueryRequest, GetUserDetailsQueryResponseMessage>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetUserDetailsQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<GetUserDetailsQueryResponseMessage> Handle(GetUserDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var existsUser = await query.UserQuery.GetWithIncludeAsync(false, u => u.Id == Guid.Parse(request.Id), u => u.Employee);

            if (existsUser == null)
            {
                return new GetUserDetailsQueryResponseMessage { IsSuccess = false, ResponseMessage = "User not found!" };
            }


            var userModel = mapper.Map<GetUserDetailsQueryResponse>(existsUser);

            return new GetUserDetailsQueryResponseMessage()
            {
                Name = userModel.Name,
                Lastname = userModel.Lastname,
                Picture = userModel.Picture,
                EmployeeBirthDate = userModel.EmployeeBirthDate,
                Username = userModel.Username,
                Role = userModel.Role,
                IsSuccess = true
            };


        }
    }
}
