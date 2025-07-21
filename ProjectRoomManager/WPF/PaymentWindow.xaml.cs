using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ClosedXML.Excel;
using DataAccess.Models;
using Microsoft.Win32;
using Repositories.DTO;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private RoomManagerContext _context = new RoomManagerContext();
        public ObservableCollection<PaymentItem> PaymentItems { get; set; }

        String monthYear = "";

        public PaymentWindow()
        {
            InitializeComponent();

            int currentYear = DateTime.Now.Year;
            for (int year = 2020; year <= currentYear; year++)
            {
                cbYear.Items.Add(year.ToString());
            }

            cbMonth.SelectedIndex = DateTime.Now.Month - 1; // chọn tháng hiện tại
            cbYear.SelectedItem = currentYear.ToString();    // chọn năm hiện tại

            monthYear = ((ComboBoxItem)cbMonth.SelectedItem).Content.ToString() + cbYear.SelectedItem.ToString();


            LoadUnpaidBills();
            DataContext = this;

        }

        private void LoadUnpaidBills()
        {

            if (string.IsNullOrWhiteSpace(monthYear))
            {
                MessageBox.Show("Vui lòng nhập tháng/năm theo định dạng yyyy-MM.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            PaymentItems = new ObservableCollection<PaymentItem>(
                from mb in _context.MonthlyBills
                join ct in _context.Contracts on mb.ContractId equals ct.ContractId
                join room in _context.Rooms on ct.RoomId equals room.RoomId
                where mb.IsPaid == false && mb.MonthYear == monthYear
                select new PaymentItem
                {
                    BillId = mb.BillId,
                    RoomName = room.RoomName,
                    Amount = mb.TotalAmount ?? 0,
                    PaymentDate = DateTime.Now,
                    Note = "",
                    IsSelected = false

                }
            );

            dgPayments.ItemsSource = PaymentItems;
        }
        private void SavePayments_Click(object sender, RoutedEventArgs e)
        {
            var selectedPayments = PaymentItems.Where(p => p.IsSelected).ToList();

            if (!selectedPayments.Any())
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 hóa đơn để thanh toán.", "Thông báo");
                return;
            }

            foreach (var item in selectedPayments)
            {
                // Ghi vào bảng Payment
                var payment = new Payment
                {
                    BillId = item.BillId,
                    Amount = item.Amount,
                    PaymentDate = DateOnly.FromDateTime(item.PaymentDate),
                    Note = item.Note
                };
                _context.Payments.Add(payment);

                // Cập nhật trạng thái hóa đơn
                var bill = _context.MonthlyBills.Find(item.BillId);
                if (bill != null)
                {
                    bill.IsPaid = true;
                    bill.PaymentDate = DateOnly.FromDateTime(item.PaymentDate);
                }
            }

            _context.SaveChanges();
            MessageBox.Show("Thanh toán thành công!", "Thông báo");
            this.Close();
        }

        private void btnFilterByMonth_Click(object sender, RoutedEventArgs e)
        {
            if (cbMonth.SelectedItem == null || cbYear.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedMonth = ((ComboBoxItem)cbMonth.SelectedItem).Content.ToString();
            string selectedYear = cbYear.SelectedItem.ToString();

            string monthYear = $"{selectedYear}-{selectedMonth}"; // dạng yyyy-MM

            PaymentItems = new ObservableCollection<PaymentItem>(
                from mb in _context.MonthlyBills
                join ct in _context.Contracts on mb.ContractId equals ct.ContractId
                join room in _context.Rooms on ct.RoomId equals room.RoomId
                where mb.IsPaid == false && mb.MonthYear == monthYear
                select new PaymentItem
                {
                    BillId = mb.BillId,
                    RoomName = room.RoomName,
                    Amount = mb.TotalAmount ?? 0,
                    PaymentDate = DateTime.Now,
                    Note = "",
                    IsSelected = false
                }
            );

            dgPayments.ItemsSource = PaymentItems;
        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("ThanhToan");

            // Header
            worksheet.Cell(1, 1).Value = "Phòng";
            worksheet.Cell(1, 2).Value = "Số tiền";
            worksheet.Cell(1, 3).Value = "Ngày thanh toán";
            worksheet.Cell(1, 4).Value = "Ghi chú";

            // Data
            var payments = dgPayments.ItemsSource as IEnumerable<dynamic>; // hoặc thay bằng kiểu của bạn
            int row = 2;
            foreach (var payment in payments)
            {
                worksheet.Cell(row, 1).Value = payment.RoomName;
                worksheet.Cell(row, 2).Value = payment.Amount;
                worksheet.Cell(row, 3).Value = payment.PaymentDate?.ToString("dd/MM/yyyy");
                worksheet.Cell(row, 4).Value = payment.Note;
                row++;
            }

            // Lưu file
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "BaoCaoThanhToan.xlsx"
            };

            if (saveDialog.ShowDialog() == true)
            {
                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
