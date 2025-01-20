using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public static class MediDBConstants
    {
        public const string GetPatientData = "SP_GetPatintData";

        #region "Master"
        public const string GetDepartmentMasterData = "SP_GetDepartmentMasterData";
        public const string GetServiceMasterData = "SP_GetServiceMasterData";
        #endregion

        #region "WhiteSheet"

        public const string GetPatientWhiteSheetData = "SP_GetWhiteSheetPatientData";
        public const string InsertPatientWhiteSheetData = "SP_IUDWhiteSheetPatientData";
        public const string InsertPatientWhiteSheetData_JSON = "SP_JSON_INSERT_WHITESHEET_DTL";

        #endregion

        #region "Doctor"

        //Doctor 
        public const string GetDoctorData = "SP_GetDoctorData";


        #endregion
    }
}
