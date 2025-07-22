using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using Services;
using Repositories.DTO;

namespace WPF
{
    public partial class ReportManager : Window
    {
        private ReportService _reportService;

        public ReportManager()
        {
            InitializeComponent();
            _reportService = new ReportService();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            // Set default dates (current month)
            dpFromDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dpToDate.SelectedDate = DateTime.Now;
            
            // Set default report type
            cmbReportType.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo!", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!dpFromDate.SelectedDate.HasValue || !dpToDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn khoảng thời gian!", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var fromDate = dpFromDate.SelectedDate.Value;
            var toDate = dpToDate.SelectedDate.Value;

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var reportType = ((ComboBoxItem)cmbReportType.SelectedItem).Tag.ToString();
                LoadReport(reportType, fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadReport(string reportType, DateTime fromDate, DateTime toDate)
        {
            dgReport.Columns.Clear();

            switch (reportType)
            {
                case "Revenue":
                    LoadRevenueReport(fromDate, toDate);
                    break;
                case "Room":
                    LoadRoomReport(fromDate, toDate);
                    break;
                case "Payment":
                    LoadPaymentReport(fromDate, toDate);
                    break;
                case "Utility":
                    LoadUtilityReport(fromDate, toDate);
                    break;
            }
        }

        private void LoadRevenueReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var data = _reportService.GetRevenueReport(fromDate, toDate);
                
                // Debug output
                MessageBox.Show($"Tìm thấy {data.Count} dòng dữ liệu báo cáo doanh thu\nKhoảng thời gian: {fromDate:yyyy-MM} đến {toDate:yyyy-MM}", 
                    "Debug", MessageBoxButton.OK, MessageBoxImage.Information);

                // Define columns for Revenue Report
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Tháng/Năm",
                    Binding = new Binding("MonthYear"),
                    Width = new DataGridLength(120)
                });
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Tổng Doanh thu",
                    Binding = new Binding("TotalRevenue") { StringFormat = "{0:N0} VNĐ" },
                    Width = new DataGridLength(150)
                });
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Tổng HĐ",
                    Binding = new Binding("TotalBills"),
                    Width = new DataGridLength(80)
                });
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Đã TT",
                    Binding = new Binding("PaidBills"),
                    Width = new DataGridLength(80)
                });
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Chưa TT",
                    Binding = new Binding("UnpaidBills"),
                    Width = new DataGridLength(80)
                });
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Đã thu",
                    Binding = new Binding("PaidAmount") { StringFormat = "{0:N0} VNĐ" },
                    Width = new DataGridLength(150)
                });
                dgReport.Columns.Add(new DataGridTextColumn
                {
                    Header = "Chưa thu",
                    Binding = new Binding("UnpaidAmount") { StringFormat = "{0:N0} VNĐ" },
                    Width = new DataGridLength(150)
                });

                dgReport.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo doanh thu: {ex.Message}\n\nStack trace: {ex.StackTrace}", 
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadRoomReport(DateTime fromDate, DateTime toDate)
        {
            var data = _reportService.GetRoomReport(fromDate, toDate);

            // Define columns for Room Report
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Phòng",
                Binding = new Binding("RoomNumber"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Người thuê",
                Binding = new Binding("TenantName"),
                Width = new DataGridLength(150)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tháng/Năm",
                Binding = new Binding("MonthYear"),
                Width = new DataGridLength(100)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Giá phòng",
                Binding = new Binding("RoomPrice") { StringFormat = "{0:N0}" },
                Width = new DataGridLength(100)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Điện (kWh)",
                Binding = new Binding("ElectricityUsed"),
                Width = new DataGridLength(90)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Nước (m³)",
                Binding = new Binding("WaterUsed"),
                Width = new DataGridLength(90)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tổng tiền",
                Binding = new Binding("TotalAmount") { StringFormat = "{0:N0}" },
                Width = new DataGridLength(120)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Trạng thái",
                Binding = new Binding("PaymentStatus"),
                Width = new DataGridLength(120)
            });

            dgReport.ItemsSource = data;
        }

        private void LoadPaymentReport(DateTime fromDate, DateTime toDate)
        {
            var data = _reportService.GetPaymentReport(fromDate, toDate);

            // Define columns for Payment Report
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Mã HĐ",
                Binding = new Binding("BillId"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tháng/Năm",
                Binding = new Binding("MonthYear"),
                Width = new DataGridLength(100)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Phòng",
                Binding = new Binding("RoomNumber"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Người thuê",
                Binding = new Binding("TenantName"),
                Width = new DataGridLength(150)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Số tiền",
                Binding = new Binding("TotalAmount") { StringFormat = "{0:N0} VNĐ" },
                Width = new DataGridLength(120)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Ngày TT",
                Binding = new Binding("PaymentDate") { StringFormat = "{0:dd/MM/yyyy}" },
                Width = new DataGridLength(100)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Quá hạn (ngày)",
                Binding = new Binding("DaysOverdue"),
                Width = new DataGridLength(100)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Trạng thái",
                Binding = new Binding("Status"),
                Width = new DataGridLength(120)
            });

            dgReport.ItemsSource = data;
        }

        private void LoadUtilityReport(DateTime fromDate, DateTime toDate)
        {
            var data = _reportService.GetUtilityReport(fromDate, toDate);

            // Define columns for Utility Report
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tháng/Năm",
                Binding = new Binding("MonthYear"),
                Width = new DataGridLength(100)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Phòng",
                Binding = new Binding("RoomNumber"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Điện cũ",
                Binding = new Binding("ElectricityOld"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Điện mới",
                Binding = new Binding("ElectricityNew"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tiêu thụ",
                Binding = new Binding("ElectricityUsed"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Nước cũ",
                Binding = new Binding("WaterOld"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Nước mới",
                Binding = new Binding("WaterNew"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tiêu thụ",
                Binding = new Binding("WaterUsed"),
                Width = new DataGridLength(80)
            });
            dgReport.Columns.Add(new DataGridTextColumn
            {
                Header = "Tổng tiền",
                Binding = new Binding("TotalUtilityAmount") { StringFormat = "{0:N0}" },
                Width = new DataGridLength(120)
            });

            dgReport.ItemsSource = data;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (dgReport.ItemsSource == null)
            {
                MessageBox.Show("Vui lòng xem báo cáo trước khi xuất Excel!", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    DefaultExt = "xlsx",
                    FileName = $"BaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var reportType = ((ComboBoxItem)cmbReportType.SelectedItem).Tag.ToString();
                    var fromDate = dpFromDate.SelectedDate.Value;
                    var toDate = dpToDate.SelectedDate.Value;

                    ExportToExcel(reportType, fromDate, toDate, saveFileDialog.FileName);
                    
                    MessageBox.Show($"Xuất báo cáo thành công!\nFile được lưu tại: {saveFileDialog.FileName}", 
                        "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportToExcel(string reportType, DateTime fromDate, DateTime toDate, string filePath)
        {
            switch (reportType)
            {
                case "Revenue":
                    var revenueData = _reportService.GetRevenueReport(fromDate, toDate);
                    _reportService.ExportRevenueReportToExcel(revenueData, filePath);
                    break;
                case "Room":
                    var roomData = _reportService.GetRoomReport(fromDate, toDate);
                    _reportService.ExportRoomReportToExcel(roomData, filePath);
                    break;
                case "Payment":
                    var paymentData = _reportService.GetPaymentReport(fromDate, toDate);
                    _reportService.ExportPaymentReportToExcel(paymentData, filePath);
                    break;
                case "Utility":
                    var utilityData = _reportService.GetUtilityReport(fromDate, toDate);
                    _reportService.ExportUtilityReportToExcel(utilityData, filePath);
                    break;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
