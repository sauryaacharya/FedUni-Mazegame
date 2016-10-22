using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class CombatState : CommandState
    {
        public CombatState()
            : base()
        {

 
            getAvailableCommands().Add("look", new LookCommand());
            getAvailableCommands().Add("list", new ListCommand());
            getAvailableCommands().Add("equip", new EquipCommand());
            getAvailableCommands().Add("unequip", new UnequipCommand());
            getAvailableCommands().Add("attack", new AttackCommand());
            getAvailableCommands().Add("flee", new FleeCommand());
        }

        public override CommandState Update(Player thePlayer)
        {
            if (thePlayer.getCurrentLocation() is DragonCave)
            {
                return this;
            }
            else if (thePlayer.getCurrentLocation() is Shop)
            {
                return new CommerceState();
            }
            else
            {
                return new MovementState();
            }
            
        }
    }
}
