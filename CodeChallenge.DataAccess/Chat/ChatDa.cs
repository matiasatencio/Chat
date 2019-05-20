using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeChallenge.DAL.Chat;
using CodeChallenge.Entities;

namespace CodeChallenge.DataAccess.Chat
{
    public class ChatDa
    {
        private static readonly ChatDAL _dal = ChatDAL.Instance;

        public static void InsertMessage(string username, string text)
        {
            _dal.InsertMessage(username, text);
        }

        public static List<Message> GetMessages(int amount)
        {
            return _dal.GetMessages(amount);
        }
    }
}