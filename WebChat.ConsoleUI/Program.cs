using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Entity;
using WebChat.Repo;

namespace WebChat.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepo = new EmployeeRepo();
            Console.WriteLine("***Mevcut Employee***");
            foreach(Employee emp in employeeRepo.GetEmployees())
            {
                Console.WriteLine("Employee id {0}, Name : {1}", emp.Id, emp.Name);
            }


            Console.WriteLine("***Employee yeni ekle");
            string error;
            var newEmployee = new Employee()
            {
                Name = "Ahmet"
            };
            if(employeeRepo.SaveEmpolyee(newEmployee,out error))
            {
                Console.WriteLine("Yeni Employee Eklendi");
            }
            {
                Console.WriteLine("Hata: {0}", error);
            }


            Console.WriteLine("***Güncel Liste***");
            foreach (Employee emp in employeeRepo.GetEmployees())
            {
                Console.WriteLine("Employee id {0}, Name : {1}", emp.Id, emp.Name);
            }
        }
    }
}
