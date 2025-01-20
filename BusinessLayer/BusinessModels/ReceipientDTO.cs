using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.BusinessModels
{
    public class ReceipientDTO
    {
        [Display(Name = "Reciepient ID")]
        public int ReciepientID { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(13, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
        [Display(Name = "UHID")]
        public string UHID { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Range(0, 150, ErrorMessage = "Age should not contain characters")]
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Age")]
        public string Age { get; set; }

        //[Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Patient Blood Group")]
        public string Patient_BldGrp { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? TransplantDate { get; set; }

        public string StrTransplantDate { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Transplant No")]
        public string TransplantNumber { get; set; }

        //[Required(ErrorMessage = "{0} is required!")]
        //[Display(Name = "Chart No")]
        //public string ChartNumber { get; set; }

        [Display(Name = "LDLT")]
        public bool TransplantType_LDLT { get; set; }

        [Display(Name = "DDLT")]
        public bool TransplantType_DDLT { get; set; }

        [Display(Name = "Whole Liver")]
        public bool LiverSize_WL { get; set; }

        [Display(Name = "RL")]
        public bool LiverSize_RL { get; set; }

        [Display(Name = "LL")]
        public bool LiverSize_LL { get; set; }

        [Display(Name = "LLS")]
        public bool LiverSize_LLS { get; set; }

        [Display(Name = "ERL")]
        public bool LiverSize_ERL { get; set; }

        [Display(Name = "RPS")]
        public bool LiverSize_RPS { get; set; }

        [Display(Name = "DM")]
        public bool Commorb_DM { get; set; }

        [Display(Name = "HTN")]
        public bool Commorb_HTN { get; set; }

        [Display(Name = "CAD")]
        public bool Commorb_CAD { get; set; }

        [Display(Name = "Br.Asthma")]
        public bool Commorb_Asthma { get; set; }

        [Display(Name = "Epilepsy")]
        public bool Commorb_Epilepsy { get; set; }

        [Display(Name = "Others")]
        public string Commorb_Others { get; set; }

        [Display(Name = "Allergies")]
        public string Allergies { get; set; }

        [Display(Name = "Dioagnosis")]
        public string Diagnosis { get; set; }

        [Display(Name = "MELD At Listing")]
        public string MELDAtListing { get; set; }

        [Display(Name = "MELD At Surgery")]
        public string MELDAtSurgery { get; set; }

        [Display(Name = "Indication for LTX")]
        public string LTX { get; set; }

        [Display(Name = "Pre-TX Downstaging")]
        public string Pre_TX { get; set; }

        [Display(Name = "Yes")]
        public bool HCC_Y { get; set; }

        [Display(Name = "No")]
        public bool HCC_N { get; set; }

        [Display(Name = "Donor Gender")]
        public string Donor_Gender { get; set; }

        [Range(0, 150, ErrorMessage = "Age should not contain characters")]
        //[Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Donor Age")]
        public string Donor_Age { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Donor Blood Group")]
        public string Donor_BldGrp { get; set; }

        [Display(Name = "Graft Weight")]
        public string GraftWeight { get; set; }

        [Display(Name = "GRWR")]
        public string GRWR { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Graft")]
        public string Graft1 { get; set; }

        [Display(Name = "Graft 2")]
        public string Graft2 { get; set; }

        [Display(Name = "Graft 3")]
        public string Graft3 { get; set; }

        [Display(Name = "Graft 4")]
        public string Graft4 { get; set; }

        [Display(Name = "Graft 5")]
        public string Graft5 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Recipient")]
        public string Recipient1 { get; set; }

        [Display(Name = "Recipient 2")]
        public string Recipient2 { get; set; }

        [Display(Name = "Recipient 3")]
        public string Recipient3 { get; set; }

        [Display(Name = "Recipient 4")]
        public string Recipient4 { get; set; }

        [Display(Name = "Recipient 5")]
        public string Recipient5 { get; set; }

        [Display(Name = "Blood Loss")]
        public string BloodLoss { get; set; }

        [Display(Name = "PRC")]
        public string Transfusion_PRC { get; set; }

        [Display(Name = "Cell Saver")]
        public string Transfusion_Celliver { get; set; }

        [Display(Name = "FFP")]
        public string Transfusion_FFP { get; set; }

        [Display(Name = "SDP")]
        public string Transfusion_SDP { get; set; }

        [Display(Name = "Cryo")]
        public string Transfusion_Cryo { get; set; }

        [Display(Name = "Pooled Platelet")]
        public string Tranfusion_Pooled_platelet { get; set; }

        [Display(Name = "Lactate(mmol/L) Peak")]
        public string Lactate_Peak { get; set; }

        [Display(Name = "At ICU Transfer")]
        public string Lactate_AtICUTransfer { get; set; }

        [Display(Name = "CIT")]
        public string CIT { get; set; }

        [Display(Name = "WIT")]
        public string WIT { get; set; }

        [Display(Name = "Splenic artery Ligation")]
        public string Flow_Mod_Splenic_Artery_Ligation { get; set; }

        [Display(Name = "Splenectomy")]
        public string Flow_Mod_Splenoctomy { get; set; }

        [Display(Name = "Colleteral Ligation")]
        public string Flow_Mod_Colleteral_Ligation { get; set; }

        [Display(Name = "Left Renal Vein Ligation")]
        public string Flow_Mod_Left_Renal_Vein_Ligation { get; set; }

        [Display(Name = "Shunt")]
        public string Flow_Mod_Shunt { get; set; }

        [Display(Name = "Others")]
        public string Flow_Mod_Others { get; set; }

        [Display(Name = "BaseLine")]
        public string Portal_Pressure_BaseLine { get; set; }

        [Display(Name = "Post Reperfusion")]
        public string Portal_Post_Reperfusion { get; set; }

        [Display(Name = "Post Modulation")]
        public string Portal_Post_Modulation { get; set; }

        [Display(Name = "Significant events/procudures")]
        public string Sign_Event_Proc { get; set; }

        [Display(Name = "Pre Transplant Imaging")]
        public string PreTransplantImaging { get; set; }

        [Display(Name = "Explant Pathology")]
        public string ExplantPathology { get; set; }

        [Display(Name = "Others")]
        public string TransplantProcedure_Oters { get; set; }

        [Display(Name = "Others")]
        public string TransplantProcedureType_Oters { get; set; }

        [Display(Name = "Others")]
        public string TransplantLiverSize_Oters { get; set; }


        //[Display(Name = "WhiteSheet ID")]
        public int WhiteSheetID { get; set; }

        //[Required(ErrorMessage = "{0} is required!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? WhiteSheetDate { get; set; }

        public string StrWhiteSheetDate { get; set; }

        //[Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Procedures")]
        public string WhiteSheetProcedure { get; set; }

        public string jsondata { get; set; }

        public string ActionType { get; set; }

        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }

        [Display(Name = "Service Name")]
        public int ServiceId { get; set; }

        [Display(Name = "Result")]
        public string WhiteSheetResultValue { get; set; }

        [Display(Name = "Reconstruction")]
        public byte[] Image { get; set; }


        public List<string> WS_Columns = new List<string>();
        public List<string> WS_Rows = new List<string>();
    }
}
