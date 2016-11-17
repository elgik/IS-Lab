﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        private User currentUser;

        private string[] validations = new string[2];

        public UserView(User user)
        {
            InitializeComponent();
            Greetings.Content += user.Login;
            currentUser = user;
            if (currentUser.IsNeedChangePassword)
            {
                Hide();
                ChangePasswordDialogView dialog = new ChangePasswordDialogView(currentUser);
                dialog.ShowDialog();
                Show();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string result = null;

            if (string.IsNullOrEmpty(NewPassword.Password) || string.IsNullOrEmpty(NewPassword1.Password) || string.IsNullOrEmpty(OldPassword.Password))
            {
                MessageBox.Show("Поля обязательны к заполнению", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (validations[0] != null)
            {
                MessageBox.Show(
                    "Пароль не соответствует требованиям!\r\nНеобходимо использовать:\r\n" + validations[0], "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (validations[1] != null && validations[0] == null)
            {
                MessageBox.Show(validations[1], "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            result = SecurityController.Verify(OldPassword.Password, currentUser);

            if (result != null)
                MessageBox.Show(result, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                currentUser.Password = SecurityController.Encrypt(NewPassword.Password);
                EntityController.UpdateUser(currentUser);
            }
        }

        private void UserView_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewPassword.Password))
                return;
            string errors = string.Empty;
            if (currentUser.IsDigits && !NewPassword.Password.Any(p => char.IsDigit(p)))
                errors += "-цифры;\r\n";
            if (currentUser.IsSymbols && !NewPassword.Password.Any(p => !char.IsLetterOrDigit(p) && !char.IsWhiteSpace(p)))
                errors += "-символы;\r\n";
            if (currentUser.IsLowerCase && !NewPassword.Password.Any(p => char.IsLower(p)))
                errors += "-прописные буквы;\r\n";
            if (currentUser.IsUpperCase && !NewPassword.Password.Any(p => char.IsUpper(p)))
                errors += "-заглавные буквы;";
            if (currentUser.IsLength && NewPassword.Password.Length <= 8)
                errors += "больше 8 символов";
            if (!string.IsNullOrEmpty(errors))
            {
                NewPassword.BorderBrush = Brushes.Red;
                NewPassword.ToolTip = new ToolTip().Content = "Пароль не соответствует требованиям!\r\nНеобходимо использовать:\r\n" + errors;
                validations[0] = errors;
            }
            else
            {
                NewPassword.BorderBrush = Brushes.White;
                NewPassword.ToolTip = null;
                validations[0] = string.Empty;
            }

            if (NewPassword1.Password != NewPassword.Password)
            {
                NewPassword1.BorderBrush = Brushes.Red;
                NewPassword1.ToolTip =
                    new ToolTip().Content = "Пароли не совпадают";
                validations[1] = "Пароли не совпадают";
            }
            else
            {
                NewPassword1.BorderBrush = Brushes.White;
                NewPassword1.ToolTip = null;
                validations[1] = null;
            }
        }
    }
}
