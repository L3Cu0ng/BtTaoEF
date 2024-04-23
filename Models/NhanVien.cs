using System;
using System.Collections.Generic;

namespace btEntityFramework.Models;

public partial class NhanVien
{
    public int Manv { get; set; }

    public string Hoten { get; set; } = null!;

    public DateOnly Ngaysinh { get; set; }

    public string Gioitinh { get; set; } = null!;

    public string Diachi { get; set; } = null!;

    public int Luong { get; set; }

    public int Mapb { get; set; }

    public virtual PhongBan MapbNavigation { get; set; } = null!;
}
