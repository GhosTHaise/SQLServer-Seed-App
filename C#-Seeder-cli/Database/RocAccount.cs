using System;
using System.Collections.Generic;

namespace C__Seeder_cli.Database;

public partial class RocAccount
{
    public int RocAccId { get; set; }

    public string? RocAccName { get; set; }

    public string? RocServiceName { get; set; }

    public string? RocPath { get; set; }

    public string? RocUser { get; set; }

    public string? RocPassword { get; set; }

    public string? RocAccType { get; set; }

    public string? RocAccActive { get; set; }

    public string? RocRep { get; set; }

    public string? RocSousRep { get; set; }

    public int? RocAccIdassoc { get; set; }

    public DateTime? RocCampDateAdd { get; set; }

    public string? RocCampAddedBy { get; set; }

    public int? RocRetentionDelay { get; set; }
}
