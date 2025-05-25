using System;
using System.IO;
using System.Text;//для обрадотки текста и строк
using static System.Console;
/*namespace Day17FileApp
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

}*/

//zadanie 2

class Program
{
    static void Main()
    {
        string inputFilePath = "input.cs";
        string outputFilePath = "output.txt";

        // Создаем пример исходного файла input.cs
        if (!File.Exists(inputFilePath))
        {
            string sampleCode = @"
        public class Example
        {
            public int myField;
            public void MyMethod()
                {
            public int innerVar = 5;
            Console.WriteLine(innerVar);
                }
            }
        ";
            File.WriteAllText(inputFilePath, sampleCode);
            WriteLine($"Создан файл {inputFilePath} с примером кода.");
        }

        string[] lines = File.ReadAllLines(inputFilePath);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            // 1. Заменяем все слова 'public' в объявлениях полей на 'private'
            line = ReplaceWord(line, "public", "private");

            // 2. Все слова длиннее 2 символов — в верхний регистр
            line = TransformLongWordsToUpper(line);

            // 3. Удаляем лишние пробелы и табуляции, оставляя только необходимые для разделения операторов
            line = NormalizeSpaces(line);

            lines[i] = line;
        }

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (var line in lines)
            {
                char[] chars = line.ToCharArray();
                Array.Reverse(chars);
                writer.WriteLine(new string(chars));
            }
        }

        WriteLine($"Обработка завершена. Результат записан в файл {outputFilePath}");
    }

    static string ReplaceWord(string text, string oldWord, string newWord)
    {
        int index = 0;
        while ((index = IndexOfWord(text, oldWord, index)) != -1)
        {
            text = text.Substring(0, index) + newWord + text.Substring(index + oldWord.Length);
            index += newWord.Length;
        }
        return text;
    }

    static int IndexOfWord(string text, string word, int startIndex)
    {
        int len = word.Length;
        for (int i = startIndex; i <= text.Length - len; i++)
        {
            if (IsWholeWord(text, i, word))
                return i;
        }
        return -1;
    }

    static bool IsWholeWord(string text, int index, string word)
    {
        if (index > 0 && Char.IsLetterOrDigit(text[index - 1]))
            return false;
        if (index + word.Length < text.Length && Char.IsLetterOrDigit(text[index + word.Length]))
            return false;

        for (int i = 0; i < word.Length; i++)
        {
            if (text[index + i] != word[i])
                return false;
        }
        return true;
    }

    // Метод для преобразования слов длиннее 2 символов в верхний регистр
    static string TransformLongWordsToUpper(string line)
    {
        char[] chars = line.ToCharArray();
        int startIdx = -1;

        for (int i = 0; i <= chars.Length; i++)
        {
            if (i < chars.Length && (Char.IsLetterOrDigit(chars[i]) || chars[i] == '_'))
            {
                if (startIdx == -1)
                    startIdx = i;
            }
            else
            {
                if (startIdx != -1)
                {
                    int endIdx = i - 1;
                    int length = endIdx - startIdx + 1;

                    if (length > 2)
                    {
                        for (int j = startIdx; j <= endIdx; j++)
                        {
                            chars[j] = Char.ToUpper(chars[j]);
                        }
                    }
                    startIdx = -1;
                }
            }
        }

        return new string(chars);
    }

    // Метод для нормализации пробелов и табуляций
    static string NormalizeSpaces(string line)
    {
        char[] chars = line.ToCharArray();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        bool prevIsSpaceOrTab = false;

        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];

            if (c == ' ' || c == '\t')
            {
                if (!prevIsSpaceOrTab)
                {
                    sb.Append(' ');
                    prevIsSpaceOrTab = true;
                }
            }
            else
            {
                sb.Append(c);
                prevIsSpaceOrTab = false;
            }
        }

        string result = sb.ToString();

        // Убираем пробелы перед знаками ; , { } и после них
        result = RemoveSpacesAroundSymbols(result, new char[] { ';', ',', '{', '}' });

        return result.Trim();
    }

    static string RemoveSpacesAroundSymbols(string input, char[] symbols)
    {
        foreach (var sym in symbols)
        {
            input = RemoveSpacesAroundSymbol(input, sym);
        }
        return input;
    }

    static string RemoveSpacesAroundSymbol(string input, char symbol)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == symbol)
            {
                while (sb.Length > 0 && sb[sb.Length - 1] == ' ')
                    sb.Remove(sb.Length - 1, 1);
                sb.Append(symbol);
                while (i + 1 < input.Length && input[i + 1] == ' ')
                    i++;
            }
            else
            {
                sb.Append(input[i]);
            }
        }
        return sb.ToString();
    }
}