using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class MonthlyBill
{
    public int BillId { get; set; }

    public int? ContractId { get; set; }

    public string? MonthYear { get; set; }

    public int? ElectricityOld { get; set; }

    public int? ElectricityNew { get; set; }

    public int? WaterOld { get; set; }

    public int? WaterNew { get; set; }

    public decimal? ElectricityRate { get; set; }

    public decimal? WaterRate { get; set; }

    public decimal? RoomPrice { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? IsPaid { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
