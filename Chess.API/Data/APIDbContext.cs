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
using Chess.API.Entities.Books;
using Chess.API.Entities.Chess;

namespace Chess.API.Data;

public class APIDbContext : AbpDbContext<APIDbContext>
{
    //public DbSet<Book> Books { get; set; }
    public DbSet<GameResult> GameStates { get; set; }

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
        builder.Entity<GameResult>(b =>
        {
            b.ToTable("GameResults", DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Winner)
                .HasConversion<string>()
                .IsRequired();

            b.Property(x => x.StartTime)
                .IsRequired();
        });

    }
}

