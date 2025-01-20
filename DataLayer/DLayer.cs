
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;


namespace DataLayer
{
    public class DLayer
    {
        protected SqlDatabase db;
        public DLayer()
        {
            string CON = ConfigurationManager.AppSettings["ConnectionString"];
            db = new SqlDatabase(CON);
            //DAdb = new SqlDatabase("Server=MCPL\\SQLSERVER2017;Database=RIMC;User Id=sa;Password=welcome123;");
        }

        public DataSet GetDepartmentDetails(int recordCount)
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db.GetStoredProcCommand(MediDBConstants.GetDepartmentMasterData))
                {
                    db.AddInParameter(Cmd, "recordCount", DbType.Int32, recordCount);
                    Cmd.CommandTimeout = 30;
                    ds = db.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
