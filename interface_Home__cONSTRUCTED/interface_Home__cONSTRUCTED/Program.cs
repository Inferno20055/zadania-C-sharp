using static System.Console;
using System;
using System.Collections.Generic;

interface IPart
{
    string Name { get; }
    bool IsBuilt { get; set; }
    void Build();
}

interface IWorker
{
    string Name { get; }
    void Work(IPart part);
}

class House
{
    public Basement Basement { get; } = new Basement();
    public List<Walls> Walls { get; } = new List<Walls>();
    public List<Window> Windows { get; } = new List<Window>();
    public List<Door> Doors { get; } = new List<Door>();
    public Roof Roof { get; } = new Roof();

    public bool IsBuilt =>
        Basement.IsBuilt &&
        Walls.TrueForAll(w => w.IsBuilt) &&
        Windows.TrueForAll(w => w.IsBuilt) &&
        Doors.TrueForAll(d => d.IsBuilt) &&
        Roof.IsBuilt;

    public void ShowHouse()
    {
        WriteLine("\n--- Дом построен! ---");
        WriteLine("   /\\");
        WriteLine("  /  \\");
        WriteLine(" /____\\");
        WriteLine(" | [] |");
        WriteLine(" | [] |");
        WriteLine(" |____|");
    }
}

// Части дома
class Basement : IPart
{
    public string Name => "Фундамент";
    public bool IsBuilt { get; set; } = false;
    public void Build()
    {
        IsBuilt = true;
        WriteLine($"{Name} построен.");
    }
}

class Walls : IPart
{
    public string Name => "Стены";
    public bool IsBuilt { get; set; } = false;
    public void Build()
    {
        IsBuilt = true;
        WriteLine($"{Name} построены.");
    }
}

class Window : IPart
{
    public string Name => "Окно";
    public bool IsBuilt { get; set; } = false;
    public void Build()
    {
        IsBuilt = true;
        WriteLine($"{Name} установлено.");
    }
}

class Door : IPart
{
    public string Name => "Дверь";
    public bool IsBuilt { get; set; } = false;
    public void Build()
    {
        IsBuilt = true;
        WriteLine($"{Name} установлена.");
    }
}

class Roof : IPart
{
    public string Name => "Крыша";
    public bool IsBuilt { get; set; } = false;
    public void Build()
    {
        IsBuilt = true;
        WriteLine($"{Name} построена.");
    }
}

// Рабочий
class Worker : IWorker
{
    public string Name { get; private set; }

    public Worker(string name)
    {
        Name = name;
    }

    public void Work(IPart part)
    {
        if (!part.IsBuilt)
        {
            part.Build();
            WriteLine($"{Name} построил(а) {part.Name}.");
        }
        else
            WriteLine($"{part.Name} уже построена. {Name} проверяет...");
    }
}

// Бригадир (отчет)
class TeamLeader : IWorker
{
    public string Name { get; private set; }

    public TeamLeader(string name)
    {
        Name = name;
    }

    // Отчет о состоянии части
    public void Work(IPart part)
    {
        if (part.IsBuilt)
            WriteLine($"Бригадир {Name}: {part.Name} уже построена.");
        else
            WriteLine($"Бригадир {Name}: {part.Name} еще не построена.");
    }

    // Общий отчет по всему дому
    public void Report(List<IPart> parts)
    {
        WriteLine($"\nОтчет бригадира {Name}:");
        foreach (var part in parts)
        {
            WriteLine($"- {part.Name}: {(part.IsBuilt ? "выполнено" : "не выполнено")}");
        }
    }
}

// Команда строителей
class Team
{
    private List<IWorker> workers;

    public Team()
    {
        workers = new List<IWorker>();
    }

    public void AddWorker(IWorker worker)
    {
        workers.Add(worker);
    }

    public void BuildPart(IPart part)
    {
        foreach (var worker in workers)
        {
            worker.Work(part);
            if (part.IsBuilt) break;
        }
    }

    // Отчет всей команды через бригадира
    public void Report(List<IPart> parts, TeamLeader leader)
    {
        leader.Report(parts);
    }
}

class Program
{
    static void Main()
    {
        var house = new House();

        var team = new Team();
        team.AddWorker(new Worker("Строитель Иван"));
        team.AddWorker(new Worker("Строитель Петр"));
        var leader = new TeamLeader("Бригадир Сергей");
        team.AddWorker(leader);

        // Строим фундамент один раз:
        house.Basement.Build();

        // Строим стены:
        for (int i = 0; i < 3; i++)
        {
            var wall = new Walls();
            house.Walls.Add(wall);
            team.BuildPart(wall);
        }

        // Окна:
        for (int i = 0; i < 2; i++)
        {
            var window = new Window();
            house.Windows.Add(window);
            team.BuildPart(window);
        }

        // Дверь:
        var door = new Door();
        house.Doors.Add(door);
        team.BuildPart(door);

        // Крыша:
        team.BuildPart(house.Roof);

        // Отчет:
        var allParts = new List<IPart>();
        allParts.Add(house.Basement);
        allParts.AddRange(house.Walls);
        allParts.AddRange(house.Windows);
        allParts.AddRange(house.Doors);
        allParts.Add(house.Roof);

        team.Report(allParts, leader);

        if (house.IsBuilt)
        {
            WriteLine("\nДом полностью построен!");
            house.ShowHouse();
        }
        else
            WriteLine("\nСтроительство еще не завершено.");
    }
}