using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System.Web.Mvc;

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
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeLog employeeLog)
        {
            var employee = _iFEmployee.Read(employeeLog.EmployeeNumber, employeeLog.Pin);
            if (employee.EmployeeId == 0)
            {
                //return View(employeeLog); //return error
                ModelState.AddModelError("EmployeeNumber", "Employee Number or Pin does not exist");
                return View(new EmployeeLog());
            }
            else
            {
                employeeLog.EmployeeId = employee.EmployeeId;
                _iFEmployeeLog.Create(UserId, employeeLog);
                return RedirectToAction("Index");
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
