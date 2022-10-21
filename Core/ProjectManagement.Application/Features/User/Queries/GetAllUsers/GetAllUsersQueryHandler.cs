using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetAllUsersQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await query.UserQuery.GetAllWithIncludeAsync(false, null, u => u.Employee);

            return mapper.Map<List<GetAllUsersQueryResponse>>(users);
        }
    }
}
