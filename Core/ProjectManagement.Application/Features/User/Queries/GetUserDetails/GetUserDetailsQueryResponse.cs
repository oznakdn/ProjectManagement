namespace ProjectManagement.Application.Features.User.Queries.GetUserDetails
{
    public class GetUserDetailsQueryResponse
    {

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Picture { get; set; }
        public string EmployeeBirthDate { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }

    public class GetUserDetailsQueryResponseMessage: GetUserDetailsQueryResponse
    {
        public GetUserDetailsQueryResponseMessage(string message)
        {
            ResponseMessage = message;
            IsSuccess = true;
        }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
