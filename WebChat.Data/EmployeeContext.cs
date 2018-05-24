using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Entity;

namespace WebChat.Data
{
    public class EmployeeContext
    {
        public List<Employee> GetEmployees()
        {
            using (var dbcontext = new WebChatContext())
            {
                return dbcontext.Employees.ToList();
            }
        }        
        public Employee GetByID(int id)
        {
            using(var dbcontext=new WebChatContext())
            {
                return dbcontext.Employees.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public bool DeleteEmployee(int empID)
        {
            string error;
            try
            {
                using (var dbcontext = new WebChatContext())
                {
                    var silinecekEmployee = dbcontext.Employees.Where(x => x.Id == empID).FirstOrDefault();
                    int id = silinecekEmployee.Id;
                    dbcontext.Employees.Remove(silinecekEmployee);
                    dbcontext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error=ex.Message;
                return false;
            }
        }
        public bool CreateEmployee(Employee employee,out string error)
        {
            error = string.Empty;
            try
            {
                using(var dbcontext=new WebChatContext())
                {
                    dbcontext.Employees.Add(employee);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public bool UpdateEmployee(Employee employee,out string error)
        {
            error = string.Empty;
            try
            {
                using(var dbcontext=new WebChatContext())
                {
                    var employeeToUpdate=dbcontext.Employees.SingleOrDefault(s => s.Id == employee.Id);
                    if (employeeToUpdate == null)
                    {
                        error = "Employee Bulunamadı";
                        return false;  
                    }
                    employeeToUpdate.Name = employee.Name;
                    employeeToUpdate.Surname = employee.Surname;
                    employeeToUpdate.Job = employee.Job;
                    dbcontext.SaveChanges();

                    return true;
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
