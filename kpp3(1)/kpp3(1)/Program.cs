using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;

namespace kpp3_1_
{

    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray dynamicArray = new DynamicArray(10);
            dynamicArray.FillRandom();
            dynamicArray.PrintArray();

            dynamicArray.Shuffle();
            dynamicArray.PrintArray();

            string filePath = "dynamic_array.json";
            dynamicArray.SaveToJson(filePath);

            DynamicArray loadedDynamicArray = DynamicArray.LoadFromJson(filePath);
            loadedDynamicArray.PrintArray();

            Console.ReadLine();
        }
    }
}