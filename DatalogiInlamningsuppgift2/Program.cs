using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DatalogiInlamningsuppgift2.Utility;
using DatalogiInlamningsuppgift2.DataStructures;

namespace DatalogiInlamningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Core core = new Core();

            string[] testArray = { "Hej", "Peter", "Kalle" };
            double[] numArray = Utils.StringToValue(testArray);

            foreach (var item in numArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
