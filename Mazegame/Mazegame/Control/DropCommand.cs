using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class DropCommand : Command
    {
        private Player player;

        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            this.player = thePlayer;
            FiniteInventory playerItems = thePlayer.GetInventory();
            foreach (string argument in userInput.getArguments())
            {
                if (playerItems.ContainsItem(argument))
                    return dropItem(argument, playerItems);

            }
            return new CommandResponse("You can't find that to drop");
        }

        private CommandResponse dropItem(string itemLabel, Inventory locationItems)
        {
            // remove the item from the location
            Item theItem = locationItems.RemoveItem(itemLabel);
            // add the item to the player inventory
            if (player.getCurrentLocation().getInventory().AddItem(theItem))
            {
                return new CommandResponse("You have drop the " + itemLabel);
            }
            locationItems.AddItem(theItem);
            return new CommandResponse("No item to drop");
            
        }

    }
}
