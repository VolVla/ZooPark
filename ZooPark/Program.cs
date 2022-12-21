using System;
using System.Collections.Generic;

namespace Zoo
{
    internal class Program
    {
        static void Main()
        {
            Zoo zooPark = new Zoo();
            zooPark.Start();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private bool _isWork;
        private bool _isSelectingAviary;
        private ConsoleKey _exitButton;

        public Zoo()
        {
            _isWork = true;
            _isSelectingAviary = true;
            _exitButton = ConsoleKey.Enter;
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
        private string _genderFist;
        private string _genderSecond;
        private int _genderNumberFist;
        private int _genderNumberSecond;
        private int randomGender;

        public string Gender { get; private set; }

        public Animal(Random random)
        {
            _genderFist = "Мужской пол";
            _genderSecond = "Женский пол";
            _genderNumberFist = 0;
            _genderNumberSecond = 1;
            randomGender = random.Next(_genderNumberFist, _genderNumberSecond + 1);

            if (randomGender == _genderNumberFist)
            {
                Gender = _genderFist;
            }
            else if (randomGender == _genderNumberSecond)
            {
                Gender = _genderSecond;
            }
        }
    }
}
