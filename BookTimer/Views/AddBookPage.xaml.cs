using BookTimer.GoogleBooksApiCnct;
using BookTimer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookTimer.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 
    public sealed partial class AddBookPage : Page
    {
        Database db = new Database();
        static Windows.Web.Http.HttpClient httpClient;
        public AddBookPage()
        {
            this.InitializeComponent();
            
            // This part was added to display application on windows same way as on mobile
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            
           
        }

        private void YourLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(YourLibraryPage));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            httpClient = new Windows.Web.Http.HttpClient();
            APIconnection apiConnection = new APIconnection(httpClient);
            apiConnection.LoadGoogleData(tbAuthor.Text, tbTitle.Text);
            List<Book> books = apiConnection.GetBooks();
            addListView.ItemsSource = books;
            //var add = db.createTable().Insert(new Book() { Title = tbTitle.Text, Author = tbAuthor.Text, Time = "" });

        }

        

            
        }
    }

