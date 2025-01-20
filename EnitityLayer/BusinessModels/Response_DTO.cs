using Microsoft.Owin.BuilderProperties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace EnitityLayer.BusinessModels
{


    #region RIMC_Online

    public class reqLogin
    {
        public string userID { get; set; }
        public string password { get; set; }
    }



    public class resLogin
    {
        public int userCode { get; set; }
        public string userID { get; set; }
        public string userName { get; set; }
        public string userImage { get; set; }
    }

    public class reqUserLogin

    {
        public int EmpId { get; set; }
        public string Password { get; set; }
    }
    public class resUserLogin
    {
        public int EmpId { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
    }


    public class reqpatLogin

    {
        public int UserId { get; set; }
        public string Password { get; set; }

    }


    public class respatLogin
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

    }

    public class resSavelogin
    {

        public int Sno { get; set; }
        public string MsgDesc { get; set; }

    }

    public class reqSaveLogin
    {
        public string EmpId { get; set; }
        public string UHID { get; set; }

    }



    public class resHouseKeepingList
    {
        public int Sno { get; set; }
        public string MsgDesc { get; set; }
    }

    public class resQMSDetails
    {
        public int tokenNo { get; set; }
        public string MsgDesc { get; set; }
    }


    public class resDaywiseQMSList
    {
        public string PatientName { get; set; }
        public int TokenNo { get; set; }
        public string TokenType { get; set; }
        public string Status { get; set; }

    }


    public class resQMSListTV
    {
        public string PatientName { get; set; }
        public int TokenNo { get; set; }
        public string Status { get; set; }

    }


    public class reqimg
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DocumentPath { get; set; }
        public string LastModifiedDate { get; set; }
        public string DocumentName { get; set; }
        public string TempPath_FileName { get; set; }
        public string temppath { get; set; }

    }

    public class resimgList
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DocumentPath { get; set; }
        public string LastModifiedDate { get; set; }
        public string DocumentName { get; set; }
        public string TempPath_FileName { get; set; }


    }


    public class reqPatient_Portal_PathModel
    {
        public string UHID { get; set; }
        //  public string PatientName { get; set; }
        //  public string MobileNo { get; set; }
        public string DocumentName { get; set; }
        //   public string DocumentPath { get; set; }

    }

    public class Patient_Portal_PathModel
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string img { get; set; }
        public string RelationshipType { get; set; }
        public string RelationshipName { get; set; }

    }

    public class signatureModel_res
    {
        public int PatientId { get; set; }
        public string pictureName { get; set; }
        public string picFileName { get; set; }
        public string Image { get; set; }
        public Boolean Active { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }

    }

    public class req_signatureModel
    {
        public string PatientId { get; set; }
        public string PicName { get; set; }
        public string ImageFolderPath { get; set; }
        public string Filename { get; set; }
        public string CreateUser { get; set; }

    }

    public class imageModel
    {

        public int Sno { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DocumentPath { get; set; }
        public string LastModifiedDate { get; set; }
        public string DocumentName { get; set; }
        public string TempPath { get; set; }
        public string TempPath_FileName { get; set; }

    }


    public class reqimageModel
    {
        public string UHID { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
        public string Status { get; set; }

    }

    public class ReqHouseKeepingList

    {
        public int Cot_code { get; set; }
        public int WashRoom_code { get; set; }
        public int Fridge_code { get; set; }
        public int Flooring_code { get; set; }
        public int Mop_code { get; set; }
        public int Floorcleaning_code { get; set; }
        public int Bedsheet_code { get; set; }
        public int Couch_code { get; set; }
        public string Remarks { get; set; }
        public string CreateID { get; set; }


    }


    public class ReqRestRoomList

    {
        public int WC_Code { get; set; }
        public int Floor_Mopping { get; set; }
        public int Walls { get; set; }
        public int DustBin_Clearence { get; set; }
        public int Wash_Basin { get; set; }
        public int Mirror { get; set; }
        public int Door { get; set; }
        public int HandWash_Liquid { get; set; }
        public int Urine_StoolSampleBox { get; set; }
        public int Urinal_Basin { get; set; }
        public int HRT_Roll { get; set; }
        public int Door_Mat { get; set; }
        public int Floor_Trap { get; set; }
        public string HK_Sign { get; set; }
        public string Supervisor_Sign { get; set; }
        public string Remarks { get; set; }
        public string CreateID { get; set; }


    }

    public class CovidRegistrationDTO
    {
        public string UHID { get; set; }
        public string PatientName { get; set; } //VARCHAR(500)
        public int SalutationCode { get; set; } //From Master API
        public string DOB { get; set; } //DATE
        public string Gender { get; set; } //CHAR //M-Male,F-Female
        public int CountryCode { get; set; }  //From Master API
        public string Mob_CountryCode { get; set; }
        public int NationalityCode { get; set; }
        public int BirthCountryCode { get; set; }
        public int CityCode { get; set; } //From Master API
        public int StateCode { get; set; } //From Master API
        public string CurrAddress { get; set; }//VARCHAR(200) //Added by jeyganesh 17.02.2021
        public string PerAddress { get; set; }//VARCHAR(200) //Added by jeyganesh 17.02.2021
        public string Area { get; set; }//VARCHAR(200) //Added by jeyganesh 17.02.2021
        public string Pincode { get; set; } //varchar(20)
        public string Address { get; set; } //varchar(500)
        public string MobileNo { get; set; } //VARCHAR(50)
        public string AltMob_CountryCode { get; set; }//VARCHAR(5) //Added by jeyganesh 17.02.2021
        public string AltMobileNo { get; set; } //VARCHAR(50) //Added by jeyganesh 17.02.2021
        public int DoctorID { get; set; }   //From Master API
        public string EmailId { get; set; }//VARCHAR(30)
        public string USERID { get; set; } //VARCHAR(150)

        public int MaritalStatus { get; set; } //From Master API
        public int Language { get; set; }//From Master API
        public int IdType { get; set; } //From Master API
        public string IdNumber { get; set; } //varchar(50)
        public string EmrcontNo { get; set; } //varchar(50) //Emergency Contact Number
        public string PassportNo { get; set; } //varchar(50)
        public string VisaNo { get; set; } //varchar(50)
        public string visaValidity { get; set; } //varchar(50) //Date
        public string Visatype { get; set; } //varchar(50),
        public string FormCstatus { get; set; } //varchar(150),
        public int referralcd { get; set; } //From Master API 
        public string othersname { get; set; }//varchar(30),
        public Boolean below { get; set; } // bit, 
        public Boolean above { get; set; } //bit ,
        public int occupation { get; set; } // From Master API,
        public string empolyeename { get; set; } // varchar(250),
        public string designation { get; set; } // varchar(150),
        public string religion { get; set; } // From Master API ,
        public string WorkLocation { get; set; } // varchar(250),
        public string Address2 { get; set; } // varchar(250)

        public string CovidId { get; set; }
        public string PatientVisitType { get; set; }
        public int Inspnlcd { get; set; }
        public string GlRefNo { get; set; }
        public string Source { get; set; }

        public string ResponseCode { get; set; }
        public string Response { get; set; }
        public string patientid { get; set; }
        public string regid { get; set; }

        public Boolean CRSD_Q1_Yes_Flg { get; set; }
        public Boolean CRSD_Q1_No_Flg { get; set; }
        public Boolean CRSD_Q2_Yes_Flg { get; set; }
        public Boolean CRSD_Q2_No_Flg { get; set; }
        public Boolean CRSD_Q3_Yes_Flg { get; set; }
        public Boolean CRSD_Q3_No_Flg { get; set; }
        public string CRSD_Q3_Desc { get; set; }
        public Boolean CRSD_Q4_Yes_Flg { get; set; }
        public Boolean CRSD_Q4_No_Flg { get; set; }
        public Boolean CRSD_Q5_Yes_Flg { get; set; }
        public Boolean CRSD_Q5_No_Flg { get; set; }
        public Boolean CRSD_Q6_Yes_Flg { get; set; }
        public Boolean CRSD_Q6_No_Flg { get; set; }
        public Boolean CRSD_Q6_ChickenPox_Flg { get; set; }
        public Boolean CRSD_Q6_Measles_Flg { get; set; }
        public Boolean CRSD_Q6_Mumps_Flg { get; set; }
        public Boolean CRSD_Q6_Rubella_Flg { get; set; }
        public Boolean CRSD_Q7_Yes_Flg { get; set; }
        public Boolean CRSD_Q7_No_Flg { get; set; }
        public Boolean CRSD_Q8_Yes_Flg { get; set; }
        public Boolean CRSD_Q8_No_Flg { get; set; }

        public string RegistrationRefNo { get; set; }
        public string PaymentRefNo { get; set; }

        public int symptoms { get; set; }
        public int historyoffever { get; set; }
        public int outofcountry1month { get; set; }
        public int diseaseoutbreak { get; set; }
        public int healthcareworker { get; set; }
        public int disease_last1month { get; set; }
        public int chickenpox { get; set; }
        public int measles { get; set; }
        public int mumps { get; set; }
        public int rubella { get; set; }
        public int diarrheasymptoms { get; set; }
        public int activeTB { get; set; }
        public int receivewhatsapp { get; set; }

        public string RefSource { get; set; }
        public string DoctorName { get; set; }
        public string username { get; set; }
        public string Loactaion { get; set; }
        public string RefNO { get; set; }
        public string RelationType { get; set; } = "";
        public string RelationName { get; set; } = "";
        public string RelationMobileno { get; set; } = "";

        public string PrefferedLanguage { get; set; }
        public int annualIncome { get; set; }
        public string bloodGroup { get; set; }
        public string SpecialAsstRemark { get; set; }
        public int SpecialAsst { get; set; }

    }


    public class uhidRequest
    {
        public long UHID { get; set; }
    }

    public class Patient_Portal
    {
        //  public long SNo { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string EmploymentStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string EmergencyContactType { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public string SpecialAssistance { get; set; }
        public string BloodGroup { get; set; }
        public string ReferralSource { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string DoorNo { get; set; }
        public string Street { get; set; }
        public string Cough { get; set; }
        public string Rashes { get; set; }
        public string Travel { get; set; }
        public string Flu { get; set; }
        public string HealthCareWrker { get; set; }
        public string DoorNoAppartmentName { get; set; }
        public string StreetLocality { get; set; }
        public string RecentDisease { get; set; }
        public string ChickenPox { get; set; }
        public string Measles { get; set; }
        public string Mumps { get; set; }
        public string Rubella { get; set; }
        public string Diarrhea { get; set; }
        public string TB { get; set; }
        public string Religion { get; set; }
        public string idproof { get; set; }
        public string pattype { get; set; }

        //  public string ImG { get; set; }

    }
    public class updaterefid

    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Amount { get; set; }
        public string MobileNO { get; set; }
        public string Email { get; set; }

    }
    public class reqclass {
        public string refId { get; set; }
    }
    public class OtClass
    {
        public string SNo { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string ScheduleTime { get; set; }
        public string TheaterName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ProcedureName { get; set; }
        public string SurgeonName { get; set; }
        public string Remarks { get; set; }
        public string Ward { get; set; }

    }

    public class req_OtClass
    {
        public int SNo { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PatientType { get; set; }
        public string TheaterName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ProcedureName { get; set; }
        public string SurgeonName { get; set; }
        public string Remarks { get; set; }
        public string Ward { get; set; }

    }

    public class docDir_imgView
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string patientAadharFile { get; set; }
        public string insuanceholderAadharFile { get; set; }
        public string panCardFile { get; set; }
        public string passportFile { get; set; }
        public string drivinglicenceFile { get; set; }
        public string cancelledchequeleafFile { get; set; }
        public string passportsizephotoFile { get; set; }
        public string doctorprescriptionFile { get; set; }
        public string investiationreportsFile { get; set; }
        public string dischargesummaryFile { get; set; }
        public string radiologyreportsFile { get; set; }
        public string corproateinsurancepolicyFile { get; set; }
        public string healthcardFile { get; set; }
        public string corporateidFile { get; set; }
        public string empidFile { get; set; }
        public string last3yearsinsuracepolicyFile { get; set; }
    }

    public class docDir_img_imp
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }

        public List<ImageUpload> Identification_Image { get; set; }
        public List<ImageUpload1> Medical_Image { get; set; }
        public List<ImageUpload2> Corporate_Image { get; set; }
        public List<ImageUpload3> Insurance_Image { get; set; }


    }

    public class ImageUpload
    {
        public string uhid { get; set; }
        public string Identification_Image { get; set; }
    }
    public class ImageUpload1
    {
        public string uhid { get; set; }
        public string Medical_Image { get; set; }
    }
    public class ImageUpload2
    {
        public string uhid { get; set; }
        public string Corporate_Image { get; set; }
    }
    public class ImageUpload3
    {
        public string uhid { get; set; }
        public string Insurance_Image { get; set; }
    }
    public class signimgreq {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string img { get; set; }
    }

    //public class docDir_img_imp
    //{
    //    public string UHID { get; set; }
    //    public string PatientName { get; set; }
    //    public string MobileNo { get; set; }
    //    public string DOB { get; set; }
    //    public string Age { get; set; }
    //    public string IDENTIFICATION_DOCUMENTS { get; set; }
    //    public string MEDICAL_DOCUMENTS { get; set; }
    //    public string CORPORATE_DOCUMENTS { get; set; }
    //    public string INSURANCE_DOCUMENTS { get; set; }

    //}

    public class docDir_img_exp
    {
        public string PicName { get; set; }
        public string ImageFolderPath { get; set; }
        public string Filename { get; set; }

    }

    public class docDir_imgView_List
    {
        public int SNo { get; set; }
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
        public string Seven { get; set; }
        public string Eight { get; set; }
        public string Nine { get; set; }
        public string Ten { get; set; }
        public string Eleven { get; set; }
        public string Tweleve { get; set; }
        public string Thirteen { get; set; }
        public string Fourteen { get; set; }

    }
    public class Get_PaymentGetWay_List
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Org_InsName { get; set; }
        public string Profession { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
    }

    public class Get_PaymentGetWay_Listdemo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class clsPatientMas_v1
    {
        public int Sno { get; set; }

        public int UHID { get; set; }

        public resDropDown Salutation { get; set; }

        public string PatientName { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }

        public resDropDown Maritial { get; set; }

        public resDropDown Nationality { get; set; }

        public resDropDown IDtype { get; set; }

        public string IDNo { get; set; }

        public resDropDown occupation { get; set; }

        public string MobileNo { get; set; }

        public string EmailId { get; set; }

        public string Pincode { get; set; }

        public string Address { get; set; }

        public resDropDown Country { get; set; }

        public resDropDown State { get; set; }


        public resDropDown City { get; set; }


        public string Area { get; set; }


        public resDropDown RelType { get; set; }

        public string RelName { get; set; }

        public string RelMobileNo { get; set; }

        public string KinArea { get; set; }

        public string KinAddress { get; set; }

        public string KinPostal { get; set; }

        public resDropDown KinCountry { get; set; }

        public resDropDown KinState { get; set; }

        public resDropDown KinCity { get; set; }

        public string CreateDate { get; set; }

        public string Age { get; set; }


    }

    public class LicenseModel
    {
        [JsonProperty(PropertyName = "Sno")]
        public int sno { get; set; }

        [JsonProperty(PropertyName = "LicenceName")]
        public string LicenceName { get; set; }

        [JsonProperty(PropertyName = "Department")]
        public string Department { get; set; }

        [JsonProperty(PropertyName = "StartDate")]
        public string StartDate { get; set; }

        [JsonProperty(PropertyName = "EndDate")]
        public string EndDate { get; set; }

        [JsonProperty(PropertyName = "AlertDays")]
        public string AlertDays { get; set; }

        [JsonProperty(PropertyName = "AlertDate")]
        public string AlertDate { get; set; }

        [JsonProperty(PropertyName = "LicenceNo")]
        public string LicenceNo { get; set; }

        [JsonProperty(PropertyName = "LicencePath")]
        public string LicencePath { get; set; }

        [JsonProperty(PropertyName = "LicenceId")]
        public string LicenceId { get; set; }

        [JsonProperty(PropertyName = "RegisterBy")]
        public string RegisterBy { get; set; }

        [JsonProperty(PropertyName = "RegisterDate")]
        public string RegisterDate { get; set; }

        [JsonProperty(PropertyName = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

        [JsonProperty(PropertyName = "LastModifiedDate")]
        public string LastModifiedDate { get; set; }

        [JsonProperty(PropertyName = "LastModifiedRemarks")]
        public string LastModifiedRemarks { get; set; }

        [JsonProperty(PropertyName = "IssuingAuthority")]
        public string IssuingAuthority { get; set; }

        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "DueDate")]
        public int DueDate { get; set; }

        [JsonProperty(PropertyName = "TimeCounter")]
        public string TimeCounter { get; set; }

        [JsonProperty(PropertyName = "UserName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "NewPassword")]
        public string NewPassword { get; set; }

        [JsonProperty(PropertyName = "AdminPriority")]
        public string AdminPriority { get; set; }

        [JsonProperty(PropertyName = "TempPath")]
        public string TempPath { get; set; }

        [JsonProperty(PropertyName = "TempPath_FileName")]
        public string TempPath_FileName { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public Boolean isActive { get; set; }

        [JsonProperty(PropertyName = "sendport")]
        public Boolean sendport { get; set; }
    }
    public class appsolt
    {
        public string Department { get; set; }
        public string DoctorName { get; set; }
        public string Qualification { get; set; }
        public List<Dropdown1> patient { get; set; }

    }

    public class PaymentGateWay
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Org_InsName { get; set; }
        public string Profession { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
    }
    public class DoctorDirectory
    {
        public int SNo { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public string Name { get; set; }
        public string Sub_Department { get; set; }
        public string Designation { get; set; }
        public int Tv_no { get; set; }
        public int slide_no { get; set; }
        public int Sequence { get; set; }
        public string profile_image { get; set; }

        public string Status { get; set; }
    }
    public class DoctorDirectory_new
    {
        public string Department { get; set; }
        public string Qualification { get; set; }
        public string Name { get; set; }
        public string Sub_Department { get; set; }
        public string Designation { get; set; }
        public int Tv_no { get; set; }
        public int slide_no { get; set; }
        public string Sequence { get; set; }
        public string profile_image { get; set; }

        public string Status { get; set; }
    }
    public class TicketingSystem
    {
        public int Total { get; set; }
        public int New { get; set; }
        public int Acknowledged { get; set; }
        public int Closed { get; set; }
    }


    public class ClsSaveAppointmentSlot
    {
        public int DoctorId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SessionStartTime { get; set; }
        public string SessionEndingTime { get; set; }
        public string UserId { get; set; }

    }
    public class DepWiseTicketingSystem
    {
        public string Department { get; set; }
        public int Total { get; set; }
        public int New { get; set; }
        public int Acknowledged { get; set; }
        public int Closed { get; set; }
    }
    public class DocDirImg_req

    {
        public List<DocDirImg_Line> DocDirImg_Line { get; set; }
    }
    public class DocDirImg_Line
    {
        public string Image { get; set; }
    }
    public class DocDirImg_List
    {
        public int SNo { get; set; }
        public string Image { get; set; }
    }
    public class Otexcel_req

    {
        public List<Otexcel> otexcel { get; set; }
    }
    public class BB_BloodGroup_req

    {
        public List<BB_BloodGroup> BB_BloodGroup { get; set; }
    }
    public class OPReceipt_Payment_Line
    {
        public string PayMode { get; set; }
        public decimal Amount { get; set; }
        public string RefNo { get; set; }
    }

    public class OPBillRecepitLine
    {
        public int RegistrationID { get; set; }
        public int ServiceID { get; set; }
        public decimal Unit { get; set; }
        public decimal Rate { get; set; }
        public int DiscType { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public int PriorityID { get; set; }
        public string Remarks { get; set; }
    }
    public class ExistsOPBillRecepitLine
    {
        public int ServiceID { get; set; }
        public decimal Unit { get; set; }
        public decimal Rate { get; set; }
        public int DiscType { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public int PriorityID { get; set; }
        public string Remarks { get; set; }
    }


    public class OPD_MasterProc_req
    {
        public List<ExistsOPBillRecepitLine> OPBillRecepitLine { get; set; }
        public List<OPReceipt_Payment_Line> OPReceipt_Payment_Line { get; set; }
        public int PatientTitle { get; set; }
        public string SalutationName { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public int MaritalStatus { get; set; }
        public int IDtype { get; set; }
        public string IDNo { get; set; }
        public int Nationality { get; set; }
        public int Language { get; set; }
        public int Occupation { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public int StateCode { get; set; }
        public int CityCode { get; set; }
        public int CountryCode { get; set; }
        public string Pincode { get; set; }
        public int BirthCountry { get; set; }
        public string PassportNo { get; set; }
        public string VISANo { get; set; }
        public int VISAType { get; set; }
        public string VISAValidity { get; set; }
        public string FormCstatus { get; set; }
        public string Mob_CountryCode { get; set; }
        public string AltMob_CountryCode { get; set; }
        public string AltMobileNo { get; set; }
        public string CurrAddress { get; set; }
        public string PermAddress { get; set; }
        public string Area { get; set; }
        public Boolean Pat_Is_symptoms { get; set; }
        public Boolean Pat_Is_historyoffever { get; set; }
        public Boolean Pat_Is_outofcountry1month { get; set; }
        public Boolean Pat_Is_diseaseoutbreak { get; set; }
        public Boolean Pat_Is_healthcareworker { get; set; }
        public Boolean Pat_Is_disease_last1month { get; set; }
        public Boolean Pat_Is_chickenpox { get; set; }
        public Boolean Pat_Is_measles { get; set; }
        public Boolean Pat_Is_mumps { get; set; }
        public Boolean Pat_Is_rubella { get; set; }
        public Boolean Pat_Is_diarrheasymptoms { get; set; }
        public Boolean Pat_Is_activeTB { get; set; }
        public Boolean Pat_Is_receivewhatsapp { get; set; }
        public string RelationType { get; set; }
        public string RelationName { get; set; }
        public string RelationMobileno { get; set; }
        public string UserID { get; set; }
        public int annualincome { get; set; }
        public int prefferedLanguages { get; set; }
        public int religion { get; set; }
        public string kin_Address { get; set; }
        public int kin_StateCode { get; set; }
        public int kin_CityCode { get; set; }
        public int kin_CountryCode { get; set; }
        public string kin_Pincode { get; set; }
        public string kin_Area { get; set; }
        public string OccRemark { get; set; }
        public int BloodGroup { get; set; }
        public int docId { get; set; }
        public int appointmentId { get; set; }
        public int RefSource { get; set; }
        public int VistType { get; set; }
        public string PatientType { get; set; }
        public int PayorID { get; set; }
        public string Remarks { get; set; }
        public int InternalDocId { get; set; }
        public int ExternalDocId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GLAmount { get; set; }
        public decimal PatientResponsibility { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime APPStartDate { get; set; }
        public string Package { get; set; }
        public string AppRemarks { get; set; }
        public string AppRefSource { get; set; }

    }
    public class OPD_ExsitsMasterProc_req
    {
        public List<ExistsOPBillRecepitLine> ExistsOPBillRecepitLine { get; set; }
        public List<OPReceipt_Payment_Line> OPReceipt_Payment_Line { get; set; }

        public string PatientID { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string UserID { get; set; }
        public int docId { get; set; }
        public int appointmentId { get; set; }
        public int RefSource { get; set; }
        public int VistType { get; set; }
        public string PatientType { get; set; }
        public int PayorID { get; set; }
        public string Remarks { get; set; }
        public int InternalDocId { get; set; }
        public int ExternalDocId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GLAmount { get; set; }
        public decimal PatientResponsibility { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime APPStartDate { get; set; }
        public string Package { get; set; }
        public string AppRemarks { get; set; }
        public string AppRefSource { get; set; }

    }

    public class BB_BloodGroup
    {
        public string VisitId { get; set; }
        public decimal RegistrationId { get; set; }
        public decimal PatientId { get; set; }
        public string ServiceNumber { get; set; }
        public int ChargeId { get; set; }
        public string TestName { get; set; }
        public string ParameterName { get; set; }
        public string TestRemaks { get; set; }
        public string Result { get; set; }
        public string Remaks { get; set; }
    }
    public class BB_BloodGroup_res
    {
        public string Success { get; set; }
        public string Message { get; set; }
    }

    public class CommonResponse
    {
        public Boolean Success { get; set; }
        public string Message { get; set; }
        public string errorCode { get; set; }
    }
    public class PrescriptionRespDTO
    {
        public int prescriptionId { get; set; }
        public int id { get; set; }
        public string name1 { get; set; }
        public string code { get; set; }
        public string dosage { get; set; }
        public int duration { get; set; }
        public string durationType { get; set; }
        public string frequency { get; set; }
        public int quantity { get; set; }
        public string instruction { get; set; }
        public string route1 { get; set; }

        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int visitId { get; set; }

        public int requestSequence { get; set; }
        public string planOfCare { get; set; } = "";
    }
    public class InvestigationRespDTO
    {
        public int orderId { get; set; }
        public int id { get; set; }
        public int departmentId { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string clinicalReason { get; set; }
        public string priority { get; set; }
        public string planOfCare { get; set; }
        public int consultationId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int visitId { get; set; }

        public int requestSequence { get; set; }
    }
    public class CommonRequestDTO
    {
        public int requestSequence { get; set; }
        public string requestType { get; set; }
        public CommonRequestDataDTO requestData = new CommonRequestDataDTO();
    }
    public class InvestigationEMR
    {

        public string requestType { get; set; }
        public string PatientId { get; set; }
        public string VisitId { get; set; }
        public string DepId { get; set; }
        public string DoctorId { get; set; }

        public string wardid { get; set; }
        public string RoomId { get; set; }
        public string BedId { get; set; }

        public DateTime Orderdate { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public string OrderUserId { get; set; }
        public List<InvestigationLineItem> Orders_items { get; set; }


    }
    public class InvestigationLineItem
    {

        public DateTime date_of_service { get; set; }
        public string order_id { get; set; }
        public string item_id { get; set; }
        public string item_description { get; set; }
        public int Unit { get; set; }
        public string Clinical_notes { get; set; }
        public string item_Priority { get; set; }

    }
    public class PrescriptionEMR
    {

        public string requestType { get; set; }
        public string PatientId { get; set; }
        public string VisitId { get; set; }
        public string prescription_Id { get; set; }
        public string Indent_Id { get; set; }
        public string Indent_type { get; set; }
        public string Indent_To { get; set; }
        public string DepId { get; set; }
        public string DoctorId { get; set; }
        public string wardid { get; set; }
        public string RoomId { get; set; }
        public string BedId { get; set; }
        public string IndentRemarks { get; set; }
        public DateTime Indentdatetime { get; set; }
        public string Indentuserid { get; set; }
        public List<PrescriptionLineItem> Orders_items { get; set; }

    }
    public class resHMPrescription
    {
    public string Pres_PrescriptionId_Id { get; set; }
    public string PatientId { get; set; }
    public string VisitId { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public string DepartmentName { get; set; }
    public string ServiceNumber { get; set; }
    public string prescriptionId { get; set; }
    public int DrugSHCode { get; set; }
    public string Dosage { get; set; }
    public int Duration { get; set; }
    public string DurationType { get; set; }
    public string Frequency { get; set; }
    public string Prescr_Route { get; set; }
    public string DrugName { get; set; }
    public int TotalItem { get; set; }
    public int NoofTablets { get; set; }
    public string Created_dttm { get; set; }

    }

    public class IPPrescriptionEMR
    {

        public string requestType { get; set; }
        public string PatientId { get; set; }
        public string VisitId { get; set; }
        public string prescription_Id { get; set; }
        public string Indent_Id { get; set; }
        public string Indent_type { get; set; }
        public string Indent_To { get; set; }
        public string DepId { get; set; }
        public string DoctorId { get; set; }
        public string wardid { get; set; }
        public string RoomId { get; set; }
        public string BedId { get; set; }
        public string IndentRemarks { get; set; }
        public DateTime Indentdatetime { get; set; }
        public string Indentuserid { get; set; }
        public List<IPPrescriptionLineItem> Orders_items { get; set; }


    }
    public class IPPrescriptionLineItem
    {

        public string item_id { get; set; }
        public string item_description { get; set; }
        public string quantity { get; set; }

    }
    public class PrescriptionLineItem
    {

        public string item_id { get; set; }
        public string item_description { get; set; }
        public string Dosage { get; set; }
        public string unit { get; set; }
        public string Route { get; set; }
        public string Instruction { get; set; }
        public string Days { get; set; }
        public string Frequency { get; set; }
        public string quantity { get; set; }
        public string Notes { get; set; }

    }
    public class CommonRequestDataDTO
    {
        public int consultationId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int visitId { get; set; }
        public PrescriptionDTO prescription = new PrescriptionDTO();
        public List<InvestigationDTO> orders = new List<InvestigationDTO>();
    }

    public class InvestigationDTO
    {
        public int orderId { get; set; }
        public List<ServiceItemsDTO> serviceItems = new List<ServiceItemsDTO>();

        public int id { get; set; }
        public int departmentId { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string clinicalReason { get; set; }
        public string priority { get; set; }
        public string planOfCare { get; set; }
        public int requestSequence { get; set; }
        public string requestType { get; set; }

        public int consultationId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int visitId { get; set; }
    }
    public class ServiceItemsDTO
    {
        public int id { get; set; }
        public int departmentId { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string clinicalReason { get; set; }
        public string priority { get; set; }
        public string planOfCare { get; set; }
    }
    public class PrescriptionDTO
    {
        public int prescriptionId { get; set; }
        public List<DrugsDTO> drugs = new List<DrugsDTO>();

        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string dosage { get; set; }
        public int duration { get; set; }
        public string durationType { get; set; }
        public string frequency { get; set; }
        public int quantity { get; set; }
        public string instruction { get; set; }
        public string route { get; set; }
        public string planOfCare { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int visitId { get; set; }

        public int requestSequence { get; set; }
        public string requestType { get; set; }
    }
    public class DrugsDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string dosage { get; set; }
        public int duration { get; set; }
        public string durationType { get; set; }
        public string frequency { get; set; }
        public int quantity { get; set; }
        public string instruction { get; set; }
        public string route { get; set; }
        public string planOfCare { get; set; }
    }
    public class clsAppAvailableSlotTimeDtl
    {
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }

    }


    public class clsGetCombinedData
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string MobileNos { get; set; }
        public int blocked { get; set; }
        public string Floor { get; set; }
        public int ExtnNos { get; set; }
        public string EmpName { get; set; }
        public string Language { get; set; }
        public string ContactNo { get; set; }
        public string Availability { get; set; }
        public string SpeeddialNos { get; set; }
        public string mobileno { get; set; }
        public string DoctorName { get; set; }
        public string email { get; set; }

    }

    //public class clsCUG
    //{
    //    public int id { get; set; }
    //    public string Name { get; set; }
    //    public string Department { get; set; }
    //    public string MobileNos { get; set; }
    //    public int blocked { get; set; }

    //}

    //public class clsEXTEN
    //{
    //    public int id { get; set; }
    //    public string Floor { get; set; }
    //    public string Name { get; set; }
    //    public string Department { get; set; }
    //    public int ExtnNos { get; set; }
    //    public int blocked { get; set; }


    //}

    //public class clsLanguage_Assis
    //{

    //    public int id { get; set; }
    //    public string EmpName { get; set; }
    //    public string Department { get; set; }
    //    public string Language { get; set; }
    //    public string ContactNo { get; set; }
    //    public string Availability { get; set; }
    //    public int blocked { get; set; }
    //    public string extensionno { get; set; }

    //}

    //public class clsSpeeddialNos  
    //{

    //    public int id { get; set; }
    //    public string Name { get; set; }
    //    public string Department { get; set; }
    //    public string SpeeddialNos { get; set; }
    //    public int blocked { get; set; }

    //}

    //public class clsHelplineNos
    //{

    //    public int id { get; set; }
    //    public string Department { get; set; }
    //    public string mobileno { get; set; }
    //    public int blocked { get; set; }

    //}
    //public class clsDoctornos
    //{
    //    public int id { get; set; }
    //    public string DoctorName { get; set; }
    //    public string Department { get; set; }
    //    public string email { get; set; }
    //    public string mobileno { get; set; }
    //    public int blocked { get; set; }
    //}

    public class opd_master_Res
    {
        public int Sno { get; set; }
        public string MsgDescp { get; set; }
        public int ReferenceNumber { get; set; }
        public string VisitId { get; set; }
        public int SurrogatedID { get; set; }
        public string Mobileno { get; set; }
        public string Emailid { get; set; }
        public int age { get; set; }
        public int appId { get; set; }
        public int docid { get; set; }
    }

    public class FinancialCounselling_req
    {
        public int Patientid { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentCode { get; set; }
        public string AdmDate { get; set; }
        public int ReqBedCat { get; set; }
        public int AllotedBedCat { get; set; }
        public string RoomNumber { get; set; }
        public string PlanOfTreatment { get; set; }
        public int RoomUpgrade { get; set; }
        public int EstimatedStay { get; set; }
        public int Deposit_Nbr { get; set; }
        public string CounselledDate { get; set; }
        public string CounselledId { get; set; }
        public int RoomTariff { get; set; }
        public int DrugConsumables { get; set; }
        public int Proceduresid { get; set; }
        public int BloodProduct { get; set; }
        public int ICUOthers { get; set; }
        public int Investigations { get; set; }
        public int DoctorFees { get; set; }
        public int Others { get; set; }
        public int EstimatedAmt { get; set; }
        public int Admissionid { get; set; }
        public int Isactive { get; set; }
        public string CreateddBy { get; set; }
        public string ModifiedBy { get; set; }
        public string PatientType { get; set; }
        public int IPFC_Payor { get; set; }
        public int Ispackage { get; set; }
        public int PackageId { get; set; }
        public string PackageInclusion { get; set; }
        public string PackageExclusion { get; set; }
        public string ImplantCharges { get; set; }
        public int TotalInsured { get; set; }
        public int Diagnosisid { get; set; }
        public int SURGICALPROCEDURE { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public int Nursingid { get; set; }
        public int DMOId { get; set; }
        public string ReportInTime { get; set; }
    }

    public class EXS_opd_master_Res
    {
        public int Sno { get; set; }
        public string MsgDescp { get; set; }
        public int ReferenceNumber { get; set; }
        public string VisitId { get; set; }
        public int SurrogatedID { get; set; }
        public string Mobileno { get; set; }
        public string Emailid { get; set; }
        public int age { get; set; }
        public int appId { get; set; }
        public int docid { get; set; }
        //public string DoctorName { get; set; }
        //public string BillVisitDATE { get; set; }

    }

    public class InsertCriticalCare_InfectiousDis_Res
    {
        public int Sno { get; set; }
        public string Msg { get; set; }

    }

    public class InsertDoctor_Directory_Js_Res
    {
        public int Sno { get; set; }
        public string Msg { get; set; }

    }


    public class UPDATEDoctor_Directory_Js_Res
    {
        public int Sno { get; set; }
        public string Msg { get; set; }

    }

    public class InsertCriticalCare_req
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email_ID { get; set; }
        public string MobileNo { get; set; }
        public string Institute_Organization { get; set; }
        public string DOB { get; set; }
        public string Designation { get; set; }
        public string RegistrationNoTNMC { get; set; }
        public string AddressofIns_Organization { get; set; }
        public string AreaofInterestinCCID { get; set; }

    }

    public class InsertDoctor_Directory_Js_req
    {

        public int doctorid { get; set; }
        public string doctorname { get; set; }
        public string department_Name { get; set; }
        public string subdepartment { get; set; }
        public string qualification { get; set; }
        public string designation { get; set; }
        public string profile_image { get; set; }
        public string tv_no { get; set; }
        public int slide_no { get; set; }
        public int sequence_no { get; set; }
        public string header { get; set; }

    }

    public class UPDATEDoctor_Directory_Js_req
    {

        public int doctorid { get; set; }
        public string doctorname { get; set; }
        public string department_Name { get; set; }
        public string subdepartment { get; set; }
        public string qualification { get; set; }
        public string designation { get; set; }
        public string profile_image { get; set; }
        public string tv_no { get; set; }
        public int slide_no { get; set; }
        public int sequence_no { get; set; }
        public string header { get; set; }

    }
    public class Otexcel
    {
        public string SNo { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string ScheduleTime { get; set; }
        public string TheaterName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ProcedureName { get; set; }
        public string Surgeon_Name { get; set; }

        public string Remarks { get; set; }
        public string Ward { get; set; }
    }
    public class clsWebMinar
    {
        public int Sno { get; set; }
        public string Result { get; set; }
    }

    public class clsdelPat
    {
        public int sno { get; set; }
        public string MsgDesc { get; set; }
    }
    public class Dropdown

    {
        public string Department { get; set; }
        public string DoctorName { get; set; }
        public string Qualification { get; set; }


    }


    public class BedRateAndNursingRate

    {
        public string BedCategory { get; set; }
        public string ChType { get; set; }
        public int Rate { get; set; }

    }

    public class BedDetails_Load

    {
        public string MBED_BEDNO_CD { get; set; }
        public int MBED_BEDID_ID { get; set; }


    }

    public class Get_BedID

    {
        public string MBED_BEDNO_CD { get; set; }

    }

    public class Dropdown1
    {
        public string Patient_UHID { get; set; }
        public string Token_No { get; set; }
        public string Status { get; set; }
    }
    public class clsResult
    {
        public int Sno { get; set; }
        public string SurrogatedID { get; set; }
        public string MsgDescp { get; set; }
        public string ServiceOrderNo { get; set; }

    }



    public class clsFinancialResult
    {
        public int Sno { get; set; }
        public string MsgDescp { get; set; }

    }


    public class clsdepResult
    {
        public int Sno { get; set; }
        public int UHID { get; set; }
        public string MsgDescp { get; set; }


    }

    public class clsrefincoun_save
    {
        public int Id { get; set; }
        public string Msgdesc { get; set; }

    }

    public class clsIPBedBlock_Save
    {
        public int Sno { get; set; }
        public string MsgDesc { get; set; }

    }

    public class clsIPBedBlock_Clear
    {
        public int Sno { get; set; }
        public string MsgDesc { get; set; }

    }

    public class clsIPBedBlock
    {
        public int BEDID { get; set; }
        public int CrPatientID { get; set; }
        public int FuPatientID { get; set; }
        public string CREATEDBY { get; set; }

    }

    public class reqIPBedBlock_Clear
    {
        public string Remark { get; set; }
        public string LASTMODIFIEDBY { get; set; }
        public int BEDID { get; set; }

    }

    public class opInvoiceLine
    {
        public int RegistrationID { get; set; }
        public int ServiceID { get; set; }
        public decimal Unit { get; set; }
        public decimal Rate { get; set; }
        public int DiscType { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public int PriorityID { get; set; }
        public string Remarks { get; set; }
    }

    public class opInvoiceHead
    {
        public string UHID { get; set; }
        public int DoctorID { get; set; }
        public string UserID { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GLAmount { get; set; }
        public string PatientResponsibility { get; set; }
        public decimal NetAmount { get; set; }
        public List<opInvoiceLine> opInvoiceLine { get; set; }
    }

    public class clsopInvoice
    {
        public string SNo { get; set; }
        public string UHID { get; set; }
        public string EpisodeNo { get; set; }
        public string OrderDate { get; set; }
        public string PatientType { get; set; }
        public Department Department { get; set; }
        public clsDropDown Doctor { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public decimal GLAmount { get; set; }
        public string PatientResponsibility { get; set; }
        public string UserID { get; set; }
        public List<clsInvoiceLine> opInvoiceLine { get; set; }
        public string Unit { get; set; }
        public string Discount { get; set; }
        public string Remarks { get; set; }

    }

    public class clsdeposit
    {
        public int PatientId { get; set; }
        public int DepAmomunt { get; set; }
        public string UserId { get; set; }
        public int DepositType { get; set; }
        public List<clsdepositLine> clsdepositLine { get; set; }
    }

    public class clsrefincoun
    {
        public int Counselling { get; set; }
        public string RevisedEstimationStaty { get; set; }
        public int CurrentBillAmount { get; set; }
        public int RecounselledAmount { get; set; }
        public int DepositAmount { get; set; }
        public string StayExceeding_Desc { get; set; }
        public string AdditionalProcedures { get; set; }
        public string MedicalReason { get; set; }
        public string Remarks { get; set; }
        public string PatientType { get; set; }
        public int payorid { get; set; }
        public int Roomcategory { get; set; }
        public string CreatedById { get; set; }

    }


    public class clsdepositLine
    {

        public string PayType { get; set; }
        public string CardNo { get; set; }
        public int amount { get; set; }
        public string ContraVoucherNo { get; set; }
        public int CreditCardId { get; set; }
        public DateTime ValidityDate { get; set; }
        public int AuthorisationNo { get; set; }

    }

    public class clsInvoiceLine
    {
        public int SNO { get; set; }
        public int RegistrationId { get; set; }
        public int Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public ServiceGroup ServiceGroup { get; set; }
        public Service Service { get; set; }
        public DiscountType DiscountType { get; set; }
        public clsPriority Priority { get; set; }
    }
    public class Service
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
        public int value { get; set; }
        public string label { get; set; }
    }

    public class DiscountType
    {
        public int value { get; set; }
        public string label { get; set; }
    }
    public class req_chargeload_v1
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
        public string responseType { get; set; }
        public int ISVariable_flg { get; set; }
        public int RCTYpe { get; set; }


    }
    public class clsPriority
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
        public int value { get; set; }
        public string label { get; set; }
    }
    public class reqRef_Relationship
    {
        public int ColumnCode { get; set; }
        public string ColumnName { get; set; }
    }

    public class SurgProcname
    {
        public int ColumnCode { get; set; }
        public string ColumnName { get; set; }
    }

    public class reqRef_DoctorData
    {
        public int ColumnCode { get; set; }
        public string ColumnName { get; set; }

    }
    public class ServiceGroup
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
        public int value { get; set; }
        public string label { get; set; }
    }
    public class clsDropDown
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
        public string responseType { get; set; }
    }


    public class clsbedRes
    {
        public string Ward_ICU_Name { get; set; }
        public string Ward_No { get; set; }
        public string COVID_Non_COVID { get; set; }
        public int Total_Beds { get; set; }
        public string Cradle { get; set; }
        public int Occupied { get; set; }
        public int Under_Maintenance { get; set; }
        public int Blocked { get; set; }
        public int Available_Beds { get; set; }
        public int Marked_for_Disharge { get; set; }
        public int Marked_for_Transfer { get; set; }
        public int New_IP_Admissions_for_the_day { get; set; }
    }
    public class contryDropDown
    {
        public int columnCode { get; set; }
        public int nationalitycode { get; set; }
        public string columnName { get; set; }
        public string responseType { get; set; }
    }
    #endregion
    public class reswebPatientDtl

    {
        public string Sno { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Yrs { get; set; }
        public string Mths { get; set; }
        public string Days { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
    }
    public class resDropDown
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
    }

    public class Department
    {
        public int columnCode { get; set; }
        public string columnName { get; set; }
        public string responseType { get; set; }
        public int value { get; set; }
        public string label { get; set; }
    }



    public class pay_request
    {
        public long PaymentID { get; set; }
        public string RefID { get; set; }
        public string RefType { get; set; } = "";
        public string PatientID { get; set; } = "";
        public string PatientName { get; set; } = "";
        public string MobileNo { get; set; } = "";
        public string EmailID { get; set; } = "";
        public int DoctorID { get; set; } = 0;
        public string TransactionDate { get; set; } = DateTime.Now.ToString();
        public string TransactionID { get; set; } = "";
        public string TransactionAmount { get; set; } = "0.00";
        public string PaymentMode { get; set; } = "";
        public string StatusCode { get; set; } = "";
        public string StatusMsg { get; set; } = "";
        public string PaymentStatus { get; set; } = "";
        public string Remarks { get; set; } = "";
        public int IsActiveflg { get; set; } = 0;
        public string CreatedCode { get; set; } = "MEFTEC";
        public string APPStartDate { get; set; }
        public string APPEndDate { get; set; }
        public string AppointmentId { get; set; }

    }
    public class payment_request
    {

        public long PaymentID { get; set; }
        public string RefID { get; set; }
        public string RefType { get; set; } = "";
        public string PatientID { get; set; } = "";
        public string PatientName { get; set; } = "";
        public string MobileNo { get; set; } = "";
        public string EmailID { get; set; } = "";
        public int DoctorID { get; set; } = 0;
        public string TransactionDate { get; set; } = DateTime.Now.ToString();
        public string TransactionID { get; set; } = "";
        public string TransactionAmount { get; set; } = "0.00";
        public string PaymentMode { get; set; } = "";
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ApprovalCode { get; set; }
        public string PaymentMethod { get; set; }
        public string StatusCode { get; set; } = "";
        public string StatusMsg { get; set; } = "";
        public string PaymentStatus { get; set; } = "";
        public string Remarks { get; set; } = "";
        public int IsActiveflg { get; set; } = 0;
        public string CreatedCode { get; set; } = "MEFTEC";
        public string CreatedDate { get; set; } = DateTime.Now.ToString();
        public string Religion { get; set; }
        public string PrefferedLanguage { get; set; }
        public int annualIncome { get; set; }
        public string bloodGroup { get; set; }
        public string APPStartDate { get; set; }
        public string APPEndDate { get; set; }
        public int AppointmentId { get; set; }

    }


    public class Response_pay
    {
        public long ResultCode { get; set; }
        public string Result { get; set; }
    }
    public class Response_DTO_v1
    {
        public long ResultCode { get; set; }
        public string Result { get; set; }
    }
    public class OTP_Resp
    {
        public string status { get; set; }
        public string response { get; set; }
        public int responsecode { get; set; }
        public List<PatientDTO> patientDTO { get; set; }
    }
    public class PatientDTO
    {
        public string Authenticated { get; set; }
        public string MobileNo { get; set; }
        public string OTP { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }

        public string Email { get; set; }
        public string IDDesc { get; set; }
        public int IDTypeCode { get; set; }

        public string CountryCode { get; set; }

        public string Doctor { get; set; }
        public string Department { get; set; }
        public string AppDate { get; set; }
        public string AppTime { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }

        public string UserName { get; set; }
        public int DepId { get; set; }
        public string AppStartDate { get; set; }
        public string AppEndDate { get; set; }
        public string PaymentStatus { get; set; }
        public string RefId { get; set; }
        public string PatientType { get; set; }
        public long AutoId { get; set; }

    }
    public class reqPatientDTO
    {
        public string Authenticated { get; set; }
        public string MobileNo { get; set; }
        public string OTP { get; set; }

    }
    public class Response_v1
    {
        public int sno { get; set; }
        public string patient_name { get; set; }
        public string patient_gender { get; set; }
        public string patient_dob { get; set; }
        public string patient_mobilenumber { get; set; }
        public string Patient_lastmodified { get; set; }
        public string Msg { get; set; }

    }

    public class Authenticate
    {
        public int sno { get; set; }
        public string patient_name { get; set; }
        public string patient_gender { get; set; }
        public string patient_dob { get; set; }
        public string patient_mobilenumber { get; set; }
        public string Patient_lastmodified { get; set; }
        public string Response { get; set; }

    }
    public class SendPatient_v1
    {
        public string MobileNo { get; set; }
        public string OTP { get; set; }


    }
    public class PincodeResuest
    {
        public int CountryCode { get; set; }
        public int StateCode { get; set; }
        public int PinCode { get; set; }
    }

    public class PincodewiseDataDTO
    {
        public int CountryCode { get; set; }
        public string CountryName { get; set; }
        public int StateCode { get; set; }
        public string StateName { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public int PinCode { get; set; }
        public int NationalityCode { get; set; }
    }
    public class SendPatientDTO
    {     
        public string Authenticated { get; set; }
        public string MobileNo { get; set; }
        public string OTP { get; set; }
    }
    public class Response_DTO
    {
        public String ResultCode { get; set; }
        public string Result { get; set; }
        public int RegId { get; set; }
        public int DepId { get; set; }
        public int DocId { get; set; }
        public string DoctorName { get; set; }
        public int UHID { get; set; }
        public int UserCode { get; set; }

    }
    public class BedBlockDetails
    {
        public int SNo { get; set; }
        public int BedId { get; set; }
        public string CATEGORY { get; set; }
        public string WARD { get; set; }
        public string BED { get; set; }
        public string BEDSTATUS { get; set; }
        public string UHID { get; set; }
        public string PATIENTNAME { get; set; }
        public string FUTUREUHID { get; set; }
        public string FUTUREPATIENTNAME { get; set; }
        public int Allocated { get; set; }
        public int Active { get; set; }
        public string PIN { get; set; }

    }

    public class CriticalCare
    {
        //public int sno { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Email_ID { get; set; }
        public string MobileNo { get; set; }
        public string Ins_Organization_nm { get; set; }
        public string DOB { get; set; }
        public string Designation { get; set; }
        public string RegistrationNo_TNMC { get; set; }
        public string AddressofIns_Organization { get; set; }
        public string AreaofInterestinCCID { get; set; }
        public string CreatedDt { get; set; }

    }


    public class UpdateTVbackgraound_Res
    {
        public int Sno { get; set; }
        public string Msg { get; set; }

    }
    public class TVbackgraound

    {
        public int tvid { get; set; }
        public string tvname { get; set; }
        public string imageurl { get; set; }

    }


    public class UpdateTVbackgraound_req

    {
        public int tvid { get; set; }
        public string tvname { get; set; }
        public string imageurl { get; set; }

    }
    public class Doctor_Directory
    {

        public int doctorid { get; set; }
        public string doctorname { get; set; }
        public string department_Name { get; set; }
        public string subdepartment { get; set; }
        public string qualification { get; set; }
        public string designation { get; set; }
        public string profile_image { get; set; }
        public string tv_no { get; set; }
        public int slide_no { get; set; }
        public int sequence_no { get; set; }
        public string header { get; set; }

    }

    public class clsWebExisitingPatientAppointment
    {
        public int Sno { get; set; }
        public string MsgDesc { get; set; }

    }




    public class reqAppVisit
    {
        public string patientId { get; set; }
        public int docId { get; set; }
        public string userId { get; set; }
        public int appointmentId { get; set; }
        public int RefSource { get; set; }
        public int VistType { get; set; }
        public string PatientType { get; set; }
        public int PayorID { get; set; }
        public string Remarks { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int InternalDocId { get; set; }
        public int ExternalDocId { get; set; }
    }

    public class clsWebExisitingPatientAppointmenthead
    {
        public int UHID { get; set; }
        public int DocId { get; set; }
        public DateTime APPStartDate { get; set; }
        public string UserId { get; set; }
        public string Package { get; set; }
        public string Remarks { get; set; }
        public string RefSource { get; set; }


    }

    public class OPBillRecepitHead
    {
        public string UHID { get; set; }
        public int DoctorID { get; set; }
        public string UserID { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GLAmount { get; set; }
        public string PatientResponsibility { get; set; }
        public decimal NetAmount { get; set; }
        public List<OPBillRecepitLine> OPBillRecepitLine { get; set; }
        public List<OPReceipt_Payment_Line> OPReceipt_Payment_Line { get; set; }
    }
    public class Save_QMSDetails
    {
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string Type { get; set; }
        public string username { get; set; }


    }

    public class req_Save_QMSDetails
    {
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string Type { get; set; }

    }
    public class DayWise_QMSDetails
    {
        public string PatientName { get; set; }
        public int TokenNo { get; set; }
        public string TokenType { get; set; }
        public string Processing_time { get; set; }
        public string Completed_time { get; set; }

    }

    public class RadiologyAppointment
    {
        public string DoctorName { get; set; }
        public string APPID { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public int Tokenno { get; set; }
        public string Status { get; set; }

    }

    public class res_opiprevenue
    {
        public string OrderDoctor { get; set; }
        public string OrderDepartment { get; set; }
        public string OrderDate { get; set; }
        public string VisitType { get; set; }
        public string GrossAmount { get; set; }
        public string Discount { get; set; }
        public string Net { get; set; }

    }



    public class res_EMRAPILog
    {
        public int SNo { get; set; }
        public string APIType { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string status { get; set; }
        public string HostName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }

    }

    public class DayWise_QMSDetails_test
    {
        public string PatientName { get; set; }
        public int TokenNo { get; set; }
        public string TokenType { get; set; }
        public string Processing_time { get; set; }
        public string Completed_time { get; set; }

    }
    public class DepPatAmt_Details
    {
        public int surrogateID { get; set; }
        public string ReceiptNo { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptTime { get; set; }
        public int CashAmt { get; set; }
        public int ChequeAmt { get; set; }
        public int CreditAmt { get; set; }
        public int ReceiptAmt { get; set; }
        public int ContraAmt { get; set; }
        public int AllocatedPatientID { get; set; }
        public int AmountUsed { get; set; }
        public int BalanceAmt { get; set; }
        public int Allocated { get; set; }
        public string CancelBillNo { get; set; }
        public string DepositType { get; set; }

    }

    public class resOPList
    {
        public string SNO { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string VisitID { get; set; }
        public string VisitDate { get; set; }
        public string TokenNo { get; set; }
        public string PartyName { get; set; }
        public string RegTyp { get; set; }
        public string Nationality { get; set; }
        public string RegId { get; set; }
        public string MRN { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public clsDropDown Doctor { get; set; }
        public clsDropDown Department { get; set; }
    }

    public class clsPatientRegistrationPdf
    {
        public long PatientId { get; set; }
        public string RegDate { get; set; }
        public string PatientFirstName { get; set; }
        public string AgeOfPatient { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string StateCode { get; set; }
        public string CountryName { get; set; }
        public string ConAddress1 { get; set; }
        public string ConAddress2 { get; set; }
        public string ConAddress3 { get; set; }

        public string DoctorName { get; set; }
        public string PostBoxNo { get; set; }
        public string DeptName { get; set; }
        public string InvoiceNo { get; set; }
        public string MobileNumber { get; set; }
        public string AltMobNumber { get; set; }
        public string PatientStatus { get; set; }
        public string ReligionName { get; set; }
        public string RaceName { get; set; }

        public string OccupationName { get; set; }
        public string MaritialStatus { get; set; }
        public string OfficePhone1 { get; set; }
        public string HomePhone1 { get; set; }
        public string EmailId { get; set; }
        public string Fax { get; set; }
        public string ReferralSource { get; set; }

        public string DOB { get; set; }
        public string Salutation { get; set; }
        public string CityCode { get; set; }
        public string KinName { get; set; }

        public string KinRelation { get; set; }
        public string KinPhoneResi { get; set; }
        public string KinPhoneOff1 { get; set; }
        public string KinAddress { get; set; }
        public string KinAddress1 { get; set; }
        public string KinAddress2 { get; set; }
        public string KinAddress3 { get; set; }
        public string PatIDNo { get; set; }
        public string KinCountry { get; set; }
        public string KinRltion { get; set; }
        public string KinPostalCode { get; set; }
        public string KinMobileNumber { get; set; }
        public string KinFax { get; set; }
        public string KinEmail { get; set; }
        public string KinStateCode { get; set; }
        public string KinCityCode { get; set; }
        public string VIPPATIENT { get; set; }
        public string SelfEligible { get; set; }
        public string RegisteredUser { get; set; }
        public string RegisteredDateTime { get; set; }
        public int IDTypeCd { get; set; }
        public string IDName { get; set; }
        public string LanguageName { get; set; }
        public string NameofEmp { get; set; }
        public string Designation { get; set; }
        public int Annual_Income { get; set; }
        public int ReferralSourceId { get; set; }
        public string OtherRemarks { get; set; }
        public int Annual_Incomebelow { get; set; }
        public int Annual_IncomeAbove { get; set; }
        public string VistiType { get; set; }

        public int Symptomscnt { get; set; }
        public int historyoffevercnt { get; set; }
        public int outofcountrycnt { get; set; }
        public int diseaseoutbreakcnt { get; set; }
        public int healthcareworkercnt { get; set; }
        public int diseasecnt { get; set; }
        public int diarrheasymptomscnt { get; set; }
        public int activeTBcnt { get; set; }
        public int chickenpox { get; set; }
        public int measles { get; set; }
        public int mumps { get; set; }
        public int rubella { get; set; }

    }
    public class clsRadLandingScreen
    {
        public string PatientType { get; set; }
        public string PatientVisitType { get; set; }
        public string OrderID { get; set; }
        public int PackOrderID { get; set; }
        public string OrderDate { get; set; }
        public string VisitID { get; set; }
        public string PreRegID { get; set; }
        public int MRN { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string OrderDesc { get; set; }
        public string AccessionNo { get; set; }
        public string Modality { get; set; }
        public string ServiceName { get; set; }
        public int ChargeID { get; set; }
        public int LabTestID { get; set; }
        public int ProfileID { get; set; }
        public int TestConfig { get; set; }
        public int RequisitionID { get; set; }
        public string STATUS { get; set; }
        public string Remarks { get; set; }
        public string ServiceRemarks { get; set; }
        public string Priority { get; set; }
        public string PlannedDt { get; set; }
        public string PlannedTm { get; set; }
        public string ReportingDr { get; set; }
        public string CompletedBy { get; set; }
        public string CompletedDate { get; set; }
        public string ReportDate { get; set; }
        public string ORDERBY { get; set; }
        public int CancelFlag { get; set; }
        public string WardName { get; set; }
        public string BillNo { get; set; }
        public string RegType { get; set; }
        public string UHID { get; set; }
        public string Age { get; set; }

    }


    public class clsCardiologyLanding
    {
        public string PatientType { get; set; }
        public string OrderID { get; set; }
        public int PackOrderID { get; set; }
        public string OrderDate { get; set; }
        public string VisitID { get; set; }
        public string PreRegID { get; set; }
        public int MRN { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string OrderDesc { get; set; }
        public string AccessionNo { get; set; }
        public string Modality { get; set; }
        public string ServiceName { get; set; }
        public int ChargeID { get; set; }
        public int LabTestID { get; set; }
        public int ProfileID { get; set; }
        public int TestConfig { get; set; }
        public int RequisitionID { get; set; }
        public string STATUS { get; set; }
        public string Remarks { get; set; }
        public string ServiceRemarks { get; set; }
        public string Priority { get; set; }
        public string ReportDate { get; set; }
        public string ORDERBY { get; set; }
        public int CancelFlag { get; set; }
        public string WardName { get; set; }
        public string BillNo { get; set; }
        public string RegType { get; set; }
        public string Started { get; set; }
        public string ResultEntryDate { get; set; }
        public string Authenticate { get; set; }
        public string ResultCompleted { get; set; }
        public string Age { get; set; }

    }

    public class clsNMLanding_Dtl
    {
        public string PatientType { get; set; }
        public string PatientVisitType { get; set; }
        public string OrderID { get; set; }
        public int PackOrderID { get; set; }
        public string OrderDate { get; set; }
        public string VisitID { get; set; }
        public string PreRegID { get; set; }
        public int MRN { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string OrderDesc { get; set; }
        public string AccessionNo { get; set; }
        public string Modality { get; set; }
        public string ServiceName { get; set; }
        public int ChargeID { get; set; }
        public int LabTestID { get; set; }
        public int ProfileID { get; set; }
        public int TestConfig { get; set; }
        public int RequisitionID { get; set; }
        public string STATUS { get; set; }
        public string Remarks { get; set; }
        public string ServiceRemarks { get; set; }
        public string Priority { get; set; }
        public string PlannedDt { get; set; }
        public string PlannedTm { get; set; }
        public string ReportingDr { get; set; }
        public string CompletedBy { get; set; }
        public string CompletedDate { get; set; }
        public string ReportDate { get; set; }
        public string ORDERBY { get; set; }
        public int CancelFlag { get; set; }
        public string WardName { get; set; }
        public string BillNo { get; set; }
        public string RegType { get; set; }
        public string UHID { get; set; }
        public string Age { get; set; }

    }

    public class clsWeb_GetRadRequisitionSlipDetail

    {
        public string RegNo { get; set; }
        public string LabNo { get; set; }
        public string LabDate { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public int TokenNo { get; set; }
        public string ChargeName { get; set; }
        public string ResultDate { get; set; }
        public string ResultTime { get; set; }
        public string SampleName { get; set; }
        public string LabNoPrefix { get; set; }
        public string LabNoSuffix { get; set; }
        public string SampleCollect { get; set; }
        public string SampleCollectDate { get; set; }
        public int AdmisionNo { get; set; }
        public string CollectStatus { get; set; }
        public string ClinicalDiag { get; set; }

    }

    public class clsweb_RadPatientSearch
    {
        public string MRN { get; set; }

        public string PatientName { get; set; }

        public string MobileNo { get; set; }

        public string Type { get; set; }

        public string DoctorName { get; set; }

        public string DepartmentName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Status { get; set; }

        public string Eligibility { get; set; }

        public string ReasonForVisit { get; set; }

        public string Country { get; set; }

        public string Rad_Online { get; set; }

        public string AppointmentType { get; set; }

    }

    public class clsweb_NMPatientSearch
    {
        public string MRN { get; set; }

        public string PatientName { get; set; }

        public string MobileNo { get; set; }

        public string Type { get; set; }

        public string DoctorName { get; set; }

        public string DepartmentName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Status { get; set; }

        public string Eligibility { get; set; }

        public string ReasonForVisit { get; set; }

        public string Country { get; set; }

        public string Rad_Online { get; set; }

        public string AppointmentType { get; set; }

    }



    public class clsweb_MediScanPatientSearch
    {
        public string MRN { get; set; }

        public string PatientName { get; set; }

        public string MobileNo { get; set; }

        public string Type { get; set; }

        public string DoctorName { get; set; }

        public string DepartmentName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Status { get; set; }

        public string Eligibility { get; set; }

        public string ReasonForVisit { get; set; }

        public string Country { get; set; }

        public string Rad_Online { get; set; }

        public string AppointmentType { get; set; }

    }
    public class QMSDetails
    {
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public int TokenNo { get; set; }
        public string TokenDate { get; set; }
        public string StausFlag { get; set; }
        public string Processing_time { get; set; }
        public string Completed_time { get; set; }


    }

    public class QMSDetails_test
    {
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public int TokenNo { get; set; }
        public string TokenDate { get; set; }
        public string StausFlag { get; set; }
        public string Processing_time { get; set; }
        public string Completed_time { get; set; }

    }

    public class resAppointmentList
    {
        public string Sno { get; set; }
        public string UHID { get; set; }
        public clsDropDown Salutation { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Nationality { get; set; }
        public clsDropDown Doctor { get; set; }
        public clsDropDown Department { get; set; }
        public string AppDate { get; set; }
        public string AppTime { get; set; }
        public string Reason { get; set; }
        public string VisitType { get; set; }
        public string ReferralSource { get; set; }
        public string UserName { get; set; }
        public string Bookingdate { get; set; }
        public string Status { get; set; }
        public string CancelDate { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public string VisitNo { get; set; }
        public string NoofBills { get; set; }
        public int AppointmentId { get; set; }
        public int AppPatienttId { get; set; }

    }

    public class resAppointmentListALL
    {
        public string Sno { get; set; }
        public string UHID { get; set; }
        public clsDropDown Salutation { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Nationality { get; set; }
        public clsDropDown Doctor { get; set; }
        public clsDropDown Department { get; set; }
        public string AppDate { get; set; }
        public string AppTime { get; set; }
        public string Reason { get; set; }
        public string VisitType { get; set; }
        public string ReferralSource { get; set; }
        public string UserName { get; set; }
        public string Bookingdate { get; set; }
        public string Status { get; set; }
        public string CancelDate { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public string VisitNo { get; set; }
        public string NoofBills { get; set; }
        public int AppointmentId { get; set; }
        public int AppPatienttId { get; set; }
        public int DoctorId { get; set; }
        public int DepId { get; set; }
        public string Abkg_AppointmentStartDate_dt { get; set; }

    }
    public class DepositeDtl_ReprintList
    {
        public string Depositno { get; set; }
        public string Pin { get; set; }
        public string PatientName { get; set; }
        public string SALUTATION { get; set; }
        public string DepositDate { get; set; }
        public int Amount { get; set; }
        public string DepositType { get; set; }

    }
    public class DepositePatientDtl
    {

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int AgeInYears { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string MaritialStatus { get; set; }
        public string IDtype { get; set; }
        public string IDNo { get; set; }
        public int AvlAmt { get; set; }



    }


    public class DepositeReprint_OutputDtl
    {

        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string ZIP { get; set; }
        public string State { get; set; }
        public string COUNTRY { get; set; }
        public int AMOUNT { get; set; }
        public string ReceiptNo { get; set; }
        public string PAYDATE { get; set; }
        public string VoucherNo { get; set; }
        public string CASHIER { get; set; }
        public string CASHIERID { get; set; }
        public string Payment_Type { get; set; }

    }








    public class QMSStatus_Dtl
    {
        public int TokenID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string TokenDate { get; set; }
        public string TokenNo { get; set; }
        public string TokenType { get; set; }
        public int StausFlag { get; set; }

    }
    public class VisitWithAppointment_Detail
    {
        public int UHID { get; set; }
        public int DocId { get; set; }
        public DateTime APPStartDate { get; set; }
        public string UserId { get; set; }
        public string Package { get; set; }
        public string Remarks { get; set; }
        public int RefSource { get; set; }
        public int AppointmentId { get; set; }
        public int VisitRefSource { get; set; }
        public int VistType { get; set; }
        public string PatientType { get; set; }
        public int PayorID { get; set; }
        public string VisitRemarks { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int InternalDocId { get; set; }
        public int ExternalDocId { get; set; }
    }


    public class salucroresponse
    {
        public salucroresponse()
        {
        }

        public int status_code { get; set; }
        public string status_message { get; set; }
        public string username { get; set; }
        public string processing_id { get; set; }
        public Accounts accounts { get; set; }
        public string transaction_id { get; set; }
        public object payment_method { get; set; }
        public object payment_location { get; set; }
        public string custom { get; set; }
        public PaymentResponse payment_response { get; set; }
        public string payment_source { get; set; }
        public string check_sum_hash { get; set; }
    }


    public class Accounts
    {
        public Accounts()
        {
        }

        public string patient_name { get; set; }
        public string account_number { get; set; }
        public string amount { get; set; }
    }


    public class PaymentResponse
    {
        public PaymentResponse()
        {
        }

        public string prod { get; set; }
        public string mmp_txn { get; set; }
        public string udf5 { get; set; }
        public string udf6 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string desc { get; set; }
        public string key { get; set; }
        public string bank_name { get; set; }
        public string responseKey { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string txnid { get; set; }
        public string amt { get; set; }
        public string package_code { get; set; }
        public string transaction_type { get; set; }
        public string appointment_id { get; set; }
        public string approvalCode { get; set; }
        public string cardType { get; set; }
        public string cardHolderName { get; set; }
        public string clientcode { get; set; }
        public string paymentMode { get; set; }
        public string udf9 { get; set; }
        public string f_code { get; set; }
        public string transactionReference { get; set; }
        public string responseMessage { get; set; }
        public string acquirerBank { get; set; }
        public string transactionDateTime { get; set; }
        public string rrn { get; set; }
        public string MerchantID { get; set; }
        public string MerchantTxnID { get; set; }
        public string VERIFIED { get; set; }
        public string BID { get; set; }
        public string bankname { get; set; }
        public string bank_txn { get; set; }
        public string atomtxnId { get; set; }
        public string surcharge { get; set; }
        public string CardNumber { get; set; }
        public string TxnDate { get; set; }
        public string reconstatus { get; set; }
        public string sdt { get; set; }
        public string responseStatus { get; set; }
        public int code { get; set; }
        public string payment_type { get; set; }
        public bool testMode { get; set; }
        public string signature { get; set; }
        public string discriminator { get; set; }
        public string amount { get; set; }
    }
    public class InvoiceLine1
    {
        public String DateofService { get; set; }
        public string Service_Name { get; set; }
        public string Services { get; set; }
        public string Qty { get; set; }
        public String UnitPrice { get; set; }
        public String GroupTotal { get; set; }
        public String ResultTime { get; set; }

    }
    public class InvoiceHead1
    {
        public string Sno { get; set; }

        public string UHIDNo { get; set; }
        public string EpisodeNo { get; set; }
        public string BillNo { get; set; }
        public string PatientName { get; set; }
        public string Doctor { get; set; }
        public string BillDate { get; set; }
        public string DOB_Gender { get; set; }

        public string Payor { get; set; }
        public string GSTNo { get; set; }
        public string CasherSignature { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public string Detail_Type { get; set; }
        public string Payment_Type { get; set; }
        public decimal SettleAmount { get; set; }
        public string AmountinWords { get; set; }
        public String BillStatus { get; set; }
        public String CreditNote { get; set; }
        public List<InvoiceLine1> InvoiceLine1 { get; set; }

    }
    public class reqInvoice_Reprint_List
    {
        public string Sno { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Regid { get; set; }
        public string VisitNo { get; set; }
        public string VisitDate { get; set; }
        public int BillNum { get; set; }
        public int InternalNo { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public decimal BillAmount { get; set; }
        public decimal SelfAmount { get; set; }
        public decimal PartyAmount { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
       // public int DepartmentCode { get; set; }
    //    public string DepartmentName { get; set; }
        public string UserId { get; set; }
        public int ISCancelled { get; set; }
        public string PartyCode { get; set; }
        public string BillStatus { get; set; }
        public int ins { get; set; }
        public string PartyName { get; set; }
     //   public string Mobileno { get; set; }
      //  public string Email { get; set; }

    }


    public class Res_AvlSlotValidation
    {
        public int Abkg_AppointmentId_id { get; set; }

    }


    public class Res_insurance_Patient
    {
        public int S_No { get; set; }
        public string Admission_Date { get; set; }
        public string BedName { get; set; }
        public string UHID { get; set; }
        public string Patient_Name { get; set; }
        public string PayorName { get; set; }
        public string Claim_No { get; set; }
        public string Admitting_Consultant { get; set; }
        public string Admitting_Department { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Admission_Category { get; set; }
        public string Discharge_Date { get; set; } 
        public string Bill_No { get; set; }
        public decimal Insurance_Amount { get; set; }
        public decimal Due { get; set; }
        public string AdmNo { get; set; }
        public string Nationality { get; set; }
        public string MainInsurance { get; set; }
        public string CompanyName { get; set; }
        public string Gipsa { get; set; }
        public string PPNGipsa { get; set; }
    }


    public class clsFinancialCounsellingprint
    {
        public string Uhid { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string AdmittingDoctor { get; set; }
        public string DOA { get; set; }
        public int reqcat { get; set; }
        public string RoomCategory { get; set; }
        public string AllotedCategory { get; set; }
        public int DepositAmt { get; set; }
        public string RoomNumber { get; set; }
        public string Roomupgrade { get; set; }
        public string Treatmentplan { get; set; }
        public string ProcedureName { get; set; }
        public string Expecteddeliverydate { get; set; }
        public int EstimatedSaty { get; set; }
        public string Speciality { get; set; }
        public string Diagnosis { get; set; }
        public int DiagnosisId { get; set; }
        public string Pattitle { get; set; }
        public string PatNam { get; set; }
        public int totaestimation { get; set; }
        public string PatientType { get; set; }
        public int Payorid { get; set; }
        public string PayorCategory { get; set; }
        public int TotSum { get; set; }
        public int Package { get; set; }
        public string packagename { get; set; }
        public int packageinclusion { get; set; }
        public int packageexclusion { get; set; }
        public int implantCharges { get; set; }
        public int RoomTariff { get; set; }
        public int DrugConsumbles { get; set; }
        public int bedsideprocedures { get; set; }
        public int bloodproduct { get; set; }
        public int ICU { get; set; }
        public int investigations { get; set; }
        public int doctorfees { get; set; }
        public int othercharges { get; set; }
        public string CounselledBy { get; set; }
        public string CounselledDate { get; set; }
        public string Kindetail { get; set; }
        public string Relationship { get; set; }
        public string Attachment { get; set; }
        public string AttachName { get; set; }
        public string ReportOutTime { get; set; }
        public string ReportingInTime { get; set; }
        public int NursingCharge { get; set; }
        public int DMORate { get; set; }

    }

    public class FinCouncil_Detail_Load
    {
        public int counselid { get; set; }
        public int MRN { get; set; }
        public string Title { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string AdmDate { get; set; }
        public int reqcat { get; set; }
        public string ReqCategoryName { get; set; }
        public int AllotedId { get; set; }
        public string AllotedCategory { get; set; }
        public string RoomNumber { get; set; }
        public string PlanTreat { get; set; }
        public int RoomUpgrade { get; set; }
        public int Stay { get; set; }
        public int Deposit { get; set; }
        public string Counselled { get; set; }
        public string CounselledBy { get; set; }
        public int RoomTariff { get; set; }
        public int DrugConsumable { get; set; }
        public int Proce { get; set; }
        public int BloodProduct { get; set; }
        public int ICUOther { get; set; }
        public int Investigation { get; set; }
        public int DoctorFee { get; set; }
        public int others { get; set; }
        public int ESAmt { get; set; }
        public int DepositFlg { get; set; }
        public string Aukthorizedby { get; set; }
        public string AuthorizedDate { get; set; }
        public string Patienttype { get; set; }
        public int Payorid { get; set; }
        public string Payor { get; set; }
        public string DiagnosisName { get; set; }
        public int DiagnosisId { get; set; }

    }

    public class clswebRef_patient
    {
        public string Sno { get; set; }
        public int UHID { get; set; }
        public clsDropDown Salutation { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        //public List<clsDropDown> MaritialStatus { get; set; }
        public clsDropDown MaritialStatus { get; set; }
        public clsDropDown Nationality { get; set; }
        public clsDropDown ID { get; set; }
        public string IDNo { get; set; }
        public clsDropDown Rrefsource { get; set; }
        public string VisitType { get; set; }
        public clsDropDown Doctor { get; set; }
        public clsDropDown Department { get; set; }
        public clsDropDown State { get; set; }
        public clsDropDown City { get; set; }
        public clsDropDown Occupation { get; set; }
        public string Pattype { get; set; }
        public string PayerName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Pincode { get; set; }
        public clsDropDown Country { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public clsDropDown Relation { get; set; }
        public string RelName { get; set; }
        public string RelMobileNo { get; set; }
        public string Age { get; set; }
        public string CreteDate { get; set; }
    }

    //public class resEMROTDetl{

    //     public string Mpat_Admissionid_id { get; set; }
    //     public string Scph_LOCATIONID_ID { get; set; }
    //     public string Scph_ScheduleDt_dt { get; set; }
    //     public string Scph_ScheduleTime_tm { get; set; }
    //     public string Scph_ScheduleEndTime_tm { get; set; }
    //     public string Scph_IsActive_flg { get; set; }
    //     public string Scph_CreatedBy_id { get; set; }
    //     public string Scph_Created_dt { get; set; }
    //     public string Scph_LastModifiedBy_id { get; set; }
    //     public string Scph_LastModified_dt { get; set; }
    //     public string OT_OTTypeCode_Cd { get; set; }
    //     public string Scph_ScheduleEndDt_dt { get; set; }
    // }


    public class resEMROTDetl
    {
        public int Sno { get; set; }
        public string MsgDesc { get; set; }

    }

    public class req_EMROTDetl
    {
        public string AdmissionId { get; set; }
        public string LocationId { get; set; }
        public string Startdate { get; set; }
        public string Endate { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public string Ottype { get; set; }
        public string ProcedureName { get; set; }
        public int EMROTDetId { get; set; }
        public string EMROTNo { get; set; }

    }


    public class cls_Patient_venue
    {
        public string patientId { get; set; }
        public string departmentId { get; set; }
        public string VisitNumber { get; set; }
        public string VisitDate { get; set; }
        public string PackageCode { get; set; }
        public string Packagename { get; set; }

    }

    public class cls_Patient_venue_temp
    {
        public string patientId { get; set; }
        public string VisitNumber { get; set; }
        public string BillNo { get; set; }
        public string VisitDate { get; set; }
        public string testcode { get; set; }
        public string TestLocation { get; set; }
        public string Statusflag { get; set; }
        public string Activeflag { get; set; }

    }

    public class cls_Patient_master
    {
        public string packageid { get; set; }
        public string packagename { get; set; }

    }


    public class cls_PatientVenue_temp
    {
        public string patientId { get; set; }
        public string VisitNumber { get; set; }
        public string BillNo { get; set; }
        public string VisitDate { get; set; }
        public string testcode { get; set; }
        public string TestLocation { get; set; }
        public int Statusflag { get; set; }
        public int Activeflag { get; set; }

    }

    public class cls_Test_master
    {
        public string testcode { get; set; }
        public string testname { get; set; }
        public string package_id { get; set; }
        public string ServiceType { get; set; }

    }

    public class salucrorequest
    {
        public string processing_id { get; set; }
        public string mid { get; set; } = "KkZma9ph";
        public string auth_user { get; set; } = "jrsuperspecialityadmin";
        public string auth_key { get; set; } = "uwVoleGcWIHfgUwgmOMYR8lgx1G7gCz6";
        public string username { get; set; } = "Patient";
        public string check_sum_hash { get; set; }
    }


    public class clsQryResponse
    {
        public int ResultCode;
        public string Result;
    }

    public class res_BirthDay_Info_New
    {
        public string empid { get; set; }
        public string empname { get; set; }
        public string Dept { get; set; }
    }


    public class responseDtl
    {
        public int Sno { get; set; }
        public string MsgDesc { get; set; }
    }


    public class requestDtl
    {
        public int OPD_Prcess_nbr { get; set; }
        public string Study_Start { get; set; }
        public string Study_Authorized { get; set; }
        public string Sample_Collected { get; set; }
        public string Lab_Authorized { get; set; }
        public string Admission_Status { get; set; }
        public string Billing_status { get; set; }
        public string Vitals_Completed_time { get; set; }
        public string Doctor_Checkin { get; set; }
        public string Followup_Appointment { get; set; }
        public string Followup_Billed { get; set; }
        public string Admission_advised { get; set; }
        public string Rad_Investigations_Billed { get; set; }
        public string Lab_Investigations_Billed { get; set; }
        public string Proc_Billed { get; set; }
        public string Procedure_Advised { get; set; }


    }

    public class requestQCEMRDashboard
    {
        public int Preg_RegistrationId_id { get; set; }
        public string Mpat_PatientId_id { get; set; }
        public string Mpat_patientName_nm { get; set; }
        public string VisitDate { get; set; }
        public string Medicines_Prescribed { get; set; }
        public string Billing_status { get; set; }
        public string Admission_Status { get; set; }
        public string Doctor_Checkin { get; set; }
        public string Lab_Order { get; set; }
        public string Sample_Collected { get; set; }
        public string Lab_Authorized { get; set; }
        public string Rad_Order { get; set; }
        public string Study_Start { get; set; }
        public string Study_Authorized { get; set; }

    }



    public class requeste_cert

    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string satisfaction { get; set; }
        public string organization { get; set; }
        public string contentExpectation { get; set; }
        public string presentationQuality { get; set; }
        public string networking { get; set; }
        public string venueFacilities { get; set; }
        public string exercisesQuality { get; set; }
        public string timeManagement { get; set; }
        public string suggestions { get; set; }
        public string additionalComments { get; set; }

    }

    public class res_opd_Process
    {
        public string RegistrationId { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string VisitDate { get; set; }
        public string DoctorName { get; set; }
        public string Rad_Order { get; set; }
        public string Rad_Followup_Billed { get; set; }
        public string Study_Start { get; set; }
        public string Study_Authorized { get; set; }
        public string Lab_Order { get; set; }
        public string Lab_Followup_Billed { get; set; }
        public string Sample_Collected { get; set; }
        public string Lab_Authorized { get; set; }
        public string Medicines_Prescribed { get; set; }
        public string Billing_status { get; set; }

        public string Admission_advised { get; set; }

        public string Admission_Status { get; set; }


    }

    public class res_doctor_tv
    {
        // public int SlNo { get; set; } 
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string DoctorName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public string SlideSequence { get; set; }
        public string PictureName { get; set; }
        public string TvTag { get; set; }
        public int Slide { get; set; }
        public string Header { get; set; }
        public string Doc_Img { get; set; }

    }

    public class res_UpdateQC_Visit
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string VisitId { get; set; }
        public string VisitDate { get; set; }
        public string Vitals_Completed_time { get; set; }
        public string Doctor_Checkin { get; set; }
        public string Procedure_Advised { get; set; }
        public string Admission_Advised { get; set; }
        public string Admission_Status { get; set; }
        public int PresOrdercnt { get; set; }
        public int PresBillcnt { get; set; }

    }


    public class req_Visittracking
    {
        public string VisitId { get; set; }
        public string Vitals_Completed_time { get; set; }
        public string Doctor_Checkin { get; set; }
        public string Procedure_Advised { get; set; }
        public string Admission_Advised { get; set; }
        public string Admission_Status { get; set; }
        public string CreatedId { get; set; }
        public string ModifyId { get; set; }


    }

    public class req_OrderTracking
    {
        public string VisitId { get; set; }
        public string InvestigationOrder { get; set; }
        public string Billed { get; set; }
        public string InvestigationStart { get; set; }
        public string InvestigationAuthorized { get; set; }
        public string InvestigationType { get; set; }
        public string Createdid { get; set; }
        //     public string QCOrder_createdDate_Dt { get; set; }
        public string LastModifyid { get; set; }
        //    public string QCOrder_LastModifyDate_Dt { get; set; }


    }


    public class SlotRes_DTO
    {
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int SlotType { get; set; }
    }


    public class SlotRes_DTO_seq
    {
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int SlotType { get; set; }
        public string StartDateTime1 { get; set; }

    }

    public class SlotReq_DTO
    {
        public string SlotDate { get; set; }
        public int DoctorID { get; set; }
        public int SlotType { get; set; }
    }


    public class SlotReq_DTO_seq
    {
        public string SlotDate { get; set; }
        public int DoctorID { get; set; }
        public int SlotType { get; set; }
    }


    public class clsDoctor
    {
        public int doctorid { get; set; }
        public string doctorname { get; set; }
        public decimal chargerate { get; set; }
        public string profilelink { get; set; }
        public string qualification { get; set; }
        public byte[] photo_img { get; set; }
        public string designation { get; set; }
    }


    public class DepartmentwiseDoctorFilter
    {
        public long DepID { get; set; } = 0;
        public string DoctorName { get; set; } = "";
        public long DoctorID { get; set; } = 0;
    }


    public class AppointmentBooking
    {
        public int AppId { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Salutation { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo1 { get; set; }
        public string DocId { get; set; }
        public string APPStartDate { get; set; }
        public string APPEndDate { get; set; }
        public string Re_APPStartDate { get; set; }
        public string Re_APPEndDate { get; set; }
        public string Re_APP_Remarks { get; set; }
        public string Source { get; set; }
        public int Country { get; set; }
        public string CountryCode { get; set; }
        public int Appcd { get; set; }
        public int IDTypeCode { get; set; }
        public string IDDescription { get; set; }
        public string EmailId { get; set; }
        public string UserId { get; set; } = "BOT";
        public string ResponseCode { get; set; }
        public string Response { get; set; }

        public string CancelRemarks { get; set; }
        //Added by jeyaganesh 29-09-2021
        public string Address_1 { get; set; } = "";
        public string Address_2 { get; set; } = "";
        public string Address_3 { get; set; } = "";
        public string Address_4 { get; set; } = "";
        //End by jeyaganesh 29-09-2021
        public int PaymentType { get; set; } = 0;
    }
    public class AppointmentBooking_seq
    {
        public int AppId { get; set; }

        // existing
        public string UHID { get; set; }
        public string DocId { get; set; }
        public string APPDate { get; set; } = "";
        public int APPSeqno { get; set; }
        public string UserId { get; set; } = "BOT";
        public int Appcd { get; set; }
        public int PaymentType { get; set; } = 0;
        public int SlotNo { get; set; }

        //new

        public string PatientName { get; set; }
        public string Salutation { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo1 { get; set; }    
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Nationality { get; set; }
        public string Address_1 { get; set; } = "";
        public string Pincode { get; set; } = "";
        public string StateName { get; set; } = "";
        public string CountryName { get; set; }
        public string CityName { get; set; } = "";
        public string Area { get; set; }
        public int Payment { get; set; }


    }

    public class appointment_Response
    {
        public int Sno { get; set; }
        public string UHID { get; set; }
        //   public string EpisodeNo { get; set; }   
        public string msgDescp { get; set; }
        //    public string InternalNo { get; set; }
        //    public string InvoiceNo { get; set; }

        public string appointmentID { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }

        public string DoctorName { get; set; }
        public string AppointmentDate { get; set; }
        public string TimeSlot { get; set; }
        public string EmailId { get; set; }
    }


    public class update_Doctor_TV_Res
    {
        public string TvTag { get; set; }
        public string MsgDesc { get; set; }
    }

    public class update_Doctor_TV_req
    {
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string DoctorName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public int SlideSequence { get; set; }
        public string PictureName { get; set; }
        public string TvTag { get; set; }
        public int Slide { get; set; }
        public string Header { get; set; }
        public string Doc_Img { get; set; }
        public int Status { get; set; }

    }
    public class delete_Doctor_TV_req
    {
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string DoctorName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }

    }

    public class delete_Doctor_TV_Res
    {
        public string MsgDesc { get; set; }

    }


    public class AppointmentSlotDTO
    {
        public int DoctorID { get; set; }
        public string AppointmentDate { get; set; }
        public int SlotType { get; set; }
        public string AvailableSlotsStDttm { get; set; }
        public string AvailableSlotsEndDttm { get; set; }
    }

    public class res_RevenueReport {
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string ServiceGroup { get; set; }
        public string ServiceName { get; set; }
        public string UHID { get; set; }
        public string OrderDoctor { get; set; }
        public string OrderDepartment { get; set; }
        public string VisitType { get; set; }
        public int Discount { get; set; }
        public int Net { get; set; }
        public string Payer { get; set; }
    }

    public class res_PatientRelation
    {
        public int RelationshipCode { get; set; }
        public string RelationshipType { get; set; }

    }

    public class LoginDTO
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public Boolean Response { get; set; }

        public string token { get; set; }
        public string ExpirationDate { get; set; }
    }


    public class DoctorDTO
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int DepartmentID { get; set; }
        public int SpecializationID { get; set; }
        public string AppDate { get; set; }
        public byte[] DoctorImg { get; set; }
        public string Shortdescription { get; set; }
        public string Profilepagelink { get; set; }
        public string Video_ConsCharges { get; set; }
        public string Walkin_ConsCharges { get; set; }
    }

    public class res_PIS_StatDetails_dtl
    {

        public int SNO { get; set; }
        public string TYPE { get; set; }
        public string ORDERNO { get; set; }
        public string ORDERDATE { get; set; }
        public string UHID { get; set; }
        public string PATIENTNAME { get; set; }
        public string Location_Name { get; set; }
        public string PriorityType { get; set; }
        public string STATUS { get; set; }


    }



    public class res_mepz
    {
        public string Mepz_Code { get; set; }
        public string Name { get; set; }
        public string Company_Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Marital_Status { get; set; }
        public string Mobile { get; set; }
        public string Family_Diabetics { get; set; }
        public string Family_Hypertension { get; set; }
        public string Family_Heart_Disease { get; set; }
        public string Family_Arthritis { get; set; }
        public string Family_Tuberculosis { get; set; }
        public string Family_Asthma { get; set; }
        public string Family_Cancer { get; set; }
        public string Family_Epilepsy { get; set; }
        public string Family_Mentaor_Nervous_Disorder { get; set; }
        public string Family_Any_Other_Disease { get; set; }
        public string Personal_Good_health_and_capable_of_full_work { get; set; }
        public string Personal_Good_health_reason { get; set; }
        public string Personal_Disease_or_Injury { get; set; }
        public string Personal_Disease_or_Injury_reason { get; set; }
        public string Personal_Rejected_on_Medical_Grounds { get; set; }
        public string Personal_Rejected_on_Medical_Grounds_reason { get; set; }
        public string Others { get; set; }
        public string Vaccination { get; set; }
        public string Personal_Heart_Disease { get; set; }
        public string Personal_Hypertension { get; set; }
        public string Personal_Diabetes { get; set; }
        public string Personal_KidneyDisease { get; set; }
        public string Personal_Asthma { get; set; }
        public string Personal_Tuberculosis { get; set; }
        public string Personal_Dermatitis { get; set; }
        public string Personal_Epilepsy { get; set; }
        public string Personal_Allergy { get; set; }
        public string Personal_Major_Operation { get; set; }
        public string Personal_HepatitisB { get; set; }
        public string Chronic_Lung_Disease { get; set; }
        public string Any_Other_Illness { get; set; }
        public string Chronic_Ear_Problem { get; set; }
        public string Pysical_Handicap { get; set; }
        public string Others_Details { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BMI { get; set; }
        public string BP { get; set; }
        public int Pulse { get; set; }
        public int Spo2 { get; set; }
        public int Temp { get; set; }
        public int CBG { get; set; }
        public string ECG { get; set; }
        public string Dental_Examination { get; set; }
        public string Eye_Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendations { get; set; }
        public string Medication { get; set; }
        public string Diagnosis1 { get; set; }
        public string Final_department { get; set; }
        public string PAP_SMEAR_No { get; set; }
        public string PAP_SMEAR_details { get; set; }
        public string Scaling { get; set; }
        public string Filling { get; set; }
        public string Prostho { get; set; }
        public string Extraction { get; set; }
        public string PERIO { get; set; }
        public string Ortho { get; set; }
        public string ECHO { get; set; }
        public string Mammo { get; set; }
        public string Recommended { get; set; }
        public string Vaccination_status { get; set; }
        public string BloodSugar { get; set; }
        public string Remarks { get; set; }
        public string Systemic_examination { get; set; }

    }


    // need to change 
    public class resInvoice
    {
 
        public string Sno { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string RegId { get; set; }
        public string VisitNo { get; set; }
        public string VisitDate { get; set; }
        public string BillNum { get; set; }
        public string InternalNo { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string BillAmount { get; set; }
        public string SelfAmount { get; set; }
        public string PartyAmount { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string UserId { get; set; }
        public string ISCancelled { get; set; }
        public string PartyCode { get; set; }
        public string BILLSTATUS { get; set; }
        public string ins { get; set; }
        public string PartyName { get; set; }

    }

    
    public class resConcession_report
    {


        public string SNo { get; set; }
        public string Bill_Date { get; set; }
        public string Bill_No { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string Bill_Amount { get; set; }
        public string Concession_Amount { get; set; }
        public string NetAmount { get; set; }
        public string Reason_for_Concession { get; set; }
        public string User_Name { get; set; }
        public string Approved_By { get; set; }
        public string Approval_Remarks { get; set; }
       
    }
    public class StateDTO
    {
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string StateName { get; set; }
        public string StateSHCode { get; set; }
    }

    public class CityDTO
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string CityName { get; set; }
        public string CitySHCode { get; set; }
    }
    public class resHealthEMR
    {
        public float PatientId { get; set; }
        public string UHID { get; set; }
        public string Patient { get; set; }
        public float EncounterId { get; set; }
        public string VisitNumber { get; set; }
        public string VisitDate { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string Vitals { get; set; }
        public string Parameter { get; set; }
        public string VisitType { get; set; }
        public string Value { get; set; }


    }

    public class resBill_cancellation
    {
        public string BILLNUM { get; set; }
        public string VisitNo { get; set; }
        public string BILLDATE { get; set; }
        public string PATIENTNAME { get; set; }
        public string UHID { get; set; }
        public string CONCESSION { get; set; }
        public string SELFAMOUNT { get; set; }
        public string PARTYAMOUNT { get; set; }
        public string InternalBillNo { get; set; }
        public string BILLAMOUNT { get; set; }
        public string PatientStatus { get; set; }
        public string Amount { get; set; }
        public string ReceivedAmount { get; set; }
        public string PartyCode { get; set; }
       
    }



        public class clsOPConsultDrDetail
        {
            public int VisitId { get; set; }
            public int DoctorId { get; set; }
            public int DeptId { get; set; }

            public string DoctorName { get; set; }
            public string DepartmentName { get; set; }
            public string VisitDate { get; set; }

        }
        public class update_Mepz_tb_res
    {
        public string Mepz_Code { get; set; }
        public string MsgDesc { get; set; }

    }
    public class clsPatientDtlsForDeposit
    {

        public string MRN { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string PatientType { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; }
        public string Eligibility { get; set; }
        public string ReasonForVisit { get; set; }
        public string Country { get; set; }
        public string His_Online { get; set; }
        public string AppointmentType { get; set; }
        public string CheckInStatus { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string AppBookedUserId { get; set; }
        public string AppBookedDate { get; set; }
    }
                            
    public class resRegistrationReport
    {
        public string Sno { get; set; }
        public string UHID { get; set; }
        public string Visit_Date { get; set; }
        public string VisitId { get; set; }
        public string VisitType { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PayorType { get; set; }
        public string PayorName { get; set; }
        public string Doctorname { get; set; }
        public string Specialty { get; set; }
        public string ConsultType { get; set; }
        public string ReferalSourceName { get; set; }
        public string Revenue { get; set; }
        public string DrConsult { get; set; }
        public string OtherCharge { get; set; }
        public string VisitCreatedUser { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string AgeNo { get; set; }
        public string ConsultationType { get; set; }
        public string VISAValidityDate { get; set; }

    }
    public class resCashCollectionreport
    {
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
        public string CollectionType { get; set; }
        public long Cash { get; set; } 
        public long Card { get; set; }
        public int Cheque { get; set; }
        public long Contra { get; set; }
        public int Faclidater { get; set; }
        public long Total { get; set; } 
    }
    public class clsRefundReport_SP
    {
        public string MRN { get; set; }
        public string PatientName { get; set; }
        public string RefundDate { get; set; }
        public string RefundNo { get; set; }
        public string DepositNo { get; set; }
        public string DepositAmt { get; set; }
        public string RefundAmt { get; set; }
        public string RefundReason { get; set; }
        public string BillNo { get; set; }
        public string UserId { get; set; }
       
    }
    public class resCreditNoteReport
    {
        public string Date { get; set; }
        public string MRN { get; set; }
        public string CreditNoteNo { get; set; }
        public string InvoiceNo { get; set; }
        public string VisitNo { get; set; }
        public string PatientName { get; set; }
        public int Amount { get; set;}
        public string Remarks { get; set;}

    }

    public class clsIpBedTransferResult
    {
        public int Sno { get; set; }
        public string MsgDescp { get; set; }

    }

    public class clsGetDepositAllocation
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string DepositDate { get; set; }
        public string Depositno { get; set; }
        public decimal Amount { get; set; }
        public string DepositType { get; set; }
        public string UserId { get; set; }

    }

    public class clsSaveBedTransferReq
    {
        public int PatientId { get; set; }
        public int AdmissionId { get; set; }
        public int FromWardid { get; set; }
        public int ToWardid { get; set; }
        public int FromBedId { get; set; }
        public int ToBedId { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string RequestUserid { get; set; }
        public string Reason { get; set; }
        public string CreatedUserid { get; set; }
    }
    public class resPackagePriceList
    {
        public string No { get; set; }
        public string ServiceGroup { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ServiceRate { get; set; }
        public string ChargeId { get; set; }
    } 
    public class Res_slotbooking
    {
        public Boolean Success { get; set; }
        public string Message { get; set; }
        public string errorCode { get; set; }

    }

    public class Res_sltdate
    {
        public string NewDate { get; set; }
        public string Msg { get; set; }

    }

    public class Req_sltdate
    {
        public string DateTime { get; set; }

    }

    public class Res_New_Hdr
    {
        public string ReturnValue { get; set; }
    }

    public class ConsultantSlot
    {
        public int TotalSlot { get; set; }
     
    }

     public class OTProcedure
    {
        public int Proce_No { get; set; }
        public string Procedure_ID { get; set; }
        public string Procedure_Name { get; set; }
        public string Department_name { get; set; }
        public string Created_by { get; set; }
      //  public string Modified_by { get; set; }
        public string Created_User { get; set; }

    }
    public class res_OTProcedure
    {
        public int Sno {  get; set; }
        public string MsgDesc {  get; set; }
    }

    public class req_OTProcedure
    {
        public string Procedure_Name { get; set; }
        public string Department_name { get; set; }
        public string Created_User { get; set; }
    }
    public class  SurgicalDepartment
    {
        public int DeptID { get; set; }
        public string Department_name { get; set; }
        public string Created_by { get; set; }
      //  public string Modified_by { get; set; }
 
    }
    public class DoctorseqSlotGap
     {
        public int Mdoc_DoctorseqSlotGap_Nbr { get; set; }
     }
    public class Req_Slot_New_Dtl_SP
    {
        public int DoctorId { get; set; } 
        public int SessionId { get; set; }
        public string CreateUser { get; set; }
        public List<Slot_New_Dtl> Orders_items { get; set; }

    }
    public class Slot_New_Dtl
    {
        public string SlotDate { get; set; }
        public int SlotStart { get; set; }

    }

    public class Req_Slot_New_Hdr_SP
    {
        public int DoctorId { get; set; }
        public int Session { get; set; }
        public int Slot { get; set; }
        public int AppType { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CreateUser { get; set; }

    }
    public class payment_portal
    {
        public int SNo { get; set; }
        public int UHID { get; set; }
        public string RefId { get; set; }
        public string RefType { get; set; }
        public string PatRefID { get; set; }
        public string PatientName { get; set; }
        public string TransDate { get; set; }
        public Decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public string EMailID { get; set; }
        public string DoctorName { get; set; }
        public string PaymentStatus { get; set; }
        public string CreatedDate { get; set; }
        public string ModifedDate { get; set; }
    }
    public class update_Mepz_tb_req
    {

        public string Mepz_Code { get; set; }
        public string Name { get; set; }
        public string Company_Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Marital_Status { get; set; }
        public string Mobile { get; set; }
        public string Family_Diabetics { get; set; }
        public string Family_Hypertension { get; set; }
        public string Family_Heart_Disease { get; set; }
        public string Family_Arthritis { get; set; }
        public string Family_Tuberculosis { get; set; }
        public string Family_Asthma { get; set; }
        public string Family_Cancer { get; set; }
        public string Family_Epilepsy { get; set; }
        public string Family_Mentaor_Nervous_Disorder { get; set; }
        public string Family_Any_Other_Disease { get; set; }
        public string Personal_Good_health_and_capable_of_full_work { get; set; }
        public string Personal_Good_health_reason { get; set; }
        public string Personal_Disease_or_Injury { get; set; }
        public string Personal_Disease_or_Injury_reason { get; set; }
        public string Personal_Rejected_on_Medical_Grounds { get; set; }
        public string Personal_Rejected_on_Medical_Grounds_reason { get; set; }
        public string Others { get; set; }
        public string Vaccination { get; set; }
        public string Vaccination_status { get; set; }
        public string Personal_Heart_Disease { get; set; }
        public string Personal_Hypertension { get; set; }
        public string Personal_Diabetes { get; set; }
        public string Personal_KidneyDisease { get; set; }
        public string Personal_Asthma { get; set; }
        public string Personal_Tuberculosis { get; set; }
        public string Personal_Dermatitis { get; set; }
        public string Personal_Epilepsy { get; set; }
        public string Personal_Allergy { get; set; }
        public string Personal_Major_Operation { get; set; }
        public string Personal_HepatitisB { get; set; }
        public string Chronic_Lung_Disease { get; set; }
        public string Any_Other_Illness { get; set; }
        public string Chronic_Ear_Problem { get; set; }
        public string Pysical_Handicap { get; set; }
        public string Others_Details { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public float BMI { get; set; }
        public string BP { get; set; }
        public int Pulse { get; set; }
        public int Spo2 { get; set; }
        public float Temp { get; set; }
        public int CBG { get; set; }
        public string ECG { get; set; }
        public string Dental_Examination { get; set; }
        public string Eye_Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendations { get; set; }
        public string Medication { get; set; }
        public string Diagnosis1 { get; set; }
        public string Final_department { get; set; }
        public string PAP_SMEAR_No { get; set; }
        public string PAP_SMEAR_details { get; set; }
        public string Scaling { get; set; }
        public string Filling { get; set; }
        public string Prostho { get; set; }
        public string Extraction { get; set; }
        public string PERIO { get; set; }
        public string Ortho { get; set; }
        public string ECHO { get; set; }
        public string Mammo { get; set; }
        public string Recommended { get; set; }
        public string BloodSugar { get; set; }
        public string Remarks { get; set; }
        public string Systemic_examination { get; set; }


    }
    public class PatientVenue_res
    {
        public string patientId { get; set; }
        public string MsgDesc { get; set; }
    }

    public class clsRegInvoice
    {
        public int uhid { get; set; }
        public decimal amount { get; set; }
    }

    public class Req_Insurance
    {
        public string AdmNo { get; set; }
        public string Presenting_Complaints { get; set; }
        public string Duration_Of_Stay { get; set; }
        public string Provisional_Diagnosis { get; set; }
        public string Plan_of_Treatment { get; set; }
        public string Admission_Date { get; set; }
        public string Patient_Name { get; set; }
        public string UHID { get; set; }
        public string BEDNo { get; set; }

    }

    public class clsInsurance_Pre_Auth
    {
        public string AdmNo { get; set; }
        public string Presenting_Complaints { get; set; }
        public string Duration_Of_Stay { get; set; }
        public string Provisional_Diagnosis { get; set; }
        public string Plan_of_Treatment { get; set; }
        public string Admission_Date { get; set; }
        public string Patient_Name { get; set; }
        public string UHID { get; set; }
        public string BEDNo { get; set; }
        public string CreatedDate { get; set; }
        
    }

    public class Res_Insurance
    {
        public string AdmNo { get; set; }
        public string MsgDesc { get; set; }
    
    }

    public class res_OPIPREVENUE_Date
    {
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string ServiceGroup { get; set; }
        public string ServiceName { get; set; }
        public string UHID { get; set; }
        public string OrderDoctor { get; set; }
        public string OrderDepartment { get; set; }
        public string VisitType { get; set; }
        public string Discount { get; set; }
        public string Net { get; set; }
        public string Payer { get; set; }

    }

    public class app_Response
    {
        public int Sno { get; set; }
        public string msgDescp { get; set; }
        public string UHID { get; set; }
        public string EpisodeNo { get; set; }
        public int InternalNo { get; set; }
        public string InvoiceNo { get; set; }
        public string appointmentID { get; set; }

    }

    public class res_REVENUE_Date
    {
        public string BillDate { get; set; }
        public string ServiceGroup { get; set; }
        public string ServiceName { get; set; }
        public string OrderDoctor { get; set; }
        public string OrderDepartment { get; set; }
        public string Net { get; set; }

    }
    public class req_PatientVenue
    {
        public string patientId { get; set; }
        // public string BillNo { get; set; }
        public string testcode { get; set; }
        public string TestLocation { get; set; }

    }

    public class Res_Kranium_feedback
    {
        public int id { get; set; }
        public string kranium_accessibility { get; set; }
        public string prescription { get; set; }
        public string op_summary { get; set; }
        public string discharge_summary { get; set; }
        public string investigation { get; set; }
        public string growth_chart { get; set; }
        public string immunization_chart { get; set; }
        public string app_speed { get; set; }
        public string good_about_kranium { get; set; }
        public string improvement_required { get; set; }
        public string remarks { get; set; }
        public string submission_date { get; set; }
        public string name { get; set; }
        public string created_date { get; set; }
        public string modified_date { get; set; }

    }

    public class Res_BedStatus
    {
        public string PATIENTID { get; set; }
        public string UHID { get; set; }
        public string PATIENTNAME { get; set; }
        public string AGE { get; set; }
        public string GENDER { get; set; }
        public string ADMISSIONDATETIME { get; set; }
        public string BedNo { get; set; }
        public string NATIONALITY { get; set; }
        public string PATIENTSTATUS { get; set; }
        public string WARD { get; set; }
        public string BEDSTATUS { get; set; }
        public string BED { get; set; }
        public string BEDTYPE { get; set; }
        public string DOCTORNAME { get; set; }
        public string Speciality { get; set; }
        public string VIPRemarks { get; set; }
        public string PatType { get; set; }

    }
    public class cls_OTScheduleing
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string TheaterName { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string StartDate { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }


    }
    public class cls_Radiologypatientsearch
    {

        public string MRN { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string Type { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Eligibility { get; set; }
        public string ReasonForVisit { get; set; }
        public string Country { get; set; }
        public string RadOnline { get; set; }
        public string AppointmentType { get; set; }
    }


    public class OPInvestigationResponse
    {    
        public int SurrogateId {  get; set; }
        public string PatientName { get; set; }
        public long UHID { get; set; }
        public int RegID { get; set; }
        public string DocotrName { get; set; }
        public int DocotrCode {  get; set; }
        public string OrderDateTM { get; set; }
        public int OrderId { get; set; }
        public string ItemID { get; set; }
        public string Investigations { get; set; }
        public string GroupName { get; set; }
        public int Amount { get; set; }
        public int Action { get; set; } 
       
    }

    public class cls_DischargeTrackingreport
    {
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDepartment { get; set; }
        public string BedNo { get; set; }
        public string AdmittedWard { get; set; }
        public string PayerType { get; set; }
        public string DischargeType { get; set; }
        public string DischargeDate { get; set; }
        public string DischargeMonth { get; set; }
        public string PhysicalToHousekeeping { get; set; }
        public string AdmNo { get; set; }
        public string Payorname { get; set; }
        public string Physical_Discharge { get; set; }

    }


    public class res_heartandlungs
    {
        public int CampCodeID { get; set; }
        public string MsgDesc { get; set; }

    }

    public class req_heartandlungs
    {
        public string CampName { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }

    public class cls_heartandlungs
    {

        public string CampCodeID { get; set; }
        public string CampCode { get; set; }
        //  public string CampName { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        //  public string DOB { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        //   public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        //  public string State { get; set; }
        //  public string City { get; set; }
        // public string Country { get; set; }
    }
    public class Newpatient_dtlRes
    {
        public string PatientName { get; set; }
        public string Doctor { get; set; }
        public string AppDate { get; set; }
        public string AppTime { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int DepId { get; set; }
        public int Charges { get; set; }
        public string UHID { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
    }

    public class  Res_ListOfLobbyToken
    
  {
    public int TokenID { get; set; }
    public string PatientName { get; set; }
    public string MobileNo { get; set; }
    public string TokenDate { get; set; }
    public string TokenNo { get; set; }
    public string TokenType { get; set; }
    public string StausFlag { get; set; }
    public string Processing_time { get; set; }
    public string Completed_time { get; set; }

}
                
    public class Res_ListOfAdmission
    {
        public string AdmissionDate { get; set; }
        public string AdmissionTime { get; set; }
        public string AdmittedBed { get; set; }
        public string AdmittedWard { get; set; }
        public string BedNo { get; set; }
        public string WARD { get; set; }
        public string UHID { get; set; }
        public string PatientName { get; set; }
        public string AdmittingConsultant { get; set; }
        public string AdmittingDepartment { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string VIP { get; set; }
        public string AdmissionCategory { get; set; }
        public string BILLABLEBEDCATEGORY { get; set; }
        public string VisitID { get; set; }

    }

    public class Res_docwiseapplist
    {       
        public string MRN { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string Type { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; }
        public string Eligibility { get; set; }
        public string ReasonForVisit { get; set; }
        public string Country { get; set; }
        public string AppointmentType { get; set; }
 
    }

    public class NetworkShare : IDisposable
    {
        private readonly string _networkName;

        public NetworkShare(string networkName, string user, string password)
        {
            _networkName = networkName;
            var netResource = new NetResource
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplayType.Share,
                RemoteName = networkName
            };

            var userName = string.IsNullOrEmpty(user) ? null : user;
            var passwordSecure = string.IsNullOrEmpty(password) ? null : password;

            var result = WNetAddConnection2(netResource, passwordSecure, userName, 0);
            if (result != 0)
            {
                throw new Win32Exception(result);
            }
        }

        ~NetworkShare()
        {
            Dispose();
        }

        public void Dispose()
        {
            WNetCancelConnection2(_networkName, 0, true);
            GC.SuppressFinalize(this);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags, bool force);

        [StructLayout(LayoutKind.Sequential)]
        private class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplayType DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        }

        public enum ResourceType
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8
        }

        public enum ResourceDisplayType
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0A,
            Ndscontainer = 0x0B
        }
    }


}
