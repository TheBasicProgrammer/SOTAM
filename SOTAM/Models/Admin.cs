using System;
using System.Collections.Generic;

namespace SOTAM.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string FullName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
