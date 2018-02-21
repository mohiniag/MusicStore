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
        public List<ModelContextEntities> getAllData()
        {

           // using (StreamReader r = new StreamReader("~/App_Data/Data.json"))
           // {
            //    var json = r.ReadToEnd();
           //     var songlist = JsonConvert.DeserializeObject<List<ModelContextEntities>>(json);
              //  return songlist;
          //  }
              string file = HttpContext.Current.Server.MapPath("~/App_Data/Data.json");
            //deserialize JSON from file  
            string data = File.ReadAllText(file);
           JavaScriptSerializer ser = new JavaScriptSerializer();
           var songlist = JsonConvert.DeserializeObject < List<ModelContextEntities>>(data);
            return songlist;
        }
    }
}