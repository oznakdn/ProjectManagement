namespace ProjectManagement.Domain.Entities
{
    public class Department:BaseEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee>Employees { get; set; }
    }
}
