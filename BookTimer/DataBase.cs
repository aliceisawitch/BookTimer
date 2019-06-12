using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTimer.Models;
using BookTimer.Views;
using SQLite.Net;

namespace BookTimer
{
    class Database
    {
        
        //public static SQLite.Net.SQLiteConnection con;
        //private SQLiteCommand sql_cmd;
        ////public static string BAZA_DANYCH_KSIAZI_PLIK= "bookdb.sqlite";
        //public static string BAZA_DANYCH_LACZKA = "Data Source=" + BAZA_DANYCH_KSIAZI_PLIK + ";Version=3;New=False;Compress=True;";


        public string path;
        //public static readonly string MockUpQuery = "INSERT INTO "main"."Book" ("Id", "Title", "Author", "SmallThumbnail", "Time") VALUES ('9', 'Test Title2', 'Test Author', 'http://books.google.com/books/content?id=V-zPAAAAIAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api', '20');";
        public static SQLite.Net.SQLiteConnection con;
        public static readonly string GetAllBooks = "";
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "bookdb.sqlite");

            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            return con;

        }

        public List<Book> getBooks()
        {
            var query = con.Table<Book>();
            try
            {
                List<Book> books = query.ToList<Book>();
                return books;
            }
            catch (System.MissingMethodException ex)
            {
                return new List<Book>(); 
            }
            
        }

        public Book getBook(string bookTitle)
        {
            var query = con.Table<Book>().Where(a => a.Title.Equals(bookTitle)).FirstOrDefault();
            Book book = new Book(query.Id, query.Title, query.Author, query.SmallThumbnail,query.Time);
            return book;
        }
        public Book getBook(int bookId)
        {
            var query = con.Table<Book>().Where(a => a.Id.Equals(bookId)).FirstOrDefault();
            Book book = new Book(query.Id, query.Title, query.Author, query.SmallThumbnail,query.Time);
            return book;
        }
        public void Close()
        {
            con.Close();
        }
        public void AddBookToDB(Book book)
        {
            con.Insert(book);
        }
        public void DeleteBookFrDb(Book book)
        {
            con.Delete(book);
        }
        public void UpdateBookRows(Book book, int seconds)
        {
            string sqlUpdate = "UPDATE Book SET Time='" + seconds + "' WHERE Id='" + book.Id + "'";
            con.Execute(sqlUpdate);
        }
    }
}
