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
    [RoutePrefix("InternHistory")]
    public class InternHistoryController : Controller
    {
        private IFInternHistory _iFInternHistory;

        public InternHistoryController()
        {
            _iFInternHistory = new FInternHistory();

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
            var internHistory = _iFInternHistory.Read(id);
            internHistory.TimeOut = DateTime.Now.ToShortTimeString();
            return View(internHistory);
        }

        //[HttpGet]
        //[CustomAuthorize(AllowedRoles = new string[] { "Receptionist" })]
        //public ActionResult Add()
        //{
        //    return View();
        //}

        [HttpGet]
        //[CustomAuthorize(AllowedRoles = new string[] { "Receptionist" })]
        public ActionResult Add()
        {
            InternHistory internHistory = new InternHistory();
            internHistory.Date = DateTime.Now.ToString("MMMM dd, yyyy");
            internHistory.TimeIn = DateTime.Now.ToShortTimeString();
            return View(internHistory);
        }

        [HttpPost]
        public JsonResult Create(InternHistory internHistory)
        {
            try
            {
                internHistory = _iFInternHistory.Create(internHistory);
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
            var internHistory = _iFInternHistory.Read(id);
            return View(internHistory);
        }

        [HttpPost]
        public ActionResult Details(InternHistory internHistory)
        {
            try
            {
                _iFInternHistory.Update(internHistory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
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
                    controller = "InternHistory",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        [HttpPost]
        public ActionResult Edit(InternHistory internHistory)
        {
            try
            {
                _iFInternHistory.Update(internHistory);
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
                InternHistory internHistory = new InternHistory();
                return Json(_iFInternHistory.List());
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
                InternHistory internHistory = _iFInternHistory.Read(id);
                return View(internHistory);
            }
            catch (Exception ex)
            {
                return View(new InternHistory());
            }
        }

        [HttpPost]
        public ActionResult Update(InternHistory internHistory)
        {
            try
            {
                internHistory = _iFInternHistory.Update(internHistory);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(InternHistory internHistory)
        {
            try
            {
                _iFInternHistory.Delete(internHistory);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}