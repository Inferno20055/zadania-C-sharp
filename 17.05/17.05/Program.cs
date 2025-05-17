//zadanie 1

using System;
using static System.Console;
class Program
{
    static void DrawSquare(int size, char symbol)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Write(symbol);
            }
            WriteLine();
        }
    }
    //zadanie 2
    static bool IsPalindrome(int number)
    {
        string strNumber = number.ToString();
        int len = strNumber.Length;

        for (int i = 0; i < len / 2; i++)
        {
            if (strNumber[i] != strNumber[len - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
    //zadanie 3
    static int[] FilterArray(int[] original, int[] filter)
    {
        HashSet<int> filterSet = new HashSet<int>(filter);

        List<int> resultList = new List<int>();

        foreach (int item in original)
        {
            if (!filterSet.Contains(item))
            {
                resultList.Add(item);
            }
        }

        return resultList.ToArray();
    }
    //zadanie 4
    class WebSite
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }

        public WebSite(string name, string url, string description, string ipAddress)
        {
            Name = name;
            Url = url;
            Description = description;
            IpAddress = ipAddress;
        }

        public void DisplayData()
        {
            WriteLine($"Название сайта: {Name}");
            WriteLine($"Путь к сайту: {Url}");
            WriteLine($"Описание сайта: {Description}");
            WriteLine($"IP-адрес сайта: {IpAddress}");
        }
    }
    //zadanie 5
    class Journal
    {
        public string Title { get; set; }
        public int YearFounded { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        public Journal(string title, int yearFounded, string description, string contactPhone, string contactEmail)
        {
            Title = title;
            YearFounded = yearFounded;
            Description = description;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
        }

        public void DisplayData()
        {
            WriteLine($"Название журнала: {Title}");
            WriteLine($"Год основания: {YearFounded}");
            WriteLine($"Описание: {Description}");
            WriteLine($"Контактный телефон: {ContactPhone}");
            WriteLine($"E-mail: {ContactEmail}");
        }
    }
    class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileDescription { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        public Shop(string name, string address, string profileDescription, string contactPhone, string contactEmail)
        {
            Name = name;
            Address = address;
            ProfileDescription = profileDescription;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
        }

        public void DisplayData()
        {
            WriteLine($"Название магазина: {Name}");
            WriteLine($"Адрес: {Address}");
            WriteLine($"Описание профиля: {ProfileDescription}");
            WriteLine($"Контактный телефон: {ContactPhone}");
            WriteLine($"E-mail: {ContactEmail}");
        }
    }
    static void Main()
    {
        //
        /*DrawSquare(5, '*');
        //
        WriteLine(IsPalindrome(1221)); // True
        WriteLine(IsPalindrome(3443)); // True
        WriteLine(IsPalindrome(7854)); // False*/
        //
        /*int[] originalArray = { 1, 2, 6, -1, 88, 7, 6 };
        int[] filterArray = { 6, 88, 7 };

        int[] result = FilterArray(originalArray, filterArray);

        WriteLine(string.Join(" ", result));*/
        //
        /*WebSite site = new WebSite(
            "Мой сайт",
            "https://example.com",
            "Это пример сайта",
            "192.168.1.1"
        );

        site.DisplayData();

        site.Name = "Это мой сайт";
        WriteLine($"\nОбновленное название сайта: {site.Name}");*/
        //
        /*var journal = new Journal(
            "Мой журнал",
            2020,
            "Это пример журнала",
            "+7-123-456-7890",
            "example@mail.com"
        );

        journal.DisplayData();

        journal.Title = "Обновленный журнал";
        WriteLine($"\nОбновленное название журнала: {journal.Title}");*/
        //
        var shop = new Shop(
            "Магазин А",
            "г. Москва, ул. Ленина, д. 1",
            "Продажа электроники",
            "+7-495-123-45-67",
            "info@shopa.ru"
        );

        shop.DisplayData();

        shop.Name = "Обновленный магазин";
        WriteLine($"\nОбновленное название магазина: {shop.Name}");
    }

   
}