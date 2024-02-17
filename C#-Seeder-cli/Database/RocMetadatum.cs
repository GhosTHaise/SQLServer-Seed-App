using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace C__Seeder_cli.Database;

public partial class RocMetadatum
{
    [Key]
    public int RocId { get; set; }

    public DateTime? RocDateRunProcess { get; set; }

    public string? RocCallPlatform { get; set; }

    public string? RocCallUid { get; set; }

    public string? RocRecordingPlatform { get; set; }

    public string? RocRecordingUid { get; set; }

    public string? RocSourcePath { get; set; }

    public string? RocCallStart { get; set; }

    public string? RocCallEnd { get; set; }

    public string? RocPhoneIdentifier { get; set; }

    public string? RocAgentIdentifier { get; set; }

    public string? RocTerminalIdentifier { get; set; }

    public string? RocDistributingIdentifier { get; set; }

    public string? RocSkillIdentifier { get; set; }

    public string? RocSegmentDuration { get; set; }

    public string? RocSegmentStart { get; set; }

    public string? RocSegmentEnd { get; set; }

    public string? RocDirection { get; set; }

    public string? RocExpirationBucket { get; set; }

    public string? RocExpirationAction { get; set; }

    public string? RocExpirationArchive { get; set; }

    public string? RocOutboundCampaignName { get; set; }

    public string? RocOutboundCampaignCustomerId { get; set; }

    public string? RocOutboundCampaignContractId { get; set; }

    public string? RocRepIn { get; set; }

    public string? RocRepOut { get; set; }

    public string? RocFlagEnvoi { get; set; }

    public string? RocOutboundCampaignCallStatus { get; set; }

    public string? RocRep { get; set; }

    public string? RocSousRep { get; set; }

    public string? RocExtraCol6 { get; set; }

    public string? RocExtraCol7 { get; set; }

    public string? RocExtraCol8 { get; set; }

    public string? RocExtraCol9 { get; set; }

    public string? RocExtraCol10 { get; set; }

    public int? RocCallStatusNum { get; set; }

    public DateTime? RocDateRetourFile { get; set; }

    public int? RocRunProcessId { get; set; }

    public string? RocDateToExport { get; set; }

    public int N { get; set; }

    public string? RocPf { get; set; }

    public string? RocServiceName { get; set; }

    public string? RocIsfileexist { get; set; }

    public int? RocCopySuccess { get; set; }

    public string? RocFlagRetour { get; set; }
}
