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
        async void LoadGoogleData()
        {

        }
        public APIconnection(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }
    }
}
