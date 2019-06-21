using Microsoft.EntityFrameworkCore;
using ODDESTODDS.Domain.Entity;

namespace ODDESTODDS.Persistence.Context

{
    public class ApplicatioDBContext : DbContext
    {
        public virtual DbSet<GameInfo> GameInfos { get; set; }
        public virtual DbSet<GameOdd> GameOdds { get; set; }
        
        public ApplicatioDBContext(DbContextOptions<ApplicatioDBContext> options) : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GameInfo>().ToTable("GameInfo");
            builder.Entity<GameInfo>().HasKey(p => p.Id);
            builder.Entity<GameInfo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<GameInfo>().Property(p => p.AwayTeam).IsRequired().HasMaxLength(120);
            builder.Entity<GameInfo>().Property(p => p.HomeTeam).IsRequired().HasMaxLength(120);
            builder.Entity<GameInfo>().Property(p => p.GameStartTime).IsRequired();


            builder.Entity<GameOdd>().ToTable("GameOdd");
            builder.Entity<GameOdd>().HasKey(p => p.Id);
            builder.Entity<GameOdd>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<GameOdd>().Property(p => p.AwayOdd).IsRequired();
            builder.Entity<GameOdd>().Property(p => p.DrawOdd).IsRequired();
            builder.Entity<GameOdd>().Property(p => p.HomeOdd).IsRequired();
            builder.Entity<GameOdd>().HasOne(p => p.GameInfo).WithOne(p => p.GameOdd).HasForeignKey<GameOdd>(p => p.GameInfoId);

            builder.Entity<GameInfo>(b =>
            {
                b.HasData(
                    new
                    {
                        Id = (long)1,
                        HomeTeam = "England U21",
                        AwayTeam = "France U21",
                        GameStartTime = System.DateTime.Now,
                        GameStatus = 1,
                        IsDeleted = false,

                    },
                    new
                    {
                        Id = (long)2,
                        HomeTeam = "USA U21",
                        AwayTeam = "Germany U21",
                        GameStartTime = System.DateTime.Now,
                        GameStatus = 1,
                        IsDeleted = false,

                    },
                      new
                      {
                          Id = (long)3,
                          HomeTeam = "Denmark  U21",
                          AwayTeam = "England  U21",
                          GameStartTime = System.DateTime.Now,
                          GameStatus = 1,
                          IsDeleted = false,

                      }
                    );

                b.OwnsOne(e => e.GameOdd).HasData
                (new
                     {
                      Id = (long)1,
                      GameInfoId = (long)1,
                      AwayOdd = 3.0, HomeOdd = 5.9,
                      DrawOdd = 14.7, OddStatus = 1,
                      CreatedDate = System.DateTime.Now,
                      IsDeleted = false,
                      GameStatus=1
                     },
                    new
                    { Id = (long)2, GameInfoId = (long)2, AwayOdd = 3.0, HomeOdd = 5.9, DrawOdd = 14.7, OddStatus = 1,
                        CreatedDate = System.DateTime.Now,
                        IsDeleted = false,
                        GameStatus = 1
                    },
                      new
                      {
                          Id = (long)3,
                          GameInfoId = (long)3,
                          AwayOdd = 3.0,
                          HomeOdd = 5.9,
                          DrawOdd = 14.7,
                          OddStatus = 1,
                          CreatedDate = System.DateTime.Now,
                          IsDeleted = false,
                          GameStatus = 1
                      }
                );
            });
           
        }
    }
}
