using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Data;
using WebChat.Entity;

namespace WebChat.Repo
{
    public class UserRepo
    {
        public readonly UserContext _userContext;
        public UserRepo()
        {
            _userContext = new UserContext();
        }
        public User LoginUser(string username, string password)
        {
            return _userContext.CheckLogin(username, password);
        } 
        public User GetirRolesByUserName(string username)
        {
            return _userContext.GetirRolesByUserName(username);
        }
        public bool SaveUser(User user,out string error)
        {
            error = string.Empty;
            if (user.UserName == string.Empty)
            {
                error = "Kullanıcı adı Boş olamaz.";
                return false;
            }
            try
            {
                if (user.UserId> 0)
                {
                    if (!_userContext.UpdateUser(user, out error))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!_userContext.CreateUser(user, out error))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
