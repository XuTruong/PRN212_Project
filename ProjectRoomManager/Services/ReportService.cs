using Repositories;
using Repositories.DTO;
using ClosedXML.Excel;

namespace Services
{
    public class ReportService
    {
        private ReportRepo _reportRepo;

        public ReportService()
        {
            _reportRepo = new ReportRepo();
        }

        public List<RevenueReportDto> GetRevenueReport(DateTime fromDate, DateTime toDate)
        {
            return _reportRepo.GetRevenueReport(fromDate, toDate);
        }

        public List<RoomReportDto> GetRoomReport(DateTime fromDate, DateTime toDate)
        {
            return _reportRepo.GetRoomReport(fromDate, toDate);
        }

        public List<PaymentReportDto> GetPaymentReport(DateTime fromDate, DateTime toDate)
        {
            return _reportRepo.GetPaymentReport(fromDate, toDate);
        }

        public List<UtilityReportDto> GetUtilityReport(DateTime fromDate, DateTime toDate)
        {
            return _reportRepo.GetUtilityReport(fromDate, toDate);
        }

        public void ExportRevenueReportToExcel(List<RevenueReportDto> data, string filePath)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Báo cáo Doanh thu");

            // Header
            worksheet.Cell(1, 1).Value = "BÁOO CÁO DOANH THU THEO THÁNG";
            worksheet.Range(1, 1, 1, 7).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Column headers
            worksheet.Cell(3, 1).Value = "Tháng/Năm";
            worksheet.Cell(3, 2).Value = "Tổng Doanh thu";
            worksheet.Cell(3, 3).Value = "Tổng Hóa đơn";
            worksheet.Cell(3, 4).Value = "Đã thanh toán";
            worksheet.Cell(3, 5).Value = "Chưa thanh toán";
            worksheet.Cell(3, 6).Value = "Số tiền đã thu";
            worksheet.Cell(3, 7).Value = "Số tiền chưa thu";

            // Make headers bold
            worksheet.Range(3, 1, 3, 7).Style.Font.Bold = true;

            // Data
            int row = 4;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.MonthYear;
                worksheet.Cell(row, 2).Value = item.TotalRevenue;
                worksheet.Cell(row, 3).Value = item.TotalBills;
                worksheet.Cell(row, 4).Value = item.PaidBills;
                worksheet.Cell(row, 5).Value = item.UnpaidBills;
                worksheet.Cell(row, 6).Value = item.PaidAmount;
                worksheet.Cell(row, 7).Value = item.UnpaidAmount;
                row++;
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }

        public void ExportRoomReportToExcel(List<RoomReportDto> data, string filePath)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Báo cáo Phòng");

            // Header
            worksheet.Cell(1, 1).Value = "BÁO CÁO CHI TIẾT THEO PHÒNG";
            worksheet.Range(1, 1, 1, 10).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Column headers
            worksheet.Cell(3, 1).Value = "Phòng";
            worksheet.Cell(3, 2).Value = "Người thuê";
            worksheet.Cell(3, 3).Value = "Tháng/Năm";
            worksheet.Cell(3, 4).Value = "Giá phòng";
            worksheet.Cell(3, 5).Value = "Điện (kWh)";
            worksheet.Cell(3, 6).Value = "Nước (m³)";
            worksheet.Cell(3, 7).Value = "Tiền điện";
            worksheet.Cell(3, 8).Value = "Tiền nước";
            worksheet.Cell(3, 9).Value = "Tổng tiền";
            worksheet.Cell(3, 10).Value = "Trạng thái";

            // Make headers bold
            worksheet.Range(3, 1, 3, 10).Style.Font.Bold = true;

            // Data
            int row = 4;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.RoomNumber;
                worksheet.Cell(row, 2).Value = item.TenantName;
                worksheet.Cell(row, 3).Value = item.MonthYear;
                worksheet.Cell(row, 4).Value = item.RoomPrice;
                worksheet.Cell(row, 5).Value = item.ElectricityUsed;
                worksheet.Cell(row, 6).Value = item.WaterUsed;
                worksheet.Cell(row, 7).Value = item.ElectricityAmount;
                worksheet.Cell(row, 8).Value = item.WaterAmount;
                worksheet.Cell(row, 9).Value = item.TotalAmount;
                worksheet.Cell(row, 10).Value = item.PaymentStatus;
                row++;
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }

        public void ExportPaymentReportToExcel(List<PaymentReportDto> data, string filePath)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Báo cáo Thanh toán");

            // Header
            worksheet.Cell(1, 1).Value = "BÁO CÁO TÌNH HÌNH THANH TOÁN";
            worksheet.Range(1, 1, 1, 8).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Column headers
            worksheet.Cell(3, 1).Value = "Mã HĐ";
            worksheet.Cell(3, 2).Value = "Tháng/Năm";
            worksheet.Cell(3, 3).Value = "Phòng";
            worksheet.Cell(3, 4).Value = "Người thuê";
            worksheet.Cell(3, 5).Value = "Số tiền";
            worksheet.Cell(3, 6).Value = "Ngày thanh toán";
            worksheet.Cell(3, 7).Value = "Ngày quá hạn";
            worksheet.Cell(3, 8).Value = "Trạng thái";

            // Make headers bold
            worksheet.Range(3, 1, 3, 8).Style.Font.Bold = true;

            // Data
            int row = 4;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.BillId;
                worksheet.Cell(row, 2).Value = item.MonthYear;
                worksheet.Cell(row, 3).Value = item.RoomNumber;
                worksheet.Cell(row, 4).Value = item.TenantName;
                worksheet.Cell(row, 5).Value = item.TotalAmount;
                worksheet.Cell(row, 6).Value = item.PaymentDate?.ToString("dd/MM/yyyy") ?? "";
                worksheet.Cell(row, 7).Value = item.DaysOverdue > 0 ? $"{item.DaysOverdue} ngày" : "";
                worksheet.Cell(row, 8).Value = item.Status;
                row++;
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }

        public void ExportUtilityReportToExcel(List<UtilityReportDto> data, string filePath)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Báo cáo Điện nước");

            // Header
            worksheet.Cell(1, 1).Value = "BÁO CÁO SỬ DỤNG ĐIỆN NƯỚC";
            worksheet.Range(1, 1, 1, 12).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Column headers
            worksheet.Cell(3, 1).Value = "Tháng/Năm";
            worksheet.Cell(3, 2).Value = "Phòng";
            worksheet.Cell(3, 3).Value = "Điện cũ";
            worksheet.Cell(3, 4).Value = "Điện mới";
            worksheet.Cell(3, 5).Value = "Tiêu thụ điện";
            worksheet.Cell(3, 6).Value = "Đơn giá điện";
            worksheet.Cell(3, 7).Value = "Tiền điện";
            worksheet.Cell(3, 8).Value = "Nước cũ";
            worksheet.Cell(3, 9).Value = "Nước mới";
            worksheet.Cell(3, 10).Value = "Tiêu thụ nước";
            worksheet.Cell(3, 11).Value = "Đơn giá nước";
            worksheet.Cell(3, 12).Value = "Tiền nước";

            // Make headers bold
            worksheet.Range(3, 1, 3, 12).Style.Font.Bold = true;

            // Data
            int row = 4;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.MonthYear;
                worksheet.Cell(row, 2).Value = item.RoomNumber;
                worksheet.Cell(row, 3).Value = item.ElectricityOld;
                worksheet.Cell(row, 4).Value = item.ElectricityNew;
                worksheet.Cell(row, 5).Value = item.ElectricityUsed;
                worksheet.Cell(row, 6).Value = item.ElectricityRate;
                worksheet.Cell(row, 7).Value = item.ElectricityAmount;
                worksheet.Cell(row, 8).Value = item.WaterOld;
                worksheet.Cell(row, 9).Value = item.WaterNew;
                worksheet.Cell(row, 10).Value = item.WaterUsed;
                worksheet.Cell(row, 11).Value = item.WaterRate;
                worksheet.Cell(row, 12).Value = item.WaterAmount;
                row++;
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }
    }
}
