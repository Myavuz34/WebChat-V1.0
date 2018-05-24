using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Data;
using WebChat.Entity;

namespace WebChat.Repo
{
    public class ChatMessageRepo
    {
        public readonly ChatMessageContext _chatMessageContext;

        public ChatMessageRepo()
        {
            _chatMessageContext = new ChatMessageContext();
        }
        public bool SaveChatMessage(ChatMessage chtMsg,out string error)
        {
            error = string.Empty;
            try
            {
                if(!_chatMessageContext.CreateMessage(chtMsg,out error))
                {
                    return false;
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
