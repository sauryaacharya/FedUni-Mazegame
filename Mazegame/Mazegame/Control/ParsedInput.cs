using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Control
{
    public class ParsedInput
    {
        private String command;
        private ArrayList arguments;

        public ParsedInput()
        {
            arguments = new ArrayList();
            command = "";
        }

        public ParsedInput(String command, ArrayList arguments)
        {
            this.arguments = arguments;
            this.command = command;
        }

        public void setCommand(String command)
        {
            this.command = command;
        }

        public String getCommand()
        {
            return command;
        }

        public void setArguments(ArrayList arguments)
        {
            this.arguments = arguments;
        }

        public ArrayList getArguments()
        {
            return arguments;
        }
    }

  
}
