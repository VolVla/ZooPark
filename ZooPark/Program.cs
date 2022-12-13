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
        private List<Aviary> _aviaries = new List<Aviary>() 
        {
            new Aviary("Львы", "Рычат", 5),new Aviary("Антилопы", "Цокают", 3),
            new Aviary("Зебры", "Брыгаются", 7),new Aviary("Верблюды", "Харкаются", 9),
            new Aviary("Бегемоты", "Зевают", 2),new Aviary("Пингвины", "Хлопают в ладоши", 10),
            new Aviary("Крокодилы", "Скрипят зубами", 1) 
        };
        private bool _isWork = true;
        private bool _isSelectingAviary = true;
        private ConsoleKey _exitButton = ConsoleKey.Enter;

        public void Start()
        {
            while (_isWork)
            {
                Console.WriteLine("Добро пожаловать в зоопарк.\nВыберите к какому вольеру подойти");

                for (int i = 0; i < _aviaries.Count; i++)
                {
                    Console.WriteLine($"{i + 1} -  {_aviaries[i].Name}");
                }

                while (_isSelectingAviary == true)
                {
                    int.TryParse(Console.ReadLine(), out int numberAvary);

                    if (0 < numberAvary && numberAvary - 1 < _aviaries.Count)
                    {
                        _aviaries[numberAvary - 1].ShowInfo();
                        _isSelectingAviary = false;
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

                _isSelectingAviary = true;
                Console.Clear();
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public string SoundAnimal { get; private set; }
        public string Name { get; private set; }
        public int NumberAnimal { get; private set; }

        public Aviary(string nameAviary, string soundAnimal, int numberAnimal)
        {
            SoundAnimal = soundAnimal;
            Name = nameAviary;
            NumberAnimal = numberAnimal;
            Random random = new Random();

            for (int i = 0; i < NumberAnimal; i++)
            { 
                Animal animal = new Animal(random);
                _animals.Add(animal);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Вольер - {Name}\nКоличество животных {NumberAnimal}");

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"{_animals[i].Gender} \nЗвук - {SoundAnimal} ");
            }
        }
    }

    class Animal
    {
        private List<string> _genders = new List<string>() {"Мужской пол","Женский пол" };
        public string Gender { get; private set; }

        public Animal(Random random)
        {
            int randomGender = random.Next(0, _genders.Count);
            SetGender(randomGender);
        }

        private void SetGender(int randomGender)
        {
            if (randomGender == _genders.IndexOf(_genders[0])) 
            {
                Gender = _genders[0];
            }
            else if (randomGender == _genders.IndexOf(_genders[1]))
            {
                Gender = _genders[1];
            }
        }
    }
}
