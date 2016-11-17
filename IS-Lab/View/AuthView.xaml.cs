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
                Hide();
                window.Show();   
            }
                
        }
        private void Enter_ClickHandler(object sender, RoutedEventArgs e)
        {
            User user = EntityController.LoadByLogin(Login.Text);
            string result;
            if (user != null)
            {
                result = SecurityController.Verify(Password.Password, user);
                if (result != null)
                    MessageBox.Show(result, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (user.IsAdmin)
                {
                    AdminView adminView = new AdminView();
                    Hide();
                    adminView.Show();
                }
                else
                {
                    UserView userView = new UserView(user);
                    Hide();
                    userView.Show();
                }
            }
            else
                MessageBox.Show("Пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
