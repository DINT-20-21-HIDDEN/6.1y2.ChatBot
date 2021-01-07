using System.ComponentModel;

namespace ChatBot
{
    class Mensaje : INotifyPropertyChanged
    {
        public enum Rol
        {
            Usuario,
            Robot
        }

        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                NotifyPropertyChanged("Texto");
            }
        }


        private Rol _quien;

        public Rol Quien
        {
            get { return _quien; }
            set { 
                _quien = value;
                NotifyPropertyChanged("Quien");
            }
        }

        public Mensaje()
        {
            Texto = "";
            Quien = Rol.Usuario;
        }

        public Mensaje(string texto, Rol quien)
        {
            Texto = texto;
            Quien = quien;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
