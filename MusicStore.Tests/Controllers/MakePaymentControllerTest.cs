using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Controllers;
using MusicStore.Core.Models;
using System.Web.Mvc;

namespace MusicStore.Tests.Controllers
{
    [TestClass]
    public class MakePaymentControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            MakePaymentController controller = new MakePaymentController();

            // Act
            ViewResult result = controller.Index(25) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void pay()
        {
            // Arrange
            MakePaymentController controller = new MakePaymentController();

            // Act
            CustomerDetails customerDetails = SetModelData();
            ViewResult result = controller.pay(customerDetails) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        private CustomerDetails SetModelData()
        {
            CustomerDetails customerDetails = new CustomerDetails();
            customerDetails.FirstName = "Mohini";
            customerDetails.LastName = "Agarwal";
            customerDetails.payableAmount = "25.0";
            customerDetails.Address = "3/D Park avenue";
            customerDetails.CardCCVNo = "134";
            customerDetails.CardExpiryMonth = "Dec";
            customerDetails.CardExpiryYear = "2018";
            customerDetails.CardNo = "1234567889234566";
            customerDetails.EmailId = "mohini@gmail.com";
            customerDetails.PhoneNo = "8860993898";
            customerDetails.State = "NY";
            return customerDetails;
        }

    }
}
