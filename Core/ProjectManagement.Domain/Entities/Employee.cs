using System.Diagnostics.Contracts;

namespace ProjectManagement.Domain.Entities
{
    public class Employee:BaseEntity
    {
        public Employee()
        {
            Projects = new HashSet<Project>();
        }

        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeePicture { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Contact EmployeeContract { get; set; }
        public virtual ICollection<Project>Projects { get; set; }


    }
}
