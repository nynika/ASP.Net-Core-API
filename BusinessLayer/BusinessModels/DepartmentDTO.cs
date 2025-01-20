using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.BusinessModels
{
    public class DepartmentDTO
    {
        [Display(Name = "Department ID")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(100, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department Remarks")]
        public string DepartmentRemarks { get; set; }
    }
}
