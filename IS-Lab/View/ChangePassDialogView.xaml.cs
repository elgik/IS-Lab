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
using IS_Lab.Controllers;
using IS_Lab.Domain;

namespace IS_Lab.View
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialogView.xaml
    /// </summary>
    public partial class ChangePasswordDialogView : Window
    {
        private User currentUser;

        public ChangePasswordDialogView(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string result;
            result = SecurityController.Verify(OldPassword.Password, currentUser);
            if (result != null)
                MessageBox.Show(result, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                currentUser.Password = SecurityController.Encrypt(NewPassword.Password);
                currentUser.IsNeedChangePassword = false;
                EntityController.UpdateUser(currentUser);
            }
        }
    }
}
