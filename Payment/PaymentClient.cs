using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections;
using System.Web.Mvc;
using MusicStore.Core.Interfaces;
using System.Web;

namespace Payment
{
    public class PaymentClient: Repository.IPaymentClient
    {

        public void MakePayment(string strNVP, string strNVPSandboxServer)
        {
            try
            {
                //Create web request and web response objects, 
                //make sure you using the correct server (sandbox/live)
                HttpWebRequest wrWebRequest = (HttpWebRequest)WebRequest.Create(strNVPSandboxServer);
                wrWebRequest.Method = "POST";
                StreamWriter requestWriter = new StreamWriter(wrWebRequest.GetRequestStream());
                requestWriter.Write(strNVP);
                requestWriter.Close();

                // Get the response.
                HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();
                StreamReader responseReader =
                    new StreamReader(wrWebRequest.GetResponse().GetResponseStream());

                //and read the response
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();

                string result = HttpContext.Current.Server.UrlDecode(responseData);

                string[] arrResult = result.Split('&');
                Hashtable htResponse = new Hashtable();
                string[] responseItemArray;
                foreach (string responseItem in arrResult)
                {
                    responseItemArray = responseItem.Split('=');
                    htResponse.Add(responseItemArray[0], responseItemArray[1]);
                }

                string strAck = htResponse["ACK"].ToString();

                //strAck = "Success";

                if (strAck == "Success" || strAck == "SuccessWithWarning")
                {
                    string strAmt = htResponse["AMT"].ToString();
                    string strCcy = htResponse["CURRENCYCODE"].ToString();
                    string strTransactionID = htResponse["TRANSACTIONID"].ToString();

                    //SaveOrder();
                    //Send Email

                    string strSuccess = "Thank you, your order for: $" +
                        strAmt + " " + strCcy + " has been processed.";
                }


                else
                {

                    string error = "Error code: " + htResponse["L_ERRORCODE0"].ToString();

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }


        }
       
    }
}
