using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public int? RoomId { get; set; }

    public int? TenantId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Deposit { get; set; }

    public string? Note { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<MonthlyBill> MonthlyBills { get; set; } = new List<MonthlyBill>();

    public virtual Room? Room { get; set; }

    public virtual ICollection<RoomTenant> RoomTenants { get; set; } = new List<RoomTenant>();

    public virtual Tenant? Tenant { get; set; }
}
