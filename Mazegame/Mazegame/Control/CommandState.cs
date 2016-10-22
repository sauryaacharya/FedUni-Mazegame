using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public abstract class CommandState
    {
        private Hashtable availableCommands;

        public CommandState()
        {
            availableCommands = new Hashtable();
        }

        protected Hashtable getAvailableCommands()
        {
            return availableCommands;
        }

        protected void setAvailableCommands(Hashtable availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        public abstract CommandState Update(Player thePlayer);

        public Command getCommand(String commandLabel)
        {
            try
            {
                return (Command)availableCommands[commandLabel];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public ArrayList getLabels()
        {
            return new ArrayList(availableCommands.Keys);
        }
    }
}
