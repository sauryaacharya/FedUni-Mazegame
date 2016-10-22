using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Entity
{
    public class Inventory
    {
        private Money gold;
        protected Dictionary<string, Item> itemList;

        public Inventory()
        {
            gold = new Money();
            itemList = new Dictionary<string, Item>();
        }

        public void AddMoney(int goldPieces)
        {
            gold.Add(goldPieces);
        }

        public bool RemoveMoney(int goldPieces)
        {
            return gold.Subtract(goldPieces);
        }

        public bool ContainsItem(string itemLabel)
        {
            return itemList.ContainsKey(itemLabel);
        }

        public Dictionary<string, Item> getItem()
        {
            return itemList;
        }

        public bool AddItem(Item theItem)
        {
            itemList[theItem.GetLabel()] = theItem;
            return true;
        }

        public Item RemoveItem(string itemName)
        {
            if (itemList.ContainsKey(itemName))
            {
                Item theItem = itemList[itemName];
                itemList.Remove(itemName);
                return theItem;
            }

            throw new ItemNotFoundException("That item isn't here to remove");
        }

        private string printItemList()
        {
            if (itemList.Count == 0)
                return "Items :: No items";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Append("Items :: \n");
            foreach (KeyValuePair<string, Item> item in itemList)
            {
                returnMsg.Append("[" + item.Value.GetLabel() + "], " + "Weight: " + item.Value.GetWeight() + "kg" + ", Price: "+ item.Value.GetValue() +" gold pieces"+ "\n");
            }
            return returnMsg.ToString();
        }

        public override string ToString()
        {
            return printItemList() + "\n" + gold.ToString();
        }
    }

    public class ItemNotFoundException : Exception
    {
        private string message;

        public ItemNotFoundException()
            : base()
        {
        }

        public ItemNotFoundException(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
