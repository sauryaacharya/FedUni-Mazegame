///////////////////////////////////////////////////////////
//  Location.cs
//  Implementation of the Class Location
//  Generated by Enterprise Architect
//  Created on:      28-Apr-2014 10:13:37 PM
//  Original author: Gsimmons
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Mazegame.Entity.Utility;

namespace Mazegame.Entity
{
    public class Location
    {
        private Inventory items;
        private readonly NonPlayerCharacterCollection characterList;
        private readonly ExitCollection exitCollection;
        private String description;
        private String label;

        public Location()
        {
            exitCollection = new ExitCollection();
            characterList = new NonPlayerCharacterCollection();
            items = new Inventory();
            
        }

        public Location(String description, String label)
            : this()
        {
            Description = description;
            Label = label;
        }

        public void AddNonPlayerCharacter(NonPlayerCharacter theNPC)
        {
            characterList.Add(theNPC.Name, theNPC);
        }

        public Dictionary<string, NonPlayerCharacter> getNPC()
        {
            return characterList;
        }

        public bool ContainsNPC(string nameNpc)
        {
            return characterList.ContainsKey(nameNpc);
        }

        public bool RemoveNonPlayerCharacter(string name)
        {
            return characterList.Remove(name);
        }

        public Inventory getInventory()
        {
            return items;
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Label
        {
            get { return label; }
            set { label = value; }
        }

        public ExitCollection getExitCollection()
        {
            return exitCollection;
        }

        public String getPlayerWt(Player player)
        {
            return "Your max weight: " + player.GetInventory().getStrength() + "kg";
        }

        public String getItemWt(Player player)
        {
            return "Your max weight: " + player.GetInventory().getStrength() + "kg";
        }

        public override string ToString()
        {
            return

                "**********\n" + this.Label + "\n**********"
                + "\n" + exitCollection.AvailableExits()
                + "\n" + items.ToString()
                + "\n" + characterList.ToString()
                + "\n**********\nYou find yourself in "
                + this.Description + "\n**********\n";
        }
    }
}