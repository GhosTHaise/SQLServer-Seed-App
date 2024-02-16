using System;
using System.Collections.Generic;

namespace C__Seeder_cli.Database;

public partial class RocGuiuser
{
    public int RocUserId { get; set; }

    public string RocUserName { get; set; } = null!;

    public string RocUserMail { get; set; } = null!;

    public int? RocUserNiveau { get; set; }

    public bool RocUserActive { get; set; }

    public string? RocUserRole { get; set; }
}
