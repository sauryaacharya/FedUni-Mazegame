using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity.Utility
{
    public class AgilityTable
    {
        private static AgilityTable instance;

        private Dictionary<int, int> lookup = new Dictionary<int, int>();

        private AgilityTable(Dictionary<int, int> theTable)
        {
            lookup = theTable;
        }

        public static AgilityTable GetInstance()
        {
            if (instance == null)
                instance = new AgilityTable(new Dictionary<int, int>());
            return instance;
        }

        public void SetModifier(int agility, int modifier)
        {
            lookup[agility] = modifier;
        }

        public int GetModifier(int agility)
        {
            int maxAgility = lookup.Keys.Max();
            if (agility > maxAgility)
                return lookup[maxAgility];

            if (lookup.Keys.Contains(agility))
                return lookup[agility];
            throw new AgilityTableException("Can't find corresponding modifier for that agility value");
        }
    }

    public class AgilityTableException : Exception
    {
        private string message;

        public AgilityTableException()
            : base()
        {
        }

        public AgilityTableException(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
