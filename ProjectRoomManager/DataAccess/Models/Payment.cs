using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? BillId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? Note { get; set; }

    public virtual MonthlyBill? Bill { get; set; }
}
