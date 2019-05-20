using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public Message()
        { }
        //public Message(int id, string username, string text, DateTime timeStamp)
        //{
        //    Id = id;
        //    Username = username;
        //    Text = text;
        //    TimeStamp = timeStamp;
        //}

    }
}