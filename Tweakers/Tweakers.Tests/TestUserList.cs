using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestUserList
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used delcared
            UserList userList;
            int userListId;
            string userListName;
            UserListType userListType;
            User userListUser;
            List<Product> userListProducts;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    userList = new UserList("test", UserListType.Inventory, user);

                    // Act
                    userListName = userList.Name;
                    userListType = userList.Type;
                    userListUser = userList.User;

                    // Assert
                    Assert.AreEqual("test", userListName);
                    Assert.AreEqual(UserListType.Inventory, userListType);
                    Assert.AreEqual(user, userListUser);
                }
                if (i == 1)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    List<Product> products = new List<Product>();
                    userList = new UserList(1, "test", UserListType.Inventory, user, products);

                    // Act
                    userListId = userList.ID;
                    userListName = userList.Name;
                    userListType = userList.Type;
                    userListUser = userList.User;
                    userListProducts = userList.Products;

                    // Assert
                    Assert.AreEqual(1, userListId);
                    Assert.AreEqual("test", userListName);
                    Assert.AreEqual(UserListType.Inventory, userListType);
                    Assert.AreEqual(user, userListUser);
                    Assert.AreEqual(products, userListProducts);
                }
                if (i == 2)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    List<Product> products = new List<Product>();
                    userList = new UserList("test", UserListType.Inventory, user, products);

                    // Act
                    userListName = userList.Name;
                    userListType = userList.Type;
                    userListUser = userList.User;
                    userListProducts = userList.Products;

                    // Assert
                    Assert.AreEqual("test", userListName);
                    Assert.AreEqual(UserListType.Inventory, userListType);
                    Assert.AreEqual(user, userListUser);
                    Assert.AreEqual(products, userListProducts);
                }
            }
        }
    }
}
