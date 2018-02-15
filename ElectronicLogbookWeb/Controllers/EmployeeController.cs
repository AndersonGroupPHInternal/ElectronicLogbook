using AndersonCRMFunction;
using AndersonCRMModel;
using System;
using System.Web.Mvc;

namespace AndersonLogBookWeb.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        private IFEmployee _iFEmployee;

        public EmployeeController()
        {
            _iFEmployee = new FEmployee();
        }

        [Route("Read")]
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFEmployee.Read());
        }

    }
}