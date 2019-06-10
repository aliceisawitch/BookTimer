using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace BookTimer.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string SmallThumbnail { get; set; }
        public TimeSpan timeSpan { get; set; }
        public int time;




    
        public Book()
        {

        }
        public Book(string Title, string Author, string smallThumbnail)
        {
            this.Author = Author;
            this.Title = Title;
            this.SmallThumbnail = smallThumbnail;
            this.timeSpan = TimeSpan.Zero;
            this.time = 0;
           

        }

        public Book(int id, string title, string author, string smallThumbnail,int time)
        {
            Id = id;
            Title = title;
            Author = author;
            SmallThumbnail = smallThumbnail;
           
            this.timeSpan = TimeSpan.FromSeconds((double)time); 
        }
        public override string ToString()
        {
           
            return "BookToString: " + this.Id + " " + this.Author + " " + this.Title + " " + this.timeSpan.ToString() + " " + this.SmallThumbnail;
        }

    }
}
