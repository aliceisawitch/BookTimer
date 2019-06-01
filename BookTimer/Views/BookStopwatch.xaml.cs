using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookTimer.Views
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class BookStopwatch : Page

    {
        DispatcherTimer timer = new DispatcherTimer();

        public BookStopwatch()
        {
            this.InitializeComponent();
            
            
        }
        
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timeSpan = 
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timeTicker;
            timer.Start();

        }
        private int seconds = 0,minutes=0,hours=0;
        

        private void timeTicker(object sender, object e)
        {
            string time="";
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if(minutes==60)
            {
                hours++;
                minutes = 0;
            }
           
            if(hours<10)
            {
                time += "0" + hours;
            }
            else
            {
                time += + hours;
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
                time +=+ seconds; ;
            }
            tbTimer.Text = time;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
