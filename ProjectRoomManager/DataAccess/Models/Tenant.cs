using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Tenant
{
    public int TenantId { get; set; }

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? IdNumber { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<RoomTenant> RoomTenants { get; set; } = new List<RoomTenant>();
}
