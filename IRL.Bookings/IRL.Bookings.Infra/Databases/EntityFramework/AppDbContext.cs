using IRL.Bookings.Infra.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace IRL.Bookings.Infra.Databases.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDbModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<RoomDbModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<RoomDbModel>()
                .HasMany(x => x.Bookings)
                .WithOne()
                .HasForeignKey(x => x.RoomId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<RoomDbModel>().HasData(
               new RoomDbModel
               {
                   Id = "d2139f44-dc41-4ebd-9886-fa4fd898e497",
                   Name = "Cancun best suite"
               }
           );
        }

        public DbSet<BookingDbModel> Bookings { get; set; }

        public DbSet<RoomDbModel> Rooms { get; set; }
    }
}