using System.ComponentModel.DataAnnotations;
namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(4,150, ErrorMessage = "Length must be between 4-150 characters")]
        public string Name { get; set; }
        [Required]
        [Range(1, 90)]
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
    }

   
}
