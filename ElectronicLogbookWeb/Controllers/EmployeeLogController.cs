using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System.Web.Mvc;

namespace ElectronicLogbookWeb.Controllers
{
    public class EmployeeLogController : BaseController
    {
        private IFEmployeeLog _iFEmployeeLog;

        public EmployeeLogController()
        {
            _iFEmployeeLog = new FEmployeeLog();
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
            _iFEmployeeLog.Create(UserId, employeeLog);
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
        public JsonResult Delete(int employeeLogId)
        {
            _iFEmployeeLog.Delete(employeeLogId);
            return Json(string.Empty);
        }
        #endregion
    }
}
