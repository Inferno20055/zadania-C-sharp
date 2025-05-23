using System;
using System.IO;
using System.Xml.Serialization;

public class UserRecord
{
    public string Name { get; set; }
    public string Email { get; set; }

    public UserRecord() { }

    public UserRecord(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

public class UserRegistrationSystem
{
    public delegate void NewUserRegisteredHandler(object sender, UserRecord user);
    public event NewUserRegisteredHandler OnNewUserRegistered;

    public void SerializeUserToXml(UserRecord user, string filename)
    {
        var serializer = new XmlSerializer(typeof(UserRecord));
        using (var writer = new StreamWriter(filename))
        {
            serializer.Serialize(writer, user);
            Console.WriteLine($"Пользователь сохранен в файл {filename}");
        }
    }

    public UserRecord DeserializeUserFromXml(string filename)
    {
        var serializer = new XmlSerializer(typeof(UserRecord));
        using (var reader = new StreamReader(filename))
        {
            return (UserRecord)serializer.Deserialize(reader);
        }
    }

    public void CreateEmptyUserFile(string filename)
    {
        var emptyUser = new UserRecord("Пустое имя", "пустой_email@example.com");
        SerializeUserToXml(emptyUser, filename);
        Console.WriteLine($"Создан файл {filename} с пустыми данными");
    }

    public void RegisterUser()
    {
        Console.Write("Введите имя пользователя: ");
        string name = Console.ReadLine();

        Console.Write("Введите email: ");
        string email = Console.ReadLine();

        var newUser = new UserRecord(name, email);

        OnNewUserRegistered?.Invoke(this, newUser);

        SerializeUserToXml(newUser, "user.xml");
    }
}

class Program
{
    private static void NotifyAdmin(object sender, UserRecord user)
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"[Уведомление] Новый пользователь зарегистрирован!");
        Console.WriteLine($"Имя: {user.Name}");
        Console.WriteLine($"Email: {user.Email}");
        Console.WriteLine("Администратор уведомлен о регистрации нового пользователя.");
        Console.WriteLine("========================================\n");
    }
    static void Main()
    {
        var registrationSystem = new UserRegistrationSystem();

        registrationSystem.CreateEmptyUserFile("user.xml");

        registrationSystem.OnNewUserRegistered += NotifyAdmin;

        registrationSystem.RegisterUser();

        var userFromFile = registrationSystem.DeserializeUserFromXml("user.xml");
        Console.WriteLine($"Десериализованный пользователь:\nИмя: {userFromFile.Name}\nEmail: {userFromFile.Email}");
    }

    
    
}