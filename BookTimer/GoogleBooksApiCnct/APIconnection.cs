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
        static readonly string apiQuery = "https://www.googleapis.com/books/v1/volumes?q=";
        static readonly string apiKey = "&key=AIzaSyDK0-zIoneoTz7tqQx_YsDAkaGVtFVrCNE";

        HttpClient HttpClient;
        List<Book> books = new List<Book>();
        string MockUpGet = "https://www.googleapis.com/books/v1/volumes?q=flowers+inauthor:keyes&key=AIzaSyDK0-zIoneoTz7tqQx_YsDAkaGVtFVrCNE";
        static readonly string maxNumberOfResults = "&maxResults=3";

        public async void LoadGoogleData(string author, string title)
        {
            string query = buildApiQuery(author, title);
            System.Diagnostics.Debug.WriteLine(query);
            try
            {
                this.dataGoogle = await HttpClient.GetStringAsync(new Uri(query)); //await to słowo klucz dla funkcji asynchronicznej 
            }
            catch (Exception ex)
            {
                Windows.UI.Popups.MessageDialog dlgError = new Windows.UI.Popups.MessageDialog("Error: " + ex.Message + ex.HResult + "Data error");
                await dlgError.ShowAsync();
                App.Current.Exit();
            }
            string googleData = dataGoogle;
            //System.Diagnostics.Debug.WriteLine("Books: " + dataGoogle);

            //root myXmlRoot = JsonConvert.DeserializeObject<root>(googleData);
            XDocument googleDataxml = (XDocument)JsonConvert.DeserializeXNode(dataGoogle, "root");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(root));
            root myXmlRoot = xmlSerializer.Deserialize(new StringReader(googleDataxml.ToString())) as root;
            try
            {
                
                foreach (rootItems rootItem in myXmlRoot.items)
                {
                    books.Add(new Book(rootItem.volumeInfo.title, rootItem.volumeInfo.authors[0], rootItem.volumeInfo.imageLinks.smallThumbnail));

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message + ex.HResult + "DataError");

            }

            foreach (Book book in books)
            {
                System.Diagnostics.Debug.WriteLine("Book: " + book.Title + " " + book.Author + " " + book.SmallThumbnail);
            }
            //System.Diagnostics.Debug.WriteLine("BooksXaml: " + books.ToString());
            System.Diagnostics.Debug.WriteLine("Number of elements on booksList: " + books.Count());

        }
        string buildApiQuery(string author, string title)
        {
            string queryAuthor = author.Trim().Replace(" ", "+");
            string queryBook = title.Trim().Replace(" ", "+");
            System.Diagnostics.Debug.WriteLine("Query in progress: " + queryAuthor + "+" +queryBook);
            return apiQuery + queryAuthor + "+" + queryBook + maxNumberOfResults + apiKey;
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
