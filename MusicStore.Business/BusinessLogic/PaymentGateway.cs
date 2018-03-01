using System;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;

namespace MusicStore.Business.BusinessLogic
{
    public class PaymentGateway : IPaymentGateway
    {
        public PaymentGateway() { }
        public string FetchedCustomerDetails(CustomerDetails customerDetails)
        {
       
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
            string apiSecret = System.Configuration.ConfigurationManager.AppSettings["ApiSecret"];
            string accountNumber = System.Configuration.ConfigurationManager.AppSettings["accountNumber"];
            int currencyBaseUnitsMultiplier = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrencyBaseUnitsMultiplier"]);
            string currencyCode = System.Configuration.ConfigurationManager.AppSettings["CurrencyCode"];
            string merchant_ref_num = System.Guid.NewGuid().ToString();
            return "hello";
       
        }

        
    }
}
