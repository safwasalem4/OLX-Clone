using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            List<Location> locations = new()
            {
                new Location{ LocationId=1, CityName= "Alexandria"},
                new Location{ LocationId=2, CityName= "Aswan"},
                new Location{ LocationId=3, CityName= "Asyut"},
                new Location{ LocationId=4, CityName= "Beheira"},
                new Location{ LocationId=5, CityName= "Beni Suef"},
                new Location{ LocationId=6, CityName= "Cairo"},
                new Location{ LocationId=7, CityName= "Dakahlia"},
                new Location{ LocationId=8, CityName= "Damietta"},
                new Location{ LocationId=9, CityName= "Faiyum"},
                new Location{ LocationId=10, CityName= "Gharbia"},
                new Location{ LocationId=11, CityName= "Giza"},
                new Location{ LocationId=12, CityName= "Ismailia"},
                new Location{ LocationId=13, CityName= "Kafr El Sheikh"},
                new Location{ LocationId=14, CityName= "Luxor"},
                new Location{ LocationId=15, CityName= "Matruh"},
                new Location{ LocationId=16, CityName= "Minya"},
                new Location{ LocationId=17, CityName= "Monufia"},
                new Location{ LocationId=18, CityName= "New Valley"},
                new Location{ LocationId=19, CityName= "North Sinai"},
                new Location{ LocationId=20, CityName= "Port Said"},
                new Location{ LocationId=21, CityName= "Qalyubia"},
                new Location{ LocationId=22, CityName= "Qena"},
                new Location{ LocationId=23, CityName= "Red Sea"},
                new Location{ LocationId=24, CityName= "Sharqia"},
                new Location{ LocationId=25, CityName= "Sohag"},
                new Location{ LocationId=26, CityName= "South Sinai"},
                new Location{ LocationId=27, CityName= "Suez"},
            };

            builder.HasData(locations);
        }
    }
}