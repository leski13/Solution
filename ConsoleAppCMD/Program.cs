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
            Console.WriteLine("Add gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Add Birthdate");
            var birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Add weight");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Add geight");
            var height = double.Parse(Console.ReadLine());
            var userController = new User_Controller(name, gender, birthdate, weight, height);
            userController.Save();
        }
    }
}
