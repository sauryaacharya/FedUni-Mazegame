using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public abstract class Command
    {
        public abstract CommandResponse Execute(ParsedInput userInput, Player thePlayer);
    }
}
