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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
           lstItem.ItemsSource = null;
            lstItem.ItemsSource = listacontext.ListItems;
            //listacontext.List_OrderBy();
           
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
           listacontext.Item_Add(txtnewItem.Text, lbluser.Content.ToString());
           // context.Item_Add(txtnewItem.Text, txtuser.Text ); 
           // txtnewItem.Text = null;
           // context.UpdateLista();
           // context.Items_LoadAll();
        }

        //private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    //if (lstItem.SelectedItem != null)
        //    //{
        //    //    // context.Item_Delete(lstItem.SelectedItem as Item);
        //    //    var i = lstItem.SelectedItem as Item;
        //    //    context.Item_Editar(i);
        //    //}

        //}
        //public static System.Windows.TextDecorationCollection Strikethrough { get; }
        private void lstItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstItem.SelectedItem != null)
            {
                // context.Item_Delete(lstItem.SelectedItem as Item);
                var i = lstItem.SelectedItem as Item;

                //    context.Item_Editar(i);

                listacontext.Item_Complete(i, lbluser.Content.ToString());

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
                listacontext.Item_Delete(lstItem.SelectedItem as Item);
             //   var i = lstItem.SelectedItem as Item;
              //  MessageBox.Show($"{i.Nombre} Eliminado");
            }
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
