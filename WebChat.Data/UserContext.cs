using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Entity;

namespace WebChat.Data
{
    public class UserContext
    {
        
        public User GetirRolesByUserName(string username)
        {
            using(var dbcontext =new WebChatContext())
            {
                return dbcontext.Users.Where(x => x.UserName == username).FirstOrDefault();
            }
        }
        public User CheckLogin(string username,string password)
        {
            using(var dbcontext = new WebChatContext())
            {
                return dbcontext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            }
        }
        public bool CreateUser(User user,out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new WebChatContext())
                {
                    dbcontext.Users.Add(user);
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
        public bool UpdateUser(User user, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new WebChatContext())
                {
                    var userToUpdate = dbcontext.Users.SingleOrDefault(s => s.UserId == user.UserId);
                    if (userToUpdate == null)
                    {
                        error = "Employee Bulunamadı";
                        return false;
                    }
                    userToUpdate.UserName = user.UserName;
                    userToUpdate.Password = user.Password;
                    userToUpdate.Email = user.Email;
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
    }
}
