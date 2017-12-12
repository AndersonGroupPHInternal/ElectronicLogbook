using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFEmployeeLog
    {
        #region CREATE
        EmployeeLog Create(EmployeeLog employeelog);
        #endregion

        #region RETRIEVE
        EmployeeLog Read(int EmployeeLogId);
        List<EmployeeLog> List();
        #endregion

        #region UPDATE
        EmployeeLog Update(EmployeeLog employeelog);
        #endregion

        #region DELETE
        void Delete(EmployeeLog employeelog);
        #endregion

        #region CREATEFOLDER
        void CreateFolder();
        #endregion
    }
}
