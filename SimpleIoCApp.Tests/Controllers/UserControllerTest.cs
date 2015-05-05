using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleIoCApp.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleIoCApp.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<IUserService> _userServiceMock;
        UsersController objController;
        List<User> listUser;

        [TestInitialize]
        public void Initialize()
        {

            _userServiceMock = new Mock<IUserService>();
            objController = new UsersController(_userServiceMock.Object);
            listUser = new List<User>() {
           new User() { Id = 1, UserName = "Anoop" },
           new User() { Id = 2, UserName = "Varghese" },
           new User() { Id = 3, UserName = "Arun" }
          };
        }

        [TestMethod]
        public void Users_All()
        {
            //Arrange
            _userServiceMock.Setup(x => x.GetAll()).Returns(listUser);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<User>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("Anoop", result[0].UserName);
            Assert.AreEqual("Varghese", result[1].UserName);
            Assert.AreEqual("Arun", result[2].UserName);
        }

        [TestMethod]
        public void Users_Create()
        {
            //Arrange
            User c = new User() { UserName = "Anoop2" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert 
            _userServiceMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Invalid_User_Create()
        {
            // Arrange
            User c = new User() { UserName = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _userServiceMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
 
    }
}
