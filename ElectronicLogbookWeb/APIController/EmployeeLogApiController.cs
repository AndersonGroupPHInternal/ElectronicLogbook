using AndersonCRMFunction;
using ElectronicLogbookFunction;
using ElectronicLogbookModel.Filter;
using System.Linq;
using System.Web.Http;

namespace ElectronicLogbookWeb.APIController
{
    public class EmployeeLogApiController : BaseApiController
    {
        private IFEmployee _iFEmployee;
        private IFEmployeeLog _iFEmployeeLog;
        private IFLogType _iFLogType;

        public EmployeeLogApiController()
        {
            _iFEmployee = new FEmployee();
            _iFEmployeeLog = new FEmployeeLog();
            _iFLogType = new FLogType();

        }

        [HttpPost]
        public IHttpActionResult Read(EmployeeLogFilter employeeLogFilter)
        {
            var employees = _iFEmployee.Read();
            var employeeLogs = _iFEmployeeLog.Read(employeeLogFilter);
            var logTypes = _iFLogType.Read();

            foreach (var employeeLog in employeeLogs)
            {
                var employee = employees.FirstOrDefault(a => a.EmployeeId == employeeLog.EmployeeId);
                if (employee != null)
                {
                    employeeLog.FirstName = employee.FirstName;
                    employeeLog.LastName = employee.LastName;
                    employeeLog.MiddleName = employee.MiddleName;
                }

                var logType = logTypes.FirstOrDefault(a => a.LogTypeId == employeeLog.LogTypeId);
                if (logType != null)
                {
                    employeeLog.LogType = logType.Name;
                }
            }
            return Ok(employeeLogs);
        }
    }
}
