using System.Collections.Generic;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var User = UserInfo();
            ShowUserInfo(User);
            Console.ReadKey();

        }

        //кортеж для сбора информации о пользователе
        static (string Name, string LastName, byte Age, bool HasPet, string[] PetNames, string[] Colors) UserInfo()
        {
            (string Name, string LastName, byte Age, bool HasPet, string[] PetNames, string[] Colors) User;

            //имя
            Console.WriteLine("Введите имя: ");
            User.Name = Console.ReadLine();

            //фамилия
            Console.WriteLine("Введите фамилию: ");
            User.LastName = Console.ReadLine();

            //возраст и проверка ввода
            Console.WriteLine("Введите возраст с цифрами:");
            User.Age = CheckInput("Введите корректное значение");

            Console.WriteLine("Есть ли у вас питомец? (да/нет): ");
            bool HasPet = Console.ReadLine().ToLower() == "да";

            string[] petNames = new string[0];
            if (HasPet)
            {
                int petCount = CheckInput("Введите корректное количество питомцев: ");
                petNames = GetPetNames(petCount);
            }
            int colorCount = CheckInput("Введите корректное количество любимых цветов: ");
            string[] Colors = GetColors(colorCount);


            return (User.Name, User.LastName, User.Age, HasPet, petNames, Colors);
        }

        //проверка ввода и получение введенного значения
        static byte CheckInput(string message)
        {
            byte count;
            while (!byte.TryParse(Console.ReadLine(), out count) || count <= 0 )
            {
                Console.WriteLine(message);
            }
            return count;
        }

        //получение кличек
        static string[] GetPetNames(int count)
        {
            string[] names = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите кличку питомца {i + 1}: ");
                names[i] = Console.ReadLine();
            }
            return names;
        }

        //получение цветов
        static string[] GetColors( int count)
            {
            string[] colors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите любимый цвет {i + 1}: ");
                colors[i] = Console.ReadLine();
            }
            return colors;
        }


        //вывод информации из кортежа на экран
        static void ShowUserInfo((string Name, string LastName, byte Age, bool HasPet, string[] PetNames, string[] Colors) User)
        {
            Console.WriteLine("Здравствуйте, {0} {1}", User.Name, User.LastName);
            Console.WriteLine("Ваш возраст {0} лет", User.Age);

            if (User.HasPet)
            {
                Console.WriteLine("Клички питомцев:");
                foreach (string pet in User.PetNames)
                {
                    Console.WriteLine(pet);
                };
            }
            else
            {
                Console.WriteLine("У вас нет питомцев");
            }

            if (User.Colors.Length > 0)
            {
                Console.WriteLine("Любимые цвета:");
                foreach (string colors in User.Colors)
                {
                    Console.WriteLine(colors);
                };
            }
            else
            {
                Console.WriteLine("У вас нет любимых цветов");
            }
        }

    }
            
}
    
    
    
