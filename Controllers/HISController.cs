using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BALayer.Repository;
using EnitityLayer.BusinessModels;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using QRCoder;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using ImageProcessor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using Microsoft.AspNetCore.Cors.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DALayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ImageProcessor.Processors;
using static BALayer.MediBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using static RIMC_WEBAPI.Controllers.HISController;
using static System.Net.Mime.MediaTypeNames;

using System;
using System.Text;
using System.Buffers.Text;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Net.NetworkInformation;

using System.IO.Abstractions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.VisualBasic;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;
using Microsoft.OpenApi.Models;
using Microsoft.CodeAnalysis.CSharp;




namespace RIMC_WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
  
    public class HISController : Controller
    {
        private readonly IMediBusiness _mediBusiness;
        private readonly IConfiguration _configuration;

        public HISController(IMediBusiness mediBusiness, IConfiguration configuration)
        {
            _mediBusiness = mediBusiness;
            _configuration = configuration;
        }

        #region RIMC_Online

        //14122023
        [HttpPost]
        [ActionName("getHISLogin")]
        public resLogin checkLogin([FromBody] reqLogin request)
        {
            resLogin response = new resLogin();
            response = _mediBusiness.GetLogin(request);

            return response;
        }

        [HttpPost]
        [ActionName("getUserLogin")]
        public resUserLogin checkuserLogin([FromBody] reqUserLogin req)
        {
            resUserLogin response = new resUserLogin();
            response = _mediBusiness.getUserLogin(req);

            return response;
        }

        [HttpPost]
        [ActionName("patLogin")]
        public respatLogin checkpatLogin([FromBody] reqpatLogin req)
        {
            respatLogin response = new respatLogin();
            response = _mediBusiness.patLogin(req);

            return response;
        }

        [HttpPost]
        [ActionName("SaveUser_login")]
        public resSavelogin SaveUser_login([FromBody] reqSaveLogin request)
        {
            resSavelogin response = new resSavelogin();
            response = _mediBusiness.SaveUser_login(request);

            return response;
        }


        [HttpPost]
        [ActionName("Get_HouseKeepingList_Save")]
        public resHouseKeepingList Get_HouseKeepingList_Save(ReqHouseKeepingList req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_HouseKeepingList_Save(req);
            return response;
        }

        [HttpPost]
        [ActionName("Get_RestRoomCheckList_Save")]
        public resHouseKeepingList Get_RestRoomCheckList_Save(ReqRestRoomList req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_RestRoomCheckList_Save(req);
            return response;
        }

        //14122023
        [HttpPost]
        [ActionName("Get_Patient_Portal")]
        public resHouseKeepingList Get_Patient_Portal(Patient_Portal req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_Patient_Portal(req);
            return response;
        }


        //14122023
        [HttpPost]
        [ActionName("Get_Patient_Portal_MHC")]
        public resHouseKeepingList Get_Patient_Portal_MHC(Patient_Portal req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_Patient_Portal_MHC(req);
            return response;
        }


        [HttpPost]
        [ActionName("Insert_AppointmentSlot")]
        public clsWebMinar SaveAppointmentSlot(ClsSaveAppointmentSlot Request)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.SaveAppointmentSlot(Request);
            return response;
        }

        [HttpPost]
        [ActionName("Update_RefId")]
        public updaterefid Update_RefId(reqclass req)
        {
            updaterefid response = new updaterefid();
            response = _mediBusiness.Update_RefId(req);
            return response;
        }

        [HttpPost]
        [ActionName("tempToUHIDGenerate")]
        public CovidRegistrationDTO tempToUHIDGenerate([FromBody] uhidRequest req)
        {

            CovidRegistrationDTO appointmentBookings = new CovidRegistrationDTO();
            appointmentBookings = _mediBusiness.uhidGenerate(req.UHID);

            //string URL = "";
            //var ReferenceNumber = appointmentBookings.RegistrationRefNo;
            //if (ReferenceNumber != "")
            //{
            //    if (reg.CountryCode == 101)
            //    {
            //        URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=Your Registration reference number is (" + ReferenceNumber + ") and Kindly share Your Registration Reference Number to Receptionist to complete the registration. Patient-" + reg.PatientName + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + reg.MobileNo + "&service=T";
            //    }
            //    else
            //    {
            //        URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=Your Registration reference number is (" + ReferenceNumber + ") and Kindly share Your Registration Reference Number to Receptionist to complete the registration. Patient-" + reg.PatientName + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + reg.MobileNo + "&service=G";
            //    }
            //    //URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=f61f0a429797f88328690649ed72cfb3&message=Your Registration reference number is " + RandomNumber + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";

            //    WebRequest myWebRequest = WebRequest.Create(URL);
            //    WebResponse myWebResponse = myWebRequest.GetResponse();
            //    Stream ReceiveStream = myWebResponse.GetResponseStream();
            //    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            //    StreamReader readStream = new StreamReader(ReceiveStream, encode);
            //    string strResponse = readStream.ReadToEnd();
            //    if (strResponse.Contains("422"))
            //    {

            //    }
            //    else
            //    {

            //    }
            //}
            return appointmentBookings;
        }


        [HttpPost]
        [ActionName("OT_LIST_SAVE")]
        public resHouseKeepingList OT_LIST_SAVE(req_OtClass req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.OT_LIST_SAVE(req);
            return response;
        }

        [HttpGet]
        [ActionName("Get_OTList")]
        public List<OtClass> Get_OTLits()
        {
            List<OtClass> dropdown_DTOs = new List<OtClass>();
            dropdown_DTOs = _mediBusiness.Get_OTLits();

            return dropdown_DTOs;
        }

        //[HttpGet]
        //[ActionName("Get_License_dtl")]
        //public List<LicenseModel> Get_License_dtl()
        //{
        //    List<LicenseModel> dropdown_DTOs = new List<LicenseModel>();
        //    dropdown_DTOs = _mediBusiness.Get_License_dtl();

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_Appsolt_dtl")]
        //public List<appsolt> Get_Appsolt_dtl()
        //{
        //    List<appsolt> dropdown_DTOs = new List<appsolt>();
        //    dropdown_DTOs = _mediBusiness.Get_Appsolt_dtl();

        //    return dropdown_DTOs;
        //}

        [HttpPost]
        [ActionName("OT_Excel")]
        public clsWebMinar OT_Excel(Otexcel_req obj)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.OT_Excel(obj);
            return response;
        }


        //[HttpGet]
        //[ActionName("Get_DoctorDirectory_dtl")]
        //public List<DoctorDirectory> Get_DoctorDirectory_dtl()
        //{
        //    List<DoctorDirectory> dropdown_DTOs = new List<DoctorDirectory>();
        //    dropdown_DTOs = _mediBusiness.Get_DoctorDirectory_dtl();

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_TicketingCount_dtl")]
        //public TicketingSystem Get_TicketingCount_dtl(string Fromdate,string Todate)
        //{
        //    TicketingSystem dropdown_DTOs = new TicketingSystem();
        //    dropdown_DTOs = _mediBusiness.Get_TicketingCount_dtl(Fromdate, Todate);

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_TicketingDepCount_dtl")]
        //public List<DepWiseTicketingSystem> Get_TicketingDepCount_dtl(string Fromdate, string Todate)
        //{
        //    List<DepWiseTicketingSystem> dropdown_DTOs = new List<DepWiseTicketingSystem>();
        //    dropdown_DTOs = _mediBusiness.Get_TicketingDepCount_dtl(Fromdate, Todate);

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_DocDirectory_Editdtl")]
        //public DoctorDirectory Get_DocDirectoru_Editdtl(int SNo)
        //{
        //    DoctorDirectory dropdown_DTOs = new DoctorDirectory();
        //    dropdown_DTOs = _mediBusiness.Get_DocDirectoru_Editdtl(SNo);

        //    return dropdown_DTOs;
        //}
        //[HttpPost]
        //[ActionName("DoctoryDiectory_Img")]
        //public clsWebMinar DoctoryDiectory_Img(DocDirImg_req obj)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.DoctoryDiectory_Img(obj);
        //    return response;
        //}
        [HttpPost]
        [ActionName("Doc_Dir_IMG_View")]
        public clsWebMinar Doc_Dir_IMG_View(docDir_imgView req)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.Doc_Dir_IMG_View(req);
            return response;
        }

        [HttpPost]
        [ActionName("usp_ImportImage")]
        public clsWebMinar Doc_Dir_IMG_import(docDir_img_imp req)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.Doc_Dir_IMG_import(req);
            return response;
        }

        [HttpPost]
        [ActionName("save_signimg")]
        public resSavelogin save_signimg(signimgreq req)
        {
            resSavelogin response = new resSavelogin();
            response = _mediBusiness.save_signimg(req);
            return response;
        }

        [HttpGet]
        [ActionName("signimage")]
        public List<signimgreq> signimage()
        {
            List<signimgreq> response = new List<signimgreq>();
            response = _mediBusiness.signimage();
            return response;
        }

        [HttpGet]
        [ActionName("usp_ExportImage")]
        public clsWebMinar Doc_Dir_IMG_export(docDir_img_exp req)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.Doc_Dir_IMG_export(req);
            return response;
        }

        //[HttpGet]
        //[ActionName("Get_DocDir_Img_List")]
        //public List<DocDirImg_List> Get_DocDir_Img_List()
        //{
        //    List<DocDirImg_List> dropdown_DTOs = new List<DocDirImg_List>();
        //    dropdown_DTOs = _mediBusiness.Get_DocDir_Img_List();

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_DocDir_Img_View_List")]
        //public List<docDir_imgView_List> Get_DocDir_Img_View_List()
        //{
        //    List<docDir_imgView_List> dropdown_DTOs = new List<docDir_imgView_List>();
        //    dropdown_DTOs = _mediBusiness.Get_DocDir_Img_View_List();

        //    return dropdown_DTOs;
        //}
        //[HttpPost]
        //[ActionName("Insert_DocDir_New")]
        //public clsWebMinar Insert_DocDir_New(DoctorDirectory_new req)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.Insert_DocDir_New(req);
        //    return response;
        //}
        //[HttpPost]
        //[ActionName("Update_DocDir_Dtl")]
        //public clsWebMinar Update_DocDir_Dtl(DoctorDirectory req)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.Update_DocDir_Dtl(req);
        //    return response;
        //}
        //[HttpGet]
        //[ActionName("Delete_DocDir_Dtl")]
        //public clsWebMinar Delete_DocDir_Dtl(int SNo)
        //{
        //    clsWebMinar dropdown_DTOs = new clsWebMinar();
        //    dropdown_DTOs = _mediBusiness.Delete_DocDir_Dtl(SNo);

        //    return dropdown_DTOs;
        //}


        //[HttpPost]
        //[ActionName("Get_PaymentGetWay")]
        //public clsWebMinar Get_PaymentGetWay(PaymentGateWay req)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.Get_PaymentGetWay(req);
        //    return response;
        //}

        //[HttpGet]
        //[ActionName("Get_PaymentGetWay_List")]
        //public List<Get_PaymentGetWay_List> Get_PaymentGetWay_List(string frdate, string todate )
        //{
        //    List<Get_PaymentGetWay_List> dropdown_DTOs = new List<Get_PaymentGetWay_List>();
        //    dropdown_DTOs = _mediBusiness.Get_PaymentGetWay_List(frdate, todate);

        //    return dropdown_DTOs;
        //}

        //[HttpGet]
        //[ActionName("Get_PaymentGetWay_Listdemo")]
        //public List<Get_PaymentGetWay_Listdemo> Get_PaymentGetWay_Listdemo(string frdate, string todate)
        //{
        //    List<Get_PaymentGetWay_Listdemo> dropdown_DTOs = new List<Get_PaymentGetWay_Listdemo>();
        //    dropdown_DTOs = _mediBusiness.Get_PaymentGetWay_Listdemo(frdate, todate);

        //    return dropdown_DTOs;
        //}

        [HttpPost]
        [ActionName("BB_BloodGroup")]
        public BB_BloodGroup_res BB_BloodGroup(BB_BloodGroup_req obj)
        {
            BB_BloodGroup_res response = new BB_BloodGroup_res();
            response = _mediBusiness.BB_BloodGroup(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Insert_OPDMaster_Porc")]
        public opd_master_Res Insert_OPDMaster_Porc(OPD_MasterProc_req obj)
        {
            opd_master_Res response = new opd_master_Res();
            response = _mediBusiness.Insert_OPDMaster_Porc(obj);
            return response;
        }

        [HttpPost]
        [ActionName("FinancialCounsellingSave")]
        public clsFinancialResult FinancialCounsellingSave(FinancialCounselling_req obj)
        {
            clsFinancialResult response = new clsFinancialResult();
            response = _mediBusiness.FinancialCounsellingSave(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Insert_ExsistsOPDMaster_Porc")]
        public EXS_opd_master_Res Insert_ExsistsOPDMaster_Porc(OPD_ExsitsMasterProc_req obj)
        {
            EXS_opd_master_Res response = new EXS_opd_master_Res();
            response = _mediBusiness.Insert_ExsistsOPDMaster_Porc(obj);
            return response;
        }
        [HttpGet]
        [ActionName("AppAvailableSlotTimeDtl")]
        public List<clsAppAvailableSlotTimeDtl> AppAvailableSlotTimeDtl(string APPDate, int ConsId, int Slottype)
        {
            List<clsAppAvailableSlotTimeDtl> response = new List<clsAppAvailableSlotTimeDtl>();
            response = _mediBusiness.AppAvailableSlotTimeDtl(APPDate, ConsId, Slottype);
            return response;
        }

        [HttpGet]
        [ActionName("GetCombinedData")]
        public List<clsGetCombinedData> GetCombinedData(string DtlType)
        {
            List<clsGetCombinedData> response = new List<clsGetCombinedData>();
            response = _mediBusiness.GetCombinedData(DtlType);
            return response;
        }

        //[HttpGet]
        //[ActionName("GetCombinedData_v1")]
        //public List<clsCUG> GetCombinedData_v1(string DtlType)
        //{
        //    List<clsCUG> response = new List<clsCUG>();
        //    response = _mediBusiness.GetCombinedData_v1(DtlType);
        //    return response;
        //}

        [HttpGet]
        [ActionName("Salutations")]
        public List<clsDropDown> GetSalutaionsDetails()
        {
            List<clsDropDown> salutations = new List<clsDropDown>();
            salutations = _mediBusiness.GetSalutaionsDetails();
            return salutations;
        }

        [HttpGet]
        [ActionName("get_Ref_Source")]
        public List<clsDropDown> Ref_Source_list()
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.Ref_Source_list();
            return response;
        }

        [HttpGet]
        [ActionName("Departments")]  // change.....29/10/2021
        public List<clsDropDown> GetDepartmentData()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            dropdown_DTOs = _mediBusiness.GetDepartment();

            return dropdown_DTOs;
        }

        [HttpGet]
        [ActionName("MobileCode")] // change.....29/10/2021
        public List<clsDropDown> GetMobileCode()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            dropdown_DTOs = _mediBusiness.GetMobileCode();

            return dropdown_DTOs;
        }

        [HttpGet]
        [ActionName("Countries")] // change.....29/10/2021
        public List<contryDropDown> GetCountriesDetails()
        {
            List<contryDropDown> countries = new List<contryDropDown>();
            countries = _mediBusiness.GetCountriesDetails();
            return countries;
        }

        [HttpGet]
        [ActionName("Get_Services")] // change.....29/10/2021
        public List<clsDropDown> Get_Services()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.GetServiceLoad();
            return res;
        }

        [HttpGet]
        [ActionName("Get_Priority")] // change.....29/10/2021
        public List<clsDropDown> Get_Priority()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.GetPriority();
            return res;
        }

        //[HttpGet]
        //[ActionName("Get_ChargeMaster")]
        //public List<clsDropDown> Get_ChargeMaster(long code)
        //{
        //    List<clsDropDown> res = new List<clsDropDown>();
        //    res = _mediBusiness.GetChargeMaster(code);
        //    return res;
        //}

        [HttpGet]
        [ActionName("Nationality")]
        public List<clsDropDown> GetNationalityDetails()
        {
            List<clsDropDown> countries = new List<clsDropDown>();
            countries = _mediBusiness.GetNationalityDetails();
            return countries;
        }
        [HttpGet]
        [ActionName("get_Web_Relationship")]
        public List<reqRef_Relationship> Ref_Relationship_list()
        {
            List<reqRef_Relationship> response = new List<reqRef_Relationship>();
            response = _mediBusiness.Ref_Relationship_list();
            return response;
        }


        [HttpGet]
        [ActionName("SurgProcname_Dtl")]
        public List<SurgProcname> SurgProcname_Dtl()
        {
            List<SurgProcname> response = new List<SurgProcname>();
            response = _mediBusiness.SurgProcname_Dtl();
            return response;
        }

        [HttpGet]
        [ActionName("FinancialCounsellingprint")]
        public List<clsFinancialCounsellingprint> FinancialCounsellingprint(int Patientid, int CounsellingId)
        {
            List<clsFinancialCounsellingprint> response = new List<clsFinancialCounsellingprint>();
            response = _mediBusiness.FinancialCounsellingprint(Patientid, CounsellingId);
            return response;
        }

        [HttpGet]
        [ActionName("FinCouncil_Detail_Load")]
        public List<FinCouncil_Detail_Load> FinCouncil_Detail_Load(int Patientid)
        {
            List<FinCouncil_Detail_Load> response = new List<FinCouncil_Detail_Load>();
            response = _mediBusiness.FinCouncil_Detail_Load(Patientid);
            return response;
        }

        //prabha 04-Jan-2022
        [HttpGet]
        [ActionName("get_Web_DoctorData")]
        public List<reqRef_DoctorData> Ref_DoctorData_list()
        {
            List<reqRef_DoctorData> response = new List<reqRef_DoctorData>();
            response = _mediBusiness.Ref_DoctorData_list();
            return response;
        }
        [HttpGet]
        [ActionName("MasterBloodGroup")]
        public List<resDropDown> MasterBloodGroup()
        {
            List<resDropDown> ReligionDTOs = new List<resDropDown>();
            ReligionDTOs = _mediBusiness.MasterBloodGroup();

            return ReligionDTOs;
        }
        [HttpGet]
        [ActionName("Get_MasReligion_Data")]
        public List<clsDropDown> Get_MasReligion_Data()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.Get_MasReligion_Data();
            return res;
        }
        [HttpGet]
        [ActionName("Get_MasLang_Data")]
        public List<clsDropDown> Get_MasLang_Data()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.Get_MasLang_Data();
            return res;
        }
        [HttpGet]
        [ActionName("Get_ExternalDoc_Data")]
        public List<resDropDown> Get_ExternalDoc_Data()
        {
            List<resDropDown> res = new List<resDropDown>();
            res = _mediBusiness.Get_ExternalDoc_Data();
            return res;
        }
        [HttpGet]
        [ActionName("State")] // change.....29/10/2021
        public List<clsDropDown> GetStateDetails()
        {
            List<clsDropDown> stateDTOs = new List<clsDropDown>();
            stateDTOs = _mediBusiness.GetStateDetails();

            return stateDTOs;
        }
        [HttpGet]
        [ActionName("OccupationData")] // change.....29/10/2021
        public List<clsDropDown> GetOccupationDataDetails()
        {
            List<clsDropDown> OccupationDTOs = new List<clsDropDown>();
            OccupationDTOs = _mediBusiness.GetOccupationDataDetails();

            return OccupationDTOs;
        }

        [HttpGet]
        [ActionName("Web_Bed_Report")] // sujithra .........26/02/2024
        public List<clsbedRes> Web_Bed_Report()
        {
            List<clsbedRes> BedReport = new List<clsbedRes>();
            BedReport = _mediBusiness.Web_Bed_Report();
            return BedReport;
        }


        [HttpGet]
        [ActionName("MaritalStatus")] // change.....29/10/2021
        public List<clsDropDown> GetMaritalStatusDetail()
        {
            List<clsDropDown> countries = new List<clsDropDown>();
            countries = _mediBusiness.GetMaritalStatusDetails();
            return countries;
        }

        [HttpGet]
        [ActionName("IDType")] // change.....29/10/2021
        public List<clsDropDown> GeIDTypeDetails()
        {
            List<clsDropDown> IDTypeDTOs = new List<clsDropDown>();
            IDTypeDTOs = _mediBusiness.GetIDTypeDetails();

            return IDTypeDTOs;
        }

        [HttpGet]
        [ActionName("Statecdwise_CityDtl")] // prabha 09/12/2021
        public List<clsDropDown> GetCityDtlStatewise(int StateCode)
        {
            List<clsDropDown> cityDTOs = new List<clsDropDown>();
            cityDTOs = _mediBusiness.GetCityDtlStatewise(StateCode);

            return cityDTOs;
        }

        [HttpGet]
        [ActionName("Area")] // change.....29/10/2021
        public List<clsDropDown> GetArea(string pincode)
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            dropdown_DTOs = _mediBusiness.GetArea(pincode);

            return dropdown_DTOs;
        }

        [HttpPost]
        [ActionName("GetDatabyPinCode")]
        public PincodewiseDataDTO GetpincodewiseData([FromBody] PincodeResuest resuest)
        {
            PincodewiseDataDTO dTO = new PincodewiseDataDTO();
            dTO = _mediBusiness.GetPincodewiseData(resuest);
            return dTO;
        }

        //Sujithra  ---start

        [HttpPost]
        [ActionName("opInvoice")]
        public clsResult opInvoice(clsopInvoice obj)
        {
            clsResult response = new clsResult();
            response = _mediBusiness.opInvoice(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Deposit_Dep")]
        public clsdepResult Deposit_Dep(clsdeposit obj)
        {
            clsdepResult response = new clsdepResult();
            response = _mediBusiness.Deposit_Dep(obj);
            return response;
        }

        [HttpPost]
        [ActionName("web_refincoun_save")]
        public clsrefincoun_save web_refincoun_save(clsrefincoun obj)
        {
            clsrefincoun_save response = new clsrefincoun_save();
            response = _mediBusiness.web_refincoun_save(obj);
            return response;
        }

        [HttpPost]
        [ActionName("IPBedBlock_Save")]
        public clsIPBedBlock_Save IPBedBlock_Save(clsIPBedBlock obj)
        {
            clsIPBedBlock_Save response = new clsIPBedBlock_Save();
            response = _mediBusiness.IPBedBlock_Save(obj);
            return response;
        }

        [HttpPost]
        [ActionName("IPBedBlock_Clear")]
        public clsIPBedBlock_Clear IPBedBlock_Clear(reqIPBedBlock_Clear obj)
        {
            clsIPBedBlock_Clear response = new clsIPBedBlock_Clear();
            response = _mediBusiness.IPBedBlock_Clear(obj);
            return response;
        }

        [HttpPost]
        [ActionName("VisitExistingpatient_new")]
        public Response_DTO VisitExistingPatient_new(reqAppVisit req)
        {
            Response_DTO response = new Response_DTO();
            response = _mediBusiness.VisitExistingPatient(req);
            return response;
        }

        [HttpPost]
        [ActionName("Save_OTProcedure")]
        public res_OTProcedure Save_OTProcedure(req_OTProcedure req)
        {
            res_OTProcedure response = new res_OTProcedure();
            response = _mediBusiness.Save_OTProcedure(req);
            return response;
        }


        [HttpGet]
        [ActionName("GetSurgicalDepartment")] 
        public List<SurgicalDepartment> GetSurgicalDepartment()
        {
            List<SurgicalDepartment> response = new List<SurgicalDepartment>();
            response = _mediBusiness.GetSurgicalDepartment();

            return response;
        }


        [HttpGet]
        [ActionName("GetOTProcedure")]
        public List<OTProcedure> GetOTProcedure()
        {
            List<OTProcedure> response = new List<OTProcedure>();
            response = _mediBusiness.GetOTProcedure();

            return response;
        }

        [HttpGet]
        [ActionName("GetInsurance_Corporate")]  // prabha.....30/11/2021
        public List<clsDropDown> GetInsuranceCorporate(string PanelType)
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.GetCorprateInsurancelist(PanelType);

            return response;
        }
        [HttpGet]
        [ActionName("DepartmentWiseDoctor")]
        public List<clsDropDown> GetDepartmentWiseDoctor(long DepID = 0, string DoctorName = "")
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.GetDoctorNameDepWise(DepID, DoctorName);

            return response;
        }

        [HttpPost]
        [ActionName("WebExisitingPatientAppointment")]
        public clsWebExisitingPatientAppointment WebExisitingPatientAppointment([FromBody] clsWebExisitingPatientAppointmenthead obj)
        {
            clsWebExisitingPatientAppointment response = new clsWebExisitingPatientAppointment();
            response = _mediBusiness.WebExisitingPatientAppointment(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_ChargeMaster_v1")]
        public List<req_chargeload_v1> Get_ChargeMaster_v1(long code)
        {
            List<req_chargeload_v1> res = new List<req_chargeload_v1>();
            res = _mediBusiness.GetChargeMaster_v1(code);
            return res;
        }
        #endregion
        [HttpPost]
        [ActionName("VisitWithAppointment")]
        public clsWebExisitingPatientAppointment VisitWithAppointment([FromBody] VisitWithAppointment_Detail obj)
        {
            clsWebExisitingPatientAppointment response = new clsWebExisitingPatientAppointment();
            response = _mediBusiness.VisitWithAppointment(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Web_OPBill_Receipt")]
        public clsResult Web_OPBill_Receipt([FromBody] OPBillRecepitHead obj)
        {
            clsResult response = new clsResult();
            response = _mediBusiness.Web_OPBill_Receipt(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_ExisPat_Detail")]
        public List<clsPatientMas_v1> GetPatientMas_List_v1(int patientid)
        {
            List<clsPatientMas_v1> response = new List<clsPatientMas_v1>();
            response = _mediBusiness.GetPatientMas_List_v1(patientid);
            return response;
        }
        [HttpGet]
        [ActionName("get_web_PatientDtl")]
        public List<reswebPatientDtl> Web_PatientDtl_list(string Type, string search)
        {
            List<reswebPatientDtl> response = new List<reswebPatientDtl>();
            response = _mediBusiness.Web_PatientDtl_list(Type, search);
            return response;
        }

        [HttpGet]
        [ActionName("web_PatientDtl")]
        public List<reswebPatientDtl> web_PatientDtl(string Type, string search)
        {
            List<reswebPatientDtl> response = new List<reswebPatientDtl>();
            response = _mediBusiness.web_PatientDtl(Type, search);
            return response;
        }


        [HttpGet]
        [ActionName("getAppList")]
        public List<resAppointmentList> appointmentList_v1(string FromDate, string ToDate)
        {
            List<resAppointmentList> response = new List<resAppointmentList>();
            response = _mediBusiness.Get_appointmentList_v1(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("getAppList_All")]
        public List<resAppointmentListALL> appointmentList_All(string FromDate, string ToDate)
        {
            List<resAppointmentListALL> response = new List<resAppointmentListALL>();
            response = _mediBusiness.appointmentList_All(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Get_appointmentList")]
        public List<resAppointmentList> appointmentList(string Search)
        {
            List<resAppointmentList> response = new List<resAppointmentList>();
            response = _mediBusiness.Get_appointmentList(Search);
            return response;
        }

        [HttpGet]
        [ActionName("GetPortal_PatDtl_New")]
        public List<Newpatient_dtlRes> PatientDtl( string mobileno)
        {
            List<Newpatient_dtlRes> response = new List<Newpatient_dtlRes>();
            response = _mediBusiness.GetPatientDtl(mobileno);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Web_DepositeDtl_Reprint")]
        public List<DepositeDtl_ReprintList> WebDepositeDtlReprint(string FromDate, string ToDate, int Uhid)
        {
            List<DepositeDtl_ReprintList> response = new List<DepositeDtl_ReprintList>();
            response = _mediBusiness.Get_Web_Deposite_Reprint(FromDate, ToDate, Uhid);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Web_PatDepositeDtl")]
        public List<DepositePatientDtl> Get_PatDepositeDtl(int patientid)
        {
            List<DepositePatientDtl> response = new List<DepositePatientDtl>();
            response = _mediBusiness.Get_PatDepositeDtl(patientid);
            return response;
        }
        [HttpGet]
        [ActionName("Get_paymentPortal_Dtl")]
        public List<payment_portal> Get_paymentPortal_Dtl(string frdatae, string todate)
        {
            List<payment_portal> response = new List<payment_portal>();
            response = _mediBusiness.Get_paymentPortal_Dtl(frdatae, todate);

            return response;
        }
        [HttpGet]
        [ActionName("Get_web_DepositeReprint_Output")]
        public List<DepositeReprint_OutputDtl> Get_DepositeReprintOutput(string ReceiptNo)
        {
            List<DepositeReprint_OutputDtl> response = new List<DepositeReprint_OutputDtl>();
            response = _mediBusiness.Get_DepositeReprintOutput(ReceiptNo);
            return response;
        }
        [HttpGet]
        [ActionName("Get_WEB_SP_QMSStatus_Dtl")]
        public resHouseKeepingList Get_WEB_SP_QMSStatus_Dtl(string PatientName, string MobileNo, int PatType)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_WEB_SP_QMSStatus_Dtl(PatientName, MobileNo, PatType);
            return response;
        }

        [HttpGet]
        [ActionName("RadiologyAppointmentStatus")]
        public resHouseKeepingList RadiologyAppointmentStatus(string DoctorName, int UHID, int APPID, int PatType)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.RadiologyAppointmentStatus(DoctorName, UHID, APPID, PatType);
            return response;
        }

        [HttpGet]
        [ActionName("RadiologyAppointmentStatus_v1")]
        public resHouseKeepingList RadiologyAppointmentStatus_v1(string DoctorName, int UHID, int APPID, string PatType)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.RadiologyAppointmentStatus_v1(DoctorName, UHID, APPID, PatType);
            return response;
        }

        [HttpGet]
        [ActionName("Get_QMS_Details")]
        public List<QMSDetails> Get_QMS_Details(string FromDate, string ToDate, string Type)
        {
            List<QMSDetails> response = new List<QMSDetails>();
            response = _mediBusiness.Get_QMS_Details(FromDate, ToDate, Type);
            return response;
        }

        [HttpGet]
        [ActionName("Get_QMS_Details_test")]
        public List<QMSDetails_test> Get_QMS_Details_test(string FromDate, string ToDate, string Type)
        {
            List<QMSDetails_test> response = new List<QMSDetails_test>();
            response = _mediBusiness.Get_QMS_Details_test(FromDate, ToDate, Type);
            return response;
        }

        [HttpGet]
        [ActionName("Get_DaywiseQMS_Data_V1")]
        public resDaywiseQMSList Get_DaywiseQMS_Data_V1()
        {
            resDaywiseQMSList response = new resDaywiseQMSList();
            response = _mediBusiness.Get_DaywiseQMS_Data_V1();
            return response;
        }

        [HttpGet]
        [ActionName("Get_QMS_TVData")]
        public List<resQMSListTV> Get_QMS_TVData()
        {
            List<resQMSListTV> response = new List<resQMSListTV>();
            response = _mediBusiness.Get_QMS_TVData();
            return response;
        }


        [HttpPut]
        [ActionName("UpdateQMSStatus_Dtl")]
        public resHouseKeepingList UpdateQMSStatus_Dtl(Save_QMSDetails obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.UpdateQMSStatus_Dtl(obj);
            return response;
        }

        [HttpPut]
        [ActionName("UpdateQMSStatus_Dtl_test")]
        public resHouseKeepingList UpdateQMSStatus_Dtl_test(Save_QMSDetails obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.UpdateQMSStatus_Dtl_test(obj);
            return response;
        }

        [HttpPost]
        [ActionName("WebSave_QMS_Details")]
        public resQMSDetails WebSave_QMS_Details(req_Save_QMSDetails obj)
        {
            resQMSDetails response = new resQMSDetails();
            response = _mediBusiness.WebSave_QMS_Details(obj);
            return response;
        }

        [HttpPost]
        [ActionName("SavePatientDetails")]
        public resHouseKeepingList SavePatientDetails([FromBody] reqimg obj)
        {
            var httpRequest = HttpContext.Request;
            // string UHID = httpRequest.Headers["UHID"];
            obj.temppath = httpRequest.Headers["temppath"];
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.SavePatientDetails(obj);
            return response;
        }

        [HttpPost]
        [ActionName("import")]
        public resHouseKeepingList import([FromBody] Patient_Portal_PathModel obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.import(obj);
            return response;
        }


        [HttpPost]
        [ActionName("import_v1")]
        public resHouseKeepingList import_v1([FromBody] Patient_Portal_PathModel obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.import_v1(obj);
            return response;
        }


        [HttpGet]
        [ActionName("GetImageDetails")]
        public List<resimgList> GetImageDetails()
        {
            List<resimgList> response = new List<resimgList>();
            response = _mediBusiness.GetImageDetails();
            return response;
        }

        [HttpPost]
        [ActionName("DeleteFilefromDisk")]
        public async Task<IActionResult> DeleteFilefromDisk(reqimageModel lic)
        {
            try
            {
                var connectionString = @"Data Source=192.168.15.7;Initial Catalog=Image_Upload;User ID=hisadmin;Password=W1nd0ws@123/*";

                var root = Path.Combine(@"\\192.168.15.4\PatientPortal", lic.UHID, lic.DocumentName, lic.DocumentPath);

                // var root = Path.Combine(@"\\192.168.15.9\Common Share\PatientPortal", lic.UHID, lic.DocumentName, lic.DocumentPath);

                //  var root = Path.Combine(@"\\192.168.6.26\Uploaded_Files", lic.UHID, lic.DocumentName, lic.DocumentPath);

                var fileInfo = new FileInfo(root);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        await con.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Image_Upload.dbo.Patient_Portal_Path WHERE UHID = @UHID AND DocumentPath = @DocumentPath", con))
                        {
                            cmd.Parameters.AddWithValue("@UHID", lic.UHID);
                            cmd.Parameters.AddWithValue("@DocumentPath", lic.DocumentPath);
                            int iResult = await cmd.ExecuteNonQueryAsync();
                            if (iResult == 1)
                            {
                                return Ok(new reqimageModel
                                {
                                    UHID = lic.UHID,
                                    DocumentName = lic.DocumentName,
                                    DocumentPath = lic.DocumentPath,
                                    Status = "Deleted"
                                });
                            }
                            else
                            {
                                return Ok(new reqimageModel
                                {
                                    UHID = lic.UHID,
                                    DocumentName = lic.DocumentName,
                                    DocumentPath = lic.DocumentPath,
                                    Status = "!Deleted"
                                });
                            }
                        }
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }


        //[HttpPost]
        //[ActionName("import_temporarily")]
        //public async Task<IActionResult> import_temporarily()
        //{

        //    List<reqimg> list = new List<reqimg>();
        //    var httpRequest = HttpContext.Request;
        //    string UHID = httpRequest.Headers["UHID"];
        //    string Paths = httpRequest.Headers["Path"];

        //    if (httpRequest.Form.Files.Count > 0)
        //    {
        //        foreach (var formFile in httpRequest.Form.Files)
        //        {
        //            if (formFile.Length > 0)
        //            {
        //                reqimg GetAll = new reqimg();
        //                var fileName = formFile.FileName;
        //             // var root = string.Format(@"\\192.168.15.9\Common Share\PatientPortal\{0}\{1}", UHID, Paths);
        //             // var root = string.Format(@"\\192.168.15.4\PatientPortal\{0}\{1}", UHID, Paths);
        //                var root = string.Format(@"\\192.168.6.26\Uploaded_Files\{0}\{1}", UHID, Paths);
        //                Directory.CreateDirectory(root);
        //                var filePath = Path.Combine(root, fileName);
        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                await formFile.CopyToAsync(stream);
        //                }

        //                GetAll.TempPath_FileName = fileName;
        //                GetAll.UHID = UHID;
        //                GetAll.temppath = Path.Combine(UHID, Paths, fileName);
        //                list.Add(GetAll);
        //            }
        //        }
        //    }
        //    return Ok(list);
        //}


        [HttpPost]
        [ActionName("import_temporarily")]
        public async Task<IActionResult> import_temporarily()
        {
            var networkPath = @"\\192.168.6.26\Uploaded_Files";
            var username = "rimc";
            var password = "Integrator#2020";

            List<reqimg> list = new List<reqimg>();
            var httpRequest = HttpContext.Request;
            string UHID = httpRequest.Headers["UHID"];
            string Paths = httpRequest.Headers["Path"];

            if (httpRequest.Form.Files.Count > 0)
            {
                foreach (var formFile in httpRequest.Form.Files)
                {
                    if (formFile.Length > 0)
                    {
                        //  byte[] imageData = ReadFile(formFile.FileName);
                        reqimg GetAll = new reqimg();
                        var fileName = formFile.FileName;
                        var root = Path.Combine(networkPath, UHID, Paths);

                        using (new NetworkShare(networkPath, username, password))
                        {
                            // Ensure directory exists
                            Directory.CreateDirectory(root);
                            var filePath = Path.Combine(root, fileName);
                            // Save file to disk
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                                //byte[] imageData = ReadFile(stream.Name);
                                //FileStream fStream = new FileStream(stream.Name, FileMode.Open, FileAccess.Read);
                                //BinaryReader br = new BinaryReader(fStream);

                            }

                            GetAll.TempPath_FileName = fileName;
                            GetAll.UHID = UHID;
                            GetAll.temppath = Path.Combine(UHID, Paths, fileName);
                            list.Add(GetAll);
                        }
                    }
                }
            }
            return Ok(list);
        }

        private byte[] ReadFile(string fileName)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ActionName("DownloadUploadedFiles")]
        public List<Patient_Portal_PathModel> DownloadUploadedFiles(reqPatient_Portal_PathModel lic)
        {
            var connectionString = @"Data Source=192.168.15.7;Initial Catalog=Image_Upload;User ID=hisadmin;Password=W1nd0ws@123/*";
            List<Patient_Portal_PathModel> res = new List<Patient_Portal_PathModel>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Image_Upload.dbo.Patient_Portal_Path where UHID='" + lic.UHID.Trim() + "' and DocumentName='" + lic.DocumentName.Trim() + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Patient_Portal_PathModel result = new Patient_Portal_PathModel();

                        result.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        result.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        result.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        result.DocumentPath = DBNull.Value != dr["DocumentPath"] ? Convert.ToString(dr["DocumentPath"]) : "";
                        result.DocumentName = DBNull.Value != dr["DocumentName"] ? Convert.ToString(dr["DocumentName"]) : "";

                        res.Add(result);

                    }
                }
            }
            return res;
        }


        [HttpPost]
        [ActionName("WebSave_QMS_Details_test")]
        public resHouseKeepingList WebSave_QMS_Details_test([FromBody] Save_QMSDetails obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.WebSave_QMS_Details_test(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_WEB_DayWiseQMS_Dtl")]
        public List<DayWise_QMSDetails> Get_WEB_DayWiseQMS_Dtl()
        {
            List<DayWise_QMSDetails> response = new List<DayWise_QMSDetails>();
            response = _mediBusiness.Get_WEB_DayWiseQMS_Dtl();
            return response;
        }

        [HttpGet]
        [ActionName("Get_RadiologyAppointment")]
        public List<RadiologyAppointment> Get_RadiologyAppointment()
        {
            List<RadiologyAppointment> response = new List<RadiologyAppointment>();
            response = _mediBusiness.Get_RadiologyAppointment();
            return response;
        }

        [HttpGet]
        [ActionName("Get_RadiologyAppointment_Modality")]
        public List<RadiologyAppointment> Get_RadiologyAppointment_Modality()
        {
            List<RadiologyAppointment> response = new List<RadiologyAppointment>();
            response = _mediBusiness.Get_RadiologyAppointment_Modality();
            return response;
        }

        [HttpGet]
        [ActionName("Get_WEB_DayWiseQMS_Dtl_test")]
        public List<DayWise_QMSDetails_test> Get_WEB_DayWiseQMS_Dtl_test()
        {
            List<DayWise_QMSDetails_test> response = new List<DayWise_QMSDetails_test>();
            response = _mediBusiness.Get_WEB_DayWiseQMS_Dtl_test();
            return response;
        }

        [HttpGet]
        [ActionName("Get_WEB_DepPatAmt_Details")]
        public List<DepPatAmt_Details> Get_WEB_DepPatAmt_Details(int UHID)
        {
            List<DepPatAmt_Details> response = new List<DepPatAmt_Details>();
            response = _mediBusiness.Get_WEB_DepPatAmt_Details(UHID);
            return response;
        }

        [HttpGet]
        [ActionName("Get_web_DepositType_Dtl")]
        public List<clsDropDown> Get_web_DepositType_Dtl()
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.Get_web_DepositType_Dtl();
            return response;
        }


        [HttpGet]
        [ActionName("Get_web_RadLandingScreen_Dtl")]
        public List<clsRadLandingScreen> Get_web_RadLandingScreen_Dtl(string dtFrom, string dtTo, int blnOrderwise)
        {
            List<clsRadLandingScreen> response = new List<clsRadLandingScreen>();
            response = _mediBusiness.Get_web_RadLandingScreen_Dtl(dtFrom, dtTo, blnOrderwise);
            return response;
        }
        [HttpGet]
        [ActionName("Web_CardiologyLanding")]
        public List<clsCardiologyLanding> Web_CardiologyLanding(string FromDate, string ToDate)
        {
            List<clsCardiologyLanding> response = new List<clsCardiologyLanding>();
            response = _mediBusiness.Web_CardiologyLanding(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Web_NMLanding_Dtl")]
        public List<clsNMLanding_Dtl> Web_NMLanding_Dtl(string FromDate, string ToDate)
        {
            List<clsNMLanding_Dtl> response = new List<clsNMLanding_Dtl>();
            response = _mediBusiness.Web_NMLanding_Dtl(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Web_GetRadRequisitionSlipDetail")]
        public List<clsWeb_GetRadRequisitionSlipDetail> Web_GetRadRequisitionSlipDetail(string sPatient, string strRegID, string OrderID, string strSampleNo)
        {
            List<clsWeb_GetRadRequisitionSlipDetail> response = new List<clsWeb_GetRadRequisitionSlipDetail>();
            response = _mediBusiness.Web_GetRadRequisitionSlipDetail(sPatient, strRegID, OrderID, strSampleNo);
            return response;
        }

        [HttpGet]
        [ActionName("web_RadPatientSearch")]
        public List<clsweb_RadPatientSearch> web_RadPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_RadPatientSearch> response = new List<clsweb_RadPatientSearch>();
            response = _mediBusiness.web_RadPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
            return response;
        }
        [HttpGet]
        [ActionName("web_NMPatientSearch")]
        public List<clsweb_NMPatientSearch> web_NMPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_NMPatientSearch> response = new List<clsweb_NMPatientSearch>();
            response = _mediBusiness.web_NMPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
            return response;
        }

        [HttpGet]
        [ActionName("web_MediScanPatientSearch")]
        public List<clsweb_MediScanPatientSearch> web_MediScanPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_MediScanPatientSearch> response = new List<clsweb_MediScanPatientSearch>();
            response = _mediBusiness.web_MediScanPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
            return response;
        }

        [HttpGet]
        [ActionName("opList")]
        public List<resOPList> opList(string Type, string Search)
        {
            List<resOPList> response = new List<resOPList>();
            response = _mediBusiness.Get_opList(Type, Search);
            return response;
        }


        [HttpGet]
        [ActionName("visitType")] // change.....29/10/2021
        public List<clsDropDown> GetvisitType(string type)
        {
            List<clsDropDown> req = new List<clsDropDown>();
            req = _mediBusiness.GetvisitType(type);

            return req;
        }

        [HttpGet]
        [ActionName("getPatientRegistrationPdf")]
        public clsPatientRegistrationPdf GetPatientRegOutPutPdf(int RegId)
        {
            clsPatientRegistrationPdf response = new clsPatientRegistrationPdf();
            response = _mediBusiness.GetPatientRegOutPutPdf(RegId);

            return response;
        }

        [HttpGet]
        [ActionName("GetInvoiceReprint_out_NEW")]
        public InvoiceHead1 OpReprint_V1(int BillNo)
        {
            InvoiceHead1 response = new InvoiceHead1();
            response = _mediBusiness.OpReprint_V1(BillNo);
            return response;
        }
        [HttpGet]
        [ActionName("getTransactionStatus")]
        public salucroresponse SalucroPayment_StatusCheck(string processingid)
        {
            try
            {
                DataTable dtPending;
                salucroresponse sresponse = new salucroresponse();
                salucrorequest request = new salucrorequest();
                clsQryResponse output = new clsQryResponse();
                dtPending = new DataTable();
                DataLayer dataLayer = new DataLayer();
                dtPending = dataLayer.getPendingDetails(processingid).Tables[0];

                request.processing_id = processingid;
                string checksum = MediDBConstants.sha256_hash(processingid + "|" + request.mid + "|" + request.auth_user + "|" + request.auth_key + "|" + MediDBConstants.secret_key);
                request.check_sum_hash = checksum;
                if (dtPending.Rows.Count > 0)
                    request.username = string.IsNullOrEmpty(dtPending.Rows[0]["Onl_CreatedCode"].ToString()) ? request.username : dtPending.Rows[0]["Onl_CreatedCode"].ToString();
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("processing_id", request.processing_id);
                    reqparm.Add("mid", request.mid);
                    reqparm.Add("auth_user", request.auth_user);
                    reqparm.Add("auth_key", request.auth_key);
                    reqparm.Add("username", request.username);
                    reqparm.Add("check_sum_hash", request.check_sum_hash);
                    byte[] responsebytes = null;
                    responsebytes = client.UploadValues(MediDBConstants.salucro_url, "POST", reqparm);
                    string responsebody = (new System.Text.UTF8Encoding()).GetString(responsebytes);
                    sresponse = JsonConvert.DeserializeObject<salucroresponse>(responsebody);
                    client.Dispose();
                }
                return sresponse;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]//PRABHA03/12/2
        [ActionName("getInvoice_Reprint_List")]
        public List<reqInvoice_Reprint_List> web_Invoice_Reprint_List_procedure(string FromDate, string ToDate, string type, string Search)
        {
            List<reqInvoice_Reprint_List> response = new List<reqInvoice_Reprint_List>();

            response = _mediBusiness.web_Invoice_Reprint_List_procedure(FromDate, ToDate, type, Search);
            return response;
        }

        [HttpGet]
        [ActionName("get_WebRef_pat")]
        public List<clswebRef_patient> get_WebRef_pat(int appPatID)
        {
            List<clswebRef_patient> response = new List<clswebRef_patient>();
            response = _mediBusiness.get_WebRef_pat(appPatID);
            return response;
        }

        [HttpGet]
        [ActionName("Package_Patient_venue")]
        public List<cls_Patient_venue> Package_Patient_venue(string RefDateTime)
        {
            List<cls_Patient_venue> response = new List<cls_Patient_venue>();
            response = _mediBusiness.Package_Patient_venue(RefDateTime);
            return response;
        }

        [HttpGet]
        [ActionName("Get_PatientVenue_temp")]
        public List<cls_Patient_venue_temp> Get_PatientVenue_temp()
        {
            List<cls_Patient_venue_temp> response = new List<cls_Patient_venue_temp>();
            response = _mediBusiness.Get_PatientVenue_temp();
            return response;
        }

        [HttpGet]
        [ActionName("Package_master")]
        public List<cls_Patient_master> Package_master()
        {
            List<cls_Patient_master> response = new List<cls_Patient_master>();
            response = _mediBusiness.Package_master();
            return response;
        }

        [HttpGet]
        [ActionName("Get_OT_Scheduleing")]
        public List<cls_OTScheduleing> Get_OT_Scheduleing()
        {
            List<cls_OTScheduleing> response = new List<cls_OTScheduleing>();
            response = _mediBusiness.Get_OT_Scheduleing();
            return response;
        }


        [HttpGet]
        [ActionName("Get_DischargeTrackingreport")] 
        public List<cls_DischargeTrackingreport> Get_DischargeTrackingreport(string FromDate, string ToDate)
        {
            List<cls_DischargeTrackingreport> response = new List<cls_DischargeTrackingreport>();
            response = _mediBusiness.Get_DischargeTrackingreport( FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Radiologypatientsearch")]
        public List<cls_Radiologypatientsearch> Get_Radiologypatientsearch()
        {
            List<cls_Radiologypatientsearch> response = new List<cls_Radiologypatientsearch>();
            response = _mediBusiness.Get_Radiologypatientsearch();
            return response;
        }


        [HttpGet]
        [ActionName("Get_heartandlungs")]
        public List<cls_heartandlungs> Get_heartandlungs()
        {
            List<cls_heartandlungs> response = new List<cls_heartandlungs>();
            response = _mediBusiness.Get_heartandlungs();
            return response;
        }

        [HttpPost]
        [ActionName("Save_heartandlungs")]
        public res_heartandlungs Save_heartandlungs(req_heartandlungs obj)
        {
            res_heartandlungs response = new res_heartandlungs();
            response = _mediBusiness.Save_heartandlungs(obj);
            return response;
        }


        [HttpGet]
        [ActionName("PatientVenue_temp")]
        public List<cls_PatientVenue_temp> PatientVenue_temp()
        {
            List<cls_PatientVenue_temp> response = new List<cls_PatientVenue_temp>();
            response = _mediBusiness.PatientVenue_temp();
            return response;
        }

        [HttpGet]
        [ActionName("Test_master")]
        public List<cls_Test_master> Test_master(string PackageCode)
        {
            List<cls_Test_master> response = new List<cls_Test_master>();
            response = _mediBusiness.Test_master(PackageCode);
            return response;
        }


        [HttpGet]
        [ActionName("BedRateAndNursingRate_dtl")]
        public List<BedRateAndNursingRate> BedRateAndNursingRate_dtl(int Bedcategoryid)
        {
            List<BedRateAndNursingRate> response = new List<BedRateAndNursingRate>();
            response = _mediBusiness.BedRateAndNursingRate_dtl(Bedcategoryid);
            return response;
        }


        [HttpGet]
        [ActionName("web_sp_BedDetails_Load")]
        public List<BedDetails_Load> web_sp_BedDetails_Load(int CatId)
        {
            List<BedDetails_Load> response = new List<BedDetails_Load>();
            response = _mediBusiness.web_sp_BedDetails_Load(CatId);
            return response;
        }

        [HttpGet]
        [ActionName("web_sp_Get_BedID")]
        public List<Get_BedID> web_sp_Get_BedID(int BedId)
        {
            List<Get_BedID> response = new List<Get_BedID>();
            response = _mediBusiness.web_sp_Get_BedID(BedId);
            return response;
        }

        [HttpGet]
        [ActionName("BedBlockDetails_Load")]
        public List<BedBlockDetails> BedBlockDetails_Load()
        {
            List<BedBlockDetails> response = new List<BedBlockDetails>();
            response = _mediBusiness.BedBlockDetails_Load();
            return response;
        }

        [HttpGet]
        [ActionName("Get_CriticalCare_InfectiousDis")]
        public List<CriticalCare> Get_CriticalCare_InfectiousDis()
        {
            List<CriticalCare> response = new List<CriticalCare>();
            response = _mediBusiness.Get_CriticalCare_InfectiousDis();
            return response;
        }

        [HttpPost]
        [ActionName("InsertCriticalCare_InfectiousDis")]
        public InsertCriticalCare_InfectiousDis_Res InsertCriticalCare_InfectiousDis(InsertCriticalCare_req obj)
        {
            InsertCriticalCare_InfectiousDis_Res response = new InsertCriticalCare_InfectiousDis_Res();
            response = _mediBusiness.InsertCriticalCare_InfectiousDis(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Doctor_Directory_Js")]
        public List<Doctor_Directory> Get_Doctor_Directory_Js()
        {
            List<Doctor_Directory> response = new List<Doctor_Directory>();
            response = _mediBusiness.Get_Doctor_Directory_Js();
            return response;
        }



        [HttpPost]
        [ActionName("InsertDoctor_Directory_Js")]
        public InsertDoctor_Directory_Js_Res InsertDoctor_Directory_Js(InsertDoctor_Directory_Js_req obj)
        {
            InsertDoctor_Directory_Js_Res response = new InsertDoctor_Directory_Js_Res();
            response = _mediBusiness.InsertDoctor_Directory_Js(obj);
            return response;
        }

        [HttpPut]
        [ActionName("UPDATEDoctor_Directory_Js")]
        public UPDATEDoctor_Directory_Js_Res UPDATEDoctor_Directory_Js(UPDATEDoctor_Directory_Js_req obj)
        {
            UPDATEDoctor_Directory_Js_Res response = new UPDATEDoctor_Directory_Js_Res();
            response = _mediBusiness.UPDATEDoctor_Directory_Js(obj);
            return response;
        }


        [HttpGet]
        [ActionName("Get_TVbackgraound")]
        public List<TVbackgraound> Get_TVbackgraound()
        {
            List<TVbackgraound> response = new List<TVbackgraound>();
            response = _mediBusiness.Get_TVbackgraound();
            return response;
        }

        [HttpPut]
        [ActionName("UpdateTVbackgraound")]
        public UpdateTVbackgraound_Res UpdateTVbackgraound(UpdateTVbackgraound_req obj)
        {
            UpdateTVbackgraound_Res response = new UpdateTVbackgraound_Res();
            response = _mediBusiness.UpdateTVbackgraound(obj);
            return response;
        }
        [HttpPost]
        [ActionName("updatePOSPayment")]
        public Response_DTO_v1 updatePOSPayment(payment_request payment_Request)
        {
            Response_DTO_v1 response = new Response_DTO_v1();
            response = _mediBusiness.updatePOSPayment(payment_Request);
            return response;
        }

        [HttpPost]
        [ActionName("updateOnlinePayment")]
        public Response_pay updateOnlinePayment(pay_request pay_Request)
        {
            Response_pay response = new Response_pay();
            response = _mediBusiness.updateOnlinePayment(pay_Request);
            return response;
        }


        [HttpGet]
        [ActionName("AuthenticateMobNo_Upload_V1")]
        public List<Authenticate> AuthenticateMobNo_Upload_V1(string OTP_MobileNo, int Otp)
        {
            List<Authenticate> response = new List<Authenticate>();
            response = _mediBusiness.AuthenticateMobNo_Upload_V1(OTP_MobileNo, Otp);
            return response;
        }

        //        [HttpPost]
        //        [ActionName("sendotp_Portal")]
        //        public SendPatientDTO sendotp_Portal([FromBody] SendPatientDTO patient)
        //        {
        //            string URL = "";
        //            Random rm = new Random();
        //            string RandomNumber = rm.Next(1000, 9999).ToString();

        //            //if (patient.CountryCode == "101") by jeyaganesh 04.05.2021

        //            URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=344ad822d6e3ec7d6eba5d69a084bc7d&message=Your OTP is " + RandomNumber + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";


        //            ////if (patient.CountryCode == "+91")
        //            ////{
        //            ////    URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=Your OTP is " + RandomNumber + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";
        //            ////}
        //            ////else
        //            ////{
        //            ////    URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=YourOTPis " + RandomNumber + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + patient.MobileNo + "&service=G";
        //            ////}
        //            //URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=f61f0a429797f88328690649ed72cfb3&message=YourOTPis " + RandomNumber + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";

        //            WebRequest myWebRequest = WebRequest.Create(URL);
        //            WebResponse myWebResponse = myWebRequest.GetResponse();
        //            Stream ReceiveStream = myWebResponse.GetResponseStream();
        //            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        //            StreamReader readStream = new StreamReader(ReceiveStream, encode);
        //            string strResponse = readStream.ReadToEnd();

        //            string strRetmessage = "";
        //            if (strResponse.Contains("422"))
        //                strRetmessage = "OTP Not Delivered";
        //            else
        //                strRetmessage = "OTP Delivered";

        //            _mediBusiness.InsertUpdateOTP_portal(RandomNumber, patient.MobileNo);
        //            patient.Authenticated = strRetmessage;
        //            return patient;
        //}




        [HttpPost]
        [ActionName("sendotp_Portal")]
        public SendPatientDTO sendotp_Portal([FromBody] SendPatientDTO patient)
        {
            if (string.IsNullOrEmpty(patient.MobileNo))
            {
                throw new ArgumentException("Mobile number cannot be null or empty.");
            }

            // Ensure the mobile number starts with '91'
            if (!patient.MobileNo.StartsWith("91"))
            {
                patient.MobileNo = "91" + patient.MobileNo.TrimStart('0'); // Add '91' if not already present
            }

            // Check if the mobile number starts with '91'
            if (!patient.MobileNo.StartsWith("91"))
            {
                patient.Authenticated = "Invalid Mobile Number";
                patient.OTP = ""; // Ensure OTP is not returned in this case
                return patient;
            }

            // Generate a random 4-digit OTP
            Random random = new Random();
            string otp = random.Next(1000, 9999).ToString();

            // Construct the API URL
            string baseUrl = "https://rest.qikberry.ai/v1/sms/messages";
            string accessToken = "344ad822d6e3ec7d6eba5d69a084bc7d";
            string senderId = "RELAIN";
            string message = $"Your OTP is {otp}, Dr. Rela Institute and Medical Centre.";
            string serviceType = "T"; // Adjust this if needed for different country codes

            string url = $"{baseUrl}?access_token={accessToken}&message={Uri.EscapeDataString(message)}&sender={senderId}&to={patient.MobileNo}&service={serviceType}";

            try
            {
                // Send the request
                WebRequest webRequest = WebRequest.Create(url);
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new Exception("No response from SMS API.");
                    }

                    using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        string response = reader.ReadToEnd();

                        // Check response for success or failure
                        if (response.Contains("422"))
                        {
                            patient.Authenticated = "OTP Not Delivered";
                        }
                        else
                        {
                            patient.Authenticated = "OTP Delivered";
                        }
                    }
                }

                // Save OTP to the database without the '91' prefix
                string mobileNoWithoutPrefix = patient.MobileNo.Substring(2); // Remove the first two characters ('91')
                _mediBusiness.InsertUpdateOTP_portal(otp, mobileNoWithoutPrefix);

                // Set OTP as empty in the response
                patient.OTP = ""; // Empty OTP field in the response
            }
            catch (Exception ex)
            {
                // Log the error and update the response
                patient.Authenticated = "OTP Delivery Failed";
                // Log exception details here (e.g., log to a file or monitoring system)
                Console.WriteLine("Error: " + ex.Message);

                // Return an empty OTP in case of error
                patient.OTP = "";
            }

            return patient;
        }


        [HttpPost]
        [ActionName("verifyotp")]
        public OTP_Resp authenticate([FromBody] reqPatientDTO patientDTO)
        {
            string strRetmessage = "";
            OTP_Resp patientres = new OTP_Resp();

            List<PatientDTO> patdto = new List<PatientDTO>();
            //List<AutheticateDTO> authenticated = new List<AutheticateDTO>();
            List<PatientDTO> patients = new List<PatientDTO>();
            strRetmessage = _mediBusiness.AuthenticateOTP(patientDTO.OTP, patientDTO.MobileNo);


            //List<PatientDTO> appointmentSlots = new List<PatientDTO>();
            //appointmentSlots = _mediBusiness.GetAppointmentSlotDetails(appointmentSlot);
            if (strRetmessage == "1")
                //patientres = _mediBusiness.GetPatientResp_MobNo(patientDTO.OTP, patientDTO.MobileNo);
                patientres.response = "OTP Sucess";

            else
            {
                PatientDTO po = new PatientDTO();
                po.UHID = "";
                po.PatientName = "";
                po.Gender = "";
                po.DOB = "";
                po.MobileNo = "";
                po.Authenticated = "OTP Mismatched";
                patients.Add(po);
                patientres.patientDTO = patients;
                patientres.responsecode = 1;
                patientres.response = "OTP Mismatched";
                patientres.status = "";
            }
            return patientres;
        }


        [HttpGet]
        [ActionName("Get_BirthDay_Info_New")]
        public List<res_BirthDay_Info_New> Get_BirthDay_Info_New(string date)
        {
            List<res_BirthDay_Info_New> response = new List<res_BirthDay_Info_New>();
            response = _mediBusiness.Get_BirthDay_Info_New(date);
            return response;
        }


        [HttpGet]
        [ActionName("Kranium_EMRAPILog")]
        public List<res_EMRAPILog> Kranium_EMRAPILog(string Fdate, string tdate, string Status)
        {
            List<res_EMRAPILog> response = new List<res_EMRAPILog>();
            response = _mediBusiness.Kranium_EMRAPILog(Fdate, tdate, Status);
            return response;
        }

        [HttpPost]
        [ActionName("save_opd_Process_Dtl")]
        public responseDtl save_opd_Process_Dtl(requestDtl requestDtl)
        {
            responseDtl response = new responseDtl();
            response = _mediBusiness.save_opd_Process_Dtl(requestDtl);
            return response;
        }


        [HttpPost]
        [ActionName("save_e_certificate")]
        public responseDtl save_e_certificate(requeste_cert requeste_cert)
        {
            responseDtl response = new responseDtl();
            response = _mediBusiness.save_e_certificate(requeste_cert);
            return response;
        }

        [HttpGet]
        [ActionName("Get_opd_Process")]
        public List<res_opd_Process> Get_opd_Process(string Todate)
        {
            List<res_opd_Process> response = new List<res_opd_Process>();
            response = _mediBusiness.Get_opd_Process(Todate);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Doctor_TV")]
        public List<res_doctor_tv> Get_Doctor_TV(string TvTag)
        {
            List<res_doctor_tv> response = new List<res_doctor_tv>();
            response = _mediBusiness.Get_Doctor_TV(TvTag);
            return response;
        }

        [HttpGet]
        [ActionName("Get_opd_Process_v1")]
        public List<res_opd_Process> Get_opd_Process_v1(string Todate, int Type)
        {
            List<res_opd_Process> response = new List<res_opd_Process>();
            response = _mediBusiness.Get_opd_Process_v1(Todate, Type);
            return response;
        }

        [HttpGet]
        [ActionName("UpdateQCEMRDashboard_Visit")]
        public List<res_UpdateQC_Visit> UpdateQCEMRDashboard_Visit(string Todate, int VisitId)
        {
            List<res_UpdateQC_Visit> response = new List<res_UpdateQC_Visit>();
            response = _mediBusiness.UpdateQCEMRDashboard_Visit(Todate, VisitId);
            return response;
        }
        [HttpPost]
        [ActionName("SaveOrUpdateQCVisittracking")]
        public responseDtl SaveOrUpdateQCVisittracking(req_Visittracking requestDtl)
        {
            responseDtl response = new responseDtl();
            response = _mediBusiness.SaveOrUpdateQCVisittracking(requestDtl);
            return response;
        }

        [HttpPost]
        [ActionName("SaveEMROTDet")]
        public resEMROTDetl SaveEMROTDet(req_EMROTDetl requestDtl)
        {
            resEMROTDetl response = new resEMROTDetl();
            response = _mediBusiness.SaveEMROTDet(requestDtl);
            return response;
        }

        [HttpPost]
        [ActionName("SaveOrUpdateQCOrderTracking")]
        public responseDtl SaveOrUpdateQCOrderTracking(req_OrderTracking requestDtl)
        {
            responseDtl response = new responseDtl();
            response = _mediBusiness.SaveOrUpdateQCOrderTracking(requestDtl);
            return response;
        }

        [HttpPost]
        [ActionName("AvailableSlot_ampm")]
        public List<SlotRes_DTO> GetAvailableAppointmentSlot_Web([FromBody] SlotReq_DTO slotReq_DTO)
        {
            List<SlotRes_DTO> slotRes_DTOs = new List<SlotRes_DTO>();
            slotRes_DTOs = _mediBusiness.GetAppointmentSlot_Web(slotReq_DTO);

            return slotRes_DTOs;
        }

        [HttpPost]
        [ActionName("AvailableSlot_ampm_seq")]
        public List<SlotRes_DTO_seq> GetAvailableAppointmentSlot_Web_seq([FromBody] SlotReq_DTO_seq slotReq_DTO)
        {
            List<SlotRes_DTO_seq> slotRes_DTOs = new List<SlotRes_DTO_seq>();
            slotRes_DTOs = _mediBusiness.GetAvailableAppointmentSlot_Web_seq(slotReq_DTO);

            return slotRes_DTOs;
        }

        [HttpPost]
        [ActionName("DepartmentWiseDoctorID")]
        public List<clsDoctor> GetDepartmentWiseDoctorID([FromBody] DepartmentwiseDoctorFilter dep)
        {
            List<clsDoctor> response = new List<clsDoctor>();
            response = _mediBusiness.GetDoctorNameDepWiseDocID(dep);

            return response;
        }

        [HttpPost]
        [ActionName("createAppointment")]
        public appointment_Response createAppointment([FromBody] AppointmentBooking appointmentBooking)
        {
            try
            {
                appointment_Response response = new appointment_Response();
                response = _mediBusiness.createAppointment(appointmentBooking);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [ActionName("createAppointment_seq")]
        public appointment_Response createAppointment_seq([FromBody] AppointmentBooking_seq appointmentBooking_sqe)
        {
            try
            {
                appointment_Response response = new appointment_Response();
                response = _mediBusiness.createAppointment_seq(appointmentBooking_sqe);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [ActionName("update_Doctor_TV")]
        public update_Doctor_TV_Res update_Doctor_TV(update_Doctor_TV_req obj)
        {
            update_Doctor_TV_Res response = new update_Doctor_TV_Res();
            response = _mediBusiness.update_Doctor_TV(obj);
            return response;
        }


        [HttpGet]
        [ActionName("Doctor_TV")]
        public List<res_doctor_tv> Doctor_TV()
        {
            List<res_doctor_tv> response = new List<res_doctor_tv>();
            response = _mediBusiness.Doctor_TV();
            return response;
        }


        [HttpDelete]
        [ActionName("Delete_Doctor_TV")]
        public delete_Doctor_TV_Res Delete_Doctor_TV(delete_Doctor_TV_req obj)
        {
            delete_Doctor_TV_Res response = new delete_Doctor_TV_Res();
            response = _mediBusiness.Delete_Doctor_TV(obj);
            return response;
        }

        [HttpPost]
        [ActionName("getslots")]
        public List<AppointmentSlotDTO> GetDoctorAppointmentSlots([FromBody] AppointmentSlotDTO appointmentSlot)
        {
            List<AppointmentSlotDTO> appointmentSlots = new List<AppointmentSlotDTO>();
            appointmentSlots = _mediBusiness.GetAppointmentSlotDetails(appointmentSlot);

            return appointmentSlots;
        }


        [HttpPost]
        [ActionName("getdays")]
        public List<AppointmentSlotDTO> GetDoctorAppointmentDays([FromBody] AppointmentSlotDTO appointmentSlot)
        {
            List<AppointmentSlotDTO> appointmentSlots = new List<AppointmentSlotDTO>();
            appointmentSlots = _mediBusiness.GetAppointmentSlotDaysDetails(appointmentSlot);
            return appointmentSlots;
        }


        [HttpGet]
        [ActionName("getmepz")]
        public List<res_mepz> getmepz()
        {
            List<res_mepz> response = new List<res_mepz>();
            response = _mediBusiness.getmepz();
            return response;
        }

        [HttpPost]
        [ActionName("update_Mepz_tb")]
        public update_Mepz_tb_res update_Mepz_tb(update_Mepz_tb_req obj)
        {
            update_Mepz_tb_res response = new update_Mepz_tb_res();
            response = _mediBusiness.update_Mepz_tb(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Signature_Upload")]
        public signatureModel_res Signature_Upload(req_signatureModel obj)
        {
            signatureModel_res response = new signatureModel_res();
            response = _mediBusiness.Signature_Upload(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Save_PatientVenue_temp")]
        public PatientVenue_res Save_PatientVenue_temp(req_PatientVenue obj)
        {
            PatientVenue_res response = new PatientVenue_res();
            response = _mediBusiness.Save_PatientVenue_temp(obj);
            return response;
        }


        [HttpGet]
        [ActionName("PharmacyRevenueReport")]
        public List<res_RevenueReport> PharmacyRevenueReport(string FromDate, string ToDate)
        {
            List<res_RevenueReport> response = new List<res_RevenueReport>();
            response = _mediBusiness.PharmacyRevenueReport(FromDate, ToDate);
            return response;
        }

        //[HttpGet]
        //[ActionName("SP_OPIPREVENUE")]
        //public List<res_opiprevenue> SP_OPIPREVENUE(string FromDate, string ToDate, string Pattype, int IVF_flg)
        //{
        //    List<res_opiprevenue> response = new List<res_opiprevenue>();
        //    response = _mediBusiness.SP_OPIPREVENUE(FromDate, ToDate, Pattype, IVF_flg);
        //    return response;
        //}

        [HttpGet]
        [ActionName("OPIPREVENUE_Date")]
        public List<res_OPIPREVENUE_Date> OPIPREVENUE_Date(string FromDate, string ToDate, string Pattype, int IVF_flg)
        {
            List<res_OPIPREVENUE_Date> response = new List<res_OPIPREVENUE_Date>();
            response = _mediBusiness.OPIPREVENUE_Date(FromDate, ToDate, Pattype, IVF_flg);
            return response;
        }

        [HttpGet]
        [ActionName("Revenu_dashboard")]
        public List<res_REVENUE_Date> Revenu_dashboard(string FromDate, string ToDate)
        {
            List<res_REVENUE_Date> response = new List<res_REVENUE_Date>();
            response = _mediBusiness.Revenu_dashboard(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Signature_PatientRelation")]
        public List<res_PatientRelation> Signature_PatientRelation()
        {
            List<res_PatientRelation> response = new List<res_PatientRelation>();
            response = _mediBusiness.Signature_PatientRelation();
            return response;
        }

        [HttpGet]
        [ActionName("DoctorsList")]
        public List<DoctorDTO> GetDoctorsDetails()
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            doctors = _mediBusiness.GetDoctorDetails();

            return doctors;
        }

        [HttpGet]
        [ActionName("PackagePriceList")]
        public List<resPackagePriceList> PackagePriceList()
        {
            List<resPackagePriceList> response = new List<resPackagePriceList>();
            response = _mediBusiness.Get_PackagePriceList();
            return response;
        }


        [HttpGet]
        [ActionName("Get_PIS_StatDetails_dtl")]
        public List<res_PIS_StatDetails_dtl> Get_PIS_StatDetails_dtl()
        {
            List<res_PIS_StatDetails_dtl> response = new List<res_PIS_StatDetails_dtl>();
            response = _mediBusiness.Get_PIS_StatDetails_dtl();
            return response;
        }

        [HttpGet]
        [ActionName("Get_Kranium_feedback")]
        public List<Res_Kranium_feedback> Get_Kranium_feedback()
        {
            List<Res_Kranium_feedback> response = new List<Res_Kranium_feedback>();
            response = _mediBusiness.Get_Kranium_feedback();
            return response;
        }


        [HttpGet]
        [ActionName("Get_BedStatusViewDetails")]
        public List<Res_BedStatus> Get_BedStatusViewDetails()
        {
            List<Res_BedStatus> response = new List<Res_BedStatus>();
            response = _mediBusiness.Get_BedStatusViewDetails();
            return response;
        }

        [HttpGet]
        [ActionName("Get_Doctorwiseappointmentlist")]
        public List<Res_docwiseapplist> Get_Doctorwiseappointmentlist(string FromDate, string ToDate)
        {
            List<Res_docwiseapplist> response = new List<Res_docwiseapplist>();
            response = _mediBusiness.Get_Doctorwiseappointmentlist(FromDate, ToDate);
            return response;
        }

        [HttpGet]   
        [ActionName("Get_ListOfAdmission")]
        public List<Res_ListOfAdmission> Get_ListOfAdmission(string FromDate, string ToDate) 
        {
            List<Res_ListOfAdmission> response = new List<Res_ListOfAdmission>();
            response = _mediBusiness.Get_ListOfAdmission(FromDate, ToDate);
            return response;
        }


        [HttpGet]
        [ActionName("Get_LobbyTokenType")]
        public List<Res_ListOfLobbyToken> Get_LobbyTokenType(string TokenType)
        {
            List<Res_ListOfLobbyToken> response = new List<Res_ListOfLobbyToken>();
            response = _mediBusiness.Get_LobbyTokenType(TokenType);
            return response;
        }

        [HttpPost]
        [ActionName("Portal_InvoiceGenerate")]
        public app_Response portal_invoice([FromBody] AppointmentBooking appointmentBooking)
        {
            app_Response response = new app_Response();
            response = _mediBusiness.portal_invoice(appointmentBooking);
            return response;
        }

        [HttpGet]
        [ActionName("Get_EMROPInvestigation_dtl")]
        public List<OPInvestigationResponse> Get_EMROPInvestigation_dtl(int uhid )
        {
            List<OPInvestigationResponse> reponse = new List<OPInvestigationResponse>();
            reponse = _mediBusiness.Get_EMROPInvestigation_dtl(uhid);
            return reponse;
        }

        //[HttpGet]
        //[ActionName("Get_WEB_OPDrConsult")]
        //public List<OPDrConsult> Get_WEB_OPDrConsult(string FromDate, string ToDate, int uhid)
        //{
        //    List<OPDrConsult> reponse = new List<OPDrConsult>();
        //    reponse = _mediBusiness.Get_WEB_OPDrConsult(FromDate, ToDate, uhid);
        //    return reponse;
        //}

        [HttpPost]
        [ActionName("updateRegistrationInvoice")]
        public app_Response regisrtaionInvoice(clsRegInvoice obj)
        {
            app_Response response = new app_Response();
            response = _mediBusiness.postRegistrationInvoice(obj);
            return response;
        }


        [HttpPost]
        [ActionName("Save_Insurance_Pre_Auth")]
        public Res_Insurance Save_Insurance_Pre_Auth(Req_Insurance obj)
        {
            Res_Insurance response = new Res_Insurance();
            response = _mediBusiness.Save_Insurance_Pre_Auth(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Slot_New_Hdr")]
        public Res_New_Hdr Slot_New_Hdr(Req_Slot_New_Hdr_SP obj)
        {
            Res_New_Hdr response = new Res_New_Hdr();
            response = _mediBusiness.Slot_New_Hdr(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Slot_New_Dtl")]
        public Res_slotbooking Slot_New_Dtl(Req_Slot_New_Dtl_SP obj)
        {
            Res_slotbooking response = new Res_slotbooking();
            response = _mediBusiness.Slot_New_Dtl(obj);
            return response;
        }

        [HttpPost]
        [ActionName("SaveSLTDate")]
        public Res_sltdate SaveSLTDate(Req_sltdate obj)
        {
            Res_sltdate response = new Res_sltdate();
            response = _mediBusiness.SaveSLTDate(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_DoctorseqSlotGap")]
        public List<DoctorseqSlotGap> Get_DoctorseqSlotGap(int DoctorId)
        {
            List<DoctorseqSlotGap> response = new List<DoctorseqSlotGap>();
            response = _mediBusiness.Get_DoctorseqSlotGap(DoctorId);
            return response;
        }

        [HttpGet]
        [ActionName("AvailableConsultantSlot")]
        public List<ConsultantSlot> AvailableConsultantSlot(int DoctorId , string FromDate, string ToDate)
        {
            List<ConsultantSlot> response = new List<ConsultantSlot>();
            response = _mediBusiness.AvailableConsultantSlot(DoctorId, FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("GetInsurance_Pre_Auth")]
        public List<clsInsurance_Pre_Auth> GetInsurance_Pre_Auth()
        {
            List<clsInsurance_Pre_Auth> response = new List<clsInsurance_Pre_Auth>();
            response = _mediBusiness.GetInsurance_Pre_Auth();
            return response;
        }

 
        [HttpGet]
        [ActionName("GetDepositreports")]
        public List<clsGetDepositAllocation> GetDepositreports(string FromDate, string Todate, int Uhid)
        {
            List<clsGetDepositAllocation> response = new List<clsGetDepositAllocation>();
            response = _mediBusiness.GetDepositreports(FromDate, Todate, Uhid);
            return response;
        }

        [HttpGet]
        [ActionName("GetAppointmentPatientSearch")]
        public List<clsPatientDtlsForDeposit> GetAppointmentPatientSearch(string FromDate, string ToDate)
        {
            List<clsPatientDtlsForDeposit> response = new List<clsPatientDtlsForDeposit>();
            response = _mediBusiness.GetAppointmentPatientSearch(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("GetRefundReport")]
        public List<clsRefundReport_SP> GetRefundReport(string FromDate, string ToDate)
        {
            List<clsRefundReport_SP> response = new List<clsRefundReport_SP>();
            response = _mediBusiness.GetRefundReport(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("GetCreditNoteReport")]
        public List<resCreditNoteReport> GetCreditNoteReport(string FromDate,string ToDate)
        {
            List<resCreditNoteReport> response = new List<resCreditNoteReport>();
            response = _mediBusiness.GetCreditNoteReport(FromDate, ToDate);
                return response;
        }

        [HttpGet]
        [ActionName("GetCashCollectionreport")]
        public List<resCashCollectionreport> GetCashCollectionreport(string FromDate, string ToDate, int InstutionId)
        {
            List<resCashCollectionreport> response = new List<resCashCollectionreport>();
            response = _mediBusiness.GetCashCollectionreport(FromDate, ToDate, InstutionId);
            return response;
        }
        
        [HttpGet]
        [ActionName("GetRegistrationReport")]
        public List<resRegistrationReport> GetRegistrationReport(string FromDate, string ToDate, int PatientType, int NationalityId, int VisitType)
        {
            List<resRegistrationReport> response = new List<resRegistrationReport>();
            response = _mediBusiness.GetRegistrationReport( FromDate,  ToDate,  PatientType,  NationalityId,  VisitType);
            return response;
        }

        [HttpGet]
        [ActionName("GetInvoice")]
        public List<resInvoice> GetInvoice(string FromDate, string ToDate)
        {
            List<resInvoice> response = new List<resInvoice>();
            response = _mediBusiness.GetInvoice(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Concession_report")]
        public List<resConcession_report> Get_Concession_report(string FromDate, string ToDate, int BillType)
        {
            List<resConcession_report> response = new List<resConcession_report>();
            response = _mediBusiness.Get_Concession_report(FromDate, ToDate, BillType);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Bill_cancellation")]
        public List<resBill_cancellation> Get_Bill_cancellation(string FromDate, string ToDate)
        {
            List<resBill_cancellation> response = new List<resBill_cancellation>();
            response = _mediBusiness.Get_Bill_cancellation(FromDate, ToDate);
            return response;
        }


        [HttpGet]
        [ActionName("GetHealthmedEMR")]
        public List<resHealthEMR> GetHealthEMR (string UHID)
        {
            List<resHealthEMR> response = new List<resHealthEMR>();
            response = _mediBusiness.GetHealthEMR(UHID);
            return response;
        }

        [HttpGet]
        [ActionName("GetVisitnumberEMR")]
        public List<resHealthEMR> GetVisitnumberEMR(string VisitNumber)
        {
            List<resHealthEMR> response = new List<resHealthEMR>();
            response = _mediBusiness.GetVisitnumberEMR(VisitNumber);
            return response;
        }
        [HttpGet]
        [ActionName("GetHMPrescription")]
        public List<resHMPrescription> GetHMPrescription(string VisitNumber)
        {
            List<resHMPrescription> response = new List<resHMPrescription>();
            response = _mediBusiness.GetHMPrescription(VisitNumber);
            return response;
        }


        [HttpPost]
        [ActionName("CitiesbyState")]
        public List<CityDTO> GetCitiesbyState(StateDTO countriesDTO)
        {
            List<CityDTO> countries = new List<CityDTO>();
            countries = _mediBusiness.GetCityDetailsbyState(countriesDTO);
            return countries;
        }

        [HttpGet]
        [ActionName("Get_AvlSlotValidation")]
        public List<Res_AvlSlotValidation> Get_AvlSlotValidation(int DocId, string APPDate, int SlotNo)
        {
            List<Res_AvlSlotValidation> reponse = new List<Res_AvlSlotValidation>();
            reponse = _mediBusiness.Get_AvlSlotValidation(DocId, APPDate, SlotNo);
            return reponse;
        }

        [HttpGet]
        [ActionName("Get_IP_insurance_Patient")]
        public List<Res_insurance_Patient> Get_IP_insurance_Patient()
        {
            List<Res_insurance_Patient> reponse = new List<Res_insurance_Patient>();
            reponse = _mediBusiness.Get_IP_insurance_Patient();
            return reponse;
        }

        //Saranya 05122024
        [HttpGet]
        [ActionName("GetDrConsult")]
        public List<clsOPConsultDrDetail> GetDrConsult(string FromDate, string ToDate, int Patientid)
        {
            List<clsOPConsultDrDetail> response = new List<clsOPConsultDrDetail>();
            response = _mediBusiness.GetDrConsult(FromDate, ToDate, Patientid);
            return response;
        }


        [HttpPost]
        [ActionName("token")]
        public ActionResult GetToken(LoginDTO loginDTO)
        {
            loginDTO = _mediBusiness.CheckLogin(loginDTO);
            if (loginDTO.Response == true)
            {
                //security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                //signing credentials
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                //claims
                var claim = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, loginDTO.UserId)
        };

                // Set the expiration date to September 2, 2029
                var expirationDate = new DateTime(2029, 9, 2);

                //create token
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Site"],
                    audience: _configuration["Jwt:Site"],
                    expires: expirationDate,
                    signingCredentials: signingCredentials,
                    claims: claim
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expirationDate
                });
            }
            else
            {
                return Unauthorized();
            }
         
        }

    }
}
