using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ChatBot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Mensaje> conversacion;
        private Mensaje nuevoMensaje;
        private QnAService cliente;
        public MainWindow()
        {
            cliente = new QnAService(Properties.Settings.Default.endpoint, Properties.Settings.Default.key, Properties.Settings.Default.id);
            conversacion = new ObservableCollection<Mensaje>();
            InitializeComponent();
            conversacionItemsControl.DataContext = conversacion;
            nuevoMensaje = new Mensaje();
            newPostTextBox.DataContext = nuevoMensaje;
            newPostTextBox.Focus();
        }

        private async void SendCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            enviarButton.IsEnabled = false;

            //Pregunta
            conversacion.Add(nuevoMensaje);
            string pregunta = nuevoMensaje.Texto;
            nuevoMensaje = new Mensaje();
            newPostTextBox.DataContext = nuevoMensaje;

            //Respuesta
            Mensaje respuesta = new Mensaje("Procesando...", Mensaje.Rol.Robot);
            conversacion.Add(respuesta);
            conversacionScrollViewer.ScrollToEnd();

            try
            {

                respuesta.Texto = await cliente.GenerarRespuesta(pregunta);
            }
            catch (Exception)
            {
                respuesta.Texto = "Lo siento, estoy un poco cansado para hablar.";
            }

            enviarButton.IsEnabled = true;

        }

        private void SendCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (newPostTextBox != null) && newPostTextBox.Text != "";
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            conversacion.Clear();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = conversacion.Count > 0;
        }


        private async void CheckCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                await cliente.GenerarRespuesta("Hola");
                MessageBox.Show("Conexión correcta con el servidor del Bot", "Comprobar conexión", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("No es posible conectar con el servidor del Bot", "Comprobar conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialogo = new Microsoft.Win32.SaveFileDialog();
            dialogo.Filter = "*.txt|Text Files";
            dialogo.AddExtension = true;

            if (dialogo.ShowDialog() == true)
            {
                StringBuilder builder = new StringBuilder();

                foreach (var post in conversacion)
                {
                    builder.Append(post.Quien.ToString());
                    builder.AppendLine();
                    builder.Append(post.Texto);
                    builder.AppendLine();
                }

                System.IO.File.WriteAllText(dialogo.FileName, builder.ToString());
            }

        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = conversacion.Count > 0;
        }

        private void ConfigCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Configuracion dialogo = new Configuracion();
            dialogo.Owner = this;

            dialogo.Fondo = Properties.Settings.Default.fondo;
            dialogo.Usuario = Properties.Settings.Default.usuario;
            dialogo.Robot = Properties.Settings.Default.robot;
            dialogo.Sexo = Properties.Settings.Default.sexo;


            if (dialogo.ShowDialog() == true)
            {
                Properties.Settings.Default.fondo = dialogo.Fondo;
                Properties.Settings.Default.usuario = dialogo.Usuario;
                Properties.Settings.Default.robot = dialogo.Robot;
                Properties.Settings.Default.sexo = dialogo.Sexo;
            }
        }


    }
}
