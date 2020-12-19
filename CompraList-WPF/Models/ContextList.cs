using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace CompraList_WPF.Models
{
    public class ContextList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Actualizar([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        public string url { get; set; }

        public HubConnection hubConnection;
        public event Action ListUpdated;
        //public event Action UpdateLista;

        public string Username { get; set; }

        private ObservableCollection<Item> listItems;

        public ObservableCollection<Item> ListItems
        {
            get { return listItems; }
            set { listItems = value; Actualizar(); }
        }



        //    public void HubConnection()
        public ContextList()
        {
            url = "https://compralist.itesrc.net/";
            ListItems = new ObservableCollection<Item> { };

            hubConnection = new HubConnectionBuilder().WithUrl($"{url}/compraListHub").Build();

            hubConnection.StartAsync();

            hubConnection.Closed += async (error) =>
            {
                Thread.Sleep(1000);
                await hubConnection.StartAsync();
            };

            hubConnection.On<IEnumerable<Item>>("ReceiveMessage", (list) => { datos(); });

            datos();

            List_OrderBy();
        }

        public async void datos()
        {
            await LoadData();
        }
        public async Task LoadData()
        {
            HttpClient httpClient = new HttpClient();

            var json = await httpClient.GetAsync($"{url}/home/getitemsall");

            json.EnsureSuccessStatusCode();
            List<Item> lista = JsonConvert.DeserializeObject<List<Item>>(await json.Content.ReadAsStringAsync());

            Reset_AllItems(lista);

            ListUpdated?.Invoke();
            //Reset_AllItems(lista);
        }

        public void List_OrderBy()
        {


            ListItems = new ObservableCollection<Item>((from item in ListItems orderby item.Listo, item.Id descending select item).ToList());

            //     UpdateLista?.Invoke();
        }
        public void Reset_AllItems(List<Item> items)
        {
            ListItems = new ObservableCollection<Item>((from item in items orderby item.Listo, item.Id descending select item).ToList());
        }


        public async void Item_Add(string itemcontent, string username)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);

            string formdata = @"{""nombre"" : """ + itemcontent + @""", ""quienagrego"" : """ + username + @"""}";

            var content = new StringContent(formdata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/home/createitem", content);

            var result = await response.Content.ReadAsStringAsync();
            await hubConnection.InvokeAsync("SyncronizeItems");
            //if (!string.IsNullOrWhiteSpace(result))
            //{
            //    MessageBox.Show("Atención");
            //}
            //else
            //{
            //    await hubConnection.InvokeAsync("SyncronizeItems");
            //}
        }
        //public void Item_Editar(Item newitems)
        //{
        //    newitems.Listo = !newitems.Listo;
        //    if (newitems.Listo)
        //    {
        //        newitems.Estilo = "Strikethrough";
        //    }
        //    else
        //    {
        //        newitems.Estilo = null;
        //    }
        //   UpdateLista?.Invoke();

        //}
        //private string estilo;

        //public string Estilo
        //{
        //    get
        //    {
        //        if (Listo)
        //        {
        //            return estilo = "Strikethrough";
        //        }
        //        else
        //        {
        //            return estilo = null;
        //        }
        //    }
        //    set { estilo = value; Actualizar(); }
        //}
        public async void Item_Complete(Item item, string username)
        {


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);


            var content = new StringContent(item.Id.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/home/changestatus/" + item.Id, content);

            var result = await response.Content.ReadAsStringAsync();
            //if (item.Listo)
            //{
            //    item.Estilo = "Strikethrough";
            //}
            //else
            //{
            //    item.Estilo = null;
            //}
            //if (!string.IsNullOrWhiteSpace(result))
            //{
            //    MessageBox.Show("Atención");

            //}
            //else
            //{
            await hubConnection.InvokeAsync("SyncronizeItems");
            //}
        }
        public async void Item_Delete(Item item)
        {
            //  ListItems.Remove(item);
            //UpdateLista?.Invoke(); 
            // List_OrderBy();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);


            var content = new StringContent(item.Id.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/home/deleteitem/" + item.Id, content);

            var result = await response.Content.ReadAsStringAsync();

            //if (!string.IsNullOrWhiteSpace(result))
            //{
            //    MessageBox.Show("Atención");

            //}
            //else
            //{
            await hubConnection.InvokeAsync("SyncronizeItems");
            ///  }
        }


    }
}