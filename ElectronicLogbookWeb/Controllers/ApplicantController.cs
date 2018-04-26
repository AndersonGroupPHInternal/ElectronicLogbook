using AccountsWebAuthentication.Helper;
using ElectronicLogbookModel;
using ElectronicLogbookFunction;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using System.Data.Entity;
using Rotativa;
using System.Web;

namespace ElectronicLogbookWeb.Controllers
{
    [RoutePrefix("Applicant")]
    public class ApplicantController : Controller
    {
        private IFApplicant _iFApplicant;

        public ApplicantController()
        {
            _iFApplicant = new FApplicant();
            _iFApplicant.CreateFolder();

        }
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            _iFApplicant.CreateFolder();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var applicant = _iFApplicant.Read(id);
            applicant.TimeOut = DateTime.Now.ToShortTimeString();
            return View(applicant);
        }
        [HttpGet]
        public ActionResult Add()
        {
            Applicant applicant = new Applicant();
            applicant.Date = DateTime.Now.ToString("MMMM dd, yyyy");
            applicant.TimeIn = DateTime.Now.ToShortTimeString();
            return View(applicant);
        }
        [HttpPost]
        public JsonResult Create(Applicant applicant)
        {
            try
            {
                applicant = _iFApplicant.Create(applicant);
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
            var applicant = _iFApplicant.Read(id);
            return View(applicant);
        }
        [HttpPost]
        public ActionResult Details(Applicant applicant)
        {
            try
            {
                _iFApplicant.Update(applicant);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult PreviewId(int id)
        {
            var applicant = _iFApplicant.Read(id);
            return View(applicant);
        }
        public ActionResult PrintId(int id)
        {
            var applicant = _iFApplicant.Read(id);
            return new ActionAsPdf("PreviewId", new { id = id })
            {
                PageMargins = new Rotativa.Options.Margins(0, 0, 0, 0),
                PageHeight = 50.8,
                PageWidth = 76.2
            };
        }
        #region Preview PDF
        [HttpGet]
        public ActionResult PreviewApplicant(int id)
        {
            var applicant = _iFApplicant.Read(id);
            return View(applicant);
        }

        public ActionResult Preview(int id)
        {
            var applicant = _iFApplicant.Read(id);
            return new ActionAsPdf("PreviewApplicant", new { id = id })
            {
                PageWidth = 215.9,
                PageHeight = 279.4,
                /*FOR PDF DOWNLOAD WITH DESIRED FILENAME*/
                //FileName = applicant.Name + " | " + applicant.Date + ".pdf"
            };
        }
        #endregion
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Applicant",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
        [HttpPost]
        public ActionResult Edit(Applicant applicant)
        {
            try
            {
                _iFApplicant.Update(applicant);
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
                Applicant applicant = new Applicant();
                return Json(_iFApplicant.List());
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
                Applicant applicant = _iFApplicant.Read(id);
                return View(applicant);
            }
            catch (Exception ex)
            {
                return View(new Applicant());
            }
        }
        [HttpPost]
        public ActionResult Update(Applicant applicant)
        {
            try
            {
                applicant = _iFApplicant.Update(applicant);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public ActionResult Delete(Applicant applicant)
        {
            try
            {
                _iFApplicant.Delete(applicant);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}