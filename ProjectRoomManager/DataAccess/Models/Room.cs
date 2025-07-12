using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public double? Area { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
