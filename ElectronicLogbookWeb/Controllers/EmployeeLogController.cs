using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicLogbookWeb.Controllers
{
    public class EmployeeLogController : Controller
    {
        // GET: EmployeeLog
        public ActionResult Index()
        {
            return View();
        }
    }
}