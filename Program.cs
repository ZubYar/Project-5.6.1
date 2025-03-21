using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        GetTuple(EnterUser());
    }

    static bool CheckNum(string number, out int correсtNumber)
    {
        correсtNumber = 0;
        if (int.TryParse(number, out int value) && value > 0)
        {
            correсtNumber = value;
            return false;
        }

        return true;
    }
    static bool IsDigitalCharArray (string value)
    {
        return value.Any(char.IsDigit);
    }

    static string[] GetPetsName(int countPets)
    {
        var result = new string[countPets];
        for (int i = 0; i < countPets; i++)
        {
            Console.WriteLine("Введите имя питомца {0}:", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;
    }

    static string[] GetColors(int count)
    {
        var result = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Введите любимый цвет {0}:", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;

    }

    static (string Name, string LastName, int Age, string[] Pets, string[] Colors) EnterUser()
    {
        (string Name, string LastName, int Age, string[] Pets, string[] Colors) User;
        User.Name = null;
        User.LastName = null;
        User.Pets = null;
        User.Colors = null;

        do
        {
            string correctName;
            Console.WriteLine("Введите имя:");
            if (!IsDigitalCharArray(correctName = Console.ReadLine()))
            {
                User.Name = correctName;
                do
                {
                    Console.WriteLine("Введите фамилию:");
                }
                while (IsDigitalCharArray(User.LastName = Console.ReadLine()));
                break;
            }
        }
        while (true);

        do
        {
            Console.WriteLine("Введите возраст цифрами:");
        }
        while (CheckNum(Console.ReadLine(), out User.Age));

        string str;
        do
        {
            Console.WriteLine("Есть ли у вас питомцы? Введите Да или Нет:");
            str = Console.ReadLine().ToLower();

            if (str == "да")
            {
                
                int count;
                do
                {
                    Console.WriteLine("Введите количество питомцев цифрами:");
                }
                while (CheckNum(Console.ReadLine(), out count));
                User.Pets = GetPetsName(count);
            }

            else if (str == "нет")
            {
                User.Pets = null;
            }
        }
        while (str.ToLower() != "да" && str.ToLower() != "нет");

        int count1;
        do
        {
            Console.WriteLine("Введите количество любимых цветов цифрами:");
        }
        while (CheckNum(Console.ReadLine(), out count1));

        User.Colors = GetColors(count1);
        return User;
    }
    static void GetTuple((string Name, string LastName, int Age, string[] Pets, string[] Colors) User)
    {
        Console.WriteLine("\nВас зовут {0} {1}\nВам {2} лет", User.Name, User.LastName, User.Age);

        if (User.Pets == null)
        {
            Console.WriteLine("У вас нет питомцев");
        }    
        else
        {
            for (int i = 0; i < User.Pets.Length; i++)
            {
                Console.WriteLine("Имя вашего питомца {0}: {1}", i + 1, User.Pets[i]);
            }
        }

        for (int i = 0; i < User.Colors.Length; i++)
        {
            Console.WriteLine("Ваш любимый цвет {0}: {1}", i + 1, User.Colors[i]);
        }
    }

}
