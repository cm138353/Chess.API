using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Chess.API.Entities.Chess;

namespace Chess.API.Data;

public class APIDbContext : AbpDbContext<APIDbContext>
{
    //public DbSet<Book> Books { get; set; }
    public DbSet<GameState> GameStates { get; set; }
    public DbSet<GameMove> GameMoves { get; set; }

    public const string DbSchema = "games";

    public APIDbContext(DbContextOptions<APIDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigurePermissionManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        
        //builder.Entity<Book>(b =>
        //{
        //    b.ToTable("Books",
        //        DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        //});

        /* Configure your own entities here */
        builder.Entity<GameState>(b =>
        {
            b.ToTable("GameStates", DbSchema);

            b.ConfigureByConvention();

            b.HasKey(x => x.Id);

            b.Property(x => x.CurrentFen)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            b.Property(x => x.Winner)
                .HasConversion<string>()
                .HasMaxLength(20);

            b.Property(x => x.EndTime)
                .IsRequired(false);

            b.HasMany(x => x.Moves)
                .WithOne()
                .HasForeignKey(x => x.GameStateId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<GameMove>(b =>
        {
            b.ToTable("GameMoves", DbSchema);

            b.ConfigureByConvention();

            b.HasKey(x => x.Id);

            b.Property(x => x.MoveNumber)
                .IsRequired();

            b.Property(x => x.Player)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            b.Property(x => x.MoveUci)
                .IsRequired()
                .HasMaxLength(20);

            b.Property(x => x.MoveSan)
                .HasMaxLength(10);

            b.Property(x => x.FenBefore)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.FenAfter)
                .IsRequired()
                .HasMaxLength(200);
        });

    }
}

