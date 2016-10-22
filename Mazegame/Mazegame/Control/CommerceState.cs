using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class CommerceState : CommandState
    {
        public CommerceState() : base()
        {
            getAvailableCommands().Add("go", new MoveCommand());
            getAvailableCommands().Add("buy", new BuyCommand());
            getAvailableCommands().Add("sell", new SellCommand());
            getAvailableCommands().Add("move", new MoveCommand());
            getAvailableCommands().Add("look", new LookCommand());
            getAvailableCommands().Add("list", new ListCommand());
            getAvailableCommands().Add("equip", new EquipCommand());
            getAvailableCommands().Add("unequip", new UnequipCommand());
        }

        public override CommandState Update(Player thePlayer)
        {
            if (thePlayer.getCurrentLocation() is Shop)
            {
                return this;
            }
            else if (thePlayer.getCurrentLocation() is DragonCave)
            {
                return new CombatState();
            }
            else
            {
                return new MovementState();
            }
        }
    }
}
