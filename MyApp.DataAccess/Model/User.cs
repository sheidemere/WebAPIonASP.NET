using System;
using System.Collections.Generic;

namespace MyApp.DataAccess.Model;

public partial class User
{
    public Guid Guid { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Gender { get; set; }

    public DateOnly? Birthday { get; set; }

    public bool Admin { get; set; }

    public DateTime Createdon { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Modifiedon { get; set; }

    public string Modifiedby { get; set; } = null!;

    public DateTime? Revokedon { get; set; }

    public string? Revokedby { get; set; }
}
