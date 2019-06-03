using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BookTimer.Views;
using BookTimer.GoogleBooksApiCnct;
using System.Xml.Linq;
using BookTimer.Models;
using System.Diagnostics;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookTimer.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 
    public sealed partial class AddBookPage : Page
    {
       
        static Windows.Web.Http.HttpClient httpClient;
        public AddBookPage()
        {
            this.InitializeComponent();
            
            // This part was added to display application on windows same way as on mobile
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
<<<<<<< HEAD
            
           
=======
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "bookdb.sqlite");
            try
            {
                con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

                con.CreateTable<Book>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Database error: " + ex.Message);
            };
>>>>>>> f73264b0ffa49dad226370639744baa27edf3872
        }

        private void YourLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(YourLibraryPage));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            httpClient = new Windows.Web.Http.HttpClient();
            APIconnection apiConnection = new APIconnection(httpClient);
            apiConnection.LoadGoogleData();
            List<Book> books = apiConnection.GetBooks();
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
           // var add = con.Insert(new Book() {Title=tbTitle.Text, Author=tbAuthor.Text, Time="" });
            //Debug.WriteLine(path);
=======
            //var add = con.Insert(new Book() {Title=tbTitle.Text, Author=tbAuthor.Text, Time="" });
            Debug.WriteLine(path);
>>>>>>> f73264b0ffa49dad226370639744baa27edf3872
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
           

        }

            
        }
    }

