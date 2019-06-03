using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace BookTimer.Models
{
    class Book
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string SmallThumbnail { get; set; }

        public TimeSpan Time { get; set; }

        public Book(string Title, string Author, string smallThumbnail)
        {
            this.Author = Author;
            this.Title = Title;
            this.SmallThumbnail = smallThumbnail;
            this.Time = TimeSpan.Zero;
        }

        public override string ToString()
        {
            return "BookToString: " + this.Id + " " + this.Author + " " + this.Title + " " + this.Time.ToString() + this.SmallThumbnail;
        }
    }
}
