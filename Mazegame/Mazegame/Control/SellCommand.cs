using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class SellCommand : Command
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
                    return sellItem(argument, playerItems);

            }
            return new CommandResponse("You can't find that to sell");
        }

        private CommandResponse sellItem(string itemLabel, Inventory locationItems)
        {
            // remove the item from the location
            Item theItem = locationItems.RemoveItem(itemLabel);
            // add the item to the player inventory
            if (player.getCurrentLocation().getInventory().AddItem(theItem))
            {
                int rem_coins = player.getMoney().getMoney();
                double discount_rate = (double)20/100;
                double item_val = (double)theItem.GetValue();
                double discount_amount = discount_rate * item_val;
                int sell_amt = (int)(item_val - discount_amount);
                player.getMoney().setMoney(rem_coins+sell_amt);
                return new CommandResponse("You have sold " + itemLabel + "at the discount of 20%.");
            }
            locationItems.AddItem(theItem);
            return new CommandResponse("No item to sell");
        }

    }
}
