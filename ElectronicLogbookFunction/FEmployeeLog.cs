using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

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
        public EmployeeLog Create(EmployeeLog employeelog)
        {
            EEmployeeLog eEmployeeLog = EEmployeeLog(employeelog);
            eEmployeeLog = _iDEmployeeLog.Create(eEmployeeLog);

            //EApplicantHistory eApplicantHistory = new EApplicantHistory
            //{
            //    ApplicantID = eApplicant.ApplicantID,
            //    Date = eApplicant.Date,
            //    Name = eApplicant.Name,
            //    Purpose = eApplicant.Purpose,
            //    TimeIn = eApplicant.TimeIn,
            //    TimeOut = eApplicant.TimeOut
            //};
            //_iDApplicant.Create(eApplicantHistory);
            return (EmployeeLog(eEmployeeLog));
        }
        #endregion

        #region READ
        public EmployeeLog Read(int employeeLogId)
        {
            EEmployeeLog eEmployeeLog = _iDEmployeeLog.Read<EEmployeeLog>(a => a.EmployeeLogId == employeeLogId);
            return EmployeeLog(eEmployeeLog);
        }

        public List<EmployeeLog> List()
        {
            List<EEmployeeLog> eEmployeeLogs = _iDEmployeeLog.List<EEmployeeLog>(a => true);
            return EmployeeLogs(eEmployeeLogs);
        }
        #endregion

        #region UPDATE
        public EmployeeLog Update(EmployeeLog employeeLog)
        {
            EEmployeeLog currentEmployeeLog = _iDEmployeeLog.Read<EEmployeeLog>(a => a.EmployeeLogId == employeeLog.EmployeeLogId);
            var eEmployee = _iDEmployeeLog.Update(EEmployeeLog(employeeLog));
            //if (applicant.ApplicantID == currentApplicant.ApplicantID)
            //{
            //    EApplicantHistory eApplicantHistory = new EApplicantHistory
            //    {
            //        ApplicantID = eApplicant.ApplicantID,
            //        Date = eApplicant.Date,
            //        Name = eApplicant.Name,
            //        ApplyingFor = eApplicant.ApplyingFor,
            //        Designation = eApplicant.Designation,
            //        TypeOfId = eApplicant.TypeOfId,
            //        IdNumber = eApplicant.IdNumber,
            //        TimeIn = eApplicant.TimeIn,
            //        TimeOut = eApplicant.TimeOut,
            //        Comment = eApplicant.Comment
            //    };
            //    _iDApplicant.Create(eApplicantHistory);
            //}
            return (EmployeeLog(eEmployee));
        }
        #endregion

        #region DELETE
        public void Delete(EmployeeLog employeeLog)
        {
            _iDEmployeeLog.Delete(EEmployeeLog(employeeLog));
        }
        #endregion

        #region OTHER FUNCTION
        private List<EmployeeLog> EmployeeLogs(List<EEmployeeLog> eEmployeeLogs)
        {
            var returnEmployeeLog = eEmployeeLogs.Select(a => new EmployeeLog
            {
                EmployeeLogId = a.EmployeeLogId,
                EmployeeId = a.EmployeeId,
                EmployeeNumber = a.EmployeeNumber,
                LogTypeId = a.LogTypeId,
                LogDate = a.LogDate,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnEmployeeLog.ToList();
        }

        private EEmployeeLog EEmployeeLog(EmployeeLog employeelog)
        {
            EEmployeeLog returnEEmployeeLog = new EEmployeeLog
            {
                EmployeeLogId = employeelog.EmployeeLogId,
                EmployeeId = employeelog.EmployeeId,
                EmployeeNumber = employeelog.EmployeeNumber,
                LogTypeId = employeelog.LogTypeId,
                LogDate = employeelog.LogDate,
                CreatedBy = employeelog.CreatedBy,
                UpdatedBy = employeelog.UpdatedBy
            };
            return returnEEmployeeLog;
        }

        private EmployeeLog EmployeeLog(EEmployeeLog eEmployeeLog)
        {
            EmployeeLog returnEmployeeLog = new EmployeeLog
            {
                EmployeeLogId = eEmployeeLog.EmployeeLogId,
                EmployeeId = eEmployeeLog.EmployeeId,
                EmployeeNumber = eEmployeeLog.EmployeeNumber,
                LogTypeId = eEmployeeLog.LogTypeId,
                LogDate = eEmployeeLog.LogDate,
                CreatedBy = eEmployeeLog.CreatedBy,
                UpdatedBy = eEmployeeLog.UpdatedBy
            };
            return returnEmployeeLog;
        }

        public void CreateFolder()
        {
            var date = DateTime.Now.ToString("MMMM dd, yyyy");
            if (!Directory.Exists(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy")))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantDetails");
            }
            else if (date != DateTime.Now.ToString("MMMM dd, yyyy"))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantDetails");
            }
            else
            {
            }
        }
        #endregion
    }
}
