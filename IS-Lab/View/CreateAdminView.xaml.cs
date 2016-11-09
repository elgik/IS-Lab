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
        public CreateAdminView()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            User admin = new User();
            admin.Login = "Admin";
            admin.Password = SecurityController.Encrypt(Password.Password);
            EntityController.Add(admin);
            Close();
        }
    }
}
