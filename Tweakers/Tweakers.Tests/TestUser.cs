using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used declared
            User user;
            int userId;
            string userName;
            string userPassword;
            List<UserList> userUserLists;
            List<Review> userReviews;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    user = new User(1, "test", "test");

                    // Act
                    userId = user.ID;
                    userName = user.Name;
                    userPassword = user.Password;

                    // Assert
                    Assert.AreEqual(1, userId);
                    Assert.AreEqual("test", userName);
                    Assert.AreEqual("test", userPassword);
                }
                if (i == 1)
                {
                    // Arrange
                    List<UserList> userLists = new List<UserList>();
                    List<Review> reviews = new List<Review>();
                    user = new User("test", "test", userLists, reviews);

                    // Act
                    userName = user.Name;
                    userPassword = user.Password;
                    userUserLists = user.UserLists;
                    userReviews = user.Reviews;

                    // Assert
                    Assert.AreEqual("test", userName);
                    Assert.AreEqual("test", userPassword);
                    Assert.AreEqual(userLists, userUserLists);
                    Assert.AreEqual(reviews, userReviews);
                }
            }

        }
    }
}
