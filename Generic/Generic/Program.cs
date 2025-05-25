using System;
using System.Collections.Generic;
using static System.Console;

public delegate void PropertyEventHandler(object sender, PropertyEventArgs e);

// Класс аргументов события, содержит имя измененного свойства
public class PropertyEventArgs : EventArgs
{
    public string PropertyName { get; }

    public PropertyEventArgs(string propertyName)
    {
        PropertyName = propertyName;
    }
}

// Интерфейс уведомления об изменении свойства
public interface IPropertyChanged
{
    event PropertyEventHandler PropertyChanged;
}

// Класс, реализующий интерфейс IPropertyChanged
public class Person : IPropertyChanged
{
    public event PropertyEventHandler PropertyChanged;

    private string name;
    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    private int age;
    public int Age
    {
        get => age;
        set
        {
            if (age != value)
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
    }

    // Метод для вызова события при изменении свойства
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyEventArgs(propertyName));
    }
}

class Program
{
    static void Main()
    {
        /*// Исходный текст
        string text = "Вот дом, Который построил Джек, А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. А это веселая птица-синица, Которая часто ворует пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

        char[] separators = new char[] { ' ', '.', ',', '-', '!', '?', ':', ';', '—', '\n', '\r' };
        string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

        // Подсчет слов
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }

        List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(wordCount);

        for (int i = 0; i < sortedList.Count - 1; i++)
        {
            for (int j = i + 1; j < sortedList.Count; j++)
            {
                if (sortedList[j].Value > sortedList[i].Value)
                {
                    var temp = sortedList[i];
                    sortedList[i] = sortedList[j];
                    sortedList[j] = temp;
                }
            }
        }

        // Вывод таблицы с номерами
        WriteLine("{0,-5} | {1,-20} | {2,5}", "№", "Слово", "Кол-во");
        WriteLine(new string('-', 40));

        int index = 1;
        foreach (var item in sortedList)
        {
            WriteLine("{0,-5} | {1,-20} | {2,5}", index++, item.Key, item.Value);
        }

        // Общие итоги
        int totalWords = words.Length;
        int uniqueWords = wordCount.Count;

        WriteLine();
        WriteLine($"Общее количество слов: {totalWords}");
        WriteLine($"Количество уникальных слов: {uniqueWords}");*/

        //zadanie 2

        Person person = new Person();

        person.PropertyChanged += (sender, e) =>
        {
            WriteLine($"Свойство '{e.PropertyName}' было изменено.");
        };

        WriteLine($"До изменения: Name = {person.Name ?? "null"}, Age = {person.Age}");

        person.Name = "Иван";
        person.Age = 30;

        WriteLine($"После изменения: Name = {person.Name}, Age = {person.Age}");

        WriteLine($"До изменения: Name = {person.Name}, Age = {person.Age}");
        person.Name = "Петр";
        person.Age = 35;
        WriteLine($"После изменения: Name = {person.Name}, Age = {person.Age}");

        WriteLine($"До попытки повторного присвоения: Name = {person.Name}");
        person.Name = "Петр";
    }
}