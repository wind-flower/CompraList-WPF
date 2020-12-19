using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CompraList_WPF
{
    /// <summary>
    /// Lógica de interacción para profileView.xaml
    /// </summary>
    public partial class profileView : Window
    {
        public profileView()
        {
            InitializeComponent();
        }
        private List listprofile;

        public List ListProfile
        {
            get { return listprofile; }
            set { listprofile = value;  }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
