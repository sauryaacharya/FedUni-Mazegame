using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity.Utility
{
    public class WeightLimit
    {
        private static WeightLimit instance;

        private Dictionary<int, int> lookup = new Dictionary<int, int>();

        private WeightLimit(Dictionary<int, int> theTable)
        {
            lookup = theTable;
        }

        public static WeightLimit GetInstance()
        {
            if (instance == null)
                instance = new WeightLimit(new Dictionary<int, int>());
            return instance;
        }

        public void SetModifier(int strength, int weightLimit)
        {
            lookup[strength] = weightLimit;
        }

        public int GetModifier(int strength)
        {
            int maxStrength = lookup.Keys.Max();
            if (strength > maxStrength)
                return lookup[maxStrength];

            if (lookup.Keys.Contains(strength))
                return lookup[strength];
            throw new WeightLimitException("Can't find corresponding weight limit for that strength value");

        }
    }

    public class WeightLimitException : Exception
    {
        private string message;

        public WeightLimitException()
            : base()
        {
        }

        public WeightLimitException(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
