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
            GridUsers.ItemsSource = EntityController.GetAllUsers();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            ChangeUserDialogView dialog = new ChangeUserDialogView(GridUsers.SelectedItem as User);
            dialog.ShowDialog();
            GridUsers.ItemsSource = EntityController.GetAllUsers();
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            UserView userView = new UserView(EntityController.LoadByLogin("Admin"));
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
            ChangeUserDialogView dialog = new ChangeUserDialogView((User)GridUsers.SelectedItem);
            dialog.ShowDialog();
            GridUsers.ItemsSource = EntityController.GetAllUsers();
        }
    }
}
