using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Example.Models;
using Service.Methods;

namespace MVC_Example.Controllers
{
    public class HomeController : Controller
    {
        Database database;

        public HomeController()
        {
            database = Database.Instance();
            database.IsConnect();
        }

        string AccountID;
        public IActionResult Index()
        {
            try
            {
                AccountID = HttpContext.Session.GetString("AccountID");
                Debug.WriteLine("Session Data: (ID)" + AccountID);

                if (AccountID == null)
                {
                    return Redirect("../Login/Index");
                }
            }
            catch { return Redirect("../Login/Index"); }

            return Redirect("../Notes");
        }

        [Route("Notes")]
        public IActionResult Notes()
        {
            database = Database.Instance();
            database.IsConnect();
            AccountID = HttpContext.Session.GetString("AccountID");

            return View(database.get_Notes(AccountID));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection)
        {
            string id = collection["id"].ToString();
            string subject = collection["subject"].ToString();
            string description = collection["description"].ToString();
            Debug.WriteLine(collection.ToString());

            database.command("update notes set subject='"+subject+"', description='"+description+"' where id="+id);
            return Redirect("../Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            ViewBag.id = id.ToString();
            ViewBag.subject = database.get("select subject from mvcdb.notes where id=" + id.ToString(), "subject");
            ViewBag.description = database.get("select description from mvcdb.notes where id=" + id.ToString(), "description");

            return View();
        }

        [HttpPost]
        public ActionResult Add(IFormCollection collection)
        {
            AccountID = HttpContext.Session.GetString("AccountID");

            string subject = collection["subject"].ToString();
            string description = collection["description"].ToString();
            Debug.WriteLine(collection.ToString());

            database.command("insert into mvcdb.notes (account_id,subject,description) values("+AccountID+",'" + subject.Replace("'", "") + "','" + description.Replace("'","") + "')");

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Del(int id)
        {
            database.command("delete from notes where id=" + id.ToString());
            return Redirect("Index");
        }
    }
}
