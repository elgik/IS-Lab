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
using System.Windows.Shapes;
using IS_Lab.Domain;

namespace IS_Lab.View
{
    /// <summary>
    /// Логика взаимодействия для RestrictionsDialogView.xaml
    /// </summary>
    public partial class RestrictionsDialogView : Window
    {
        User user;
        public RestrictionsDialogView(User u)
        {                
            InitializeComponent();
            user = u;
            Digits.IsChecked = user.IsDigits;
            Lower.IsChecked = user.IsLowerCase;
            Upper.IsChecked = user.IsUpperCase;
            Symbols.IsChecked = user.IsSymbols;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            user.IsDigits = (bool) Digits.IsChecked;
            user.IsLowerCase = (bool)Lower.IsChecked;
            user.IsUpperCase = (bool)Upper.IsChecked;
            user.IsSymbols = (bool)Symbols.IsChecked;
            Close();
        }
    }
}
