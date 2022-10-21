namespace ProjectManagement.Application.Features.Employee.Queries.GetEmployeeWith
{
    public class GetEmployeeWithQueryResponse
    {

        public GetEmployeeWithQueryResponse()
        {

        }

        public GetEmployeeWithQueryResponse(string id, string employeeName, string employeeLastname, string employeePicture, string employeeBirthDate, string department, string address, string city, string emailAddress, string phoneNumber):this()
        {
            Id = id;
            EmployeeName = employeeName;
            EmployeeLastname = employeeLastname;
            EmployeePicture = employeePicture;
            EmployeeBirthDate = employeeBirthDate;
            Department = department;
            Address = address;
            City = city;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeePicture { get; set; }
        public string EmployeeBirthDate { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }



    }

    public class GetEmployeeWithQueryResponseMessage: GetEmployeeWithQueryResponse
    {
        public string ResponseMessage { get; set; }

    }
}
