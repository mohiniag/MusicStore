using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;
using System.Configuration;
using Payment.PaymentClient;

namespace MusicStore.Business.PaymentGateway
{
   public class PaymentGateway : IPaymentGateway
    {
        private readonly IPaymentClient paymentClient;

        public PaymentGateway() {}
        public PaymentGateway(IPaymentClient paymentClient)
        {
            this.paymentClient = paymentClient;
        }
        public string FetchedCustomerDetails(CustomerDetails customerDetails)
        {

            string strUsername = ConfigurationManager.AppSettings["InStoreAPIUsername"].ToString();
            string strPassword = ConfigurationManager.AppSettings["InStoreAPIPassword"].ToString();
            string strSignature = ConfigurationManager.AppSettings["InStoreAPISignature"].ToString();
            string strCredentials = "USER=" + strUsername +
            "&PWD=" + strPassword + "&SIGNATURE=" + strSignature;
            string strNVPSandboxServer =
               ConfigurationManager.AppSettings["NVPSandboxServer"].ToString();

            string strAPIVersion = "60.0";
            string strNVP = "METHOD=DoDirectPayment" +
                           "&VERSION=" + strAPIVersion +
                           "&PWD=" + strPassword +
                           "&USER=" + strUsername +
                           "&SIGNATURE=" + strSignature +
                           "&PAYMENTACTION=Sale" +
                           "&IPADDRESS="+customerDetails.customerIp +
                           "&RETURNFMFDETAILS=0" +
                           "&CREDITCARDTYPE=" + "Visa" +
                           "&ACCT=" + "4111111111111111" +
                           "&EXPDATE=" + customerDetails.CardExpiryMonth + customerDetails.CardExpiryYear +
                           "&CVV2=" + customerDetails.CardCCVNo +
                           "&STARTDATE=" +
                           "&ISSUENUMBER=" +
                           "&EMAIL="+customerDetails.EmailId +
                           //the following  represents the billing details
                           "&FIRSTNAME=" + customerDetails.FirstName+
                           "&LASTNAME=" + customerDetails.LastName+
                           "&STREET=" +customerDetails.Address+
                           "&STREET2=" + "" +
                           "&CITY=" + "Memphsis" +
                           "&STATE=" + "TN" +
                           "&COUNTRYCODE=US" +
                           "&ZIP=" + "38134" +
                           "&AMT=" +customerDetails.payableAmount
                           +//orderdetails.GrandTotal.ToString("0.0")+
                           "&CURRENCYCODE=USD" +
                           "&DESC=Test Sale Tickets" +
                           "&INVNUM=" + "";
           
            string response=paymentClient.MakePayment(strNVP, strNVPSandboxServer);
            return response;
        }
    }
}
