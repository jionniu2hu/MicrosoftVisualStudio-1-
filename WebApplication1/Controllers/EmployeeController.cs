using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();

            //获取将处理过的数据列表
            empListModel.EmployeeViewList = getEmpVM();
            //获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.userName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }
        
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult Save(Employee emp)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.AddEmployee(emp);
            //return (emp.Name + "----" + emp.Salary.ToString());
            return new RedirectResult("index");
        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            
            empBL.DeleteEmpoyee(id);
            return RedirectToAction("index");
        }

        public ActionResult Update(int id)
        {
            //ViewBag.id = id;
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            Employee emp = empBL.Query(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Update(Employee emp)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.UpdateEmpoyee(emp);
            return RedirectToAction("index");
        }

        public ActionResult QueryName(string searchName)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            var QueryResult = empBL.QueryName(searchName);
            return View(QueryResult);
        }



        [NonAction]
        List<EmployeeViewModel> getEmpVM()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            var listEmp = empBL.GetEmployeeList();

            var listEmpVm = new List<EmployeeViewModel>();
            foreach (var key in listEmp)
            {
                EmployeeViewModel empVmOdj = new EmployeeViewModel();
                empVmOdj.EmployeeId = key.EmployeeId;
                empVmOdj.EmployeeName = key.Name;
                empVmOdj.EmployeeSalary = key.Salary.ToString("C");
                if (key.Salary > 1000)
                {
                    empVmOdj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmOdj.EmployeeGrade = "穷鬼";
                }
                listEmpVm.Add(empVmOdj);
            }
            return listEmpVm;
        }

        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime h = DateTime.Now;
            //获取当前小时数
            int hour = h.Hour;
            //根据小时数判断要返回哪个视图，<12MyView否则返回YouView
            if (hour < 12)
            {
                greeting = "上午好";
            }
            else
            {
                greeting = "下午好";
            }
            //empListModel.Greeting = greeting;
            return greeting;
        }

        [NonAction]
        string getUserName()
        {
            return "Admin";
        }
    }
}