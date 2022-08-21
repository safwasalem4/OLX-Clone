using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;
using Newtonsoft.Json;

namespace Data.Configuration
{
    public class ImagesConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            List<PostImage> images = new();
            
            for (int i = 1; i < 2000; i++)
            {
                var img = new PostImage()
                {
                    ImageURL = "https://cdn.vectorstock.com/i/1000x1000/35/52/placeholder-rgb-color-icon-vector-32173552.webp",
                    PostImageID = i,
                    PostId = i
                };
                images.Add(img);
            }

            builder.HasData(images);
        }
    }
}