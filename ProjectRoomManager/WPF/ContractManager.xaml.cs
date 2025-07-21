using System.Windows;
using System.Windows.Controls;
using Repositories.DTO;
using Services;

namespace WPF
{
    /// <summary>
    /// Logic tương tác cho cửa sổ ContractManager.xaml
    /// </summary>
    public partial class ContractManager : Window
    {
        private ContractService contractService;

        public ContractManager()
        {
            InitializeComponent();
            contractService = new ContractService();
            var contracts = contractService.GetAllContracts();
            dgContracts.ItemsSource = contracts; // Gán danh sách hợp đồng cho DataGrid
        }

        // Khi chọn một hợp đồng trong DataGrid
        private void dgContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgContracts.SelectedItem is ContractDisplayDto selected)
            {
                txtRoomName.Text = selected.RoomName;
                txtInfoMainTenant.Text = selected.MainTenantName;
                txtInfoRoomates.Text = selected.Roommates;
                txtStartDate.Text = selected.StartDate.HasValue ? selected.StartDate.Value.ToString("dd/MM/yyyy") : "Chưa có";
                txtEndDate.Text = selected.EndDate.HasValue ? selected.EndDate.Value.ToString("dd/MM/yyyy") : "Chưa có";
                txtDeposit.Text = selected.Deposit.ToString();
                txtNote.Text = selected.Note;
            }
        }

        // Khi thay đổi nội dung tìm kiếm
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var result = contractService.SearchContract(keyword); // Tìm kiếm hợp đồng
            dgContracts.ItemsSource = result;
        }

        // Hiển thị danh sách hợp đồng còn hiệu lực
        private void btnActiveContracts_Click(object sender, RoutedEventArgs e)
        {
            dgContracts.ItemsSource = contractService.GetAllActiveContracts();
        }

        // Hiển thị danh sách hợp đồng đã hết hạn
        private void btnExpiredContracts_Click(object sender, RoutedEventArgs e)
        {
            dgContracts.ItemsSource = contractService.GetAllExpiredContracts();
        }

        // Hiển thị tất cả hợp đồng
        private void btnAllContracts_Click(object sender, RoutedEventArgs e)
        {
            dgContracts.ItemsSource = contractService.GetAllContracts();
        }

        // Mở cửa sổ tạo hợp đồng mới
        private void btnCreateContract_Click(object sender, RoutedEventArgs e)
        {
            var createContract = new CreateContract();
            this.Close();
            createContract.ShowDialog();
        }

        // Kết thúc hợp đồng đang chọn
        private void btnEndContract_Click(object sender, RoutedEventArgs e)
        {
            if (dgContracts.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vào hợp đồng/phòng.");
            }

            if (dgContracts.SelectedItem is ContractDisplayDto selected)
            {
                int contractId = selected.ContractId;
                String roomName = selected.RoomName;
                List<int> roommateIds = selected.TenantIdRoomate;

                contractService.EndContract(contractId, roomName); // Kết thúc hợp đồng
                contractService.RemoveRoomate(roommateIds); // Xóa người ở ghép
                MessageBox.Show("Đã xóa hợp đồng thành công.");
                dgContracts.ItemsSource = contractService.GetAllContracts();
            }
        }

        // Mở cửa sổ thêm người ở ghép
        private void btnAddRoomates_Click(object sender, RoutedEventArgs e)
        {
            var addRoomate = new AddRoomate();
            this.Close();
            addRoomate.ShowDialog();
        }

        // Xóa người ở ghép của hợp đồng đang chọn
        private void btnRemoveRoomates_Click(object sender, RoutedEventArgs e)
        {
            if (dgContracts.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vào hợp đồng/phòng.");
            }

            if (dgContracts.SelectedItem is ContractDisplayDto selected)
            {
                List<int> roommateIds = selected.TenantIdRoomate;

                if (roommateIds.Count == 0)
                {
                    MessageBox.Show("Phòng này không có người ở cùng.");
                }
                else
                {
                    contractService.RemoveRoomate(roommateIds);
                    MessageBox.Show("Đã xóa thành công.");
                    dgContracts.ItemsSource = contractService.GetAllContracts();
                }
            }
        }
    }
}
