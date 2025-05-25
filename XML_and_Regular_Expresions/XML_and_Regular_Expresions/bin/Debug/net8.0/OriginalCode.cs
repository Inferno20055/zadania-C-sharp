
using System;

namespace ExampleNamespace
{
    public class Person
    {
        public string Name;
        public int Age;
        public string Address;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class Car
    {
        public string Model;
        public int Year;

        public void ShowDetails()
        {
            Console.WriteLine($"Model: {Model}, Year: {Year}");
        }
    }
}
