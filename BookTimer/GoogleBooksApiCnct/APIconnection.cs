using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using System.Xml.Linq;
using BookTimer.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

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
                this.dataGoogle = await HttpClient.GetStringAsync(new Uri(MockUpGet)); //await to słowo klucz dla funkcji asynchronicznej 
            }
            catch (Exception ex)
            {
                Windows.UI.Popups.MessageDialog dlgError = new Windows.UI.Popups.MessageDialog("Error: " + ex.Message + ex.HResult, "Data error");
                await dlgError.ShowAsync();
                App.Current.Exit();
            }
            string googleData = dataGoogle;
            System.Diagnostics.Debug.WriteLine("Books: " + dataGoogle);
            XDocument googleDataxml = (XDocument)JsonConvert.DeserializeXNode(dataGoogle, "root");
            System.Diagnostics.Debug.WriteLine("BooksXaml: " + googleDataxml.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(root));
            root myXmlRoot = xmlSerializer.Deserialize(new StringReader(googleDataxml.ToString())) as root;
            foreach (rootItems rootItem in myXmlRoot.items)
            {
                books.Add(new Book(rootItem.volumeInfo.title, rootItem.volumeInfo.authors.ToString(), rootItem.volumeInfo.imageLinks.smallThumbnail));
            }
            foreach (Book book in books)
            {
                System.Diagnostics.Debug.WriteLine("Book Title: " + book.Title);
            }
            System.Diagnostics.Debug.WriteLine("BooksXaml: " + books.ToString());
            System.Diagnostics.Debug.WriteLine("Number of elements on booksList: " + books.Count());

        }

        public APIconnection(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
