using ClassLibrary.Controller;
using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-en");
            var resourceManager = new ResourceManager("ConsoleAppCMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("AddUserName", culture));
            var name = Console.ReadLine();
            var userController = new User_Controller(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("birthdate");
                double weight = ParseDouble("Weight");
                double height = ParseDouble("Height");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            while(true)
            {
            Console.WriteLine("What do you do?");
            Console.WriteLine("E = new eating");
            Console.WriteLine("W = new exercise");
            Console.WriteLine("Q = exit");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);
                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t {item.Key} - {item.Value}");
                    }
                    break;
                case ConsoleKey.W:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.begin, exe.end);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} do {item.Finish.ToShortTimeString()}");
                        }
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
            Console.ReadLine();
            }
    }

        private static (DateTime begin, DateTime end, Activity Activity) EnterExercise()
        {
            Console.Write("Name exercise: ");
            var name = Console.ReadLine();
            var begin = ParseDateTime("begin exercise");
            var end = ParseDateTime("end exercise");
            var energy = ParseDouble("Energy cost of 1 minutes");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Add name products ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var prots = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");

            var weight = ParseDouble("weight portion");
            var product = new Food(food, prots, fats, carbohydrates, calories);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            while (true)
            {
                Console.Write($"Введите {value} (дд.мм.гггг.): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {

                    return birthDate;
                    //break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }
        }

        private static double ParseDouble(string name)
        {
            while(true)
            {
                Console.Write($"Введите {name}: ");
                if(double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name} ");
                }
            }
        }
    }
}
