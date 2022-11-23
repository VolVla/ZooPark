using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooPark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsWork = true;
            bool SelectionAviary = true;
            int MinimumValue = 0;
            ZooPark ZooPark = new ZooPark();
            ConsoleKey ExitButton = ConsoleKey.Enter;

            while (IsWork)
            {
                Console.WriteLine("Добро пожаловать в зоопарк.\nВыберите к какому вольеру подойти");

                for (int i = 0; i < ZooPark.ReturnAmountAviary().Count; i++)
                {
                    Console.WriteLine($"{i + 1} -  {ZooPark.ReturnAmountAviary()[i].NameAviary}");
                }

                while (SelectionAviary == true)
                {
                    int.TryParse(Console.ReadLine(), out int NumberAvary);

                    if (MinimumValue < NumberAvary && NumberAvary - 1 < ZooPark.ReturnAmountAviary().Count)
                    {
                        ZooPark.ReturnAmountAviary()[NumberAvary - 1].ShowInfo();
                        SelectionAviary = false;
                    }
                    else
                    {
                        Console.WriteLine("Вывели не правильное значение вольера попробуйте заново");
                    }
                }

                Console.WriteLine($"Вы хотите выйти из программы?Нажмите Enter.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == ExitButton)
                {
                    IsWork = false;
                    Console.WriteLine("Вы вышли из программы");
                }

                SelectionAviary = true;
                Console.Clear();
            }
        }
    }

    class ZooPark
    {
        private List<Aviary> _aviaries = new List<Aviary>() { new Aviary("Львы", 10, "Мужской пол", "Рычат"), new Aviary("Антилопы", 5, "Женский пол", "Цокают"), new Aviary("Зебры", 3, "Женский пол", "Брыгаются"), new Aviary("Верблюды", 4, "Мужской пол", "Харкаются"), new Aviary("Бегемоты", 6, "Мужской пол", "Зевают"), new Aviary("Пингвины", 7, "Мужской пол", "Хлопают в ладоши"), new Aviary("Крокодилы", 8, "Мужской пол", "Скрипят зубами") };

        public List<Aviary> ReturnAmountAviary()
        {
            return _aviaries;
        }
    }

    class Aviary
    {
        private Animals _animals;

        public string NameAviary { get; set; }
        public int NumberAnimal { get; set; }

        public Aviary(string nameAviary, int numberAnimal, string Gender, string SoundAnimal)
        {
            NameAviary = nameAviary;
            NumberAnimal = numberAnimal;
            _animals = new Animals(Gender, SoundAnimal);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Вольер - {NameAviary}\n{NumberAnimal} - животных \n{_animals.Gender} \nЗвук - {_animals.SoundAnimal} ");
        }
    }

    class Animals
    {
        public string Gender { get; set; }
        public string SoundAnimal { get; set; }

        public Animals(string gender, string soundAnimal)
        {
            Gender = gender;
            SoundAnimal = soundAnimal;
        }
    }
}
