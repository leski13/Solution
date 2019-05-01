﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new User_Controller(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 100));
            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));
            //Assert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}