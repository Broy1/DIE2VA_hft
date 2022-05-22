using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;

namespace WitcherApp.Repository.Database
{
    public class WitcherDbContext : DbContext
    {
        public DbSet<Witcher> Witchers { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<School> Schools { get; set; }

        public WitcherDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("witcher");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Witcher>(witcher => witcher
                .HasOne(witcher => witcher.School)
                .WithMany(school => school.Witchers)
                .HasForeignKey(witcher => witcher.SchoolId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Monster>()
                .HasMany(m => m.HuntedBy)
                .WithMany(m => m.HuntedMonsters)
                .UsingEntity<Human>(
                    x => x.HasOne(x => x.WitcherFriend)
                        .WithMany().HasForeignKey(x => x.WitcherId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.KilledBy)
                        .WithMany().HasForeignKey(x => x.MonsterId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Human>()
                .HasOne(h => h.KilledBy)
                .WithMany(m => m.KilledHumans)
                .HasForeignKey(h => h.MonsterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Human>()
                .HasOne(h => h.WitcherFriend)
                .WithMany(witcher => witcher.Friends)
                .HasForeignKey(w => w.WitcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Witcher>().HasData(new Witcher[]
            {
                // id-name-wage-school-age
                new Witcher("1-Geralt-3500-School of the Wolf-57"),
                new Witcher("2-Vesemir-4000-School of the Wolf-42"),
                new Witcher("3-Gweld-2200-School of the Wolf-51"),
                new Witcher("4-Raven-2105-School of the Griffin-35"),
                new Witcher("5-Kristov-3025-School of the Griffin-47"),
                new Witcher("6-Coen-1300-School of the Cat-40"),
                new Witcher("7-Aiden-1450-School of the Cat-34"),
                new Witcher("8-Guxart-1760-School of the Cat-44"),
                new Witcher("9-Auckes-2100-School of the Viper-63"),
                new Witcher("10-Gerd-1890-School of the Bear-34"),
                new Witcher("11-Ivo-1550-School of the Bear-37"),
                
            });

            modelBuilder.Entity<School>().HasData(new School[]
            {
                // id-name
                new School("1-School of the Wolf"),
                new School("2-School of the Griffin"),
                new School("3-School of the Cat"),
                new School("4-School of the Viper"),
                new School("5-School of the Bear"),
            });

            modelBuilder.Entity<Monster>().HasData(new Monster[]
            {
                // id-name-bounty
                new Monster("1-Leshen-1000"),
                new Monster("2-Mountain Troll-200"),
                new Monster("3-Nekker-50"),
                new Monster("4-Drowner-150"),
                new Monster("5-Wraith-300"),
                new Monster("6-Wyvern-1500"),
                new Monster("7-Giant-1200"),
                new Monster("8-Hymn-1000"),
                new Monster("9-Vampire-2500"),
                new Monster("10-Ghoul-250"),
                new Monster("11-Striga-400"),
                new Monster("12-NightWraith-200"),
                new Monster("13-Golem-500"),
                new Monster("14-Doppler-700"),
                new Monster("15-Werewolf-800"),
                new Monster("16-Djinn-700"),
                new Monster("17-Fiend-1000"),
                new Monster("18-Gargoyle-500"),
            });

            modelBuilder.Entity<Human>().HasData(new Human[]
            {
                // id-witcherid-monsterid-name
                new Human("1-5-7-Gavin"),
                new Human("2-8-6-Sigrid"),
                new Human("3-10-8-Hugh"),
                new Human("4-3-3-Ivar"),
                new Human("5-6-14-Edmund"),
                new Human("6-7-11-Viola"),
                new Human("7-4-12-Leopold"),
                new Human("8-9-10-Severin"),
                new Human("9-2-5-Alba"),
                new Human("10-1- -Yennefer")
            });
        }

    }
}
