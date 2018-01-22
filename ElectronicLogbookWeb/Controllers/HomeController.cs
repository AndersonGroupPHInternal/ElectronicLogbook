using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ElectronicLogbookWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var date = DateTime.Now.ToString("MMMM dd, yyyy");
            if (!Directory.Exists(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy")) &&
                !Directory.Exists(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy")) && 
                !Directory.Exists(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy")))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantDetails");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorDetails");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternDetails");
            }
            else if (date != DateTime.Now.ToString("MMMM dd, yyyy"))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantDetails");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorDetails");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternDetails");
            }
            else
            {
            }
            return View();
        }
    }
}