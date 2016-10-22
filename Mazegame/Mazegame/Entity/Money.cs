using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity
{
    public class Money
    {
        private int total;

        public Money()
        {
            total = 0;
        }

        public Money(int total)
        {
            this.total = total;
        }

        public void Add(int amount)
        {
            total += amount;
        }

        public bool Subtract(int amount)
        {
            if (amount > total)
                return false;
            total -= amount;
            return true;
        }

        public int getMoney()
        {
            return total;
        }

        public void setMoney(int total)
        {
            this.total = total;
        }

        public double GetWeight()
        {
            return (double)total / 100;
        }

        public override string ToString()
        {
            if (total < 1)
                return "No gold pieces";
            if (total == 1)
                return "One gold piece";
            return "There are " + total + " gold pieces";
        }
    }
}
