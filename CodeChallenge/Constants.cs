using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge
{
    public class Constants
    {
        //Parameters
        public const int MESSAGES_AMOUNT = 50;

        //HTML
        public const string TAG_STRONG = "STRONG";
        public const string TAG_BR = "<br />";
        public const string TAG_ITALIC = "i";

        //Commands
        public const string COMMAND_STOCK = "/stock";
        public const string ERROR_COMMAND_NOT_FOUND = "<font color=\"orange\"><i>Command not found, please try another command</i></font><br />";
        public const string ERROR_COMMAND_GENERIC = "<font color=\"orange\"><i>Command should follow the format \'/COMMAND=PARAM\'</i></font><br />";
    }
}