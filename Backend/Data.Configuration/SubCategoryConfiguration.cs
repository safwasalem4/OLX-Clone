using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {

            List<SubCategory> subCategories = new()
            {
                // Vehicles
                new SubCategory { CategoryID = 1,SubCategoryID =1, SubCategoryName = "Cars for Sale" },
                new SubCategory { CategoryID = 1,SubCategoryID =2, SubCategoryName = "Tyres, Batteries, Oils, &Accessories" },
                new SubCategory { CategoryID = 1,SubCategoryID =3, SubCategoryName = "Car Spare Parts" },
                new SubCategory { CategoryID = 1,SubCategoryID =4, SubCategoryName = "Motorcycles & Accessories" },
                new SubCategory { CategoryID = 1,SubCategoryID =5, SubCategoryName = "Motorcycles & Accessories" },
                new SubCategory { CategoryID = 1,SubCategoryID =6, SubCategoryName = "Boats - Watercraft" },
                new SubCategory { CategoryID = 1,SubCategoryID =7, SubCategoryName = "Heavy Trucks, Buses & Other Vehicles" },
                
                // Properties
                new SubCategory { CategoryID = 2,SubCategoryID =8, SubCategoryName = "Apartments & Duplex for Sale" },
                new SubCategory { CategoryID = 2,SubCategoryID =9, SubCategoryName = "Apartments & Duplex for Rent" },
                new SubCategory { CategoryID = 2,SubCategoryID =10, SubCategoryName = "Villas For Sale" },
                new SubCategory { CategoryID = 2,SubCategoryID =11, SubCategoryName = "Villas For Rent" },
                new SubCategory { CategoryID = 2,SubCategoryID =12, SubCategoryName = "Vacation Homes for Sale" },
                new SubCategory { CategoryID = 2,SubCategoryID =13, SubCategoryName = "Commercial for Sale" },
                new SubCategory { CategoryID = 2,SubCategoryID =14, SubCategoryName = "Buildings & Lands" },
                
                // Mobile Phones, Tablets, & Accessories
                new SubCategory { CategoryID = 3,SubCategoryID =15, SubCategoryName = "Mobile Phones" },
                new SubCategory { CategoryID = 3,SubCategoryID =16, SubCategoryName = "Tablets" },
                new SubCategory { CategoryID = 3,SubCategoryID =17, SubCategoryName = "Mobile & Tablet Accessories" },
                new SubCategory { CategoryID = 3,SubCategoryID =18, SubCategoryName = "Mobile Numbers" },
                
                //Electronics & Home Appliances
                new SubCategory { CategoryID = 4,SubCategoryID =19, SubCategoryName = "Electronics & Home Appliances" },
                new SubCategory { CategoryID = 4,SubCategoryID =20, SubCategoryName = "TV - Audio - Video" },
                new SubCategory { CategoryID = 4,SubCategoryID =21, SubCategoryName = "Computers - Accessories" },
                new SubCategory { CategoryID = 4,SubCategoryID =22, SubCategoryName = "Video games - Consoles" },
                new SubCategory { CategoryID = 4,SubCategoryID =23, SubCategoryName = "Cameras - Imaging" },
                new SubCategory { CategoryID = 4,SubCategoryID =24, SubCategoryName = "Home Appliance" },

                //Home Furniture - Decor
                new SubCategory { CategoryID = 5,SubCategoryID =25, SubCategoryName = "Bathroom" },
                new SubCategory { CategoryID = 5,SubCategoryID =26, SubCategoryName = "Bedroom" },
                new SubCategory { CategoryID = 5,SubCategoryID =27, SubCategoryName = "Dining Room" },
                new SubCategory { CategoryID = 5,SubCategoryID =28, SubCategoryName = "Fabrics - Curtains - Carpets" },
                new SubCategory { CategoryID = 5,SubCategoryID =29, SubCategoryName = "Garden - Outdoor" },
                new SubCategory { CategoryID = 5,SubCategoryID =30, SubCategoryName = "Home Decoration" },
                new SubCategory { CategoryID = 5,SubCategoryID =31, SubCategoryName = "Kitchen - Kitchenware" },
                new SubCategory { CategoryID = 5,SubCategoryID =32, SubCategoryName = "Lighting Tools" },
                new SubCategory { CategoryID = 5,SubCategoryID =33, SubCategoryName = "Living Room" },
                new SubCategory { CategoryID = 5,SubCategoryID =34, SubCategoryName = "Multiple/Other Furniture" },

                // Fashion & Beauty
                new SubCategory { CategoryID = 6,SubCategoryID =35, SubCategoryName = "Women's Clothing" },
                new SubCategory { CategoryID = 6,SubCategoryID =36, SubCategoryName = "Men's Clothing" },
                new SubCategory { CategoryID = 6,SubCategoryID =37, SubCategoryName = "Women's Accessories - Cosmetics - Personal Care" },
                new SubCategory { CategoryID = 6,SubCategoryID =38, SubCategoryName = "Men's Accessories - Personal Care" },

                // Pets - Accessories
                new SubCategory { CategoryID = 7,SubCategoryID =39, SubCategoryName = "Birds - Pigeons" },
                new SubCategory { CategoryID = 7,SubCategoryID =40, SubCategoryName = "Cats" },
                new SubCategory { CategoryID = 7,SubCategoryID =41, SubCategoryName = "Dogs" },
                new SubCategory { CategoryID = 7,SubCategoryID =42, SubCategoryName = "Other Pets & Animals" },
                new SubCategory { CategoryID = 7,SubCategoryID =43, SubCategoryName = "Accessories - Pet Care Products" },

                // Kids & Babies
                new SubCategory { CategoryID = 8,SubCategoryID =44, SubCategoryName = "Baby & Mom Healthcare" },
                new SubCategory { CategoryID = 8,SubCategoryID =45, SubCategoryName = "Baby Clothing" },
                new SubCategory { CategoryID = 8,SubCategoryID =46, SubCategoryName = "Baby Feeding Tools" },
                new SubCategory { CategoryID = 8,SubCategoryID =47, SubCategoryName = "Cribs - Strollers - Carriers" },
                new SubCategory { CategoryID = 8,SubCategoryID =48, SubCategoryName = "Toys" },
                new SubCategory { CategoryID = 8,SubCategoryID =49, SubCategoryName = "Other Baby Items" },

                // Books, Sports & Hobbies
                new SubCategory { CategoryID = 9,SubCategoryID =50, SubCategoryName = "Antiques - Collectibles" },
                new SubCategory { CategoryID = 9,SubCategoryID =51, SubCategoryName = "Bicycles" },
                new SubCategory { CategoryID = 9,SubCategoryID =52, SubCategoryName = "Books" },
                new SubCategory { CategoryID = 9,SubCategoryID =53, SubCategoryName = "Board - Card Games" },
                new SubCategory { CategoryID = 9,SubCategoryID =54, SubCategoryName = "Movies - Music" },
                new SubCategory { CategoryID = 9,SubCategoryID =55, SubCategoryName = "Musical Instruments" },
                new SubCategory { CategoryID = 9,SubCategoryID =56, SubCategoryName = "Sports Equipment" },
                new SubCategory { CategoryID = 9,SubCategoryID =57, SubCategoryName = "Study Tools" },
                new SubCategory { CategoryID = 9,SubCategoryID =58, SubCategoryName = "Tickets - Vouchers" },
                new SubCategory { CategoryID = 9,SubCategoryID =59, SubCategoryName = "Luggage" },
                new SubCategory { CategoryID = 9,SubCategoryID =60, SubCategoryName = "Other Items" },

                // Jobs
                new SubCategory { CategoryID = 10,SubCategoryID =61, SubCategoryName = "Accounting, Finance & Banking" },
                new SubCategory { CategoryID = 10,SubCategoryID =62, SubCategoryName = "Engineering" },
                new SubCategory { CategoryID = 10,SubCategoryID =63, SubCategoryName = "Designers" },
                new SubCategory { CategoryID = 10,SubCategoryID =64, SubCategoryName = "Customer Service & Call Center" },
                new SubCategory { CategoryID = 10,SubCategoryID =65, SubCategoryName = "Workers and Technicians" },
                new SubCategory { CategoryID = 10,SubCategoryID =66, SubCategoryName = "Management & Consulting" },
                new SubCategory { CategoryID = 10,SubCategoryID =67, SubCategoryName = "Drivers & Delivery" },
                new SubCategory { CategoryID = 10,SubCategoryID =68, SubCategoryName = "Education" },
                new SubCategory { CategoryID = 10,SubCategoryID =69, SubCategoryName = "HR" },
                new SubCategory { CategoryID = 10,SubCategoryID =70, SubCategoryName = "Tourism, Travel & Hospitality" },
                new SubCategory { CategoryID = 10,SubCategoryID =71, SubCategoryName = "IT - Telecom" },
                new SubCategory { CategoryID = 10,SubCategoryID =72, SubCategoryName = "Marketing and Public Relations" },
                new SubCategory { CategoryID = 10,SubCategoryID =73, SubCategoryName = "Medical, Healthcare, & Nursing" },
                new SubCategory { CategoryID = 10,SubCategoryID =74, SubCategoryName = "Sales" },
                new SubCategory { CategoryID = 10,SubCategoryID =75, SubCategoryName = "Secretarial" },
                new SubCategory { CategoryID = 10,SubCategoryID =76, SubCategoryName = "Guards and Security" },
                new SubCategory { CategoryID = 10,SubCategoryID =77, SubCategoryName = "Legal - Lawyers" },
                new SubCategory { CategoryID = 10,SubCategoryID =78, SubCategoryName = "Other Job" },

                // Business - Industrial - Agriculture
                new SubCategory { CategoryID = 11,SubCategoryID =79, SubCategoryName = "Agriculture" },
                new SubCategory { CategoryID = 11,SubCategoryID =80, SubCategoryName = "Construction" },
                new SubCategory { CategoryID = 11,SubCategoryID =81, SubCategoryName = "Industrial Equipment" },
                new SubCategory { CategoryID = 11,SubCategoryID =82, SubCategoryName = "Medical Equipment" },
                new SubCategory { CategoryID = 11,SubCategoryID =83, SubCategoryName = "Office Furniture & Equipment" },
                new SubCategory { CategoryID = 11,SubCategoryID =84, SubCategoryName = "Restaurants Equipment" },
                new SubCategory { CategoryID = 11,SubCategoryID =85, SubCategoryName = "Whole Business for Sale" },
                new SubCategory { CategoryID = 11,SubCategoryID =86, SubCategoryName = "Other Business, Industrial &" },
                new SubCategory { CategoryID = 11,SubCategoryID =87, SubCategoryName = "Agriculture" },

                // Services
                new SubCategory { CategoryID = 12,SubCategoryID =88, SubCategoryName = "Business" },
                new SubCategory { CategoryID = 12,SubCategoryID =89, SubCategoryName = "Car" },
                new SubCategory { CategoryID = 12,SubCategoryID =90, SubCategoryName = "Events" },
                new SubCategory { CategoryID = 12,SubCategoryID =91, SubCategoryName = "Health & Beauty" },
                new SubCategory { CategoryID = 12,SubCategoryID =92, SubCategoryName = "Maintenance" },
                new SubCategory { CategoryID = 12,SubCategoryID =93, SubCategoryName = "Medical" },
                new SubCategory { CategoryID = 12,SubCategoryID =94, SubCategoryName = "Movers" },
                new SubCategory { CategoryID = 12,SubCategoryID =95, SubCategoryName = "Pets" },
                new SubCategory { CategoryID = 12,SubCategoryID =96, SubCategoryName = "Education" },
                new SubCategory { CategoryID = 12,SubCategoryID =97, SubCategoryName = "Other Service" },
            };

            builder.HasData(subCategories);
        }
    }
}