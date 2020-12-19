using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CompraList_WPF.Models;

namespace CompraList_WPF
{
    /// <summary>
    /// Lógica de interacción para CompraList_View.xaml
    /// </summary>
    public partial class CompraList_View : Window
    {
        public CompraList_View()
        {
            InitializeComponent();
        }
        ContextList listacontext = new ContextList();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listacontext.ListUpdated += Listacontext_ListUpdated;
            //  listacontext.HubConnection();
            await Cargardatos();
            lstItem.ItemsSource = null;
            lstItem.ItemsSource = listacontext.ListItems;
            listacontext.List_OrderBy();
        }

        private void Listacontext_ListUpdated()
        {
            //throw new NotImplementedException();
            lstItem.ItemsSource = null;
            lstItem.ItemsSource = listacontext.ListItems;
        }

        async Task Cargardatos()
        {
            await listacontext.LoadData();
        }
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            listacontext.Item_Add(txtnewItem.Text, lbluser.Content.ToString());
        }

        private void lstItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstItem.SelectedItem != null)
            {
                var i = lstItem.SelectedItem as Item;

                //    context.Item_Editar(i);

                listacontext.Item_Complete(i, lbluser.Content.ToString());
                //lstItem.ItemsSource = null;
                //lstItem.ItemsSource = listacontext.ListItems;
                //listacontext.List_OrderBy();
                //   var i = lstItem.SelectedItem as Item;
                //  MessageBox.Show($"{i.Nombre} Eliminado");
            }
        }

        private void chkListo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (lstItem.SelectedItem != null)
            {
                var i = lstItem.SelectedItem as Item;

                //    context.Item_Editar(i);

                listacontext.Item_Complete(i, lbluser.Content.ToString());
                //lstItem.ItemsSource = null;
                //lstItem.ItemsSource = listacontext.ListItems;
                //listacontext.List_OrderBy();
                //   var i = lstItem.SelectedItem as Item;
                //  MessageBox.Show($"{i.Nombre} Eliminado");
            }
        }

        private void chkListo_Checked(object sender, RoutedEventArgs e)
        {
            if (lstItem.SelectedItem != null)
            {
                var i = lstItem.SelectedItem as Item;

                //    context.Item_Editar(i);

                listacontext.Item_Complete(i, lbluser.Content.ToString());
                //lstItem.ItemsSource = null;
                //lstItem.ItemsSource = listacontext.ListItems;
                //listacontext.List_OrderBy();
                //   var i = lstItem.SelectedItem as Item;
                //  MessageBox.Show($"{i.Nombre} Eliminado");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
