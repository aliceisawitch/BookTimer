﻿using BookTimer.GoogleBooksApiCnct;
using BookTimer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Windows.UI.Popups;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookTimer.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 
    public sealed partial class AddBookPage : Page
    {
        //list of books returned from API call
        List<Book> books;
        // list of books added to User Library
        public static List<Book> adChosen = new List<Book>();
        //htttpClient for api call
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

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            httpClient = new Windows.Web.Http.HttpClient();
            APIconnection apiConnection = new APIconnection(httpClient);
            //asynchronous loading data from google Api
            Task waitForGoogleData = apiConnection.LoadGoogleData(tbAuthor.Text, tbTitle.Text);
            try
            {
                //wait with list of books atribution untill api return list
                await waitForGoogleData;
                //list of books from GA
                books = apiConnection.GetBooks();
                //<log>
                foreach (Book book in books)
                {
                    System.Diagnostics.Debug.WriteLine("BookAsynch: " + book.Title + " " + book.Author + " " + book.SmallThumbnail);
                }
                //<log/>
                LbxBooks.ItemsSource = apiConnection.GetBooks();
            }
            catch (System.NullReferenceException ex) { };
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            //wait for user confimation
            var messageDialog = new MessageDialog("Would you like to add this book to your library?");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.SaveToDbInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.SaveToDbInvokedHandler)));
            await messageDialog.ShowAsync();
            
        }

        private void SaveToDbInvokedHandler(IUICommand command)
        {
            if (command.Label == "Yes")
            {
                System.Diagnostics.Debug.WriteLine("book selected to add to db:"+((Book)LbxBooks.SelectedItem).ToString());
                //add chosen book to db 
                Database db = new Database();
                db.GetConnection();
                db.AddBookToDB((Book)LbxBooks.SelectedItem);
                db.Close();
            }
            
        }

        private void LbxBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }

