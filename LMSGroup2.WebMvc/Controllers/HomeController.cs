using LMSGroup2.BAL;
using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSGroup2.WebMvc.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            UsersBO usersBo = new UsersBO();
            var users = usersBo.GetUsers();

            return View(users);
        }

        public ActionResult Edit()
        {
            UsersBO usersBo = new UsersBO();
            var user = usersBo.GetUserById(Convert.ToInt32(RouteData.Values["Id"]));

            return View(user);
        }

        public ActionResult Save()
        {
            UsersBO usersBo = new UsersBO();
            var user = usersBo.Save( // Pass the used object model );

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}