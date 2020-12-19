using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompraList_WPF.Models
{
  public class themeMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Actualizar([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private string darklight;

        public string DLtheme
        {
            get { return darklight; }
            set { darklight = value;  Actualizar(); }
        }

    }
}
