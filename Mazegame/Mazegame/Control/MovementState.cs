using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity;

namespace Mazegame.Control
{
    public class MovementState : CommandState
    {
        public MovementState()
            : base()
        {
            getAvailableCommands().Add("go", new MoveCommand());
            getAvailableCommands().Add("get", new GetCommand());
            getAvailableCommands().Add("take", new GetCommand());
            getAvailableCommands().Add("pickup", new GetCommand());
            getAvailableCommands().Add("quit", new QuitCommand());
            getAvailableCommands().Add("move", new MoveCommand());
            getAvailableCommands().Add("look", new LookCommand());
            getAvailableCommands().Add("unlock", new UnlockCommand());
            getAvailableCommands().Add("drop", new DropCommand());
            getAvailableCommands().Add("list", new ListCommand());
            getAvailableCommands().Add("equip", new EquipCommand());
            getAvailableCommands().Add("unequip", new UnequipCommand());
           
        }

        public override CommandState Update(Player thePlayer)
        {
            if (thePlayer.getCurrentLocation() is Shop)
            {
                return new CommerceState();
            }
            else if (thePlayer.getCurrentLocation() is DragonCave)
            {
                return new CombatState();
            }
            else
            {
                return this;
            }
        }
    }
}
