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
                window.Show();
                Close();
            }                
        }
        private void Enter_ClickHandler(object sender, RoutedEventArgs e)
        {            
            User user = EntityController.LoadByLogin(Login.Text);
            if (user != null)
            {
                var result = SecurityController.Verify(Password.Password, user);
                if (user.IsBlocked)
                {
                    MessageBox.Show("Пользователь заблокирован!\r\nОбратитесь к администратору", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!result)
                {
                    MessageBox.Show("Неправильный пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    user.TryCount++;
                    EntityController.UpdateUser(user);
                    return;
                }                
                if (user.IsAdmin)
                {
                    user.TryCount = 0;
                    EntityController.UpdateUser(user);
                    AdminView adminView = new AdminView();
                    Close();
                    adminView.Show();
                }
                else
                {
                    user.TryCount = 0;
                    EntityController.UpdateUser(user);
                    UserView userView = new UserView(user);
                    Close();
                    userView.Show();
                }
            }
            else
                MessageBox.Show("Пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Help_OnClick(object sender, RoutedEventArgs e)
        {
            Utils.ShowAbout();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
