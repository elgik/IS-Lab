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
using IS_Lab.Controllers;

namespace IS_Lab.View
{
    /// <summary>
    /// Interaction logic for CreateAdminView.xaml
    /// </summary>
    public partial class CreateAdminView : Window
    {
        private string validatation = null;
        public CreateAdminView()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (validatation == null)
            {
                User admin = new User();
                admin.Login = "Admin";
                admin.Password = SecurityController.Encrypt(Password.Password);
                EntityController.Add(admin);
                AuthView window = new AuthView();
                window.Show();                
                Close();
            }
            else            
                MessageBox.Show(validatation, "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);                                            
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Password1.Password != Password.Password)
            {               
                Password1.BorderBrush = Brushes.Red;
                
                Password1.ToolTip =
                    new ToolTip().Content = "Пароли не совпадают";
                validatation = "Пароли не совпадают";
            }
            else
            {
                Password1.BorderBrush = Brushes.White;
                Password1.ToolTip = null;
                validatation = null;
            }
        }
    }
}
