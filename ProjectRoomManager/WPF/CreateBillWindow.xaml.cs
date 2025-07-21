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
using DataAccess.Models;
using Services;

namespace WPF
{
    /// <summary>
    /// Interaction logic for CreateBillWindow.xaml
    /// </summary>
    public partial class CreateBillWindow : Window
    {
        private RoomService roomService;

        private ContractService contractService;

        private MonthlyBillService monthlyBillService;

        public CreateBillWindow()
        {
            roomService = new RoomService();
            InitializeComponent();
            cbRoom.ItemsSource = roomService.GetAllRoomsHaveStatusOccupied();
        }

        private void CreateBillButton_Click(object sender, RoutedEventArgs e)
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

                if (monthlyBillService.checkExistRoomMonthCurrent(contractId, monthYear))
                {
decimal totalAmount = CalculateTotalAmount(
                    electricityOld, electricityNew, electricityRate,
                    waterOld, waterNew, waterRate, roomPrice);

                var bill = new MonthlyBill
                {
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

                monthlyBillService.CreateBill(bill);
                MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                } else
                {
                    MessageBox.Show("Bạn đã thêm phòng này vào danh sách tháng này rồi.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                
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
