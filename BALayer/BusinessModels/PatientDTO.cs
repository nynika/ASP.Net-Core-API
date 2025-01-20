using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class PatientDTO
    {
        public string Authenticated { get; set; }
        public string MobileNo { get; set; }
        public string OTP { get; set; }

        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
       
        //public string AppDate { get; set; }

    }
}
