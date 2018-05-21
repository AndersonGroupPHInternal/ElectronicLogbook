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
using System.IO;

namespace ElectronicLogbookWeb.Controllers
{
    [RoutePrefix("Visitor")]
    public class VisitorController : Controller
    {
        private IFVisitor _iFVisitor;

        public VisitorController()
        {
            _iFVisitor = new FVisitor();
            _iFVisitor.CreateFolder();
        }
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            _iFVisitor.CreateFolder();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return View(visitor);
        }
      
        [HttpGet]
        public ActionResult Create()
        {
            Visitor visitor = new Visitor();
            return View(visitor);
        }
        [HttpPost]
        public ActionResult Create(Visitor visitor)
        {
            try
            {
                visitor = _iFVisitor.Create(visitor);
                return RedirectToAction("Index");
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
        public ActionResult PreviewId(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return View(visitor);
        }
        public ActionResult PrintId(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return new ActionAsPdf("PreviewId", new { id = id })
            {
                PageMargins = new Rotativa.Options.Margins(0, 0, 0, 0),
                PageHeight = 50.8,
                PageWidth = 76.2
            };
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            string directory = @"C:\Temp\";

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(directory, fileName));
            }

            return RedirectToAction("Add");

        }
        #region Preview PDF
        [HttpGet]
        public ActionResult PreviewVisitor(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return View(visitor);
        }

        public ActionResult Preview(int id)
        {
            var visitor = _iFVisitor.Read(id);
            return new ActionAsPdf("PreviewVisitor", new { id = id })
            {
                PageWidth = 215.9,
                PageHeight = 279.4
                /*FOR PDF DOWNLOAD WITH DESIRED FILENAME*/
                //FileName = visitor.Name + " | " + visitor.Date + ".pdf"
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
                return RedirectToAction("Index");
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