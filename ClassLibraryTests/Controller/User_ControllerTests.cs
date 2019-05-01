using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Controller.Tests
{
    [TestClass()]
    public class User_ControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var gender = "man";
            var weight = 96;
            var height = 195;
            var controller = new User_Controller(userName);
            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new User_Controller(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new User_Controller(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}