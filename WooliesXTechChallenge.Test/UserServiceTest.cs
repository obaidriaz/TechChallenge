using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXTechChallenge.API.Controllers;
using WooliesXTechChallenge.API.Models;
using WooliesXTechChallenge.API.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WooliesXTechChallenge.Test
{
    [TestClass]
    public class UserServiceTest
    {
        /// <summary>
        /// This method will test the GetUser Method. It will return the name and token of the user.
        /// </summary>
        [TestMethod]
        public void TestGetUser()
        {
            //Act
            var user = new UserService().GetUser();            

            //Assert
            Assert.AreEqual(user.Name, "Obaid Riaz");
            Assert.IsTrue(user.Token.Length > 0);            
        }        
    }
}
