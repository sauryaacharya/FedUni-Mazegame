using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;
using System.Collections;

namespace Mazegame.Control
{
    public class LookCommand:Command
    {
        private CommandResponse response;

        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            response = new CommandResponse("Can't find that to look at here!");
            if (userInput.getArguments().Count == 0)
            {
                response.setMessage(thePlayer.getCurrentLocation().ToString());
                return response;
            }
            foreach (string argument in userInput.getArguments())
            {
                if (thePlayer.getCurrentLocation().getExitCollection().ContainsExit(argument))
                {
                    Exit theExit = thePlayer.getCurrentLocation().getExitCollection().GetExit(argument);
                    return new CommandResponse(theExit.Description);
                }    
            }
            return response;
        }

    }
}
