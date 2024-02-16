using System;
using System.Collections.Generic;

namespace C__Seeder_cli.Database;

public partial class RocCampaign
{
    public int RocCampaignId { get; set; }

    public string? RocCampaignName { get; set; }

    public string? RocCampaignPf { get; set; }

    public int? RocAccId { get; set; }

    public string? RocCampaignActive { get; set; }

    public string? RocCallStatNum { get; set; }

    public int? RocCallType { get; set; }

    public string? RocCampagneSortante { get; set; }

    public string? RocExtraCol6 { get; set; }

    public string? RocClientTable { get; set; }

    public string? RocBaseName { get; set; }

    public string? RocRecFolderName { get; set; }

    public string? RocExtraCol7 { get; set; }

    public string? RocExtraCol8 { get; set; }

    public string? RocExtraCol9 { get; set; }

    public string? RocExtraCol10 { get; set; }

    public string? Naegelen { get; set; }

    public DateTime? RocCampDateAdd { get; set; }

    public string? RocCampAddedBy { get; set; }
}
