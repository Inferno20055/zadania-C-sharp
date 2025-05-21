using System;
using System.IO;

namespace Day17FileApp
{
    class Program
    {
        static string filename = "Day17.txt";

       

        static void CreateFile()
        {
            if (File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} уже существует.");
            }
            else
            {
                File.Create(filename).Close();
                Console.WriteLine($"Файл {filename} успешно создан.");
            }
        }

        static void WriteDataToFile()
        {
            string personalData = "Иванов Иван Иванович";
            double[,] doubleArray = { { 1.1, 2.2, 3.3 }, { 4.4, 5.5, 6.6 } };
            int[,] intArray = { { 7, 8, 9 }, { 10, 11, 12 } };
            string dateStr = DateTime.Now.ToString("yyyy-MM-dd");

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(personalData);

                sw.WriteLine($"{doubleArray.GetLength(0)} {doubleArray.GetLength(1)}");
                for (int i = 0; i < doubleArray.GetLength(0); i++)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                        sw.Write($"{doubleArray[i, j]} ");
                    sw.WriteLine();
                }

                sw.WriteLine($"{intArray.GetLength(0)} {intArray.GetLength(1)}");
                for (int i = 0; i < intArray.GetLength(0); i++)
                {
                    for (int j = 0; j < intArray.GetLength(1); j++)
                        sw.Write($"{intArray[i, j]} ");
                    sw.WriteLine();
                }

                sw.WriteLine(dateStr);
            }
            Console.WriteLine("Данные успешно записаны в файл.");
        }

        static void ReadAndParseFile()
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} не найден.");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string personalData = sr.ReadLine();

                    var dimsDouble = sr.ReadLine().Split(' ');
                    int rowsDouble = int.Parse(dimsDouble[0]);
                    int colsDouble = int.Parse(dimsDouble[1]);
                    double[,] doubleArray = new double[rowsDouble, colsDouble];

                    for (int i = 0; i < rowsDouble; i++)
                    {
                        var nums = sr.ReadLine().Split(' ');
                        for (int j = 0; j < colsDouble; j++)
                            doubleArray[i, j] = double.Parse(nums[j]);
                    }

                    var dimsInt = sr.ReadLine().Split(' ');
                    int rowsInt = int.Parse(dimsInt[0]);
                    int colsInt = int.Parse(dimsInt[1]);
                    int[,] intArray = new int[rowsInt, colsInt];

                    for (int i = 0; i < rowsInt; i++)
                    {
                        var nums = sr.ReadLine().Split(' ');
                        for (int j = 0; j < colsInt; j++)
                            intArray[i, j] = int.Parse(nums[j]);
                    }

                    string dateStr = sr.ReadLine();

                    Console.WriteLine($"\nЛичные данные: {personalData}");

                    Console.WriteLine($"\nМассив дробных чисел ({rowsDouble}x{colsDouble}):");
                    for (int i = 0; i < rowsDouble; i++)
                    {
                        for (int j = 0; j < colsDouble; j++)
                            Console.Write($"{doubleArray[i, j]} ");
                        Console.WriteLine();
                    }

                    Console.WriteLine($"\nМассив целых чисел ({rowsInt}x{colsInt}):");
                    for (int i = 0; i < rowsInt; i++)
                    {
                        for (int j = 0; j < colsInt; j++)
                            Console.Write($"{intArray[i, j]} ");
                        Console.WriteLine();
                    }

                    Console.WriteLine($"\nДата из файла: {dateStr}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении или разборе файла: {ex.Message}");
            }
        }
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Создать файл");
                Console.WriteLine("2. Записать данные в файл");
                Console.WriteLine("3. Прочитать и разобрать файл");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите действие (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateFile(); break;
                    case "2": WriteDataToFile(); break;
                    case "3": ReadAndParseFile(); break;
                    case "4": return;
                    default: Console.WriteLine("Некорректный выбор."); break;
                }
            }
        }
    }

}