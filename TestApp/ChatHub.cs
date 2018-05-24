using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebChat.Entity;
using WebChat.Repo;

namespace TestApp
{
    public class ChatHub : Hub
    {
        public void Send(string username, string message)
        {
            Clients.All.sendMessage(username, message);            
            SendChat(username,message);
        }
        public void SendChat(string username,string message)
        {
            string error;            
            var chtMsgRepo = new ChatMessageRepo();
            try
            {
                chtMsgRepo.SaveChatMessage(new ChatMessage()
                {
                    UserName = username,
                    Message = message,
                }, out error);

            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
        }
    }
}