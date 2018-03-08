using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Controllers;
using MusicStore.Core.Models;
using System.Web.Mvc;

namespace MusicStore.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        

        [TestMethod]
        public void Index()
        {
            // Arrange
            CartController controller = new CartController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddtoCartDataNotFound()
        {
            // Arrange
            CartController controller = new CartController();

            // Act
            DataContentsModel dataContentModel = SetModelData();
            string response = controller.Index(dataContentModel);
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response, "Cart data not available");
        }
        [TestMethod]
        public void RemovefromCartDataNotFound()
        {
            // Arrange
            CartController controller = new CartController();

            // Act
            string response = controller.RemoveItem(35);
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response, "Cart is empty");
        }

        private DataContentsModel SetModelData()
        {
            DataContentsModel dataContentModel = new DataContentsModel();
            dataContentModel.Id = 35;
            dataContentModel.Artist = "Fresh Moods";
            dataContentModel.Title = "Aground";
            dataContentModel.Price = 25.0M;
            dataContentModel.Duration = "03.40 min";
            dataContentModel.ImageUrl = "../Content/Images/aground.jpeg";
            dataContentModel.Genre = "Jazz";
            return dataContentModel;
        }
    }
}
