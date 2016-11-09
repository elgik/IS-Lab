﻿using System;
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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        private User currentUser;
        public UserView(User user)
        {
            InitializeComponent();
            Greetings.Content += user.Login;
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
                EntityController.UpdateUser(currentUser);
            }
        }
    }
}
