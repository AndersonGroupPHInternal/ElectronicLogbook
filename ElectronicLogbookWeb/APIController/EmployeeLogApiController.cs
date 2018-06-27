using AndersonCRMFunction;
using ElectronicLogbookFunction;
using ElectronicLogbookModel.Filter;
using System.Web.Http;

namespace ElectronicLogbookWeb.APIController
{
    public class EmployeeLogApiController : BaseApiController
    {
        private IFEmployeeLog _iFEmployeeLog;
        private IFEmployee _iFEmployee;

        public EmployeeLogApiController()
        {
            _iFEmployeeLog = new FEmployeeLog();
            _iFEmployee = new FEmployee();

        }

        [HttpPost]
        public IHttpActionResult Read(EmployeeLogFilter employeeLogFilter)
        {
            var employeeLogs = _iFEmployeeLog.Read(employeeLogFilter);
            return Ok(employeeLogs);
        }
    }
}
