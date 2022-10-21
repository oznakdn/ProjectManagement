namespace ProjectManagement.Domain.Entities
{
    public class Project:BaseEntity
    {

        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public string ProjectTitle { get; set; }
        public string ProjectDetails { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}
