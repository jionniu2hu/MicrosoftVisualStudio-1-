using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> student = new List<Student>();
            Student st = new Student();
            st.id = 01;
            st.Name = "卢本伟";

            student.Add(st);


            st = new Student();
            st.id = 02;
            st.Name = "五五开";

            student.Add(st);

            foreach(var key in student)
            {
                Console.WriteLine("id:{0},Name:{1}", key.id, key.Name);
            }
            Console.ReadLine();
        }

    }
    
}