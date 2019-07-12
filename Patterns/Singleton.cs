using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{

    //паттерн, который гарантирует, что для определенного класса будет создан только один объект,
    //а также предоставит к этому объекту точку доступа.

    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }




    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }
    class OS
    {
        private static OS instance;

        public string Name { get; private set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance == null)
                instance = new OS(name);
            return instance;
        }
    }


    class OSLOCK
    {
        private static OSLOCK instance;

        public string Name { get; private set; }
        private static object syncRoot = new Object();

        protected OSLOCK(string name)
        {
            this.Name = name;
        }

        public static OSLOCK getInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OSLOCK(name);
                }
            }
            return instance;
        }
    }

}
