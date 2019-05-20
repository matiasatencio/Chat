using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Entities.Commands
{
    public abstract class Command
    {
        public string Name { get; set; }

        public Command(string name)
        {
            this.Name = name;
        }

        public abstract string Perform(string param);
    }
}