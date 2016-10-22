using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class EquipCommand : Command
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
            try
            {
                if (thePlayer.IsValidArmorName(armorName, thePlayer.GetInventory().getItem()[armorName]))
                {

                    if (thePlayer.getEquippedItem().Count == 0)
                    {
                            thePlayer.equippItem(thePlayer.GetInventory().getItem()[armorName]);
                            if (thePlayer.GetInventory().getItem()[armorName] is Armor)
                            {
                                thePlayer.LifePoints = thePlayer.LifePoints + ((Armor)thePlayer.GetInventory().getItem()[armorName]).Bonus;
                            }
                            return new CommandResponse("You equipped " + armorName);
                    }
                    else
                    {
                        if (thePlayer.getEquippedItem().ContainsKey(armorName))
                        {

                            return new CommandResponse(armorName + " is already equipped");
                        }

                        return new CommandResponse("You can equip only one item at a time");
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return new CommandResponse("You have to get the weapon or armor to equip");
            }
            return new CommandResponse("You can't find that to equip");
        }
    }
}
