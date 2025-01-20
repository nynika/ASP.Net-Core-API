using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class ServiceDTO
    {
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(100, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Required(ErrorMessage = "DepartmentName is required!")]
        [Display(Name = "Department ID")]
        public int? DepartmentID { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Service Remarks")]
        public string ServiceRemarks { get; set; }

    }
}
