using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Entity;

namespace WebChat.Data
{
    public class WebChatContext:DbContext
    {
        //private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        public WebChatContext() : base("name=WebChatConnection")
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
