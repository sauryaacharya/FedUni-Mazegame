using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mazegame.Entity
{
    public class ExitCollection
    {
        private Hashtable exits;

        public ExitCollection()
        {
            exits = new Hashtable();
        }

        public Boolean AddExit(String exitLabel, Exit theExit)
        {
            if (exits.ContainsKey(exitLabel))
                return false;
            exits.Add(exitLabel, theExit);
            return true;
        }

        public Exit GetExit(String exitLabel)
        {
            return (Exit)exits[exitLabel];
        }
        public Exit GetRandomExit()
        {
            int count = this.exits.Keys.Count;

            Random r = new Random();
            int ran = r.Next(0, count);

            List<string> keyList = new List<string>();
            foreach (string label in this.exits.Keys)
            {
                keyList.Add(label);
            }
            return (Exit)exits[keyList[ran]];
        }

        public bool ContainsExit(String exitLabel)
        {
            return exits.Contains(exitLabel);
        }

        public String AvailableExits()
        {
            StringBuilder returnMsg = new StringBuilder();
            foreach (string label in this.exits.Keys)
            {
                returnMsg.Append("[" + label + "] ");
            }
            return returnMsg.ToString();
        }
    }
}