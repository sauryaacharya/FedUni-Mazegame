using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class FleeCommand : Command
    {
        private Player player;

        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            this.player = thePlayer;
            player.setCurrentLocation(player.getCurrentLocation().getExitCollection().GetRandomExit().Destination);
            return new CommandResponse("You have fled to " + player.getCurrentLocation().Label + "\n\n" + "Life Points: " + thePlayer.LifePoints + "\n" + thePlayer.getCurrentLocation().getPlayerWt(thePlayer) + "\n" + "Total weight of the item: " + thePlayer.GetInventory().GetWeight() + "kg" + "\n" + "Your money: " + thePlayer.getMoney().getMoney() + " gold pieces"+ "\n"+ player.getCurrentLocation().ToString());
        }

        

    }
}
