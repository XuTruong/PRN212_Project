using System;

namespace Repositories.DTO
{
    public class RevenueReportDto
    {
        public string MonthYear { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
        public int TotalBills { get; set; }
        public int PaidBills { get; set; }
        public int UnpaidBills { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal UnpaidAmount { get; set; }
    }

    public class RoomReportDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string TenantName { get; set; } = string.Empty;
        public decimal RoomPrice { get; set; }
        public string MonthYear { get; set; } = string.Empty;
        public int ElectricityUsed { get; set; }
        public int WaterUsed { get; set; }
        public decimal ElectricityAmount { get; set; }
        public decimal WaterAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
    }

    public class PaymentReportDto
    {
        public int BillId { get; set; }
        public string MonthYear { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public string TenantName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateOnly? PaymentDate { get; set; }
        public int DaysOverdue { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class UtilityReportDto
    {
        public string MonthYear { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public int ElectricityOld { get; set; }
        public int ElectricityNew { get; set; }
        public int ElectricityUsed { get; set; }
        public decimal ElectricityRate { get; set; }
        public decimal ElectricityAmount { get; set; }
        public int WaterOld { get; set; }
        public int WaterNew { get; set; }
        public int WaterUsed { get; set; }
        public decimal WaterRate { get; set; }
        public decimal WaterAmount { get; set; }
        public decimal TotalUtilityAmount { get; set; }
    }
}
