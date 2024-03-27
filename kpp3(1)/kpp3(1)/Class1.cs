using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace kpp3_1_
{
    class DynamicArray
    {
        [JsonProperty("array")]
        private int[] array;

        [JsonProperty("size")]
        private int size;

        public DynamicArray(int size)
        {
            this.size = size;
            array = new int[size];
        }

        // Метод для виведення масиву на екран
        public void PrintArray()
        {
            Console.WriteLine("Array elements:");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        // Метод для заповнення масиву випадковими числами
        public void FillRandom()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(100);
            }
        }

        // Метод для збереження об'єкта у JSON файл
        public void SaveToJson(string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Object saved to JSON file successfully.");
        }

        // Метод для завантаження об'єкта з JSON файлу
        public static DynamicArray LoadFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            DynamicArray dynamicArray = JsonConvert.DeserializeObject<DynamicArray>(jsonString);
            Console.WriteLine("Object loaded from JSON file successfully.");
            return dynamicArray;
        }
    }
}