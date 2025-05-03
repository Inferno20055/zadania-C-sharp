using System;

class Program
{
    /*static void Main()
    {
        Console.Write("Введите строку для шифрования: ");
        string input = Console.ReadLine();

        Console.Write("Введите сдвиг (положительное число для шифрования, отрицательное для расшифрования): ");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = Encrypt(input, shift);
        Console.WriteLine($"Зашифрованный текст: {encrypted}");

        string decrypted = Encrypt(encrypted, -shift);
        Console.WriteLine($"Расшифрованный текст: {decrypted}");
    }

    static string Encrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)((((letter + shift) - offset + 26) % 26) + offset);
            }

            buffer[i] = letter;
        }

        return new string(buffer);
    }*/
    //zadanie 4
    /*static int[,] MultiplyByNumber(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix[i, j] * number;

        return result;
    }

    static int[,] AddMatrices(int[,] a, int[,] b)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);

        if (rows != b.GetLength(0) || cols != b.GetLength(1))
            return null; 

        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }

    static int[,] MultiplyMatrices(int[,] a, int[,] b)
    {
        int rowsA = a.GetLength(0);
        int colsA = a.GetLength(1);
        int rowsB = b.GetLength(0);
        int colsB = b.GetLength(1);

        if (colsA != rowsB)
            return null; 

        int[,] result = new int[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
            for (int j = 0; j < colsB; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < colsA; k++)
                    result[i, j] += a[i, k] * b[k, j];
            }

        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        if (matrix == null)
        {
            Console.WriteLine("Ошибка: матрицы имеют несовместимые размеры.");
            return;
        }

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }

    static void Main()
    {
        // Пример матриц
        int[,] matrixA =
        {
            {1, 2},
            {3, 4}
        };

        int[,] matrixB =
        {
            {5, 6},
            {7, 8}
        };

        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);

        Console.WriteLine("\nМатрица B:");
        PrintMatrix(matrixB);

        Console.WriteLine("\nУмножение матрицы A на число 3:");
        var multipliedByNumber = MultiplyByNumber(matrixA, 3);
        PrintMatrix(multipliedByNumber);

        Console.WriteLine("\nСложение матриц A и B:");
        var sumMatrices = AddMatrices(matrixA, matrixB);

        PrintMatrix(sumMatrices);

        Console.WriteLine("\nПроизведение матриц A и B:");
        var productMatrices = MultiplyMatrices(matrixA, matrixB);
        PrintMatrix(productMatrices);
    }*/
    //zadanie 5
    /*static void Main()
    {
        Console.WriteLine("Введите арифметическое выражение (например, 3 + 5 - 2):");
        string input = Console.ReadLine();

        try
        {
            double result = EvaluateExpression(input);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static double EvaluateExpression(string expression)
    {
        expression = expression.Replace(" ", "");

        double result = 0;
        char operation = '+';

        for (int i = 0; i < expression.Length; i++)
        {
            char currentChar = expression[i];

            if (char.IsDigit(currentChar) || currentChar == '.')
            {
                string numberString = "";

                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    numberString += expression[i];
                    i++;
                }

                double number = double.Parse(numberString);

                if (operation == '+')
                    result += number;
                else if (operation == '-')
                    result -= number;

                i--;
            }
            else if (currentChar == '+' || currentChar == '-')
            {
                operation = currentChar;
            }
            else
            {
                throw new ArgumentException("Недопустимый символ в выражении.");
            }
        }

        return result;
    }*/
    //zadanie 6
    /*static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        string result = CapitalizeFirstLetterOfSentences(input);
        Console.WriteLine("Результат:");
        Console.WriteLine(result);
    }

    static string CapitalizeFirstLetterOfSentences(string text)
    {
        char[] sentenceEndings = { '.', '!', '?' };
        string[] sentences = text.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = sentences[i].Trim();

            if (sentences[i].Length > 0)
            {
                sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
            }
        }

        string result = string.Join(". ", sentences).Trim();

        for (int i = 0; i < text.Length; i++)
        {
            if (sentenceEndings.Contains(text[i]))
            {
                result += text[i];
            }
        }

        return result;
    }*/
    //zadanie 7
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string inputText = Console.ReadLine();

        Console.WriteLine("Введите недопустимое слово:");
        string forbiddenWord = Console.ReadLine();

        (string modifiedText, int replacements) = ReplaceForbiddenWord(inputText, forbiddenWord);

        Console.WriteLine("Результат:");
        Console.WriteLine(modifiedText);
        Console.WriteLine($"Статистика: {replacements} замены слова '{forbiddenWord}'.");
    }

    static (string, int) ReplaceForbiddenWord(string text, string forbiddenWord)
    {
        string lowerText = text.ToLower();
        string lowerForbiddenWord = forbiddenWord.ToLower();

        int count = 0;

        string modifiedText = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length), StringComparison.OrdinalIgnoreCase);

        count += (lowerText.Length - lowerText.Replace(lowerForbiddenWord, "").Length) / lowerForbiddenWord.Length;

        return (modifiedText, count);
    }
}