using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Singleton
    {
        public Uge TempUge { get; set; }

        private static Singleton _instance = new Singleton();
        public Singleton()
        {
            
        }

        public static Singleton GetInstance()
        {
            return _instance;
        }

        public void nyUge()
        {
                Uge ugeX = new Uge();
        }
    }
}
