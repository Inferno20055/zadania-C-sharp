using System;
using static System.Console;
class Money
{
    public int Amount { get; private set; } 
    public int Cents { get; private set; }  

    public Money(int amount = 0, int cents = 0)
    {
        SetValues(amount, cents);
    }

    public void SetValues(int amount, int cents)
    {
        if (amount < 0 || cents < 0)
        {
            WriteLine("Значения не могут быть отрицательными.");
            Amount = 0;
            Cents = 0;
            return;
        }

        Amount = amount + cents / 100;
        Cents = cents % 100;
    }

    public void Display()
    {
        WriteLine($"{Amount} {GetCurrencyName()} {Cents:D2}");
    }

    public string GetCurrencyName()
    {
        return ",единиц"; 
    }
}

// Класс Product для товара
class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    // Уменьшение цены на заданную сумму
    public void ReducePrice(Money amountToReduce)
    {
        int totalCentsCurrent = Price.Amount * 100 + Price.Cents;
        int totalCentsReduce = amountToReduce.Amount * 100 + amountToReduce.Cents;

        if (totalCentsReduce > totalCentsCurrent)
        {
                WriteLine("Невозможно уменьшить цену более чем она есть.");
            return;
        }

        int newTotalCents = totalCentsCurrent - totalCentsReduce;
        Price.SetValues(newTotalCents / 100, newTotalCents % 100);
    }

    public void Display()
    {
        WriteLine($"Товар: {Name}");
        Write("Цена: ");
        Price.Display();
    }
}
//задание 2
class Ustroystvo
{
    public string Name { get; }
    public string Characteristics { get; }

    public Ustroystvo(string name, string characteristics)
    {
        Name = name;
        Characteristics = characteristics;
    }

    public virtual void Show()
    {
        WriteLine($"Устройство: {Name}");
    }

    public virtual void Desc()
    {
        WriteLine($"Характеристики: {Characteristics}");
    }

    public virtual void Sound()
    {
        WriteLine($"{Name} издает звук.");
    }
}


class Chaynik : Ustroystvo
{
    public Chaynik(string name, string characteristics) : base(name, characteristics) { }
    public override void Sound() => WriteLine($"{Name} говорит: Буль-буль");
}

class Mikrovolnovka : Ustroystvo
{
    public Mikrovolnovka(string name, string characteristics) : base(name, characteristics) { }
    public override void Sound() => WriteLine($"{Name} издает звуковой сигнал");
}

class Avtomobil : Ustroystvo
{
    public Avtomobil(string name, string characteristics) : base(name, characteristics) { }
    public override void Sound() => WriteLine($"{Name} издает звук двигателя");
}

class Parohod : Ustroystvo
{
    public Parohod(string name, string characteristics) : base(name, characteristics) { }
    public override void Sound() => WriteLine($"{Name} говорит гудком");
}
//zadanie 3
class MuzykalnyInstrument
{
    public string Name { get; }
    public string Characteristics { get; }

    public MuzykalnyInstrument(string name, string characteristics)
    {
        Name = name;
        Characteristics = characteristics;
    }

    public virtual void Sound()
    {
        WriteLine($"{Name} издает звук.");
    }

    public virtual void Show()
    {
        WriteLine($"Инструмент: {Name}");
    }

    public virtual void Desc()
    {
        WriteLine($"Описание: {Characteristics}");
    }

    public virtual void History()
    {
        WriteLine($"История создания инструмента {Name} неизвестна или не указана.");
    }
}

// Производный класс "Скрипка"
class Skripka : MuzykalnyInstrument
{
    public Skripka(string name, string characteristics) : base(name, characteristics) { }

    public override void Sound()
    {
        WriteLine($"{Name} издает нежный скрипичный звук.");
    }

    public override void History()
    {
        WriteLine($"{Name} — один из старейших струнных инструментов, появившийся в Средние века.");
    }
}

// Производный класс "Тромбон"
class Trombon : MuzykalnyInstrument
{
    public Trombon(string name, string characteristics) : base(name, characteristics) { }

    public override void Sound()
    {
        WriteLine($"{Name} издает громкий медный звук.");
    }

    public override void History()
    {
        WriteLine($"{Name} был изобретен в 19 веке и широко используется в оркестрах и джазе.");
    }
}

// Производный класс "Укулеле"
class Ukulele : MuzykalnyInstrument
{
    public Ukulele(string name, string characteristics) : base(name, characteristics) { }

    public override void Sound()
    {
        WriteLine($"{Name} издает веселый гитарный звук.");
    }

    public override void History()
    {
        WriteLine($"{Name} — гавайский струнный инструмент, появившийся в 19 веке.");
    }
}

// Производный класс "Виолончель"
class Violoncelle : MuzykalnyInstrument
{
    public Violoncelle(string name, string characteristics) : base(name, characteristics) { }

    public override void Sound()
    {
        WriteLine($"{Name} издает глубокий бархатистый звук.");
    }

    public override void History()
    {
        WriteLine($"{Name} — инструмент с древней историей, используемый в классической музыке с XVI века.");
    }
}
//zadanie 4
abstract class Worker
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Worker(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void Print();
}

// Производный класс President
class President : Worker
{
    public string Company { get; set; }

    public President(string name, int age, string company) : base(name, age)
    {
        Company = company;
    }

    public override void Print()
    {
            WriteLine($"Президент: {Name}, Возраст: {Age}, Компания: {Company}");
    }
}

// Производный класс Security
class Security : Worker
{
    public string Department { get; set; }

    public Security(string name, int age, string department) : base(name, age)
    {
        Department = department;
    }

    public override void Print()
    {
        WriteLine($"Охранник: {Name}, Возраст: {Age}, Отдел: {Department}");
    }
}

// Производный класс Manager
class Manager : Worker
{
    public string Department { get; set; }

    public Manager(string name, int age, string department) : base(name, age)
    {
        Department = department;
    }

    public override void Print()
    {
        WriteLine($"Менеджер: {Name}, Возраст: {Age}, Отдел: {Department}");
    }
}

// Производный класс Engineer
class Engineer : Worker
{
    public string Specialty { get; set; }

    public Engineer(string name, int age, string specialty) : base(name, age)
    {
        Specialty = specialty;
    }

    public override void Print()
    {
        WriteLine($"Инженер: {Name}, Возраст: {Age}, Специальность: {Specialty}");
    }
}
class Program
{
    static void Main()
    {
        /* var price = new Money(10, 50);
         price.Display();

         var product = new Product("Телевизор", price);

         WriteLine("\nДо уменьшения цены:");
         product.Display();

         var discount = new Money(2, 75);
         product.ReducePrice(discount);

         WriteLine("\nПосле уменьшения цены:");
         product.Display();*/
        //
        /*var devices = new Ustroystvo[]
       {
           new Chaynik("Электрический чайник", "Мощность 1500 Вт, объем 1.7 л"),
           new Mikrovolnovka("Samsung MW", "Мощность 800 Вт, объем 20 л"),
           new Avtomobil("Toyota Camry", "Двигатель 2.5 л, автоматическая коробка"),
           new Parohod("Корабль \"Нептун\"", "Длина 100 м, пассажировместимость 200 человек")
       };

        foreach (var device in devices)
        {
            device.Show();
            device.Desc();
            device.Sound();
            Console.WriteLine();
        }*/
        /*MuzykalnyInstrument[] instruments =
       {
           new Skripka("Струнная скрипка", "Четыре струны, деревянный корпус"),
           new Trombon("Медный тромбон", "Длинная трубка с слайдером"),
           new Ukulele("Гавайское укулеле", "Четыре нейлоновые струны"),
           new Violoncelle("Виолончель", "Большая струна с глубоким звуком")
       };

        foreach (var instrument in instruments)
        {
            instrument.Show();
            instrument.Desc();
            instrument.Sound();
            instrument.History();
            WriteLine();
        }*/
        Worker[] workers =
      {
           new President("Иван Иванов", 55, "TechCorp"),
           new Security("Петр Петров", 40, "Main Gate"),
           new Manager("Анна Смирнова", 35, "Sales"),
           new Engineer("Дмитрий Кузнецов", 30, "Software Development")
       };

        foreach (var worker in workers)
        {
            worker.Print();
        }
    }
}