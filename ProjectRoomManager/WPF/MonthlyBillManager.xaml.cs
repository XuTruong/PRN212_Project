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
using Microsoft.EntityFrameworkCore;
using Repositories.DTO;
using Services;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MonthlyBillManager.xaml
    /// </summary>
    public partial class MonthlyBillManager : Window
    {
        private MonthlyBillService _service;
        private RoomManagerContext context;
        private int SelectedBillId = 0;

        public MonthlyBillManager()
        {
            InitializeComponent();

            int currentYear = DateTime.Now.Year;
            for (int year = 2020; year <= currentYear; year++)
            {
                cbYear.Items.Add(year.ToString());
            }

            cbMonth.SelectedIndex = DateTime.Now.Month - 1; // chọn tháng hiện tại
            cbYear.SelectedItem = currentYear.ToString();    // chọn năm hiện tại

            _service = new MonthlyBillService();
            dgMonthlyBills.ItemsSource = _service.GetMonthlyBillsByEx(((ComboBoxItem)cbMonth.SelectedItem).Content.ToString() + cbYear.SelectedItem.ToString());
        }

        private void btnCreateBill_Click(object sender, RoutedEventArgs e)
        {
            var createBillWindow = new CreateBillWindow();
            createBillWindow.ShowDialog();
        }

        private void btnEditBill_Click(object sender, RoutedEventArgs e)
        {
            if (dgMonthlyBills.SelectedItem is MonthlyBillDto selectedBill)
            {
                SelectedBillId = selectedBill.BillId;
                var editWindow = new EditBillWindow((int)SelectedBillId);
                editWindow.ShowDialog();
            } else
            {
                MessageBox.Show("Vui lòng chọn vào 1 hóa đơn để cập nhật.");
                return;
            }
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


            dgMonthlyBills.ItemsSource = _service.GetMonthlyBillsByEx(monthYear);
            
        }
    }
}
