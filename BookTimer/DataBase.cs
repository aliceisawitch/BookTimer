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
        public static SQLite.Net.SQLiteConnection con;
        public SQLite.Net.SQLiteConnection Polacz()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "bookdb.sqlite");

            con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

           // con.CreateTable<Book>();

            return con;

        }
    }
}
