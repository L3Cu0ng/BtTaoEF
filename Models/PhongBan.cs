using System;
using System.Collections.Generic;

namespace btEntityFramework.Models;

public partial class PhongBan
{
    public int Mapb { get; set; }

    public string Tenpb { get; set; } = null!;

    public int IdCongTy { get; set; }

    public virtual Congty IdCongTyNavigation { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
