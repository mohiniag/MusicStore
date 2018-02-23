using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class DataContentsModel
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        
    }
}