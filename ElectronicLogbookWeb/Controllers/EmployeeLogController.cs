using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Routing;
using System;

namespace ElectronicLogbookWeb.Controllers
{
    public class EmployeeLogController : BaseController
    {
        private IFEmployeeLog _iFEmployeeLog;
        private AndersonCRMFunction.IFEmployee _iFEmployee;
        public EmployeeLogController()
        {
            _iFEmployeeLog = new FEmployeeLog();
            _iFEmployee = new AndersonCRMFunction.FEmployee();
            
        }
        #region Create
        [HttpGet]
        public ActionResult CreateLog(int? id)
        {
            if (id == null)
                return View(new EmployeeLog());
            var employeeLog = _iFEmployeeLog.Read(id.Value);
            if (employeeLog.SuccesLogin)
            {
                var employee = _iFEmployee.Read(employeeLog.EmployeeId);
                employeeLog.EmployeeImageBase64 = employee.EmployeeImageBase64;
                employeeLog.FirstName = employee.FirstName;
                employeeLog.MiddleName = employee.MiddleName;
                employeeLog.LastName = employee.LastName;
            }

            return View(employeeLog);
        }
        [HttpPost]
        public ActionResult CreateLog(EmployeeLog employeeLog)
        {
            var employee = _iFEmployee.Read(employeeLog.EmployeeNumber, employeeLog.Pin);
            var logname = _iFEmployeeLog.Readlogtype(employeeLog.LogTypeId);
            bool IsSuccess = employee.EmployeeId != 0 && employee.Pin == employeeLog.Pin;
            employeeLog.LogDate = DateTime.Now;
            employeeLog.LogName = logname.Name;
            employeeLog.EmployeeId = employee.EmployeeId;
            employeeLog.SuccesLogin = IsSuccess;
            employeeLog = _iFEmployeeLog.Create(UserId, employeeLog);
            employeeLog.EmployeeImageBase64 = employee.EmployeeImageBase64;
           return RedirectToAction("CreateLog", new { id = employeeLog.EmployeeLogId });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeLog());
        }
        [HttpPost]
        public ActionResult Create(EmployeeLog employeeLog)
        {

            var logname = _iFEmployeeLog.Readlogtype(employeeLog.LogTypeId);
            employeeLog.SuccesLogin = true;
            employeeLog.LogName = logname.Name;
            employeeLog = _iFEmployeeLog.Create(UserId, employeeLog);
            return RedirectToAction("Index");
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
        public ActionResult Update(int id)
        {
            return View(_iFEmployeeLog.Read(id));

        }
        [HttpPost]
        public ActionResult Update(EmployeeLog employeeLog)
        {
           employeeLog = _iFEmployeeLog.Update(UserId, employeeLog);
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
