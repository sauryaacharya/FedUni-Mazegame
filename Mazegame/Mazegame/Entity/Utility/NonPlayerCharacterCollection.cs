using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity.Utility
{
    public class NonPlayerCharacterCollection : Dictionary<string, NonPlayerCharacter>
    {
        public NonPlayerCharacterCollection()
            : base()
        {
        }


        public override string ToString()
        {
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Append("Characters ::");
            if (this.Count == 0)
                returnMsg.Append(" No characters");
            else
            {
                foreach (NonPlayerCharacter npc in Values)
                    returnMsg.Append(" << " + npc.Name + " >> " + " \nLifePoints:: << " + npc.LifePoints + " >> ");
            }

            return returnMsg.ToString();
        }

    }
}