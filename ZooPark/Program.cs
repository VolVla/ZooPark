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
            bool isWork = true;
            bool selectionAviary = true;
            int minimumValue = 0;
            string genderMan = "Мужской пол";
            string genderGirl = "Женский пол";
            List<Aviary> aviaries = new List<Aviary>() { new Aviary("Львы", 10, genderMan, "Рычат"), new Aviary("Антилопы", 5, genderGirl, "Цокают"), new Aviary("Зебры", 3, genderGirl, "Брыгаются"), new Aviary("Верблюды", 4, genderMan, "Харкаются"), new Aviary("Бегемоты", 6, genderMan, "Зевают"), new Aviary("Пингвины", 7, genderMan, "Хлопают в ладоши"), new Aviary("Крокодилы", 8, genderMan, "Скрипят зубами") };

            while (isWork)
            {
                Console.WriteLine("Добро пожаловать в зоопарк.\nВыберите к какому вольеру подойти");

                for (int i = 0; i < aviaries.Count; i++)
                {
                    Console.WriteLine($"{i + 1} -  {aviaries[i].NameAviary}");
                }

                while (selectionAviary == true)
                {
                    int.TryParse(Console.ReadLine(), out int numberAvary);

                    if (minimumValue < numberAvary && numberAvary - 1 < aviaries.Count)
                    {
                        aviaries[numberAvary - 1].ShowInfo();
                        selectionAviary = false;
                    }
                    else
                    {
                        Console.WriteLine("Вывели не правильное значение вольера попробуйте заново");
                    }
                }

                Console.WriteLine($"Вы хотите выйти из программы?Нажмите Enter.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    isWork = false;
                    Console.WriteLine("Вы вышли из программы");
                }

                selectionAviary = true;
                Console.Clear();
            }
        }
    }

    class Aviary
    {
        public string NameAviary { get; set; }
        public string SoundAnimal { get; set; }
        public string Gender { get; set; }
        public int NumberAnimal { get; set; }

        public Aviary(string nameAviary, int numberAnimal, string gender, string soundAnimal)
        {
            NameAviary = nameAviary;
            NumberAnimal = numberAnimal;
            Gender = gender;
            SoundAnimal = soundAnimal;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Вольер - {NameAviary}\n{NumberAnimal} - животных \n{Gender} \nЗвук - {SoundAnimal} ");
        }
    }

}
