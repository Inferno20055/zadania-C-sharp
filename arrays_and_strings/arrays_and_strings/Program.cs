class Program
{
    static void Main(string[] arg)
    {

        /*int[] numbers = { 1, 2, 3, 4, 5, 6, 1, 2, 3 };

        int evenNumber=0;
        int noEvenNumber=0;
        int uniqueNumber = 0;

        bool[] isUnique = new bool[numbers.Length];

        for (int i = 0; i < numbers.Length; i++) {
            if (numbers[i] % 2 == 0)
            {
                evenNumber++;
            }
            else
            {
                noEvenNumber++;
            }
            isUnique[i] = true;
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    isUnique[i] = false;
                    break ;
                }
            }
        }
        for (int i = 0; i < isUnique.Length; i++)
        {
            if (isUnique[i])
            {
                uniqueNumber++;
            }
        }
        Console.WriteLine($"Количество чётных элементов: {evenNumber}");
        Console.WriteLine($"Количество нечётных элементов: {noEvenNumber}");
        Console.WriteLine($"Количество уникальных элементов: {uniqueNumber}");*/

        //zadanie 2
        /*int[] numbers = { 1,2,3,4,5,6,7,8,9};

        Console.WriteLine("Введите число: ");
        string input = Console.ReadLine();

        int count = 0;

        if (int.TryParse(input,out int chislo))
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < chislo)
                {
                    count++;
                }

               
            }

            Console.WriteLine($"Количество значений в массиве меньше {chislo}: {count}");
        }
        else
        {
            Console.WriteLine("Ошибка: введено некорректное значение.");
        }*/

        //zadanie 3

        /*int[] numbers = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };

        Console.Write("Введите три числа через пробел: ");
        string input = Console.ReadLine();

        string[] parts = input.Split(' ');

        if (parts.Length != 3)
        {
            Console.WriteLine("Ошибка: необходимо ввести три числа.");
            return;
        }

        int first, second, third;

        try
        {
            first = Convert.ToInt32(parts[0]);
            second = Convert.ToInt32(parts[1]);
            third = Convert.ToInt32(parts[2]);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введены некорректные значения.");
            return;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: одно из введённых чисел слишком велико или слишком мало.");
            return;
        }

        int count = 0;
        for (int i = 0; i <= numbers.Length - 3; i++)
        {
            if (numbers[i] == first && numbers[i + 1] == second && numbers[i + 2] == third)
            {
                count++;
            }
        }

        Console.WriteLine($"Количество повторений последовательности {first}, {second}, {third}: {count}");*/

        //zadane 4

        /*int[] array1 = { 1, 2, 3, 4, 5, 6 };
        int[] array2 = { 4, 5, 6, 7, 8, 9 };

        HashSet<int> commonElements = new HashSet<int>();

        foreach (int num in array1)
        {
            if (Array.Exists(array2, element => element == num))
            {
                commonElements.Add(num);
            }
        }

        int[] resultArray = new int[commonElements.Count];
        commonElements.CopyTo(resultArray);

        Console.WriteLine("Общие элементы без повторений:");
        foreach (int num in resultArray)
        {
            Console.Write(num + " ");
        }*/

        //zadanie 5

        /*int[,] array = {
            { 3, 5, 1, 9 },
            { 8, 2, 7, 4 },
            { 6, 0, 5, 3 }
        };

        int minValue = int.MaxValue;
        int maxValue = int.MinValue;

        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for (int j = 0; j < array.GetLength(1); j++) 
            {
                if (array[i, j] < minValue)
                {
                    minValue = array[i, j];
                }

                if (array[i, j] > maxValue)
                {
                    maxValue = array[i, j];
                }
            }
        }

        Console.WriteLine($"Минимальное значение: {minValue}");
        Console.WriteLine($"Максимальное значение: {maxValue}");*/

        //zadanie 6

        /*Console.WriteLine("Введите предложение:");
        string input = Console.ReadLine();

        int wordCount = CountWords(input);

        Console.WriteLine($"Количество слов в предложении: {wordCount}");*/

        //zadanie 7

        /*Console.WriteLine("Введите предложение:");
        string input = Console.ReadLine();

        string result = ReverseWords(input);

        Console.WriteLine($"После переворота: {result}");*/

        //zadanie 8

        /*Console.WriteLine("Введите предложение:");
        string input = Console.ReadLine();

        int vowelCount = CountVowels(input);

        Console.WriteLine($"Количество гласных букв в предложении: {vowelCount}");*/

        //zadanie 9

        Console.WriteLine("Введите исходную строку:");
        string inputString = Console.ReadLine();

        Console.WriteLine("Введите подстроку для поиска:");
        string searchString = Console.ReadLine();

        int count = CountOccurrences(inputString, searchString);

        Console.WriteLine($"Результат поиска: {count}");



    }

    static int CountOccurrences(string input, string search)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(search))
            return 0;

        int count = 0;
        int index = 0;

        while ((index = input.IndexOf(search, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += search.Length; 
        }

        return count;
    }

    /*static int CountVowels(string sentence)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y',
                          'A', 'E', 'I', 'O', 'U', 'Y' }; 

        int count = 0;

        foreach (char c in sentence)
        {
            if (Array.Exists(vowels, element => element == c))
            {
                count++; 
            }
        }

        return count;
    }*/


    /*static string ReverseWords(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return string.Empty;

        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            char[] charArray = words[i].ToCharArray(); 
            Array.Reverse(charArray); 
            words[i] = new string(charArray);
        }

        return string.Join(" ", words);
    }*/

}

    /*static int CountWords(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
        {
            return 0;
        }

        int count = 0;
        bool inWord = false;

        foreach (char c in sentence)
        {

            if (char.IsWhiteSpace(c))
            {
                if (inWord) 
                {
                    inWord = false; 
                }
            }
            else
            {
                if (!inWord) 
                {
                    inWord = true; 
                    count++; 
                }
            }
        }

        return count;
    }*/

    

