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
    /// Interaction logic for ChangeUserDialogView.xaml
    /// </summary>
    public partial class ChangeUserDialogView : Window
    {
        private User selectedUser;

        public ChangeUserDialogView(User user)
        {
            InitializeComponent();
            selectedUser = user;
            Login.Text = selectedUser.Login;
        }

        private void RestrictionButton_Click(object sender, RoutedEventArgs e)
        {
            RestrictionsDialogView dialog = new RestrictionsDialogView(selectedUser);
            dialog.Show();
        }

        private void ForceChange_Click(object sender, RoutedEventArgs e)
        {
            string newPass = Utils.GeneratePassword();
            selectedUser.Password = SecurityController.Encrypt(newPass);
            MessageBox.Show("Временный пароль:\r\n" + newPass, "Пароль сформирован", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            selectedUser.IsBlocked = (bool) Block.IsChecked;
            if (selectedUser.Login != Login.Text && EntityController.LoadByLogin(Login.Text) != null)
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка при сохранении", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(selectedUser.Login != Login.Text)
                selectedUser.Login = Login.Text;
            EntityController.UpdateUser(selectedUser);
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            EntityController.Delete(selectedUser);
            MessageBox.Show("Пользователь удалён", "База обновлена", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
