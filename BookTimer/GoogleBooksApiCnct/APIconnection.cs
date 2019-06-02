using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using System.Xml.Linq;
using BookTimer.Models;
using Newtonsoft.Json;

namespace BookTimer.GoogleBooksApiCnct
{
    class APIconnection
    {
        string dataGoogle = "";
        HttpClient HttpClient;
        List<Book> books = new List<Book>();
        string MockUpGet = "https://www.googleapis.com/books/v1/volumes?q=flowers+inauthor:keyes&key=AIzaSyDK0-zIoneoTz7tqQx_YsDAkaGVtFVrCNE";
        public async void LoadGoogleData()
        {
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
        public XDocument parseGoogleData()
        {
            
            XDocument googleDataxml = (XDocument)JsonConvert.DeserializeXNode(dataGoogle, "root");
            Console.WriteLine(googleDataxml.ToString());
            try
            {
                books = (from item in googleDataxml.Descendants("item")
                         select new Book
                         {
                             Title = item.Element("title").Value,
                             Author = item.Element("author").Value,
                             SmallThumbnail = item.Element("smallThumbnail").Value
                         }
                                 ).ToList();
            }
            catch (Exception ex)
            {

            }
            return googleDataxml;
        }
        public APIconnection(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
    }
}
