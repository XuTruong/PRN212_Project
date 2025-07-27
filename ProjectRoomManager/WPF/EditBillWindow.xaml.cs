using System.Windows;
using DataAccess.Models;
using Services;

namespace WPF
{
    /// <summary>
    /// Interaction logic for EditBillWindow.xaml
    /// </summary>
    public partial class EditBillWindow : Window
    {

        private int _billId;
        private MonthlyBillService monthlyBillService;
        private ContractService contractService;
        private RoomService roomService;

        public EditBillWindow(int billId)
        {
            InitializeComponent();
            roomService = new RoomService();
            _billId = billId;

            LoadRooms();
            LoadBillData();
        }

        private void LoadRooms()
        {
            var roomService = new RoomService(); // Bạn cần có RoomService
            var rooms = roomService.GetAllRoomsHaveStatusOccupied(); // Trả về List<Room>
            cbRoom.ItemsSource = rooms;
        }

        private void LoadBillData()
        {
            var roomService = new RoomService();
            monthlyBillService = new MonthlyBillService();
            var bill = monthlyBillService.GetMonthlyBillById(_billId); // Bạn cần tạo hàm này trong MonthlyBillService

            if (bill != null)
            {
                cbRoom.SelectedValue = roomService.GetRoomIdByContractId(bill.BillId);
                MonthYearTextBox.Text = bill.MonthYear;
                ElectricityOldTextBox.Text = bill.ElectricityOld.ToString();
                ElectricityNewTextBox.Text = bill.ElectricityNew.ToString();
                WaterOldTextBox.Text = bill.WaterOld.ToString();
                WaterNewTextBox.Text = bill.WaterNew.ToString();
                ElectricityRateTextBox.Text = bill.ElectricityRate.ToString();
                WaterRateTextBox.Text = bill.WaterRate.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void UpdateBillButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contractService = new ContractService();
                monthlyBillService = new MonthlyBillService();

                if (cbRoom.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(cbRoom.SelectedValue?.ToString(), out int roomId))
                {
                    MessageBox.Show("Phòng không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string monthYear = MonthYearTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(monthYear))
                {
                    MessageBox.Show("Vui lòng nhập tháng/năm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(monthYear, @"^\d{4}-(0[1-9]|1[0-2])$"))
                {
                    MessageBox.Show("Định dạng tháng/năm phải là yyyy-MM (ví dụ: 2025-07).", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(ElectricityOldTextBox.Text, out int electricityOld) ||
                    !int.TryParse(ElectricityNewTextBox.Text, out int electricityNew) ||
                    !int.TryParse(WaterOldTextBox.Text, out int waterOld) ||
                    !int.TryParse(WaterNewTextBox.Text, out int waterNew) ||
                    !decimal.TryParse(ElectricityRateTextBox.Text, out decimal electricityRate) ||
                    !decimal.TryParse(WaterRateTextBox.Text, out decimal waterRate))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (electricityNew < electricityOld)
                {
                    MessageBox.Show("Chỉ số điện mới phải lớn hơn hoặc bằng chỉ số cũ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (waterNew < waterOld)
                {
                    MessageBox.Show("Chỉ số nước mới phải lớn hơn hoặc bằng chỉ số cũ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var roomPrice = GetCurrentRoomPrice(roomId);
                var contractId = contractService.ChangeRoomIdToContractId(roomId);

                if (contractId == 0)
                {
                    MessageBox.Show("Không tìm thấy hợp đồng đang hoạt động với phòng này.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                decimal totalAmount = CalculateTotalAmount(
                                    electricityOld, electricityNew, electricityRate,
                                    waterOld, waterNew, waterRate, roomPrice);

                var bill = new MonthlyBill
                {
                    BillId = _billId,
                    ContractId = contractId,
                    MonthYear = monthYear,
                    ElectricityOld = electricityOld,
                    ElectricityNew = electricityNew,
                    WaterOld = waterOld,
                    WaterNew = waterNew,
                    ElectricityRate = electricityRate,
                    WaterRate = waterRate,
                    RoomPrice = roomPrice,
                    TotalAmount = totalAmount,
                    IsPaid = false,
                    PaymentDate = null
                };

                monthlyBillService.UpdateBill(bill);
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private decimal GetCurrentRoomPrice(int roomId)
        {
            return roomService.GetCurrentRoomPrice(roomId);
        }

        private decimal CalculateTotalAmount(int electricityOld, int electricityNew, decimal electricityRate, int waterOld, int waterNew,
                            decimal waterRate, decimal roomPrice)
        {
            int electricityUsage = electricityNew - electricityOld;
            int waterUsage = waterNew - waterOld;

            decimal electricityCost = electricityUsage * electricityRate;
            decimal waterCost = waterUsage * waterRate;

            decimal total = electricityCost + waterCost + roomPrice;
            return total;
        }
    }
}
