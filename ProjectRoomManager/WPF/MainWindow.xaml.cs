using System.Windows;

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
            var contractWindow = new ContractManager();
            contractWindow.ShowDialog();
        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            var monthlyBillManager = new MonthlyBillManager();
            monthlyBillManager.ShowDialog();
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            var paymentWindow = new PaymentWindow();
            paymentWindow.ShowDialog();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}