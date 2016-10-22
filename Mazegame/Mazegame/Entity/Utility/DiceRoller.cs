using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity.Utility
{
    public class DiceRoller
    {
        private static DiceRoller instance = new DiceRoller();

        private Dice d6;

        private DiceRoller()
        {
            d6 = new Dice(6);
        }

        public static DiceRoller GetInstance()
        {
            return instance;
        }

        // roll 5 six sided die, take the best 3 
        // and return the total
        public int GenerateAbilityScore()
        {
            List<int> results = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                results.Add(d6.Roll());
            }
            results.Sort();
            results.RemoveRange(0, 2);
            return results.Sum();
        }
    }
}
