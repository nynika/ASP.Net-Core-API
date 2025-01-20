
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class AppointmentSlotDTO
    {
        public int DoctorID { get; set; }
        public string AppointmentDate { get; set; }
        public string AvailableSlotsStDttm { get; set; }
        public string AvailableSlotsEndDttm { get; set; }
    }
}
