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
        private const string CommandSelectAviary = "1";
        private const string CommandExit = "2";
        private bool _isWork = true;
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            _aviaries.Add(new Aviary("Львы", "Лев", 5, "Рычат", 2, 3));
            _aviaries.Add(new Aviary("Антилопы", "Антилопа", 3, "Цокают", 1, 2));
            _aviaries.Add(new Aviary("Зебры", "Зебра", 7, "Брыгаются", 5, 2));
            _aviaries.Add(new Aviary("Верблюды", "Верблюд", 9, "Харкаются", 7, 2));
            _aviaries.Add(new Aviary("Бегемоты", "Бегемот", 2, "Зевают", 1, 1));
            _aviaries.Add(new Aviary("Пингвины", "Пингвин", 10, "Хлопают в ладоши", 5, 5));
            _aviaries.Add(new Aviary("Крокодилы", "Крокодил", 2, "Скрипят зубами", 1, 1));
        }

        public void Start()
        {
            while (_isWork == true)
            {
                Console.WriteLine($"Добро пожаловать в зоопарк.\nДля того чтоб подойти к вольеру напишите {CommandSelectAviary}.\nЕсли вы хотите выйти из зоопарка напишите {CommandExit}");

                switch (Console.ReadLine())
                {
                    case CommandSelectAviary:
                        SelectAviary();
                        break;
                    case CommandExit:
                        Console.WriteLine("Вы вышли из программы");
                        _isWork = false;
                        break;
                    default:
                        Console.WriteLine("Выберите к какому вольеру подойти или уйдите из Зоопарка");
                        break;
                }
            }
        }

        private void SelectAviary()
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
        private string _genderFist;
        private string _genderSecond;

        public Aviary(string nameAviary, string nameAnimal, int numberAnimal, string soundAnimal, int numberAnimalFirstGender, int numberAnimalSecondGender)
        {
            _genderFist = "Мужской пол";
            _genderSecond = "Женский пол";
            Name = nameAviary;
            NumberAnimal = numberAnimal;
            CreateAnimals(nameAnimal, soundAnimal, numberAnimalFirstGender, numberAnimalSecondGender);
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

        private void CreateAnimals(string nameAnimal, string soundAnimal, int numberAnimalFirstGender, int numberAnimalSecondGender)
        {
            CreateAnimal(numberAnimalFirstGender, _genderFist, soundAnimal, nameAnimal);
            CreateAnimal(numberAnimalSecondGender, _genderSecond, soundAnimal, nameAnimal);
        }

        private void CreateAnimal(int numberAnimal, string nameGender, string soundAnimal, string nameAnimal)
        {
            for (int i = 0; i < numberAnimal; i++)
            {
                Animal animal = new Animal(nameGender, soundAnimal, nameAnimal);
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
