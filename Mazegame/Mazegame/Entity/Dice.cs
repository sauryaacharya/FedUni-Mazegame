///////////////////////////////////////////////////////////
//  Dice.cs
//  Implementation of the Class Dice
//  Generated by Enterprise Architect
//  Created on:      28-Apr-2014 10:13:36 PM
//  Original author: Gsimmons
///////////////////////////////////////////////////////////


using System;

namespace Mazegame.Entity
{
    public class Dice
    {
        private int faces;
        private static readonly Random generator = new Random();

        public Dice(int faces)
        {
            this.faces = faces;
        }

        public int Roll()
        {
            return generator.Next(faces) + 1;
        }

    } //end Dice
} //end namespace Entity