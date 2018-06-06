using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System;
using ElectronicLogbookModel.Filter;

namespace ElectronicLogbookFunction
{
    public class FEmployeeLog : IFEmployeeLog
    {
        private IDEmployeeLog _iDEmployeeLog;

        public FEmployeeLog()
        {
            _iDEmployeeLog = new DEmployeeLog();
        }
        #region CREATE
        public EmployeeLog Create(int userId, EmployeeLog employeelog)
        {
            EEmployeeLog eEmployeeLog = EEmployeeLog(employeelog);
            eEmployeeLog.CreatedDate = DateTime.Now;
            eEmployeeLog.CreatedBy = userId;
            eEmployeeLog = _iDEmployeeLog.Create(eEmployeeLog);
            return (EmployeeLog(eEmployeeLog));
        }
        #endregion

        #region READ
        public EmployeeLog Read(int employeeLogId)
        {
            EEmployeeLog eEmployeeLog = _iDEmployeeLog.Read<EEmployeeLog>(a => a.EmployeeLogId == employeeLogId);
            return EmployeeLog(eEmployeeLog);
        }

        public List<EmployeeLog> Read()
        {
            List<EEmployeeLog> eEmployeeLogs = _iDEmployeeLog.List<EEmployeeLog>(a => true);
            return EmployeeLogs(eEmployeeLogs);
        }

        public List<EmployeeLog> Read(EmployeeLogFilter employeeLogFilter)
        {
            List<EEmployeeLog> eEmployeeLogs = _iDEmployeeLog.List<EEmployeeLog>(a => a.LogDate >= employeeLogFilter.LogDateFrom && a.LogDate <= employeeLogFilter.LogDateTo);
            return EmployeeLogs(eEmployeeLogs);
        }
        #endregion
        #region UPDATE
        public EmployeeLog Update(int userId, EmployeeLog employeeLog)
        {
            var eEmployeeLog = EEmployeeLog(employeeLog);
            eEmployeeLog.UpdatedDate = DateTime.Now;
            eEmployeeLog.UpdatedBy = userId;
            eEmployeeLog = _iDEmployeeLog.Update(EEmployeeLog(employeeLog));
            return (EmployeeLog(eEmployeeLog));
        }
        #endregion
        #region DELETE
        public void Delete(int employeeLogId)
        {
            _iDEmployeeLog.Delete<EEmployeeLog>(a => a.EmployeeLogId == employeeLogId);
        }
        #endregion
        #region OTHER FUNCTION
        private List<EmployeeLog> EmployeeLogs(List<EEmployeeLog> eEmployeeLogs)
        {
            var returnEmployeeLog = eEmployeeLogs.Select(a => new EmployeeLog
            {
                SuccesLogin = a.SuccesLogin,

                CreatedBy = a.CreatedBy,
                LogDate = a.LogDate,
                UpdatedDate = a.UpdatedDate,

                CreatedDate = a.CreatedDate,
                EmployeeLogId = a.EmployeeLogId,
                EmployeeId = a.EmployeeId,
                LogTypeId = a.LogTypeId,
                UpdatedBy = a.UpdatedBy,

                EmployeeNumber = a.EmployeeNumber
            });
            return returnEmployeeLog.ToList();
        }
        private EEmployeeLog EEmployeeLog(EmployeeLog employeeLog)
        {
            EEmployeeLog returnEEmployeeLog = new EEmployeeLog
            {
                SuccesLogin = employeeLog.SuccesLogin,

                CreatedBy = employeeLog.CreatedBy,
                LogDate = employeeLog.LogDate,
                UpdatedDate = employeeLog.UpdatedDate,

                CreatedDate = employeeLog.CreatedDate,
                EmployeeLogId = employeeLog.EmployeeLogId,
                EmployeeId = employeeLog.EmployeeId,
                LogTypeId = employeeLog.LogTypeId,
                UpdatedBy = employeeLog.UpdatedBy,

                EmployeeNumber = employeeLog.EmployeeNumber
            };
            return returnEEmployeeLog;
        }

        private EmployeeLog EmployeeLog(EEmployeeLog eEmployeeLog)
        {
            EmployeeLog returnEmployeeLog = new EmployeeLog
            {
                SuccesLogin = eEmployeeLog.SuccesLogin,

                CreatedBy = eEmployeeLog.CreatedBy,
                LogDate = eEmployeeLog.LogDate,
                UpdatedDate = eEmployeeLog.UpdatedDate,

                CreatedDate = eEmployeeLog.CreatedDate,
                EmployeeLogId = eEmployeeLog.EmployeeLogId,
                EmployeeId = eEmployeeLog.EmployeeId,
                LogTypeId = eEmployeeLog.LogTypeId,
                UpdatedBy = eEmployeeLog.UpdatedBy,

                EmployeeNumber = eEmployeeLog.EmployeeNumber,
            };
            return returnEmployeeLog;
        }
        #endregion
    }
}
