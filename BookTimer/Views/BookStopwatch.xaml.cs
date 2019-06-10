using BookTimer.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookTimer.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class BookStopwatch : Page

    {
       static DispatcherTimer timer = new DispatcherTimer();
    
        TimeSpan timeSpan =
    timer.Interval = TimeSpan.FromSeconds(1);
        private bool isActive=false;

        public BookStopwatch()
        {
            Book chosenBook = YourLibraryPage.chosenBook;
            System.Diagnostics.Debug.WriteLine("Book Passed from Library: " + chosenBook.ToString());
            this.DataContext = chosenBook;
            
            this.InitializeComponent();
           System.Diagnostics.Debug.WriteLine( chosenBook.Author.ToString());
            tbTimer.Text = ""+getTimeSpanFromSeconds(chosenBook.Time);
            



        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
           if(isActive==false)
            {
                timer.Tick -= timeTicker;
                timer.Tick += timeTicker;

                timer.Start();
                isActive = true;

            }



        }
        static TimeSpan getTimeSpanFromSeconds(int seconds)
        {
          
            TimeSpan timeSpan = new TimeSpan(0,0,seconds);


            return timeSpan;
        }
        private int seconds = YourLibraryPage.chosenBook.Time;

        private void LibraryNavigation_Click(object sender, RoutedEventArgs e)
        {
          
            this.Frame.Navigate(typeof(YourLibraryPage));
            
        }

        private void timeTicker(object sender, object e)
        {
           
           
            seconds++;
            

           tbTimer.Text="" +getTimeSpanFromSeconds(seconds);
            System.Diagnostics.Debug.WriteLine(seconds);
          
            
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
           int timerValue = seconds;
            timer.Stop();
           
            Book chosenBook = YourLibraryPage.chosenBook;
            Database db = new Database();
            db.GetConnection();
        
            db.UpdateBookRows(chosenBook,timerValue);
            db.Close();
            isActive = false;
            //YourLibraryPage.chosenBook.Time = seconds;

        }

    }

}