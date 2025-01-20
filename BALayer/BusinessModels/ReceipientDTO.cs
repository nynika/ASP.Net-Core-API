using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BALayer.BusinessModels
{
    public class ReceipientDTO
    {
        public int ReciepientID { get; set; }
        public string UHID { get; set; }
        public string UHID_Old { get; set; }
        public string PatientName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Patient_BldGrp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? TransplantDate { get; set; }
        public string StrTransplantDate { get; set; }
        public string TransplantNumber { get; set; }
        public bool TransplantType_LDLT { get; set; }
        public bool TransplantType_DDLT { get; set; }
        public bool LiverSize_WL { get; set; }
        public bool LiverSize_RL { get; set; }
        public bool LiverSize_LL { get; set; }
        public bool LiverSize_LLS { get; set; }
        public bool LiverSize_ERL { get; set; }
        public bool LiverSize_RPS { get; set; }
        public bool Commorb_DM { get; set; }
        public bool Commorb_HTN { get; set; }
        public bool Commorb_CAD { get; set; }
        public bool Commorb_Asthma { get; set; }
        public bool Commorb_Epilepsy { get; set; }
        public string Commorb_Others { get; set; }
        public string Allergies { get; set; }
        public string Diagnosis { get; set; }
        public string MELDAtListing { get; set; }
        public string MELDAtSurgery { get; set; }
        public string LTX { get; set; }
        public string Pre_TX { get; set; }
        public bool HCC_Y { get; set; }
        public bool HCC_N { get; set; }
        public string Donor_Gender { get; set; }
        public string Donor_Age { get; set; }
        public string Donor_BldGrp { get; set; }
        public string GraftWeight { get; set; }
        public string GRWR { get; set; }
        public string Graft1 { get; set; }
        public string Graft2 { get; set; }
        public string Graft3 { get; set; }
        public string Graft4 { get; set; }
        public string Graft5 { get; set; }
        public string Recipient1 { get; set; }
        public string Recipient2 { get; set; }
        public string Recipient3 { get; set; }
        public string Recipient4 { get; set; }
        public string Recipient5 { get; set; }
        public string BloodLoss { get; set; }
        public string Transfusion_PRC { get; set; }
        public string Transfusion_Celliver { get; set; }
        public string Transfusion_FFP { get; set; }
        public string Transfusion_SDP { get; set; }
        public string Transfusion_Cryo { get; set; }
        public string Tranfusion_Pooled_platelet { get; set; }
        public string Lactate_Peak { get; set; }
        public string Lactate_AtICUTransfer { get; set; }
        public string CIT { get; set; }
        public string WIT { get; set; }
        public string Flow_Mod_Splenic_Artery_Ligation { get; set; }
        public string Flow_Mod_Splenoctomy { get; set; }
        public string Flow_Mod_Colleteral_Ligation { get; set; }
        public string Flow_Mod_Left_Renal_Vein_Ligation { get; set; }
        public string Flow_Mod_Shunt { get; set; }
        public string Flow_Mod_Others { get; set; }
        public string Portal_Pressure_BaseLine { get; set; }
        public string Portal_Post_Reperfusion { get; set; }
        public string Portal_Post_Modulation { get; set; }
        public string Sign_Event_Proc { get; set; }
        public string PreTransplantImaging { get; set; }
        public string ExplantPathology { get; set; }
        public string TransplantProcedure_Oters { get; set; }
        public string TransplantProcedureType_Oters { get; set; }
        public string TransplantLiverSize_Oters { get; set; }
        public int WhiteSheetID { get; set; }
        public DateTime? WhiteSheetDate { get; set; }
        public string StrWhiteSheetDate { get; set; }
        public string WhiteSheetProcedure { get; set; }
        public string jsondata { get; set; }
        public string ActionType { get; set; }
        public int DepartmentID { get; set; }
        public int ServiceId { get; set; }
        public string WhiteSheetResultValue { get; set; }
        public byte[] Image { get; set; }

        public List<string> WS_Columns = new List<string>();
        public List<string> WS_Rows = new List<string>();
    }
}
