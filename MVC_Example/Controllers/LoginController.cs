using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Methods;

namespace MVC_Example.Controllers
{
    public class LoginController : Controller
    {
        Database database;
        public LoginController()
        {
            database = Database.Instance();
            database.IsConnect();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(IFormCollection collection)
        {
            string username = collection["username"].ToString();
            string password = collection["password"].ToString();

            bool status = database.get_Bool("select id from accounts where username='"+username+"' and password='"+password+"'");
            Debug.WriteLine("DURUM:"+status.ToString());
            if (status)
            {
                string id= database.get("select id from accounts where username='" + username + "' and password='" + password + "'","id");
                Debug.WriteLine("DURUM (2):"+ id.ToString());

                HttpContext.Session.SetString("AccountID",id);
                return Redirect("../Notes");
            }
            else
            {
                ViewBag.warning = "Kullanıcı adı veya şifre hatalı.";
            }

            return Redirect("Index");
        }
    }
}