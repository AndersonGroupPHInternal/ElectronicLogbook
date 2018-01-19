using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System.Web.Mvc;
using System.Web.UI;

namespace ElectronicLogbookWeb.Controllers
{
    public class EmployeeLogController : BaseController
    {
        private IFEmployeeLog _iFEmployeeLog;
        private AndersonCRMFunction.IFEmployee _iFEmployee;
        //private AndersonCRMModel.Employee _employee;

        public EmployeeLogController()
        {
            _iFEmployeeLog = new FEmployeeLog();
            _iFEmployee = new AndersonCRMFunction.FEmployee();
            
        }
        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeLog());
        }

        [HttpPost]
        public ActionResult Create(EmployeeLog employeeLog)
        {
            var employee = _iFEmployee.Read(employeeLog.EmployeeNumber, employeeLog.Pin);
            var logname = _iFEmployeeLog.Readlogtype(employeeLog.LogTypeId);
            bool IsSuccess = employee.EmployeeId != 0 && employee.Pin == employeeLog.Pin;
            if (employeeLog.LogTypeId == 1 && IsSuccess == true)
            {
                ModelState.AddModelError("EmployeeNumber", "Successfully logged in at " + System.DateTime.Now.ToString("h:mm:ss tt"));
            }
            else if (employeeLog.LogTypeId == 2 && IsSuccess == true)
            {
                ModelState.AddModelError("EmployeeNumber", "Successfully logged out at " + System.DateTime.Now.ToString("h:mm:ss tt"));
            }

            employeeLog.LogName = logname.Name;
            employeeLog.EmployeeId = employee.EmployeeId;
            employeeLog.SuccesLogin = IsSuccess;

            _iFEmployeeLog.Create(UserId, employeeLog);

            employeeLog.EmployeeImage = employee.EmployeeImage;

            if (!IsSuccess)
            {
                ModelState.AddModelError("EmployeeNumber", "Employee Number or Pin does not exist");
                return View(new EmployeeLog());
            }
            else
            {
                return View(employeeLog);
                //return RedirectToAction("Index");
            }
        }
        #endregion
        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFEmployeeLog.Read());
        }
        #endregion
        #region Update
        [HttpGet]
        public ActionResult Update(int employeeLogId)
        {
            return View(_iFEmployeeLog.Read(employeeLogId));
        }

        [HttpPost]
        public ActionResult Update(EmployeeLog employeeLog)
        {
            _iFEmployeeLog.Update(UserId, employeeLog);
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFEmployeeLog.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}
