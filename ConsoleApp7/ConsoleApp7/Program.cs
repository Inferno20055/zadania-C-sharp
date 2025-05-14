using System;
using System.Collections;
using System.Data;
using System.Globalization;
//на это можете не обращать внимание это былоподключенно во время пары
class Program
{
    //zadanie 1
    /*static long GetRange(int start,int end) {
        long product = 1;
        for (int i = start; i <= end; i++)
        {
            product *= i;
        }
        return product;
    }
    static void Main(string[] args) {
        int start = 1;
        int end = 5;
        Console.WriteLine($"Произведение чисел от {start} до {end} = {GetRange(start,end)}");
    }*/
    //zadanie 2
    /*static bool IsFibonacciNumber(int num)
    {
        int test1 = 5 * num * num + 4;
        int test2 = 5 * num * num - 4;
        return IsPerfectSquare(test1) || IsPerfectSquare(test2);
    }

    static bool IsPerfectSquare(int x)
    {
        int s = (int)Math.Sqrt(x);
        return s * s == x;
    }

    static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;

        int sqrt = (int)Math.Sqrt(num);
        for (int i = 3; i <= sqrt; i += 2)
            if (num % i == 0) return false;

        return true;
    }
    static void Main(string[] args) {
        int number = 21;
        if (IsFibonacciNumber(number))
        {
            Console.WriteLine($"Число {number} — число Фибоначчи.");
            Console.WriteLine(IsPrime(number) ? "Результат: true" : "Результат: false");
        }
        else
        {
            Console.WriteLine($"Число {number} не является числом Фибоначчи.");
            Console.WriteLine("Результат: false");
        }
    }*/

    //zadanie 3
    /*static void SortArray(int[] arr, int order)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                bool shouldSwap = false;

                if (order == 1 && arr[j] > arr[j + 1]) // по возрастанию
                {
                    shouldSwap = true;
                }
                else if (order == 2 && arr[j] < arr[j + 1]) // по убыванию
                {
                    shouldSwap = true;
                }

                if (shouldSwap)
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
        static void Main(string[] args)
    {
        int[] array = { 5, 2, 9, 1, 5, 6 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", array));

        Console.WriteLine("Выберите порядок сортировки: 1 - по возрастанию, 2 - по убыванию");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Некорректный ввод. По умолчанию выбран порядок по возрастанию.");
            choice = 1;
        }

        SortArray(array, choice);
        Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
    }*/

    //zadanie 4


    /*public class City
    {
        public string cityName { get; set; }
        public string countryName { get; set; }
        public int residentsNumber { get; set; }
        public string cityTelephoneCode { get; set; }

        public City(string cityN, string countryNam, int residentsNum, string telefonnyKod)
        {
            cityName = cityN;
            countryName = countryNam;
            residentsNumber = residentsNum;
            cityTelephoneCode = telefonnyKod;
        }

        public override string ToString()
        {
            return $"Город: {cityName}\nСтрана: {countryName}\nЖители: {residentsNumber}\nТелефонный код: {cityTelephoneCode}";
        }
    }
    static void Main(string[] args) {
        Console.WriteLine("Введите название города:");
        string cityName=Console.ReadLine();
        Console.WriteLine("Введите название страны:");
        string countryName=Console.ReadLine();

        int residentsNumber;

        while (true) {
            Console.WriteLine("Введите количество жителей:");
            if (int.TryParse(Console.ReadLine(), out residentsNumber))
            {
                break;
            }
            else {
                Console.WriteLine("Пожалуства ввидите коректное число!");
                    }
        }
        Console.WriteLine("Введите телефонный код города:");
        string cityTelephoneCode=Console.ReadLine();

        City city = new City(cityName, countryName, residentsNumber, cityTelephoneCode);

        Console.WriteLine($"\nИнформация о городе {cityName}");
        Console.WriteLine(city);
    }*/

    //задание 5

    /*public class Sotrudnik
    {
        public string Fio { get; set; }
        public DateTime dateofBirth { get; set; }
        public string ContactPhone { get; set; }
        public string WorkinGemail { get; set; }
        public string post { get; set; }
        public string DescriptionOfResponsibilities { get; set; }

        public void VvodDannykh()
        {
            Console.WriteLine("Введите ФИО:");
            Fio = Console.ReadLine();

            Console.WriteLine("Введите дату рождения (в формате дд.мм.гггг):");
            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    dateofBirth = date;
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный формат даты. Попробуйте снова (дд.мм.гггг):");
                }
            }

            Console.WriteLine("Введите контактный телефон:");
            ContactPhone = Console.ReadLine();

            Console.WriteLine("Введите рабочий email:");
            WorkinGemail = Console.ReadLine();

            Console.WriteLine("Введите должность:");
            post = Console.ReadLine();

            Console.WriteLine("Опишите служебные обязанности:");
            DescriptionOfResponsibilities = Console.ReadLine();
        }

        public void VyvodDannykh()
        {
            Console.WriteLine($"ФИО: {Fio}");
            Console.WriteLine($"Дата рождения: {dateofBirth:dd.MM.yyyy}");
            Console.WriteLine($"Контактный телефон: {ContactPhone}");
            Console.WriteLine($"Рабочий email: {WorkinGemail}");
            Console.WriteLine($"Должность: {post}");
            Console.WriteLine($"Обязанности: {DescriptionOfResponsibilities}");
        }

        static void Main()
        {
            Sotrudnik sotrudnik = new Sotrudnik();
            sotrudnik.VvodDannykh();
            sotrudnik.VyvodDannykh();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }


    }*/
    /*public class Plane
    {
        public string title { get; set; }
        
        public string ManufacturersName { get; set; }
        public string YearOfRelease { get; set; }
        public string Aircrafttype { get; set; }

        public void VvodDannykh()
        {
            Console.WriteLine("Введите название самолёта:");
            title = Console.ReadLine();

            Console.WriteLine("Введите название производителя:");
            ManufacturersName = Console.ReadLine();

            Console.WriteLine("Введите год выпуска:");
            YearOfRelease = Console.ReadLine();

            Console.WriteLine("Введите тип самолёта:");
            Aircrafttype = Console.ReadLine();

           
        }

        public void VyvodDannykh()
        {
            Console.WriteLine($"Название самолёта: {title}");
     
            Console.WriteLine($"Название производителя: {ManufacturersName}");
            Console.WriteLine($"Год выпуска: {YearOfRelease}");
            Console.WriteLine($"Тип самолёта: {Aircrafttype}");
        }

        static void Main()
        {
            Plane plane = new Plane();
            plane.VvodDannykh();
            plane.VyvodDannykh();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }


    }*/

    //zadanie 7
    class Matrix
    {
        private int[,] data;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            data = new int[rows, cols];
        }

        public void Input()
        {
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    data[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Output()
        {
            Console.WriteLine("Матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{data[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public int GetMax()
        {
            int max = data[0, 0];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (data[i, j] > max)
                        max = data[i, j];
            return max;
        }

        public int GetMin()
        {
            int min = data[0, 0];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (data[i, j] < min)
                        min = data[i, j];
            return min;
        }
    }
    static void Main()
    {
        Matrix matrix = new Matrix(3, 3);
        matrix.Input();
        matrix.Output();
        Console.WriteLine($"Максимальный элемент: {matrix.GetMax()}");
        Console.WriteLine($"Минимальный элемент: {matrix.GetMin()}");
    }
}
