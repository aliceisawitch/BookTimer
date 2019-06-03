using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace BookTimer.Models
{
    class Book
    {   [PrimaryKey,AutoIncrement]

         public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string SmallThumbnail { get; set; }
        
        public string Time { get; set; }
    }
}
