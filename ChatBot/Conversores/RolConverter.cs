using System;
using System.Globalization;
using System.Windows.Data;
using static ChatBot.Mensaje;

namespace ChatBot
{
    class RolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Rol quien = (Rol)value;

            if (quien == Rol.Robot)
            {
                return "Assets/robot2.png";
            }
            else
            {
                if (Properties.Settings.Default.sexo == "Hombre")
                {
                    return "Assets/hombre.png";
                }
                else
                {
                    return "Assets/mujer.png";
                }
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
