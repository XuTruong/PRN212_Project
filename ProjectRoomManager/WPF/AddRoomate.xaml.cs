using System.Windows;
using DataAccess.Models;
using Repositories.DTO;
using Services;

namespace WPF
{
    /// <summary>
    /// Interaction logic for AddRoomate.xaml
    /// </summary>
    public partial class AddRoomate : Window
    {
        private ContractService contractService;
        private TenantService tenantService;

        public AddRoomate()
        {
            InitializeComponent();
            contractService = new ContractService();
            tenantService = new TenantService();
            var contracts = contractService.GetAllActiveContracts();
            dgContracts.ItemsSource = contracts;
            cbOtherTenants.ItemsSource = tenantService.getTenantDto();
        }

        private void AddRoommate_Click(object sender, RoutedEventArgs e)
        {
            if (cbOtherTenants.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người ở ghép.");
                return;
            }

            if (dgContracts.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng/phòng.");
                return;
            }

            var selectedContract = dgContracts.SelectedItem as ContractDisplayDto;

            if (selectedContract == null)
            {
                MessageBox.Show("Không thể lấy hợp đồng đã chọn.");
                return;
            }

            int contractId = selectedContract.ContractId;
            int tenantId = (int)cbOtherTenants.SelectedValue;

            RoomTenant roomTenant = new RoomTenant
            {
                ContractId = contractId,
                TenantId = tenantId
            };

            contractService.AddRoomTenant(roomTenant);
            MessageBox.Show("Thêm người ở ghép thành công.");
            this.Close();
            new ContractManager().ShowDialog();
        }
    }
}
