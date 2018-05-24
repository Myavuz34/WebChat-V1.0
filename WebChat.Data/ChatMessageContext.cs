using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Entity;

namespace WebChat.Data
{
    public class ChatMessageContext
    {
        public bool CreateMessage(ChatMessage msg,out string error)
        {
            error = string.Empty;
            try
            {
                using(var dbcontext=new WebChatContext())
                {
                    dbcontext.ChatMessages.Add(msg);
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
