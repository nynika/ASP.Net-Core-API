
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class AutheticateDTO
    {
        public string Response { get; set; }
        public List<PatientDTO> patients { get; set; }
    }
}
