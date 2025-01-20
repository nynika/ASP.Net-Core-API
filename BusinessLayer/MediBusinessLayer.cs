using BusinessLayer.BusinessModels;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DALayer;

namespace BusinessLayer
{
    public class MediBusinessLayer : IMediBusiness
    {
        private DataLayer dataLayer;
        public MediBusinessLayer()
        {
            
            
            dataLayer = new DataLayer();
        }
        
        public List<DepartmentDTO> GetDepartmentDetails(int recordCount)
        {
            List<DepartmentDTO> Department = new List<DepartmentDTO>();

            //DataSet ds = dataLayer.GetPatientDetails(recordCount);
            DataSet ds = dataLayer.GetDepartmentDetails(recordCount);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DepartmentDTO po = new DepartmentDTO();

                        po.DepartmentID = DBNull.Value != dr["DepartmentID"] ? Convert.ToInt32(dr["DepartmentID"]) : 0;
                        po.DepartmentName = DBNull.Value != dr["DepartmentName"] ? Convert.ToString(dr["DepartmentName"]) : "";
                        po.DepartmentRemarks = DBNull.Value != dr["DepartmentRemarks"] ? Convert.ToString(dr["DepartmentName"]) : "";
                        //po.Gender = DBNull.Value != dr["Pgender"] ? Convert.ToString(dr["Pgender"]) : "";

                        Department.Add(po);
                    }
                }
            }

            return Department;
        }
    }
}
