using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            List<Category> categories = new()
            {
                new Category { CategoryID = 1, CategoryName = "Vehicles" },
                new Category { CategoryID = 2, CategoryName = "Properties" },
                new Category { CategoryID = 3, CategoryName = "Mobile Phones, Tablets, & Accessories" },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Electronics & Home Appliances"
                },
                new Category { CategoryID = 5, CategoryName = "Home Furniture - Decor" },
                new Category { CategoryID = 6, CategoryName = "Fashion & Beauty" },
                new Category { CategoryID = 7, CategoryName = "Pets - Accessories" },
                new Category { CategoryID = 8, CategoryName = "Kids & Babies" },
                new Category { CategoryID = 9, CategoryName = "Books, Sports & Hobbies" },
                new Category { CategoryID = 10, CategoryName = "Jobs" },
                new Category { CategoryID = 11, CategoryName = "Business - Industrial - Agriculture" },
                new Category { CategoryID = 12, CategoryName = "Services" }
            };

            builder.HasData(categories);
        }
    }
}