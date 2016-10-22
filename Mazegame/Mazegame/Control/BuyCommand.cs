using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class BuyCommand : Command
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
                    return buyItem(argument, locationItems);

            }
            return new CommandResponse("You can't find that to buy");
        }

        private CommandResponse buyItem(string itemLabel, Inventory locationItems)
        {
            // remove the item from the location
            Item theItem = locationItems.RemoveItem(itemLabel);
            // add the item to the player inventory
            if (player.GetInventory().AddItem(theItem))
            {
                if (player.getMoney().getMoney() < theItem.GetValue())
                {

                    return new CommandResponse("Not enough gold coins to buy");
                }
                int rem_coins = player.getMoney().getMoney();
                int item_val = theItem.GetValue();
                player.getMoney().setMoney(rem_coins - item_val);
                return new CommandResponse("You bought " + itemLabel);
            }
            locationItems.AddItem(theItem);
            return new CommandResponse("The " + itemLabel + " is too heavy");
        }

    }
}
