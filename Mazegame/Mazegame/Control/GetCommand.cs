using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class GetCommand : Command
    {
        private Player player;

        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            this.player = thePlayer;
            Inventory locationItems = thePlayer.getCurrentLocation().getInventory();
            foreach (string argument in userInput.getArguments())
            {
                if (locationItems.ContainsItem(argument))
                    return takeItem(argument, locationItems);

            }
            return new CommandResponse("You can't find that to take");
        }

        private CommandResponse takeItem(string itemLabel, Inventory locationItems)
        {
            // remove the item from the location
            Item theItem = locationItems.RemoveItem(itemLabel);
            // add the item to the player inventory
            if (player.GetInventory().AddItem(theItem))
            {
                return new CommandResponse("You have taken the " + itemLabel);
            }
            locationItems.AddItem(theItem);
            return new CommandResponse("The " + itemLabel + " is too heavy");
        }

    }
}
