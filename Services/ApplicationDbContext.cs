using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using My_Pacific_Tour_App.Models;

namespace My_Pacific_Tour_App.Services
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        // Database entities to all the database to write the correct tables to the database
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<HotelAvailability> HotelAvailabilities { get; set; }
        public DbSet<TourAvailability> TourAvailabilities { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations so i can lay out the key for each table

            modelBuilder.Entity<Tour>().HasKey(t => t.TourId);
            modelBuilder.Entity<Hotel>().HasKey(h => h.HotelId);
            modelBuilder.Entity<HotelAvailability>().HasKey(ha => ha.HotelAvailabilityId);
            modelBuilder.Entity<TourAvailability>().HasKey(ta => ta.TourAvailabilityId);
            modelBuilder.Entity<HotelBooking>().HasKey(hb => hb.HotelBookingId);
            modelBuilder.Entity<TourBooking>().HasKey(tb => tb.TourBookingId);

            // This is where the Database relationships are laid out 
            //i'll run through the logic for each of these relationships
            //Says that each abailability has one hotel, meaning that multiple instances of each availability can be linked to on hotel
            //hotelid is the foreign key
            modelBuilder.Entity<HotelAvailability>()
               .HasOne(p => p.Hotel)
               .WithMany()
               .HasForeignKey(p => p.HotelId);
            //same idea as above but for tours
            modelBuilder.Entity<TourAvailability>()
               .HasOne(p => p.Tour)
               .WithMany()
               .HasForeignKey(p => p.TourId);
            //Each hotel booking has one hotel and that multiple bookings can be related to one hotel
            modelBuilder.Entity<HotelBooking>()
                .HasOne(p => p.Hotel)
                .WithMany()
                .HasForeignKey(p => p.HotelId);
            //same idea as above but for tours
            modelBuilder.Entity<TourBooking>()
                .HasOne(p => p.Tour)
                .WithMany()
                .HasForeignKey(p => p.TourId);
            //hotel bookings can have only one user but multiple hotelbookings can be associated with one user
            modelBuilder.Entity<HotelBooking>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
            //same thinking as above but for tours
            modelBuilder.Entity<TourBooking>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);



            //This seeds data directly into the database allowing the project to be tested locally and compile properly
            //in other machines
            Hotel HiltonS = new Hotel { HotelId = Guid.NewGuid(), Name = "HiltonLondonHotel", RoomType = "single", Cost = 375, AvailableSpaces = 20 };
            Hotel HiltonD = new Hotel { HotelId = Guid.NewGuid(), Name = "HiltonLondonHotel", RoomType = "double", Cost = 775, AvailableSpaces = 20 };
            Hotel HiltonF = new Hotel { HotelId = Guid.NewGuid(), Name = "HiltonLondonHotel", RoomType = "family suite", Cost = 950, AvailableSpaces = 20 };

            Hotel MarriotS = new Hotel { HotelId = Guid.NewGuid(), Name = "LondonMarriotHotel", RoomType = "single", Cost = 300, AvailableSpaces = 20 };
            Hotel MarriotD = new Hotel { HotelId = Guid.NewGuid(), Name = "LondonMarriotHotel", RoomType = "Double", Cost = 300, AvailableSpaces = 20 };
            Hotel MarriotF = new Hotel { HotelId = Guid.NewGuid(), Name = "LondonMarriotHotel", RoomType = "family suite", Cost = 300, AvailableSpaces = 20 };

            Hotel TravellodgeS = new Hotel { HotelId = Guid.NewGuid(), Name = "LondonMarriotHotel", RoomType = "single", Cost = 300, AvailableSpaces = 20 };
            Hotel TravellodgeD = new Hotel { HotelId = Guid.NewGuid(), Name = "LondonMarriotHotel", RoomType = "double", Cost = 300, AvailableSpaces = 20 };
            Hotel TravellodgeF = new Hotel { HotelId = Guid.NewGuid(), Name = "LondonMarriotHotel", RoomType = "family suite", Cost = 300, AvailableSpaces = 20 };

            HotelAvailability HiltonSA = new HotelAvailability { HotelAvailabilityId = Guid.NewGuid(), HotelId = HiltonS.HotelId, AvailableFrom = new DateTime(2024, 01, 14), AvailableTo = new DateTime(2024, 12, 23) };
            modelBuilder.Entity<Hotel>().HasData(
                HiltonS,
                HiltonD,
                HiltonF,
                MarriotS,
                MarriotD,
                MarriotF,
                TravellodgeS,
                TravellodgeD,
                TravellodgeF
                );

            modelBuilder.Entity<HotelAvailability>().HasData(
                HiltonSA
                );

            Tour RealBritain = new Tour { TourId = Guid.NewGuid(), Name = "Real Britain", DurationInDays = 5, Cost = 600, AvailableSpaces = 20 };
            Tour BritainandIreland = new Tour { TourId = Guid.NewGuid(), Name = "Britain and Ireland Explorer", DurationInDays = 5, Cost = 600, AvailableSpaces = 20 };

            TourAvailability RealBritainA = new TourAvailability { TourAvailabilityId = Guid.NewGuid(), TourId = RealBritain.TourId, AvailableFrom = new DateTime(2024,01,15), AvailableTo = new DateTime(2024,01,20)};

            modelBuilder.Entity<Tour>().HasData(
                RealBritain,
                BritainandIreland);

            modelBuilder.Entity<TourAvailability>().HasData(
                RealBritainA

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
