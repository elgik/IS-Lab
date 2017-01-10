using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IS_Lab.Controllers
{
    public static class Utils
    {
        public static string GeneratePassword()
        {
            string result = null;
            Random rnd = new Random();
            Char[] pwdChars = new Char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int i = 0; i < 10; i++)
                result += pwdChars[rnd.Next(0, 25)];
            return result;
        }

        public static void ShowAbout()
        {
            MessageBox.Show("Автор: Попов Денис Павлович" +
                            "\r\nСтудент группы ИДБ-13-15", "", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
