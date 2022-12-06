using System;
using System.Collections.Generic;

namespace ZooPark
{
    internal class Program
    {
        static void Main()
        {
            ZooPark zooPark = new ZooPark();
            zooPark.Start();
        }
    }

    class ZooPark
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private bool _isWork = true;
        private bool _selectionAviary = true;
        private int _minimumValue = 0;
        private ConsoleKey _exitButton = ConsoleKey.Enter;

        public ZooPark()
        {
            _aviaries.Add(new Aviary("Львы", "Рычат", 5));
            _aviaries.Add(new Aviary("Антилопы", "Цокают", 3));
            _aviaries.Add(new Aviary("Зебры", "Брыгаются", 7));
            _aviaries.Add(new Aviary("Верблюды", "Харкаются", 9));
            _aviaries.Add(new Aviary("Бегемоты", "Зевают", 2));
            _aviaries.Add(new Aviary("Пингвины", "Хлопают в ладоши", 10));
            _aviaries.Add(new Aviary("Крокодилы", "Скрипят зубами", 1));
        }

        public void Start()
        {
            while (_isWork)
            {
                Console.WriteLine("Добро пожаловать в зоопарк.\nВыберите к какому вольеру подойти");

                for (int i = 0; i < _aviaries.Count; i++)
                {
                    Console.WriteLine($"{i + 1} -  {_aviaries[i].Name}");
                }

                while (_selectionAviary == true)
                {
                    int.TryParse(Console.ReadLine(), out int NumberAvary);

                    if (_minimumValue < NumberAvary && NumberAvary - 1 < _aviaries.Count)
                    {
                        _aviaries[NumberAvary - 1].ShowInfo();
                        _selectionAviary = false;
                    }
                    else
                    {
                        Console.WriteLine("Вывели не правильное значение вольера попробуйте заново");
                    }
                }

                Console.WriteLine($"Вы хотите выйти из программы?Нажмите Enter.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == _exitButton)
                {
                    _isWork = false;
                    Console.WriteLine("Вы вышли из программы");
                }

                _selectionAviary = true;
                Console.Clear();
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animal = new List<Animal>();

        public string SoundAnimal { get; private set; }
        public string Name { get; private set; }
        public int NumberAnimal { get; private set; }

        public Aviary(string nameAviary, string soundAnimal, int numberAnimal)
        {
            SoundAnimal = soundAnimal;
            Name = nameAviary;
            NumberAnimal = numberAnimal;
            CreateAnimal();
        }

        public void CreateAnimal()
        {
            int numberGender;
            Random random = new Random();

            for (int i = 0; i < NumberAnimal; i++)
            {
                numberGender = random.Next(1, 3);
                Animal animal = new Animal();
                animal.SetGender(numberGender);
                _animal.Add(animal);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Вольер - {Name}\nКоличество животных {NumberAnimal}");

            for (int i = 0; i < _animal.Count; i++)
            {
                Console.WriteLine($"{_animal[i].Gender} \nЗвук - {SoundAnimal} ");
            }
        }
    }

    class Animal
    {
        private const int FirstNumberGender = 1;
        private const int SecondNumberGender = 2;
        private const string FirstGender = "Мужской пол";
        private const string SecondGender = "Женский пол";

        public string Gender { get; private set; }

        public void SetGender(int randomGender)
        {
            if (randomGender == FirstNumberGender)
            {
                Gender = FirstGender;
            }
            else if (randomGender == SecondNumberGender)
            {
                Gender = SecondGender;
            }
        }
    }
}
