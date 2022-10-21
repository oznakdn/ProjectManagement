using MediatR;

namespace ProjectManagement.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest:IRequest<List<GetAllUsersQueryResponse>>
    {
    }
}
