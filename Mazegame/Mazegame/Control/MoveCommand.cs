using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class MoveCommand:Command
    {
        public override CommandResponse Execute(ParsedInput userInput, Player thePlayer)
        {
            if (userInput.getArguments().Count == 0)
            {
                return new CommandResponse("If you want to move you need to tell me where");
            }
            String exitLabel = (String)userInput.getArguments()[0];
            Exit desiredExit = thePlayer.getCurrentLocation().getExitCollection().GetExit(exitLabel);
            if (desiredExit == null)
            {
                return new CommandResponse("There is no exit there.. Trying moving someplace moveable!!");
            }
            else
            {
                thePlayer.setCurrentLocation(desiredExit.Destination);
                return new CommandResponse("You successfully move " + exitLabel + " and find yourself somewhere else\n\n" + "Life Points: " + thePlayer.LifePoints + "\n" + thePlayer.getCurrentLocation().getPlayerWt(thePlayer) + "\n" + "Total weight of the item: " + thePlayer.GetInventory().GetWeight() + "kg" + "\n" + "Your money: " + thePlayer.getMoney().getMoney() + " gold pieces"+ "\n" + thePlayer.getCurrentLocation().ToString());
            }
        }
    }
}
