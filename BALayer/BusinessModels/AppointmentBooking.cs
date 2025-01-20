using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class AppointmentBooking
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo1 { get; set; }
        public string DocId { get; set; }
        public string APPStartDate { get; set; }
        public string APPEndDate { get; set; }
        public string Source { get; set; }
    }
}
