using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazegame.Entity.Utility;

namespace Mazegame.Entity
{
    public class FiniteInventory : Inventory
    {
        private double weightLimit;

        public FiniteInventory(int strength)
            : base()
        {
            SetStrength(strength);
        }

        public void SetStrength(int strength)
        {
            weightLimit = (double)WeightLimit.GetInstance().GetModifier(strength);
        }

        public double getStrength()
        {
            return weightLimit;
        }

        public double GetWeight()
        {
            double currentWeight = 0;
            foreach (Item theItem in this.itemList.Values)
            {
                currentWeight += theItem.GetWeight();
            }
            return currentWeight;
        }

        public virtual bool AddItem(Item theItem)
        {
            if (weightLimit > theItem.GetWeight() + GetWeight())
                return base.AddItem(theItem);
            return false;
        }

        public virtual Item RemoveItem(string itemName)
        {
            if (itemList.ContainsKey(itemName))
            {
                Item theItem = itemList[itemName];
                itemList.Remove(itemName);
                return theItem;
            }

            throw new ItemNotFoundException("That item isn't here to remove");
        }
    }
}
