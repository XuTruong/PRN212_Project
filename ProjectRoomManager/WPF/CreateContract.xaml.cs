using System.Windows;
using DataAccess.Models;
using Services;

namespace WPF
{
    /// <summary>
    /// Xử lý logic cho CreateContract.xaml
    /// </summary>
    public partial class CreateContract : Window
    {
        private ContractService _service;
        private RoomService roomService;
        private TenantService tenantService;

        public CreateContract()
        {
            roomService = new RoomService();
            tenantService = new TenantService();
            InitializeComponent();

            // Đổ dữ liệu vào combobox phòng và người thuê chính
            cbRoom.ItemsSource = roomService.GetAllRoomsHaveStatusOccupied();  // Danh sách phòng trống
            cbMainTenant.ItemsSource = tenantService.GetTenantDisplayDtos();  // Danh sách người thuê
        }

        private void btnCreateContract_Click(object sender, RoutedEventArgs e)
        {
            _service = new ContractService();

            // Kiểm tra nếu chưa chọn phòng
            if (cbRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng.");
                return;
            }

            // Kiểm tra nếu chưa chọn người thuê chính
            if (cbMainTenant.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người thuê chính.");
                return;
            }

            // Kiểm tra ngày bắt đầu
            if (!dpStartDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu hợp đồng.");
                return;
            }

            // Kiểm tra ngày kết thúc
            if (!dpEndDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày kết thúc hợp đồng.");
                return;
            }

            // Kiểm tra ngày kết thúc phải sau ngày bắt đầu
            if (dpEndDate.SelectedDate < dpStartDate.SelectedDate)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.");
                return;
            }

            // Kiểm tra tính hợp lệ của tiền cọc
            decimal deposit;
            if (!decimal.TryParse(txtDeposit.Text, out deposit) || deposit < 0)
            {
                MessageBox.Show("Tiền cọc không hợp lệ.");
                return;
            }

            // Lấy ID phòng và người thuê từ ComboBox
            int roomId = (int)cbRoom.SelectedValue;
            int mainTenantId = (int)cbMainTenant.SelectedValue;

            // Tạo đối tượng hợp đồng
            var contract = new Contract
            {
                RoomId = roomId,
                TenantId = mainTenantId,
                StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value),
                EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value),
                Deposit = deposit,
                Note = txtNote.Text,
                IsActive = true
            };

            // Gọi service để lưu hợp đồng và cập nhật trạng thái phòng
            _service.Addcontract(contract, roomId);

            MessageBox.Show("Tạo hợp đồng thành công.");

            // Đóng cửa sổ tạo hợp đồng, mở lại màn quản lý hợp đồng
            this.Close();
            new ContractManager().ShowDialog();
        }
    }
}
