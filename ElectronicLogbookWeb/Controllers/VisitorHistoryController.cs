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
    [RoutePrefix("VisitorHistory")]
    public class VisitorHistoryController : Controller
    {
        private IFVisitorHistory _iFVisitorHistory;

        public VisitorHistoryController()
        {
            _iFVisitorHistory = new FVisitorHistory();

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
            var visitorHistory = _iFVisitorHistory.Read(id);
            visitorHistory.TimeOut = DateTime.Now.ToShortTimeString();
            return View(visitorHistory);
        }
        [HttpGet]
        public ActionResult Add()
        {
            VisitorHistory visitorHistory = new VisitorHistory();
            visitorHistory.Date = DateTime.Now.ToString("MMMM dd, yyyy");
            visitorHistory.TimeIn = DateTime.Now.ToShortTimeString();
            return View(visitorHistory);
        }
        [HttpPost]
        public JsonResult Create(VisitorHistory visitorHistory)
        {
            try
            {
                visitorHistory = _iFVisitorHistory.Create(visitorHistory);
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
            var visitorHistory = _iFVisitorHistory.Read(id);
            return View(visitorHistory);
        }
        [HttpPost]
        public ActionResult Details(VisitorHistory visitorHistory)
        {
            try
            {
                _iFVisitorHistory.Update(visitorHistory);
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
                    controller = "VisitorHistory",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
        [HttpPost]
        public ActionResult Edit(VisitorHistory visitorHistory)
        {
            try
            {
                _iFVisitorHistory.Update(visitorHistory);
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
                VisitorHistory visitorHistory = new VisitorHistory();
                return Json(_iFVisitorHistory.List());
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
                VisitorHistory visitorHistory = _iFVisitorHistory.Read(id);
                return View(visitorHistory);
            }
            catch (Exception ex)
            {
                return View(new VisitorHistory());
            }
        }
        [HttpPost]
        public ActionResult Update(VisitorHistory visitorHistory)
        {
            try
            {
                visitorHistory = _iFVisitorHistory.Update(visitorHistory);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public ActionResult Delete(VisitorHistory visitorHistory)
        {
            try
            {
                _iFVisitorHistory.Delete(visitorHistory);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}