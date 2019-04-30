using ClassLibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application FitnessTab");
            Console.WriteLine("Add UserName");
            var name = Console.ReadLine();           
            var userController = new User_Controller(name);
            if(userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("Weight");
                double height = ParseDouble("Height");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

            
            

        }
        private static DateTime ParseDateTime()
        {
            while (true)
            {
                Console.Write("Введите дату рождения (дд.мм.гггг.): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {

                    return birthDate;
                    //break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
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
                    Console.WriteLine($"Неверный формат ввода {name} ");
                }
            }
        }
    }
}
