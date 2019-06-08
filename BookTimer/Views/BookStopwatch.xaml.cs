﻿using BookTimer.Models;
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
        DispatcherTimer timer = new DispatcherTimer();
        public static Book chosenBook = YourLibraryPage.chosenBook;
        

        public BookStopwatch()
        {
            System.Diagnostics.Debug.WriteLine("Book Passed from Library: " + chosenBook.ToString());
            this.DataContext = chosenBook;
            this.InitializeComponent();
           System.Diagnostics.Debug.WriteLine( chosenBook.Author.ToString());
            



        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timeSpan =
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timeTicker;
            

            timer.Start();

        }
        private int seconds = chosenBook.time, minutes = 0, hours = 0;

        private void LibraryNavigation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(YourLibraryPage));
            
        }

        private void timeTicker(object sender, object e)
        {
            string time = "";
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if (minutes == 60)
            {
                hours++;
                minutes = 0;
            }

            if (hours < 10)
            {
                time += "0" + hours;
            }
            else
            {
                time += +hours;
            }
            time += ":";
            if (minutes < 10)
            {
                time += "0" + minutes;
            }
            else
            {
                time += minutes;
            }
            time += ":";
            if (seconds < 10)
            {
                time += "0" + seconds;
            }
            else
            {
                time += seconds; ;
            }
            tbTimer.Text = time;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            YourLibraryPage.chosenBook.time = seconds;
        }

    }

}