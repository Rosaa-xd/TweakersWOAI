using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestCategory
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used declared
            Category category;
            int categoryId;
            string categoryName;
            Category categoryParent;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    category = new Category(1, "Basiscomponenten");

                    // Act
                    categoryId = category.ID;
                    categoryName = category.Name;

                    // Assert
                    Assert.AreEqual(1, categoryId);
                    Assert.AreEqual("Basiscomponenten", categoryName);
                }
                if (i == 1)
                {
                    // Arrange
                    Category pCategory = new Category(1, "Basiscomponenten");
                    category = new Category(2, "CPU", pCategory);

                    // Act
                    categoryId = category.ID;
                    categoryName = category.Name;
                    categoryParent = category.ParentCategory;

                    // Assert
                    Assert.AreEqual(2, categoryId);
                    Assert.AreEqual("CPU", categoryName);
                    Assert.AreEqual(pCategory, categoryParent);
                }
            }
        }
    }
}
