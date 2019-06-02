using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace BookTimer.GoogleBooksApiCnct
{
    class APIconnection
    {
        HttpClient HttpClient;
        string MockUpGet = "https://www.googleapis.com/books/v1/volumes?q=flowers+inauthor:keyes&key=AIzaSyDK0-zIoneoTz7tqQx_YsDAkaGVtFVrCNE";
        async void LoadGoogleData()
        {
            string dataGoogle = "";
            try
            {
                dataGoogle = await HttpClient.GetStringAsync(new Uri(MockUpGet)); //await to słowo klucz dla funkcji asynchronicznej 
            }
            catch (Exception ex)
            {
                Windows.UI.Popups.MessageDialog dlgError = new Windows.UI.Popups.MessageDialog("Error: " + ex.Message + ex.HResult, "Data error");
                await dlgError.ShowAsync();
                App.Current.Exit();
            }
        }
        public APIconnection(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
    }
}
