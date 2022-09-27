using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orbis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
            GetNews();
        }
        public async Task GetNews()
        {
            HttpClient myHttpClient = new HttpClient();
            myHttpClient.BaseAddress = "https://api.reliefweb.int/";

            string uri = "v1/reports?appname=apidoc&limit=2";
            var response = await myHttpClient.GetAsync(uri);

            var materials = JsonSerializer.Deserialize<NewsModel>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}