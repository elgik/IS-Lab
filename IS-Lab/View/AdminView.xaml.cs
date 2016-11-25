using System;
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
using IS_Lab.Controllers;
using IS_Lab.Domain;

namespace IS_Lab.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
            GridUsers.ItemsSource = EntityController.GetAllUsers();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUserDialogView dialog = new CreateUserDialogView();
            dialog.ShowDialog();
            RefreshGrid();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(FindBox.Text) || string.IsNullOrWhiteSpace(FindBox.Text))
                return;
            User u = EntityController.LoadByLogin(FindBox.Text);
            if (u != null)
            {
                ChangeUserDialogView dialog = new ChangeUserDialogView(u);
                dialog.ShowDialog();
                RefreshGrid();
            }
            else
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            ChangeUserDialogView changeUserDialogView = new ChangeUserDialogView(EntityController.LoadByLogin("Admin"));
            changeUserDialogView.Show();
            RefreshGrid();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            AuthView authView = new AuthView();
            authView.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (GridUsers.SelectedItem != null)
            {
                ChangeUserDialogView dialog = new ChangeUserDialogView((User) GridUsers.SelectedItem);
                dialog.ShowDialog();
                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            GridUsers.ItemsSource = EntityController.GetAllUsers();
        }
    }
}
