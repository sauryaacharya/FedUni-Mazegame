///////////////////////////////////////////////////////////
//  Character.cs
//  Implementation of the Class Character
//  Generated by Enterprise Architect
//  Created on:      28-Apr-2014 10:13:36 PM
//  Original author: Gsimmons
///////////////////////////////////////////////////////////

using System;
using Mazegame.Entity.Utility;

namespace Mazegame.Entity
{
    public class Character
    {
        private int agility;
        private int lifePoints;
        private String name;
        private int strength;
        private FiniteInventory items;
        private Money gold;

        public Character()
        {
            agility = DiceRoller.GetInstance().GenerateAbilityScore();
            strength = DiceRoller.GetInstance().GenerateAbilityScore();
            items = new FiniteInventory(strength);
            
        }

        public Character(String name, int lifePoints)
            : this()
        {
            Name = name;  
            this.gold = new Money();
            LifePoints = lifePoints;
        }

        public Money getMoney()
        {
            return gold;
        }

        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        public int LifePoints
        {
            get { return lifePoints; }
            set { lifePoints = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                items.SetStrength(strength);
            }
        }

        public FiniteInventory GetInventory()
        {
            return this.items;
        }

    } //end Character
} //end namespace Entity