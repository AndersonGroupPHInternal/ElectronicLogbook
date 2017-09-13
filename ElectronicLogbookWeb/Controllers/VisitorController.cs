using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using System.Data.Entity;

namespace ElectronicLogbookWeb.Controllers
{
    [RoutePrefix("Visitor")]
    public class VisitorController : Controller
    {
        private IFVisitor _iFVisitor;

        public VisitorController()
        {
            _iFVisitor = new FVisitor();

        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return View(visitor);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(new Visitor());
        }

        [HttpPost]
        public JsonResult Create(Visitor visitor)
        {

            try
            {
                visitor = _iFVisitor.Create(visitor);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return View(visitor);
        }

        [HttpPost]
        public ActionResult Details(Visitor visitor)
        {
            try
            {
                _iFVisitor.Update(visitor);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Visitor",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        [HttpPost]
        public ActionResult Edit(Visitor visitor)
        {
            try
            {
                _iFVisitor.Update(visitor);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Route("List")]
        [HttpPost]
        public ActionResult List()
        {
            try
            {
                Visitor visitor = new Visitor();
                return Json(_iFVisitor.List());
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
                Visitor visitor = _iFVisitor.Read(id);
                return View(visitor);
            }
            catch (Exception ex)
            {
                return View(new Visitor());
            }
        }

        [HttpPost]
        public ActionResult Update(Visitor visitor)
        {
            try
            {
                visitor = _iFVisitor.Update(visitor);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(Visitor visitor)
        {
            try
            {
                _iFVisitor.Delete(visitor);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}