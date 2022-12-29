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
        private const int SelectAviary = 1;
        private const int Exit = 2;
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            _aviaries.Add(new Aviary("Львы", "Лев", 5));
            _aviaries.Add(new Aviary("Антилопы", "Антилопа", 3));
            _aviaries.Add(new Aviary("Зебры", "Зебра", 7));
            _aviaries.Add(new Aviary("Верблюды", "Верблюд", 9));
            _aviaries.Add(new Aviary("Бегемоты", "Бегемот", 2));
            _aviaries.Add(new Aviary("Пингвины", "Пингвин", 10));
            _aviaries.Add(new Aviary("Крокодилы", "Крокодил", 1));
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine($"Добро пожаловать в зоопарк.\nДля того чтоб подойти к вольеру напишите {SelectAviary}.\nЕсли вы хотите выйти из зоопарка напишите {Exit}");
                int.TryParse(Console.ReadLine(), out int input);

                switch (input)
                {
                    case SelectAviary:
                        SelectedAviary();
                        break;
                    default:
                        Console.WriteLine("Выберите к какому вольеру подойти или уйдите из Зоопарка");
                        break;
                }

                if (input == Exit)
                {
                    Console.WriteLine("Вы вышли из программы");
                    break;
                }
            }
        }

        private void SelectedAviary()
        {
            Console.Clear();

            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1} -  {_aviaries[i].Name}");
            }

            int.TryParse(Console.ReadLine(), out int numberAvary);
            Console.Clear();

            if (0 < numberAvary && numberAvary - 1 < _aviaries.Count)
            {
                _aviaries[numberAvary - 1].ShowInfo();
            }
            else
            {
                Console.WriteLine("Вывели не правильное значение вольера попробуйте заново");
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        private List<string> _soundsAnimals = new List<string>();
        private int _randomGender;
        private int _randomSound;
        private int _genderNumberFist;
        private int _genderNumberSecond;
        private string _genderFist;
        private string _genderSecond;
        private string _genderAnimal;
        private string _soundAnimal;

        public Aviary(string nameAviary, string nameAnimal, int numberAnimal)
        {
            _genderFist = "Мужской пол";
            _genderSecond = "Женский пол";
            _genderAnimal = "";
            _genderNumberFist = 0;
            _genderNumberSecond = 1;
            Name = nameAviary;
            NumberAnimal = numberAnimal;
            Random random = new Random();
            _soundsAnimals.Add("Рычат");
            _soundsAnimals.Add("Цокают");
            _soundsAnimals.Add("Брыгаются");
            _soundsAnimals.Add("Харкаются");
            _soundsAnimals.Add("Зевают");
            _soundsAnimals.Add("Хлопают в ладоши");
            _soundsAnimals.Add("Скрипят зубами");
            CreateAnimals(random, nameAnimal);
        }

        public string Name { get; private set; }
        public int NumberAnimal { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Вольер - {Name}\nКоличество животных {_animals.Count}");

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"{_animals[i].Gender} \nЗвук - {_animals[i].SoundAnimal}\nТип животного - {_animals[i].Name}");
            }
        }

        private void CreateAnimals(Random random, string nameAnimal)
        {
            for (int i = 0; i < NumberAnimal; i++)
            {
                _randomGender = random.Next(_genderNumberFist, _genderNumberSecond + 1);
                _randomSound = random.Next(0, _soundsAnimals.Count);
                _soundAnimal = _soundsAnimals[_randomSound];

                if (_randomGender == _genderNumberFist)
                {
                    _genderAnimal = _genderFist;
                }
                else if (_randomGender == _genderNumberSecond)
                {
                    _genderAnimal = _genderSecond;
                }

                Animal animal = new Animal(_genderAnimal, _soundAnimal, nameAnimal);
                _animals.Add(animal);
            }
        }
    }

    class Animal
    {
        public Animal(string gender, string sound, string name)
        {
            Gender = gender;
            SoundAnimal = sound;
            Name = name;
        }

        public string Name { get; private set; }
        public string SoundAnimal { get; private set; }
        public string Gender { get; private set; }
    }
}
