using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            Client cent = new Client();
            Employee emp = new Employee();

            cent.Name = "卢来佛祖";
            emp.Name = "卢本伟";

            cent.Address = 100;
            emp.Salary = 20000;

            ViewBag.vb = cent;
            ViewBag.EmpKey = emp;

            return View("ClientView", cent);
            
        }
        
    }
}