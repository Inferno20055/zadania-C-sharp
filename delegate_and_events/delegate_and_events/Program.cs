using System;
using static System.Console;
namespace SimpleEventOnPropertyChange
{
    // Класс с событием изменения свойства
    class MyClass
    {
        private string _myProperty;

        // Объявление делегата для события
        public delegate void PropertyChangedHandler(string oldValue, string newValue);

        // Событие, вызываемое при изменении свойства
        public event PropertyChangedHandler OnPropertyChanged;

        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                if (_myProperty != value)
                {
                    string oldValue = _myProperty;
                    _myProperty = value;
                    OnPropertyChanged?.Invoke(oldValue, _myProperty);
                }
            }
        }
    }
    namespace DelegateNumberProcessing
    {
        class NumberProcessor
        {
            public int Square(int num)
            {
                return num * num;
            }

            public int Double(int num)
            {
                return num * 2;
            }
        }
        namespace ConsoleCalculatorWithEvents
        {
            // Класс, реализующий логику калькулятора
            class Calculator
            {
                private double _currentResult;
                private double _currentNumber;

                // Делегаты для событий операций
                public delegate void OperationEventHandler(double operand);
                public event OperationEventHandler OnAdd;
                public event OperationEventHandler OnSubtract;
                public event OperationEventHandler OnMultiply;
                public event OperationEventHandler OnDivide;

                // Конструктор
                public Calculator()
                {
                    _currentResult = 0;
                    _currentNumber = 0;
                }

                // Метод для установки начального числа
                public void SetInitialNumber(double number)
                {
                    _currentResult = number;
                    WriteLine($"Начальное значение: {_currentResult}");
                }

                // Методы для выполнения операций
                public void Add(double number)
                {
                    _currentResult += number;
                    WriteLine($"Промежуточный результат после +: {_currentResult}");
                    OnAdd?.Invoke(number);
                }

                public void Subtract(double number)
                {
                    _currentResult -= number;
                    WriteLine($"Промежуточный результат после -: {_currentResult}");
                    OnSubtract?.Invoke(number);
                }

                public void Multiply(double number)
                {
                    _currentResult *= number;
                    WriteLine($"Промежуточный результат после *: {_currentResult}");
                    OnMultiply?.Invoke(number);
                }

                public void Divide(double number)
                {
                    if (number != 0)
                    {
                        _currentResult /= number;
                        WriteLine($"Промежуточный результат после /: {_currentResult}");
                        OnDivide?.Invoke(number);
                    }
                    else
                    {
                        WriteLine("Ошибка: деление на ноль!");
                    }
                }


                public double GetResult()
                {
                    return _currentResult;
                }
            }
            class Program
            {
                static void PropertyChangedHandler(string oldVal, string newVal)
                {
                    Console.WriteLine($"Значение изменилось с '{oldVal}' на '{newVal}'.");
                }
                static void Main()
                {
                    /*NumberProcessor processor = new NumberProcessor();

                    Write("Введите целое число: ");
                    string input = ReadLine();

                    if (int.TryParse(input, out int number))
                    {
                        Func<int, int> squareDelegate = processor.Square;
                        Func<int, int> doubleDelegate = processor.Double;

                        int squaredResult = squareDelegate(number);
                        int doubledResult = doubleDelegate(number);

                        WriteLine($"Квадрат числа {number} равен: {squaredResult}");
                        WriteLine($"Удвоенное число {number} равно: {doubledResult}");
                    }
                    else
                    {
                        WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    }*/

                    //zadanie 2
                    /*MyClass obj = new MyClass();

                    obj.OnPropertyChanged += PropertyChangedHandler;

                    WriteLine("Введите новые значения для свойства. Для выхода введите 'exit'.");

                    while (true)
                    {
                        Write("Новое значение: ");
                        string input = ReadLine();

                        if (input.ToLower() == "exit")
                            break;

                        obj.MyProperty = input;
                    }*/

                    //zadanie 3
                    Calculator calc = new Calculator();

                    calc.OnAdd += (num) => WriteLine($"Обработчик события: добавление {num}");
                    calc.OnSubtract += (num) => WriteLine($"Обработчик события: вычитание {num}");
                    calc.OnMultiply += (num) => WriteLine($"Обработчик события: умножение на {num}");
                    calc.OnDivide += (num) => WriteLine($"Обработчик события: деление на {num}");

                    WriteLine("Простой консольный калькулятор");
                    Write("Введите начальное число: ");
                    if (!double.TryParse(ReadLine(), out double initial))
                    {
                        WriteLine("Некорректный ввод. Завершение программы.");
                        return;
                    }

                    calc.SetInitialNumber(initial);

                    while (true)
                    {
                        WriteLine("\nВведите операцию (+, -, *, /) или '=' для завершения:");
                        string op = ReadLine();

                        if (op == "=")
                        {
                            WriteLine($"Итоговый результат: {calc.GetResult()}");
                            break;
                        }

                        if (op != "+" && op != "-" && op != "*" && op != "/")
                        {
                            WriteLine("Некорректная операция. Попробуйте снова.");
                            continue;
                        }

                        Write("Введите число: ");
                        if (!double.TryParse(ReadLine(), out double num))
                        {
                            WriteLine("Некорректный ввод числа. Попробуйте снова.");
                            continue;
                        }

                        switch (op)
                        {
                            case "+":
                                calc.Add(num);
                                break;
                            case "-":
                                calc.Subtract(num);
                                break;
                            case "*":
                                calc.Multiply(num);
                                break;
                            case "/":
                                calc.Divide(num);
                                break;
                        }
                    }

                    WriteLine("Работа калькулятора завершена.");

                }
            }
        }
    }
}