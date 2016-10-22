using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity.Utility
{
    public class StrengthTable
    {
        private static StrengthTable instance;

        private Dictionary<int, int> lookup = new Dictionary<int, int>();

        private StrengthTable(Dictionary<int, int> theTable)
        {
            lookup = theTable;
        }

        //public static StrengthTable GetInstance(Dictionary<int, int> theTable)
        //{
        //    if (instance == null)
        //        instance = new StrengthTable(theTable);
        //    return instance;
        //}

        public static StrengthTable GetInstance()
        {
            if (instance == null)
                instance = new StrengthTable(new Dictionary<int, int>());
            return instance;
        }

        public void SetModifier(int strength, int modifier)
        {
            lookup[strength] = modifier;
        }

        public int GetModifier(int strength)
        {
            int maxStrength = lookup.Keys.Max();
            if (strength > maxStrength)
                return lookup[maxStrength];

            if (lookup.Keys.Contains(strength))
                return lookup[strength];
            throw new StrengthTableException("Can't find corresponding modifier for that strength value");

        }
    }

    public class StrengthTableException : Exception
    {
        private string message;

        public StrengthTableException()
            : base()
        {
        }

        public StrengthTableException(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
