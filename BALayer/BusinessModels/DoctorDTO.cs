using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class DoctorDTO
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int DepartmentID { get; set; }
        public int SpecializationID { get; set; }
        public string AppDate { get; set; }
    }
}
