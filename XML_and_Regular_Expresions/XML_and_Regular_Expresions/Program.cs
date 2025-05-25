using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using static System.Console;
//Тут будут все три задания как по XML так и РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ
/*namespace WeatherLibrary
{
    public class WeatherInfo
    {
        public string City { get; set; }
        public string Temperature { get; set; }
        public string WeatherDescription { get; set; }
        public string WindSpeed { get; set; }
        public string Humidity { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Город: {City}\n" +
                   $"Дата: {Date}\n" +
                   $"Температура: {Temperature}\n" +
                   $"Погода: {WeatherDescription}\n" +
                   $"Ветер: {WindSpeed}\n" +
                   $"Влажность: {Humidity}";
        }
    }

    public class WeatherFetcher
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<WeatherInfo> GetWeatherAsync(int cityCode)
        {
            string url = $"http://informer.gismeteo.by/rss/{cityCode}.xml";

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                return ParseXml(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
                return null;
            }
        }

        private WeatherInfo ParseXml(System.IO.Stream xmlStream)
        {
            WeatherInfo weather = new WeatherInfo();

            using (XmlReader reader = XmlReader.Create(xmlStream))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "title":
                                var titleContent = reader.ReadElementContentAsString();
                                var parts = titleContent.Split(',');
                                if (parts.Length > 0)
                                    weather.City = parts[0].Trim();
                                break;

                            case "pubDate":
                                var dateStr = reader.ReadElementContentAsString();
                                if (DateTime.TryParse(dateStr, out DateTime date))
                                    weather.Date = date;
                                break;

                            case "temperature":
                                if (reader.HasAttributes)
                                {
                                    reader.MoveToAttribute("value");
                                    weather.Temperature = reader.Value + "°C";
                                }
                                break;

                            case "weather":
                                if (reader.HasAttributes)
                                {
                                    reader.MoveToAttribute("value");
                                    weather.WeatherDescription = reader.Value;
                                }
                                break;

                            case "windSpeed":
                                if (reader.HasAttributes)
                                {
                                    reader.MoveToAttribute("name");
                                    weather.WindSpeed = reader.Value;
                                }
                                break;

                            case "humidity":
                                if (reader.HasAttributes)
                                {
                                    reader.MoveToAttribute("value");
                                    weather.Humidity = reader.Value + "%";
                                }
                                break;
                        }
                    }
                }
            }

            return weather;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите код города:");
            if (!int.TryParse(Console.ReadLine(), out int cityCode))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            var fetcher = new WeatherFetcher();
            var weather = await fetcher.GetWeatherAsync(cityCode);

            if (weather != null)
            {
                Console.WriteLine("\nПогода:");
                Console.WriteLine(weather);
            }
            else
            {
                Console.WriteLine("Не удалось получить данные о погоде.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}*/

//Регулярны выражения
//задание 1

class Program
{
    static void Main()
    {
        /*string weatherData = "Weather report: Temperature: 20°C, Humidity: 65%, Wind: 10 km/h";

        // Регулярные выражения для поиска параметров
        string tempPattern = @"Temperature:\s*(\d+)[°|C]";
        string humidityPattern = @"Humidity:\s*(\d+)%";
        string windPattern = @"Wind:\s*(\d+)\s*km/h";

        // Поиск температуры
        Match tempMatch = Regex.Match(weatherData, tempPattern);
        if (tempMatch.Success)
        {
            WriteLine($"Температура: {tempMatch.Groups[1].Value}°C");
        }
        else
        {
            WriteLine("Температура не найдена");
        }

        // Поиск влажности
        Match humidityMatch = Regex.Match(weatherData, humidityPattern);
        if (humidityMatch.Success)
        {
            WriteLine($"Влажность: {humidityMatch.Groups[1].Value}%");
        }
        else
        {
            WriteLine("Влажность не найдена");
        }

        // Поиск ветра
        Match windMatch = Regex.Match(weatherData, windPattern);
        if (windMatch.Success)
        {
            WriteLine($"Скорость ветра: {windMatch.Groups[1].Value} км/ч");
        }
        else
        {
            WriteLine("Данные о ветре не найдены");
        }*/

        //zadanie 2

        string inputFilePath = "OriginalCode.cs";
        string outputFilePath = "ModifiedCode.cs";

        string sampleCode = @"
        using System;

        namespace ExampleNamespace
        {
            public class Person
            {
                public string Name;
                public int Age;
                public string Address;

                public void DisplayInfo()
                {
                    Console.WriteLine($""Name: {Name}, Age: {Age}"");
                }
            }

            public class Car
            {
                public string Model;
                public int Year;

                public void ShowDetails()
                {
                    Console.WriteLine($""Model: {Model}, Year: {Year}"");
                }
            }
        }
        ";

        File.WriteAllText(inputFilePath, sampleCode);
        WriteLine($"Создан исходный файл: {inputFilePath}");

        string code = File.ReadAllText(inputFilePath);

        WriteLine("=== Исходный код до изменений ===");
        WriteLine(code);
        WriteLine("=================================\n");

        string pattern = @"\bpublic\s+([A-Za-z_][A-Za-z0-9_<>,\s]*)\s+([a-zA-Z_][A-Za-z0-9_]*)\s*;";

        string resultCode = Regex.Replace(code, pattern, match =>
        {
            string typePart = match.Groups[1].Value.Trim();
            string fieldName = match.Groups[2].Value;

            if (!string.IsNullOrEmpty(fieldName))
            {
                fieldName = Char.ToLowerInvariant(fieldName[0]) + fieldName.Substring(1);
            }

            return $"private {typePart} {fieldName};";
        });

        WriteLine("=== Итоговый код после изменений ===");
        WriteLine(resultCode);
        WriteLine("=====================================\n");

        File.WriteAllText(outputFilePath, resultCode);
        WriteLine($"Объявления полей с 'public' заменены на 'private' и имена приведены к стилю camelCase.\nРезультат сохранен в: {outputFilePath}");
    }
}