using MediatR;

namespace ProjectManagement.Application.Features.User.Queries.GetUserDetails
{
    public class GetUserDetailsQueryRequest:IRequest<GetUserDetailsQueryResponseMessage>
    {
        public GetUserDetailsQueryRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
