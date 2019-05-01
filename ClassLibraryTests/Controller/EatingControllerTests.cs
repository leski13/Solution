using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Model;

namespace ClassLibrary.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new User_Controller(userName);
            var eatingCont = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(10, 100), rnd.Next(10, 100), rnd.Next(10, 100), rnd.Next(100, 1000));
            //Act
            eatingCont.Add(food, 100);
            //Assert
            //Assert.AreEqual(food.Name, eatingCont.Eating.Foods.First().Key.Name);
        }
    }
}