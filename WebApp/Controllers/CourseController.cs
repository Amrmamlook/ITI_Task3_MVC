using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Cookies
        /// </summary>
        /// <returns></returns>
        public IActionResult Details()
        {
            Response.Cookies.Append("id", "3");
            Response.Cookies.Append("name", "Amr");

            ViewBag.id = 3;
            ViewBag.name = "Amr";
            return View();
        }
        public IActionResult Show() {

            int id = int.Parse(Request.Cookies["id"]);
            string name = Request.Cookies["name"];
            ViewBag.name = name;
            ViewBag.id= id;
            return View();
        }
        /// <summary>
        /// Sessions
        /// </summary>
        /// <returns></returns>
        public IActionResult SessionDeta() 
        {
            HttpContext.Session.SetInt32("id", 3);
            HttpContext.Session.SetString("name", "Ahmed");
            ViewBag.id = 3;
            ViewBag.name = "Ahmed";
            return View();
        }
        public IActionResult SessionDiplay()
        {
            int? id = HttpContext.Session.GetInt32("id");
            string name =HttpContext.Session.GetString("name");
            ViewBag.name = name;
            ViewBag.id = id;
            return View();
        }
    }
}
