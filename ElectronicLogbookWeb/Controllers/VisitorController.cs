using AccountsWebAuthentication.Helper;
using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using System.Data.Entity;
using Rotativa;

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
        //[CustomAuthorize(AllowedRoles = new string[] { "Receptionist" })]
        public ActionResult Edit(int id)
        {
            var visitor = _iFVisitor.Read(id);
            visitor.TimeOut = DateTime.Now.ToShortTimeString();
            return View(visitor);
        }

        [HttpGet]
        //[CustomAuthorize(AllowedRoles = new string[] { "Receptionist" })]
        public ActionResult Add()
        {
            Visitor visitor = new Visitor();
            visitor.Date = DateTime.Now.ToString("MMMM dd, yyyy");
            visitor.TimeIn = DateTime.Now.ToShortTimeString();
            return View(visitor);
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

        [HttpGet]
        public ActionResult PrintVisitor(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return View(visitor);
        }

        public ActionResult Print(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return new ActionAsPdf("PrintVisitor", new { id = id })
            {
                FileName = visitor.Name + " | " + visitor.Date + ".pdf"
            };
        }

        //[HttpGet]
        //public ActionResult PrintPdf(int id)
        //{
        //    var visitor = _iFVisitor.Read(id);
        //    return new ActionAsPdf("Details", new { id = id });
        //}

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