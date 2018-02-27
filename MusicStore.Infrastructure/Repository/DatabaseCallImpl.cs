
using System.Collections.Generic;
using System.Web;
using MusicStore.Core.Models;
using System.Web.Script.Serialization; // for serialize and deserialize  
using System.IO; // for File operation 
using Newtonsoft.Json;
using MusicStore.Data;
using System.Linq;
using MusicStore.Core.Interfaces.Repository;
using System.Reflection;

namespace MusicStore.Infrastructure.Repository
{
    public class DatabaseCallImpl : IDatabaseCalls
    {
        public DatabaseCallImpl() { }

        public string AddToCart(DataContentsModel dataset)
        {
           
          
            var jsonList = GetAllData("~/App_Data/Cart.json");
            jsonList.Add(dataset);
           string response= WriteData(jsonList, "~/App_Data/Cart.json");
         
            return response;
        }

        public string RemoveFromCart(int Id)
        {
            System.Console.Write(Id);
            var jsonList = GetAllData("~/App_Data/Cart.json");
            if (!jsonList.Any())
            {
                return "cart is empty";
            }
            DataContentsModel item = jsonList.First(x => x.Id== Id);
            jsonList.Remove(item);
            WriteData(jsonList, "~/App_Data/Cart.json");
            return "successfull";
        }

        public List<DataContentsModel> GetAllData(string Url)
        {


            string file = HttpContext.Current.Server.MapPath(Url);
            //deserialize JSON from file  
            string data = File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var songlist = JsonConvert.DeserializeObject<List<DataContentsModel>>(data);
            return songlist;
        }

        private string WriteData(List<DataContentsModel> dataset,string url)
        {

            string json = JsonConvert.SerializeObject(dataset);

            //write string to file
            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(url), json);

            return "SUCCESSFULL";
        }


    }
}