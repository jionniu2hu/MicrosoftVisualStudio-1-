using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "你好，MVC";
        }

        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "卢来佛";
            ct.Address = "66";
            return ct;
        }

        public ActionResult GetView()
        {
            string greeting;
            //获取当前时间
            DateTime h = DateTime.Now;
            //获取当前小时数
            int hour = h.Hour;
            //根据小时数判断要返回哪个视图，<12MyView否则返回YouView
            if (hour < 12)
            {
                greeting= "上午好";
            }
            else
            {
                greeting="下午好";
            }
            ViewBag.greeting = greeting;
            //ViewData["greeting"] = greeting;
            Employee emp = new Employee();
            emp.Name = "卢本伟";
            emp.Salary = 20000;

            EmployeeViewModel EmpVm = new EmployeeViewModel();
            EmpVm.EmployeeName = emp.Name;
            EmpVm.EmployeeSalary = emp.Salary.ToString("c");
            if (emp.Salary > 10000000)
            {
                EmpVm.EmployeeGrade = "土豪";
            }
            else
            {
                EmpVm.EmployeeGrade = "穷逼";
            }
            //EmpVm.Greeting = greeting;
            //EmpVm.UserName = "管理员";
            //ViewData["EmpKey"] = emp;
            return View("MyView", EmpVm);
        }
        
    }
}