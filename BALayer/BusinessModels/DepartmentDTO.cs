using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentShortCode { get; set; }
        public string DepartmentRemarks { get; set; }
    }
}
