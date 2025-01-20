using BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repository
{
    public interface IMediBusiness
    {
        List<DepartmentDTO> GetDepartmentDetails(int recordCount);
    }
}
