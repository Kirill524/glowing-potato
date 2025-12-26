//Задание 1: 
//Создайте приложение для работы с коллекцией стихов. 
//Необходимо хранить такую информацию: 
// Название стиха 
// ФИО автора 
// Год написания 
// Текст стиха 
// Тема стиха 
//Приложение должно позволять: 
// Добавлять стихи 
// Удалять стихи 
// Изменять информацию о стихах 
// Искать стих по разным характеристикам 
// Сохранять коллекцию стихов в файл 
// Загружать коллекцию стихов из файла 

using System;

class Poem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Text { get; set; }
    public string Theme { get; set; }

    public override string ToString()
    {
        return $"{Title}|{Author}|{Year}|{Theme}|{Text}";
    }

    public static Poem FromString(string data)
    {
        var parts = data.Split('|');
        return new Poem
        {
            Title = parts[0],
            Author = parts[1],
            Year = int.Parse(parts[2]),
            Theme = parts[3],
            Text = parts[4]
        };
    }
}

class Program
{
    static List<Poem> poems = new List<Poem>();
    const string fileName = "poems.txt";

    static void Main()
    {
        poems.Add(new Poem
        {
            Title = "Осень",
            Author = "Пушкин",
            Year = 1833,
            Theme = "Природа",
            Text = "Унылая пора..."
        });

        SaveToFile();
        LoadFromFile();

        foreach (var poem in poems)
            Console.WriteLine(poem.Title + " — " + poem.Author);
    }

    static void SaveToFile()
    {
        using StreamWriter sw = new StreamWriter(fileName);
        foreach (var poem in poems)
            sw.WriteLine(poem);
    }

    static void LoadFromFile()
    {
        poems.Clear();
        if (!File.Exists(fileName)) return;

        foreach (var line in File.ReadAllLines(fileName))
            poems.Add(Poem.FromString(line));
    }
}

//Задание 2: 
//Добавьте к приложению из первого задания возможность 
//генерировать отчёты. Отчёт может быть отображён на экран или 
//сохранён в файл. Создайте такие отчёты: 
// По названию стиха 
// По ФИО автора 
// По теме стиха 

using System;

class Poem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Theme { get; set; }
}

class Program
{
    static void Main()
    {
        List<Poem> poems = new()
        {
            new Poem { Title="Осень", Author="Пушкин", Theme="Природа" },
            new Poem { Title="Зима", Author="Пушкин", Theme="Природа" },
            new Poem { Title="Любовь", Author="Есенин", Theme="Чувства" }
        };

        Console.WriteLine("Отчёт по автору Пушкин:");
        var byAuthor = poems.Where(p => p.Author == "Пушкин");

        foreach (var p in byAuthor)
            Console.WriteLine(p.Title);
    }
}

//Задание 3: 
//Добавьте к приложению из первого задания дополнительные 
//отчёты: 
// По слову в тексте стиха 
// По году написания стиха 
// По длине стиха

using System;

class Poem
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main()
    {
        List<Poem> poems = new()
        {
            new Poem { Title="Осень", Year=1833, Text="Унылая пора очей очарованье" },
            new Poem { Title="Весна", Year=1840, Text="Люблю грозу в начале мая" }
        };

        Console.WriteLine("Поиск слова 'пора':");
        foreach (var p in poems.Where(p => p.Text.Contains("пора")))
            Console.WriteLine(p.Title);

        Console.WriteLine("По году 1833:");
        foreach (var p in poems.Where(p => p.Year == 1833))
            Console.WriteLine(p.Title);

        Console.WriteLine("По длине текста > 20:");
        foreach (var p in poems.Where(p => p.Text.Length > 20))
            Console.WriteLine(p.Title);
    }
}

//Задание 1: 
//Разработайте приложение для поиска файлов по маске. 
//Пользователь вводит путь к папке и маску для поиска. 
//Например:  
//D:\DataForUser
//*.txt
//Приложение должно отобразить все файлы с расширением txt по 
//пути D:\DataForUser

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите путь к папке: ");
        string path = Console.ReadLine();

        Console.Write("Введите маску (например *.txt): ");
        string mask = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Папка не существует");
            return;
        }

        string[] files = Directory.GetFiles(path, mask);

        foreach (string file in files)
            Console.WriteLine(file);
    }
}

//Задание 2: 
//Добавьте к первому заданию поиск в подпапках. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Путь к папке: ");
        string path = Console.ReadLine();

        Console.Write("Маска: ");
        string mask = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Папка не найдена");
            return;
        }

        string[] files = Directory.GetFiles(path, mask, SearchOption.AllDirectories);

        foreach (string file in files)
            Console.WriteLine(file);
    }
}

//Задание 3: 
//Разработайте приложение для удаления файлов по маске. 
//Пользователь вводит путь к папке и маску для поиска 
//удаляемых файлов. Например:  
//D:\DataForUser
//*.txt
//Приложение должно удалить все файлы с расширением txt по 
//пути D:\DataForUser

using System;

class Program
{
    static void Main()
    {
        Console.Write("Путь к папке: ");
        string path = Console.ReadLine();

        Console.Write("Маска: ");
        string mask = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Папка не существует");
            return;
        }

        foreach (string file in Directory.GetFiles(path, mask))
        {
            File.Delete(file);
            Console.WriteLine("Удалён: " + file);
        }
    }
}

//Задание 4: 
//Добавьте к третьему заданию удаление файлов в подпапках. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Путь: ");
        string path = Console.ReadLine();

        Console.Write("Маска: ");
        string mask = Console.ReadLine();

        foreach (string file in Directory.GetFiles(path, mask, SearchOption.AllDirectories))
        {
            File.Delete(file);
            Console.WriteLine("Удалён: " + file);
        }
    }
}

//Задание 5: 
//Добавьте к третьему заданию удаление подпапок в папках. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Путь к папке: ");
        string path = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Папка не найдена");
            return;
        }

        foreach (string dir in Directory.GetDirectories(path))
        {
            Directory.Delete(dir, true);
            Console.WriteLine("Удалена папка: " + dir);
        }
    }
}

//Задание 6: 
//Создайте приложение для отображения файловой структуры по 
//указанному пути. Пользователь вводит путь для отображения. 
//Приложение показывает содержимое по указанному пути. 
//Например, если пользователь вводит D:\TestFolder должно 
//отобразиться содержимое этой папки. Обратите внимание, что 
//нужно показать всё содержимое папки вплоть до подпапок.

using System;

class Program
{
    static void ShowDirectory(string path, int level = 0)
    {
        string indent = new string(' ', level * 2);

        foreach (string dir in Directory.GetDirectories(path))
        {
            Console.WriteLine(indent + "[Папка] " + Path.GetFileName(dir));
            ShowDirectory(dir, level + 1);
        }

        foreach (string file in Directory.GetFiles(path))
        {
            Console.WriteLine(indent + "Файл: " + Path.GetFileName(file));
        }
    }

    static void Main()
    {
        Console.Write("Введите путь: ");
        string path = Console.ReadLine();

        if (Directory.Exists(path))
            ShowDirectory(path);
        else
            Console.WriteLine("Путь не существует");
    }
}

//Задание 1: 
//Приложение
//позволяет 
//пользователю 
//просматривать 
//содержимое файла. Пользователь вводит путь к файлу. Если 
//файл существует, его содержимое отображается на экран. Если 
//файла не существует, нужно отобразить сообщение об ошибке. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите путь к файлу: ");
        string path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не существует");
            return;
        }

        string content = File.ReadAllText(path);
        Console.WriteLine("Содержимое файла:\n");
        Console.WriteLine(content);
    }
}

//Задание 2: 
//Пользователь вводит значения для элементов массива с 
//клавиатуры. 
//Приложение 
//предоставляет 
//сохранения содержимого массива в файл. 

using System;

class Program
{
    static void Main()
    {
        int[] array = new int[5];

        Console.WriteLine("Введите 5 чисел:");
        for (int i = 0; i < array.Length; i++)
            array[i] = int.Parse(Console.ReadLine());

        File.WriteAllText("array.txt", string.Join(" ", array));
        Console.WriteLine("Массив сохранён в файл");
    }
}

//Задание 3: 
//возможность
//Добавьте ко второму заданию возможность загрузки массива из 
//файла.   

using System;

class Program
{
    static void Main()
    {
        if (!File.Exists("array.txt"))
        {
            Console.WriteLine("Файл не найден");
            return;
        }

        string[] data = File.ReadAllText("array.txt").Split(' ');
        int[] array = Array.ConvertAll(data, int.Parse);

        Console.WriteLine("Массив из файла:");
        foreach (int n in array)
            Console.WriteLine(n);
    }
}

//Задание 4: 
//Приложение генерирует случайным образом 10000 целых чисел. 
//Необходимо сохранить чётные числа в один файл, нечётные в 
//другой. По итогам работы приложения нужно отобразить 
//статистику на экран. 

using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int even = 0, odd = 0;

        using StreamWriter evenFile = new StreamWriter("even.txt");
        using StreamWriter oddFile = new StreamWriter("odd.txt");

        for (int i = 0; i < 10000; i++)
        {
            int number = rnd.Next(1, 10000);

            if (number % 2 == 0)
            {
                evenFile.WriteLine(number);
                even++;
            }
            else
            {
                oddFile.WriteLine(number);
                odd++;
            }
        }

        Console.WriteLine($"Чётных: {even}");
        Console.WriteLine($"Нечётных: {odd}");
    }
}

//Задание 4: 
//Приложение предоставляет пользователю возможность поиска 
//по файлу: 
// Поиск заданного слова. Приложение показывает найдено 
//ли слово. Кроме этого, отображается информация о том, где 
//найдено совпадение. 
// Поиск количества вхождения слова в файл. Приложение 
//отображает количество раз, сколько найдено слово. 
// Поиск заданного слова в обратном порядке. Например,
//пользователь ищет слово moon. Это значит, что приложение 
//ищет слово moon в обратном порядке: noom.По
//результатам поиска, приложение отображает количество 
//вхождений. 


//Задание 5: 
//Пользователь вводит путь к файлу. Приложение отображает 
//статистическую информацию о файле: 
// Количество предложений 
// Количество больших букв 
// Количество маленьких букв 
// Количество гласных букв 
// Количество согласных букв 
// Количество цифр


//Задание 1: 
//Создайте приложение для работы с коллекцией рецептов. Рецепт 
//содержит такие данные: 
// Название рецепта 
// Название кухни, откуда родом рецепт (Например,
//итальянская или японская) 
// Названия ингредиентов 
// Время готовки 
// Описание процесса готовки по шагам 
//Приложение должно позволять: 
// Добавлять рецепты 
// Удалять рецепты 
// Изменять рецепты 
// Искать рецепты по разным характеристикам 
// Сохранять рецепты в файл 
// Загружать рецепты из файла 

using System;


class Recipe
{
    public string Name { get; set; }
    public string Cuisine { get; set; }
    public List<string> Ingredients { get; set; }
    public int CookTime { get; set; }
    public string Steps { get; set; }

    public override string ToString()
    {
        return $"{Name}|{Cuisine}|{CookTime}|{string.Join(",", Ingredients)}|{Steps}";
    }

    public static Recipe FromString(string data)
    {
        var p = data.Split('|');
        return new Recipe
        {
            Name = p[0],
            Cuisine = p[1],
            CookTime = int.Parse(p[2]),
            Ingredients = p[3].Split(',').ToList(),
            Steps = p[4]
        };
    }
}

class Program
{
    static List<Recipe> recipes = new();
    const string file = "recipes.txt";

    static void Main()
    {
        recipes.Add(new Recipe
        {
            Name = "Паста",
            Cuisine = "Итальянская",
            CookTime = 30,
            Ingredients = new List<string> { "макароны", "сыр" },
            Steps = "Отварить и смешать"
        });

        Save();
        Load();

        foreach (var r in recipes)
            Console.WriteLine(r.Name);
    }

    static void Save()
    {
        File.WriteAllLines(file, recipes.Select(r => r.ToString()));
    }

    static void Load()
    {
        if (!File.Exists(file)) return;
        recipes = File.ReadAllLines(file)
            .Select(Recipe.FromString)
            .ToList();
    }
}

//Задание 2: 
//Добавьте к приложению из первого задания возможность 
//генерировать отчёты. Отчёт может быть отображён на экран или 
//сохранён в файл. Создайте такие отчёты: 
// По типу кухни 
// По времени готовки 
// По названиям ингредиентов 
// По названию рецепта 

using System;

class Recipe
{
    public string Name { get; set; }
    public string Cuisine { get; set; }
    public int CookTime { get; set; }
    public List<string> Ingredients { get; set; }
}

class Program
{
    static void Main()
    {
        var recipes = new List<Recipe>
        {
            new Recipe { Name="Паста", Cuisine="Итальянская", CookTime=30, Ingredients=new(){"сыр"} },
            new Recipe { Name="Суши", Cuisine="Японская", CookTime=50, Ingredients=new(){"рис"} }
        };

        Console.WriteLine("Итальянская кухня:");
        foreach (var r in recipes.Where(r => r.Cuisine == "Итальянская"))
            Console.WriteLine(r.Name);

        Console.WriteLine("\nГотовка до 40 минут:");
        foreach (var r in recipes.Where(r => r.CookTime <= 40))
            Console.WriteLine(r.Name);
    }
}

//Задание 3: 
//Добавьте к приложению из первого задания дополнительные 
//характеристики: 
// Калории ингредиентов 
// Тип блюда: салат, первое, второе, закуска, десерт 
//Создайте дополнительные отчёты: 
// По сумме калорий 
// По типу блюда 
// По комбинации типов блюд. Например, отчёт, который 
//генерирует комбинацию блюд: закуска, салат, первое,
//второе, десерт.

using System;

class Ingredient
{
    public string Name { get; set; }
    public int Calories { get; set; }
}

class Recipe
{
    public string Name { get; set; }
    public string DishType { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public int TotalCalories => Ingredients.Sum(i => i.Calories);
}

class Program
{
    static void Main()
    {
        var recipes = new List<Recipe>
        {
            new Recipe
            {
                Name="Салат",
                DishType="Салат",
                Ingredients=new()
                {
                    new Ingredient{Name="Огурец",Calories=20},
                    new Ingredient{Name="Помидор",Calories=25}
                }
            }
        };

        Console.WriteLine("По типу блюда:");
        foreach (var r in recipes.Where(r => r.DishType == "Салат"))
            Console.WriteLine(r.Name);

        Console.WriteLine("\nПо калориям < 100:");
        foreach (var r in recipes.Where(r => r.TotalCalories < 100))
            Console.WriteLine(r.Name);
    }
}

//Задание 1: 
//Создайте приложение для копирования файлов. Пользователь 
//вводит путь к оригинальному файлу и путь к тому месту куда 
//нужно скопировать файл. Приложение должно сообщить об 
//успешности или неуспешности операции. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Путь к исходному файлу: ");
        string source = Console.ReadLine();

        Console.Write("Путь назначения: ");
        string destination = Console.ReadLine();

        try
        {
            File.Copy(source, destination, true);
            Console.WriteLine("Файл успешно скопирован");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}

//Задание 2: 
//Создайте приложение для перемещения файлов. Пользователь 
//вводит путь к оригинальному файлу и путь к тому месту куда 
//нужно переместить файл. Приложение должно сообщить об 
//успешности или неуспешности операции. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Путь к исходному файлу: ");
        string source = Console.ReadLine();

        Console.Write("Путь назначения: ");
        string destination = Console.ReadLine();

        try
        {
            File.Move(source, destination, true);
            Console.WriteLine("Файл успешно перемещён");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}

//Задание 3: 
//Создайте приложение для копирования папок. Пользователь 
//вводит путь к оригинальной папке и путь к тому месту куда нужно 
//скопировать папку. Приложение должно сообщить об 
//успешности или неуспешности операции. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Исходная папка: ");
        string source = Console.ReadLine();

        Console.Write("Папка назначения: ");
        string destination = Console.ReadLine();

        Directory.CreateDirectory(destination);

        foreach (string file in Directory.GetFiles(source))
        {
            string name = Path.GetFileName(file);
            File.Copy(file, Path.Combine(destination, name), true);
        }

        Console.WriteLine("Папка скопирована");
    }
}

//Задание 4: 
//Добавьте к приложению возможность копирования папок с 
//подпапками. 

using System;

class Program
{
    static void CopyDir(string source, string destination)
    {
        Directory.CreateDirectory(destination);

        foreach (string file in Directory.GetFiles(source))
        {
            string name = Path.GetFileName(file);
            File.Copy(file, Path.Combine(destination, name), true);
        }

        foreach (string dir in Directory.GetDirectories(source))
        {
            string name = Path.GetFileName(dir);
            CopyDir(dir, Path.Combine(destination, name));
        }
    }

    static void Main()
    {
        Console.Write("Исходная папка: ");
        string source = Console.ReadLine();

        Console.Write("Папка назначения: ");
        string destination = Console.ReadLine();

        CopyDir(source, destination);
        Console.WriteLine("Папка скопирована с подпапками");
    }
}

//Задание 5: 
//Создайте приложение для перемещения папок. Пользователь 
//вводит путь к оригинальной папке и путь к тому месту куда нужно 
//переместить папку. Приложение должно сообщить об 
//успешности или неуспешности операции. 

using System;

class Program
{
    static void Main()
    {
        Console.Write("Исходная папка: ");
        string source = Console.ReadLine();

        Console.Write("Папка назначения: ");
        string destination = Console.ReadLine();

        Directory.Move(source, destination);
        Console.WriteLine("Папка перемещена");
    }
}

//Задание 6: 
//Добавьте к приложению возможность перемещения папок с 
//подпапками.
using System;

class Program
{
    static void Main()
    {
        Console.Write("Исходная папка: ");
        string source = Console.ReadLine();

        Console.Write("Папка назначения: ");
        string destination = Console.ReadLine();

        Directory.Move(source, destination);
        Console.WriteLine("Папка перемещена вместе с подпапками");
    }
}