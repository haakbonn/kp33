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

        [JsonConstructor]
        public DynamicArray()
        {
        }

        public DynamicArray(int size)
        {
            this.size = size;
            array = new int[size];
        }

        // Конструктор для виділення пам'яті під задану кількість елементів
        public DynamicArray(int[] elements)
        {
            size = elements.Length;
            array = new int[size];
            Array.Copy(elements, array, size);
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

        // Метод для перестановки елементів у випадковому порядку
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = size - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public void SaveToJson(string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Object saved to JSON file successfully.");
        }

        public static DynamicArray LoadFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            DynamicArray dynamicArray = JsonConvert.DeserializeObject<DynamicArray>(jsonString);
            Console.WriteLine("Object loaded from JSON file successfully.");
            return dynamicArray;
        }
    }
}