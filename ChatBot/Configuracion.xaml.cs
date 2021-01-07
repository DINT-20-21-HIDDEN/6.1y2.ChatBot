using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ChatBot
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        public string Fondo { get; set; }
        public string Usuario { get; set; }
        public string Robot { get; set; }
        public string Sexo { get; set; }

        public Configuracion()
        {
            InitializeComponent();
            fondoListBox.ItemsSource = typeof(Colors).GetProperties();
            usuarioListBox.ItemsSource = typeof(Colors).GetProperties();
            robotListBox.ItemsSource = typeof(Colors).GetProperties();
            sexoListBox.ItemsSource = new List<string> { "Hombre", "Mujer" };
            DataContext = this;
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
