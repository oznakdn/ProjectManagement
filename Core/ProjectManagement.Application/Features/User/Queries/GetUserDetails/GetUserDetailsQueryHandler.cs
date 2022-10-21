using AutoMapper;
using MediatR;
using ProjectManagement.Application.UnitOfWork;

namespace ProjectManagement.Application.Features.User.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQueryRequest, GetUserDetailsQueryResponse>
    {
        private readonly IQueryUnitOfWork query;
        private readonly IMapper mapper;

        public GetUserDetailsQueryHandler(IQueryUnitOfWork query, IMapper mapper)
        {
            this.query = query;
            this.mapper = mapper;
        }

        public async Task<GetUserDetailsQueryResponse> Handle(GetUserDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var existsUser = await query.UserQuery.GetWithIncludeAsync(false, u => u.Id == Guid.Parse(request.Id), u => u.Employee);

            if(existsUser == null)
            {
                return new GetUserDetailsQueryResponseMessage("User not found.") { IsSuccess=false};
            }


            return mapper.Map<GetUserDetailsQueryResponse>(existsUser);
          
           
        }
    }
}
