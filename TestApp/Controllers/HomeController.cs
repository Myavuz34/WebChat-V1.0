using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Entity;
using WebChat.Repo;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim Bilgileri";

            return View();
        }
        public ActionResult Listele()
        {
            if (Session["UserId"] != null)
            {
                var employeeRepo = new EmployeeRepo();
                return View(employeeRepo.GetEmployees());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult Detaylar(int id)
        {
            var employee = new EmployeeRepo().GetByID(id);
            return View(employee);
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult YeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKayit(Employee emp)
        {
            string error;
            var employeeRepo = new EmployeeRepo();
            try
            {
                employeeRepo.SaveEmpolyee(new Employee()
               {
                   Name= emp.Name,
                   Surname=emp.Surname,
                   Job=emp.Job
                   
               }, out error);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Listele");  
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Listele");
            var employee = new EmployeeRepo().GetByID(id.Value);
            if (employee == null)
                return RedirectToAction("Listele");
            var model = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Job=employee.Job
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Duzenle(Employee model)
        {
            string error;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "personel güncellenirken hata oluştu.");
                return View(model);
            }
            try
            {
                var employee = new EmployeeRepo().GetByID(model.Id);
                employee.Name = model.Name;
                employee.Surname = model.Surname;
                employee.Job = model.Job;
                new EmployeeRepo().UpdateEmployee(employee,out error);
                return RedirectToAction("Listele");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }
      
        public ActionResult Sil(int id)
        {
            var employee = new EmployeeRepo().GetByID(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Sil(Employee employee)
        {
            var emp = new EmployeeRepo().DeleteEmployee(employee.Id);
            return View("Anasayfa");
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}
