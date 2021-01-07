using System.Windows.Input;

namespace ChatBot
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand
            ("Nuevo", "New", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.N, ModifierKeys.Control) });

        public static readonly RoutedUICommand Save = new RoutedUICommand
            ("Guardar", "Save", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.G, ModifierKeys.Control) });

        public static readonly RoutedUICommand Exit = new RoutedUICommand
            ("Salir", "Exit", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.S, ModifierKeys.Control) });

        public static readonly RoutedUICommand Check = new RoutedUICommand
            ("Comprobar conexión", "Check", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.O, ModifierKeys.Control) });

        public static readonly RoutedUICommand Config = new RoutedUICommand
            ("Configuración", "Config", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.C, ModifierKeys.Control) });

        public static readonly RoutedUICommand Send = new RoutedUICommand
            ("Enviar", "Send", typeof(CustomCommands),
            new InputGestureCollection() { new KeyGesture(Key.E, ModifierKeys.Control) });

    }
}
