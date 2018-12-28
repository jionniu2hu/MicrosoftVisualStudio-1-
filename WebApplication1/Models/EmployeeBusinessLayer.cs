using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
                        
            SalesERPDAL salesDAL = new SalesERPDAL();
            return salesDAL.Employees.ToList();


            //var list = new List<Employee>();
            //Employee emp = new Employee();
            //emp.Name = "卢本伟";
            //emp.Salary = 10000;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "弥勒";
            //emp.Salary = 666666;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "约书亚";
            //emp.Salary = 13131313;
            //list.Add(emp);

            //return list;
        }

        public void AddEmployee(Employee emp)
        {
            using(var db=new SalesERPDAL())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }
        }

        public void DeleteEmpoyee(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                db.Entry(emp).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void UpdateEmpoyee(Employee emp)
        {
            using (var db = new SalesERPDAL())
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Employee Query(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                return emp;
            }
        }        

        public IEnumerable<Employee> QueryName(string searchName)
        {
            using (var db = new SalesERPDAL())
            {
                return db.Employees.Where(e => e.Name.Contains(searchName)).ToList();
            }
        }
    }
}