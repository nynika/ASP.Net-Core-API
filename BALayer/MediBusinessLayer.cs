//using BALayer.BusinessModels;
using BALayer.Repository;
using DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AutoMapper;
using EnitityLayer.BusinessModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Diagnostics.Contracts;
using System.Web.UI;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Owin.BuilderProperties;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace BALayer
{
    public class MediBusinessLayer : IMediBusiness
    {
        private DataLayer dataLayer;
        private readonly HttpClient _httpClient;
        public MediBusinessLayer()
        {

            dataLayer = new DataLayer();

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.Timeout = new TimeSpan(0, 5, 0);
        }

        public resLogin GetLogin(reqLogin request)
        {
            resLogin response = new resLogin();
            DataSet ds = dataLayer.GetLoginData(request);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        
                        response.userCode = DBNull.Value != dr["UserCode"] ? Convert.ToInt32(dr["UserCode"]) : 0;
                        response.userID = DBNull.Value != dr["UserID"] ? Convert.ToString(dr["UserID"]) : "";
                        response.userName = DBNull.Value != dr["UserName"] ? Convert.ToString(dr["UserName"]) : "";
                        response.userImage = DBNull.Value != dr["UserImage"] ? Encoding.ASCII.GetString((byte[])dr["UserImage"]) : "";

                    }
                }
            }

            return response;
        }

        public resUserLogin getUserLogin(reqUserLogin req)
        {
            resUserLogin response = new resUserLogin();
            DataSet ds = dataLayer.getUserLogin(req);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.EmpId = DBNull.Value != dr["EmpId"] ? Convert.ToInt32(dr["EmpId"]) : 0;
                        response.username = DBNull.Value != dr["username"] ? Convert.ToString(dr["username"]) : "";
                        response.Password = DBNull.Value != dr["Password"] ? Convert.ToString(dr["Password"]) : "";

                    }
                }
            }

            return response;
        }


        //public resSavelogin SaveUser_login(reqSaveLogin request)

        //{
        //    resSavelogin response = new resSavelogin();

        //    DataSet ds = dataLayer.SaveUser_login(request);

        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
                        
        //                response.Username = DBNull.Value != dr["Username"] ? Convert.ToString(dr["Username"]) : "";
        //                response.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
        //                response.Date = DBNull.Value != dr["Date"] ? Convert.ToString(dr["Date"]) : "";
        //            }
        //        }
        //    }

        //    return response;
        //}


        public resSavelogin SaveUser_login(reqSaveLogin request)
        {
            resSavelogin response = new resSavelogin();

            DataSet ds = dataLayer.SaveUser_login(request);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    response.Sno = Convert.ToInt32(dr["Sno"]);
                    response.MsgDesc = Convert.ToString(dr["MsgDesc"]);
                }
            }

            return response;
        }


        public respatLogin patLogin(reqpatLogin request)
        {
            respatLogin response = new respatLogin();
            DataSet ds = dataLayer.patLogin(request);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.UserId = DBNull.Value != dr["UserId"] ? Convert.ToString(dr["UserId"]) : "";
                        response.Password = DBNull.Value != dr["Password"] ? Convert.ToString(dr["Password"]) : "";
                        response.UserName = DBNull.Value != dr["UserName"] ? Convert.ToString(dr["UserName"]) : "";
           
                    }
                }
            }

            return response;
        }


        public resHouseKeepingList Get_HouseKeepingList_Save(ReqHouseKeepingList request)

        {
            resHouseKeepingList response = new resHouseKeepingList();

            DataSet ds = dataLayer.Get_HouseKeepingList_Save(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }

        public resHouseKeepingList Get_RestRoomCheckList_Save(ReqRestRoomList request)

        {
            resHouseKeepingList response = new resHouseKeepingList();

            DataSet ds = dataLayer.Get_RestRoomCheckList_Save(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }
        public resHouseKeepingList Get_Patient_Portal(Patient_Portal request)

        {
            resHouseKeepingList response = new resHouseKeepingList();

            DataSet ds = dataLayer.Get_Patient_Portal(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }

      
        public resHouseKeepingList Get_Patient_Portal_MHC(Patient_Portal request)

        {
            resHouseKeepingList response = new resHouseKeepingList();

            DataSet ds = dataLayer.Get_Patient_Portal_MHC(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }

        
        public clsWebMinar SaveAppointmentSlot(ClsSaveAppointmentSlot Request)
        {
            clsWebMinar result = new clsWebMinar();

            DataSet ds = dataLayer.SaveAppointmentSlot(Request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.Result = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }
        public updaterefid Update_RefId(reqclass req)
        {
            updaterefid result = new updaterefid();

            DataSet ds = dataLayer.Update_RefId(req);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        result.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        result.Amount = DBNull.Value != dr["Amount"] ? Convert.ToString(dr["Amount"]) : "";
                        result.MobileNO = DBNull.Value != dr["MobileNO"] ? Convert.ToString(dr["MobileNO"]) : "";
                        result.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                    }
                }
            }

            return result;
        }

        public CovidRegistrationDTO uhidGenerate(long UHID)
        {
            CovidRegistrationDTO appointmentBooking_Resp = new CovidRegistrationDTO();
            DataSet ds = dataLayer.uhidGenerateLayer(UHID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        appointmentBooking_Resp.ResponseCode = Convert.ToString(dr["Sno"]);
                        appointmentBooking_Resp.Response = Convert.ToString(dr["MsgDescp"]);
                        appointmentBooking_Resp.RegistrationRefNo = Convert.ToString(dr["ReferenceNumber"]);
                        appointmentBooking_Resp.MobileNo = Convert.ToString(dr["MobileNo"]);
                        appointmentBooking_Resp.EmailId = Convert.ToString(dr["Emailid"]);
                    }
                }
            }
            return appointmentBooking_Resp;
        }
       // Jeyaganesh 23.07.2021

   
        public resHouseKeepingList OT_LIST_SAVE(req_OtClass req)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.OT_LIST_SAVE(req);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
                        result.MsgDesc = DBNull.Value != dr["Result"] ? Convert.ToString(dr["Result"]) : "";
           
                    }
                }
            }

            return result;
        }


        public List<OtClass> Get_OTLits()
        {
            List<OtClass> result = new List<OtClass>();

            DataSet ds = dataLayer.Get_OTLits();

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        OtClass otItem = new OtClass();

                        otItem.SNo = DBNull.Value != dr["SNo"] ? Convert.ToString(dr["SNo"]) : "";
                        otItem.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        otItem.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        otItem.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        otItem.ScheduleTime = DBNull.Value != dr["ScheduleTime"] ? Convert.ToString(dr["ScheduleTime"]) : "";
                        otItem.TheaterName = DBNull.Value != dr["TheaterName"] ? Convert.ToString(dr["TheaterName"]) : "";
                        otItem.StartTime = DBNull.Value != dr["StartTime"] ? Convert.ToString(dr["StartTime"]) : "";
                        otItem.EndTime = DBNull.Value != dr["EndTime"] ? Convert.ToString(dr["EndTime"]) : "";                 
                        otItem.ProcedureName = DBNull.Value != dr["ProcedureName"] ? Convert.ToString(dr["ProcedureName"]) : "";
                        otItem.SurgeonName = DBNull.Value != dr["Surgeon_Name"] ? Convert.ToString(dr["Surgeon_Name"]) : "";
                        otItem.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";
                        otItem.Ward = DBNull.Value != dr["Ward"] ? Convert.ToString(dr["Ward"]) : "";
                     

                        result.Add(otItem);
                    }
                }
            }

            return result;
        }



        public clsWebMinar Doc_Dir_IMG_View(docDir_imgView req)
        {
            clsWebMinar result = new clsWebMinar();

            DataSet ds = dataLayer.doc_dir_img_view(req);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
                        result.Result = DBNull.Value != dr["msgdesc"] ? Convert.ToString(dr["msgdesc"]) : "";

                    }
                }
            }

            return result;
        }

        public clsWebMinar Doc_Dir_IMG_import(docDir_img_imp req)
        {
            clsWebMinar result = new clsWebMinar();

            DataSet ds = dataLayer.Doc_Dir_IMG_import(req);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
                        result.Result = DBNull.Value != dr["Result"] ? Convert.ToString(dr["Result"]) : "";

                    }
                }
            }

            return result;
        }

        public resSavelogin save_signimg(signimgreq req)
        {
            resSavelogin result = new resSavelogin();

            DataSet ds = dataLayer.save_signimg(req);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        result.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";

                    }
                }
            }

            return result;
        }



        public List<signimgreq> signimage()
        {
            List<signimgreq> res = new List<signimgreq>();
            DataSet ds = dataLayer.signimage();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        signimgreq result = new signimgreq();

                        result.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        result.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        result.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        result.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        result.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        result.img = DBNull.Value != dr["img"] ? Convert.ToString(dr["img"]) : "";


                        res.Add(result);

                    }
                }
            }
            return res;
        }

        public clsWebMinar Doc_Dir_IMG_export(docDir_img_exp req)
        {
            clsWebMinar result = new clsWebMinar();

            DataSet ds = dataLayer.Doc_Dir_IMG_export(req);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
                        result.Result = DBNull.Value != dr["msgdesc"] ? Convert.ToString(dr["msgdesc"]) : "";

                    }
                }
            }

            return result;
        }

        //public clswebminar insert_docdir_new(doctordirectory_new req)
        //{
        //    clswebminar result = new clswebminar();

        //    dataset ds = datalayer.insert_docdir_new(req);

        //    if (ds != null)
        //    {
        //        if (ds.tables.count > 0 && ds.tables[0] != null && ds.tables[0].rows != null)
        //        {
        //            foreach (datarow dr in ds.tables[0].rows)
        //            {
        //                result.sno = dbnull.value != dr["sno"] ? convert.toint32(dr["sno"]) : 0;
        //                result.result = dbnull.value != dr["msgdesc"] ? convert.tostring(dr["msgdesc"]) : "";

        //            }
        //        }
        //    }

        //    return result;
        //}
        //public clswebminar update_docdir_dtl(doctordirectory req)
        //{
        //    clswebminar result = new clswebminar();

        //    dataset ds = datalayer.update_docdir_dtl(req);

        //    if (ds != null)
        //    {
        //        if (ds.tables.count > 0 && ds.tables[0] != null && ds.tables[0].rows != null)
        //        {
        //            foreach (datarow dr in ds.tables[0].rows)
        //            {
        //                result.sno = dbnull.value != dr["sno"] ? convert.toint32(dr["sno"]) : 0;
        //                result.result = dbnull.value != dr["msgdesc"] ? convert.tostring(dr["msgdesc"]) : "";

        //            }
        //        }
        //    }

        //    return result;
        //}
        //public clswebminar delete_docdir_dtl(int sno)
        //{
        //    clswebminar result = new clswebminar();

        //    dataset ds = datalayer.delete_docdir_dtl(sno);

        //    if (ds != null)
        //    {
        //        if (ds.tables.count > 0 && ds.tables[0] != null && ds.tables[0].rows != null)
        //        {
        //            foreach (datarow dr in ds.tables[0].rows)
        //            {
        //                result.sno = dbnull.value != dr["sno"] ? convert.toint32(dr["sno"]) : 0;
        //                result.result = dbnull.value != dr["msgdesc"] ? convert.tostring(dr["msgdesc"]) : "";

        //            }
        //        }
        //    }

        //    return result;
        //}


        //public clsWebMinar Get_PaymentGetWay(PaymentGateWay req)
        //{
        //    clsWebMinar result = new clsWebMinar();

        //    DataSet ds = dataLayer.Get_PaymentGetWay(req);

        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                result.Sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
        //                result.Result = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";

        //            }
        //        }
        //    }

        //    return result;
        //}
        //public List<OtClass> Get_OTLits()
        //{
        //    List<OtClass> iDTypeDTOs = new List<OtClass>();
        //    DataSet ds = dataLayer.Get_OTLits();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                OtClass OT = new OtClass();

        //                OT.SNo = DBNull.Value != dr["SNo"] ? Convert.ToString(dr["SNo"]) : "";
        //                OT.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
        //                OT.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
        //                OT.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
        //                OT.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) :"";
        //                OT.ScheduleTime = DBNull.Value != dr["ScheduleTime"] ? Convert.ToString(dr["ScheduleTime"]) : "";
        //                OT.TheaterName = DBNull.Value != dr["TheaterName"] ? Convert.ToString(dr["TheaterName"]) : "";
        //                OT.StartTime = DBNull.Value != dr["StartTime"] ? Convert.ToString(dr["StartTime"]) : "";
        //                OT.EndTime = DBNull.Value != dr["EndTime"] ? Convert.ToString(dr["EndTime"]) : "";
        //                OT.ProcedureName = DBNull.Value != dr["ProcedureName"] ? Convert.ToString(dr["ProcedureName"]) : "";
        //                OT.SurgeonName = DBNull.Value != dr["Surgeon_Name"] ? Convert.ToString(dr["Surgeon_Name"]) : "";
        //                OT.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";
        //                OT.Ward = DBNull.Value != dr["Ward"] ? Convert.ToString(dr["Ward"]) : "";

        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public List<LicenseModel> Get_License_dtl()
        //{
        //    List<LicenseModel> iDTypeDTOs = new List<LicenseModel>();
        //    DataSet ds = dataLayer.get_LicenseModel();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                LicenseModel OT = new LicenseModel();

        //                OT.sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
        //                OT.LicenceName = DBNull.Value != dr["LicenceName"] ? Convert.ToString(dr["LicenceName"]) : "";
        //                OT.Department = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
        //                OT.StartDate = DBNull.Value != dr["StartDate"] ? Convert.ToString(dr["StartDate"]) : "";
        //                OT.EndDate = DBNull.Value != dr["EndDate"] ? Convert.ToString(dr["EndDate"]) : "";
        //                OT.AlertDays = DBNull.Value != dr["AlertDays"] ? Convert.ToString(dr["AlertDays"]) : "";
        //                OT.AlertDate = DBNull.Value != dr["AlertDate"] ? Convert.ToString(dr["AlertDate"]) : "";
        //                OT.LicenceNo = DBNull.Value != dr["LicenseNo"] ? Convert.ToString(dr["LicenseNo"]) : "";
        //                OT.LicencePath = DBNull.Value != dr["LicensePath"] ? Convert.ToString(dr["LicensePath"]) : "";
        //                OT.RegisterBy = DBNull.Value != dr["RegisterBy"] ? Convert.ToString(dr["RegisterBy"]) : "";
        //                OT.RegisterDate = DBNull.Value != dr["RegisterDate"] ? Convert.ToString(dr["RegisterDate"]) : "";
        //                OT.LastModifiedBy = DBNull.Value != dr["LastModifiedBy"] ? Convert.ToString(dr["LastModifiedBy"]) : "";
        //                OT.LastModifiedDate = DBNull.Value != dr["LastModifiedDate"] ? Convert.ToString(dr["LastModifiedDate"]) : "";
        //                OT.LastModifiedDate = DBNull.Value != dr["LastModifiedDate"] ? Convert.ToString(dr["LastModifiedDate"]) : "";
        //                OT.LastModifiedRemarks = DBNull.Value != dr["LastModifiedRemarks"] ? Convert.ToString(dr["LastModifiedRemarks"]) : "";
        //                OT.IssuingAuthority = DBNull.Value != dr["IssuingAuthority"] ? Convert.ToString(dr["IssuingAuthority"]) : "";
        //                OT.DueDate = DBNull.Value != dr["Duedate"] ? Convert.ToInt32(dr["Duedate"]) : 0;
        //                OT.Category = DBNull.Value != dr["Category"] ? Convert.ToString(dr["Category"]) : "";
        //                //OT.sendport = DBNull.Value != dr["sendport"] ? Convert.ToBoolean(dr["sendport"]) : false;
        //                //OT.isActive = DBNull.Value != dr["isActive"] ? Convert.ToBoolean(dr["isActive"]) : false;
        //                OT.TimeCounter = DBNull.Value != dr["TimeCounter"] ? Convert.ToString(dr["TimeCounter"]) : "";


        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public List<appsolt> Get_Appsolt_dtl()
        //{
        //    List<appsolt> iDTypeDTOs = new List<appsolt>();

        //    List<Dropdown1> res2 = new List<Dropdown1>();

        //    DataSet ds = dataLayer.Get_Appsolt_dtl();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {


        //            DataTable dt = new DataTable();
        //            dt = ds.Tables["Table"].DefaultView.ToTable(true, "Department", "DoctorName", "Qualification");

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {

        //                res2 = new List<Dropdown1>();

        //                appsolt OT = new appsolt();
        //                OT.Department = DBNull.Value != dt.Rows[i]["Department"] ? Convert.ToString(dt.Rows[i]["Department"]) : "";
        //                OT.DoctorName = DBNull.Value != dt.Rows[i]["DoctorName"] ? Convert.ToString(dt.Rows[i]["DoctorName"]) : "";
        //                OT.Qualification = DBNull.Value != dt.Rows[i]["Qualification"] ? Convert.ToString(dt.Rows[i]["Qualification"]) : "";


        //                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        //                {
        //                    //string ds1 = ds.Tables[0].Rows[j]["DoctorName"].ToString();
        //                    //string ds2 = dt.Rows[i]["DoctorName"].ToString();
        //                    if (ds.Tables[0].Rows[j]["DoctorName"].ToString() == dt.Rows[i]["DoctorName"].ToString())
        //                    {

        //                        Dropdown1 dd2 = new Dropdown1();
        //                        dd2.Patient_UHID = DBNull.Value != ds.Tables[0].Rows[j]["Patient_UHID"] ? Convert.ToString(ds.Tables[0].Rows[j]["Patient_UHID"]) : "";
        //                        dd2.Token_No = DBNull.Value != ds.Tables[0].Rows[j]["Token_No"] ? Convert.ToString(ds.Tables[0].Rows[j]["Token_No"]) : "";
        //                        dd2.Status = DBNull.Value != ds.Tables[0].Rows[j]["Status"] ? Convert.ToString(ds.Tables[0].Rows[j]["Status"]) : "";
        //                        OT.patient = res2;
        //                        res2.Add(dd2);

        //                    }
        //                }

        //                iDTypeDTOs.Add(OT);
        //            }

        //        }
        //    }

        //    return iDTypeDTOs;
        //}

        public clsWebMinar OT_Excel(Otexcel_req request)
        {
            clsWebMinar result = new clsWebMinar();
            DataSet ds = dataLayer.OT_Excel(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["sno"]) : 0;
                result.Result = DBNull.Value != ds.Tables[0].Rows[0]["msgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["msgDesc"]) : "";

            }

            return result;
        }
        //public List<DoctorDirectory> Get_DoctorDirectory_dtl()
        //{
        //    List<DoctorDirectory> iDTypeDTOs = new List<DoctorDirectory>();
        //    DataSet ds = dataLayer.Get_DoctorDirectory_dtl();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                DoctorDirectory OT = new DoctorDirectory();


        //                OT.SNo = DBNull.Value != dr["SNo"] ? Convert.ToInt32(dr["SNo"]) : 0;
        //                OT.Name = DBNull.Value != dr["Name"] ? Convert.ToString(dr["Name"]) : "";
        //                OT.Department = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
        //                OT.Sub_Department = DBNull.Value != dr["Sub_Department"] ? Convert.ToString(dr["Sub_Department"]) : "";
        //                OT.slide_no = DBNull.Value != dr["slide_no"] ? Convert.ToInt32(dr["slide_no"]) : 0;
        //                OT.Tv_no = DBNull.Value != dr["Tv_no"] ? Convert.ToInt32(dr["Tv_no"]) : 0;
        //                OT.Qualification = DBNull.Value != dr["Qualification"] ? Convert.ToString(dr["Qualification"]) : "";
        //                OT.Designation = DBNull.Value != dr["Designation"] ? Convert.ToString(dr["Designation"]) : "";
        //                OT.Sequence = DBNull.Value != dr["Sequence"] ? Convert.ToInt32(dr["Sequence"]) : 0;
        //                OT.profile_image = DBNull.Value != dr["profile image"] ? Convert.ToString(dr["profile image"]) : "";
        //                OT.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public TicketingSystem Get_TicketingCount_dtl(string Fromdate, string Todate)
        //{
        //    TicketingSystem result = new TicketingSystem();

        //    DataSet ds = dataLayer.Get_TicketingCount_dtl(Fromdate, Todate);

        //    if (ds != null)
        //    {
        //        result.Total = DBNull.Value != ds.Tables[0].Rows[0]["Total"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Total"]) : 0;
        //        result.New = DBNull.Value != ds.Tables[0].Rows[0]["New"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["New"]) : 0;
        //        result.Acknowledged = DBNull.Value != ds.Tables[0].Rows[0]["Acknowledged"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Acknowledged"]) : 0;
        //        result.Closed = DBNull.Value != ds.Tables[0].Rows[0]["Closed"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Closed"]) : 0;
        //    }

        //    return result;
        //}
        //public List<DepWiseTicketingSystem> Get_TicketingDepCount_dtl(string Fromdate, string Todate)
        //{
        //    List<DepWiseTicketingSystem> iDTypeDTOs = new List<DepWiseTicketingSystem>();
        //    DataSet ds = dataLayer.Get_TicketingDepCount_dtl(Fromdate, Todate);
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                DepWiseTicketingSystem OT = new DepWiseTicketingSystem();

        //                OT.Department = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
        //                OT.Total = DBNull.Value != dr["Total"] ? Convert.ToInt32(dr["Total"]) : 0;
        //                OT.New = DBNull.Value != dr["New"] ? Convert.ToInt32(dr["New"]) : 0;
        //                OT.Acknowledged = DBNull.Value != dr["Acknowledged"] ? Convert.ToInt32(dr["Acknowledged"]) : 0;
        //                OT.Closed = DBNull.Value != dr["Closed"] ? Convert.ToInt32(dr["Closed"]) : 0;

        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public DoctorDirectory Get_DocDirectoru_Editdtl(int SNo)
        //{
        //    DoctorDirectory result = new DoctorDirectory();

        //    DataSet ds = dataLayer.Get_DocDirectoru_Editdtl(SNo);

        //    if (ds != null)
        //    {
        //        result.SNo = DBNull.Value != ds.Tables[0].Rows[0]["SNo"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["SNo"]) : 0;
        //        result.Name = DBNull.Value != ds.Tables[0].Rows[0]["Name"] ? Convert.ToString(ds.Tables[0].Rows[0]["Name"]) : "";
        //        result.Department = DBNull.Value != ds.Tables[0].Rows[0]["Department"] ? Convert.ToString(ds.Tables[0].Rows[0]["Department"]) : "";
        //        result.Sub_Department = DBNull.Value != ds.Tables[0].Rows[0]["Sub_Department"] ? Convert.ToString(ds.Tables[0].Rows[0]["Sub_Department"]) : "";
        //        result.slide_no = DBNull.Value != ds.Tables[0].Rows[0]["slide_no"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["slide_no"]) : 0;
        //        result.Tv_no = DBNull.Value != ds.Tables[0].Rows[0]["Tv_no"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Tv_no"]) : 0;
        //        result.Qualification = DBNull.Value != ds.Tables[0].Rows[0]["Qualification"] ? Convert.ToString(ds.Tables[0].Rows[0]["Qualification"]) : "";
        //        result.Designation = DBNull.Value != ds.Tables[0].Rows[0]["Designation"] ? Convert.ToString(ds.Tables[0].Rows[0]["Designation"]) : "";
        //        result.Sequence = DBNull.Value != ds.Tables[0].Rows[0]["Sequence"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sequence"]) : 0;
        //        result.profile_image = DBNull.Value != ds.Tables[0].Rows[0]["profile_image"] ? Convert.ToString(ds.Tables[0].Rows[0]["profile_image"]) : "";
        //        result.Status = DBNull.Value != ds.Tables[0].Rows[0]["Status"] ? Convert.ToString(ds.Tables[0].Rows[0]["Status"]) : "";
        //    }

        //    return result;
        //}
        //public clsWebMinar DoctoryDiectory_Img(DocDirImg_req request)
        //{
        //    clsWebMinar result = new clsWebMinar();



        //    DataSet ds = dataLayer.DoctoryDiectory_Img(request);

        //    if (ds != null)
        //    {
        //        result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["sno"]) : 0;
        //        result.Result = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";


        //    }

        //    return result;
        //}
        //public List<DocDirImg_List> Get_DocDir_Img_List()
        //{
        //    List<DocDirImg_List> iDTypeDTOs = new List<DocDirImg_List>();
        //    DataSet ds = dataLayer.Get_DocDir_Img_List();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                DocDirImg_List OT = new DocDirImg_List();

        //                OT.SNo = DBNull.Value != dr["SNo"] ? Convert.ToInt32(dr["SNo"]) : 0;
        //                OT.Image = DBNull.Value != dr["Image"] ? Convert.ToString(dr["Image"]) : "";


        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public List<docDir_imgView_List> Get_DocDir_Img_View_List()
        //{
        //    List<docDir_imgView_List> iDTypeDTOs = new List<docDir_imgView_List>();
        //    DataSet ds = dataLayer.Get_DocDir_Img_View_List();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                docDir_imgView_List OT = new docDir_imgView_List();

        //                OT.SNo = DBNull.Value != dr["SNo"] ? Convert.ToInt32(dr["SNo"]) : 0;
        //                OT.One = DBNull.Value != dr["One"] ? Convert.ToString(dr["One"]) : "";
        //                OT.Two = DBNull.Value != dr["TwO"] ? Convert.ToString(dr["TwO"]) : "";
        //                OT.Three = DBNull.Value != dr["Three"] ? Convert.ToString(dr["Three"]) : "";
        //                OT.Four = DBNull.Value != dr["Four"] ? Convert.ToString(dr["Four"]) : "";
        //                OT.Five = DBNull.Value != dr["Five"] ? Convert.ToString(dr["Five"]) : "";
        //                OT.Six = DBNull.Value != dr["Six"] ? Convert.ToString(dr["Six"]) : "";
        //                OT.Seven = DBNull.Value != dr["Seven"] ? Convert.ToString(dr["Seven"]) : "";
        //                OT.Eight = DBNull.Value != dr["Eight"] ? Convert.ToString(dr["Eight"]) : "";
        //                OT.Nine = DBNull.Value != dr["Nine"] ? Convert.ToString(dr["Nine"]) : "";
        //                OT.Ten = DBNull.Value != dr["Ten"] ? Convert.ToString(dr["Ten"]) : "";
        //                OT.Eleven = DBNull.Value != dr["Eleven"] ? Convert.ToString(dr["Eleven"]) : "";
        //                OT.Tweleve = DBNull.Value != dr["Tweleve"] ? Convert.ToString(dr["Tweleve"]) : "";
        //                OT.Thirteen = DBNull.Value != dr["Thirteen"] ? Convert.ToString(dr["Thirteen"]) : "";
        //                OT.Fourteen = DBNull.Value != dr["Fourteen"] ? Convert.ToString(dr["Fourteen"]) : "";

        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public List<Get_PaymentGetWay_List> Get_PaymentGetWay_List(string frdate,string todate)
        //{
        //    List<Get_PaymentGetWay_List> iDTypeDTOs = new List<Get_PaymentGetWay_List>();
        //    DataSet ds = dataLayer.Get_PaymentGetWay_List(frdate, todate);
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                Get_PaymentGetWay_List OT = new Get_PaymentGetWay_List();

        //                OT.FirstName = DBNull.Value != dr["FirstName"] ? Convert.ToString(dr["FirstName"]) : "";
        //                OT.LastName = DBNull.Value != dr["LastName"] ? Convert.ToString(dr["LastName"]) : "";
        //                OT.Dob = DBNull.Value != dr["Dob"] ? Convert.ToString(dr["Dob"]) : "";
        //                OT.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
        //                OT.Org_InsName = DBNull.Value != dr["Org_InsName"] ? Convert.ToString(dr["Org_InsName"]) : "";
        //                OT.Profession = DBNull.Value != dr["Profession"] ? Convert.ToString(dr["Profession"]) : "";
        //                OT.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
        //                OT.EmailId = DBNull.Value != dr["EmailId"] ? Convert.ToString(dr["EmailId"]) : "";

        //                iDTypeDTOs.Add(OT);
        //            }
        //        }
        //    }

        //    return iDTypeDTOs;
        //}
        //public List<Get_PaymentGetWay_Listdemo> Get_PaymentGetWay_Listdemo(string frdate, string todate)
        //{
        //    List<Get_PaymentGetWay_Listdemo> payment = new List<Get_PaymentGetWay_Listdemo>();
        //    DataSet ds = dataLayer.Get_PaymentGetWay_Listdemo(frdate, todate);
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                Get_PaymentGetWay_Listdemo OT = new Get_PaymentGetWay_Listdemo();

        //                OT.FirstName = DBNull.Value != dr["FirstName"] ? Convert.ToString(dr["FirstName"]) : "";
        //                OT.LastName = DBNull.Value != dr["LastName"] ? Convert.ToString(dr["LastName"]) : "";


        //                payment.Add(OT);
        //            }
        //        }
        //    }

        //    return payment;
        //}
        public BB_BloodGroup_res BB_BloodGroup(BB_BloodGroup_req request)
        {
            BB_BloodGroup_res result = new BB_BloodGroup_res();
            DataSet ds = dataLayer.BB_BloodGroup(request);

            if (ds != null)
            {
                result.Success = DBNull.Value != ds.Tables[0].Rows[0]["Success"] ? Convert.ToString(ds.Tables[0].Rows[0]["Success"]) : "";
                result.Message = DBNull.Value != ds.Tables[0].Rows[0]["Message"] ? Convert.ToString(ds.Tables[0].Rows[0]["Message"]) : "";
            }

            return result;
        }

        public clsFinancialResult FinancialCounsellingSave(FinancialCounselling_req request)
        {
            clsFinancialResult result = new clsFinancialResult();
            DataSet ds = dataLayer.FinancialCounsellingSave(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDescp = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }

        public List<clsAppAvailableSlotTimeDtl> AppAvailableSlotTimeDtl(string APPDate, int ConsId, int Slottype)
        {
            List<clsAppAvailableSlotTimeDtl> table = new List<clsAppAvailableSlotTimeDtl>();
            try
            {
                DataSet ds = dataLayer.AppAvailableSlotTimeDtl(APPDate, ConsId, Slottype);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsAppAvailableSlotTimeDtl res = new clsAppAvailableSlotTimeDtl();


                            res.StartDateTime = DBNull.Value != dr["StartDateTime"] ? Convert.ToString(dr["StartDateTime"]) : "";
                            res.EndDateTime = DBNull.Value != dr["EndDateTime"] ? Convert.ToString(dr["EndDateTime"]) : "";
                          

                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }



        //public List<clsCUG> GetCombinedData_v1(string DtlType)
        //{
        //    List<clsCUG> resultList = new List<clsCUG>();
        //    List<clsEXTEN> resultList1 = new List<clsEXTEN>();
        //    List<clsLanguage_Assis> resultList2 = new List<clsLanguage_Assis>();
        //    List<clsSpeeddialNos> resultList3 = new List<clsSpeeddialNos>();


        //    DataSet ds = dataLayer.GetCombinedData_v1(DtlType);

        //    if (DtlType == "CUG")
        //    {
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                clsCUG req = new clsCUG();

        //                req.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
        //                req.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req.MobileNos = dr["MobileNos"] != DBNull.Value ? Convert.ToString(dr["MobileNos"]) : "";
        //                req.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList.Add(req);
        //            }

        //        }

        //    }

        //    else if (DtlType == "Exten")
        //    {
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                clsEXTEN req1 = new clsEXTEN();

        //                req1.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req1.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
        //                req1.Floor = dr["Floor"] != DBNull.Value ? Convert.ToString(dr["Floor"]) : "";
        //                req1.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req1.ExtnNos = dr["ExtnNos"] != DBNull.Value ? Convert.ToInt32(dr["ExtnNos"]) : 0;
        //                req1.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;
        //                resultList1.Add(req1);
        //            }
        //        }
        //    }

        //    else if (DtlType == "Language_Assis")
        //    {

        //      if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                clsLanguage_Assis req2 = new clsLanguage_Assis();

        //                req2.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req2.EmpName = dr["EmpName"] != DBNull.Value ? Convert.ToString(dr["EmpName"]) : "";
        //                req2.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req2.Language = dr["Language"] != DBNull.Value ? Convert.ToString(dr["Language"]) : "";
        //                req2.ContactNo = dr["ContactNo"] != DBNull.Value ? Convert.ToString(dr["ContactNo"]) : "";
        //                req2.Availability = dr["Availability"] != DBNull.Value ? Convert.ToString(dr["Availability"]) : "";
        //                req2.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList2.Add(req2);
        //            }
        //        }

        //    }

        //    else if (DtlType == "SpeeddialNos")
        //    {
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                clsSpeeddialNos req3 = new clsSpeeddialNos();

        //                req3.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req3.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
        //                req3.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req3.SpeeddialNos = dr["SpeeddialNos"] != DBNull.Value ? Convert.ToString(dr["SpeeddialNos"]) : "";
        //                req3.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList3.Add(req3);
        //            }
        //        }
        //    }

        //    return resultList;
        //}

        //public List<object> GetCombinedData_v1(string DtlType)
        //{
        //    List<object> resultList = new List<object>();

        //    DataSet ds = dataLayer.GetCombinedData_v1(DtlType);

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            if (DtlType == "CUG")
        //            {
        //                clsCUG req = new clsCUG();

        //                req.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
        //                req.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req.MobileNos = dr["MobileNos"] != DBNull.Value ? Convert.ToString(dr["MobileNos"]) : "";
        //                req.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList.Add(req);
        //            }
        //            else if (DtlType == "Exten")
        //            {
        //                clsEXTEN req1 = new clsEXTEN();

        //                req1.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req1.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
        //                req1.Floor = dr["Floor"] != DBNull.Value ? Convert.ToString(dr["Floor"]) : "";
        //                req1.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req1.ExtnNos = dr["ExtnNos"] != DBNull.Value ? Convert.ToInt32(dr["ExtnNos"]) : 0;
        //                req1.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList.Add(req1);
        //            }
        //            else if (DtlType == "Language_Assis")
        //            {
        //                clsLanguage_Assis req2 = new clsLanguage_Assis();

        //                req2.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req2.EmpName = dr["EmpName"] != DBNull.Value ? Convert.ToString(dr["EmpName"]) : "";
        //                req2.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req2.Language = dr["Language"] != DBNull.Value ? Convert.ToString(dr["Language"]) : "";
        //                req2.ContactNo = dr["ContactNo"] != DBNull.Value ? Convert.ToString(dr["ContactNo"]) : "";
        //                req2.Availability = dr["Availability"] != DBNull.Value ? Convert.ToString(dr["Availability"]) : "";
        //                req2.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList.Add(req2);
        //            }
        //            else if (DtlType == "SpeeddialNos")
        //            {
        //                clsSpeeddialNos req3 = new clsSpeeddialNos();

        //                req3.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
        //                req3.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
        //                req3.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
        //                req3.SpeeddialNos = dr["SpeeddialNos"] != DBNull.Value ? Convert.ToString(dr["SpeeddialNos"]) : "";
        //                req3.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

        //                resultList.Add(req3);
        //            }
        //        }
        //    }

        //    return resultList;
        //}



        public List<clsGetCombinedData> GetCombinedData(string DtlType)
        {
            List<clsGetCombinedData> reqList = new List<clsGetCombinedData>();

            DataSet ds = dataLayer.GetCombinedData(DtlType);

            if (DtlType == "CUG")
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsGetCombinedData req = new clsGetCombinedData();

                        req.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        req.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
                        req.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
                        req.MobileNos = dr["MobileNos"] != DBNull.Value ? Convert.ToString(dr["MobileNos"]) : "";
                        req.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

                        reqList.Add(req);
                    }
                }
            }
            else if (DtlType == "Exten")
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsGetCombinedData req1 = new clsGetCombinedData();

                        req1.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        req1.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
                        req1.Floor = dr["Floor"] != DBNull.Value ? Convert.ToString(dr["Floor"]) : "";
                        req1.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
                        req1.ExtnNos = dr["ExtnNos"] != DBNull.Value ? Convert.ToInt32(dr["ExtnNos"]) : 0;
                        req1.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

                        reqList.Add(req1);
                    }
                }

            }

            else if (DtlType == "Language_Assis")
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsGetCombinedData req2 = new clsGetCombinedData();

                        req2.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        req2.EmpName = dr["EmpName"] != DBNull.Value ? Convert.ToString(dr["EmpName"]) : "";
                        req2.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
                        req2.Language = dr["Language"] != DBNull.Value ? Convert.ToString(dr["Language"]) : "";
                        req2.ContactNo = dr["ContactNo"] != DBNull.Value ? Convert.ToString(dr["ContactNo"]) : "";
                        req2.Availability = dr["Availability"] != DBNull.Value ? Convert.ToString(dr["Availability"]) : "";
                        req2.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

                        reqList.Add(req2);
                    }
                }

            }


            else if (DtlType == "SpeeddialNos")
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsGetCombinedData req3 = new clsGetCombinedData();

                        req3.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        req3.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
                        req3.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
                        req3.SpeeddialNos = dr["SpeeddialNos"] != DBNull.Value ? Convert.ToString(dr["SpeeddialNos"]) : "";
                        req3.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

                        reqList.Add(req3);
                    }
                }

            }


            else if (DtlType == "HelplineNos")
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsGetCombinedData req4 = new clsGetCombinedData();

                        req4.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        req4.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
                        req4.mobileno = dr["mobileno"] != DBNull.Value ? Convert.ToString(dr["mobileno"]) : "";
                        req4.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

                        reqList.Add(req4);
                    }
                }

            }


            else if (DtlType == "Doctornos")
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsGetCombinedData req5 = new clsGetCombinedData();

                        req5.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        req5.DoctorName = dr["DoctorName"] != DBNull.Value ? Convert.ToString(dr["DoctorName"]) : "";
                        req5.Department = dr["Department"] != DBNull.Value ? Convert.ToString(dr["Department"]) : "";
                        req5.email = dr["email"] != DBNull.Value ? Convert.ToString(dr["email"]) : "";
                        req5.mobileno = dr["mobileno"] != DBNull.Value ? Convert.ToString(dr["mobileno"]) : "";
                        req5.blocked = dr["blocked"] != DBNull.Value ? Convert.ToInt32(dr["blocked"]) : 0;

                        reqList.Add(req5);
                    }
                }

            }

            // Return an empty list if DtlType is neither "CUG" nor "Exten"
            return reqList;
        }


        public opd_master_Res Insert_OPDMaster_Porc(OPD_MasterProc_req request)
        {
            opd_master_Res result = new opd_master_Res();
            DataSet ds = dataLayer.Insert_OPDMaster_Porc(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDescp = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";
                result.ReferenceNumber = DBNull.Value != ds.Tables[0].Rows[0]["ReferenceNumber"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["ReferenceNumber"]) : 0;
                result.VisitId = DBNull.Value != ds.Tables[0].Rows[0]["VisitId"] ? Convert.ToString(ds.Tables[0].Rows[0]["VisitId"]) : "";
                result.SurrogatedID = DBNull.Value != ds.Tables[0].Rows[0]["SurrogatedID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["SurrogatedID"]) : 0;
                result.Mobileno = DBNull.Value != ds.Tables[0].Rows[0]["Mobileno"] ? Convert.ToString(ds.Tables[0].Rows[0]["Mobileno"]) : "";
                result.Emailid = DBNull.Value != ds.Tables[0].Rows[0]["Emailid"] ? Convert.ToString(ds.Tables[0].Rows[0]["Emailid"]) : "";
                result.age = DBNull.Value != ds.Tables[0].Rows[0]["age"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["age"]) : 0;
                result.appId = DBNull.Value != ds.Tables[0].Rows[0]["appId"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["appId"]) : 0;
                result.docid = DBNull.Value != ds.Tables[0].Rows[0]["docid"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["docid"]) : 0;
            }

            return result;
        }

        public List<resHealthEMR> GetHealthEMR(string UHID)
        {
            List<resHealthEMR> salutations = new List<resHealthEMR>();
            DataSet ds = dataLayer.GetHealthEMR(UHID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resHealthEMR po = new resHealthEMR();

                        po.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToInt64(dr["PatientId"]) : 0;
                        po.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        po.Patient = DBNull.Value != dr["Patient"] ? Convert.ToString(dr["Patient"]) : "";
                        po.EncounterId = DBNull.Value != dr["EncounterId"] ? Convert.ToInt64(dr["EncounterId"]) : 0;
                        po.VisitNumber = DBNull.Value != dr["VisitNumber"] ? Convert.ToString(dr["VisitNumber"]) : "";
                        po.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                        po.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        po.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                        po.Vitals = DBNull.Value != dr["Vitals"] ? Convert.ToString(dr["Vitals"]) : "";
                        po.Parameter = DBNull.Value != dr["Parameter"] ? Convert.ToString(dr["Parameter"]) : "";
                        po.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        po.Value = DBNull.Value != dr["Value"] ? Convert.ToString(dr["Value"]) : "";
                        salutations.Add(po);
                    }
                }
            }

            return salutations;

        }

        public List<resHealthEMR> GetVisitnumberEMR(string VisitNumber)
        {
            List<resHealthEMR> salutations = new List<resHealthEMR>();
            DataSet ds = dataLayer.GetVisitnumberEMR(VisitNumber);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resHealthEMR po = new resHealthEMR();

                        po.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToInt64(dr["PatientId"]) : 0;
                        po.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        po.Patient = DBNull.Value != dr["Patient"] ? Convert.ToString(dr["Patient"]) : "";
                        po.EncounterId = DBNull.Value != dr["EncounterId"] ? Convert.ToInt64(dr["EncounterId"]) : 0;
                        po.VisitNumber = DBNull.Value != dr["VisitNumber"] ? Convert.ToString(dr["VisitNumber"]) : "";
                        po.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                        po.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        po.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                        po.Vitals = DBNull.Value != dr["Vitals"] ? Convert.ToString(dr["Vitals"]) : "";
                        po.Parameter = DBNull.Value != dr["Parameter"] ? Convert.ToString(dr["Parameter"]) : "";
                        po.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        po.Value = DBNull.Value != dr["Value"] ? Convert.ToString(dr["Value"]) : "";
                        salutations.Add(po);
                    }
                }
            }

            return salutations;

        }
        public List<resHMPrescription> GetHMPrescription(string VisitNumber)
        {
            List<resHMPrescription> salutations = new List<resHMPrescription>();
            DataSet ds = dataLayer.GetHMPrescription(VisitNumber);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resHMPrescription po = new resHMPrescription();

                        po.Pres_PrescriptionId_Id = DBNull.Value != dr["Pres_PrescriptionId_Id"] ? Convert.ToString(dr["Pres_PrescriptionId_Id"]) : "";
                        po.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToString(dr["PatientId"]) : "";
                        po.VisitId = DBNull.Value != dr["VisitId"] ? Convert.ToString(dr["VisitId"]) : "";
                        po.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                        po.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        po.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                        po.ServiceNumber = DBNull.Value != dr["ServiceNumber"] ? Convert.ToString(dr["ServiceNumber"]) : "";
                        po.prescriptionId = DBNull.Value != dr["prescriptionId"] ? Convert.ToString(dr["prescriptionId"]) : "";
                        po.DrugSHCode = DBNull.Value != dr["DrugSHCode"] ? Convert.ToInt32(dr["DrugSHCode"]) : 0;
                        po.Dosage = DBNull.Value != dr["Dosage"] ? Convert.ToString(dr["Dosage"]) : "";
                        po.Duration = DBNull.Value != dr["Duration"] ? Convert.ToInt32(dr["Duration"]) : 0;
                        po.DurationType = DBNull.Value != dr["DurationType"] ? Convert.ToString(dr["DurationType"]) : "";
                        po.Frequency = DBNull.Value != dr["Frequency"] ? Convert.ToString(dr["Frequency"]) : "";
                        po.Prescr_Route = DBNull.Value != dr["Prescr_Route"] ? Convert.ToString(dr["Prescr_Route"]) : "";
                        po.DrugName = DBNull.Value != dr["DrugName"] ? Convert.ToString(dr["DrugName"]) : "";
                        po.TotalItem = DBNull.Value != dr["TotalItem"] ? Convert.ToInt32(dr["TotalItem"]) : 0;
                        po.NoofTablets = DBNull.Value != dr["NoofTablets"] ? Convert.ToInt32(dr["NoofTablets"]) : 0;
                        po.Created_dttm = DBNull.Value != dr["Created_dttm"] ? Convert.ToString(dr["Created_dttm"]) : "";

                        salutations.Add(po);
                    }
                }
            }

            return salutations;

        }

        public List<CityDTO> GetCityDetailsbyState(StateDTO countriesDTO)
        {
            List<CityDTO> services = new List<CityDTO>();

            DataSet ds = dataLayer.GetCityDetailsbyState(countriesDTO);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CityDTO po = new CityDTO();

                        po.CityID = DBNull.Value != dr["City_CityCode_cd"] ? Convert.ToInt32(dr["City_CityCode_cd"]) : 0;
                        po.StateID = DBNull.Value != dr["City_StateCode_cd"] ? Convert.ToInt32(dr["City_StateCode_cd"]) : 0;
                        po.CityName = DBNull.Value != dr["City_CityName_nm"] ? Convert.ToString(dr["City_CityName_nm"]) : "";

                        services.Add(po);

                    }
                }
            }

            return services;
        }
        public List<clsDropDown> GetSalutaionsDetails()
        {
            List<clsDropDown> salutations = new List<clsDropDown>();
            DataSet ds = dataLayer.GetSalutationsDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();
                        po.columnCode = DBNull.Value != dr["Mssl_Salutation_cd"] ? Convert.ToInt32(dr["Mssl_Salutation_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Mssl_SalutationNm_nm"] ? Convert.ToString(dr["Mssl_SalutationNm_nm"]) : "";
                        po.responseType = "Salutation";
                        salutations.Add(po);
                    }
                }
            }

            return salutations;

        }
        public List<clsDropDown> GetMobileCode()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetMobileCodeData();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown dropdown_DTO = new clsDropDown();

                        dropdown_DTO.columnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                        dropdown_DTO.columnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                        dropdown_DTO.responseType = "Mobile code";
                        dropdown_DTOs.Add(dropdown_DTO);
                    }
                }
            }

            return dropdown_DTOs;
        }

        public List<contryDropDown> GetCountriesDetails()
        {
            List<contryDropDown> countries = new List<contryDropDown>();
            DataSet ds = dataLayer.GetCountriesDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        contryDropDown po = new contryDropDown();

                        po.columnCode = DBNull.Value != dr["Ctry_CountryCode_cd"] ? Convert.ToInt32(dr["Ctry_CountryCode_cd"]) : 0;
                        po.nationalitycode = DBNull.Value != dr["Nlty_NationalityCode_cd"] ? Convert.ToInt32(dr["Nlty_NationalityCode_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Ctry_CountryName_nm"] ? Convert.ToString(dr["Ctry_CountryName_nm"]) : "";
                        po.responseType = "Countries ";
                        countries.Add(po);
                    }
                }
            }

            return countries;
        }
        public List<clsDropDown> GetServiceLoad()
        {
            List<clsDropDown> reqList = new List<clsDropDown>();
            DataSet ds = dataLayer.GetServiceLoad();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown req = new clsDropDown();

                        req.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                        req.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                        req.responseType = "services";
                        reqList.Add(req);
                    }
                }
            }

            return reqList;
        }
        //End by jeyaganesh 06.08.2021

        public List<clsDropDown> GetPriority()
        {
            List<clsDropDown> reqList = new List<clsDropDown>();
            DataSet ds = dataLayer.GetPriorityrData();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown req = new clsDropDown();

                        req.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                        req.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                        req.responseType = "priority";
                        reqList.Add(req);
                    }
                }
            }

            return reqList;
        }

        //public List<clsDropDown> GetChargeMaster(long code)
        //{
        //    List<clsDropDown> reqList = new List<clsDropDown>();
        //    DataSet ds = dataLayer.GetChargeMasterData(code);
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                clsDropDown req = new clsDropDown();

        //                req.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
        //                req.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
        //                req.responseType = "ChargeMaster";
        //                reqList.Add(req);
        //            }
        //        }
        //    }

        //    return reqList;
        //}
        public List<clsDropDown> GetNationalityDetails()
        {
            List<clsDropDown> iDTypeDTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetNationalityDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();

                        po.columnCode = DBNull.Value != dr["Nlty_NationalityCode_cd"] ? Convert.ToInt32(dr["Nlty_NationalityCode_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Nlty_Nationality_desc"] ? Convert.ToString(dr["Nlty_Nationality_desc"]) : "";
                        po.responseType = "Nationality";
                        iDTypeDTOs.Add(po);
                    }
                }
            }
            return iDTypeDTOs;
        }
        public List<resDropDown> MasterBloodGroup()
        {
            List<resDropDown> reqList = new List<resDropDown>();
            DataSet ds = dataLayer.GetMasterBloodGroup();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resDropDown req = new resDropDown();

                        req.columnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                        req.columnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                        reqList.Add(req);
                    }
                }
            }

            return reqList;
        }
        public List<resDropDown> Get_ExternalDoc_Data()
        {
            List<resDropDown> External = new List<resDropDown>();
            try
            {
                DataSet ds = dataLayer.GetExternal_DocData();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resDropDown DocData = new resDropDown();
                            DocData.columnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                            DocData.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                            External.Add(DocData);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return External;
        }
        public List<reqRef_Relationship> Ref_Relationship_list()
        {
            List<reqRef_Relationship> dropdown_DTOs = new List<reqRef_Relationship>();
            try
            {
                DataSet ds = dataLayer.GetRef_Relationship();
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            reqRef_Relationship res = new reqRef_Relationship();
                            res.ColumnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                            res.ColumnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<SurgProcname> SurgProcname_Dtl()
        {
            List<SurgProcname> dropdown_DTOs = new List<SurgProcname>();
            try
            {
                DataSet ds = dataLayer.SurgProcname_Dtl();
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            SurgProcname res = new SurgProcname();
                            res.ColumnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                            res.ColumnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<clsFinancialCounsellingprint> FinancialCounsellingprint(int Patientid, int CounsellingId)
        {
            List<clsFinancialCounsellingprint> dropdown_DTOs = new List<clsFinancialCounsellingprint>();
            try
            {
                DataSet ds = dataLayer.FinancialCounsellingprint(Patientid, CounsellingId);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsFinancialCounsellingprint res = new clsFinancialCounsellingprint();
                            res.Uhid = DBNull.Value != dr["Uhid"] ? Convert.ToString(dr["Uhid"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                            res.AdmittingDoctor = DBNull.Value != dr["AdmittingDoctor"] ? Convert.ToString(dr["AdmittingDoctor"]) : "";
                            res.DOA = DBNull.Value != dr["DOA"] ? Convert.ToString(dr["DOA"]) : "";
                            res.reqcat = DBNull.Value != dr["reqcat"] ? Convert.ToInt32(dr["reqcat"]) : 0;
                            res.RoomCategory = DBNull.Value != dr["RoomCategory"] ? Convert.ToString(dr["RoomCategory"]) : "";
                            res.AllotedCategory = DBNull.Value != dr["AllotedCategory"] ? Convert.ToString(dr["AllotedCategory"]) : "";
                            res.DepositAmt = DBNull.Value != dr["DepositAmt"] ? Convert.ToInt32(dr["DepositAmt"]) : 0;
                            res.RoomNumber = DBNull.Value != dr["RoomNumber"] ? Convert.ToString(dr["RoomNumber"]) : "";
                            res.Roomupgrade = DBNull.Value != dr["Roomupgrade"] ? Convert.ToString(dr["Roomupgrade"]) : "";
                            res.Treatmentplan = DBNull.Value != dr["Treatmentplan"] ? Convert.ToString(dr["Treatmentplan"]) : "";
                            res.ProcedureName = DBNull.Value != dr["ProcedureName"] ? Convert.ToString(dr["ProcedureName"]) : "";
                            res.Expecteddeliverydate = DBNull.Value != dr["Expecteddeliverydate"] ? Convert.ToString(dr["Expecteddeliverydate"]) : "";
                            res.EstimatedSaty = DBNull.Value != dr["EstimatedSaty"] ? Convert.ToInt32(dr["EstimatedSaty"]) : 0;
                            res.Speciality = DBNull.Value != dr["Speciality"] ? Convert.ToString(dr["Speciality"]) : "";
                            res.Diagnosis = DBNull.Value != dr["Diagnosis"] ? Convert.ToString(dr["Diagnosis"]) : "";
                            res.DiagnosisId = DBNull.Value != dr["DiagnosisId"] ? Convert.ToInt32(dr["DiagnosisId"]) : 0;
                            res.Pattitle = DBNull.Value != dr["Pattitle"] ? Convert.ToString(dr["Pattitle"]) : "";
                            res.PatNam = DBNull.Value != dr["PatNam"] ? Convert.ToString(dr["PatNam"]) : "";         
                            res.totaestimation = DBNull.Value != dr["totaestimation"] ? Convert.ToInt32(dr["totaestimation"]) : 0;
                            res.PatientType = DBNull.Value != dr["PatientType"] ? Convert.ToString(dr["PatientType"]) : "";
                            res.Payorid = DBNull.Value != dr["Payorid"] ? Convert.ToInt32(dr["Payorid"]) : 0;
                            res.Payorid = DBNull.Value != dr["Payorid"] ? Convert.ToInt32(dr["Payorid"]) : 0;
                            res.PayorCategory = DBNull.Value != dr["PayorCategory"] ? Convert.ToString(dr["PayorCategory"]) : "";
                            res.TotSum = DBNull.Value != dr["TotSum"] ? Convert.ToInt32(dr["TotSum"]) : 0;
                            res.Package = DBNull.Value != dr["Package"] ? Convert.ToInt32(dr["Package"]) : 0;
                            res.packagename = DBNull.Value != dr["packagename"] ? Convert.ToString(dr["packagename"]) : "";
                            res.packageinclusion = DBNull.Value != dr["packageinclusion"] ? Convert.ToInt32(dr["packageinclusion"]) : 0;
                            res.packageexclusion = DBNull.Value != dr["packageexclusion"] ? Convert.ToInt32(dr["packageexclusion"]) : 0;
                            res.implantCharges = DBNull.Value != dr["implantCharges"] ? Convert.ToInt32(dr["implantCharges"]) : 0;
                            res.RoomTariff = DBNull.Value != dr["RoomTariff"] ? Convert.ToInt32(dr["RoomTariff"]) : 0;
                            res.DrugConsumbles = DBNull.Value != dr["DrugConsumbles"] ? Convert.ToInt32(dr["DrugConsumbles"]) : 0;
                            res.bedsideprocedures = DBNull.Value != dr["bedsideprocedures"] ? Convert.ToInt32(dr["bedsideprocedures"]) : 0;
                            res.bloodproduct = DBNull.Value != dr["bloodproduct"] ? Convert.ToInt32(dr["bloodproduct"]) : 0;
                            res.ICU = DBNull.Value != dr["ICU"] ? Convert.ToInt32(dr["ICU"]) : 0;
                            res.investigations = DBNull.Value != dr["investigations"] ? Convert.ToInt32(dr["investigations"]) : 0;
                            res.doctorfees = DBNull.Value != dr["doctorfees"] ? Convert.ToInt32(dr["doctorfees"]) : 0;
                            res.othercharges = DBNull.Value != dr["othercharges"] ? Convert.ToInt32(dr["othercharges"]) : 0;
                            res.CounselledBy = DBNull.Value != dr["CounselledBy"] ? Convert.ToString(dr["CounselledBy"]) : "";
                            res.CounselledDate = DBNull.Value != dr["CounselledDate"] ? Convert.ToString(dr["CounselledDate"]) : "";
                            res.Kindetail = DBNull.Value != dr["Kindetail"] ? Convert.ToString(dr["Kindetail"]) : "";
                            res.Relationship = DBNull.Value != dr["Relationship"] ? Convert.ToString(dr["Relationship"]) : "";
                            res.Attachment = DBNull.Value != dr["Attachment"] ? Convert.ToString(dr["Attachment"]) : "";
                            res.AttachName = DBNull.Value != dr["AttachName"] ? Convert.ToString(dr["AttachName"]) : "";
                            res.ReportOutTime = DBNull.Value != dr["ReportOutTime"] ? Convert.ToString(dr["ReportOutTime"]) : "";
                            res.ReportingInTime = DBNull.Value != dr["ReportingInTime"] ? Convert.ToString(dr["ReportingInTime"]) : "";
                            res.NursingCharge = DBNull.Value != dr["NursingCharge"] ? Convert.ToInt32(dr["NursingCharge"]) : 0;
                            res.ReportingInTime = DBNull.Value != dr["ReportingInTime"] ? Convert.ToString(dr["ReportingInTime"]) : ""; 
                            res.DMORate = DBNull.Value != dr["DMORate"] ? Convert.ToInt32(dr["DMORate"]) : 0;


                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<FinCouncil_Detail_Load> FinCouncil_Detail_Load(int Patientid)
        {
            List<FinCouncil_Detail_Load> dropdown_DTOs = new List<FinCouncil_Detail_Load>();
            try
            {
                DataSet ds = dataLayer.FinancialCounsellingprint(Patientid);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            FinCouncil_Detail_Load res = new FinCouncil_Detail_Load();
                            res.counselid = DBNull.Value != dr["counselid"] ? Convert.ToInt32(dr["counselid"]) : 0;
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToInt32(dr["MRN"]) : 0;
                            res.Title = DBNull.Value != dr["Title"] ? Convert.ToString(dr["Title"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DeptId = DBNull.Value != dr["DeptId"] ? Convert.ToInt32(dr["DeptId"]) : 0;
                            res.DeptName = DBNull.Value != dr["DeptName"] ? Convert.ToString(dr["DeptName"]) : "";
                            res.AdmDate = DBNull.Value != dr["AdmDate"] ? Convert.ToString(dr["AdmDate"]) :"";
                            res.reqcat = DBNull.Value != dr["reqcat"] ? Convert.ToInt32(dr["reqcat"]) : 0;
                            res.ReqCategoryName = DBNull.Value != dr["ReqCategoryName"] ? Convert.ToString(dr["ReqCategoryName"]) : "";
                            res.AllotedId = DBNull.Value != dr["AllotedId"] ? Convert.ToInt32(dr["AllotedId"]) : 0;
                            res.AllotedCategory = DBNull.Value != dr["AllotedCategory"] ? Convert.ToString(dr["AllotedCategory"]) : "";
                            res.RoomNumber = DBNull.Value != dr["RoomNumber"] ? Convert.ToString(dr["RoomNumber"]) : "";
                            res.PlanTreat = DBNull.Value != dr["PlanTreat"] ? Convert.ToString(dr["PlanTreat"]) : "";
                            res.RoomUpgrade = DBNull.Value != dr["RoomUpgrade"] ? Convert.ToInt32(dr["RoomUpgrade"]) : 0;
                            res.Stay = DBNull.Value != dr["Stay"] ? Convert.ToInt32(dr["Stay"]) : 0;
                            res.Deposit = DBNull.Value != dr["Deposit"] ? Convert.ToInt32(dr["Deposit"]) : 0;
                            res.Counselled = DBNull.Value != dr["Counselled"] ? Convert.ToString(dr["Counselled"]) : "";
                            res.CounselledBy = DBNull.Value != dr["CounselledBy"] ? Convert.ToString(dr["CounselledBy"]) : "";
                            res.RoomTariff = DBNull.Value != dr["RoomTariff"] ? Convert.ToInt32(dr["RoomTariff"]) : 0;
                            res.DrugConsumable = DBNull.Value != dr["DrugConsumable"] ? Convert.ToInt32(dr["DrugConsumable"]) : 0;
                            res.Proce = DBNull.Value != dr["Proce"] ? Convert.ToInt32(dr["Proce"]) : 0;
                            res.BloodProduct = DBNull.Value != dr["BloodProduct"] ? Convert.ToInt32(dr["BloodProduct"]) : 0;
                            res.ICUOther = DBNull.Value != dr["ICUOther"] ? Convert.ToInt32(dr["ICUOther"]) : 0;
                            res.Investigation = DBNull.Value != dr["Investigation"] ? Convert.ToInt32(dr["Investigation"]) : 0;
                            res.DoctorFee = DBNull.Value != dr["DoctorFee"] ? Convert.ToInt32(dr["DoctorFee"]) : 0;
                            res.others = DBNull.Value != dr["others"] ? Convert.ToInt32(dr["others"]) : 0;
                            res.ESAmt = DBNull.Value != dr["ESAmt"] ? Convert.ToInt32(dr["ESAmt"]) : 0;
                            res.DepositFlg = DBNull.Value != dr["DepositFlg"] ? Convert.ToInt32(dr["DepositFlg"]) : 0;
                            res.Aukthorizedby = DBNull.Value != dr["Aukthorizedby"] ? Convert.ToString(dr["Aukthorizedby"]) : "";
                            res.AuthorizedDate = DBNull.Value != dr["AuthorizedDate"] ? Convert.ToString(dr["AuthorizedDate"]) : "";
                            res.Patienttype = DBNull.Value != dr["Patienttype"] ? Convert.ToString(dr["Patienttype"]) : "";
                            res.Payorid = DBNull.Value != dr["Payorid"] ? Convert.ToInt32(dr["Payorid"]) : 0;
                            res.Payor = DBNull.Value != dr["Payor"] ? Convert.ToString(dr["Payor"]) : "";
                            res.DiagnosisName = DBNull.Value != dr["DiagnosisName"] ? Convert.ToString(dr["DiagnosisName"]) : "";
                            res.DiagnosisId = DBNull.Value != dr["DiagnosisId"] ? Convert.ToInt32(dr["DiagnosisId"]) : 0;
                          

                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


        public List<clsDropDown> Get_MasReligion_Data()
        {
            List<clsDropDown> WebList = new List<clsDropDown>();
            try
            {
                DataSet ds = dataLayer.GetMasReligion_Data();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsDropDown chg = new clsDropDown();
                            chg.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                            chg.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                            chg.responseType = "Religin Data";
                            WebList.Add(chg);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
        public List<clsDropDown> Get_MasLang_Data()
        {
            List<clsDropDown> WebList = new List<clsDropDown>();
            try
            {
                DataSet ds = dataLayer.GetMasLang_Data();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsDropDown chg = new clsDropDown();
                            chg.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                            chg.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                            chg.responseType = "Language Data";
                            WebList.Add(chg);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
        public List<clsDropDown> GetOccupationDataDetails()
        {
            List<clsDropDown> iDTypeDTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetOccupationDataDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();

                        po.columnCode = DBNull.Value != dr["Occu_OccupationCode_cd"] ? Convert.ToInt32(dr["Occu_OccupationCode_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Occu_OccupationName_nm"] ? Convert.ToString(dr["Occu_OccupationName_nm"]) : "";
                        po.responseType = "Occupation";
                        iDTypeDTOs.Add(po);
                    }
                }
            }

            return iDTypeDTOs;
        }

        public List<clsbedRes> Web_Bed_Report()
        {
            List<clsbedRes> iDTypeDTOs = new List<clsbedRes>();
            DataSet ds = dataLayer.Web_Bed_Report();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsbedRes po = new clsbedRes();

                        po.Ward_ICU_Name = DBNull.Value != dr["Ward_ICU_Name"] ? Convert.ToString(dr["Ward_ICU_Name"]) : "";
                        po.Ward_No = DBNull.Value != dr["Ward_No"] ? Convert.ToString(dr["Ward_No"]) : "";
                        po.COVID_Non_COVID = DBNull.Value != dr["COVID_Non_COVID"] ? Convert.ToString(dr["COVID_Non_COVID"]) : "";
                        po.Total_Beds = DBNull.Value != dr["Total_Beds"] ? Convert.ToInt32(dr["Total_Beds"]) : 0;
                        po.Cradle = DBNull.Value != dr["Cradle"] ? Convert.ToString(dr["Cradle"]) : "";                       
                        po.Occupied = DBNull.Value != dr["Occupied"] ? Convert.ToInt32(dr["Occupied"]) : 0;
                        po.Under_Maintenance = DBNull.Value != dr["Under_Maintenance"] ? Convert.ToInt32(dr["Under_Maintenance"]) : 0;
                        po.Blocked = DBNull.Value != dr["Blocked"] ? Convert.ToInt32(dr["Blocked"]) : 0;
                        po.Available_Beds = DBNull.Value != dr["Available_Beds"] ? Convert.ToInt32(dr["Available_Beds"]) : 0;
                        po.Marked_for_Disharge = DBNull.Value != dr["Marked_for_Disharge"] ? Convert.ToInt32(dr["Marked_for_Disharge"]) : 0;
                        po.Marked_for_Transfer = DBNull.Value != dr["Marked_for_Transfer"] ? Convert.ToInt32(dr["Marked_for_Transfer"]) : 0;
                        po.New_IP_Admissions_for_the_day = DBNull.Value != dr["New_IP_Admissions_for_the_day"] ? Convert.ToInt32(dr["New_IP_Admissions_for_the_day"]) :0;
                  
                        iDTypeDTOs.Add(po);
                    }
                }
            }

            return iDTypeDTOs;
        }
        public List<clsDropDown> GetStateDetails()
        {
            List<clsDropDown> countries = new List<clsDropDown>();
            DataSet ds = dataLayer.GetStateDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();
                        po.columnCode = DBNull.Value != dr["Stat_StateCode_cd"] ? Convert.ToInt32(dr["Stat_StateCode_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Stat_StateName_nm"] ? Convert.ToString(dr["Stat_StateName_nm"]) : "";
                        po.responseType = "State Name";
                        countries.Add(po);
                    }
                }
            }

            return countries;
        }
        public List<clsDropDown> GetMaritalStatusDetails()
        {
            List<clsDropDown> iDTypeDTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetMaritalStatusDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();

                        po.columnCode = DBNull.Value != dr["Mrst_MaritalStatus_cd"] ? Convert.ToInt32(dr["Mrst_MaritalStatus_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Mrst_MaritalStatus_nm"] ? Convert.ToString(dr["Mrst_MaritalStatus_nm"]) : "";
                        //po.Mrst_MaritalStatus_SHCD = DBNull.Value != dr["TMC_Maritalstatuscode"] ? Convert.ToString(dr["TMC_Maritalstatuscode"]) : "";
                        po.responseType = "Marital Status";
                        iDTypeDTOs.Add(po);
                    }
                }
            }

            return iDTypeDTOs;
        }
        public List<clsDropDown> GetCityDtlStatewise(int StateCode)
        {
            List<clsDropDown> countries = new List<clsDropDown>();
            DataSet ds = dataLayer.GetCityStatewiseDtl(StateCode);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();

                        po.columnCode = DBNull.Value != dr["City_CityCode_cd"] ? Convert.ToInt32(dr["City_CityCode_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["City_CityName_nm"] ? Convert.ToString(dr["City_CityName_nm"]) : "";
                        po.responseType = "City";
                        countries.Add(po);
                    }
                }
            }

            return countries;
        }
        public List<req_chargeload_v1> GetChargeMaster_v1(long code)
        {
            List<req_chargeload_v1> reqList = new List<req_chargeload_v1>();
            DataSet ds = dataLayer.GetChargeMasterData_v1(code);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        req_chargeload_v1 req = new req_chargeload_v1();

                        req.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                        req.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                        req.ISVariable_flg = DBNull.Value != dr["ISVariable_flg"] ? Convert.ToInt32(dr["ISVariable_flg"]) : 0;
                        req.responseType = "ChargeMaster";
                        reqList.Add(req);
                    }
                }
            }

            return reqList;
        }
        public List<clsDropDown> GetIDTypeDetails()
        {
            List<clsDropDown> iDTypeDTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetIDTypeDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown po = new clsDropDown();

                        po.columnCode = DBNull.Value != dr["Idty_IdtypeCode_cd"] ? Convert.ToInt32(dr["Idty_IdtypeCode_cd"]) : 0;
                        po.columnName = DBNull.Value != dr["Idty_IdtypeName_nm"] ? Convert.ToString(dr["Idty_IdtypeName_nm"]) : "";
                        po.responseType = "ID Type";
                        iDTypeDTOs.Add(po);
                    }
                }
            }

            return iDTypeDTOs;
        }
        public List<clsDropDown> GetDoctorNameDepWise(long DepID, string DoctorName)
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetDoctorNameDepWise(DepID, DoctorName);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown dropdown_DTO = new clsDropDown();
                        dropdown_DTO.columnCode = DBNull.Value != dr["Mdoc_DoctorId_id"] ? Convert.ToInt32(dr["Mdoc_DoctorId_id"]) : 0;
                        dropdown_DTO.columnName = DBNull.Value != dr["Mdoc_DoctorName_nm"] ? Convert.ToString(dr["Mdoc_DoctorName_nm"]) : "";
                        dropdown_DTO.responseType = "Doctor";
                        dropdown_DTOs.Add(dropdown_DTO);
                    }
                }
            }

            return dropdown_DTOs;
        }
        public List<clsDropDown> GetCorprateInsurancelist(string PanelType)
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();

            DataSet ds = dataLayer.GetRef_Corprate_Insurance(PanelType);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown dropdown_DTO = new clsDropDown();
                        dropdown_DTO.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                        dropdown_DTO.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                        dropdown_DTOs.Add(dropdown_DTO);
                    }
                }
            }


            return dropdown_DTOs;
        }
        public PincodewiseDataDTO GetPincodewiseData(PincodeResuest resuest)
        {
            PincodewiseDataDTO dTO = new PincodewiseDataDTO();
            DataSet ds = dataLayer.GetPincodewiseData(resuest);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    dTO.CountryCode = DBNull.Value != ds.Tables[0].Rows[0]["City_CountryCode_cd"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["City_CountryCode_cd"]) : 0;
                    dTO.CountryName = DBNull.Value != ds.Tables[0].Rows[0]["Ctry_CountryName_nm"] ? Convert.ToString(ds.Tables[0].Rows[0]["Ctry_CountryName_nm"]) : "";
                    dTO.StateCode = DBNull.Value != ds.Tables[0].Rows[0]["City_StateCode_cd"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["City_StateCode_cd"]) : 0;
                    dTO.StateName = DBNull.Value != ds.Tables[0].Rows[0]["Stat_StateName_nm"] ? Convert.ToString(ds.Tables[0].Rows[0]["Stat_StateName_nm"]) : "";
                    dTO.CityCode = DBNull.Value != ds.Tables[0].Rows[0]["City_CityCode_cd"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["City_CityCode_cd"]) : 0;
                    dTO.CityName = DBNull.Value != ds.Tables[0].Rows[0]["City_CityName_nm"] ? Convert.ToString(ds.Tables[0].Rows[0]["City_CityName_nm"]) : "";
                    dTO.PinCode = DBNull.Value != ds.Tables[0].Rows[0]["Pincode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Pincode"]) : 0;
                    dTO.NationalityCode = DBNull.Value != ds.Tables[0].Rows[0]["Nlty_NationalityCode_cd"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Nlty_NationalityCode_cd"]) : 0;
                }
            }
            return dTO;
        }

        public List<clsDropDown> GetArea(string pincode)
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetAreaData(pincode);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown dropdown_DTO = new clsDropDown();

                        dropdown_DTO.columnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                        dropdown_DTO.columnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                        dropdown_DTO.responseType = "Get Area ";
                        dropdown_DTOs.Add(dropdown_DTO);
                    }
                }
            }

            return dropdown_DTOs;
        }
        //PRABHA 04-Jan-2022
        public List<reqRef_DoctorData> Ref_DoctorData_list()
        {
            List<reqRef_DoctorData> dropdown_DTOs = new List<reqRef_DoctorData>();
            try
            {
                DataSet ds = dataLayer.GetRef_DoctorData();
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            reqRef_DoctorData res = new reqRef_DoctorData();
                            res.ColumnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                            res.ColumnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                            //res.ResponseType = DBNull.Value != dr["ResponseType"] ? Convert.ToString(dr["ResponseType"]) : "";
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<clsDropDown> Ref_Source_list()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            try
            {
                DataSet ds = dataLayer.GetRef_Source();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsDropDown res = new clsDropDown();
                            res.columnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                            res.columnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                            res.responseType = "Ref Source";
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
        public List<clsDropDown> GetDepartment() //change to jai
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            DataSet ds = dataLayer.GetDepartmentData();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown dropdown_DTO = new clsDropDown();

                        dropdown_DTO.columnCode = DBNull.Value != dr["ColumnCode"] ? Convert.ToInt32(dr["ColumnCode"]) : 0;
                        dropdown_DTO.columnName = DBNull.Value != dr["ColumnName"] ? Convert.ToString(dr["ColumnName"]) : "";
                        dropdown_DTO.responseType = DBNull.Value != dr["ResponseType"] ? Convert.ToString(dr["ResponseType"]) : "";
                        dropdown_DTOs.Add(dropdown_DTO);
                    }
                }
            }

            return dropdown_DTOs;
        }
        public EXS_opd_master_Res Insert_ExsistsOPDMaster_Porc(OPD_ExsitsMasterProc_req request)
        {
            EXS_opd_master_Res result = new EXS_opd_master_Res();
            DataSet ds = dataLayer.Insert_ExsistsOPDMaster_Porc(request);

            if (ds != null)
            {
               // Sno MsgDescp    ReferenceNumber VisitId SurrogatedID Mobileno    Emailid age appId docid


                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDescp = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";
                result.ReferenceNumber = DBNull.Value != ds.Tables[0].Rows[0]["ReferenceNumber"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["ReferenceNumber"]) : 0;
                result.VisitId = DBNull.Value != ds.Tables[0].Rows[0]["VisitId"] ? Convert.ToString(ds.Tables[0].Rows[0]["VisitId"]) : "";
                result.SurrogatedID = DBNull.Value != ds.Tables[0].Rows[0]["SurrogatedID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["SurrogatedID"]) : 0;
                result.Mobileno = DBNull.Value != ds.Tables[0].Rows[0]["Mobileno"] ? Convert.ToString(ds.Tables[0].Rows[0]["Mobileno"]) : "";
                result.Emailid = DBNull.Value != ds.Tables[0].Rows[0]["Emailid"] ? Convert.ToString(ds.Tables[0].Rows[0]["Emailid"]) : "";
                result.age = DBNull.Value != ds.Tables[0].Rows[0]["age"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["age"]) : 0;
                result.appId = DBNull.Value != ds.Tables[0].Rows[0]["appId"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["appId"]) : 0;
                result.docid = DBNull.Value != ds.Tables[0].Rows[0]["docid"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["docid"]) : 0;
                //result.DoctorName = DBNull.Value != ds.Tables[0].Rows[0]["DoctorName"] ? Convert.ToString(ds.Tables[0].Rows[0]["DoctorName"]) : "";
                //result.BillVisitDATE = DBNull.Value != ds.Tables[0].Rows[0]["BillVisitDATE"] ? Convert.ToString(ds.Tables[0].Rows[0]["BillVisitDATE"]) : "";
            }
           
            return result;
        }
        //sujithra
        public InsertCriticalCare_InfectiousDis_Res InsertCriticalCare_InfectiousDis(InsertCriticalCare_req request)
        {
            InsertCriticalCare_InfectiousDis_Res result = new InsertCriticalCare_InfectiousDis_Res();
            DataSet ds = dataLayer.InsertCriticalCare_InfectiousDis(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.Msg = DBNull.Value != ds.Tables[0].Rows[0]["Msg"] ? Convert.ToString(ds.Tables[0].Rows[0]["Msg"]) : "";

            }

            return result;
        }

        public clsResult opInvoice(clsopInvoice request)
        {
            clsResult result = new clsResult();

            DataSet ds = dataLayer.opInvoice(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.SurrogatedID = DBNull.Value != ds.Tables[0].Rows[0]["SurrogatedID"] ? Convert.ToString(ds.Tables[0].Rows[0]["SurrogatedID"]) : "";
                result.MsgDescp = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";
                result.ServiceOrderNo = DBNull.Value != ds.Tables[0].Rows[0]["ServiceOrderNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["ServiceOrderNo"]) : "";

            }

            return result;
        }


        public clsdepResult Deposit_Dep(clsdeposit request)
        {
            clsdepResult result = new clsdepResult();

            DataSet ds = dataLayer.Deposit_Dep(request);

            if (ds != null)
            {

                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.UHID = DBNull.Value != ds.Tables[0].Rows[0]["UHID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["UHID"]) : 0;
                result.MsgDescp = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";

            }

            return result;
        }
        public clsrefincoun_save web_refincoun_save(clsrefincoun request)
        {
            clsrefincoun_save result = new clsrefincoun_save();

            DataSet ds = dataLayer.web_refincoun_save(request);

            if (ds != null)
            {

                result.Id = DBNull.Value != ds.Tables[0].Rows[0]["Id"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]) : 0;
                result.Msgdesc = DBNull.Value != ds.Tables[0].Rows[0]["Msgdesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["Msgdesc"]) : "";

            }

            return result;
        }
        public clsIPBedBlock_Save IPBedBlock_Save(clsIPBedBlock request)
        {
            clsIPBedBlock_Save result = new clsIPBedBlock_Save();

            DataSet ds = dataLayer.IPBedBlock_Save(request);

            if (ds != null)
            {

                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }
        public clsIPBedBlock_Clear IPBedBlock_Clear(reqIPBedBlock_Clear request)
        {
            clsIPBedBlock_Clear result = new clsIPBedBlock_Clear();

            DataSet ds = dataLayer.IPBedBlock_Clear(request);

            if (ds != null)
            {

                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }

        public Response_DTO VisitExistingPatient(reqAppVisit request)
        {
            Response_DTO response = new Response_DTO();

            DataSet ds = dataLayer.updateVist_new(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.ResultCode = DBNull.Value != dr["ResultCode"] ? Convert.ToString(dr["ResultCode"]) : "";
                        response.Result = DBNull.Value != dr["Result"] ? Convert.ToString(dr["Result"]) : "";
                        response.RegId = DBNull.Value != dr["RegId"] ? Convert.ToInt32(dr["RegId"]) : 0;
                        response.DepId = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                        response.DocId = DBNull.Value != dr["DocId"] ? Convert.ToInt32(dr["DocId"]) : 0;
                        response.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        response.UHID = DBNull.Value != dr["Uhid"] ? Convert.ToInt32(dr["Uhid"]) : 0;
                        response.UserCode = DBNull.Value != dr["UserCode"] ? Convert.ToInt32(dr["UserCode"]) : 0;

                    }
                }
            }

            return response;
        }

        public clsWebExisitingPatientAppointment WebExisitingPatientAppointment(clsWebExisitingPatientAppointmenthead request)
        {
            clsWebExisitingPatientAppointment result = new clsWebExisitingPatientAppointment();

            DataSet ds = dataLayer.getWebExisitingPatientAppointment(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";


            }

            return result;
        }

        public clsWebExisitingPatientAppointment VisitWithAppointment(VisitWithAppointment_Detail request)
        {
            clsWebExisitingPatientAppointment result = new clsWebExisitingPatientAppointment();

            DataSet ds = dataLayer.VisitWithAppointment(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";

            }

            return result;
        }




        public List<clsPatientMas_v1> GetPatientMas_List_v1(int PatientID)
        {
            List<clsPatientMas_v1> res = new List<clsPatientMas_v1>();
            List<resDropDown> res1 = new List<resDropDown>();
            DataSet ds = dataLayer.GetPatientMas_List_v1(PatientID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsPatientMas_v1 req = new clsPatientMas_v1();


                        req.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                        req.UHID = DBNull.Value != ds.Tables[0].Rows[0]["UHID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["UHID"]) : 0;

                        resDropDown Salutation = new resDropDown();
                        Salutation.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["Salutation"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Salutation"]) : 0;
                        Salutation.columnName = DBNull.Value != ds.Tables[0].Rows[0]["SalutationName"] ? Convert.ToString(ds.Tables[0].Rows[0]["SalutationName"]) : "";
                        req.Salutation = Salutation;

                        req.PatientName = DBNull.Value != ds.Tables[0].Rows[0]["PatientName"] ? Convert.ToString(ds.Tables[0].Rows[0]["PatientName"]) : "";
                        req.Gender = DBNull.Value != ds.Tables[0].Rows[0]["Gender"] ? Convert.ToString(ds.Tables[0].Rows[0]["Gender"]) : "";
                        req.DOB = DBNull.Value != ds.Tables[0].Rows[0]["DOB"] ? Convert.ToString(ds.Tables[0].Rows[0]["DOB"]) : "";

                        resDropDown Marital = new resDropDown();
                        Marital.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["MaritialID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaritialID"]) : 0;
                        Marital.columnName = DBNull.Value != ds.Tables[0].Rows[0]["MaritialStatus"] ? Convert.ToString(ds.Tables[0].Rows[0]["MaritialStatus"]) : "";
                        req.Maritial = Marital;

                        resDropDown Nationality = new resDropDown();
                        Nationality.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["Natcode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Natcode"]) : 0;
                        Nationality.columnName = DBNull.Value != ds.Tables[0].Rows[0]["Nationality"] ? Convert.ToString(ds.Tables[0].Rows[0]["Nationality"]) : "";
                        req.Nationality = Nationality;

                        resDropDown IdType = new resDropDown();
                        IdType.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["IDCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["IDCode"]) : 0;
                        IdType.columnName = DBNull.Value != ds.Tables[0].Rows[0]["IDtype"] ? Convert.ToString(ds.Tables[0].Rows[0]["IDtype"]) : "";
                        req.IDtype = IdType;

                        req.IDNo = DBNull.Value != ds.Tables[0].Rows[0]["IDNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["IDNo"]) : "";


                        resDropDown occupation = new resDropDown();
                        occupation.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["Occupation"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Occupation"]) : 0;
                        occupation.columnName = DBNull.Value != ds.Tables[0].Rows[0]["OccupationName"] ? Convert.ToString(ds.Tables[0].Rows[0]["OccupationName"]) : "";
                        req.occupation = occupation;


                        req.MobileNo = DBNull.Value != ds.Tables[0].Rows[0]["MobileNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]) : "";
                        req.EmailId = DBNull.Value != ds.Tables[0].Rows[0]["Email"] ? Convert.ToString(ds.Tables[0].Rows[0]["Email"]) : "";
                        req.Pincode = DBNull.Value != ds.Tables[0].Rows[0]["Pincode"] ? Convert.ToString(ds.Tables[0].Rows[0]["Pincode"]) : "";

                        resDropDown Country = new resDropDown();
                        Country.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["CountryCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["CountryCode"]) : 0;
                        Country.columnName = DBNull.Value != ds.Tables[0].Rows[0]["CountryName"] ? Convert.ToString(ds.Tables[0].Rows[0]["CountryName"]) : "";
                        req.Country = Country;


                        resDropDown State = new resDropDown();
                        State.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["StateCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["StateCode"]) : 0;
                        State.columnName = DBNull.Value != ds.Tables[0].Rows[0]["StatName"] ? Convert.ToString(ds.Tables[0].Rows[0]["StatName"]) : "";
                        req.State = State;


                        resDropDown City = new resDropDown();
                        City.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["CityCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["CityCode"]) : 0;
                        City.columnName = DBNull.Value != ds.Tables[0].Rows[0]["CityName"] ? Convert.ToString(ds.Tables[0].Rows[0]["CityName"]) : "";
                        req.City = City;


                        req.Area = DBNull.Value != ds.Tables[0].Rows[0]["Area"] ? Convert.ToString(ds.Tables[0].Rows[0]["Area"]) : "";

                        req.Address = DBNull.Value != ds.Tables[0].Rows[0]["Address"] ? Convert.ToString(ds.Tables[0].Rows[0]["Address"]) : "";


                        resDropDown RelType = new resDropDown();
                        RelType.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["RelType"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["RelType"]) : 0;
                        RelType.columnName = DBNull.Value != ds.Tables[0].Rows[0]["RelTypeName"] ? Convert.ToString(ds.Tables[0].Rows[0]["RelTypeName"]) : "";
                        req.RelType = RelType;

                        req.RelMobileNo = DBNull.Value != ds.Tables[0].Rows[0]["RelMobileNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["RelMobileNo"]) : "";

                        req.RelName = DBNull.Value != ds.Tables[0].Rows[0]["RelName"] ? Convert.ToString(ds.Tables[0].Rows[0]["RelName"]) : "";

                        req.KinArea = DBNull.Value != ds.Tables[0].Rows[0]["KinArea"] ? Convert.ToString(ds.Tables[0].Rows[0]["KinArea"]) : "";

                        req.KinAddress = DBNull.Value != ds.Tables[0].Rows[0]["KinAddress"] ? Convert.ToString(ds.Tables[0].Rows[0]["KinAddress"]) : "";

                        req.KinPostal = DBNull.Value != ds.Tables[0].Rows[0]["KinPostal"] ? Convert.ToString(ds.Tables[0].Rows[0]["KinPostal"]) : "";


                        resDropDown KinCountry = new resDropDown();
                        KinCountry.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["KinCountryCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["KinCountryCode"]) : 0;
                        KinCountry.columnName = DBNull.Value != ds.Tables[0].Rows[0]["KinCountryName"] ? Convert.ToString(ds.Tables[0].Rows[0]["KinCountryName"]) : "";
                        req.KinCountry = KinCountry;


                        resDropDown KinState = new resDropDown();
                        KinState.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["KinStateCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["KinStateCode"]) : 0;
                        KinState.columnName = DBNull.Value != ds.Tables[0].Rows[0]["KinStateName"] ? Convert.ToString(ds.Tables[0].Rows[0]["KinStateName"]) : "";
                        req.KinState = KinState;


                        resDropDown KinCity = new resDropDown();
                        KinCity.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["KinCityCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["KinCityCode"]) : 0;
                        KinCity.columnName = DBNull.Value != ds.Tables[0].Rows[0]["KinCityName"] ? Convert.ToString(ds.Tables[0].Rows[0]["KinCityName"]) : "";
                        req.KinCity = KinCity;


                        req.CreateDate = DBNull.Value != ds.Tables[0].Rows[0]["CreateDate"] ? Convert.ToString(ds.Tables[0].Rows[0]["CreateDate"]) : "";

                        req.Age = DBNull.Value != ds.Tables[0].Rows[0]["Age"] ? Convert.ToString(ds.Tables[0].Rows[0]["Age"]) : "";
                        res.Add(req);

                    }
                }
            }

            return res;

        }

        public List<DepPatAmt_Details> Get_WEB_DepPatAmt_Details(int UHID)
        {
            List<DepPatAmt_Details> res = new List<DepPatAmt_Details>();
            List<resDropDown> res1 = new List<resDropDown>();
            DataSet ds = dataLayer.Get_WEB_DepPatAmt_Details(UHID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DepPatAmt_Details req = new DepPatAmt_Details();

                        req.surrogateID = DBNull.Value != dr["surrogateID"] ? Convert.ToInt32(dr["surrogateID"]) : 0;
                        req.ReceiptNo = DBNull.Value != dr["ReceiptNo"] ? Convert.ToString(dr["ReceiptNo"]) : "";
                        req.ReceiptDate = DBNull.Value != dr["ReceiptDate"] ? Convert.ToString(dr["ReceiptDate"]) : "";
                        req.ReceiptTime = DBNull.Value != dr["ReceiptTime"] ? Convert.ToString(dr["ReceiptTime"]) : "";
                        req.CashAmt = DBNull.Value != dr["CashAmt"] ? Convert.ToInt32(dr["CashAmt"]) : 0;
                        req.ChequeAmt = DBNull.Value != dr["ChequeAmt"] ? Convert.ToInt32(dr["ChequeAmt"]) : 0;
                        req.CreditAmt = DBNull.Value != dr["CreditAmt"] ? Convert.ToInt32(dr["CreditAmt"]) : 0;
                        req.ReceiptAmt = DBNull.Value != dr["ReceiptAmt"] ? Convert.ToInt32(dr["ReceiptAmt"]) : 0;
                        req.ContraAmt = DBNull.Value != dr["ContraAmt"] ? Convert.ToInt32(dr["ContraAmt"]) : 0;
                        req.AllocatedPatientID = DBNull.Value != dr["AllocatedPatientID"] ? Convert.ToInt32(dr["AllocatedPatientID"]) : 0;
                        req.AmountUsed = DBNull.Value != dr["AmountUsed"] ? Convert.ToInt32(dr["AmountUsed"]) : 0;
                        req.BalanceAmt = DBNull.Value != dr["BalanceAmt"] ? Convert.ToInt32(dr["BalanceAmt"]) : 0;
                        req.Allocated = DBNull.Value != dr["Allocated"] ? Convert.ToInt32(dr["Allocated"]) : 0;
                        req.CancelBillNo = DBNull.Value != dr["CancelBillNo"] ? Convert.ToString(dr["CancelBillNo"]) : "";
                        req.DepositType = DBNull.Value != dr["DepositType"] ? Convert.ToString(dr["DepositType"]) :"";
                          
                        res.Add(req);

                    }
                }
            }

            return res;

        }

        //public List<clsDropDown> Get_web_DepositType_Dtl()
        //{

        //    List<clsDropDown> res1 = new List<clsDropDown>();
        //    DataSet ds = dataLayer.Get_web_DepositType_Dtl();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {

        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                clsDropDown req = new clsDropDown();

        //                req.columnName = DBNull.Value != ds.Tables[0].Rows[0]["ColumnName"] ? Convert.ToString(ds.Tables[0].Rows[0]["ColumnName"]) : "";
        //                req.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["ColumnCode"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["ColumnCode"]) : 0;
        //                req.responseType = "Deposite Type";

        //                res1.Add(req);
        //            }
        //        }
        //    }

        //    return res1;

        //}
        public List<clsDropDown> Get_web_DepositType_Dtl()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            try
            {
                DataSet ds = dataLayer.Get_web_DepositType_Dtl();
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsDropDown res = new clsDropDown();
                            res.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                            res.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                            res.responseType = "Deposite Type";
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<clsRadLandingScreen> Get_web_RadLandingScreen_Dtl(string dtFrom, string dtTo, int blnOrderwise)
        {
            List<clsRadLandingScreen> dropdown_DTOs = new List<clsRadLandingScreen>();
            try
            {
                DataSet ds = dataLayer.Get_web_RadLandingScreen_Dtl(dtFrom, dtTo, blnOrderwise);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsRadLandingScreen res = new clsRadLandingScreen();
                            res.PatientType = DBNull.Value != dr["PatientType"] ? Convert.ToString(dr["PatientType"]) : "";
                            res.PatientVisitType = DBNull.Value != dr["PatientVisitType"] ? Convert.ToString(dr["PatientVisitType"]) : "";
                            res.OrderID = DBNull.Value != dr["OrderID"] ? Convert.ToString(dr["OrderID"]) : "";
                            res.PackOrderID = DBNull.Value != dr["PackOrderID"] ? Convert.ToInt32(dr["PackOrderID"]) : 0;
                            res.OrderDate = DBNull.Value != dr["OrderDate"] ? Convert.ToString(dr["OrderDate"]) : "";
                            res.VisitID = DBNull.Value != dr["VisitID"] ? Convert.ToString(dr["VisitID"]) : "";
                            res.PreRegID = DBNull.Value != dr["PreRegID"] ? Convert.ToString(dr["PreRegID"]) : "";
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToInt32(dr["MRN"]) : 0;
                            res.PatientID = DBNull.Value != dr["PatientID"] ? Convert.ToInt32(dr["PatientID"]) : 0;
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DoctorID = DBNull.Value != dr["DoctorID"] ? Convert.ToInt32(dr["DoctorID"]) : 0;
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.OrderDesc = DBNull.Value != dr["OrderDesc"] ? Convert.ToString(dr["OrderDesc"]) : "";
                            res.AccessionNo = DBNull.Value != dr["AccessionNo"] ? Convert.ToString(dr["AccessionNo"]) : "";
                            res.Modality = DBNull.Value != dr["Modality"] ? Convert.ToString(dr["Modality"]) : "";
                            res.ServiceName = DBNull.Value != dr["ServiceName"] ? Convert.ToString(dr["ServiceName"]) : "";
                            res.ChargeID = DBNull.Value != dr["ChargeID"] ? Convert.ToInt32(dr["ChargeID"]) : 0;
                            res.LabTestID = DBNull.Value != dr["LabTestID"] ? Convert.ToInt32(dr["LabTestID"]) : 0;
                            res.ProfileID = DBNull.Value != dr["ProfileID"] ? Convert.ToInt32(dr["ProfileID"]) : 0;
                            res.TestConfig = DBNull.Value != dr["TestConfig"] ? Convert.ToInt32(dr["TestConfig"]) : 0;
                            res.RequisitionID = DBNull.Value != dr["RequisitionID"] ? Convert.ToInt32(dr["RequisitionID"]) : 0;
                            res.STATUS = DBNull.Value != dr["STATUS"] ? Convert.ToString(dr["STATUS"]) : "";
                            res.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";
                            res.ServiceRemarks = DBNull.Value != dr["ServiceRemarks"] ? Convert.ToString(dr["ServiceRemarks"]) : "";
                            res.Priority = DBNull.Value != dr["Priority"] ? Convert.ToString(dr["Priority"]) : "";
                            res.PlannedDt = DBNull.Value != dr["PlannedDt"] ? Convert.ToString(dr["PlannedDt"]) : "";
                            res.PlannedTm = DBNull.Value != dr["PlannedTm"] ? Convert.ToString(dr["PlannedTm"]) : "";
                            res.ReportingDr = DBNull.Value != dr["ReportingDr"] ? Convert.ToString(dr["ReportingDr"]) : "";
                            res.CompletedBy = DBNull.Value != dr["CompletedBy"] ? Convert.ToString(dr["CompletedBy"]) : "";
                            res.CompletedDate = DBNull.Value != dr["CompletedDate"] ? Convert.ToString(dr["CompletedDate"]) : "";
                            res.ReportDate = DBNull.Value != dr["ReportDate"] ? Convert.ToString(dr["ReportDate"]) : "";
                            res.ORDERBY = DBNull.Value != dr["ORDERBY"] ? Convert.ToString(dr["ORDERBY"]) : "";
                            res.CancelFlag = DBNull.Value != dr["CancelFlag"] ? Convert.ToInt32(dr["CancelFlag"]) : 0;
                            res.WardName = DBNull.Value != dr["WardName"] ? Convert.ToString(dr["WardName"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                            res.RegType = DBNull.Value != dr["RegType"] ? Convert.ToString(dr["RegType"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                            


                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


        public List<clsCardiologyLanding> Web_CardiologyLanding(string FromDate, string ToDate)
        {
            List<clsCardiologyLanding> dropdown_DTOs = new List<clsCardiologyLanding>();
            try
            {
                DataSet ds = dataLayer.Web_CardiologyLanding(FromDate, ToDate);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsCardiologyLanding res = new clsCardiologyLanding();
                            res.PatientType = DBNull.Value != dr["PatientType"] ? Convert.ToString(dr["PatientType"]) : "";
                            res.OrderID = DBNull.Value != dr["OrderID"] ? Convert.ToString(dr["OrderID"]) : "";
                            res.PackOrderID = DBNull.Value != dr["PackOrderID"] ? Convert.ToInt32(dr["PackOrderID"]) : 0;
                            res.OrderDate = DBNull.Value != dr["OrderDate"] ? Convert.ToString(dr["OrderDate"]) : "";
                            res.VisitID = DBNull.Value != dr["VisitID"] ? Convert.ToString(dr["VisitID"]) : "";
                            res.PreRegID = DBNull.Value != dr["PreRegID"] ? Convert.ToString(dr["PreRegID"]) : "";
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToInt32(dr["MRN"]) : 0;
                            res.PatientID = DBNull.Value != dr["PatientID"] ? Convert.ToInt32(dr["PatientID"]) : 0;
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DoctorID = DBNull.Value != dr["DoctorID"] ? Convert.ToInt32(dr["DoctorID"]) : 0;
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.OrderDesc = DBNull.Value != dr["OrderDesc"] ? Convert.ToString(dr["OrderDesc"]) : "";
                            res.AccessionNo = DBNull.Value != dr["AccessionNo"] ? Convert.ToString(dr["AccessionNo"]) : "";
                            res.Modality = DBNull.Value != dr["Modality"] ? Convert.ToString(dr["Modality"]) : "";
                            res.ServiceName = DBNull.Value != dr["ServiceName"] ? Convert.ToString(dr["ServiceName"]) : "";
                            res.ChargeID = DBNull.Value != dr["ChargeID"] ? Convert.ToInt32(dr["ChargeID"]) : 0;
                            res.LabTestID = DBNull.Value != dr["LabTestID"] ? Convert.ToInt32(dr["LabTestID"]) : 0;
                            res.ProfileID = DBNull.Value != dr["ProfileID"] ? Convert.ToInt32(dr["ProfileID"]) : 0;
                            res.TestConfig = DBNull.Value != dr["TestConfig"] ? Convert.ToInt32(dr["TestConfig"]) : 0;
                            res.RequisitionID = DBNull.Value != dr["RequisitionID"] ? Convert.ToInt32(dr["RequisitionID"]) : 0;
                            res.STATUS = DBNull.Value != dr["STATUS"] ? Convert.ToString(dr["STATUS"]) : "";
                            res.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";
                            res.ServiceRemarks = DBNull.Value != dr["ServiceRemarks"] ? Convert.ToString(dr["ServiceRemarks"]) : "";
                            res.Priority = DBNull.Value != dr["Priority"] ? Convert.ToString(dr["Priority"]) : "";
                            res.ReportDate = DBNull.Value != dr["ReportDate"] ? Convert.ToString(dr["ReportDate"]) : "";
                            res.ORDERBY = DBNull.Value != dr["ORDERBY"] ? Convert.ToString(dr["ORDERBY"]) : "";
                            res.CancelFlag = DBNull.Value != dr["CancelFlag"] ? Convert.ToInt32(dr["CancelFlag"]) : 0;
                            res.WardName = DBNull.Value != dr["WardName"] ? Convert.ToString(dr["WardName"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                            res.RegType = DBNull.Value != dr["RegType"] ? Convert.ToString(dr["RegType"]) : "";
                            res.Started = DBNull.Value != dr["Started"] ? Convert.ToString(dr["Started"]) : "";
                            res.ResultEntryDate = DBNull.Value != dr["ResultEntryDate"] ? Convert.ToString(dr["ResultEntryDate"]) : "";
                            res.Authenticate = DBNull.Value != dr["Authenticate"] ? Convert.ToString(dr["Authenticate"]) : "";
                            res.ResultCompleted = DBNull.Value != dr["ResultCompleted"] ? Convert.ToString(dr["ResultCompleted"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";

                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        
        public List<clsweb_RadPatientSearch> web_RadPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_RadPatientSearch> dropdown_DTOs = new List<clsweb_RadPatientSearch>();
            try
            {
                DataSet ds = dataLayer.web_RadPatientSearch( FromDate,  ToDate,  MRN,  PatientName,  ApptTime,  DoctName,  Company,  MobileNo,  DeptName,  radmenu);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsweb_RadPatientSearch res = new clsweb_RadPatientSearch();
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            res.Type = DBNull.Value != dr["Type"] ? Convert.ToString(dr["Type"]) : "";
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.Date = DBNull.Value != dr["Date"] ? Convert.ToString(dr["Date"]) : "";
                            res.Time = DBNull.Value != dr["Time"] ? Convert.ToString(dr["Time"]) : "";
                            res.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                            res.Eligibility = DBNull.Value != dr["Eligibility"] ? Convert.ToString(dr["Eligibility"]) : "";
                            res.ReasonForVisit = DBNull.Value != dr["Reason For Visit"] ? Convert.ToString(dr["Reason For Visit"]) : "";
                            res.Country = DBNull.Value != dr["Country"] ? Convert.ToString(dr["Country"]) : "";
                            res.Rad_Online = DBNull.Value != dr["Rad_Online"] ? Convert.ToString(dr["Rad_Online"]) : "";
                            res.AppointmentType = DBNull.Value != dr["AppointmentType"] ? Convert.ToString(dr["AppointmentType"]) : "";
                         

                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

     
        public List<clsweb_NMPatientSearch> web_NMPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_NMPatientSearch> dropdown_DTOs = new List<clsweb_NMPatientSearch>();
            try
            {
                DataSet ds = dataLayer.web_NMPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsweb_NMPatientSearch res = new clsweb_NMPatientSearch();
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            res.Type = DBNull.Value != dr["Type"] ? Convert.ToString(dr["Type"]) : "";
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.Date = DBNull.Value != dr["Date"] ? Convert.ToString(dr["Date"]) : "";
                            res.Time = DBNull.Value != dr["Time"] ? Convert.ToString(dr["Time"]) : "";
                            res.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                            res.Eligibility = DBNull.Value != dr["Eligibility"] ? Convert.ToString(dr["Eligibility"]) : "";
                            res.ReasonForVisit = DBNull.Value != dr["Reason For Visit"] ? Convert.ToString(dr["Reason For Visit"]) : "";
                            res.Country = DBNull.Value != dr["Country"] ? Convert.ToString(dr["Country"]) : "";
                            res.Rad_Online = DBNull.Value != dr["Rad_Online"] ? Convert.ToString(dr["Rad_Online"]) : "";
                            res.AppointmentType = DBNull.Value != dr["AppointmentType"] ? Convert.ToString(dr["AppointmentType"]) : "";


                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


        public List<clsweb_MediScanPatientSearch> web_MediScanPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_MediScanPatientSearch> dropdown_DTOs = new List<clsweb_MediScanPatientSearch>();
            try
            {
                DataSet ds = dataLayer.web_MediScanPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsweb_MediScanPatientSearch res = new clsweb_MediScanPatientSearch();
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            res.Type = DBNull.Value != dr["Type"] ? Convert.ToString(dr["Type"]) : "";
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.Date = DBNull.Value != dr["Date"] ? Convert.ToString(dr["Date"]) : "";
                            res.Time = DBNull.Value != dr["Time"] ? Convert.ToString(dr["Time"]) : "";
                            res.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                            res.Eligibility = DBNull.Value != dr["Eligibility"] ? Convert.ToString(dr["Eligibility"]) : "";
                            res.ReasonForVisit = DBNull.Value != dr["Reason For Visit"] ? Convert.ToString(dr["Reason For Visit"]) : "";
                            res.Country = DBNull.Value != dr["Country"] ? Convert.ToString(dr["Country"]) : "";
                            res.Rad_Online = DBNull.Value != dr["Rad_Online"] ? Convert.ToString(dr["Rad_Online"]) : "";
                            res.AppointmentType = DBNull.Value != dr["AppointmentType"] ? Convert.ToString(dr["AppointmentType"]) : "";


                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
        public List<clsNMLanding_Dtl> Web_NMLanding_Dtl(string FromDate, string ToDate)
        {
            List<clsNMLanding_Dtl> dropdown_DTOs = new List<clsNMLanding_Dtl>();
            try
            {
                DataSet ds = dataLayer.Web_NMLanding_Dtl(FromDate, ToDate);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsNMLanding_Dtl res = new clsNMLanding_Dtl();
                            res.PatientType = DBNull.Value != dr["PatientType"] ? Convert.ToString(dr["PatientType"]) : "";
                            res.PatientVisitType = DBNull.Value != dr["PatientVisitType"] ? Convert.ToString(dr["PatientVisitType"]) : "";
                            res.OrderID = DBNull.Value != dr["OrderID"] ? Convert.ToString(dr["OrderID"]) : "";
                            res.PackOrderID = DBNull.Value != dr["PackOrderID"] ? Convert.ToInt32(dr["PackOrderID"]) : 0;
                            res.OrderDate = DBNull.Value != dr["OrderDate"] ? Convert.ToString(dr["OrderDate"]) : "";
                            res.VisitID = DBNull.Value != dr["VisitID"] ? Convert.ToString(dr["VisitID"]) : "";
                            res.PreRegID = DBNull.Value != dr["PreRegID"] ? Convert.ToString(dr["PreRegID"]) : "";
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToInt32(dr["MRN"]) : 0;
                            res.PatientID = DBNull.Value != dr["PatientID"] ? Convert.ToInt32(dr["PatientID"]) : 0;
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DoctorID = DBNull.Value != dr["DoctorID"] ? Convert.ToInt32(dr["DoctorID"]) : 0;
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.OrderDesc = DBNull.Value != dr["OrderDesc"] ? Convert.ToString(dr["OrderDesc"]) : "";
                            res.AccessionNo = DBNull.Value != dr["AccessionNo"] ? Convert.ToString(dr["AccessionNo"]) : "";
                            res.Modality = DBNull.Value != dr["Modality"] ? Convert.ToString(dr["Modality"]) : "";
                            res.ServiceName = DBNull.Value != dr["ServiceName"] ? Convert.ToString(dr["ServiceName"]) : "";
                            res.ChargeID = DBNull.Value != dr["ChargeID"] ? Convert.ToInt32(dr["ChargeID"]) : 0;
                            res.LabTestID = DBNull.Value != dr["LabTestID"] ? Convert.ToInt32(dr["LabTestID"]) : 0;
                            res.ProfileID = DBNull.Value != dr["ProfileID"] ? Convert.ToInt32(dr["ProfileID"]) : 0;
                            res.TestConfig = DBNull.Value != dr["TestConfig"] ? Convert.ToInt32(dr["TestConfig"]) : 0;
                            res.RequisitionID = DBNull.Value != dr["RequisitionID"] ? Convert.ToInt32(dr["RequisitionID"]) : 0;
                            res.STATUS = DBNull.Value != dr["STATUS"] ? Convert.ToString(dr["STATUS"]) : "";
                            res.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";
                            res.ServiceRemarks = DBNull.Value != dr["ServiceRemarks"] ? Convert.ToString(dr["ServiceRemarks"]) : "";
                            res.Priority = DBNull.Value != dr["Priority"] ? Convert.ToString(dr["Priority"]) : "";
                            res.PlannedDt = DBNull.Value != dr["PlannedDt"] ? Convert.ToString(dr["PlannedDt"]) : "";
                            res.PlannedTm = DBNull.Value != dr["PlannedTm"] ? Convert.ToString(dr["PlannedTm"]) : "";
                            res.ReportingDr = DBNull.Value != dr["ReportingDr"] ? Convert.ToString(dr["ReportingDr"]) : "";
                            res.CompletedBy = DBNull.Value != dr["CompletedBy"] ? Convert.ToString(dr["CompletedBy"]) : "";
                            res.CompletedDate = DBNull.Value != dr["CompletedDate"] ? Convert.ToString(dr["CompletedDate"]) : "";
                            res.ReportDate = DBNull.Value != dr["ReportDate"] ? Convert.ToString(dr["ReportDate"]) : "";
                            res.ORDERBY = DBNull.Value != dr["ORDERBY"] ? Convert.ToString(dr["ORDERBY"]) : "";
                            res.CancelFlag = DBNull.Value != dr["CancelFlag"] ? Convert.ToInt32(dr["CancelFlag"]) : 0;
                            res.WardName = DBNull.Value != dr["WardName"] ? Convert.ToString(dr["WardName"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                            res.RegType = DBNull.Value != dr["RegType"] ? Convert.ToString(dr["RegType"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";

                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<clsWeb_GetRadRequisitionSlipDetail> Web_GetRadRequisitionSlipDetail(string sPatient, string strRegID, string OrderID, string strSampleNo)
        {
            List<clsWeb_GetRadRequisitionSlipDetail> dropdown_DTOs = new List<clsWeb_GetRadRequisitionSlipDetail>();
            try
            {
                DataSet ds = dataLayer.Web_GetRadRequisitionSlipDetail(sPatient, strRegID, OrderID, strSampleNo);
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsWeb_GetRadRequisitionSlipDetail res = new clsWeb_GetRadRequisitionSlipDetail();
                            res.RegNo = DBNull.Value != dr["RegNo"] ? Convert.ToString(dr["RegNo"]) : "";
                            res.LabNo = DBNull.Value != dr["LabNo"] ? Convert.ToString(dr["LabNo"]) : "";
                            res.LabDate = DBNull.Value != dr["LabDate"] ? Convert.ToString(dr["LabDate"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                            res.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                            res.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                            res.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToInt32(dr["TokenNo"]) : 0;
                            res.ChargeName = DBNull.Value != dr["ChargeName"] ? Convert.ToString(dr["ChargeName"]) : "";
                            res.ResultDate = DBNull.Value != dr["ResultDate"] ? Convert.ToString(dr["ResultDate"]) : "";
                            res.ResultTime = DBNull.Value != dr["ResultTime"] ? Convert.ToString(dr["ResultTime"]) : "";
                            res.SampleName = DBNull.Value != dr["SampleName"] ? Convert.ToString(dr["SampleName"]) : "";
                            res.LabNoPrefix = DBNull.Value != dr["LabNoPrefix"] ? Convert.ToString(dr["LabNoPrefix"]) : "";
                            res.LabNoSuffix = DBNull.Value != dr["LabNoSuffix"] ? Convert.ToString(dr["LabNoSuffix"]) : "";
                            res.SampleCollect = DBNull.Value != dr["SampleCollect"] ? Convert.ToString(dr["SampleCollect"]) : "";
                            res.SampleCollectDate = DBNull.Value != dr["SampleCollectDate"] ? Convert.ToString(dr["SampleCollectDate"]) : "";
                            res.AdmisionNo = DBNull.Value != dr["AdmisionNo"] ? Convert.ToInt32(dr["AdmisionNo"]) : 0;
                            res.CollectStatus = DBNull.Value != dr["CollectStatus"] ? Convert.ToString(dr["CollectStatus"]) : "";
                            res.ClinicalDiag = DBNull.Value != dr["ClinicalDiag"] ? Convert.ToString(dr["ClinicalDiag"]) : "";
                            
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
        public List<DepositePatientDtl> Get_PatDepositeDtl(int PatientID)
        {
            List<DepositePatientDtl> res = new List<DepositePatientDtl>();
            List<resDropDown> res1 = new List<resDropDown>();
            DataSet ds = dataLayer.Get_PatDepositeDtl(PatientID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DepositePatientDtl req = new DepositePatientDtl();

                        req.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToInt32(dr["PatientId"]) : 0;
                        req.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        req.AgeInYears = DBNull.Value != dr["AgeInYears"] ? Convert.ToInt32(dr["AgeInYears"]) : 0;
                        req.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";             
                        req.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        req.MaritialStatus = DBNull.Value != dr["MaritialStatus"] ? Convert.ToString(dr["MaritialStatus"]) : "";
                        req.IDtype = DBNull.Value != dr["IDtype"] ? Convert.ToString(dr["IDtype"]) : "";
                        req.IDNo = DBNull.Value != dr["IDNo"] ? Convert.ToString(dr["IDNo"]) : "";
                        req.AvlAmt = DBNull.Value != dr["AvlAmt"] ? Convert.ToInt32(dr["AvlAmt"]) : 0;
                      
                        res.Add(req);

                    }
                }
            }

            return res;

        }

        public List<payment_portal> Get_paymentPortal_Dtl(string frdatae, string todate)
        {
            List<payment_portal> table = new List<payment_portal>();
            try
            {
                DataSet ds = dataLayer.Get_paymentPortal_Dtl(frdatae, todate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            payment_portal DocData = new payment_portal();
                            DocData.SNo = DBNull.Value != dr["SNo"] ? Convert.ToInt32(dr["SNo"]) : 0;
                            DocData.UHID = DBNull.Value != dr["UHID"] ? Convert.ToInt32(dr["UHID"]) : 0;
                            DocData.RefId = DBNull.Value != dr["RefId"] ? Convert.ToString(dr["RefId"]) : "";
                            DocData.RefType = DBNull.Value != dr["RefType"] ? Convert.ToString(dr["RefType"]) : "";
                            DocData.PatRefID = DBNull.Value != dr["PatRefID"] ? Convert.ToString(dr["PatRefID"]) : "";
                            DocData.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            DocData.TransDate = DBNull.Value != dr["TransDate"] ? Convert.ToString(dr["TransDate"]) : "";
                            DocData.Amount = DBNull.Value != dr["Amount"] ? Convert.ToDecimal(dr["Amount"]) : 0;
                            DocData.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            DocData.EMailID = DBNull.Value != dr["EMailID"] ? Convert.ToString(dr["EMailID"]) : "";
                            DocData.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            DocData.PaymentStatus = DBNull.Value != dr["PaymentStatus"] ? Convert.ToString(dr["PaymentStatus"]) : "";
                            DocData.CreatedDate = DBNull.Value != dr["CreatedDate"] ? Convert.ToString(dr["CreatedDate"]) : "";
                            DocData.ModifedDate = DBNull.Value != dr["ModifedDate"] ? Convert.ToString(dr["ModifedDate"]) : "";
                            table.Add(DocData);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;

        }
        public List<reswebPatientDtl> Web_PatientDtl_list(string Type, string search)
        {
            List<reswebPatientDtl> res = new List<reswebPatientDtl>();

            DataSet ds = dataLayer.GetwebPatientDtl(Type, search);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        reswebPatientDtl Patient = new reswebPatientDtl();

                        Patient.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.Yrs = DBNull.Value != dr["Yrs"] ? Convert.ToString(dr["Yrs"]) : "";
                        Patient.Mths = DBNull.Value != dr["Mths"] ? Convert.ToString(dr["Mths"]) : "";
                        Patient.Days = DBNull.Value != dr["Days"] ? Convert.ToString(dr["Days"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<reswebPatientDtl> web_PatientDtl(string Type, string search)
        {
            List<reswebPatientDtl> res = new List<reswebPatientDtl>();

            DataSet ds = dataLayer.web_PatientDtl(Type, search);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        reswebPatientDtl Patient = new reswebPatientDtl();

                        Patient.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.Yrs = DBNull.Value != dr["Yrs"] ? Convert.ToString(dr["Yrs"]) : "";
                        Patient.Mths = DBNull.Value != dr["Mths"] ? Convert.ToString(dr["Mths"]) : "";
                        Patient.Days = DBNull.Value != dr["Days"] ? Convert.ToString(dr["Days"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public clsResult Web_OPBill_Receipt(OPBillRecepitHead request)
        {
            clsResult result = new clsResult();

            DataSet ds = dataLayer.Web_OPBill_Receipt(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.SurrogatedID = DBNull.Value != ds.Tables[0].Rows[0]["SurrogatedID"] ? Convert.ToString(ds.Tables[0].Rows[0]["SurrogatedID"]) : "";
                result.MsgDescp = DBNull.Value != ds.Tables[0].Rows[0]["MsgDescp"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDescp"]) : "";
                result.ServiceOrderNo = DBNull.Value != ds.Tables[0].Rows[0]["ServiceOrderNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["ServiceOrderNo"]) : "";
            }

            return result;
        }

        
        public resQMSDetails WebSave_QMS_Details(req_Save_QMSDetails request)
        {
            resQMSDetails result = new resQMSDetails();

            DataSet ds = dataLayer.WebSave_QMS_Details(request);

            if (ds != null)
            {
                result.tokenNo = DBNull.Value != ds.Tables[0].Rows[0]["TokenNo"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["TokenNo"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }

        public resHouseKeepingList SavePatientDetails(reqimg request )
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.SavePatientDetails(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }


        public resHouseKeepingList import(Patient_Portal_PathModel request)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.import(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }


        public resHouseKeepingList import_v1(Patient_Portal_PathModel request)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.import_v1(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }



        public resHouseKeepingList WebSave_QMS_Details_test(Save_QMSDetails request)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.WebSave_QMS_Details_test(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }

        public List<QMSDetails> Get_QMS_Details(string FromDate, string ToDate, string Type)
        {
            List<QMSDetails> res = new List<QMSDetails>();

            DataSet ds = dataLayer.Get_QMS_Details(FromDate, ToDate, Type);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        QMSDetails Patient = new QMSDetails();

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToInt32(dr["TokenNo"]) : 0;
                        Patient.TokenDate = DBNull.Value != dr["TokenDate"] ? Convert.ToString(dr["TokenDate"]) : "";
                        Patient.StausFlag = DBNull.Value != dr["StausFlag"] ? Convert.ToString(dr["StausFlag"]) : "";
                        Patient.Processing_time = DBNull.Value != dr["Processing_time"] ? Convert.ToString(dr["Processing_time"]) : "";
                        Patient.Completed_time = DBNull.Value != dr["Completed_time"] ? Convert.ToString(dr["Completed_time"]) : "";


                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<QMSDetails_test> Get_QMS_Details_test(string FromDate, string ToDate, string Type)
        {
            List<QMSDetails_test> res = new List<QMSDetails_test>();

            DataSet ds = dataLayer.Get_QMS_Details_test(FromDate, ToDate, Type);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        QMSDetails_test Patient = new QMSDetails_test();

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToInt32(dr["TokenNo"]) : 0;                 
                        Patient.TokenDate = DBNull.Value != dr["TokenDate"] ? Convert.ToString(dr["TokenDate"]) : "";
                        Patient.StausFlag = DBNull.Value != dr["StausFlag"] ? Convert.ToString(dr["StausFlag"]) : "";
                        Patient.Processing_time = DBNull.Value != dr["Processing_time"] ? Convert.ToString(dr["Processing_time"]) : "";
                        Patient.Completed_time = DBNull.Value != dr["Completed_time"] ? Convert.ToString(dr["Completed_time"]) : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }


        public List<resAppointmentList> Get_appointmentList_v1(string FromDate, string ToDate)
        {
            List<resAppointmentList> res = new List<resAppointmentList>();
            DataSet ds = dataLayer.Get_appointmentList_v1(FromDate, ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        resAppointmentList Patient = new resAppointmentList();

                        Patient.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";

                        clsDropDown Salutation = new clsDropDown();
                        Salutation.columnName = DBNull.Value != dr["SalutationName"] ? Convert.ToString(dr["SalutationName"]) : "";
                        Salutation.columnCode = DBNull.Value != dr["SalutationCode"] ? Convert.ToInt32(dr["SalutationCode"]) : 0;
                        Salutation.responseType = "salutation";
                        Patient.Salutation = Salutation;

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        Patient.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";

                        clsDropDown doctor = new clsDropDown();
                        doctor.columnName = DBNull.Value != dr["Doctor"] ? Convert.ToString(dr["Doctor"]) : "";
                        doctor.columnCode = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                        doctor.responseType = "Doctor";
                        Patient.Doctor = doctor;

                        clsDropDown department = new clsDropDown();
                        department.columnName = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
                        department.columnCode = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                        department.responseType = "Department";
                        Patient.Department = department;


                        Patient.AppDate = DBNull.Value != dr["AppDate"] ? Convert.ToString(dr["AppDate"]) : "";
                        Patient.AppTime = DBNull.Value != dr["AppTime"] ? Convert.ToString(dr["AppTime"]) : "";
                        Patient.Reason = DBNull.Value != dr["Reason"] ? Convert.ToString(dr["Reason"]) : "";
                        Patient.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        Patient.ReferralSource = DBNull.Value != dr["ReferralSource"] ? Convert.ToString(dr["ReferralSource"]) : "";
                        Patient.UserName = DBNull.Value != dr["UserName"] ? Convert.ToString(dr["UserName"]) : "";
                        Patient.Bookingdate = DBNull.Value != dr["Bookingdate"] ? Convert.ToString(dr["Bookingdate"]) : "";
                        Patient.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                        Patient.CancelDate = DBNull.Value != dr["CancelDate"] ? Convert.ToString(dr["CancelDate"]) : "";
                        Patient.CancelledBy = DBNull.Value != dr["Cancelledby"] ? Convert.ToString(dr["Cancelledby"]) : "";
                        Patient.CancelledReason = DBNull.Value != dr["CancelledReason"] ? Convert.ToString(dr["CancelledReason"]) : "";
                        Patient.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                        Patient.NoofBills = DBNull.Value != dr["NoofBills"] ? Convert.ToString(dr["NoofBills"]) : "";
                        Patient.AppointmentId = DBNull.Value != dr["AppointmentId"] ? Convert.ToInt32(dr["AppointmentId"]) : 0;
                        Patient.AppPatienttId = DBNull.Value != dr["AppPatienttId"] ? Convert.ToInt32(dr["AppPatienttId"]) : 0;


                        res.Add(Patient);

                    }
                }
            }
            return res;
        }

        public List<resAppointmentListALL> appointmentList_All(string FromDate, string ToDate)
        {
            List<resAppointmentListALL> res = new List<resAppointmentListALL>();
            DataSet ds = dataLayer.appointmentList_All(FromDate, ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        resAppointmentListALL Patient = new resAppointmentListALL();

                        Patient.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";

                        clsDropDown Salutation = new clsDropDown();
                        Salutation.columnName = DBNull.Value != dr["SalutationName"] ? Convert.ToString(dr["SalutationName"]) : "";
                        Salutation.columnCode = DBNull.Value != dr["SalutationCode"] ? Convert.ToInt32(dr["SalutationCode"]) : 0;
                        Salutation.responseType = "salutation";
                        Patient.Salutation = Salutation;

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        Patient.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";

                        clsDropDown doctor = new clsDropDown();
                        doctor.columnName = DBNull.Value != dr["Doctor"] ? Convert.ToString(dr["Doctor"]) : "";
                        doctor.columnCode = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                        doctor.responseType = "Doctor";
                        Patient.Doctor = doctor;

                        clsDropDown department = new clsDropDown();
                        department.columnName = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
                        department.columnCode = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                        department.responseType = "Department";
                        Patient.Department = department;


                        Patient.AppDate = DBNull.Value != dr["AppDate"] ? Convert.ToString(dr["AppDate"]) : "";
                        Patient.AppTime = DBNull.Value != dr["AppTime"] ? Convert.ToString(dr["AppTime"]) : "";
                        Patient.Reason = DBNull.Value != dr["Reason"] ? Convert.ToString(dr["Reason"]) : "";
                        Patient.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        Patient.ReferralSource = DBNull.Value != dr["ReferralSource"] ? Convert.ToString(dr["ReferralSource"]) : "";
                        Patient.UserName = DBNull.Value != dr["UserName"] ? Convert.ToString(dr["UserName"]) : "";
                        Patient.Bookingdate = DBNull.Value != dr["Bookingdate"] ? Convert.ToString(dr["Bookingdate"]) : "";
                        Patient.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                        Patient.CancelDate = DBNull.Value != dr["CancelDate"] ? Convert.ToString(dr["CancelDate"]) : "";
                        Patient.CancelledBy = DBNull.Value != dr["Cancelledby"] ? Convert.ToString(dr["Cancelledby"]) : "";
                        Patient.CancelledReason = DBNull.Value != dr["CancelledReason"] ? Convert.ToString(dr["CancelledReason"]) : "";
                        Patient.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                        Patient.NoofBills = DBNull.Value != dr["NoofBills"] ? Convert.ToString(dr["NoofBills"]) : "";
                        Patient.AppointmentId = DBNull.Value != dr["AppointmentId"] ? Convert.ToInt32(dr["AppointmentId"]) : 0;
                        Patient.AppPatienttId = DBNull.Value != dr["AppPatienttId"] ? Convert.ToInt32(dr["AppPatienttId"]) : 0;
                        Patient.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                        Patient.DepId = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                        Patient.Abkg_AppointmentStartDate_dt = DBNull.Value != dr["Abkg_AppointmentStartDate_dt"] ? Convert.ToString(dr["Abkg_AppointmentStartDate_dt"]) : "";


                        res.Add(Patient);

                    }
                }
            }
            return res;
        }
  

        public List<Newpatient_dtlRes> GetPatientDtl(string mobileno)
        {
            List<Newpatient_dtlRes> res = new List<Newpatient_dtlRes>();

            DataSet ds = dataLayer.GetPatientnew(mobileno);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        Newpatient_dtlRes response = new Newpatient_dtlRes();

                        response.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        response.AppointmentId = DBNull.Value != dr["AppointmentId"] ? Convert.ToInt32(dr["AppointmentId"]) : 0;
                        response.AppDate = DBNull.Value != dr["AppDate"] ? Convert.ToString(dr["AppDate"]) : "";
                        response.AppTime = DBNull.Value != dr["AppTime"] ? Convert.ToString(dr["AppTime"]) : "";
                        response.Doctor = DBNull.Value != dr["Doctor"] ? Convert.ToString(dr["Doctor"]) : "";
                        response.Charges = DBNull.Value != dr["Charges"] ? Convert.ToInt32(dr["Charges"]) : 0;
                        response.DepId = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                        response.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                        response.UHID = DBNull.Value != dr["Uhid"] ? Convert.ToString(dr["Uhid"]) : "";
                        response.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        response.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";

                        res.Add(response);
                    }
                }
            }

            return res;
        }

        public List<Res_ListOfLobbyToken> Get_LobbyTokenType(string TokenType)
        {
            List<Res_ListOfLobbyToken> res = new List<Res_ListOfLobbyToken>();

            DataSet ds = dataLayer.Get_LobbyTokenType(TokenType);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        Res_ListOfLobbyToken response = new Res_ListOfLobbyToken();

                        response.TokenID = DBNull.Value != dr["TokenID"] ? Convert.ToInt32(dr["TokenID"]) : 0;
                        response.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        response.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        response.TokenDate = DBNull.Value != dr["TokenDate"] ? Convert.ToString(dr["TokenDate"]) : "";
                        response.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToString(dr["TokenNo"]) : "";
                        response.TokenType = DBNull.Value != dr["TokenType"] ? Convert.ToString(dr["TokenType"]) : "";
                        response.StausFlag = DBNull.Value != dr["StausFlag"] ? Convert.ToString(dr["StausFlag"]) : "";
                        response.Processing_time = DBNull.Value != dr["Processing_time"] ? Convert.ToString(dr["Processing_time"]) : "";
                        response.Completed_time = DBNull.Value != dr["Completed_time"] ? Convert.ToString(dr["Completed_time"]) : "";
                      
                        res.Add(response);
                    }
                }
            }

            return res;
        }


        public List<resPackagePriceList> Get_PackagePriceList()
        {
            List<resPackagePriceList> res = new List<resPackagePriceList>();

            DataSet ds = dataLayer.PackagePriceList();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resPackagePriceList Patient = new resPackagePriceList();


                        Patient.No = DBNull.Value != dr["No"] ? Convert.ToString(dr["No"]) : "";
                        Patient.ServiceGroup = DBNull.Value != dr["Service Group"] ? Convert.ToString(dr["Service Group"]) : "";
                        Patient.ServiceCode = DBNull.Value != dr["Service Code"] ? Convert.ToString(dr["Service Code"]) : "";
                        Patient.ServiceName = DBNull.Value != dr["Service Name"] ? Convert.ToString(dr["Service Name"]) : "";
                        Patient.ServiceRate = DBNull.Value != dr["ServiceRate"] ? Convert.ToString(dr["ServiceRate"]) : "";
                        Patient.ChargeId = DBNull.Value != dr["ChargeId"] ? Convert.ToString(dr["ChargeId"]) : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<resAppointmentList> Get_appointmentList(string Search)
        {
            List<resAppointmentList> res = new List<resAppointmentList>();
            DataSet ds = dataLayer.Get_appointmentList(Search);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        resAppointmentList Patient = new resAppointmentList();

                        Patient.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";

                        clsDropDown Salutation = new clsDropDown();
                        Salutation.columnName = DBNull.Value != dr["SalutationName"] ? Convert.ToString(dr["SalutationName"]) : "";
                        Salutation.columnCode = DBNull.Value != dr["SalutationCode"] ? Convert.ToInt32(dr["SalutationCode"]) : 0;
                        Salutation.responseType = "salutation";
                        Patient.Salutation = Salutation;

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        Patient.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";

                        clsDropDown doctor = new clsDropDown();
                        doctor.columnName = DBNull.Value != dr["Doctor"] ? Convert.ToString(dr["Doctor"]) : "";
                        doctor.columnCode = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                        doctor.responseType = "Doctor";
                        Patient.Doctor = doctor;

                        clsDropDown department = new clsDropDown();
                        department.columnName = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
                        department.columnCode = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                        department.responseType = "Department";
                        Patient.Department = department;


                        Patient.AppDate = DBNull.Value != dr["AppDate"] ? Convert.ToString(dr["AppDate"]) : "";
                        Patient.AppTime = DBNull.Value != dr["AppTime"] ? Convert.ToString(dr["AppTime"]) : "";
                        Patient.Reason = DBNull.Value != dr["Reason"] ? Convert.ToString(dr["Reason"]) : "";
                        Patient.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        Patient.ReferralSource = DBNull.Value != dr["ReferralSource"] ? Convert.ToString(dr["ReferralSource"]) : "";
                        Patient.UserName = DBNull.Value != dr["UserName"] ? Convert.ToString(dr["UserName"]) : "";
                        Patient.Bookingdate = DBNull.Value != dr["Bookingdate"] ? Convert.ToString(dr["Bookingdate"]) : "";
                        Patient.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                        Patient.CancelDate = DBNull.Value != dr["CancelDate"] ? Convert.ToString(dr["CancelDate"]) : "";
                        Patient.CancelledBy = DBNull.Value != dr["Cancelledby"] ? Convert.ToString(dr["Cancelledby"]) : "";
                        Patient.CancelledReason = DBNull.Value != dr["CancelledReason"] ? Convert.ToString(dr["CancelledReason"]) : "";
                        Patient.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                        Patient.NoofBills = DBNull.Value != dr["NoofBills"] ? Convert.ToString(dr["NoofBills"]) : "";
                        Patient.AppointmentId = DBNull.Value != dr["AppointmentId"] ? Convert.ToInt32(dr["AppointmentId"]) : 0;
                        Patient.AppPatienttId = DBNull.Value != dr["AppPatienttId"] ? Convert.ToInt32(dr["AppPatienttId"]) : 0;

                        res.Add(Patient);

                    }
                }
            }
            return res;
        }


        public List<DepositeDtl_ReprintList> Get_Web_Deposite_Reprint(string FromDate, string ToDate, int Uhid)
        {
            List<DepositeDtl_ReprintList> res = new List<DepositeDtl_ReprintList>();
            DataSet ds = dataLayer.Get_Web_Deposite_Reprint(FromDate, ToDate, Uhid);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        DepositeDtl_ReprintList Patient = new DepositeDtl_ReprintList();

                        Patient.Depositno = DBNull.Value != dr["Depositno"] ? Convert.ToString(dr["Depositno"]) : "";
                        Patient.Pin = DBNull.Value != dr["Pin"] ? Convert.ToString(dr["Pin"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.SALUTATION = DBNull.Value != dr["SALUTATION"] ? Convert.ToString(dr["SALUTATION"]) : "";
                        Patient.DepositDate = DBNull.Value != dr["DepositDate"] ? Convert.ToString(dr["DepositDate"]) : "";
                        Patient.Amount = DBNull.Value != dr["Amount"] ? Convert.ToInt32(dr["Amount"]) : 0;
                        Patient.DepositType = DBNull.Value != dr["DepositType"] ? Convert.ToString(dr["DepositType"]) : "";


                        res.Add(Patient);

                    }
                }
            }
            return res;
        }


        public List<DepositeReprint_OutputDtl> Get_DepositeReprintOutput(string ReceiptNo)
        {
            List<DepositeReprint_OutputDtl> res = new List<DepositeReprint_OutputDtl>();
            DataSet ds = dataLayer.Get_DepositeReprintOutput(ReceiptNo);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        DepositeReprint_OutputDtl Patient = new DepositeReprint_OutputDtl();

                        Patient.PatientID = DBNull.Value != dr["PatientID"] ? Convert.ToInt32(dr["PatientID"]) : 0;
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.ADDRESS1 = DBNull.Value != dr["ADDRESS1"] ? Convert.ToString(dr["ADDRESS1"]) : "";
                        Patient.ADDRESS2 = DBNull.Value != dr["ADDRESS2"] ? Convert.ToString(dr["ADDRESS2"]) : "";
                        Patient.ADDRESS3 = DBNull.Value != dr["ADDRESS3"] ? Convert.ToString(dr["ADDRESS3"]) : "";
                        Patient.CITY = DBNull.Value != dr["CITY"] ? Convert.ToString(dr["CITY"]) : "";
                        Patient.ZIP = DBNull.Value != dr["ZIP"] ? Convert.ToString(dr["ZIP"]) : "";
                        Patient.State = DBNull.Value != dr["State"] ? Convert.ToString(dr["State"]) : "";
                        Patient.COUNTRY = DBNull.Value != dr["COUNTRY"] ? Convert.ToString(dr["COUNTRY"]) : "";
                        Patient.AMOUNT = DBNull.Value != dr["AMOUNT"] ? Convert.ToInt32(dr["AMOUNT"]) : 0;
                        Patient.ReceiptNo = DBNull.Value != dr["ReceiptNo"] ? Convert.ToString(dr["ReceiptNo"]) : "";
                        Patient.PAYDATE = DBNull.Value != dr["PAYDATE"] ? Convert.ToString(dr["PAYDATE"]) : "";
                        Patient.VoucherNo = DBNull.Value != dr["VoucherNo"] ? Convert.ToString(dr["VoucherNo"]) : "";
                        Patient.CASHIER = DBNull.Value != dr["CASHIER"] ? Convert.ToString(dr["CASHIER"]) : "";
                        Patient.CASHIERID = DBNull.Value != dr["CASHIERID"] ? Convert.ToString(dr["CASHIERID"]) : "";
                        Patient.Payment_Type = DBNull.Value != dr["Payment_Type"] ? Convert.ToString(dr["Payment_Type"]) : "";

                        res.Add(Patient);

                    }
                }
            }
            return res;
        }

        public resHouseKeepingList Get_WEB_SP_QMSStatus_Dtl(string PatientName, string MobileNo, int PatType)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.Get_WEB_SP_QMSStatus_Dtl(PatientName, MobileNo, PatType);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }


        public resHouseKeepingList RadiologyAppointmentStatus(string DoctorName, int UHID, int APPID, int PatType)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.RadiologyAppointmentStatus(DoctorName, UHID, APPID, PatType);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }


        public resHouseKeepingList RadiologyAppointmentStatus_v1(string DoctorName, int UHID, int APPID, string PatType)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.RadiologyAppointmentStatus_v1(DoctorName, UHID, APPID, PatType);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }
        public resDaywiseQMSList Get_DaywiseQMS_Data_V1()
        {
            resDaywiseQMSList result = new resDaywiseQMSList();

            DataSet ds = dataLayer.Get_DaywiseQMS_Data_V1();

            if (ds != null)
            {
                result.PatientName = DBNull.Value != ds.Tables[0].Rows[0]["PatientName"] ? Convert.ToString(ds.Tables[0].Rows[0]["PatientName"]) : "";
                result.TokenNo = DBNull.Value != ds.Tables[0].Rows[0]["TokenNo"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["TokenNo"]) : 0;
                result.TokenType = DBNull.Value != ds.Tables[0].Rows[0]["TokenType"] ? Convert.ToString(ds.Tables[0].Rows[0]["TokenType"]) : "";
                result.Status = DBNull.Value != ds.Tables[0].Rows[0]["Status"] ? Convert.ToString(ds.Tables[0].Rows[0]["Status"]) : "";
                
            }

            return result;
        }

        public List<resQMSListTV> Get_QMS_TVData()
        {
            List<resQMSListTV> res = new List<resQMSListTV>();
            DataSet ds = dataLayer.Get_QMS_TVData();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        resQMSListTV result = new resQMSListTV();

                        result.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        result.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToInt32(dr["TokenNo"]) : 0;
                        result.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";

                        res.Add(result);

                    }
                }
            }
            return res;
        }

    
        public List<resimgList> GetImageDetails( )
        {
            List<resimgList> res = new List<resimgList>();
            DataSet ds = dataLayer.GetImageDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resimgList result = new resimgList();

                        result.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        result.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        result.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        result.DocumentPath = DBNull.Value != dr["DocumentPath"] ? Convert.ToString(dr["DocumentPath"]) : "";
                        result.LastModifiedDate = DBNull.Value != dr["LastModifiedDate"] ? Convert.ToString(dr["LastModifiedDate"]) : "";
                        result.DocumentName = DBNull.Value != dr["DocumentName"] ? Convert.ToString(dr["DocumentName"]) : "";
                        result.TempPath_FileName = DBNull.Value != dr["TempPath_FileName"] ? Convert.ToString(dr["TempPath_FileName"]) : "";
           
                        res.Add(result);

                    }
                }
            }
            return res;
        }

        public resHouseKeepingList UpdateQMSStatus_Dtl(Save_QMSDetails req)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.UpdateQMSStatus_Dtl(req);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }

        public resHouseKeepingList UpdateQMSStatus_Dtl_test(Save_QMSDetails req)
        {
            resHouseKeepingList result = new resHouseKeepingList();

            DataSet ds = dataLayer.UpdateQMSStatus_Dtl_test(req);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }

        public List<resOPList> Get_opList(string Type, String Search)
        {
            List<resOPList> res = new List<resOPList>();
            DataSet ds = dataLayer.Get_opList(Type, Search);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        resOPList Patient = new resOPList();
                        clsDropDown doctor = new clsDropDown();
                        clsDropDown department = new clsDropDown();
                        Patient.SNO = DBNull.Value != dr["SNO"] ? Convert.ToString(dr["SNO"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.VisitID = DBNull.Value != dr["VisitID"] ? Convert.ToString(dr["VisitID"]) : "";
                        Patient.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                        Patient.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToString(dr["TokenNo"]) : "";
                        Patient.PartyName = DBNull.Value != dr["PartyName"] ? Convert.ToString(dr["PartyName"]) : "";
                        Patient.RegTyp = DBNull.Value != dr["RegTyp"] ? Convert.ToString(dr["RegTyp"]) : "";
                        Patient.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";
                        Patient.RegId = DBNull.Value != dr["RegId"] ? Convert.ToString(dr["RegId"]) : "";
                        Patient.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        Patient.EmailID = DBNull.Value != dr["EmailID"] ? Convert.ToString(dr["EmailID"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        department.columnName = DBNull.Value != dr["DeptName"] ? Convert.ToString(dr["DeptName"]) : "";
                        department.columnCode = DBNull.Value != dr["DepID"] ? Convert.ToInt32(dr["DepID"]) : 0;
                        department.responseType = "Department";
                        Patient.Department = department;

                        doctor.columnName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        doctor.columnCode = DBNull.Value != dr["DocID"] ? Convert.ToInt32(dr["DocID"]) : 0;
                        doctor.responseType = "Doctor";
                        Patient.Doctor = doctor;

                        res.Add(Patient);

                    }
                }
            }
            return res;
        }

        public List<clsDropDown> GetvisitType(string type)
        {
            List<clsDropDown> reqList = new List<clsDropDown>();
            DataSet ds = dataLayer.GetVisitData(type);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDropDown req = new clsDropDown();

                        req.columnCode = DBNull.Value != dr["columnCode"] ? Convert.ToInt32(dr["columnCode"]) : 0;
                        req.columnName = DBNull.Value != dr["columnName"] ? Convert.ToString(dr["columnName"]) : "";
                        req.responseType = "visitType";
                        reqList.Add(req);
                    }
                }
            }

            return reqList;
        }

        public clsPatientRegistrationPdf GetPatientRegOutPutPdf(int RegId)
        {
            clsPatientRegistrationPdf acess = new clsPatientRegistrationPdf();
            DataSet ds = dataLayer.GetPatientRegOutPutPdf(RegId);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsPatientRegistrationPdf po = new clsPatientRegistrationPdf();

                        po.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToInt64(dr["PatientId"]) : 0;
                        po.RegDate = DBNull.Value != dr["RegDate"] ? Convert.ToString(dr["RegDate"]) : "";
                        po.PatientFirstName = DBNull.Value != dr["PatientFirstName"] ? Convert.ToString(dr["PatientFirstName"]) : "";
                        po.AgeOfPatient = DBNull.Value != dr["AgeOfPatient"] ? Convert.ToString(dr["AgeOfPatient"]) : "";
                        po.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";
                        po.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        po.StateCode = DBNull.Value != dr["StateCode"] ? Convert.ToString(dr["StateCode"]) : "";
                        po.CountryName = DBNull.Value != dr["CountryName"] ? Convert.ToString(dr["CountryName"]) : "";
                        po.ConAddress1 = DBNull.Value != dr["ConAddress1"] ? Convert.ToString(dr["ConAddress1"]) : "";
                        po.ConAddress2 = DBNull.Value != dr["ConAddress2"] ? Convert.ToString(dr["ConAddress2"]) : "";
                        po.ConAddress3 = DBNull.Value != dr["ConAddress3"] ? Convert.ToString(dr["ConAddress3"]) : "";
                        po.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        po.PostBoxNo = DBNull.Value != dr["PostBoxNo"] ? Convert.ToString(dr["PostBoxNo"]) : "";
                        po.DeptName = DBNull.Value != dr["DeptName"] ? Convert.ToString(dr["DeptName"]) : "";
                        po.InvoiceNo = DBNull.Value != dr["InvoiceNo"] ? Convert.ToString(dr["InvoiceNo"]) : "";
                        po.MobileNumber = DBNull.Value != dr["MobileNumber"] ? Convert.ToString(dr["MobileNumber"]) : "";
                        po.AltMobNumber = DBNull.Value != dr["AltMobNumber"] ? Convert.ToString(dr["AltMobNumber"]) : "";
                        po.PatientStatus = DBNull.Value != dr["PatientStatus"] ? Convert.ToString(dr["PatientStatus"]) : "";
                        po.ReligionName = DBNull.Value != dr["ReligionName"] ? Convert.ToString(dr["ReligionName"]) : "";
                        po.RaceName = DBNull.Value != dr["RaceName"] ? Convert.ToString(dr["RaceName"]) : "";
                        po.OccupationName = DBNull.Value != dr["OccupationName"] ? Convert.ToString(dr["OccupationName"]) : "";
                        po.MaritialStatus = DBNull.Value != dr["MaritialStatus"] ? Convert.ToString(dr["MaritialStatus"]) : "";
                        po.OfficePhone1 = DBNull.Value != dr["OfficePhone1"] ? Convert.ToString(dr["OfficePhone1"]) : "";
                        po.HomePhone1 = DBNull.Value != dr["HomePhone1"] ? Convert.ToString(dr["HomePhone1"]) : "";
                        po.EmailId = DBNull.Value != dr["EmailId"] ? Convert.ToString(dr["EmailId"]) : "";
                        po.Fax = DBNull.Value != dr["Fax"] ? Convert.ToString(dr["Fax"]) : "";
                        po.ReferralSource = DBNull.Value != dr["ReferralSource"] ? Convert.ToString(dr["ReferralSource"]) : "";
                        po.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                        po.Salutation = DBNull.Value != dr["Salutation"] ? Convert.ToString(dr["Salutation"]) : "";
                        po.CityCode = DBNull.Value != dr["CityCode"] ? Convert.ToString(dr["CityCode"]) : "";
                        po.KinName = DBNull.Value != dr["KinName"] ? Convert.ToString(dr["KinName"]) : "";
                        po.KinRelation = DBNull.Value != dr["KinRelation"] ? Convert.ToString(dr["KinRelation"]) : "";
                        po.KinPhoneResi = DBNull.Value != dr["KinPhoneResi"] ? Convert.ToString(dr["KinPhoneResi"]) : "";
                        po.KinPhoneOff1 = DBNull.Value != dr["KinPhoneOff1"] ? Convert.ToString(dr["KinPhoneOff1"]) : "";
                        po.KinAddress = DBNull.Value != dr["KinAddress"] ? Convert.ToString(dr["KinAddress"]) : "";
                        po.KinAddress1 = DBNull.Value != dr["KinAddress1"] ? Convert.ToString(dr["KinAddress1"]) : "";
                        po.KinAddress2 = DBNull.Value != dr["KinAddress2"] ? Convert.ToString(dr["KinAddress2"]) : "";
                        po.KinAddress3 = DBNull.Value != dr["KinAddress3"] ? Convert.ToString(dr["KinAddress3"]) : "";
                        po.PatIDNo = DBNull.Value != dr["PatIDNo"] ? Convert.ToString(dr["PatIDNo"]) : "";
                        po.KinCountry = DBNull.Value != dr["KinCountry"] ? Convert.ToString(dr["KinCountry"]) : "";
                        po.KinRltion = DBNull.Value != dr["KinRltion"] ? Convert.ToString(dr["KinRltion"]) : "";
                        po.KinPostalCode = DBNull.Value != dr["KinPostalCode"] ? Convert.ToString(dr["KinPostalCode"]) : "";
                        po.KinMobileNumber = DBNull.Value != dr["KinMobileNumber"] ? Convert.ToString(dr["KinMobileNumber"]) : "";
                        po.KinFax = DBNull.Value != dr["KinFax"] ? Convert.ToString(dr["KinFax"]) : "";
                        po.KinEmail = DBNull.Value != dr["KinEmail"] ? Convert.ToString(dr["KinEmail"]) : "";
                        po.KinStateCode = DBNull.Value != dr["KinStateCode"] ? Convert.ToString(dr["KinStateCode"]) : "";
                        po.KinCityCode = DBNull.Value != dr["KinCityCode"] ? Convert.ToString(dr["KinCityCode"]) : "";
                        po.VIPPATIENT = DBNull.Value != dr["VIPPATIENT"] ? Convert.ToString(dr["VIPPATIENT"]) : "";
                        po.SelfEligible = DBNull.Value != dr["SelfEligible"] ? Convert.ToString(dr["SelfEligible"]) : "";
                        po.RegisteredUser = DBNull.Value != dr["RegisteredUser"] ? Convert.ToString(dr["RegisteredUser"]) : "";
                        po.RegisteredDateTime = DBNull.Value != dr["RegisteredDateTime"] ? Convert.ToString(dr["RegisteredDateTime"]) : "";
                        po.IDTypeCd = DBNull.Value != dr["IDTypeCd"] ? Convert.ToInt32(dr["IDTypeCd"]) : 0;
                        po.IDName = DBNull.Value != dr["IDName"] ? Convert.ToString(dr["IDName"]) : "";
                        po.LanguageName = DBNull.Value != dr["LanguageName"] ? Convert.ToString(dr["LanguageName"]) : "";
                        po.NameofEmp = DBNull.Value != dr["NameofEmp"] ? Convert.ToString(dr["NameofEmp"]) : "";
                        po.Designation = DBNull.Value != dr["Designation"] ? Convert.ToString(dr["Designation"]) : "";
                        po.Annual_Income = DBNull.Value != dr["Annual_Income"] ? Convert.ToInt32(dr["Annual_Income"]) : 0;
                        po.ReferralSourceId = DBNull.Value != dr["ReferralSourceId"] ? Convert.ToInt32(dr["ReferralSourceId"]) : 0;
                        po.OtherRemarks = DBNull.Value != dr["OtherRemarks"] ? Convert.ToString(dr["OtherRemarks"]) : "";
                        po.Annual_Incomebelow = DBNull.Value != dr["Annual_Incomebelow"] ? Convert.ToInt32(dr["Annual_Incomebelow"]) : 0;
                        po.Annual_IncomeAbove = DBNull.Value != dr["Annual_IncomeAbove"] ? Convert.ToInt32(dr["Annual_IncomeAbove"]) : 0;
                        po.VistiType = DBNull.Value != dr["VistiType"] ? Convert.ToString(dr["VistiType"]) : "";
                        po.Symptomscnt = DBNull.Value != dr["Symptomscnt"] ? Convert.ToInt32(dr["Symptomscnt"]) : 0;
                        po.historyoffevercnt = DBNull.Value != dr["historyoffevercnt"] ? Convert.ToInt32(dr["historyoffevercnt"]) : 0;
                        po.outofcountrycnt = DBNull.Value != dr["outofcountrycnt"] ? Convert.ToInt32(dr["outofcountrycnt"]) : 0;
                        po.diseaseoutbreakcnt = DBNull.Value != dr["diseaseoutbreakcnt"] ? Convert.ToInt32(dr["diseaseoutbreakcnt"]) : 0;
                        po.healthcareworkercnt = DBNull.Value != dr["healthcareworkercnt"] ? Convert.ToInt32(dr["healthcareworkercnt"]) : 0;
                        po.diseasecnt = DBNull.Value != dr["diseasecnt"] ? Convert.ToInt32(dr["diseasecnt"]) : 0;
                        po.diarrheasymptomscnt = DBNull.Value != dr["diarrheasymptomscnt"] ? Convert.ToInt32(dr["diarrheasymptomscnt"]) : 0;
                        po.activeTBcnt = DBNull.Value != dr["activeTBcnt"] ? Convert.ToInt32(dr["activeTBcnt"]) : 0;
                        po.chickenpox = DBNull.Value != dr["chickenpox"] ? Convert.ToInt32(dr["chickenpox"]) : 0;
                        po.measles = DBNull.Value != dr["measles"] ? Convert.ToInt32(dr["measles"]) : 0;
                        po.mumps = DBNull.Value != dr["mumps"] ? Convert.ToInt32(dr["mumps"]) : 0;
                        po.rubella = DBNull.Value != dr["rubella"] ? Convert.ToInt32(dr["rubella"]) : 0;
                        acess = po;

                    }
                }
            }
            return acess;
        }

        public List<reqInvoice_Reprint_List> web_Invoice_Reprint_List_procedure(string FromDate, string ToDate, string type, string search)
        {
            List<reqInvoice_Reprint_List> dropdown_DTOs = new List<reqInvoice_Reprint_List>();
            try
            {
                DataSet ds = dataLayer.OpInvoice_Reprint_List(FromDate, ToDate, type, search);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            reqInvoice_Reprint_List res = new reqInvoice_Reprint_List();

                            res.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToInt32(dr["Age"]) : 0;
                            res.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                            res.Regid = DBNull.Value != dr["RegId"] ? Convert.ToInt32(dr["RegId"]) : 0;
                            res.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                            res.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : " ";
                            res.BillNum = DBNull.Value != dr["BillNum"] ? Convert.ToInt32(dr["BillNum"]) : 0;
                            res.InternalNo = DBNull.Value != dr["InternalNo"] ? Convert.ToInt32(dr["InternalNo"]) : 0;
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : " ";
                            res.BillDate = DBNull.Value != dr["BillDate"] ? Convert.ToString(dr["BillDate"]) : " ";
                            res.BillAmount = DBNull.Value != dr["BillAmount"] ? Convert.ToInt32(dr["BillAmount"]) : 0;
                            res.SelfAmount = DBNull.Value != dr["SelfAmount"] ? Convert.ToInt32(dr["SelfAmount"]) : 0;
                            res.PartyAmount = DBNull.Value != dr["PartyAmount"] ? Convert.ToInt32(dr["PartyAmount"]) : 0;
                            res.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                          //  res.DepartmentCode = DBNull.Value != dr["DepartmentCode"] ? Convert.ToInt32(dr["DepartmentCode"]) : 0;
                          //  res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.UserId = DBNull.Value != dr["UserId"] ? Convert.ToString(dr["UserId"]) : "";
                            res.ISCancelled = DBNull.Value != dr["ISCancelled"] ? Convert.ToInt32(dr["ISCancelled"]) : 0;
                            res.PartyCode = DBNull.Value != dr["PartyCode"] ? Convert.ToString(dr["PartyCode"]) : "";
                            res.BillStatus = DBNull.Value != dr["BillStatus"] ? Convert.ToString(dr["BillStatus"]) : "";
                            res.ins = DBNull.Value != dr["ins"] ? Convert.ToInt32(dr["ins"]) : 0;                           
                            res.PartyName = DBNull.Value != dr["PartyName"] ? Convert.ToString(dr["PartyName"]) : "";
                           // res.Mobileno = DBNull.Value != dr["Mobileno"] ? Convert.ToString(dr["Mobileno"]) : "";
                          //  res.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";

                            dropdown_DTOs.Add(res);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
        public List<cls_Patient_venue> Package_Patient_venue(string RefDateTime)
        {
            List<cls_Patient_venue> dropdown_DTOs = new List<cls_Patient_venue>();
            try
            {
                DataSet ds = dataLayer.Package_Patient_venue(RefDateTime);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_Patient_venue res = new cls_Patient_venue();

                            res.patientId = DBNull.Value != dr["patientId"] ? Convert.ToString(dr["patientId"]) : "";
                            res.departmentId = DBNull.Value != dr["departmentId"] ? Convert.ToString(dr["departmentId"]) : "";
                            res.VisitNumber = DBNull.Value != dr["VisitNumber"] ? Convert.ToString(dr["VisitNumber"]) : "";
                            res.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                            res.PackageCode = DBNull.Value != dr["PackageCode"] ? Convert.ToString(dr["PackageCode"]) : "";
                            res.Packagename = DBNull.Value != dr["Packagename"] ? Convert.ToString(dr["Packagename"]) : "";

                            dropdown_DTOs.Add(res);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
        public List<cls_Patient_venue_temp> Get_PatientVenue_temp()
        {
            List<cls_Patient_venue_temp> dropdown_DTOs = new List<cls_Patient_venue_temp>();
            try
            {
                DataSet ds = dataLayer.Get_PatientVenue_temp();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_Patient_venue_temp res = new cls_Patient_venue_temp();

                            res.patientId = DBNull.Value != dr["patientId"] ? Convert.ToString(dr["patientId"]) : "";
                            res.VisitNumber = DBNull.Value != dr["VisitNumber"] ? Convert.ToString(dr["VisitNumber"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";                       
                            res.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                            res.testcode = DBNull.Value != dr["testcode"] ? Convert.ToString(dr["testcode"]) : "";
                            res.TestLocation = DBNull.Value != dr["TestLocation"] ? Convert.ToString(dr["TestLocation"]) : "";
                            res.Statusflag = DBNull.Value != dr["Statusflag"] ? Convert.ToString(dr["Statusflag"]) : "";
                            res.Activeflag = DBNull.Value != dr["Activeflag"] ? Convert.ToString(dr["Activeflag"]) : "";

                            dropdown_DTOs.Add(res);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<cls_Patient_master> Package_master()
        {
            List<cls_Patient_master> dropdown_DTOs = new List<cls_Patient_master>();
            try
            {
                DataSet ds = dataLayer.Package_master();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_Patient_master res = new cls_Patient_master();

                            res.packageid = DBNull.Value != dr["packageid"] ? Convert.ToString(dr["packageid"]) : "";
                            res.packagename = DBNull.Value != dr["packagename"] ? Convert.ToString(dr["packagename"]) : "";                           
      
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public List<cls_PatientVenue_temp> PatientVenue_temp()
        {
            List<cls_PatientVenue_temp> dropdown_DTOs = new List<cls_PatientVenue_temp>();
            try
            {
                DataSet ds = dataLayer.PatientVenue_temp();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_PatientVenue_temp res = new cls_PatientVenue_temp();
                              
                            res.patientId = DBNull.Value != dr["patientId"] ? Convert.ToString(dr["patientId"]) : "";
                            res.VisitNumber = DBNull.Value != dr["VisitNumber"] ? Convert.ToString(dr["VisitNumber"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                            res.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                            res.testcode = DBNull.Value != dr["testcode"] ? Convert.ToString(dr["testcode"]) : "";
                            res.TestLocation = DBNull.Value != dr["TestLocation"] ? Convert.ToString(dr["TestLocation"]) : "";
                            res.Statusflag = DBNull.Value != dr["Statusflag"] ? Convert.ToInt32(dr["Statusflag"]) : 0;
                            res.Activeflag = DBNull.Value != dr["Activeflag"] ? Convert.ToInt32(dr["Activeflag"]) :0;
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        
        public List<cls_Test_master> Test_master(string PackageCode)
        {
            List<cls_Test_master> dropdown_DTOs = new List<cls_Test_master>();
            try
            {
                DataSet ds = dataLayer.Test_master(PackageCode);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_Test_master res = new cls_Test_master();

                            res.testcode = DBNull.Value != dr["testcode"] ? Convert.ToString(dr["testcode"]) : "";
                            res.testname = DBNull.Value != dr["testname"] ? Convert.ToString(dr["testname"]) : "";
                            res.package_id = DBNull.Value != dr["package_id"] ? Convert.ToString(dr["package_id"]) : "";
                            res.ServiceType = DBNull.Value != dr["ServiceType"] ? Convert.ToString(dr["ServiceType"]) : "";
                            


                            dropdown_DTOs.Add(res);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }

        public InvoiceHead1 OpReprint_V1(int BillNo)
        {
            List<InvoiceLine1> invoiceLines = new List<InvoiceLine1>();
            InvoiceHead1 reqHead = new InvoiceHead1();
            DataSet ds = dataLayer.OpReprint_V1(BillNo);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    reqHead.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToString(ds.Tables[0].Rows[0]["Sno"]) : "";
                    reqHead.UHIDNo = DBNull.Value != ds.Tables[0].Rows[0]["UHIDNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["UHIDNo"]) : "";
                    reqHead.EpisodeNo = DBNull.Value != ds.Tables[0].Rows[0]["EpisodeNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["EpisodeNo"]) : "";
                    reqHead.BillNo = DBNull.Value != ds.Tables[0].Rows[0]["BillNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["BillNo"]) : "";
                    reqHead.PatientName = DBNull.Value != ds.Tables[0].Rows[0]["PatientName"] ? Convert.ToString(ds.Tables[0].Rows[0]["PatientName"]) : "";
                    reqHead.Doctor = DBNull.Value != ds.Tables[0].Rows[0]["Doctor"] ? Convert.ToString(ds.Tables[0].Rows[0]["Doctor"]) : "";
                    reqHead.BillDate = DBNull.Value != ds.Tables[0].Rows[0]["BillDate"] ? Convert.ToString(ds.Tables[0].Rows[0]["BillDate"]) : "";
                    reqHead.DOB_Gender = DBNull.Value != ds.Tables[0].Rows[0]["DOB_Gender"] ? Convert.ToString(ds.Tables[0].Rows[0]["DOB_Gender"]) : "";
                    reqHead.Payor = DBNull.Value != ds.Tables[0].Rows[0]["Payor"] ? Convert.ToString(ds.Tables[0].Rows[0]["Payor"]) : "";
                    reqHead.GSTNo = DBNull.Value != ds.Tables[0].Rows[0]["GSTNo"] ? Convert.ToString(ds.Tables[0].Rows[0]["GSTNo"]) : "";
                    reqHead.CasherSignature = DBNull.Value != ds.Tables[0].Rows[0]["CasherSignature"] ? Convert.ToString(ds.Tables[0].Rows[0]["CasherSignature"]) : "";
                    reqHead.TotalGrossAmount = DBNull.Value != ds.Tables[0].Rows[0]["TotalGrossAmount"] ? Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalGrossAmount"]) : 0;
                    reqHead.TotalDiscount = DBNull.Value != ds.Tables[0].Rows[0]["TotalDiscount"] ? Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalDiscount"]) : 0;
                    reqHead.TotalNetAmount = DBNull.Value != ds.Tables[0].Rows[0]["TotalNetAmount"] ? Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalNetAmount"]) : 0;
                    reqHead.Detail_Type = DBNull.Value != ds.Tables[0].Rows[0]["Detail_Type"] ? Convert.ToString(ds.Tables[0].Rows[0]["Detail_Type"]) : "";
                    reqHead.Payment_Type = DBNull.Value != ds.Tables[0].Rows[0]["Payment_Type"] ? Convert.ToString(ds.Tables[0].Rows[0]["Payment_Type"]) : "";
                    reqHead.SettleAmount = DBNull.Value != ds.Tables[0].Rows[0]["SettleAmount"] ? Convert.ToDecimal(ds.Tables[0].Rows[0]["SettleAmount"]) : 0;
                    reqHead.AmountinWords = DBNull.Value != ds.Tables[0].Rows[0]["AmountinWords"] ? Convert.ToString(ds.Tables[0].Rows[0]["AmountinWords"]) : "";
                    reqHead.BillStatus = DBNull.Value != ds.Tables[0].Rows[0]["BillStatus"] ? Convert.ToString(ds.Tables[0].Rows[0]["BillStatus"]) : "";
                    reqHead.CreditNote = DBNull.Value != ds.Tables[0].Rows[0]["CreditNote"] ? Convert.ToString(ds.Tables[0].Rows[0]["CreditNote"]) : "";



                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        InvoiceLine1 reqLine = new InvoiceLine1();
                        reqLine.DateofService = DBNull.Value != dr["DateofService"] ? Convert.ToString(dr["DateofService"]) : "";
                        reqLine.Service_Name = DBNull.Value != dr["Service_Name"] ? Convert.ToString(dr["Service_Name"]) : "";
                        reqLine.Services = DBNull.Value != dr["Services"] ? Convert.ToString(dr["Services"]) : "";
                        reqLine.Qty = DBNull.Value != dr["Qty"] ? Convert.ToString(dr["Qty"]) : "";
                        reqLine.UnitPrice = DBNull.Value != dr["UnitPrice"] ? Convert.ToString(dr["UnitPrice"]) : "";
                        reqLine.GroupTotal = DBNull.Value != dr["GroupTotal"] ? Convert.ToString(dr["GroupTotal"]) : "";
                        reqLine.ResultTime = DBNull.Value != dr["ResultTime"] ? Convert.ToString(dr["ResultTime"]) : "";


                        invoiceLines.Add(reqLine);
                    }
                    reqHead.InvoiceLine1 = invoiceLines;
                }
            }
            return reqHead;
        }
        
        public List<clswebRef_patient> get_WebRef_pat(int appPatID)
        {
            List<clswebRef_patient> WebList = new List<clswebRef_patient>();
            //List<clsDropDown> res1 = new List<clsDropDown>();
            // List<clsDropDown> res2 = new List<clsDropDown>();
            try
            {
                DataSet ds = dataLayer.get_WebRef_pat(appPatID);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clswebRef_patient web = new clswebRef_patient();
                            //clsDropDown dd = new clsDropDown();
                            //clsDropDown dd1 = new clsDropDown();
                            // clsDropDown dd2 = new clsDropDown();
                            web.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                            web.UHID = DBNull.Value != dr["UHID"] ? Convert.ToInt32(dr["UHID"]) : 0;
                            web.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            web.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                            web.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                            web.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";

                            //res1 = new List<clsDropDown>();
                            //dd.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["Salutation"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Salutation"]) : 0;
                            //dd.columnName = DBNull.Value != ds.Tables[0].Rows[0]["SalutationName"] ? Convert.ToString(ds.Tables[0].Rows[0]["SalutationName"]) : "";
                            //dd.responseType = "Salutation";
                            //web.Salutation = res1;

                            clsDropDown Salutation = new clsDropDown();
                            Salutation.columnName = DBNull.Value != dr["SalutationName"] ? Convert.ToString(dr["SalutationName"]) : "";
                            Salutation.columnCode = DBNull.Value != dr["Salutation"] ? Convert.ToInt32(dr["Salutation"]) : 0;
                            Salutation.responseType = "Salutation";
                            web.Salutation = Salutation;

                            clsDropDown MaritialStatus = new clsDropDown();
                            MaritialStatus.columnName = DBNull.Value != dr["MaritialStatus"] ? Convert.ToString(dr["MaritialStatus"]) : "";
                            MaritialStatus.columnCode = DBNull.Value != dr["MaritialID"] ? Convert.ToInt32(dr["MaritialID"]) : 0;
                            MaritialStatus.responseType = "MaritialStatus";
                            web.MaritialStatus = MaritialStatus;


                            //res2 = new List<clsDropDown>();
                            //dd1.columnCode = DBNull.Value != ds.Tables[0].Rows[0]["MaritialID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaritialID"]) : 0;
                            //dd1.columnName = DBNull.Value != ds.Tables[0].Rows[0]["MaritialStatus"] ? Convert.ToString(ds.Tables[0].Rows[0]["MaritialStatus"]) : "";
                            //dd1.responseType = "MaritialStatus";
                            //web.MaritialStatus = res2;


                            clsDropDown Nationality = new clsDropDown();
                            Nationality.columnName = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";
                            Nationality.columnCode = DBNull.Value != dr["Natcode"] ? Convert.ToInt32(dr["Natcode"]) : 0;
                            Nationality.responseType = "Nationality";
                            web.Nationality = Nationality;

                            web.IDNo = DBNull.Value != dr["IDNo"] ? Convert.ToString(dr["IDNo"]) : "";
                            clsDropDown ID = new clsDropDown();
                            ID.columnName = DBNull.Value != dr["IDtype"] ? Convert.ToString(dr["IDtype"]) : "";
                            ID.columnCode = DBNull.Value != dr["IDCode"] ? Convert.ToInt32(dr["IDCode"]) : 0;
                            ID.responseType = "IDtype";
                            web.ID = ID;

                            clsDropDown Rrefsource = new clsDropDown();
                            Rrefsource.columnName = DBNull.Value != dr["Rrefsource"] ? Convert.ToString(dr["Rrefsource"]) : "";
                            Rrefsource.columnCode = DBNull.Value != dr["Refid"] ? Convert.ToInt32(dr["Refid"]) : 0;
                            Rrefsource.responseType = "Rrefsource";
                            web.Rrefsource = Rrefsource;

                            clsDropDown Doctor = new clsDropDown();
                            Doctor.columnName = DBNull.Value != dr["Doctor"] ? Convert.ToString(dr["Doctor"]) : "";
                            Doctor.columnCode = DBNull.Value != dr["DoctorId"] ? Convert.ToInt32(dr["DoctorId"]) : 0;
                            Doctor.responseType = "Doctor";
                            web.Doctor = Doctor;

                            clsDropDown Department = new clsDropDown();
                            Department.columnName = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
                            Department.columnCode = DBNull.Value != dr["DepId"] ? Convert.ToInt32(dr["DepId"]) : 0;
                            Department.responseType = "Department";
                            web.Department = Department;

                            clsDropDown Occupation = new clsDropDown();
                            Occupation.columnName = DBNull.Value != dr["OccupationName"] ? Convert.ToString(dr["OccupationName"]) : "";
                            Occupation.columnCode = DBNull.Value != dr["Occupation"] ? Convert.ToInt32(dr["Occupation"]) : 0;
                            Occupation.responseType = "Occupation";
                            web.Occupation = Occupation;

                            clsDropDown State = new clsDropDown();
                            State.columnName = DBNull.Value != dr["StatName"] ? Convert.ToString(dr["StatName"]) : "";
                            State.columnCode = DBNull.Value != dr["StateCode"] ? Convert.ToInt32(dr["StateCode"]) : 0;
                            State.responseType = "State";
                            web.State = State;

                            clsDropDown Country = new clsDropDown();
                            Country.columnName = DBNull.Value != dr["CountryName"] ? Convert.ToString(dr["CountryName"]) : "";
                            Country.columnCode = DBNull.Value != dr["CountryCode"] ? Convert.ToInt32(dr["CountryCode"]) : 0;
                            Country.responseType = "Country";
                            web.Country = Country;

                            clsDropDown City = new clsDropDown();
                            City.columnName = DBNull.Value != dr["CityName"] ? Convert.ToString(dr["CityName"]) : "";
                            City.columnCode = DBNull.Value != dr["CityCode"] ? Convert.ToInt32(dr["CityCode"]) : 0;
                            City.responseType = "City";
                            web.City = City;

                            clsDropDown Relation = new clsDropDown();
                            Relation.columnName = DBNull.Value != dr["RelType"] ? Convert.ToString(dr["RelType"]) : "";
                            Relation.columnCode = DBNull.Value != dr["RelCode"] ? Convert.ToInt32(dr["RelCode"]) : 0;
                            Relation.responseType = "Relation";
                            web.Relation = Relation;

                            web.Pattype = DBNull.Value != dr["Pattype"] ? Convert.ToString(dr["Pattype"]) : "";
                            web.PayerName = DBNull.Value != dr["PayerName"] ? Convert.ToString(dr["PayerName"]) : "";
                            web.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            web.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                            web.Pincode = DBNull.Value != dr["Pincode"] ? Convert.ToString(dr["Pincode"]) : "";
                            web.Area = DBNull.Value != dr["Area"] ? Convert.ToString(dr["Area"]) : "";
                            web.Address = DBNull.Value != dr["Address"] ? Convert.ToString(dr["Address"]) : "";
                            web.RelName = DBNull.Value != dr["RelName"] ? Convert.ToString(dr["RelName"]) : "";
                            web.RelMobileNo = DBNull.Value != dr["RelMobileNo"] ? Convert.ToString(dr["RelMobileNo"]) : "";
                            web.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                            web.CreteDate = DBNull.Value != dr["CreteDate"] ? Convert.ToString(dr["CreteDate"]) : "";
                            WebList.Add(web);
                            //res1.Add(dd);
                            //res2.Add(dd1);
                            //new res1();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
        public List<BedRateAndNursingRate> BedRateAndNursingRate_dtl(int Bedcategoryid)
        {
            List<BedRateAndNursingRate> WebList = new List<BedRateAndNursingRate>();

            try
            {
                DataSet ds = dataLayer.BedRateAndNursingRate_dtl(Bedcategoryid);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BedRateAndNursingRate web = new BedRateAndNursingRate();
                            web.BedCategory = DBNull.Value != dr["BedCategory"] ? Convert.ToString(dr["BedCategory"]) : "";
                            web.ChType = DBNull.Value != dr["ChType"] ? Convert.ToString(dr["ChType"]) : "";
                            web.Rate = DBNull.Value != dr["Rate"] ? Convert.ToInt32(dr["Rate"]) : 0;

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }

        public List<BedDetails_Load> web_sp_BedDetails_Load(int CatId)
        {
            List<BedDetails_Load> WebList = new List<BedDetails_Load>();

            try
            {
                DataSet ds = dataLayer.web_sp_BedDetails_Load(CatId);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BedDetails_Load web = new BedDetails_Load();
                            web.MBED_BEDNO_CD = DBNull.Value != dr["MBED_BEDNO_CD"] ? Convert.ToString(dr["MBED_BEDNO_CD"]) : "";
                            web.MBED_BEDID_ID = DBNull.Value != dr["MBED_BEDID_ID"] ? Convert.ToInt32(dr["MBED_BEDID_ID"]) : 0;
                            WebList.Add(web);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }

        public List<Authenticate> AuthenticateMobNo_Upload_V1(string OTP_MobileNo, int Otp)
        {
            List<Authenticate> WebList = new List<Authenticate>();

            try
            {
                DataSet ds = dataLayer.AuthenticateMobNo_Upload_V1( OTP_MobileNo, Otp);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Authenticate web = new Authenticate();


                            web.sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
                            web.patient_name = DBNull.Value != dr["patient_name"] ? Convert.ToString(dr["patient_name"]) : "";
                            web.patient_gender = DBNull.Value != dr["patient_gender"] ? Convert.ToString(dr["patient_gender"]) : "";
                            web.patient_dob = DBNull.Value != dr["patient_dob"] ? Convert.ToString(dr["patient_dob"]) : "";
                            web.patient_mobilenumber = DBNull.Value != dr["patient_mobilenumber"] ? Convert.ToString(dr["patient_mobilenumber"]) : "";
                            web.Patient_lastmodified = DBNull.Value != dr["Patient_lastmodified"] ? Convert.ToString(dr["Patient_lastmodified"]) : "";
                            web.Response = DBNull.Value != dr["Response"] ? Convert.ToString(dr["Response"]) : "";
                          
                            WebList.Add(web);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
        public List<Get_BedID> web_sp_Get_BedID(int BedId)
        {
            List<Get_BedID> WebList = new List<Get_BedID>();

            try
            {
                DataSet ds = dataLayer.web_sp_Get_BedID(BedId);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Get_BedID web = new Get_BedID();
                            web.MBED_BEDNO_CD = DBNull.Value != dr["MBED_BEDNO_CD"] ? Convert.ToString(dr["MBED_BEDNO_CD"]) : "";

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
       
        public List<BedBlockDetails> BedBlockDetails_Load()
        {
            List<BedBlockDetails> WebList = new List<BedBlockDetails>();

            try
            {
                DataSet ds = dataLayer.BedBlockDetails_Load();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BedBlockDetails web = new BedBlockDetails();

                            web.SNo = DBNull.Value != dr["SNo"] ? Convert.ToInt32(dr["SNo"]) : 0;
                            web.BedId = DBNull.Value != dr["BedId"] ? Convert.ToInt32(dr["BedId"]) : 0;
                            web.CATEGORY = DBNull.Value != dr["CATEGORY"] ? Convert.ToString(dr["CATEGORY"]) : "";
                            web.WARD = DBNull.Value != dr["WARD"] ? Convert.ToString(dr["WARD"]) : "";
                            web.BED = DBNull.Value != dr["BED"] ? Convert.ToString(dr["BED"]) : "";
                            web.BEDSTATUS = DBNull.Value != dr["BEDSTATUS"] ? Convert.ToString(dr["BEDSTATUS"]) : "";
                            web.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            web.PATIENTNAME = DBNull.Value != dr["PATIENTNAME"] ? Convert.ToString(dr["PATIENTNAME"]) : "";
                            web.FUTUREUHID = DBNull.Value != dr["FUTUREUHID"] ? Convert.ToString(dr["FUTUREUHID"]) : "";
                            web.FUTUREPATIENTNAME = DBNull.Value != dr["FUTUREPATIENTNAME"] ? Convert.ToString(dr["FUTUREPATIENTNAME"]) : "";
                            web.Allocated = DBNull.Value != dr["Allocated"] ? Convert.ToInt32(dr["Allocated"]) : 0;
                            web.Active = DBNull.Value != dr["Active"] ? Convert.ToInt32(dr["Active"]) : 0;
                            web.PIN = DBNull.Value != dr["PIN"] ? Convert.ToString(dr["PIN"]) : "";
                            WebList.Add(web);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
        public List<CriticalCare> Get_CriticalCare_InfectiousDis()
        {
            List<CriticalCare> WebList = new List<CriticalCare>();

            try
            {
                DataSet ds = dataLayer.Get_CriticalCare_InfectiousDis();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CriticalCare web = new CriticalCare();
                            
                            //web.sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
                            web.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            web.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                            web.Email_ID = DBNull.Value != dr["Email_ID"] ? Convert.ToString(dr["Email_ID"]) : "";
                            web.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            web.Ins_Organization_nm = DBNull.Value != dr["Ins_Organization_nm"] ? Convert.ToString(dr["Ins_Organization_nm"]) : "";
                            web.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                            web.Designation = DBNull.Value != dr["Designation"] ? Convert.ToString(dr["Designation"]) : "";
                            web.RegistrationNo_TNMC = DBNull.Value != dr["RegistrationNo_TNMC"] ? Convert.ToString(dr["RegistrationNo_TNMC"]) : "";
                            web.AddressofIns_Organization = DBNull.Value != dr["AddressofIns_Organization"] ? Convert.ToString(dr["AddressofIns_Organization"]) : "";
                            web.AreaofInterestinCCID = DBNull.Value != dr["AreaofInterestinCCID"] ? Convert.ToString(dr["AreaofInterestinCCID"]) : "";
                            web.CreatedDt = DBNull.Value != dr["CreatedDt"] ? Convert.ToString(dr["CreatedDt"]) : "";         
                            WebList.Add(web);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }
        public List<DayWise_QMSDetails> Get_WEB_DayWiseQMS_Dtl()
        {
            List<DayWise_QMSDetails> res = new List<DayWise_QMSDetails>();
            DataSet ds = dataLayer.Get_WEB_DayWiseQMS_Dtl();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        DayWise_QMSDetails Patient = new DayWise_QMSDetails();

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToInt32(dr["TokenNo"]) : 0;
                        Patient.TokenType = DBNull.Value != dr["TokenType"] ? Convert.ToString(dr["TokenType"]) : "";
                        Patient.Processing_time = DBNull.Value != dr["Processing_time"] ? Convert.ToString(dr["Processing_time"]) : "";
                        Patient.Completed_time = DBNull.Value != dr["Completed_time"] ? Convert.ToString(dr["Completed_time"]) : "";

                        res.Add(Patient);

                    }
                }
            }
            return res;
        }

        public List<RadiologyAppointment> Get_RadiologyAppointment()
        {
            List<RadiologyAppointment> res = new List<RadiologyAppointment>();
            DataSet ds = dataLayer.Get_RadiologyAppointment();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        RadiologyAppointment Patient = new RadiologyAppointment();
                              
                        Patient.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        Patient.APPID = DBNull.Value != dr["APPID"] ? Convert.ToString(dr["APPID"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.Tokenno = DBNull.Value != dr["Tokenno"] ? Convert.ToInt32(dr["Tokenno"]) : 0;
                        Patient.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
  
                        res.Add(Patient);

                    }
                }
            }
            return res;
        }


        public List<RadiologyAppointment> Get_RadiologyAppointment_Modality()
        {
            List<RadiologyAppointment> res = new List<RadiologyAppointment>();
            DataSet ds = dataLayer.Get_RadiologyAppointment_Modality();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        RadiologyAppointment Patient = new RadiologyAppointment();

                        Patient.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        Patient.APPID = DBNull.Value != dr["APPID"] ? Convert.ToString(dr["APPID"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.Tokenno = DBNull.Value != dr["Tokenno"] ? Convert.ToInt32(dr["Tokenno"]) : 0;
                        Patient.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";

                        res.Add(Patient);

                    }
                }
            }
            return res;
        }

        public List<DayWise_QMSDetails_test> Get_WEB_DayWiseQMS_Dtl_test()
        {
            List<DayWise_QMSDetails_test> res = new List<DayWise_QMSDetails_test>();
            DataSet ds = dataLayer.Get_WEB_DayWiseQMS_Dtl_test();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        DayWise_QMSDetails_test Patient = new DayWise_QMSDetails_test();

                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.TokenNo = DBNull.Value != dr["TokenNo"] ? Convert.ToInt32(dr["TokenNo"]) : 0;
                        Patient.TokenType = DBNull.Value != dr["TokenType"] ? Convert.ToString(dr["TokenType"]) : "";
                        Patient.Processing_time = DBNull.Value != dr["Processing_time"] ? Convert.ToString(dr["Processing_time"]) : "";
                        Patient.Completed_time = DBNull.Value != dr["Completed_time"] ? Convert.ToString(dr["Completed_time"]) : "";

                        res.Add(Patient);

                    }
                }
            }
            return res;
        }

        public List<Doctor_Directory> Get_Doctor_Directory_Js() 
        {
            List<Doctor_Directory> WebList = new List<Doctor_Directory>();

            try
            {
                DataSet ds = dataLayer.Get_Doctor_Directory_Js();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Doctor_Directory web = new Doctor_Directory();
                            
                           
                            web.doctorid = DBNull.Value != dr["doctorid"] ? Convert.ToInt32(dr["doctorid"]) : 0;
                            web.doctorname = DBNull.Value != dr["doctorname"] ? Convert.ToString(dr["doctorname"]) : "";
                            web.department_Name = DBNull.Value != dr["department_Name"] ? Convert.ToString(dr["department_Name"]) : "";
                            web.subdepartment = DBNull.Value != dr["subdepartment"] ? Convert.ToString(dr["subdepartment"]) : "";
                            web.qualification = DBNull.Value != dr["qualification"] ? Convert.ToString(dr["qualification"]) : "";
                            web.designation = DBNull.Value != dr["designation"] ? Convert.ToString(dr["designation"]) : "";
                            web.profile_image = DBNull.Value != dr["profile_image"] ? Convert.ToString(dr["profile_image"]) : "";
                            web.tv_no = DBNull.Value != dr["tv_no"] ? Convert.ToString(dr["tv_no"]) : "";
                            web.slide_no = DBNull.Value != dr["slide_no"] ? Convert.ToInt32(dr["slide_no"]) : 0;
                            web.sequence_no = DBNull.Value != dr["sequence_no"] ? Convert.ToInt32(dr["sequence_no"]) : 0;
                            web.header = DBNull.Value != dr["header"] ? Convert.ToString(dr["header"]) : "";
                           
                            WebList.Add(web);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }


      


        public InsertDoctor_Directory_Js_Res InsertDoctor_Directory_Js(InsertDoctor_Directory_Js_req request)
        {
            InsertDoctor_Directory_Js_Res result = new InsertDoctor_Directory_Js_Res();
            DataSet ds = dataLayer.InsertDoctor_Directory_Js(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.Msg = DBNull.Value != ds.Tables[0].Rows[0]["Msg"] ? Convert.ToString(ds.Tables[0].Rows[0]["Msg"]) : "";

            }

            return result;
        }

        public UPDATEDoctor_Directory_Js_Res UPDATEDoctor_Directory_Js(UPDATEDoctor_Directory_Js_req request)
        {
            UPDATEDoctor_Directory_Js_Res result = new UPDATEDoctor_Directory_Js_Res();
            DataSet ds = dataLayer.UPDATEDoctor_Directory_Js(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.Msg = DBNull.Value != ds.Tables[0].Rows[0]["Msg"] ? Convert.ToString(ds.Tables[0].Rows[0]["Msg"]) : "";

            }

            return result;
        }

        public List<TVbackgraound> Get_TVbackgraound()
        {
            List<TVbackgraound> WebList = new List<TVbackgraound>();

            try
            {
                DataSet ds = dataLayer.Get_TVbackgraound();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            TVbackgraound web = new TVbackgraound();


                            web.tvid = DBNull.Value != dr["tvid"] ? Convert.ToInt32(dr["tvid"]) : 0;
                            web.tvname = DBNull.Value != dr["tvname"] ? Convert.ToString(dr["tvname"]) : "";
                            web.imageurl = DBNull.Value != dr["imageurl"] ? Convert.ToString(dr["imageurl"]) : "";
                            
                            WebList.Add(web);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return WebList;
        }

        public UpdateTVbackgraound_Res UpdateTVbackgraound(UpdateTVbackgraound_req request)
        {
            UpdateTVbackgraound_Res result = new UpdateTVbackgraound_Res();
            DataSet ds = dataLayer.UpdateTVbackgraound(request);

            if (ds != null)
            {
                result.Sno = DBNull.Value != ds.Tables[0].Rows[0]["Sno"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"]) : 0;
                result.Msg = DBNull.Value != ds.Tables[0].Rows[0]["Msg"] ? Convert.ToString(ds.Tables[0].Rows[0]["Msg"]) : "";

            }

            return result;
        }
        public Response_pay updateOnlinePayment(pay_request request)
        {
            Response_pay response = new Response_pay();

            DataSet ds = dataLayer.updateOnlinePayment(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.ResultCode = DBNull.Value != dr["ResultCode"] ? Convert.ToInt32(dr["ResultCode"]) : 0;
                        response.Result = DBNull.Value != dr["Result"] ? Convert.ToString(dr["Result"]) : "";
                    }
                }
            }

            return response;
        }

        //public Response_v1 AuthenticateMobNo_Upload_V1(Auth_request request)
        //{
        //    Response_v1 response = new Response_v1();

        //    DataSet ds = dataLayer.AuthenticateMobNo_Upload_V1(request);

        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                response.sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
        //                response.patient_name = DBNull.Value != dr["patient_name"] ? Convert.ToString(dr["patient_name"]) : "";
        //                response.patient_gender = DBNull.Value != dr["patient_gender"] ? Convert.ToString(dr["patient_gender"]) : "";
        //                response.patient_dob = DBNull.Value != dr["patient_dob"] ? Convert.ToString(dr["patient_dob"]) : "";
        //                response.patient_mobilenumber = DBNull.Value != dr["patient_mobilenumber"] ? Convert.ToString(dr["patient_mobilenumber"]) : "";
        //                response.Patient_lastmodified = DBNull.Value != dr["Patient_lastmodified"] ? Convert.ToString(dr["Patient_lastmodified"]) : "";
        //                response.Msg = DBNull.Value != dr["Msg"] ? Convert.ToString(dr["Msg"]) : "";
        //            }
        //        }
        //    }

        //    return response;
        //}

        public void InsertUpdateOTP_portal( string RandomNumber, string MobileNo)
        {

            dataLayer.InsertUpdateOTP_portal( RandomNumber, MobileNo);
        }
        public string AuthenticateOTP(string RandomNumber, string MobileNo)
        {
            string str = dataLayer.AuthenticateMobNo(RandomNumber, MobileNo);

            return str;
        }

        public OTP_Resp GetPatientResp_MobNo(string RandomNumber, string MobileNo)
        {
            OTP_Resp patientres = new OTP_Resp();
            List<PatientDTO> patdto = new List<PatientDTO>();
            DataSet ds = dataLayer.GetPatientDet_MobNo(MobileNo);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PatientDTO po = new PatientDTO();
                        //po.DoctorID = DBNull.Value != dr["Mspc_SpecialisationCode_cd"] ? Convert.ToInt32(dr["Mspc_SpecialisationCode_cd"]) : 0;
                        po.UHID = DBNull.Value != dr["patient_mrnnumber"] ? Convert.ToString(dr["patient_mrnnumber"]) : "";
                        po.PatientName = DBNull.Value != dr["patient_name"] ? Convert.ToString(dr["patient_name"]) : "";
                        po.Gender = DBNull.Value != dr["patient_gender"] ? Convert.ToString(dr["patient_gender"]) : "";
                        po.DOB = DBNull.Value != dr["patient_dob"] ? Convert.ToDateTime(dr["patient_dob"]).ToString("dd/MMM/yyyy") : "";
                        po.MobileNo = DBNull.Value != dr["patient_mobilenumber"] ? Convert.ToString(dr["patient_mobilenumber"]) : "";
                        //po.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                        //po.IDDesc = DBNull.Value != dr["IDDesc"] ? Convert.ToString(dr["IDDesc"]) : "";
                        //po.IDTypeCode = DBNull.Value != dr["IDTypeCode"] ? Convert.ToInt32(dr["IDTypeCode"]) : 0;

                        po.OTP = RandomNumber;
                        po.Authenticated = "Authenticated";
                        patdto.Add(po);

                    }
                    patientres.patientDTO = patdto;
                    //patientDet.Add(po);
                    patientres.responsecode = 0;
                    patientres.response = "Authenticated";
                    patientres.status = "Patient Details Available";
                }
                else
                {
                    PatientDTO po = new PatientDTO();
                    po.UHID = "";
                    po.PatientName = "";
                    po.Gender = "";
                    po.DOB = "";
                    po.MobileNo = MobileNo;
                    po.OTP = RandomNumber;
                    po.Authenticated = "Authenticated";
                    patdto.Add(po);

                    patientres.patientDTO = patdto;
                    patientres.responsecode = 1;
                    patientres.response = "Authenticated";
                    patientres.status = "New Patient";
                }
            }

            return patientres;
        }

        public Response_DTO_v1 updatePOSPayment(payment_request request)
        {
            Response_DTO_v1 response = new Response_DTO_v1();

            DataSet ds = dataLayer.updatePOSPayment(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.ResultCode = DBNull.Value != dr["ResultCode"] ? Convert.ToInt32(dr["ResultCode"]) : 0;
                        response.Result = DBNull.Value != dr["Result"] ? Convert.ToString(dr["Result"]) : "";
                    }
                }
            }

            return response;
        }


        public List<res_BirthDay_Info_New> Get_BirthDay_Info_New(string date)
        {
            List<res_BirthDay_Info_New> res = new List<res_BirthDay_Info_New>();
            DataSet ds = dataLayer.Get_BirthDay_Info_New(date);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_BirthDay_Info_New req = new res_BirthDay_Info_New();

                        req.empid = DBNull.Value != dr["empid"] ? Convert.ToString(dr["empid"]) : "";
                        req.empname = DBNull.Value != dr["empname"] ? Convert.ToString(dr["empname"]) : "";
                        req.Dept = DBNull.Value != dr["Dept"] ? Convert.ToString(dr["Dept"]) : "";

                        res.Add(req);

                    }
                }
            }

            return res;

        }

        //public List<res_opiprevenue> SP_OPIPREVENUE(string FromDate, string ToDate, string Pattype, int IVF_flg)
        //{
        //    List<res_opiprevenue> res = new List<res_opiprevenue> ();
        //    DataSet ds = dataLayer.SP_OPIPREVENUE( FromDate,  ToDate,  Pattype,  IVF_flg);
        //    if (ds !=null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {

        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                res_opiprevenue req = new res_opiprevenue();

        //                req.OrderDoctor = DBNull.Value != dr["OrderDoctor"] ? Convert.ToString(dr["OrderDoctor"]) : "";
        //                req.OrderDepartment = DBNull.Value != dr["OrderDepartment"] ? Convert.ToString(dr["OrderDepartment"]) : "";
        //                req.OrderDate = DBNull.Value != dr["OrderDate"] ? Convert.ToDateTime(dr["OrderDate"]).ToString("dd/MMM/yyyy") : "";
        //                req.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
        //                req.GrossAmount = DBNull.Value != dr["GrossAmount"] ? Convert.ToString(dr["GrossAmount"]) : "";
        //                req.Discount = DBNull.Value != dr["Discount"] ? Convert.ToString(dr["Discount"]) : "";
        //                req.Net = DBNull.Value != dr["Net"] ? Convert.ToString(dr["Net"]) : "";

        //                res.Add(req);

        //            }
        //        }
        //    }

        //    return res;

        //}

        public responseDtl save_opd_Process_Dtl(requestDtl request)
        {
            responseDtl response = new responseDtl();

            DataSet ds = dataLayer.save_opd_Process_Dtl(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }

       

        public responseDtl SaveOrUpdateQCVisittracking(req_Visittracking request)
        {
            responseDtl response = new responseDtl();

            DataSet ds = dataLayer.SaveOrUpdateQCVisittracking(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }

        ////public resEMROTDetl SaveEMROTDet(req_EMROTDetl request)
        ////{
        ////    resEMROTDetl response = new resEMROTDetl();

        ////    DataSet ds = dataLayer.SaveEMROTDet(request);

        ////    if (ds != null)
        ////    {
        ////        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        ////        {
        ////            foreach (DataRow dr in ds.Tables[0].Rows)
        ////            {
             
        ////                response.Mpat_Admissionid_id = DBNull.Value != dr["Mpat_Admissionid_id"] ? Convert.ToString(dr["Mpat_Admissionid_id"]) : "";
        ////                response.Scph_LOCATIONID_ID = DBNull.Value != dr["Scph_LOCATIONID_ID"] ? Convert.ToString(dr["Scph_LOCATIONID_ID"]) : "";
        ////                response.Scph_ScheduleDt_dt = DBNull.Value != dr["Scph_ScheduleDt_dt"] ? Convert.ToString(dr["Scph_ScheduleDt_dt"]) : "";
        ////                response.Scph_ScheduleTime_tm = DBNull.Value != dr["Scph_ScheduleTime_tm"] ? Convert.ToString(dr["Scph_ScheduleTime_tm"]) : ""; 
        ////                response.Scph_ScheduleEndTime_tm = DBNull.Value != dr["Scph_ScheduleEndTime_tm"] ? Convert.ToString(dr["Scph_ScheduleEndTime_tm"]) : "";
        ////                response.Scph_IsActive_flg = DBNull.Value != dr["Scph_IsActive_flg"] ? Convert.ToString(dr["Scph_IsActive_flg"]) : ""; 
        ////                response.Scph_CreatedBy_id = DBNull.Value != dr["Scph_CreatedBy_id"] ? Convert.ToString(dr["Scph_CreatedBy_id"]) : "";
        ////                response.Scph_Created_dt = DBNull.Value != dr["Scph_Created_dt"] ? Convert.ToString(dr["Scph_Created_dt"]) : "";
        ////                response.Scph_LastModifiedBy_id = DBNull.Value != dr["Scph_LastModifiedBy_id"] ? Convert.ToString(dr["Scph_LastModifiedBy_id"]) : "";
        ////                response.Scph_LastModified_dt = DBNull.Value != dr["Scph_LastModified_dt"] ? Convert.ToString(dr["Scph_LastModified_dt"]) : "";
        ////                response.OT_OTTypeCode_Cd = DBNull.Value != dr["OT_OTTypeCode_Cd"] ? Convert.ToString(dr["OT_OTTypeCode_Cd"]) : "";
        ////                response.Scph_ScheduleEndDt_dt = DBNull.Value != dr["Scph_ScheduleEndDt_dt"] ? Convert.ToString(dr["Scph_ScheduleEndDt_dt"]) : "";
                     
        ////            }
        ////        }
        ////    }

        ////    return response;
        ////}


        public resEMROTDetl SaveEMROTDet(req_EMROTDetl request)
        {
            resEMROTDetl response = new resEMROTDetl();

            DataSet ds = dataLayer.SaveEMROTDet(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";

                    }
                }
            }

            return response;
        }


        public responseDtl SaveOrUpdateQCOrderTracking(req_OrderTracking request)
        {
            responseDtl response = new responseDtl();

            DataSet ds = dataLayer.SaveOrUpdateQCOrderTracking(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }

        public responseDtl save_e_certificate(requeste_cert requeste_cert)
        {
            responseDtl response = new responseDtl();

            DataSet ds = dataLayer.save_e_certificate(requeste_cert);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                    }
                }
            }

            return response;
        }
       


        public List<res_EMRAPILog> Kranium_EMRAPILog(string Fdate, string tdate, string Status)
        {
            List<res_EMRAPILog> res = new List<res_EMRAPILog>();

            DataSet ds = dataLayer.Kranium_EMRAPILog(Fdate, tdate, Status);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_EMRAPILog Patient = new res_EMRAPILog();

                  
                        Patient.SNo = DBNull.Value != dr["SNo"] ? Convert.ToInt32(dr["SNo"]) :0;
                        Patient.APIType = DBNull.Value != dr["APIType"] ? Convert.ToString(dr["APIType"]) : "";
                        Patient.Request = DBNull.Value != dr["Request"] ? Convert.ToString(dr["Request"]) : "";
                        Patient.Response = DBNull.Value != dr["Response"] ? Convert.ToString(dr["Response"]) : "";
                        Patient.status = DBNull.Value != dr["status"] ? Convert.ToString(dr["status"]) : "";
                        Patient.HostName = DBNull.Value != dr["HostName"] ? Convert.ToString(dr["HostName"]) : "";
                        Patient.CreatedBy = DBNull.Value != dr["CreatedBy"] ? Convert.ToString(dr["CreatedBy"]) : "";
                        Patient.CreatedDate = DBNull.Value != dr["CreatedDate"] ? Convert.ToString(dr["CreatedDate"]) : "";
                        
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }




        public List<res_opd_Process> Get_opd_Process(string Todate)
        {
            List<res_opd_Process> res = new List<res_opd_Process>();

            DataSet ds = dataLayer.Get_opd_Process(Todate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_opd_Process Patient = new res_opd_Process();

                        Patient.RegistrationId = DBNull.Value != dr["RegistrationId"] ? Convert.ToString(dr["RegistrationId"]) : "";
                        Patient.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToString(dr["PatientId"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                        Patient.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        Patient.Rad_Order = DBNull.Value != dr["Rad_Order"] ? Convert.ToString(dr["Rad_Order"]) : "";
                        Patient.Rad_Followup_Billed = DBNull.Value != dr["Rad_Followup_Billed"] ? Convert.ToString(dr["Rad_Followup_Billed"]) : "";
                        Patient.Study_Start = DBNull.Value != dr["Study_Start"] ? Convert.ToString(dr["Study_Start"]) : "";
                        Patient.Study_Authorized = DBNull.Value != dr["Study_Authorized"] ? Convert.ToString(dr["Study_Authorized"]) : "";
                        Patient.Lab_Order = DBNull.Value != dr["Lab_Order"] ? Convert.ToString(dr["Lab_Order"]) : "";
                        Patient.Lab_Followup_Billed = DBNull.Value != dr["Lab_Followup_Billed"] ? Convert.ToString(dr["Lab_Followup_Billed"]) : "";
                        Patient.Sample_Collected = DBNull.Value != dr["Sample_Collected"] ? Convert.ToString(dr["Sample_Collected"]) : "";
                        Patient.Lab_Authorized = DBNull.Value != dr["Lab_Authorized"] ? Convert.ToString(dr["Lab_Authorized"]) : "";
                        Patient.Medicines_Prescribed = DBNull.Value != dr["Medicines_Prescribed"] ? Convert.ToString(dr["Medicines_Prescribed"]) : "";
                        Patient.Billing_status = DBNull.Value != dr["Billing_status"] ? Convert.ToString(dr["Billing_status"]) : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }



        public List<res_opd_Process> Get_opd_Process_v1(string Todate, int Type)
        {
            List<res_opd_Process> res = new List<res_opd_Process>();

            DataSet ds = dataLayer.Get_opd_Process_v1(Todate, Type);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_opd_Process Patient = new res_opd_Process();

                    
                        Patient.RegistrationId = DBNull.Value != dr["RegistrationId"] ? Convert.ToString(dr["RegistrationId"]) : "";
                        Patient.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToString(dr["PatientId"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                        Patient.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";

                        if (Type == 1)
                        {
                            Patient.Rad_Order = DBNull.Value != dr["Rad_Order"] ? Convert.ToString(dr["Rad_Order"]) : "";
                            Patient.Rad_Followup_Billed = DBNull.Value != dr["Rad_Followup_Billed"] ? Convert.ToString(dr["Rad_Followup_Billed"]) : "";
                            Patient.Study_Start = DBNull.Value != dr["Study_Start"] ? Convert.ToString(dr["Study_Start"]) : "";
                            Patient.Study_Authorized = DBNull.Value != dr["Study_Authorized"] ? Convert.ToString(dr["Study_Authorized"]) : "";

                            Patient.Lab_Order = "";
                            Patient.Lab_Followup_Billed =  "";
                            Patient.Sample_Collected = "";
                            Patient.Lab_Authorized =  "";
                            Patient.Medicines_Prescribed = "";
                            Patient.Billing_status =  "";


                        }


                        if (Type == 2)
                        {

                            Patient.Admission_advised = DBNull.Value != dr["Admission_advised"] ? Convert.ToString(dr["Admission_advised"]) : "";
                            Patient.Admission_Status = DBNull.Value != dr["Admission_Status"] ? Convert.ToString(dr["Admission_Status"]) : "";

                            Patient.Rad_Order =  "";
                            Patient.Rad_Followup_Billed = "";
                            Patient.Study_Start =  "";
                            Patient.Study_Authorized =  "";
                            Patient.Lab_Order =  "";
                            Patient.Lab_Followup_Billed =  "";
                            Patient.Sample_Collected =  "";
                            Patient.Lab_Authorized =  "";
                            Patient.Medicines_Prescribed =  "";
                            Patient.Billing_status =  "";
                        }

                        if (Type == 3)
                        {
                            Patient.Rad_Order =  "";
                            Patient.Rad_Followup_Billed =  "";
                            Patient.Study_Start =  "";
                            Patient.Study_Authorized =  "";
                            Patient.Lab_Order = "";
                            Patient.Lab_Followup_Billed =  "";
                            Patient.Sample_Collected =  "";
                            Patient.Lab_Authorized =  "";
                            Patient.Medicines_Prescribed = DBNull.Value != dr["Medicines_Prescribed"] ? Convert.ToString(dr["Medicines_Prescribed"]) : "";
                            Patient.Billing_status = DBNull.Value != dr["Billing_status"] ? Convert.ToString(dr["Billing_status"]) : "";
                        }

                        if(Type == 4)
                        {
                            Patient.Lab_Order = DBNull.Value != dr["Lab_Order"] ? Convert.ToString(dr["Lab_Order"]) : "";
                            Patient.Lab_Followup_Billed = DBNull.Value != dr["Lab_Followup_Billed"] ? Convert.ToString(dr["Lab_Followup_Billed"]) : "";
                            Patient.Sample_Collected = DBNull.Value != dr["Sample_Collected"] ? Convert.ToString(dr["Sample_Collected"]) : "";
                            Patient.Lab_Authorized = DBNull.Value != dr["Lab_Authorized"] ? Convert.ToString(dr["Lab_Authorized"]) : "";

                            
                            Patient.Rad_Order = "";
                            Patient.Rad_Followup_Billed =  "";
                            Patient.Study_Start =  "";
                            Patient.Study_Authorized =  "";
                            Patient.Medicines_Prescribed =  "";
                            Patient.Billing_status =  "";
                        }
                        if (Type == 5)
                        {
                            Patient.Rad_Order = DBNull.Value != dr["Rad_Order"] ? Convert.ToString(dr["Rad_Order"]) : "";
                            Patient.Rad_Followup_Billed = DBNull.Value != dr["Rad_Followup_Billed"] ? Convert.ToString(dr["Rad_Followup_Billed"]) : "";
                            Patient.Study_Start = DBNull.Value != dr["Study_Start"] ? Convert.ToString(dr["Study_Start"]) : "";
                            Patient.Study_Authorized = DBNull.Value != dr["Study_Authorized"] ? Convert.ToString(dr["Study_Authorized"]) : "";
                            Patient.Lab_Order = DBNull.Value != dr["Lab_Order"] ? Convert.ToString(dr["Lab_Order"]) : "";
                            Patient.Lab_Followup_Billed = DBNull.Value != dr["Lab_Followup_Billed"] ? Convert.ToString(dr["Lab_Followup_Billed"]) : "";
                            Patient.Sample_Collected = DBNull.Value != dr["Sample_Collected"] ? Convert.ToString(dr["Sample_Collected"]) : "";
                            Patient.Lab_Authorized = DBNull.Value != dr["Lab_Authorized"] ? Convert.ToString(dr["Lab_Authorized"]) : "";
                            Patient.Medicines_Prescribed = DBNull.Value != dr["Medicines_Prescribed"] ? Convert.ToString(dr["Medicines_Prescribed"]) : "";
                            Patient.Billing_status = DBNull.Value != dr["Billing_status"] ? Convert.ToString(dr["Billing_status"]) : "";
                        }
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<res_UpdateQC_Visit> UpdateQCEMRDashboard_Visit(string Todate, int VisitId)
        {
            List<res_UpdateQC_Visit> res = new List<res_UpdateQC_Visit>();

            DataSet ds = dataLayer.UpdateQCEMRDashboard_Visit(Todate, VisitId);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_UpdateQC_Visit Patient = new res_UpdateQC_Visit();

                        Patient.PatientId = DBNull.Value != dr["PatientId"] ? Convert.ToString(dr["PatientId"]) : "";
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.VisitId = DBNull.Value != dr["VisitId"] ? Convert.ToString(dr["VisitId"]) : "";
                        Patient.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                        Patient.Vitals_Completed_time = DBNull.Value != dr["Vitals_Completed_time"] ? Convert.ToString(dr["Vitals_Completed_time"]) : "";
                        Patient.Doctor_Checkin = DBNull.Value != dr["Doctor_Checkin"] ? Convert.ToString(dr["Doctor_Checkin"]) : "";
                        Patient.Procedure_Advised = DBNull.Value != dr["Procedure_Advised"] ? Convert.ToString(dr["Procedure_Advised"]) : "";
                        Patient.Admission_Advised = DBNull.Value != dr["Admission_Advised"] ? Convert.ToString(dr["Admission_Advised"]) : "";
                        Patient.Admission_Status = DBNull.Value != dr["Admission_Status"] ? Convert.ToString(dr["Admission_Status"]) : "";
                        Patient.PresOrdercnt = DBNull.Value != dr["PresOrdercnt"] ? Convert.ToInt32(dr["PresOrdercnt"]) : 0;
                        Patient.PresBillcnt = DBNull.Value != dr["PresBillcnt"] ? Convert.ToInt32(dr["PresBillcnt"]) : 0;

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<res_doctor_tv> Get_Doctor_TV(string TvTag)
        {
            List<res_doctor_tv> res = new List<res_doctor_tv>();

            DataSet ds = dataLayer.Get_Doctor_TV(TvTag);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_doctor_tv Patient = new res_doctor_tv();
                      //  Patient.SlNo = DBNull.Value != dr["SlNo"] ? Convert.ToInt32(dr["SlNo"]) : 0;
                        Patient.Department = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
                        Patient.SubDepartment = DBNull.Value != dr["SubDepartment"] ? Convert.ToString(dr["SubDepartment"]) : "";
                        Patient.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        Patient.Designation = DBNull.Value != dr["Designation"] ? Convert.ToString(dr["Designation"]) : "";
                        Patient.Qualification = DBNull.Value != dr["Qualification"] ? Convert.ToString(dr["Qualification"]) : "";
                        Patient.SlideSequence = DBNull.Value != dr["SlideSequence"] ? Convert.ToString(dr["SlideSequence"]) : "";
                        Patient.PictureName = DBNull.Value != dr["PictureName"] ? Convert.ToString(dr["PictureName"]) : "";
                        Patient.TvTag = DBNull.Value != dr["TvTag"] ? Convert.ToString(dr["TvTag"]) : "";
                        Patient.Slide = DBNull.Value != dr["Slide"] ? Convert.ToInt32(dr["Slide"]) : 0;
                        Patient.Header = DBNull.Value != dr["Header"] ? Convert.ToString(dr["Header"]) : "";
                        Patient.Doc_Img = DBNull.Value != dr["Doc_Img"] ? Convert.ToString(dr["Doc_Img"]) : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }


        public List<res_doctor_tv> Doctor_TV()
        {
            List<res_doctor_tv> res = new List<res_doctor_tv>();

            DataSet ds = dataLayer.Doctor_TV();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_doctor_tv Patient = new res_doctor_tv();                   
                        Patient.Department = DBNull.Value != dr["Department"] ? Convert.ToString(dr["Department"]) : "";
                        Patient.SubDepartment = DBNull.Value != dr["SubDepartment"] ? Convert.ToString(dr["SubDepartment"]) : "";
                        Patient.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        Patient.Designation = DBNull.Value != dr["Designation"] ? Convert.ToString(dr["Designation"]) : "";
                        Patient.Qualification = DBNull.Value != dr["Qualification"] ? Convert.ToString(dr["Qualification"]) : "";
                        Patient.SlideSequence = DBNull.Value != dr["SlideSequence"] ? Convert.ToString(dr["SlideSequence"]) : "";
                        Patient.PictureName = DBNull.Value != dr["PictureName"] ? Convert.ToString(dr["PictureName"]) : "";
                        Patient.TvTag = DBNull.Value != dr["TvTag"] ? Convert.ToString(dr["TvTag"]) : "";
                        Patient.Slide = DBNull.Value != dr["Slide"] ? Convert.ToInt32(dr["Slide"]) : 0;
                        Patient.Header = DBNull.Value != dr["Header"] ? Convert.ToString(dr["Header"]) : "";
                        Patient.Doc_Img = DBNull.Value != dr["Doc_Img"] ? Convert.ToString(dr["Doc_Img"]) : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }



        public List<SlotRes_DTO> GetAppointmentSlot_Web(SlotReq_DTO slot_DTO)
        {
            List<SlotRes_DTO> slotRes_DTOs = new List<SlotRes_DTO>();
            DataSet ds = dataLayer.GetAppointmentSlot_Web(slot_DTO);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SlotRes_DTO slotRes_DTO = new SlotRes_DTO();

                        //slotRes_DTO.StartDateTime = DBNull.Value != dr["StartDateTime"] ? dr["StartDateTime"].ToString() : "";
                        //slotRes_DTO.EndDateTime = DBNull.Value != dr["EndDateTime"] ? dr["EndDateTime"].ToString() : "";
                        slotRes_DTO.StartDateTime = DBNull.Value != dr["StartDateTime"] ? dr["StartDateTime"].ToString() : "";
                        slotRes_DTO.EndDateTime = DBNull.Value != dr["EndDateTime"] ? dr["EndDateTime"].ToString() : "";
                        slotRes_DTO.SlotType = DBNull.Value != dr["SlotType"] ? Convert.ToInt32(dr["SlotType"]) : 0;
                        slotRes_DTOs.Add(slotRes_DTO);
                    }
                }
            }

            return slotRes_DTOs;
        }


        public List<SlotRes_DTO_seq> GetAvailableAppointmentSlot_Web_seq(SlotReq_DTO_seq slot_DTO)
        {
            List<SlotRes_DTO_seq> slotRes_DTOs = new List<SlotRes_DTO_seq>();
            DataSet ds = dataLayer.GetAvailableAppointmentSlot_Web_seq(slot_DTO);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SlotRes_DTO_seq slotRes_DTO = new SlotRes_DTO_seq();

                        //slotRes_DTO.StartDateTime = DBNull.Value != dr["StartDateTime"] ? dr["StartDateTime"].ToString() : "";
                        //slotRes_DTO.EndDateTime = DBNull.Value != dr["EndDateTime"] ? dr["EndDateTime"].ToString() : "";
                        slotRes_DTO.StartDateTime = DBNull.Value != dr["StartDateTime"] ? dr["StartDateTime"].ToString() : "";
                        slotRes_DTO.EndDateTime = DBNull.Value != dr["EndDateTime"] ? dr["EndDateTime"].ToString() : "";
                        slotRes_DTO.SlotType = DBNull.Value != dr["SlotType"] ? Convert.ToInt32(dr["SlotType"]) : 0;
                        slotRes_DTO.StartDateTime1 = DBNull.Value != dr["StartDateTime1"] ? dr["StartDateTime1"].ToString() : "";
                        

                        slotRes_DTOs.Add(slotRes_DTO);
                    }
                }
            }

            return slotRes_DTOs;
        }

        
        public List<clsDoctor> GetDoctorNameDepWiseDocID(DepartmentwiseDoctorFilter dep)
        {
            List<clsDoctor> dropdown_DTOs = new List<clsDoctor>();
            DataSet ds = dataLayer.GetDoctorNameDepWiseDocID(dep);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsDoctor dropdown_DTO = new clsDoctor();

                        dropdown_DTO.doctorid = DBNull.Value != dr["Mdoc_DoctorId_id"] ? Convert.ToInt32(dr["Mdoc_DoctorId_id"]) : 0;
                        dropdown_DTO.doctorname = DBNull.Value != dr["Mdoc_DoctorName_nm"] ? Convert.ToString(dr["Mdoc_DoctorName_nm"]) : "";
                        dropdown_DTO.chargerate = DBNull.Value != dr["Mdoc_ChargeRate_nm"] ? Convert.ToDecimal(dr["Mdoc_ChargeRate_nm"]) : 0;
                        dropdown_DTO.profilelink = DBNull.Value != dr["Mdoc_ProfileLink_Desc"] ? Convert.ToString(dr["Mdoc_ProfileLink_Desc"]) : "#";
                        dropdown_DTO.qualification = DBNull.Value != dr["Mdoc_Qualification_desc"] ? Convert.ToString(dr["Mdoc_Qualification_desc"]) : "";
                        dropdown_DTO.photo_img = DBNull.Value != dr["Mdoc_Photo_img"] ? (byte[])(dr["Mdoc_Photo_img"]) : null;
                        dropdown_DTO.designation = DBNull.Value != dr["Mdoc_ShortDescription_Desc"] ? Convert.ToString(dr["Mdoc_ShortDescription_Desc"]) : "";
                        //DBNull.Value != dr["Mdoc_Photo_img"] ? (byte[]) dr["Mdoc_Photo_img"] : new byte();
                        dropdown_DTOs.Add(dropdown_DTO);
                    }
                }
            }

            return dropdown_DTOs;
        }

        public appointment_Response createAppointment(AppointmentBooking appointmentBooking)
        {
            appointment_Response response = new appointment_Response();

            DataSet ds = dataLayer.update_appointment(appointmentBooking);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.msgDescp = DBNull.Value != dr["MsgDescp"] ? Convert.ToString(dr["MsgDescp"]) : "";
                        response.appointmentID = DBNull.Value != dr["appointmentID"] ? Convert.ToString(dr["appointmentID"]) : "";        
                        response.Age = DBNull.Value != dr["age"] ? Convert.ToString(dr["age"]) : "";
                        response.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        response.DoctorName = DBNull.Value != dr["DocName"] ? Convert.ToString(dr["DocName"]) : "";
                        response.AppointmentDate = DBNull.Value != dr["datepart"] ? Convert.ToString(dr["datepart"]) : "";
                        response.TimeSlot = DBNull.Value != dr["TimePart"] ? Convert.ToString(dr["TimePart"]) : "";
                        response.EmailId = DBNull.Value != dr["emailId"] ? Convert.ToString(dr["emailId"]) : "";
                        response.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";


                    }
                }
            }

            return response;
        }

        public List<Res_AvlSlotValidation> Get_AvlSlotValidation(int DocId, string APPDate, int SlotNo)
        {
            List<Res_AvlSlotValidation> res = new List<Res_AvlSlotValidation>();

            DataSet ds = dataLayer.Get_AvlSlotValidation(DocId, APPDate, SlotNo);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Res_AvlSlotValidation Patient = new Res_AvlSlotValidation();

                        Patient.Abkg_AppointmentId_id = DBNull.Value != dr["Abkg_AppointmentId_id"] ? Convert.ToInt32(dr["Abkg_AppointmentId_id"]) : 0;

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<Res_insurance_Patient> Get_IP_insurance_Patient()
        {
            List<Res_insurance_Patient> res = new List<Res_insurance_Patient>();

            DataSet ds = dataLayer.Get_IP_insurance_Patient();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Res_insurance_Patient Patient = new Res_insurance_Patient();

                            Patient.S_No = DBNull.Value != dr["S_No"] ? Convert.ToInt32(dr["S_No"]) : 0;
                            Patient.Admission_Date = DBNull.Value != dr["Admission_Date"] ? Convert.ToString(dr["Admission_Date"]) : "";
                            Patient.BedName = DBNull.Value != dr["BedName"] ? dr["BedName"].ToString() : "";
                            Patient.UHID = DBNull.Value != dr["UHID"] ? dr["UHID"].ToString() : "";
                            Patient.Patient_Name = DBNull.Value != dr["Patient_Name"] ? dr["Patient_Name"].ToString() : "";
                            Patient.PayorName = DBNull.Value != dr["PayorName"] ? dr["PayorName"].ToString() : "";
                            Patient.Claim_No = DBNull.Value != dr["Claim_No"] ? dr["Claim_No"].ToString() : "";
                            Patient.Admitting_Consultant = DBNull.Value != dr["Admitting_Consultant"] ? dr["Admitting_Consultant"].ToString() : "";
                            Patient.Admitting_Department = DBNull.Value != dr["Admitting_Department"] ? dr["Admitting_Department"].ToString() : "";
                            Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                            Patient.Gender = DBNull.Value != dr["Gender"] ? dr["Gender"].ToString() : "";
                            Patient.Admission_Category = DBNull.Value != dr["Admission_Category"] ? dr["Admission_Category"].ToString() : "";
                            Patient.Discharge_Date = DBNull.Value != dr["Discharge_Date"] ? Convert.ToString(dr["Discharge_Date"]) : "";
                            Patient.Bill_No = DBNull.Value != dr["Bill_No"] ? dr["Bill_No"].ToString() : "";
                            Patient.Insurance_Amount = DBNull.Value != dr["Insurance_Amount"] ? Convert.ToDecimal(dr["Insurance_Amount"]) : 0;
                            Patient.Due = DBNull.Value != dr["Due"] ? Convert.ToDecimal(dr["Due"]) : 0;
                            Patient.AdmNo = DBNull.Value != dr["AdmNo"] ? dr["AdmNo"].ToString() : "";
                            Patient.Nationality = DBNull.Value != dr["Nationality"] ? dr["Nationality"].ToString() : "";
                            Patient.MainInsurance = DBNull.Value != dr["MainInsurance"] ? dr["MainInsurance"].ToString() : "";
                            Patient.CompanyName = DBNull.Value != dr["CompanyName"] ? dr["CompanyName"].ToString() : "";
                            Patient.Gipsa = DBNull.Value != dr["Gipsa"] ? dr["Gipsa"].ToString() : "";
                            Patient.PPNGipsa = DBNull.Value != dr["PPNGipsa"] ? dr["PPNGipsa"].ToString() : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<SurgicalDepartment> GetSurgicalDepartment()
        {
            List<SurgicalDepartment> res = new List<SurgicalDepartment>();

            DataSet ds = dataLayer.GetSurgicalDepartment();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SurgicalDepartment Patient = new SurgicalDepartment();

                        Patient.DeptID = DBNull.Value != dr["DeptID"] ? Convert.ToInt32(dr["DeptID"]) : 0;
                        Patient.Department_name = DBNull.Value != dr["Department_name"] ? Convert.ToString(dr["Department_name"]) : "";
                        Patient.Created_by = DBNull.Value != dr["Created_by"] ? dr["Created_by"].ToString() : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public res_OTProcedure Save_OTProcedure(req_OTProcedure request)
        {
            res_OTProcedure response = new res_OTProcedure();

            DataSet ds = dataLayer.Save_OTProcedure(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                      
                    }
                }
            }

            return response;
        }

        public List<OTProcedure> GetOTProcedure()
        {
            List<OTProcedure> res = new List<OTProcedure>();

            DataSet ds = dataLayer.GetOTProcedure();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        OTProcedure Patient = new OTProcedure();
                                     
                        Patient.Proce_No = DBNull.Value != dr["Proce_No"] ? Convert.ToInt32(dr["Proce_No"]) : 0;
                        Patient.Procedure_ID = DBNull.Value != dr["Procedure_ID"] ? Convert.ToString(dr["Procedure_ID"]) : "";
                        Patient.Procedure_Name = DBNull.Value != dr["Procedure_Name"] ? dr["Procedure_Name"].ToString() : "";
                        Patient.Department_name = DBNull.Value != dr["Department_name"] ? dr["Department_name"].ToString() : "";
                        Patient.Created_by = DBNull.Value != dr["Created_by"] ? dr["Created_by"].ToString() : "";
                        Patient.Created_User = DBNull.Value != dr["Created_User"] ? dr["Created_User"].ToString() : "";
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<clsInsurance_Pre_Auth> GetInsurance_Pre_Auth()
        {
            List<clsInsurance_Pre_Auth> res = new List<clsInsurance_Pre_Auth>();

            DataSet ds = dataLayer.GetInsurance_Pre_Auth();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInsurance_Pre_Auth Patient = new clsInsurance_Pre_Auth();

                        Patient.AdmNo = DBNull.Value != dr["AdmNo"] ? Convert.ToString(dr["AdmNo"]) : "";
                        Patient.Presenting_Complaints = DBNull.Value != dr["Presenting Complaints"] ? Convert.ToString(dr["Presenting Complaints"]) : "";
                        Patient.Duration_Of_Stay = DBNull.Value != dr["Duration Of Stay"] ? dr["Duration Of Stay"].ToString() : "";
                        Patient.Provisional_Diagnosis = DBNull.Value != dr["Provisional Diagnosis"] ? dr["Provisional Diagnosis"].ToString() : "";
                        Patient.Plan_of_Treatment = DBNull.Value != dr["Plan of Treatment"] ? dr["Plan of Treatment"].ToString() : "";
                        Patient.Admission_Date = DBNull.Value != dr["Admission Date"] ? dr["Admission Date"].ToString() : "";
                        Patient.Patient_Name = DBNull.Value != dr["Patient Name"] ? dr["Patient Name"].ToString() : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? dr["UHID"].ToString() : "";        
                        Patient.BEDNo = DBNull.Value != dr["BEDNo"] ? dr["BEDNo"].ToString() : "";
                        Patient.CreatedDate = DBNull.Value != dr["Created Date"] ? dr["Created Date"].ToString() : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }
        public List<DoctorseqSlotGap> Get_DoctorseqSlotGap(int DoctorId)
        {
            List<DoctorseqSlotGap> res = new List<DoctorseqSlotGap>();

            DataSet ds = dataLayer.Get_DoctorseqSlotGap( DoctorId);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DoctorseqSlotGap Patient = new DoctorseqSlotGap();

                        Patient.Mdoc_DoctorseqSlotGap_Nbr = DBNull.Value != dr["Mdoc_DoctorseqSlotGap_Nbr"] ? Convert.ToInt32(dr["Mdoc_DoctorseqSlotGap_Nbr"]) : 0;
                    
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<ConsultantSlot> AvailableConsultantSlot(int DoctorId, string FromDate, string ToDate)
        {
            List<ConsultantSlot> res = new List<ConsultantSlot>();

            DataSet ds = dataLayer.AvailableConsultantSlot( DoctorId,  FromDate,  ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ConsultantSlot Patient = new ConsultantSlot();

                        Patient.TotalSlot = DBNull.Value != dr["TotalSlot"] ? Convert.ToInt32(dr["TotalSlot"]) : 0;

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public appointment_Response createAppointment_seq(AppointmentBooking_seq appointmentBooking_seq) 
        {
            appointment_Response response = new appointment_Response();

            DataSet ds = dataLayer.update_appointment_seq(appointmentBooking_seq);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";                                  
                        response.msgDescp = DBNull.Value != dr["MsgDescp"] ? Convert.ToString(dr["MsgDescp"]) : "";                          
                        response.appointmentID = DBNull.Value != dr["appointmentID"] ? Convert.ToString(dr["appointmentID"]) : "";
                        response.Age = DBNull.Value != dr["age"] ? Convert.ToString(dr["age"]) : "";                   
                        response.DoctorName = DBNull.Value != dr["DocName"] ? Convert.ToString(dr["DocName"]) : "";                    
                        response.AppointmentDate = DBNull.Value != dr["appointmentDate"] ? Convert.ToString(dr["appointmentDate"]) : "";                     
                        response.TimeSlot = DBNull.Value != dr["timeSlot"] ? Convert.ToString(dr["timeSlot"]) : ""; 
                        response.EmailId = DBNull.Value != dr["emailId"] ? Convert.ToString(dr["emailId"]) : "";
                        response.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";


                    }
                }
            }

            return response;
        }

        public update_Doctor_TV_Res update_Doctor_TV(update_Doctor_TV_req request)
        {
            update_Doctor_TV_Res result = new update_Doctor_TV_Res();
            DataSet ds = dataLayer.update_Doctor_TV(request);

            if (ds != null)
            {
                result.TvTag = DBNull.Value != ds.Tables[0].Rows[0]["TvTag"] ? Convert.ToString(ds.Tables[0].Rows[0]["TvTag"]) : "";
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }


        public delete_Doctor_TV_Res Delete_Doctor_TV(delete_Doctor_TV_req request)
        {
            delete_Doctor_TV_Res result = new delete_Doctor_TV_Res();
            DataSet ds = dataLayer.Delete_Doctor_TV(request);

            if (ds != null)
            {
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }

        public List<AppointmentSlotDTO> GetAppointmentSlotDetails(AppointmentSlotDTO appointmentSlot)
        {
            List<AppointmentSlotDTO> appointmentSlots = new List<AppointmentSlotDTO>();
            DataSet ds = dataLayer.GetAppointmentSlotDetails(appointmentSlot);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        AppointmentSlotDTO po = new AppointmentSlotDTO();
       
                        po.DoctorID = appointmentSlot.DoctorID;
                        po.AppointmentDate = appointmentSlot.AppointmentDate;
                        po.AvailableSlotsStDttm = DBNull.Value != dr["StartDateTime"] ? Convert.ToString(dr["StartDateTime"]) : "";
                        po.AvailableSlotsEndDttm = DBNull.Value != dr["EndDateTime"] ? Convert.ToString(dr["EndDateTime"]) : "";
                        po.SlotType = Convert.ToInt16(dr["SlotType"]);
                        appointmentSlots.Add(po);
                    }
                }
            }

            return appointmentSlots;
        }


        public List<AppointmentSlotDTO> GetAppointmentSlotDaysDetails(AppointmentSlotDTO appointmentSlot)
        {
            List<AppointmentSlotDTO> appointmentSlots = new List<AppointmentSlotDTO>();
            DataSet ds = dataLayer.GetAppointmentSlotDaysDetails(appointmentSlot);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        AppointmentSlotDTO po = new AppointmentSlotDTO();

                        //po.DoctorID = DBNull.Value != dr["Mspc_SpecialisationCode_cd"] ? Convert.ToInt32(dr["Mspc_SpecialisationCode_cd"]) : 0;
                        po.DoctorID = appointmentSlot.DoctorID;
                        po.AppointmentDate = DBNull.Value != dr["AvailableDate"] ? Convert.ToString(dr["AvailableDate"]) : "";
                        po.AvailableSlotsStDttm = "";
                        po.AvailableSlotsEndDttm = "";
                        po.SlotType = Convert.ToInt16(dr["SlotType"]);
                        appointmentSlots.Add(po);
                    }
                }
            }

            return appointmentSlots;
        }

        public List<res_mepz> getmepz()
        {
            List<res_mepz> res = new List<res_mepz>();

            DataSet ds = dataLayer.getmepz();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_mepz Patient = new res_mepz();

                        Patient.Mepz_Code = DBNull.Value != dr["Mepz_Code"] ? Convert.ToString(dr["Mepz_Code"]) : "";
                        Patient.Name = DBNull.Value != dr["Name"] ? Convert.ToString(dr["Name"]) : "";
                        Patient.Company_Name = DBNull.Value != dr["Company_Name"] ? Convert.ToString(dr["Company_Name"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Mobile = DBNull.Value != dr["Mobile"] ? Convert.ToString(dr["Mobile"]) : "";
                        Patient.DOB = DBNull.Value != dr["DOB"] ? Convert.ToDateTime(dr["DOB"]).ToString("dd-MM-yyyy") : "";
                        Patient.Marital_Status = DBNull.Value != dr["Marital_Status"] ? Convert.ToString(dr["Marital_Status"]) : "";
                        Patient.Family_Diabetics = DBNull.Value != dr["Family_Diabetics"] ? Convert.ToString(dr["Family_Diabetics"]) : "";
                        Patient.Family_Hypertension = DBNull.Value != dr["Family_Hypertension"] ? Convert.ToString(dr["Family_Hypertension"]) : "";
                        Patient.Family_Heart_Disease = DBNull.Value != dr["Family_Heart_Disease"] ? Convert.ToString(dr["Family_Heart_Disease"]) : "";
                        Patient.Family_Arthritis = DBNull.Value != dr["Family_Arthritis"] ? Convert.ToString(dr["Family_Arthritis"]) : "";
                        Patient.Family_Tuberculosis = DBNull.Value != dr["Family_Tuberculosis"] ? Convert.ToString(dr["Family_Tuberculosis"]) : "";
                        Patient.Family_Asthma = DBNull.Value != dr["Family_Asthma"] ? Convert.ToString(dr["Family_Asthma"]) : "";
                        Patient.Family_Cancer = DBNull.Value != dr["Family_Cancer"] ? Convert.ToString(dr["Family_Cancer"]) : "";
                        Patient.Family_Epilepsy = DBNull.Value != dr["Family_Epilepsy"] ? Convert.ToString(dr["Family_Epilepsy"]) : "";
                        Patient.Family_Mentaor_Nervous_Disorder = DBNull.Value != dr["Family_Mentaor_Nervous_Disorder"] ? Convert.ToString(dr["Family_Mentaor_Nervous_Disorder"]) : "";
                        Patient.Family_Any_Other_Disease = DBNull.Value != dr["Family_Any_Other_Disease"] ? Convert.ToString(dr["Family_Any_Other_Disease"]) : "";

                        Patient.Personal_Good_health_and_capable_of_full_work = DBNull.Value != dr["Personal_Good_health_and_capable_of_full_work"] ? Convert.ToString(dr["Personal_Good_health_and_capable_of_full_work"]) : "";
                        Patient.Personal_Good_health_reason = DBNull.Value != dr["Personal_Good_health_reason"] ? Convert.ToString(dr["Personal_Good_health_reason"]) : "";


                        Patient.Personal_Disease_or_Injury = DBNull.Value != dr["Personal_Disease_or_Injury"] ? Convert.ToString(dr["Personal_Disease_or_Injury"]) : "";
                        Patient.Personal_Disease_or_Injury_reason = DBNull.Value != dr["Personal_Disease_or_Injury_reason"] ? Convert.ToString(dr["Personal_Disease_or_Injury_reason"]) : "";

                        Patient.Personal_Rejected_on_Medical_Grounds = DBNull.Value != dr["Personal_Rejected_on_Medical_Grounds"] ? Convert.ToString(dr["Personal_Rejected_on_Medical_Grounds"]) : "";
                        Patient.Personal_Rejected_on_Medical_Grounds_reason = DBNull.Value != dr["Personal_Rejected_on_Medical_Grounds_reason"] ? Convert.ToString(dr["Personal_Rejected_on_Medical_Grounds_reason"]) : "";

                        Patient.Others = DBNull.Value != dr["Others"] ? Convert.ToString(dr["Others"]) : "";
                        Patient.Vaccination = DBNull.Value != dr["Vaccination"] ? Convert.ToString(dr["Vaccination"]) : "";
                        Patient.Personal_Heart_Disease = DBNull.Value != dr["Personal_Heart_Disease"] ? Convert.ToString(dr["Personal_Heart_Disease"]) : "";
                        Patient.Personal_Hypertension = DBNull.Value != dr["Personal_Hypertension"] ? Convert.ToString(dr["Personal_Hypertension"]) : "";
                        Patient.Personal_Diabetes = DBNull.Value != dr["Personal_Diabetes"] ? Convert.ToString(dr["Personal_Diabetes"]) : "";
                        Patient.Personal_KidneyDisease = DBNull.Value != dr["Personal_KidneyDisease"] ? Convert.ToString(dr["Personal_KidneyDisease"]) : "";
                        Patient.Personal_Asthma = DBNull.Value != dr["Personal_Asthma"] ? Convert.ToString(dr["Personal_Asthma"]) : "";
                        Patient.Personal_Tuberculosis = DBNull.Value != dr["Personal_Tuberculosis"] ? Convert.ToString(dr["Personal_Tuberculosis"]) : "";
                        Patient.Personal_Dermatitis = DBNull.Value != dr["Personal_Dermatitis"] ? Convert.ToString(dr["Personal_Dermatitis"]) : "";
                        Patient.Personal_Epilepsy = DBNull.Value != dr["Personal_Epilepsy"] ? Convert.ToString(dr["Personal_Epilepsy"]) : "";
                        Patient.Personal_Allergy = DBNull.Value != dr["Personal_Allergy"] ? Convert.ToString(dr["Personal_Allergy"]) : "";
                        Patient.Personal_Major_Operation = DBNull.Value != dr["Personal_Major_Operation"] ? Convert.ToString(dr["Personal_Major_Operation"]) : "";
                        Patient.Personal_HepatitisB = DBNull.Value != dr["Personal_HepatitisB"] ? Convert.ToString(dr["Personal_HepatitisB"]) : "";
                        Patient.Chronic_Lung_Disease = DBNull.Value != dr["Chronic_Lung_Disease"] ? Convert.ToString(dr["Chronic_Lung_Disease"]) : "";
                        Patient.Any_Other_Illness = DBNull.Value != dr["Any_Other_Illness"] ? Convert.ToString(dr["Any_Other_Illness"]) : "";
                        Patient.Chronic_Ear_Problem = DBNull.Value != dr["Chronic_Ear_Problem"] ? Convert.ToString(dr["Chronic_Ear_Problem"]) : "";
                        Patient.Pysical_Handicap = DBNull.Value != dr["Pysical_Handicap"] ? Convert.ToString(dr["Pysical_Handicap"]) : "";
                        Patient.Others_Details = DBNull.Value != dr["Others_Details"] ? Convert.ToString(dr["Others_Details"]) : "";
                        Patient.Height = DBNull.Value != dr["Height"] ? Convert.ToInt32(dr["Height"]) : 0;
                        Patient.Weight = DBNull.Value != dr["Weight"] ? Convert.ToInt32(dr["Weight"]) : 0;
                        Patient.BMI = DBNull.Value != dr["BMI"] ? Convert.ToInt32(dr["BMI"]) : 0;
                        Patient.BP = DBNull.Value != dr["BP"] ? Convert.ToString(dr["BP"]) : "";
                        Patient.Pulse = DBNull.Value != dr["Pulse"] ? Convert.ToInt32(dr["Pulse"]) : 0;
                        Patient.Spo2 = DBNull.Value != dr["Spo2"] ? Convert.ToInt32(dr["Spo2"]) : 0;
                        Patient.Temp = DBNull.Value != dr["Temp"] ? Convert.ToInt32(dr["Temp"]) : 0;
                        Patient.CBG = DBNull.Value != dr["CBG"] ? Convert.ToInt32(dr["CBG"]) : 0;
                        Patient.ECG = DBNull.Value != dr["ECG"] ? Convert.ToString(dr["ECG"]) : "";
                        Patient.Dental_Examination = DBNull.Value != dr["Dental_Examination"] ? Convert.ToString(dr["Dental_Examination"]) : "";
                        Patient.Eye_Examination = DBNull.Value != dr["Eye_Examination"] ? Convert.ToString(dr["Eye_Examination"]) : "";
                        Patient.Diagnosis = DBNull.Value != dr["Diagnosis"] ? Convert.ToString(dr["Diagnosis"]) : "";
                        Patient.Recommendations = DBNull.Value != dr["Recommendations"] ? Convert.ToString(dr["Recommendations"]) : "";
                        Patient.Medication = DBNull.Value != dr["Medication"] ? Convert.ToString(dr["Medication"]) : "";
                        Patient.Diagnosis1 = DBNull.Value != dr["Diagnosis1"] ? Convert.ToString(dr["Diagnosis1"]) : "";
                        Patient.Final_department = DBNull.Value != dr["Final_department"] ? Convert.ToString(dr["Final_department"]) : "";
                        Patient.PAP_SMEAR_No = DBNull.Value != dr["PAP_SMEAR_No"] ? Convert.ToString(dr["PAP_SMEAR_No"]) : "";
                        Patient.PAP_SMEAR_details = DBNull.Value != dr["PAP_SMEAR_details"] ? Convert.ToString(dr["PAP_SMEAR_details"]) : "";
                        Patient.Scaling = DBNull.Value != dr["Scaling"] ? Convert.ToString(dr["Scaling"]) : "";
                        Patient.Filling = DBNull.Value != dr["Filling"] ? Convert.ToString(dr["Filling"]) : "";
                        Patient.Prostho = DBNull.Value != dr["Prostho"] ? Convert.ToString(dr["Prostho"]) : "";
                        Patient.Extraction = DBNull.Value != dr["Extraction"] ? Convert.ToString(dr["Extraction"]) : "";
                        Patient.PERIO = DBNull.Value != dr["PERIO"] ? Convert.ToString(dr["PERIO"]) : "";
                        Patient.Ortho = DBNull.Value != dr["Ortho"] ? Convert.ToString(dr["Ortho"]) : "";
                        Patient.ECHO = DBNull.Value != dr["ECHO"] ? Convert.ToString(dr["ECHO"]) : "";
                        Patient.Mammo = DBNull.Value != dr["Mammo"] ? Convert.ToString(dr["Mammo"]) : "";
                        Patient.Recommended = DBNull.Value != dr["Recommended"] ? Convert.ToString(dr["Recommended"]) : "";
                        Patient.Vaccination_status = DBNull.Value != dr["Vaccination_status"] ? Convert.ToString(dr["Vaccination_status"]) : "";

                        Patient.BloodSugar = DBNull.Value != dr["Blood_Sugar"] ? Convert.ToString(dr["Blood_Sugar"]) : "";

                        Patient.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";

                        Patient.Systemic_examination = DBNull.Value != dr["Systemic_examination"] ? Convert.ToString(dr["Systemic_examination"]) : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }


        public update_Mepz_tb_res update_Mepz_tb(update_Mepz_tb_req request)
        {
            update_Mepz_tb_res result = new update_Mepz_tb_res();
            DataSet ds = dataLayer.update_Mepz_tb(request);

            if (ds != null)
            {
                result.Mepz_Code = DBNull.Value != ds.Tables[0].Rows[0]["Mepz_Code"] ? Convert.ToString(ds.Tables[0].Rows[0]["Mepz_Code"]) : "";
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }

        public signatureModel_res Signature_Upload(req_signatureModel request)
        {
            signatureModel_res result = new signatureModel_res();

            DataSet ds = dataLayer.Signature_Upload(request);

            if (ds != null)
            {

                result.PatientId = DBNull.Value != ds.Tables[0].Rows[0]["PatientId"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["PatientId"]) : 0;
                result.pictureName = DBNull.Value != ds.Tables[0].Rows[0]["pictureName"] ? Convert.ToString(ds.Tables[0].Rows[0]["pictureName"]) : "";
                result.picFileName = DBNull.Value != ds.Tables[0].Rows[0]["picFileName"] ? Convert.ToString(ds.Tables[0].Rows[0]["picFileName"]) : "";
                result.Image = DBNull.Value != ds.Tables[0].Rows[0]["Image"] ? Convert.ToString(ds.Tables[0].Rows[0]["Image"]) : "";
                result.Active = DBNull.Value != ds.Tables[0].Rows[0]["Active"] ? Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]) : true;
                result.CreatedUser = DBNull.Value != ds.Tables[0].Rows[0]["CreatedUser"] ? Convert.ToString(ds.Tables[0].Rows[0]["CreatedUser"]) : "";
                result.ModifiedUser = DBNull.Value != ds.Tables[0].Rows[0]["ModifiedUser"] ? Convert.ToString(ds.Tables[0].Rows[0]["ModifiedUser"]) : "";
                result.CreatedDate = DBNull.Value != ds.Tables[0].Rows[0]["CreatedDate"] ? Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]) : "";
                result.ModifiedDate = DBNull.Value != ds.Tables[0].Rows[0]["ModifiedDate"] ? Convert.ToString(ds.Tables[0].Rows[0]["ModifiedDate"]) : "";
        
            }

            return result;
        }

        public PatientVenue_res Save_PatientVenue_temp(req_PatientVenue request)
        {
            PatientVenue_res result = new PatientVenue_res();

            DataSet ds = dataLayer.Save_PatientVenue_temp(request);

            if (ds != null)
            {
                result.patientId = DBNull.Value != ds.Tables[0].Rows[0]["patientId"] ? Convert.ToString(ds.Tables[0].Rows[0]["patientId"]) : "";
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";
            }

            return result;
        }


        public List<res_RevenueReport> PharmacyRevenueReport(string FromDate, string ToDate)
        {
            List<res_RevenueReport> res = new List<res_RevenueReport>();

            DataSet ds = dataLayer.PharmacyRevenueReport(FromDate, ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                            res_RevenueReport Patient = new res_RevenueReport();

                        Patient.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                        Patient.BillDate = DBNull.Value != dr["BillDate"] ? Convert.ToString(dr["BillDate"]) : "";
                        Patient.ServiceGroup = DBNull.Value != dr["ServiceGroup"] ? Convert.ToString(dr["ServiceGroup"]) : "";
                        Patient.ServiceName = DBNull.Value != dr["ServiceName"] ? Convert.ToString(dr["ServiceName"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.OrderDoctor = DBNull.Value != dr["OrderDoctor"] ? Convert.ToString(dr["OrderDoctor"]) : "";
                        Patient.OrderDepartment = DBNull.Value != dr["OrderDepartment"] ? Convert.ToString(dr["OrderDepartment"]) : "";
                        Patient.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        Patient.Discount = DBNull.Value != dr["Discount"] ? Convert.ToInt32(dr["Discount"]) : 0;
                        Patient.Net = DBNull.Value != dr["Net"] ? Convert.ToInt32(dr["Net"]) : 0;
                        Patient.Payer = DBNull.Value != dr["Payer"] ? Convert.ToString(dr["Payer"]) : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<res_OPIPREVENUE_Date> OPIPREVENUE_Date(string FromDate, string ToDate, string Pattype, int IVF_flg)
        {
            List<res_OPIPREVENUE_Date> res = new List<res_OPIPREVENUE_Date>();

            DataSet ds = dataLayer.OPIPREVENUE_Date(FromDate, ToDate, Pattype, IVF_flg);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_OPIPREVENUE_Date Patient = new res_OPIPREVENUE_Date();

                        Patient.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                        Patient.BillDate = DBNull.Value != dr["BillDate"] ? Convert.ToDateTime(dr["BillDate"]).ToString("dd-MM-yyyy") : "";
                        Patient.ServiceGroup = DBNull.Value != dr["ServiceGroup"] ? Convert.ToString(dr["ServiceGroup"]) : "";
                        Patient.ServiceName = DBNull.Value != dr["ServiceName"] ? Convert.ToString(dr["ServiceName"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.OrderDoctor = DBNull.Value != dr["OrderDoctor"] ? Convert.ToString(dr["OrderDoctor"]) : "";
                        Patient.OrderDepartment = DBNull.Value != dr["OrderDepartment"] ? Convert.ToString(dr["OrderDepartment"]) : "";
                        Patient.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        Patient.Discount = DBNull.Value != dr["Discount"] ? Convert.ToString(dr["Discount"]) : "";
                        Patient.Net = DBNull.Value != dr["Net"] ? Convert.ToString(dr["Net"]) : "";
                        Patient.Payer = DBNull.Value != dr["Payer"] ? Convert.ToString(dr["Payer"]) : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<res_REVENUE_Date> Revenu_dashboard(string FromDate, string ToDate)
        {
            List<res_REVENUE_Date> res = new List<res_REVENUE_Date>();

            DataSet ds = dataLayer.Revenu_dashboard(FromDate, ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_REVENUE_Date Patient = new res_REVENUE_Date();

                        //Patient.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                        Patient.BillDate = DBNull.Value != dr["BillDate"] ? Convert.ToDateTime(dr["BillDate"]).ToString("dd-MM-yyyy") : "";          
                        Patient.ServiceGroup = DBNull.Value != dr["ServiceGroup"] ? Convert.ToString(dr["ServiceGroup"]) : "";
                        Patient.ServiceName = DBNull.Value != dr["ServiceName"] ? Convert.ToString(dr["ServiceName"]) : "";
                        Patient.OrderDoctor = DBNull.Value != dr["OrderDoctor"] ? Convert.ToString(dr["OrderDoctor"]) : "";
                        Patient.OrderDepartment = DBNull.Value != dr["OrderDepartment"] ? Convert.ToString(dr["OrderDepartment"]) : "";
                        Patient.Net = DBNull.Value != dr["Net"] ? Convert.ToString(dr["Net"]) : "";
                        // Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        //  Patient.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";
                        //  Patient.Discount = DBNull.Value != dr["Discount"] ? Convert.ToString(dr["Discount"]) : "";
                        //  Patient.Payer = DBNull.Value != dr["Payer"] ? Convert.ToString(dr["Payer"]) : "";

                        res.Add(Patient);
                    }
                }
            }
            return res;
        }

        public List<res_PatientRelation> Signature_PatientRelation()
        {
            List<res_PatientRelation> res = new List<res_PatientRelation>();

            DataSet ds = dataLayer.Signature_PatientRelation();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_PatientRelation Patient = new res_PatientRelation();
                    
                        Patient.RelationshipCode = DBNull.Value != dr["Rltn_RelationshipCode_cd"] ? Convert.ToInt32(dr["Rltn_RelationshipCode_cd"]) : 0;
                        Patient.RelationshipType = DBNull.Value != dr["Rltn_RelationshipName_nm"] ? Convert.ToString(dr["Rltn_RelationshipName_nm"]) : "";
            
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }


        public List<DoctorDTO> GetDoctorDetails()
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            DataSet ds = dataLayer.GetDoctorDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DoctorDTO po = new DoctorDTO();

                        po.DoctorID = DBNull.Value != dr["Mdoc_DoctorId_id"] ? Convert.ToInt32(dr["Mdoc_DoctorId_id"]) : 0;
                        po.DoctorName = DBNull.Value != dr["Mdoc_DoctorName_nm"] ? Convert.ToString(dr["Mdoc_DoctorName_nm"]) : "";
                        po.DepartmentID = DBNull.Value != dr["Mdoc_Department_nbr"] ? Convert.ToInt32(dr["Mdoc_Department_nbr"]) : 0;
                        po.SpecializationID = DBNull.Value != dr["Mspc_SpecialisationCode_cd"] ? Convert.ToInt32(dr["Mspc_SpecialisationCode_cd"]) : 0;

                        po.Shortdescription = DBNull.Value != dr["Mdoc_ShortDescription_Desc"] ? Convert.ToString(dr["Mdoc_ShortDescription_Desc"]) : "";
                        po.Profilepagelink = DBNull.Value != dr["Mdoc_ProfileLink_Desc"] ? Convert.ToString(dr["Mdoc_ProfileLink_Desc"]) : "";
                        po.Video_ConsCharges = DBNull.Value != dr["Mdoc_FollowupChargeRate_Nbr"] ? Convert.ToString(dr["Mdoc_FollowupChargeRate_Nbr"]) : "";
                        po.Walkin_ConsCharges = DBNull.Value != dr["Mdoc_Video_Cons_ChargeRate_nm"] ? Convert.ToString(dr["Mdoc_Video_Cons_ChargeRate_nm"]) : "";
                        if (dr["Mdoc_Photo_img"] != DBNull.Value)
                        {
                            po.DoctorImg = (Byte[])dr["Mdoc_Photo_img"];
                        }
                        doctors.Add(po);
                    }
                }
            }

            return doctors;
        }
        public List<res_PIS_StatDetails_dtl> Get_PIS_StatDetails_dtl()
        {
            List<res_PIS_StatDetails_dtl> res = new List<res_PIS_StatDetails_dtl>();

            DataSet ds = dataLayer.Get_PIS_StatDetails_dtl();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        res_PIS_StatDetails_dtl Patient = new res_PIS_StatDetails_dtl();

                        Patient.SNO = DBNull.Value != dr["SNO"] ? Convert.ToInt32(dr["SNO"]) : 0;
                        Patient.TYPE = DBNull.Value != dr["TYPE"] ? Convert.ToString(dr["TYPE"]) : "";
                        Patient.ORDERNO = DBNull.Value != dr["ORDERNO"] ? Convert.ToString(dr["ORDERNO"]) : "";           
                        Patient.ORDERDATE = DBNull.Value != dr["ORDERDATE"] ? Convert.ToString(dr["ORDERDATE"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PATIENTNAME = DBNull.Value != dr["PATIENTNAME"] ? Convert.ToString(dr["PATIENTNAME"]) : "";            
                        Patient.Location_Name = DBNull.Value != dr["Location_Name"] ? Convert.ToString(dr["Location_Name"]) : "";
                        Patient.PriorityType = DBNull.Value != dr["PriorityType"] ? Convert.ToString(dr["PriorityType"]) : "";
                        Patient.STATUS = DBNull.Value != dr["STATUS"] ? Convert.ToString(dr["STATUS"]) : "";

                        res.Add(Patient);
                    }
                }
            }

            return res;
        }


        public List<Res_Kranium_feedback> Get_Kranium_feedback()
        {
            List<Res_Kranium_feedback> res = new List<Res_Kranium_feedback>();

            DataSet ds = dataLayer.Get_Kranium_feedback();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Res_Kranium_feedback Patient = new Res_Kranium_feedback();

                    
                        Patient.id = DBNull.Value != dr["id"] ? Convert.ToInt32(dr["id"]) : 0;
                        Patient.name = DBNull.Value != dr["name"] ? Convert.ToString(dr["name"]) : "";
                        Patient.kranium_accessibility = DBNull.Value != dr["kranium_accessibility"] ? Convert.ToString(dr["kranium_accessibility"]) : "";
                        Patient.prescription = DBNull.Value != dr["prescription"] ? Convert.ToString(dr["prescription"]) : "";
                        Patient.op_summary = DBNull.Value != dr["op_summary"] ? Convert.ToString(dr["op_summary"]) : "";
                        Patient.discharge_summary = DBNull.Value != dr["discharge_summary"] ? Convert.ToString(dr["discharge_summary"]) : "";
                        Patient.investigation = DBNull.Value != dr["investigation"] ? Convert.ToString(dr["investigation"]) : "";
                        Patient.growth_chart = DBNull.Value != dr["growth_chart"] ? Convert.ToString(dr["growth_chart"]) : "";
                        Patient.immunization_chart = DBNull.Value != dr["immunization_chart"] ? Convert.ToString(dr["immunization_chart"]) : "";
                        Patient.app_speed = DBNull.Value != dr["app_speed"] ? Convert.ToString(dr["app_speed"]) : "";
                        Patient.good_about_kranium = DBNull.Value != dr["good_about_kranium"] ? Convert.ToString(dr["good_about_kranium"]) : "";
                        Patient.improvement_required = DBNull.Value != dr["improvement_required"] ? Convert.ToString(dr["improvement_required"]) : "";
                        Patient.remarks = DBNull.Value != dr["remarks"] ? Convert.ToString(dr["remarks"]) : ""; 
                        Patient.submission_date = DBNull.Value != dr["submission_date"] ? Convert.ToString(dr["submission_date"]) : "";
                      
                       
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<Res_BedStatus> Get_BedStatusViewDetails()
        {
            List<Res_BedStatus> res = new List<Res_BedStatus>();

            DataSet ds = dataLayer.Get_BedStatusViewDetails();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Res_BedStatus Patient = new Res_BedStatus();

                        Patient.PATIENTID = DBNull.Value != dr["PATIENTID"] ? Convert.ToString(dr["PATIENTID"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PATIENTNAME = DBNull.Value != dr["PATIENT NAME"] ? Convert.ToString(dr["PATIENT NAME"]) : "";
                        Patient.AGE = DBNull.Value != dr["AGE"] ? Convert.ToString(dr["AGE"]) : "";
                        Patient.GENDER = DBNull.Value != dr["GENDER"] ? Convert.ToString(dr["GENDER"]) : "";
                        Patient.ADMISSIONDATETIME = DBNull.Value != dr["ADMISSION DATE TIME"] ? Convert.ToString(dr["ADMISSION DATE TIME"]) : "";
                        Patient.BedNo = DBNull.Value != dr["BedNo"] ? Convert.ToString(dr["BedNo"]) : "";
                        Patient.NATIONALITY = DBNull.Value != dr["NATIONALITY"] ? Convert.ToString(dr["NATIONALITY"]) : "";
                        Patient.PATIENTSTATUS = DBNull.Value != dr["PATIENT STATUS"] ? Convert.ToString(dr["PATIENT STATUS"]) : "";                      
                        Patient.WARD = DBNull.Value != dr["WARD"] ? Convert.ToString(dr["WARD"]) : "";
                        Patient.BEDSTATUS = DBNull.Value != dr["BED STATUS"] ? Convert.ToString(dr["BED STATUS"]) : "";
                        Patient.BED = DBNull.Value != dr["BED"] ? Convert.ToString(dr["BED"]) : "";
                        Patient.BEDTYPE = DBNull.Value != dr["BED TYPE"] ? Convert.ToString(dr["BED TYPE"]) : "";
                        Patient.DOCTORNAME = DBNull.Value != dr["DOCTOR NAME"] ? Convert.ToString(dr["DOCTOR NAME"]) : "";
                        Patient.Speciality = DBNull.Value != dr["Speciality"] ? Convert.ToString(dr["Speciality"]) : "";
                        Patient.VIPRemarks = DBNull.Value != dr["VIPRemarks"] ? Convert.ToString(dr["VIPRemarks"]) : "";
                        Patient.PatType = DBNull.Value != dr["PatType"] ? Convert.ToString(dr["PatType"]) : "";
                        
                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<Res_docwiseapplist> Get_Doctorwiseappointmentlist(string FromDate, string ToDate)
        {
            List<Res_docwiseapplist> resp = new List<Res_docwiseapplist>();

            DataSet ds = dataLayer.Get_Doctorwiseappointmentlist( FromDate, ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Res_docwiseapplist res = new Res_docwiseapplist();

                        res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                        res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                        res.Type = DBNull.Value != dr["PatientType"] ? Convert.ToString(dr["PatientType"]) : "";
                        res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                        res.AppointmentDate = DBNull.Value != dr["AppointmentDate"] ? Convert.ToString(dr["AppointmentDate"]) : "";
                        res.AppointmentTime = DBNull.Value != dr["AppointmentTime"] ? Convert.ToString(dr["AppointmentTime"]) : "";
                        res.AppointmentStatus = DBNull.Value != dr["AppointmentStatus"] ? Convert.ToString(dr["AppointmentStatus"]) : "";
                        res.Eligibility = DBNull.Value != dr["Eligibility"] ? Convert.ToString(dr["Eligibility"]) : "";
                        res.ReasonForVisit = DBNull.Value != dr["ReasonForVisit"] ? Convert.ToString(dr["ReasonForVisit"]) : "";
                        res.Country = DBNull.Value != dr["Country"] ? Convert.ToString(dr["Country"]) : "";                   
                        res.AppointmentType = DBNull.Value != dr["AppointmentType"] ? Convert.ToString(dr["AppointmentType"]) : "";

                        resp.Add(res);
                    }
                }
            }

            return resp;
        }



        public List<cls_OTScheduleing> Get_OT_Scheduleing()
        {
            List<cls_OTScheduleing> dropdown_DTOs = new List<cls_OTScheduleing>();
            try
            {
                DataSet ds = dataLayer.Get_OT_Scheduleing();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_OTScheduleing res = new cls_OTScheduleing();

                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            res.TheaterName = DBNull.Value != dr["TheaterName"] ? Convert.ToString(dr["TheaterName"]) : "";
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.StartDate = DBNull.Value != dr["StartDate"] ? Convert.ToString(dr["StartDate"]) : "";
                            res.Time = DBNull.Value != dr["Time"] ? Convert.ToString(dr["Time"]) : "";
                            res.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                            res.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";

                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


        public List<cls_Radiologypatientsearch> Get_Radiologypatientsearch()
        {
            List<cls_Radiologypatientsearch> dropdown_DTOs = new List<cls_Radiologypatientsearch>();
            try
            {
                DataSet ds = dataLayer.Get_Radiologypatientsearch();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_Radiologypatientsearch res = new cls_Radiologypatientsearch();

                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            res.Type = DBNull.Value != dr["Type"] ? Convert.ToString(dr["Type"]) : "";
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.Date = DBNull.Value != dr["Date"] ? Convert.ToString(dr["Date"]) : "";
                            res.Time = DBNull.Value != dr["Time"] ? Convert.ToString(dr["Time"]) : "";
                            res.Status = DBNull.Value != dr["Status"] ? Convert.ToString(dr["Status"]) : "";
                            res.Eligibility = DBNull.Value != dr["Eligibility"] ? Convert.ToString(dr["Eligibility"]) : "";
                            res.ReasonForVisit = DBNull.Value != dr["Reason For Visit"] ? Convert.ToString(dr["Reason For Visit"]) : "";
                            res.Country = DBNull.Value != dr["Country"] ? Convert.ToString(dr["Country"]) : "";
                            res.RadOnline = DBNull.Value != dr["Rad_Online"] ? Convert.ToString(dr["Rad_Online"]) : "";
                            res.AppointmentType = DBNull.Value != dr["AppointmentType"] ? Convert.ToString(dr["AppointmentType"]) : "";


                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
        public List<cls_DischargeTrackingreport> Get_DischargeTrackingreport(string FromDate, string ToDate)
        {
            List<cls_DischargeTrackingreport> dropdown_DTOs = new List<cls_DischargeTrackingreport>();
            try
            {
                DataSet ds = dataLayer.Get_DischargeTrackingreport( FromDate, ToDate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_DischargeTrackingreport res = new cls_DischargeTrackingreport();


                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.PatientName = DBNull.Value != dr["Patient_Name"] ? Convert.ToString(dr["Patient_Name"]) : "";
                            res.DoctorName = DBNull.Value != dr["Doctor_Name"] ? Convert.ToString(dr["Doctor_Name"]) : "";
                            res.DoctorDepartment = DBNull.Value != dr["Doctor_Department"] ? Convert.ToString(dr["Doctor_Department"]) : "";
                            res.BedNo = DBNull.Value != dr["Bed_No"] ? Convert.ToString(dr["Bed_No"]) : "";
                            res.AdmittedWard = DBNull.Value != dr["Ward_Name"] ? Convert.ToString(dr["Ward_Name"]) : "";
                            res.PayerType = DBNull.Value != dr["Payer_Type"] ? Convert.ToString(dr["Payer_Type"]) : "";
                            res.DischargeType = DBNull.Value != dr["Discharge_Type"] ? Convert.ToString(dr["Discharge_Type"]) : "";
                            res.DischargeDate = DBNull.Value != dr["Discahrge_Date"] ? Convert.ToString(dr["Discahrge_Date"]) : "";
                            res.DischargeMonth = DBNull.Value != dr["Discahrge_Month"] ? Convert.ToString(dr["Discahrge_Month"]) : "";
                            res.PhysicalToHousekeeping = DBNull.Value != dr["Physcial_to_Housekeeping"] ? Convert.ToString(dr["Physcial_to_Housekeeping"]) : "";
                            res.AdmNo = DBNull.Value != dr["AdmNo."] ? Convert.ToString(dr["AdmNo."]) : "";
                            res.Payorname = DBNull.Value != dr["Payorname"] ? Convert.ToString(dr["Payorname"]) : "";
                            res.Physical_Discharge = DBNull.Value != dr["Physical_Discharge"] ? Convert.ToString(dr["Physical_Discharge"]) : "";
                       
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


        public List<cls_heartandlungs> Get_heartandlungs()
        {
            List<cls_heartandlungs> dropdown_DTOs = new List<cls_heartandlungs>();
            try
            {
                DataSet ds = dataLayer.Get_heartandlungs();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cls_heartandlungs res = new cls_heartandlungs();
                           
                            res.CampCodeID = dr["CampCodeID"] != DBNull.Value ? Convert.ToString(dr["CampCodeID"]) : "";
                            res.CampCode = dr["CampCode"] != DBNull.Value ? Convert.ToString(dr["CampCode"]) : "";
                        //    res.CampName = dr["CampName"] != DBNull.Value ? Convert.ToString(dr["CampName"]) : "";
                            res.Salutation = dr["Salutation"] != DBNull.Value ? Convert.ToString(dr["Salutation"]) : "";
                            res.Name = dr["Name"] != DBNull.Value ? Convert.ToString(dr["Name"]) : "";
                            res.MobileNo = dr["MobileNo"] != DBNull.Value ? Convert.ToString(dr["MobileNo"]) : "";
                         //   res.DOB = dr["DOB"] != DBNull.Value ? Convert.ToDateTime(dr["DOB"]).ToString("dd-MM-yyyy") : "";             
                            res.Age = dr["Age"] != DBNull.Value ? Convert.ToString(dr["Age"]) : "";
                            res.Gender = dr["Gender"] != DBNull.Value ? Convert.ToString(dr["Gender"]) : "";
                         //   res.MaritalStatus = dr["MaritalStatus"] != DBNull.Value ? Convert.ToString(dr["MaritalStatus"]) : "";
                            res.Address = dr["Address"] != DBNull.Value ? Convert.ToString(dr["Address"]) : "";
                            res.Pincode = dr["Pincode"] != DBNull.Value ? Convert.ToString(dr["Pincode"]) : "";
                         //   res.State = dr["State"] != DBNull.Value ? Convert.ToString(dr["State"]) : "";
                          //  res.City = dr["City"] != DBNull.Value ? Convert.ToString(dr["City"]) : "";
                           // res.Country = dr["Country"] != DBNull.Value ? Convert.ToString(dr["Country"]) : "";

                          
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


        public res_heartandlungs Save_heartandlungs(req_heartandlungs request)
        {
            res_heartandlungs result = new res_heartandlungs();
            DataSet ds = dataLayer.Save_heartandlungs(request);

            if (ds != null)
            {
        
                result.CampCodeID = DBNull.Value != ds.Tables[0].Rows[0]["CampCodeID"] ? Convert.ToInt32(ds.Tables[0].Rows[0]["CampCodeID"]) : 0;
                result.MsgDesc = DBNull.Value != ds.Tables[0].Rows[0]["MsgDesc"] ? Convert.ToString(ds.Tables[0].Rows[0]["MsgDesc"]) : "";

            }

            return result;
        }


        public List<Res_ListOfAdmission> Get_ListOfAdmission(string FromDate, string ToDate)
        {
            List<Res_ListOfAdmission> res = new List<Res_ListOfAdmission>();

            DataSet ds = dataLayer.Get_ListOfAdmission(FromDate, ToDate);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Res_ListOfAdmission Patient = new Res_ListOfAdmission();

                        Patient.AdmissionDate = DBNull.Value != dr["Admission Date"] ? Convert.ToString(dr["Admission Date"]) : "";
                        Patient.AdmissionTime = DBNull.Value != dr["Admission Time"] ? Convert.ToString(dr["Admission Time"]) : "";
                        Patient.AdmittedBed = DBNull.Value != dr["Admitted Bed"] ? Convert.ToString(dr["Admitted Bed"]) : "";
                        Patient.AdmittedWard = DBNull.Value != dr["Admitted Ward"] ? Convert.ToString(dr["Admitted Ward"]) : "";
                        Patient.BedNo = DBNull.Value != dr["Bed No"] ? Convert.ToString(dr["Bed No"]) : "";
                        Patient.WARD = DBNull.Value != dr["WARD"] ? Convert.ToString(dr["WARD"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        Patient.PatientName = DBNull.Value != dr["Patient Name"] ? Convert.ToString(dr["Patient Name"]) : "";
                        Patient.AdmittingConsultant = DBNull.Value != dr["Admitting Consultant"] ? Convert.ToString(dr["Admitting Consultant"]) : "";
                        Patient.AdmittingDepartment = DBNull.Value != dr["Admitting Department"] ? Convert.ToString(dr["Admitting Department"]) : "";
                        Patient.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                        Patient.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                        Patient.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";
                        Patient.VIP = DBNull.Value != dr["VIP"] ? Convert.ToString(dr["VIP"]) : "";
                        Patient.AdmissionCategory = DBNull.Value != dr["Admission Category"] ? Convert.ToString(dr["Admission Category"]) : "";
                        Patient.BILLABLEBEDCATEGORY = DBNull.Value != dr["BILLABLE BED CATEGORY"] ? Convert.ToString(dr["BILLABLE BED CATEGORY"]) : "";
                        Patient.VisitID = DBNull.Value != dr["VisitID"] ? Convert.ToString(dr["VisitID"]) : "";


                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<OPInvestigationResponse> Get_EMROPInvestigation_dtl(int uhid)
        {
            List<OPInvestigationResponse> res = new List<OPInvestigationResponse>();

            DataSet ds = dataLayer.Get_EMROPInvestigation_dtl(uhid);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        OPInvestigationResponse Patient = new OPInvestigationResponse();

                        Patient.SurrogateId = DBNull.Value != dr["SurrogateId"] ? Convert.ToInt32(dr["SurrogateId"]) : 0;
                        Patient.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                        Patient.UHID = DBNull.Value != dr["UHID"] ? Convert.ToInt64(dr["UHID"]) : 0  ;
                        Patient.RegID = DBNull.Value != dr["RegID"] ? Convert.ToInt32(dr["RegID"]) : 0;
                        Patient.DocotrName = DBNull.Value != dr["DocotrName"] ? Convert.ToString(dr["DocotrName"]) : "";
                        Patient.DocotrCode = DBNull.Value != dr["DocotrCode"] ? Convert.ToInt32(dr["DocotrCode"]) : 0;
                        Patient.OrderDateTM = DBNull.Value != dr["OrderDateTM"] ? Convert.ToString(dr["OrderDateTM"]) : "";
                       // Patient.HM_EMR_OrderDateTM_cd = DBNull.Value != dr["HM_EMR_OrderDateTM_cd"] ? Convert.ToDateTime(dr["HM_EMR_OrderDateTM_cd"]).ToString("dd/MMM/yyyy") : "";
                        Patient.OrderId = DBNull.Value != dr["OrderId"] ? Convert.ToInt32(dr["OrderId"]) : 0;
                        Patient.ItemID = DBNull.Value != dr["ItemID"] ? Convert.ToString(dr["ItemID"]) : "";
                        Patient.Investigations = DBNull.Value != dr["Investigations"] ? Convert.ToString(dr["Investigations"]) : "";
                        Patient.GroupName = DBNull.Value != dr["GroupName"] ? Convert.ToString(dr["GroupName"]) : "";
                        Patient.Amount = DBNull.Value != dr["Amount"] ? Convert.ToInt32(dr["Amount"]) : 0;
                        Patient.Action = DBNull.Value != dr["Action"] ? Convert.ToInt32(dr["Action"]) : 0;


                        res.Add(Patient);
                    }
                }
            }

            return res;
        }

        public List<clsGetDepositAllocation> GetDepositreports(string FromDate, string Todate, int Uhid)
        {
            List<clsGetDepositAllocation> table = new List<clsGetDepositAllocation>();
            try
            {
                DataSet ds = dataLayer.GetDepositreports(FromDate, Todate, Uhid);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsGetDepositAllocation res = new clsGetDepositAllocation();


                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DepositDate = DBNull.Value != dr["DepositDate"] ? Convert.ToString(dr["DepositDate"]) : "";
                            res.Depositno = DBNull.Value != dr["Depositno"] ? Convert.ToString(dr["Depositno"]) : "";
                            res.Amount = DBNull.Value != dr["Amount"] ? Convert.ToDecimal(dr["Amount"]) : 0;
                            res.DepositType = DBNull.Value != dr["DepositType"] ? Convert.ToString(dr["DepositType"]) : "";
                            res.UserId = DBNull.Value != dr["UserId"] ? Convert.ToString(dr["UserId"]) : "";
                            



                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }


        public List<clsPatientDtlsForDeposit> GetAppointmentPatientSearch(string FromDate, string ToDate)
        {
            List<clsPatientDtlsForDeposit> dropdown_DTOs = new List<clsPatientDtlsForDeposit>();
            try
            {
                DataSet ds = dataLayer.GetAppointmentPatientSearch(FromDate, ToDate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsPatientDtlsForDeposit res = new clsPatientDtlsForDeposit();
                          
                  
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.MobileNo = DBNull.Value != dr["MobileNo"] ? Convert.ToString(dr["MobileNo"]) : "";
                            res.PatientType = DBNull.Value != dr["PatientType"] ? Convert.ToString(dr["PatientType"]) : "";
                            res.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.AppointmentDate = DBNull.Value != dr["AppointmentDate"] ? Convert.ToString(dr["AppointmentDate"]) : "";
                            res.AppointmentTime = DBNull.Value != dr["AppointmentTime"] ? Convert.ToString(dr["AppointmentTime"]) : "";
                            res.AppointmentStatus = DBNull.Value != dr["AppointmentStatus"] ? Convert.ToString(dr["AppointmentStatus"]) : "";
                            res.Eligibility = DBNull.Value != dr["Eligibility"] ? Convert.ToString(dr["Eligibility"]) : "";
                            res.ReasonForVisit = DBNull.Value != dr["ReasonForVisit"] ? Convert.ToString(dr["ReasonForVisit"]) : "";
                            res.Country = DBNull.Value != dr["Country"] ? Convert.ToString(dr["Country"]) : "";
                            res.His_Online = DBNull.Value != dr["His_Online"] ? Convert.ToString(dr["His_Online"]) : "";
                            res.AppointmentType = DBNull.Value != dr["AppointmentType"] ? Convert.ToString(dr["AppointmentType"]) : "";
                            res.CheckInStatus = DBNull.Value != dr["CheckInStatus"] ? Convert.ToString(dr["CheckInStatus"]) : "";
                            res.CheckInTime = DBNull.Value != dr["CheckInTime"] ? Convert.ToString(dr["CheckInTime"]) : "";
                            res.CheckOutTime = DBNull.Value != dr["CheckOutTime"] ? Convert.ToString(dr["CheckOutTime"]) : "";
                            res.AppBookedUserId = DBNull.Value != dr["AppBookedUserId"] ? Convert.ToString(dr["AppBookedUserId"]) : "";
                            res.AppBookedDate = DBNull.Value != dr["AppBookedDate"] ? Convert.ToString(dr["AppBookedDate"]) : "";

                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }


   

        public List<resCreditNoteReport> GetCreditNoteReport(string FromDate, string ToDate)
        {
            List<resCreditNoteReport> table = new List<resCreditNoteReport>();
            try
            {
                DataSet ds = dataLayer.GetCreditNoteReport(FromDate, ToDate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resCreditNoteReport res = new resCreditNoteReport();                        

                            res.Date = DBNull.Value != dr["Date"] ? Convert.ToString(dr["Date"]) : "";
                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.CreditNoteNo = DBNull.Value != dr["CreditNoteNo"] ? Convert.ToString(dr["CreditNoteNo"]) : "";
                            res.InvoiceNo = DBNull.Value != dr["InvoiceNo"] ? Convert.ToString(dr["InvoiceNo"]) : "";
                            res.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.Amount = DBNull.Value != dr["Amount"] ? Convert.ToInt32(dr["Amount"]) : 0;
                            res.Remarks = DBNull.Value != dr["Remarks"] ? Convert.ToString(dr["Remarks"]) : "";

                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }

        public List<resCashCollectionreport> GetCashCollectionreport(string FromDate, string ToDate, int InstutionId)
        {
            List<resCashCollectionreport> table = new List<resCashCollectionreport>();
            try
            {
                DataSet ds = dataLayer.GetCashCollectionreport(FromDate, ToDate, InstutionId);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resCashCollectionreport res = new resCashCollectionreport();

                            res.UserName = DBNull.Value != dr["UserName"] ? Convert.ToString(dr["UserName"]) : "";
                            res.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                            res.CollectionType = DBNull.Value != dr["CollectionType"] ? Convert.ToString(dr["CollectionType"]) : "";
                            res.Cash = DBNull.Value != dr["Cash"] ? Convert.ToInt64(dr["Cash"]) : 0;
                            res.Card = DBNull.Value != dr["Card"] ? Convert.ToInt64(dr["Card"]) : 0;
                            res.Cheque = DBNull.Value != dr["Cheque"] ? Convert.ToInt32(dr["Cheque"]) : 0;
                            res.Contra = DBNull.Value != dr["Contra"] ? Convert.ToInt64(dr["Contra"]) : 0;
                            res.Faclidater = DBNull.Value != dr["Faclidater"] ? Convert.ToInt32(dr["Faclidater"]) : 0;
                            res.Total = DBNull.Value != dr["Total"] ? Convert.ToInt64(dr["Total"]) : 0;


                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }
   
        public List<resRegistrationReport> GetRegistrationReport(string FromDate, string ToDate, int PatientType, int NationalityId, int VisitType)
        {
            List<resRegistrationReport> table = new List<resRegistrationReport>();
            try
            {
                DataSet ds = dataLayer.GetRegistrationReport( FromDate,  ToDate,  PatientType,  NationalityId,  VisitType);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resRegistrationReport res = new resRegistrationReport();                 

                            res.Sno = DBNull.Value != dr["S.No"] ? Convert.ToString(dr["S.No"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.Visit_Date = DBNull.Value != dr["Visit_Date"] ? Convert.ToString(dr["Visit_Date"]) : "";
                            res.VisitId = DBNull.Value != dr["VisitId"] ? Convert.ToString(dr["VisitId"]) : "";
                            res.VisitType = DBNull.Value != dr["VisitType"] ? Convert.ToString(dr["VisitType"]) : "";                   
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                            res.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";
                            res.Nationality = DBNull.Value != dr["Nationality"] ? Convert.ToString(dr["Nationality"]) : "";
                            res.PayorType = DBNull.Value != dr["PayorType"] ? Convert.ToString(dr["PayorType"]) : "";                       
                            res.PayorName = DBNull.Value != dr["PayorName"] ? Convert.ToString(dr["PayorName"]) : "";
                            res.Doctorname = DBNull.Value != dr["Doctorname"] ? Convert.ToString(dr["Doctorname"]) : "";
                            res.Specialty = DBNull.Value != dr["Specialty"] ? Convert.ToString(dr["Specialty"]) : "";
                            res.ConsultType = DBNull.Value != dr["ConsultType"] ? Convert.ToString(dr["ConsultType"]) : "";
                            res.ReferalSourceName = DBNull.Value != dr["ReferalSourceName"] ? Convert.ToString(dr["ReferalSourceName"]) : "";
                            res.Revenue = DBNull.Value != dr["Revenue"] ? Convert.ToString(dr["Revenue"]) : "";
                            res.DrConsult = DBNull.Value != dr["DrConsult"] ? Convert.ToString(dr["DrConsult"]) : "";
                            res.OtherCharge = DBNull.Value != dr["OtherCharge"] ? Convert.ToString(dr["OtherCharge"]) : "";
                            res.VisitCreatedUser = DBNull.Value != dr["VisitCreatedUser"] ? Convert.ToString(dr["VisitCreatedUser"]) : "";
                            res.Mobile = DBNull.Value != dr["Mobile"] ? Convert.ToString(dr["Mobile"]) : "";
                            res.Email = DBNull.Value != dr["Email"] ? Convert.ToString(dr["Email"]) : "";
                            res.AgeNo = DBNull.Value != dr["AgeNo"] ? Convert.ToString(dr["AgeNo"]) : "";
                            res.ConsultationType = DBNull.Value != dr["ConsultationType"] ? Convert.ToString(dr["ConsultationType"]) : "";
                            res.VISAValidityDate = DBNull.Value != dr["VISAValidityDate"] ? Convert.ToString(dr["VISAValidityDate"]) : "";

                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }



        public List<resInvoice> GetInvoice(string FromDate, string ToDate)
        {
            List<resInvoice> table = new List<resInvoice>();
            try
            {
                DataSet ds = dataLayer.GetInvoice(FromDate, ToDate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resInvoice res = new resInvoice();


                            res.Sno = DBNull.Value != dr["Sno"] ? Convert.ToString(dr["Sno"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.DOB = DBNull.Value != dr["DOB"] ? Convert.ToString(dr["DOB"]) : "";
                            res.Age = DBNull.Value != dr["Age"] ? Convert.ToString(dr["Age"]) : "";
                            res.Gender = DBNull.Value != dr["Gender"] ? Convert.ToString(dr["Gender"]) : "";                          
                            res.RegId = DBNull.Value != dr["RegId"] ? Convert.ToString(dr["RegId"]) : "";
                            res.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                            res.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";
                            res.BillNum = DBNull.Value != dr["BillNum"] ? Convert.ToString(dr["BillNum"]) : "";
                            res.InternalNo = DBNull.Value != dr["InternalNo"] ? Convert.ToString(dr["InternalNo"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";                           
                            res.BillDate = DBNull.Value != dr["BillDate"] ? Convert.ToString(dr["BillDate"]) : "";
                            res.BillAmount = DBNull.Value != dr["BillAmount"] ? Convert.ToString(dr["BillAmount"]) : "";
                            res.SelfAmount = DBNull.Value != dr["SelfAmount"] ? Convert.ToString(dr["SelfAmount"]) : "";
                            res.PartyAmount = DBNull.Value != dr["PartyAmount"] ? Convert.ToString(dr["PartyAmount"]) : "";
                            res.DoctorId = DBNull.Value != dr["DoctorId"] ? Convert.ToString(dr["DoctorId"]) : "";
                            res.DoctorName = DBNull.Value != dr["Doctorname"] ? Convert.ToString(dr["Doctorname"]) : "";
                            res.UserId = DBNull.Value != dr["UserId"] ? Convert.ToString(dr["UserId"]) : "";
                            res.ISCancelled = DBNull.Value != dr["ISCancelled"] ? Convert.ToString(dr["ISCancelled"]) : "";
                            res.PartyCode = DBNull.Value != dr["PartyCode"] ? Convert.ToString(dr["PartyCode"]) : "";
                            res.BILLSTATUS = DBNull.Value != dr["BILLSTATUS"] ? Convert.ToString(dr["BILLSTATUS"]) : "";
                            res.ins = DBNull.Value != dr["ins"] ? Convert.ToString(dr["ins"]) : "";
                            res.PartyName = DBNull.Value != dr["PartyName"] ? Convert.ToString(dr["PartyName"]) : "";

                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }


        public List<resConcession_report> Get_Concession_report(string FromDate, string ToDate,int BillType)
        {
            List<resConcession_report> table = new List<resConcession_report>();
            try
            {
                DataSet ds = dataLayer.Get_Concession_report(FromDate, ToDate, BillType);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resConcession_report res = new resConcession_report();

                            res.SNo = DBNull.Value != dr["SNo"] ? Convert.ToString(dr["SNo"]) : "";
                            res.Bill_Date = DBNull.Value != dr["Bill_Date"] ? Convert.ToString(dr["Bill_Date"]) : "";
                            res.Bill_No = DBNull.Value != dr["Bill_No"] ? Convert.ToString(dr["Bill_No"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";                           
                            res.Bill_Amount = DBNull.Value != dr["Bill_Amount"] ? Convert.ToString(dr["Bill_Amount"]) : "";
                            res.Concession_Amount = DBNull.Value != dr["Concession_Amount"] ? Convert.ToString(dr["Concession_Amount"]) : "";
                            res.NetAmount = DBNull.Value != dr["NetAmount"] ? Convert.ToString(dr["NetAmount"]) : "";
                            res.Reason_for_Concession = DBNull.Value != dr["Reason_for_Concession"] ? Convert.ToString(dr["Reason_for_Concession"]) : "";
                            res.User_Name = DBNull.Value != dr["User_Name"] ? Convert.ToString(dr["User_Name"]) : "";
                            res.Approved_By = DBNull.Value != dr["Approved_By"] ? Convert.ToString(dr["Approved_By"]) : "";
                            res.Approval_Remarks = DBNull.Value != dr["Approval_Remarks"] ? Convert.ToString(dr["Approval_Remarks"]) : "";           

                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }

        public List<resBill_cancellation> Get_Bill_cancellation(string FromDate, string ToDate)
        {
            List<resBill_cancellation> table = new List<resBill_cancellation>();
            try
            {
                DataSet ds = dataLayer.Get_Bill_cancellation(FromDate, ToDate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            resBill_cancellation res = new resBill_cancellation();

                            res.BILLNUM = DBNull.Value != dr["BILLNUM"] ? Convert.ToString(dr["BILLNUM"]) : "";
                            res.VisitNo = DBNull.Value != dr["VisitNo"] ? Convert.ToString(dr["VisitNo"]) : "";
                            res.BILLDATE = DBNull.Value != dr["BILLDATE"] ? Convert.ToString(dr["BILLDATE"]) : "";
                            res.PATIENTNAME = DBNull.Value != dr["PATIENTNAME"] ? Convert.ToString(dr["PATIENTNAME"]) : "";
                            res.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                            res.CONCESSION = DBNull.Value != dr["CONCESSION"] ? Convert.ToString(dr["CONCESSION"]) : "";
                            res.SELFAMOUNT = DBNull.Value != dr["SELFAMOUNT"] ? Convert.ToString(dr["SELFAMOUNT"]) : "";
                            res.PARTYAMOUNT = DBNull.Value != dr["PARTYAMOUNT"] ? Convert.ToString(dr["PARTYAMOUNT"]) : "";
                            res.InternalBillNo = DBNull.Value != dr["InternalBillNo"] ? Convert.ToString(dr["InternalBillNo"]) : "";
                            res.BILLAMOUNT = DBNull.Value != dr["BILLAMOUNT"] ? Convert.ToString(dr["BILLAMOUNT"]) : "";
                            res.PatientStatus = DBNull.Value != dr["PatientStatus"] ? Convert.ToString(dr["PatientStatus"]) : "";
                            res.Amount = DBNull.Value != dr["Amount"] ? Convert.ToString(dr["Amount"]) : "";
                            res.ReceivedAmount = DBNull.Value != dr["ReceivedAmount"] ? Convert.ToString(dr["ReceivedAmount"]) : "";
                            res.PartyCode = DBNull.Value != dr["PartyCode"] ? Convert.ToString(dr["PartyCode"]) : "";
                            table.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }

        public List<clsOPConsultDrDetail> GetDrConsult(string FromDate, string ToDate, int Patientid)
        {
            List<clsOPConsultDrDetail> res = new List<clsOPConsultDrDetail>();

            DataSet ds = dataLayer.GetDrConsult(FromDate, ToDate, Patientid);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsOPConsultDrDetail result = new clsOPConsultDrDetail();

                        result.VisitId = DBNull.Value != dr["RegId"] ? Convert.ToInt32(dr["RegId"]) : 0;
                        result.DoctorId = DBNull.Value != dr["DocID"] ? Convert.ToInt32(dr["DocID"]) : 0;
                        result.DeptId = DBNull.Value != dr["DepID"] ? Convert.ToInt32(dr["DepID"]) : 0;
                        result.DoctorName = DBNull.Value != dr["DoctorName"] ? Convert.ToString(dr["DoctorName"]) : "";
                        result.DepartmentName = DBNull.Value != dr["DeptName"] ? Convert.ToString(dr["DeptName"]) : "";
                        result.VisitDate = DBNull.Value != dr["VisitDate"] ? Convert.ToString(dr["VisitDate"]) : "";

                        res.Add(result);
                    }
                }
            }

            return res;
        }


        public List<clsRefundReport_SP> GetRefundReport(string FromDate, string ToDate)
        {
            List<clsRefundReport_SP> dropdown_DTOs = new List<clsRefundReport_SP>();
            try
            {
                DataSet ds = dataLayer.GetRefundReport(FromDate, ToDate);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsRefundReport_SP res = new clsRefundReport_SP();

                            res.MRN = DBNull.Value != dr["MRN"] ? Convert.ToString(dr["MRN"]) : "";
                            res.PatientName = DBNull.Value != dr["PatientName"] ? Convert.ToString(dr["PatientName"]) : "";
                            res.RefundDate = DBNull.Value != dr["RefundDate"] ? Convert.ToString(dr["RefundDate"]) : "";
                            res.RefundNo = DBNull.Value != dr["RefundNo"] ? Convert.ToString(dr["RefundNo"]) : "";
                            res.DepositNo = DBNull.Value != dr["DepositNo"] ? Convert.ToString(dr["DepositNo"]) : "";
                            res.DepositAmt = DBNull.Value != dr["DepositAmt"] ? Convert.ToString(dr["DepositAmt"]) : "";
                            res.RefundAmt = DBNull.Value != dr["RefundAmt"] ? Convert.ToString(dr["RefundAmt"]) : "";
                            res.RefundReason = DBNull.Value != dr["RefundReason"] ? Convert.ToString(dr["RefundReason"]) : "";
                            res.BillNo = DBNull.Value != dr["BillNo"] ? Convert.ToString(dr["BillNo"]) : "";
                            res.UserId = DBNull.Value != dr["UserId"] ? Convert.ToString(dr["UserId"]) : "";
                           
                            dropdown_DTOs.Add(res);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dropdown_DTOs;
        }
      
        
        public LoginDTO CheckLogin(LoginDTO loginDTO)
        {
            LoginDTO login = new LoginDTO();

            Boolean str = dataLayer.CheckLogin(loginDTO);
            if (str == true)
            {
                loginDTO.Response = true;
            }
            else
            {
                loginDTO.Response = false;
            }

            return loginDTO;
        }


        public app_Response portal_invoice(AppointmentBooking appointmentBooking)
        {
            app_Response response = new app_Response();

            DataSet ds = dataLayer.Getportal_invoice(appointmentBooking);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.msgDescp = DBNull.Value != dr["msgDescp"] ? Convert.ToString(dr["msgDescp"]) : "";
                        response.appointmentID = DBNull.Value != dr["appointmentID"] ? Convert.ToString(dr["appointmentID"]) : "";
                        response.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        response.EpisodeNo = DBNull.Value != dr["EpisodeNo"] ? Convert.ToString(dr["EpisodeNo"]) : "";
                        response.InternalNo = DBNull.Value != dr["InternalNo"] ? Convert.ToInt32(dr["InternalNo"]) : 0;
                        response.InvoiceNo = DBNull.Value != dr["InvoiceNo"] ? Convert.ToString(dr["InvoiceNo"]) : "";


                    }
                }
            }

            return response;
        }


        public app_Response postRegistrationInvoice(clsRegInvoice request)
        {
            app_Response response = new app_Response();

            DataSet ds = dataLayer.updateRegInvoice(request);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.Sno = DBNull.Value != dr["Sno"] ? Convert.ToInt32(dr["Sno"]) : 0;
                        response.msgDescp = DBNull.Value != dr["msgDescp"] ? Convert.ToString(dr["msgDescp"]) : "";
                        response.appointmentID = DBNull.Value != dr["appointmentID"] ? Convert.ToString(dr["appointmentID"]) : "";
                        response.UHID = DBNull.Value != dr["UHID"] ? Convert.ToString(dr["UHID"]) : "";
                        response.EpisodeNo = DBNull.Value != dr["EpisodeNo"] ? Convert.ToString(dr["EpisodeNo"]) : "";
                        response.InternalNo = DBNull.Value != dr["InternalNo"] ? Convert.ToInt32(dr["InternalNo"]) : 0;
                        response.InvoiceNo = DBNull.Value != dr["InvoiceNo"] ? Convert.ToString(dr["InvoiceNo"]) : "";
                    }
                }
            }

            return response;
        }
        public Res_Insurance Save_Insurance_Pre_Auth(Req_Insurance obj)
        {
            Res_Insurance response = new Res_Insurance();

            DataSet ds = dataLayer.Save_Insurance_Pre_Auth(obj);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.AdmNo = DBNull.Value != dr["AdmNo"] ? Convert.ToString(dr["AdmNo"]) : "";
                        response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";
                  
                    }
                }
            }

            return response;
        }
        public Res_New_Hdr Slot_New_Hdr(Req_Slot_New_Hdr_SP obj)
        {
            Res_New_Hdr response = new Res_New_Hdr();

            DataSet ds = dataLayer.Slot_New_Hdr(obj);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.ReturnValue = DBNull.Value != dr["Return Value"] ? Convert.ToString(dr["Return Value"]) : "";
                      

                    }
                }
            }

            return response;
        }

        public Res_slotbooking Slot_New_Dtl(Req_Slot_New_Dtl_SP obj)
        {
            Res_slotbooking response = new Res_slotbooking();

            DataSet ds = dataLayer.Slot_New_Dtl(obj);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.Success = DBNull.Value != dr["Success"] ? Convert.ToBoolean(dr["Success"]) : false;
                        response.Message = DBNull.Value != dr["Message"] ? Convert.ToString(dr["Message"]) : "";


                    }
                }
            }

            return response;
        }

        public Res_sltdate SaveSLTDate(Req_sltdate obj)
        {
            Res_sltdate response = new Res_sltdate();

            DataSet ds = dataLayer.SaveSLTDate(obj);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        response.NewDate = DBNull.Value != dr["NewDate"] ? Convert.ToString(dr["NewDate"]) : "";
                        response.Msg = DBNull.Value != dr["Msg"] ? Convert.ToString(dr["Msg"]) : "";


                    }
                }
            }

            return response;
        }
        //public CommonResponse EMROPOrderInvestigation(InvestigationEMR order)
        //{
        //    CommonResponse resp = new CommonResponse();
        //    DataSet ds = dataLayer.EMROPOrderInvestigation(order);
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                resp.Success = DBNull.Value != dr["Success"] ? Convert.ToBoolean(dr["Success"]) : false;
        //                resp.Message = DBNull.Value != dr["Message"] ? Convert.ToString(dr["Message"]) : "";
        //            }

        //        }
        //    }

        //    return resp;
        //}


        //public PatientVenue_res Save_PatientVenue_temp(req_PatientVenue request)
        //{
        //    PatientVenue_res result = new PatientVenue_res();

        //    DataSet ds = dataLayer.Save_PatientVenue_temp(request);

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        DataRow row = ds.Tables[0].Rows[0];

        //        result.patientId = DBNull.Value != row["patientId"] ? Convert.ToString(row["patientId"]) : "";
        //        result.VisitNumber = DBNull.Value != row["VisitNumber"] ? Convert.ToString(row["VisitNumber"]) : "";
        //        result.BillNo = DBNull.Value != row["BillNo"] ? Convert.ToString(row["BillNo"]) : "";
        //        result.VisitDate = DBNull.Value != row["VisitDate"] ? Convert.ToString(row["VisitDate"]) : "";
        //        result.testcode = DBNull.Value != row["testcode"] ? Convert.ToString(row["testcode"]) : "";
        //        result.TestLocation = DBNull.Value != row["TestLocation"] ? Convert.ToString(row["TestLocation"]) : "";
        //        result.Statusflag = DBNull.Value != row["Statusflag"] ? Convert.ToInt32(row["Statusflag"]) : 0;
        //        result.Activeflag = DBNull.Value != row["Activeflag"] ? Convert.ToInt32(row["Activeflag"]) : 0;
        //    }

        //    return result;
        //}



        //public clsdelPat DeleteFilefromDisk(int UHID, string DocumentPath)
        //{
        //    clsdelPat response = new clsdelPat();

        //    DataSet ds = dataLayer.DeleteFilefromDisk(UHID,DocumentPath);

        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                response.sno = DBNull.Value != dr["sno"] ? Convert.ToInt32(dr["sno"]) : 0;
        //                response.MsgDesc = DBNull.Value != dr["MsgDesc"] ? Convert.ToString(dr["MsgDesc"]) : "";

        //            }
        //        }
        //    }

        //    return response;
        //}

    }

}
