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
    /// Interaction logic for NewUserDialogView.xaml
    /// </summary>
    public partial class CreateUserDialogView : Window
    {
        private User newUser =  new User();

        public CreateUserDialogView()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            newUser.Login = Login.Text;
            newUser.IsNeedChangePassword = true;
            EntityController.Add(newUser);
            Close();        
        }

        private void RestrictionButton_Click(object sender, RoutedEventArgs e)
        {
            RestrictionsDialogView dialog = new RestrictionsDialogView(newUser);
            dialog.Show();            
        }

        private void ForcePass_Click(object sender, RoutedEventArgs e)
        {
            string newPass = Utils.GeneratePassword();            
            MessageBox.Show("Временный пароль:\r\n" + newPass, "Пароль сформирован", MessageBoxButton.OK, MessageBoxImage.Information);
            newUser.Password = SecurityController.Encrypt(newPass);
            Password.Text = newPass;
        }

    }
}
