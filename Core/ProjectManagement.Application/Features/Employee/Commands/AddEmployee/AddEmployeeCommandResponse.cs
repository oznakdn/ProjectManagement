namespace ProjectManagement.Application.Features.Employee.Commands.AddEmployee
{
    public class AddEmployeeCommandResponse
    {
        public AddEmployeeCommandResponse()
        {
            this.ResponseMessages = new List<string>();
            this.IsValid = true;
        }

        public List<string> ResponseMessages { get; set; }
        public bool IsValid { get; set; }
    }
}
