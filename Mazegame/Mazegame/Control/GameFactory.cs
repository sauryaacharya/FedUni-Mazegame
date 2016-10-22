using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Mazegame.Boundary;
using System.Reflection;

namespace Mazegame.Control
{
    public class GameFactory
    {
        Dictionary<String, String> config = new Dictionary<String, String>();
        private IMazeClient theClient;
        private IMazeData theData;
        private static GameFactory instance;

        private GameFactory()
        {
            ReadConfigFile();
            theClient = (IMazeClient) DynamicLoad(config["ui_assembly"], config["ui"]);
            theData = (IMazeData) DynamicLoad(config["data_assembly"], config["data"]);

        }

        public IMazeClient getTheClient()
        {
            return theClient;
        }

        public void setTheClient(IMazeClient theClient)
        {
            this.theClient = theClient;
        }

        public IMazeData getTheData()
        {
            return theData;
        }

        public void setTheData(IMazeData theData)
        {
            this.theData = theData;
        }

        private void ReadConfigFile()
        {
            StreamReader reader = new StreamReader("config.txt");
            while(!reader.EndOfStream)
            {
            String[] items = reader.ReadLine().Split('=');
            config.Add(items[0], items[1]);

            }
            reader.Close();
        }

        private Object DynamicLoad(String assemblyName, String className)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyName);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    // doing it this way means that you don't have
                    // to specify the full namespace and class (just the class)
                    if (type.FullName.EndsWith("." + className))
                    {
                        return Activator.CreateInstance(type);
                    }
                }
            }
            throw (new Exception("could not instantiate class"));

        }

        public static GameFactory GetInstance()
        {
            if (instance == null)
                instance = new GameFactory();
            return instance;
        }



    }
}
