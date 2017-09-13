using AndersonCRMFunction;
using AndersonCRMModel;
using System;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    [RoutePrefix("Position")]
    public class PositionController : Controller
    {
        private IFPosition _iFPosition;

        public PositionController()
        {
            _iFPosition = new FPosition();
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Position());
        }

        public ActionResult Edit(int id)
        {
            var position = _iFPosition.Read(id);
            return View(position);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var position = _iFPosition.Read(id);
            return View(position);
        }


        [HttpPost]
        public ActionResult Details(Position position)
        {
            try
            {
                _iFPosition.Update(position);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Position position)
        {
            try
            {
                _iFPosition.Update(position);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Create(Position position)
        {
            try
            {
                position = _iFPosition.Create(position);
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
                Position position = new Position();
                return Json(_iFPosition.List());
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
                Position position = _iFPosition.Read(id);
                return View(position);
            }
            catch (Exception ex)
            {
                return View(new Position());
            }
        }

        [HttpPost]
        public JsonResult Update(Position position)
        {
            try
            {
                position = _iFPosition.Update(position);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(Position position)
        {
            try
            {
                _iFPosition.Delete(position);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}