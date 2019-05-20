using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using CodeChallenge.DataAccess.Chat;
using CodeChallenge.Entities;
using CodeChallenge.Entities.Chat;
using CodeChallenge.Entities.Commands;

namespace CodeChallenge
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            ChatDa.InsertMessage(name, message);
            GetMessages();
        }

        public void Command(string name, string message)
        {
            try
            {
                List<Command> allCommands = Functions.GetAllCommands();

                //Command exists
                if (allCommands.Any(c => c.Name == message.Split('=')[0]))
                {
                    Command com = allCommands.First(c => c.Name == message.Split('=')[0]);
                    message = com.Perform(message.Split('=')[1]);
                    Send(name, message);
                }
                else //Command does not exist
                {
                    List<Message> messages = ChatDa.GetMessages(Constants.MESSAGES_AMOUNT);
                    string chatText = Functions.BuildChat(messages) + Constants.ERROR_COMMAND_NOT_FOUND;
                    //Sends an error message only to the sender
                    Clients.Caller.SendChat(chatText);
                }
            }
            catch(Exception ex)
            {
                List<Message> messages = ChatDa.GetMessages(Constants.MESSAGES_AMOUNT);
                string chatText = Functions.BuildChat(messages) + Constants.ERROR_COMMAND_GENERIC;
                //Sends an error message only to the sender
                Clients.Caller.SendChat(chatText);
            }
        }

        public void GetMessages()
        {
            List<Message> messages = ChatDa.GetMessages(Constants.MESSAGES_AMOUNT);
            string chatText = Functions.BuildChat(messages);
            Clients.All.SendChat(chatText);
        }
    }
}