using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace C__Seeder_cli.Database;

public partial class WebHelpRocContext : DbContext
{
    public WebHelpRocContext()
    {
    }

    public WebHelpRocContext(DbContextOptions<WebHelpRocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RocAccount> RocAccounts { get; set; }

    public virtual DbSet<RocCampaign> RocCampaigns { get; set; }

    public virtual DbSet<RocGuiuser> RocGuiusers { get; set; }

    public virtual DbSet<RocMetadatum> RocMetadata { get; set; }

    public virtual DbSet<RocPf> RocPfs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1H35QEL\\SQLEXPRESS;Database=WEBHELP_ROC;Integrated Security=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RocAccount>(entity =>
        {
            entity.HasKey(e => e.RocAccId);

            entity.ToTable("ROC_ACCOUNTS");

            entity.Property(e => e.RocAccId).HasColumnName("RocAccID");
            entity.Property(e => e.RocAccActive)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RocAccIdassoc).HasColumnName("RocAccIDAssoc");
            entity.Property(e => e.RocAccName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RocAccType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RocCampAddedBy)
                .HasMaxLength(150)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.RocCampDateAdd)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RocPassword).HasMaxLength(250);
            entity.Property(e => e.RocPath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RocRep).HasMaxLength(75);
            entity.Property(e => e.RocRetentionDelay).HasDefaultValueSql("((30))");
            entity.Property(e => e.RocServiceName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RocSousRep).HasMaxLength(75);
            entity.Property(e => e.RocUser)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RocCampaign>(entity =>
        {
            entity.ToTable("ROC_CAMPAIGNS");

            entity.Property(e => e.Naegelen).HasMaxLength(10);
            entity.Property(e => e.RocAccId).HasColumnName("RocAccID");
            entity.Property(e => e.RocBaseName).HasMaxLength(75);
            entity.Property(e => e.RocCallStatNum).HasMaxLength(50);
            entity.Property(e => e.RocCampAddedBy)
                .HasMaxLength(150)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.RocCampDateAdd)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RocCampagneSortante).HasMaxLength(150);
            entity.Property(e => e.RocCampaignActive)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RocCampaignName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RocCampaignPf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RocCampaignPF");
            entity.Property(e => e.RocClientTable).HasMaxLength(150);
            entity.Property(e => e.RocExtraCol10).HasMaxLength(100);
            entity.Property(e => e.RocExtraCol6).HasMaxLength(100);
            entity.Property(e => e.RocExtraCol7).HasMaxLength(100);
            entity.Property(e => e.RocExtraCol8).HasMaxLength(100);
            entity.Property(e => e.RocExtraCol9).HasMaxLength(100);
            entity.Property(e => e.RocRecFolderName).HasMaxLength(150);
        });

        modelBuilder.Entity<RocGuiuser>(entity =>
        {
            entity.HasKey(e => e.RocUserId);

            entity.ToTable("RocGUIUser");

            entity.Property(e => e.RocUserMail).HasMaxLength(150);
            entity.Property(e => e.RocUserName).HasMaxLength(150);
            entity.Property(e => e.RocUserRole)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('utilisateur')");
        });

        modelBuilder.Entity<RocMetadatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROC_METADATA");

            entity.HasIndex(e => new { e.RocCallPlatform, e.RocRunProcessId }, "IDX_ROC_CALLPLATFORM");

            entity.HasIndex(e => e.RocId, "IDX_ROC_ID").IsClustered();

            entity.HasIndex(e => e.RocRunProcessId, "IDX_ROC_RunProcessId");

            entity.HasIndex(e => e.RocServiceName, "IDX_ROC_ServiceName");

            entity.Property(e => e.RocAgentIdentifier)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROC_AgentIdentifier");
            entity.Property(e => e.RocCallEnd)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ROC_CallEnd");
            entity.Property(e => e.RocCallPlatform)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_CallPlatform");
            entity.Property(e => e.RocCallStart)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ROC_CallStart");
            entity.Property(e => e.RocCallStatusNum).HasColumnName("Roc_CallStatusNum");
            entity.Property(e => e.RocCallUid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_CallUID");
            entity.Property(e => e.RocCopySuccess).HasColumnName("ROC_CopySuccess");
            entity.Property(e => e.RocDateRetourFile)
                .HasColumnType("datetime")
                .HasColumnName("ROC_DateRetourFile");
            entity.Property(e => e.RocDateRunProcess)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ROC_DateRunProcess");
            entity.Property(e => e.RocDateToExport)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ROC_DateToExport");
            entity.Property(e => e.RocDirection)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_Direction");
            entity.Property(e => e.RocDistributingIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_DistributingIdentifier");
            entity.Property(e => e.RocExpirationAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_ExpirationAction");
            entity.Property(e => e.RocExpirationArchive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROC_ExpirationArchive");
            entity.Property(e => e.RocExpirationBucket)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROC_ExpirationBucket");
            entity.Property(e => e.RocExtraCol10)
                .HasMaxLength(100)
                .HasColumnName("Roc_ExtraCol10");
            entity.Property(e => e.RocExtraCol6)
                .HasMaxLength(100)
                .HasColumnName("Roc_ExtraCol6");
            entity.Property(e => e.RocExtraCol7)
                .HasMaxLength(100)
                .HasColumnName("Roc_ExtraCol7");
            entity.Property(e => e.RocExtraCol8)
                .HasMaxLength(100)
                .HasColumnName("Roc_ExtraCol8");
            entity.Property(e => e.RocExtraCol9)
                .HasMaxLength(100)
                .HasColumnName("Roc_ExtraCol9");
            entity.Property(e => e.RocFlagEnvoi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_FlagEnvoi");
            entity.Property(e => e.RocFlagRetour)
                .HasMaxLength(25)
                .HasColumnName("ROC_FlagRetour");
            entity.Property(e => e.RocId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ROC_Id");
            entity.Property(e => e.RocIsfileexist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_ISFILEEXIST");
            entity.Property(e => e.RocOutboundCampaignCallStatus)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROC_OutboundCampaignCallStatus");
            entity.Property(e => e.RocOutboundCampaignContractId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_OutboundCampaignContractId");
            entity.Property(e => e.RocOutboundCampaignCustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROC_OutboundCampaignCustomerId");
            entity.Property(e => e.RocOutboundCampaignName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_OutboundCampaignName");
            entity.Property(e => e.RocPf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_PF");
            entity.Property(e => e.RocPhoneIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_PhoneIdentifier");
            entity.Property(e => e.RocRecordingPlatform)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_RecordingPlatform");
            entity.Property(e => e.RocRecordingUid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_RecordingUID");
            entity.Property(e => e.RocRep)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROC_Rep");
            entity.Property(e => e.RocRepIn)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROC_RepIN");
            entity.Property(e => e.RocRepOut)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROC_RepOUT");
            entity.Property(e => e.RocRunProcessId).HasColumnName("ROC_RunProcessId");
            entity.Property(e => e.RocSegmentDuration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_SegmentDuration");
            entity.Property(e => e.RocSegmentEnd)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ROC_SegmentEnd");
            entity.Property(e => e.RocSegmentStart)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ROC_SegmentStart");
            entity.Property(e => e.RocServiceName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ROC_ServiceName");
            entity.Property(e => e.RocSkillIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_SkillIdentifier");
            entity.Property(e => e.RocSourcePath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROC_SourcePath");
            entity.Property(e => e.RocSousRep)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ROC_SousRep");
            entity.Property(e => e.RocTerminalIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROC_TerminalIdentifier");
        });

        modelBuilder.Entity<RocPf>(entity =>
        {
            entity.ToTable("ROC_PFS");

            entity.Property(e => e.RocPfid).HasColumnName("RocPFID");
            entity.Property(e => e.RocCampaignCallPf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RocCampaignCallPF");
            entity.Property(e => e.RocCampaignRecordingPf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RocCampaignRecordingPF");
            entity.Property(e => e.RocCtiDrive)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RocDirRecords).HasMaxLength(250);
            entity.Property(e => e.RocLinkServer).HasMaxLength(150);
            entity.Property(e => e.RocPfactive)
                .HasMaxLength(3)
                .HasColumnName("RocPFActive");
            entity.Property(e => e.RocPfctiIp)
                .HasMaxLength(75)
                .HasColumnName("RocPFCtiIP");
            entity.Property(e => e.RocPffileSource)
                .HasMaxLength(25)
                .HasColumnName("RocPFFileSource");
            entity.Property(e => e.RocPflabel)
                .HasMaxLength(25)
                .HasColumnName("RocPFLabel");
            entity.Property(e => e.RocPfname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RocPFName");
            entity.Property(e => e.RocPfsqlIp)
                .HasMaxLength(75)
                .HasColumnName("RocPFSqlIP");
            entity.Property(e => e.RocPftype)
                .HasMaxLength(15)
                .HasColumnName("RocPFType");
            entity.Property(e => e.RocSftphost)
                .HasMaxLength(64)
                .HasColumnName("RocSFTPHost");
            entity.Property(e => e.RocSftppass)
                .HasMaxLength(64)
                .HasColumnName("RocSFTPPass");
            entity.Property(e => e.RocSftpuser)
                .HasMaxLength(64)
                .HasColumnName("RocSFTPUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
