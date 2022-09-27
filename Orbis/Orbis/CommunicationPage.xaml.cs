using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Orbis.Models;
using Xamarin.Forms;

namespace Orbis
{
    public partial class CommunicationPage : ContentPage
    {

        public CommunicationPage()
        {
            InitializeComponent();

            listView.RefreshCommand = new Command((obj) =>
            {
                Console.WriteLine("RefreshCommand");
                DownloadData((messagesm) =>
                {
                    listView.ItemsSource = messagesm;
                    listView.IsRefreshing = false;
                });
            });

            listView.IsVisible = false;
            waitLayout.IsVisible = true;

            Console.WriteLine("ETAPE 1");

            DownloadData((messagesm) =>
            {
                listView.ItemsSource = messagesm;

                listView.IsVisible = true;
                waitLayout.IsVisible = false;
            });

            Console.WriteLine("ETAPE 4");

        }

        public void DownloadData(Action<List<MessageM>> action)
        {
            const string URL = "https://orbis-communication.azurewebsites.net/api/messagesm";

            using (var webclient = new WebClient())
            {

                Console.WriteLine("ETAPE 2");

                webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) => {

                    Console.WriteLine("ETAPE 5");

                    try
                    {
                        string messagesmJson = e.Result;

                        List<MessageM> messagesm = JsonConvert.DeserializeObject<List<MessageM>>(messagesmJson);

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            action.Invoke(messagesm);

                        });

                    }
                    catch (Exception ex)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Erreur", "Une erreur réseau s'est produite: " + ex.Message, "OK");
                            action.Invoke(null);
                        });
                    }

                };

                Console.WriteLine("ETAPE 3");

                webclient.DownloadStringAsync(new Uri(URL));


            }
        }
    }
}
