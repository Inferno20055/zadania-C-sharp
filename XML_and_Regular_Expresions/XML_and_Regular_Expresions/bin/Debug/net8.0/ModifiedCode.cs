
using System;

namespace ExampleNamespace
{
    public class Person
    {
        private string name;
        private int age;
        private string address;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class Car
    {
        private string model;
        private int year;

        public void ShowDetails()
        {
            Console.WriteLine($"Model: {Model}, Year: {Year}");
        }
    }
}
