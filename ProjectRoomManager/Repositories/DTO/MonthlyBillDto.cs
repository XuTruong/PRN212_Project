using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTO
{
    public class MonthlyBillDto
    {
        public int BillId { get; set; }
        public string RoomName { get; set; }
        public string MonthYear { get; set; }
        public int ElectricityOld { get; set; }
        public int ElectricityNew { get; set; }
        public int WaterOld { get; set; }
        public int WaterNew { get; set; }
        public decimal ElectricityRate { get; set; }
        public decimal WaterRate { get; set; }
        public decimal RoomPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
