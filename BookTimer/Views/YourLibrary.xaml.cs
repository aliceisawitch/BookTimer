using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BookTimer.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class YourLibraryPage : Page
    {
        Database db = new Database();
        List<Book> books = new List<Book>();
        public static Book chosenBook;

        public YourLibraryPage()
        {


            this.InitializeComponent();
            Database db = new Database();
            db.GetConnection();
            ListOFBooks.ItemsSource = db.getBooks();
            db.Close();

        }

        private void ButtonAddBookPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddBookPage));
        }

       //// private void Button_Click(object sender, RoutedEventArgs e)
       // {
        //    this.Frame.Navigate(typeof(BookStopwatch));
      //  }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {


           
            var messageDialog = new MessageDialog("Would you like to remove this book from your library?");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.removeFromDbInvokeHandler)));
            messageDialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.removeFromDbInvokeHandler)));
            await messageDialog.ShowAsync();
           




        }
        private void removeFromDbInvokeHandler(IUICommand command)
        {
            if(command.Label=="Yes")
            {
                Database db = new Database();
                db.GetConnection();
                db.DeleteBookFrDb((Book)ListOFBooks.SelectedItem);
                ListOFBooks.ItemsSource = db.getBooks();
                db.Close();
            }
           
        }
        private  void Watch_Click(object sender, RoutedEventArgs e)
        {
           
                chosenBook = (Book)ListOFBooks.SelectedItem;

                this.Frame.Navigate(typeof(BookStopwatch), chosenBook);
            
      
           
        }
    }
}
