using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CompraList_WPF.Models
{
  public  class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Actualizar([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        private bool listo;

        public bool Listo
        {
            get { return listo; }
            set { listo = value; Actualizar(); }
        }
        private string quienAgrego;

        public string QuienAgrego
        {
            get { return quienAgrego; }
            set { quienAgrego = value; Actualizar(); }
        }
        private string estilo;

        public string Estilo
        {
            get {
                if (Listo)
                {
                    return Estilo = "Strikethrough";
                }
                else
                {
                    return Estilo = null;
                }
            }
            set { estilo = value; }
        }


    }
}
