using System;
using System.Collections.Generic;

namespace btEntityFramework.Models;

public partial class Congty
{
    public int IdCongTy { get; set; }

    public string? TenCongTy { get; set; }

    public string? DiaChiCongTy { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<PhongBan> PhongBans { get; set; } = new List<PhongBan>();
}
