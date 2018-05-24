using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Data;
using WebChat.Entity;

namespace WebChat.Repo
{
    public class EmployeeRepo
    {
        public readonly EmployeeContext _employeeContext;
        public EmployeeRepo()
        {
            _employeeContext = new EmployeeContext();
        }
        public List<Employee> GetEmployees()
        {
            return _employeeContext.GetEmployees();
        }
        public bool DeleteEmployee(int empID)
        {
            return _employeeContext.DeleteEmployee(empID);
        }
        public Employee GetByID(int empID)
        {
            return _employeeContext.GetByID(empID);
        }
        public bool UpdateEmployee(Employee employee, out string error)
        {
            error = string.Empty;
            if (employee.Name == string.Empty)
            {
                error = "Employee İsim Boş olamaz.";
                return false;
            }
            try
            {
                if (employee.Id > 0)
                {
                    if (!_employeeContext.UpdateEmployee(employee, out error))
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
        public bool SaveEmpolyee(Employee employee,out string error)
        {
            error = string.Empty;
            if (employee.Name == string.Empty)
            {
                error = "Employee İsim Boş olamaz.";
                return false;
            }            
            try
            {
                if (employee.Id > 0)
                {
                    if(!_employeeContext.UpdateEmployee(employee, out error))
                    {
                        return false;
                    }
                }
                else
                {
                    if(!_employeeContext.CreateEmployee(employee,out error))
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
