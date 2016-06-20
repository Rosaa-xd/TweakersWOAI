using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    /// <summary>
    /// Summary description for TestAsset
    /// </summary>
    [TestClass]
    public class TestAsset
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used declared
            Asset asset;
            int assetId;
            AssetType assetType;
            string assetExplanation;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    asset = new Asset(1, AssetType.Positive, "This is a test explanation");

                    // Act
                    assetId = asset.ID;
                    assetType = asset.Type;
                    assetExplanation = asset.Explanation;

                    // Assert
                    Assert.AreEqual(1, assetId);
                    Assert.AreEqual(AssetType.Positive, assetType);
                    Assert.AreEqual("This is a test explanation", assetExplanation);
                }
                if (i == 1)
                {
                    // Arrange
                    asset = new Asset(AssetType.Positive, "This is a test explanation");

                    // Act
                    assetType = asset.Type;
                    assetExplanation = asset.Explanation;

                    // Assert
                    Assert.AreEqual(AssetType.Positive, assetType);
                    Assert.AreEqual("This is a test explanation", assetExplanation);
                }
            }
        }
    }
}
