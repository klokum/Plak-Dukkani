using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.ViewModel.AlbumViewModels
{
    public class AlbumDetailVM  //Album.cs, Artist.cs, Genre.cs'den göstermek istediğimiz prop.ları aldık.
    {
        public int ID { get; set; } 
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public decimal Discount { get; set; }
        public string ArtistFullName { get; set; }    //Artist.cs
        public string GenreName { get; set; }     //Genre.cs
    }
}
