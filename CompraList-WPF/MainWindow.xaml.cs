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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        private  void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
           listacontext.Item_Add(txtnewItem.Text, lbluser.Content.ToString());
            // await Cargardatos();
            //lstItem.ItemsSource = null;
            //lstItem.ItemsSource = listacontext.ListItems;
            //listacontext.List_OrderBy();

            // context.Item_Add(txtnewItem.Text, txtuser.Text ); 
            txtnewItem.Text = null;
            // context.UpdateLista();
            // context.Items_LoadAll();
        }

      
        //public static System.Windows.TextDecorationCollection Strikethrough { get; }
        private void lstItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (lstItem.SelectedItem != null)
            //{
            //    var i = lstItem.SelectedItem as Item;

            //    //    context.Item_Editar(i);

            //    listacontext.Item_Complete(i, lbluser.Content.ToString());
            //    //lstItem.ItemsSource = null;
            //    //lstItem.ItemsSource = listacontext.ListItems;
            //    listacontext.List_OrderBy();
            //    //   var i = lstItem.SelectedItem as Item;
            //    //  MessageBox.Show($"{i.Nombre} Eliminado");
            //}
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
    
        //private void tbtnmode_Checked(object sender, RoutedEventArgs e)
        //{
          
        //   // theme.DLtheme = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml";
        //}

        //private void tbtnmode_Unchecked(object sender, RoutedEventArgs e)
        //{

        //   // theme.DLtheme = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml";
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lstItem.SelectedItem != null)
        //    {
        //         context.Item_Delete(lstItem.SelectedItem as Item);

        //    }
        //}

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
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

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstItem.SelectedItem != null)
            {
                // context.Item_Delete(lstItem.SelectedItem as Item);

                listacontext.Item_Delete(lstItem.SelectedItem as Item);
                //lstItem.ItemsSource = null;
                //lstItem.ItemsSource = listacontext.ListItems;
                //listacontext.List_OrderBy();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox_clicked = e.OriginalSource as CheckBox;
            Item item = checkbox_clicked.DataContext as Item;

            listacontext.Item_Delete(item);
            //if (lstItem.SelectedItem != null)
            //{
            //    // context.Item_Delete(lstItem.SelectedItem as Item);

            //    listacontext.Item_Delete(lstItem.SelectedItem as Item);
            //    //lstItem.ItemsSource = null;
            //    //lstItem.ItemsSource = listacontext.ListItems;
            //    //listacontext.List_OrderBy();
            //}

        }

        //private void lstItem_Selected(object sender, RoutedEventArgs e)
        //{
        //    if (lstItem.SelectedItem!=null)
        //    {
        //        context.Item_Delete(lstItem.SelectedItem as Item);

        //    }
        //}
    }
}
