using AndersonCRMFunction;
using AndersonCRMModel;
using System;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        private IFEmployee _iFEmployee;

        public EmployeeController()
        {
            _iFEmployee = new FEmployee();
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var employee = _iFEmployee.Read(id);
            return View(employee);
        }


        [HttpPost]
        public ActionResult Details(Employee employee)
        {
            try
            {
                _iFEmployee.Update(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var employee = _iFEmployee.Read(id);
            return View(employee);
        }


        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                _iFEmployee.Update(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        public JsonResult Create(Employee employee)
        {
            //employee = _iFEmployee.Create(employee);
            //return View(employee);
            try
            {
                employee = _iFEmployee.Create(employee);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
       

        [Route("List")]
        [HttpPost]
        public ActionResult List()
        {
            try
            {
                Employee employee = new Employee();
                return Json(_iFEmployee.List());
            }
            catch (Exception exception)
            {
                return Json(exception);
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                Employee employee = _iFEmployee.Read(id);
                return View(employee);
            }
            catch (Exception ex)
            {
                return View(new Employee());
            }
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            try
            {
                employee = _iFEmployee.Update(employee);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                _iFEmployee.Delete(employee);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

    }
}