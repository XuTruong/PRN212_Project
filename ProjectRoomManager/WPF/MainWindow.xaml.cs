using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            var roomWindow = new RoomManager();
            roomWindow.ShowDialog();
        }

        private void Tenant_Click(object sender, RoutedEventArgs e)
        {
            var tenantWindow = new TenantManager();
            tenantWindow.ShowDialog();
        }

        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}