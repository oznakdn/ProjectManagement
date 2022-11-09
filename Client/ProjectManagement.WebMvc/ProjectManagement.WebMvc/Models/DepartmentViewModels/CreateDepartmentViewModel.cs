using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.WebMvc.Models.DepartmentViewModels
{
    public class CreateDepartmentViewModel
    {
        [MaxLength(50)]
        [MinLength(2)]
        public string DepartmentName { get; set; }

    }
}
