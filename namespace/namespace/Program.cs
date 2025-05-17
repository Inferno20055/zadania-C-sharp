using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using MorseCodeTranslator;

class Game
{
    char[] board = new char[9];
    char human = 'X';
    char computer = 'O';
    Random rand = new Random();
    bool humanTurn;
    bool vsComputer;

    public Game(bool vsComputer)
    {
        this.vsComputer = vsComputer;
    }

    public void Start()
    {
        InitializeBoard();

        if (vsComputer)
        {
            humanTurn = rand.Next(2) == 0;
            WriteLine(humanTurn ? "Вы ходите первым." : "Первым ходит компьютер.");
        }
        else
        {
            // В игре с двумя людьми оба игрока используют одинаковый код, только меняется имя игрока.
            // Можно оставить так, чтобы первый ход делал первый игрок.
            humanTurn = true; 
            WriteLine("Игра с другим человеком. Первый ход за первым игроком (X).");
        }

        while (true)
        {
            PrintBoard();

            if (vsComputer)
            {
                if (humanTurn)
                    HumanMove();
                else
                    ComputerMove();
            }
            else
            {
                HumanMove(); 
            }

            if (CheckWin(human))
            {
                PrintBoard();
                WriteLine(vsComputer ? "Поздравляем! Вы победили!" : "Первый игрок победил!");
                break;
            }
            if (vsComputer && CheckWin(computer))
            {
                PrintBoard();
                WriteLine("Компьютер победил!");
                break;
            }
            if (IsDraw())
            {
                PrintBoard();
                WriteLine("Ничья!");
                break;
            }

            humanTurn = !humanTurn;
        }
    }

    void InitializeBoard()
    {
        for (int i = 0; i < 9; i++)
            board[i] = ' ';
    }

    void PrintBoard()
    {
        WriteLine();
        for (int i = 0; i < 9; i += 3)
        {
            WriteLine($" {board[i]} | {board[i + 1]} | {board[i + 2]} ");
            if (i < 6)
                WriteLine("---+---+---");
        }
        WriteLine();
    }

    void HumanMove()
    {
        int move;
        while (true)
        {
            if (vsComputer)
                Write($"Ваш ход ({human}). Введите номер клетки (1-9): ");
            else
                Write($"Ход игрока {(humanTurn ? "X" : "O")}. Введите номер клетки (1-9): ");

            if (int.TryParse(ReadLine(), out move) && move >= 1 && move <= 9 && board[move - 1] == ' ')
            {
                board[move - 1] = humanTurn ? 'X' : 'O';
                break;
            }
            WriteLine("Некорректный ввод или клетка занята. Попробуйте снова.");
        }
    }

    void ComputerMove()
    {
        int[] freeCells = ArrayExtensions.FindAllIndices(board, c => c == ' ');
        int index = freeCells[rand.Next(freeCells.Length)];
        board[index] = computer;
        WriteLine($"Компьютер поставил в клетку {index + 1}.");
    }

    bool CheckWin(char player)
    {
        int[][] wins =
        {
                new[] {0,1,2}, new[] {3,4,5}, new[] {6,7,8},
                new[] {0,3,6}, new[] {1,4,7}, new[] {2,5,8},
                new[] {0,4,8}, new[] {2,4,6}
            };

        foreach (var line in wins)
            if (board[line[0]] == player && board[line[1]] == player && board[line[2]] == player)
                return true;

        return false;
    }

    bool IsDraw()
    {
        return Array.IndexOf(board, ' ') == -1;
    }
}

static class ArrayExtensions
{
    public static int[] FindAllIndices<T>(T[] array, Func<T, bool> predicate)
    {
        var list = new System.Collections.Generic.List<int>();
        for (int i = 0; i < array.Length; i++)
            if (predicate(array[i]))
                list.Add(i);
        return list.ToArray();
    }
}
namespace MorseCodeTranslator
{
    public static class Translator
    {
        private static readonly Dictionary<char, string> MorseMap = new Dictionary<char, string>()
        {
            {'A', ".-"},    {'B', "-..."},  {'C', "-.-."},  {'D', "-.."},
            {'E', "."},     {'F', "..-."},  {'G', "--."},   {'H', "...."},
            {'I', ".."},    {'J', ".---"},  {'K', "-.-"},   {'L', ".-.."},
            {'M', "--"},    {'N', "-."},    {'O', "---"},   {'P', ".--."},
            {'Q', "--.-"},  {'R', ".-."},   {'S', "..."},   {'T', "-"},
            {'U', "..-"},   {'V', "...-"},  {'W', ".--"},   {'X', "-..-"},
            {'Y', "-.--"},  {'Z', "--.."},
            {'0', "-----"}, {'1', ".----"},{'2', "..---"},{'3', "...--"},
            {'4', "....-"},{'5',"....."},{'6'," -...."},{'7'," --..."},
            {'8',"---.."},{'9',"----."},
            {'.',".-.-.-"},{',' ,"--..--"},{'?',"..--.."},
            { '!', "-.-.--" }, { '-', "-....-" }, { '/', "-..-." },
            { '@'," .--.-." }, { '(', "-.--." }, { ')'," -.--.-" },
            { ' ', "/" }
        };

        private static readonly Dictionary<string, char> ReverseMorseMap = new Dictionary<string, char>();

        static Translator()
        {
            foreach (var kvp in MorseMap)
            {
                
                if (!ReverseMorseMap.ContainsKey(kvp.Value))
                {
                    ReverseMorseMap[kvp.Value] = kvp.Key;
                }
            }
        }

        public static string ConvertToMorse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            var morseCode = new StringBuilder();

            foreach (char c in input.ToUpper())
            {
                if (MorseMap.TryGetValue(c, out string morse))
                {
                    morseCode.Append(morse + " ");
                }
                else
                {
                    morseCode.Append("? ");
                }
            }

            return morseCode.ToString().TrimEnd();
        }

        public static string ConvertFromMorse(string morseInput)
        {
            if (string.IsNullOrWhiteSpace(morseInput))
                return "";

            var result = new StringBuilder();

            string[] tokens = morseInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (token == "/")
                {
                    result.Append(' '); 
                }
                else if (ReverseMorseMap.TryGetValue(token, out char c))
                {
                    result.Append(c);
                }
                else
                {
                    result.Append('?'); 
                }
            }

            return result.ToString();
        }
    }
}
namespace TicTacToeGame
    //задание 2

{
    class Program
    {
        static void Main()
        {
            /*WriteLine("Выберите режим игры:");
            WriteLine("1 - Игра против компьютера");
            WriteLine("2 - Игра с другим человеком");
            Write("Введите 1 или 2: ");
            string choice = ReadLine();

            bool vsComputer = choice == "1";

            var game = new Game(vsComputer);
            game.Start();

            WriteLine("Нажмите любую клавишу для выхода...");
            ReadKey();*/
            //
            WriteLine("Выберите режим:\n1 - Перевод текста в азбуку Морзе\n2 - Перевод из азбуки Морзе в текст");
            var mode = ReadLine();

            if (mode == "1")
            {
                WriteLine("Введите текст для перевода в азбуку Морзе:");
                string inputText = ReadLine();
                string morseResult = Translator.ConvertToMorse(inputText);
                WriteLine("\nТекст в азбуке Морзе:");
                WriteLine(morseResult);
            }
            else if (mode == "2")
            {
                WriteLine("Введите код Морзе для перевода в текст (разделяйте символы пробелами, слова — '/'): ");
                string morseInput = ReadLine();
                string textResult = Translator.ConvertFromMorse(morseInput);
                WriteLine("\nПереведённый текст:");
                WriteLine(textResult);
            }
            else
            {
                WriteLine("Некорректный выбор режима.");
            }



        }
    }

    
}