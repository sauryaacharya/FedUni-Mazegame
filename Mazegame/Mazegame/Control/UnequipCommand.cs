using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class UnequipCommand : Command
    {
        private Player player;

        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            this.player = thePlayer;
            FiniteInventory playerItems = thePlayer.GetInventory();
            if (userInput.getArguments().Count == 0)
            {
                return new CommandResponse("If you want to equip your body tell me what to wear");
            }
            String armorName = (String)userInput.getArguments()[0];
            if (thePlayer.getEquippedItem().ContainsKey(armorName))
            {
                thePlayer.unEquipItem(armorName);
                if (thePlayer.GetInventory().getItem()[armorName] is Armor)
                {
                    thePlayer.LifePoints = thePlayer.LifePoints - ((Armor)thePlayer.GetInventory().getItem()[armorName]).Bonus;
                }
                return new CommandResponse("You unequipped " + armorName);
            }            
                return new CommandResponse("You have not equipped this item");
        }

        

    }
}
