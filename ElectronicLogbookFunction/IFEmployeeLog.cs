using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFEmployeeLog
    {
        #region CREATE
        EmployeeLog Create(int userId, EmployeeLog employeelog);
        EmployeeLog Insert(int userId, EmployeeLog employeelog);
        #endregion
        #region RETRIEVE
        EmployeeLog Read(int EmployeeLogId);
        List<EmployeeLog> Read();
        //List<EmployeeLog> Read(int employeeLogId, string sortBy);
        List<EmployeeLog> Read(int employeeid, string sortBy);
        LogType Readlogtype(int logtypeid);
        #endregion
        #region UPDATE
        EmployeeLog Update(int userId, EmployeeLog employeelog);
        #endregion
        #region DELETE
        void Delete(int EmployeeLogId);
        #endregion
    }
}
