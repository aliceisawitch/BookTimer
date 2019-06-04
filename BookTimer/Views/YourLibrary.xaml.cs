﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BookTimer.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookTimer.Views
{

    public sealed partial class YourLibraryPage : Page
    {
        Database db = new Database();
        List<Book> books = new List<Book>();
        public static Book chosenBook;

        public YourLibraryPage()
        {

             
            this.InitializeComponent();
            AddBookPage.adChosen.Add(new Book("Test Title", "Test Author", "http://books.google.com/books/content?id=V-zPAAAAIAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"));
            
            ListOFBooks.ItemsSource = AddBookPage.adChosen;

        }

        private void ButtonAddBookPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddBookPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookStopwatch));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            AddBookPage.adChosen.Remove((Book)ListOFBooks.SelectedItem);
            ListOFBooks.ItemsSource = null;
            ListOFBooks.ItemsSource = AddBookPage.adChosen;
            ListOFBooks.SelectedItem = 0;
        }

        private void Watch_Click(object sender, RoutedEventArgs e)
        {
            chosenBook = (Book)ListOFBooks.SelectedItem;
            this.Frame.Navigate(typeof(BookStopwatch));
        }
    }
}
