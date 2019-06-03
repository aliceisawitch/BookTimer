using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTimer.Models;
using BookTimer.Views;

namespace BookTimer
{
    class Database
    {
        public string path;
        public SQLite.Net.SQLiteConnection con;
        public SQLite.Net.SQLiteConnection createTable()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "bookdb.sqlite");

            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            con.CreateTable<Book>();
            
            return con;
            
            
           
            
        }
    }
}
