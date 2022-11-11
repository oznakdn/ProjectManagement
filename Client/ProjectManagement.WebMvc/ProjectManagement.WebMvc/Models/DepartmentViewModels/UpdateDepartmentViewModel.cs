using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.WebMvc.Models.DepartmentViewModels
{
    public class UpdateDepartmentViewModel
    {


        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string DepartmentName { get; set; }
    }
}
