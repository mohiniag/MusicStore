using System.Collections.Generic;
using System.Web;
using MusicStore.Core.Models;
using System.Web.Script.Serialization; // for serialize and deserialize  
using System.IO; // for File operation 
using Newtonsoft.Json;
using System.Linq;
using MusicStore.Core.Interfaces.Repository;
using System;

namespace MusicStore.Infrastructure.Repository
{
    public class DatabaseCallImpl : IDatabaseCalls
    {
        public DatabaseCallImpl() { }

        public string AddToCart(DataContentsModel dataset)
        {


            var jsonList = GetAllData("~/App_Data/Cart.json");

            if (jsonList == null)
            {
                return "Cannot add to cart";
            }

            jsonList.Add(dataset);

            string response = WriteData(jsonList, "~/App_Data/Cart.json");

            if (response == "Successfull")
                return "Item added to cart";
            else
                return "Item cannot be added to the cart";
        }

        public string RemoveFromCart(int Id)
        {

            var jsonList = GetAllData("~/App_Data/Cart.json");
            if (!jsonList.Any() || jsonList == null)
            {
                return "Cart is empty";
            }
            DataContentsModel item = jsonList.First(x => x.Id == Id);
            jsonList.Remove(item);
            string response = WriteData(jsonList, "~/App_Data/Cart.json");
            if (response == "Successfull")
                return "Item removed from cart";
            else
                return "Item cannot be removed from cart";
        }

        public List<DataContentsModel> GetAllData(string Url)
        {

            try
            {
                string file = HttpContext.Current.Server.MapPath(Url);
                //deserialize JSON from file  
                string data = File.ReadAllText(file);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var songlist = JsonConvert.DeserializeObject<List<DataContentsModel>>(data);
                return songlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string WriteData(List<DataContentsModel> dataset, string url)
        {

            string json = JsonConvert.SerializeObject(dataset);

            //write string to file
            try
            {
                File.WriteAllText(HttpContext.Current.Server.MapPath(url), json);
                return "Successfull";
            }
            catch (Exception ex)
            {
                return "Unsuccessfull";
            }

        }


    }
}