using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class CommandHandler
    {
        private CommandState availableCommands;

        public CommandHandler()
        {
            availableCommands = new MovementState();
        }

        
        public CommandResponse processTurn(String userInput, Player thePlayer)
        {
            availableCommands = availableCommands.Update(thePlayer);
            ParsedInput validInput = parse(userInput);
            Command theCommand = availableCommands.getCommand(validInput.getCommand());
            if (theCommand == null)
                return new CommandResponse("Not a valid command for this state");
            return theCommand.Execute(validInput, thePlayer);
            
        }

        private ParsedInput parse(String userInput)
        {
            Parser theParser = new Parser(availableCommands.getLabels());
            return theParser.Parse(userInput);
        }
        
    }
}
