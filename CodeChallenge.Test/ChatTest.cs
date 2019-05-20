using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge;
using CodeChallenge.Entities;
using CodeChallenge.Entities.Commands;
using System.Collections.Generic;
using CodeChallenge.Entities.Chat;

namespace CodeChallenge.Test
{
    [TestClass]
    public class ChatTest
    {
        [TestMethod]
        public void When_BuildingChat_NoMessages()
        {
            List<Message> list = new List<Message>();
            string response = Functions.BuildChat(list);
            Assert.AreEqual(response, string.Empty);
        }

        [TestMethod]
        public void When_BuildingChat_OneMessage()
        {
            List<Message> list = new List<Message>();
            Message m1 = new Message() { Id = 2, Username = "test_user", Text = "testing", TimeStamp = DateTime.Today };
            list.Add(m1);
            string response = Functions.BuildChat(list);
            Assert.AreEqual(response, $"[ <i>{DateTime.Today.ToString("MMM/dd HH:mm:ss")}</i> ] <STRONG>test_user</STRONG>: testing<br />");
        }

        [TestMethod]
        public void When_AddingTag()
        {
            string tag = "strong";
            string text = "hello";
            string response = Functions.AddTag(text, tag);
            Assert.AreEqual(response, "<strong>hello</strong>");
        }

        [TestMethod]
        public void When_ParsingCSV_Exists()
        {
            Stock s = StockCommand.ParseToStock(@"https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv");

            Assert.AreEqual(s.Symbol, "AAPL.US");
        }

        [TestMethod]
        public void When_ParsingCSV_DoesNotExists()
        {
            Stock s = StockCommand.ParseToStock(@"https://stooq.com/q/l/?s=aaaaapl.us&f=sd2t2ohlcv&h&e=csv");

            Assert.IsNull(s);
        }
    }
}
