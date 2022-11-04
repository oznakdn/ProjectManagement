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

        // TODO : burası düzenlenecek
        //private DateTime _projectEndDate;
        //public DateTime ProjectEndDate 
        //{
        //    get => _projectEndDate;
        //    set
        //    {
        //       _projectEndDate= ProjectStartDate > ProjectEndDate ? throw new Exception("Project start date must be less then project end date!"): value;
        //    }
        //}


        public virtual ICollection<Employee> Employees { get; set; }
    }
}
