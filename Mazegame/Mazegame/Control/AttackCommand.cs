using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;
using Mazegame.Entity.Utility;

namespace Mazegame.Control
{
    public class AttackCommand : Command
    {
        private Player player;

        public override CommandResponse Execute(ParsedInput userInput,
            Player thePlayer)
        {
            this.player = thePlayer;
            NonPlayerCharacterCollection npc = (NonPlayerCharacterCollection)thePlayer.getCurrentLocation().getNPC();
            /*
            if (userInput.getArguments().Count == 0)
            {
                return new CommandResponse("If you want to attack you have to tell me to whom you want to attack.");
            }
             * */
            if (npc.Count == 0)
            {
                return new CommandResponse("Dragon is already dead.");
            }
            
                foreach (string argument in userInput.getArguments())
                {
                    if (npc.ContainsKey(argument))
                    {
                        return attackNpc(argument, npc);
                    }

                }
                return new CommandResponse("If you want to attack you have to tell me to whom you want to attack.");
            
        }

        private CommandResponse attackNpc(string npcName, NonPlayerCharacterCollection npc_col)
        {
            int dam_point = 0;
            int npc_lifePoints = 0;
            if (player.getEquippedItem().Count == 0)
            {
                return new CommandResponse("You have to equip the item to attack");
            }
            else
            {
            foreach(Item item in player.getEquippedItem().Values)
            {
                if (item is Armor)
                {
                    return new CommandResponse("You have equip a weapon to attack.");
                }
            }
            }
            foreach(Item theItem in player.getEquippedItem().Values)
            {
                dam_point = ((Weapon)theItem).DamagePoints;
                foreach(NonPlayerCharacter npc in npc_col.Values)
                {
                    npc_lifePoints = npc.LifePoints - dam_point * 10;
                    npc.LifePoints = npc_lifePoints;
                }

            }
            if (npc_lifePoints <= 0)
            {
                npc_col.Remove(npcName);
                return new CommandResponse("Congratulationss! The dragon has been killed.");
            }
            return new CommandResponse("Character: "+ " << " + npcName + " >> \n" + "LifePoints: " + " << " + npc_lifePoints + " >> ");
           
        }

    }
}
