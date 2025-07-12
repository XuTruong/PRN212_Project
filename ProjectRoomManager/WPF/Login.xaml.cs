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
using Microsoft.IdentityModel.Tokens;
using Repositories.DTO;
using Services;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        AccountService accountService;

        public Login()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            accountService = new AccountService();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("Username and Password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AccountDTO acc =  accountService.Login(username, password);

            
            if (acc != null)
            {
                // Proceed to the main application window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
