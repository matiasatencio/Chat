using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using CodeChallenge.Entities;
using CodeChallenge.Entities.Commands;

namespace CodeChallenge
{
    public static class Functions
    {
        static HttpClient client = new HttpClient();

        public static string BuildChat(List<Message> list)
        {
            StringBuilder sb = new StringBuilder();
            list = list.OrderBy(item => item.TimeStamp).ToList();
            foreach (Message m in list)
            {
                sb.Append($"[ {m.TimeStamp.ToString("MMM/dd HH:mm:ss").AddTag(Constants.TAG_ITALIC)} ] { m.Username.AddTag(Constants.TAG_STRONG)}: {m.Text}{Constants.TAG_BR}");
            }
            return sb.ToString();
        }

        public static string AddTag(this string text, string tag)
        {
            return $"<{tag}>{text}</{tag}>";
        }

        

        public static List<Command> GetAllCommands()
        {
            List<Command> commands = new List<Command>();
            commands.Add(new StockCommand(Constants.COMMAND_STOCK));

            return commands;
        }
    }
}