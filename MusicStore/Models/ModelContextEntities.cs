using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class ModelContextEntities
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public decimal Duration { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        
    }
}