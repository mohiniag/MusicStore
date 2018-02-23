using MusicStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Models;
using System.Web.Script.Serialization; // for serialize and deserialize  
using System.IO; // for File operation 
using Newtonsoft.Json;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace MusicStore.Service
{
    public class DatabaseCallImpl : DatabaseCalls
    {
        public DatabaseCallImpl() { }
        public List<DataContentsModel> getAllData(string Url)
        {

          
              string file = HttpContext.Current.Server.MapPath(Url);
            //deserialize JSON from file  
            string data = File.ReadAllText(file);
           JavaScriptSerializer ser = new JavaScriptSerializer();
           var songlist = JsonConvert.DeserializeObject < List<DataContentsModel>>(data);
            return songlist;
        }


        public string writeData(DataContentsModel dataset)
        {

            var jsonList = getAllData("~/App_Data/Cart.json");
            jsonList.Add(dataset);
           
            string json = JsonConvert.SerializeObject(jsonList);

            //write string to file
            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/App_Data/Cart.json"), json);

            return "successful";
        }


    }
}