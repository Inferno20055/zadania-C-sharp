using System;
class programm {
    /*static void Main()
    {
        int[,] array = new int[5, 5];
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j=0;j<5;j++) {
                array[i, j] = random.Next(-100, 100);
            }
        }
        Console.WriteLine("Выведенный массив: ");
        for (int i = 0; i < 5; i++)
        {
            for (int j=0;j<5;j++) {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
        
        int minValue = int.MaxValue;
        int maxValue = int.MinValue;
        (int minRow, int minCol) = (-1, -1);
        (int maxRow, int maxCol) = (-1, -1);

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (array[i, j] < minValue)
                {
                    minValue = array[i, j];
                    minRow = i;
                    minCol = j;
                }
                if (array[i, j] > maxValue)
                {
                    maxValue = array[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }

        int startRow = Math.Min(minRow, maxRow);
        int endRow = Math.Max(minRow, maxRow);
        int startCol = Math.Min(minCol, maxCol);
        int endCol = Math.Max(minCol, maxCol);

        int sum = 0;

        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                if (!(i == minRow && j == minCol) && !(i == maxRow && j == maxCol)) // Исключаем мин и макс элементы
                {
                    sum += array[i, j];
                }
            }
        }

        Console.WriteLine($"Минимальный элемент: {minValue} на позиции ({minRow}, {minCol})");
        Console.WriteLine($"Максимальный элемент: {maxValue} на позиции ({maxRow}, {maxCol})");
        Console.WriteLine($"Сумма элементов между минимальным и максимальным: {sum}");
    }

    private static int GetRandomNumber(int minValue, int maxValue)
    {
        Random random = new Random();
        return random.Next(minValue, maxValue);
    }*/
    static void Main() {
        int[] A = new int[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        Console.WriteLine("Введите 5 целых чисел для массива A:");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write($"A[{i}] = ");
            A[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < B.GetLength(0); i++)
            for (int j = 0; j < B.GetLength(1); j++)
                B[i, j] = Math.Round(rand.NextDouble() * 10, 2);

        Console.WriteLine("\nМассив A: " + string.Join(" ", A));

        Console.WriteLine("\nМассив B:");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
                Console.Write(B[i, j].ToString("F2") + " ");
            Console.WriteLine();
        }

        double maxElement = A[0], minElement = A[0], sumAll = 0, productAll = 1;
        int sumEvenA = 0;
        double sumOddColumnsB = 0;

        foreach (var item in A)
        {
            sumAll += item;
            productAll *= item;
            if (item % 2 == 0) sumEvenA += item;
            if (item > maxElement) maxElement = item;
            if (item < minElement) minElement = item;
        }

        for (int i = 0; i < B.GetLength(0); i++)
            for (int j = 0; j < B.GetLength(1); j++)
            {
                sumAll += B[i, j];
                productAll *= B[i, j];
                if (j % 2 == 1) sumOddColumnsB += B[i, j]; 
                if (B[i, j] > maxElement) maxElement = B[i, j];
                if (B[i, j] < minElement) minElement = B[i, j];
            }


        Console.WriteLine($"\nОбщий максимальный элемент: {maxElement}");
        Console.WriteLine($"Общий минимальный элемент: {minElement}");
        Console.WriteLine($"Общая сумма всех элементов: {sumAll}");
        Console.WriteLine($"Общее произведение всех элементов: {productAll}");
        Console.WriteLine($"Сумма четных элементов массива A: {sumEvenA}");
        Console.WriteLine($"Сумма нечетных столбцов массива B: {sumOddColumnsB:F2}");
    }
}

