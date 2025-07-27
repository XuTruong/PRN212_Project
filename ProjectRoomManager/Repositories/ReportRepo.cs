using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DTO;

namespace Repositories
{
    public class ReportRepo
    {
        private RoomManagerContext _context;

        public ReportRepo()
        {
            _context = new RoomManagerContext();
        }

        public List<RevenueReportDto> GetRevenueReport(DateTime fromDate, DateTime toDate)
        {
            var fromMonthYear = fromDate.ToString("yyyy-MM");
            var toMonthYear = toDate.ToString("yyyy-MM");

            var bills = _context.MonthlyBills
                .Include(b => b.Contract)
                .ThenInclude(c => c!.Room)
                .Where(b => string.Compare(b.MonthYear, fromMonthYear) >= 0 &&
                           string.Compare(b.MonthYear, toMonthYear) <= 0)
                .ToList();

            var revenueReport = bills
                .GroupBy(b => b.MonthYear)
                .Select(g => new RevenueReportDto
                {
                    MonthYear = g.Key ?? "",
                    TotalRevenue = g.Sum(b => b.TotalAmount ?? 0),
                    TotalBills = g.Count(),
                    PaidBills = g.Count(b => b.IsPaid == true),
                    UnpaidBills = g.Count(b => b.IsPaid == false),
                    PaidAmount = g.Where(b => b.IsPaid == true).Sum(b => b.TotalAmount ?? 0),
                    UnpaidAmount = g.Where(b => b.IsPaid == false).Sum(b => b.TotalAmount ?? 0)
                })
                .OrderBy(r => r.MonthYear)
                .ToList();

            return revenueReport;
        }

        public List<RoomReportDto> GetRoomReport(DateTime fromDate, DateTime toDate)
        {
            var fromMonthYear = fromDate.ToString("yyyy-MM");
            var toMonthYear = toDate.ToString("yyyy-MM");

            var roomReport = _context.MonthlyBills
                .Include(b => b.Contract)
                .ThenInclude(c => c!.Room)
                .Include(b => b.Contract)
                .ThenInclude(c => c!.RoomTenants)
                .ThenInclude(rt => rt.Tenant)
                .Where(b => string.Compare(b.MonthYear, fromMonthYear) >= 0 &&
                           string.Compare(b.MonthYear, toMonthYear) <= 0)
                .Select(b => new RoomReportDto
                {
                    RoomId = b.Contract!.Room!.RoomId,
                    RoomNumber = b.Contract!.Room!.RoomName ?? "",
                    TenantName = b.Contract!.RoomTenants.FirstOrDefault()!.Tenant!.FullName ?? "",
                    RoomPrice = b.RoomPrice ?? 0,
                    MonthYear = b.MonthYear ?? "",
                    ElectricityUsed = (b.ElectricityNew ?? 0) - (b.ElectricityOld ?? 0),
                    WaterUsed = (b.WaterNew ?? 0) - (b.WaterOld ?? 0),
                    ElectricityAmount = ((b.ElectricityNew ?? 0) - (b.ElectricityOld ?? 0)) * (b.ElectricityRate ?? 0),
                    WaterAmount = ((b.WaterNew ?? 0) - (b.WaterOld ?? 0)) * (b.WaterRate ?? 0),
                    TotalAmount = b.TotalAmount ?? 0,
                    IsPaid = b.IsPaid ?? false,
                    PaymentStatus = b.IsPaid == true ? "Đã thanh toán" : "Chưa thanh toán"
                })
                .OrderBy(r => r.RoomNumber)
                .ThenBy(r => r.MonthYear)
                .ToList();

            return roomReport;
        }

        public List<PaymentReportDto> GetPaymentReport(DateTime fromDate, DateTime toDate)
        {
            var fromMonthYear = fromDate.ToString("yyyy-MM");
            var toMonthYear = toDate.ToString("yyyy-MM");

            var paymentReport = _context.MonthlyBills
                .Include(b => b.Contract)
                .ThenInclude(c => c!.Room)
                .Include(b => b.Contract)
                .ThenInclude(c => c!.RoomTenants)
                .ThenInclude(rt => rt.Tenant)
                .Where(b => string.Compare(b.MonthYear, fromMonthYear) >= 0 &&
                           string.Compare(b.MonthYear, toMonthYear) <= 0)
                .Select(b => new PaymentReportDto
                {
                    BillId = b.BillId,
                    MonthYear = b.MonthYear ?? "",
                    RoomNumber = b.Contract!.Room!.RoomName ?? "",
                    TenantName = b.Contract!.RoomTenants.FirstOrDefault()!.Tenant!.FullName ?? "",
                    TotalAmount = b.TotalAmount ?? 0,
                    IsPaid = b.IsPaid ?? false,
                    PaymentDate = b.PaymentDate,
                    DaysOverdue = b.IsPaid == false ?
                        (DateTime.Now - DateTime.ParseExact(b.MonthYear + "/01", "yyyy-MM-dd", null).AddMonths(1)).Days : 0,
                    Status = b.IsPaid == true ? "Đã thanh toán" :
                            (DateTime.Now - DateTime.ParseExact(b.MonthYear + "/01", "yyyy-MM-dd", null).AddMonths(1)).Days > 0 ?
                            "Quá hạn" : "Chưa đến hạn"
                })
                .OrderBy(r => r.MonthYear)
                .ThenBy(r => r.RoomNumber)
                .ToList();

            return paymentReport;
        }

        public List<UtilityReportDto> GetUtilityReport(DateTime fromDate, DateTime toDate)
        {
            var fromMonthYear = fromDate.ToString("yyyy-MM");
            var toMonthYear = toDate.ToString("yyyy-MM");

            var utilityReport = _context.MonthlyBills
                .Include(b => b.Contract)
                .ThenInclude(c => c!.Room)
                .Where(b => string.Compare(b.MonthYear, fromMonthYear) >= 0 &&
                           string.Compare(b.MonthYear, toMonthYear) <= 0)
                .Select(b => new UtilityReportDto
                {
                    MonthYear = b.MonthYear ?? "",
                    RoomNumber = b.Contract!.Room!.RoomName ?? "",
                    ElectricityOld = b.ElectricityOld ?? 0,
                    ElectricityNew = b.ElectricityNew ?? 0,
                    ElectricityUsed = (b.ElectricityNew ?? 0) - (b.ElectricityOld ?? 0),
                    ElectricityRate = b.ElectricityRate ?? 0,
                    ElectricityAmount = ((b.ElectricityNew ?? 0) - (b.ElectricityOld ?? 0)) * (b.ElectricityRate ?? 0),
                    WaterOld = b.WaterOld ?? 0,
                    WaterNew = b.WaterNew ?? 0,
                    WaterUsed = (b.WaterNew ?? 0) - (b.WaterOld ?? 0),
                    WaterRate = b.WaterRate ?? 0,
                    WaterAmount = ((b.WaterNew ?? 0) - (b.WaterOld ?? 0)) * (b.WaterRate ?? 0),
                    TotalUtilityAmount = ((b.ElectricityNew ?? 0) - (b.ElectricityOld ?? 0)) * (b.ElectricityRate ?? 0) +
                                        ((b.WaterNew ?? 0) - (b.WaterOld ?? 0)) * (b.WaterRate ?? 0)
                })
                .OrderBy(r => r.MonthYear)
                .ThenBy(r => r.RoomNumber)
                .ToList();

            return utilityReport;
        }
    }
}
