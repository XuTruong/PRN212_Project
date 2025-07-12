using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class RoomTenant
{
    public int RoomTenantId { get; set; }

    public int? ContractId { get; set; }

    public int? TenantId { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual Tenant? Tenant { get; set; }
}
