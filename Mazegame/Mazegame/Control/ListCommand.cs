using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class ListCommand : Command
    {
        private Player player;

        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            this.player = thePlayer;
            FiniteInventory playerItems = thePlayer.GetInventory();
            if (userInput.getArguments().Count == 0)
            {
                return listItem(playerItems); 
            }
            
            return new CommandResponse("Invalid argument");
        }

        private CommandResponse listItem(Inventory item)
        {
            if (item.getItem().Count == 0)
            {
                return new CommandResponse("There is no any item with you");
            }
            StringBuilder sb = new StringBuilder("The item with you are: \n");
           
            foreach(string name in item.getItem().Keys)
            {
                sb.Append("[" + name + "]" + " ");
            }
            return new CommandResponse(sb.ToString());
        }

    }
}
