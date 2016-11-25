using System.Windows;
using IS_Lab.Controllers;
using IS_Lab.Domain;
namespace IS_Lab.View
{
    /// <summary>
    /// Interaction logic for AuthView.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();
            if(EntityController.LoadByLogin("Admin") == null)
            {
                CreateAdminView window = new CreateAdminView();
                Close();
                window.Show();   
            }
                
        }
        private void Enter_ClickHandler(object sender, RoutedEventArgs e)
        {
            if ("Admin".Equals("ADMIN"))
                MessageBox.Show("1111");
            User user = EntityController.LoadByLogin(Login.Text);
            if (user != null)
            {
                var result = SecurityController.Verify(Password.Password, user);
                if (result != null)
                {
                    MessageBox.Show(result, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (user.IsBlocked)
                {
                    MessageBox.Show("Пользователь заблокирован!\r\nОбратитесь к администратору", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (user.IsAdmin)
                {
                    AdminView adminView = new AdminView();
                    Close();
                    adminView.Show();
                }
                else
                {
                    UserView userView = new UserView(user);
                    Close();
                    userView.Show();
                }
            }
            else
                MessageBox.Show("Пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
