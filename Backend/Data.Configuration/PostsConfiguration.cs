using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;
using Newtonsoft.Json;

namespace Data.Configuration
{
    public class PostsConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> SeedLargData()
            {
                var posts = new List<Post>();
                using (StreamReader r = new(@"..\Data.Configuration\Seed\PostSeed.json"))
                {
                    string json = r.ReadToEnd();
                    posts = JsonConvert.DeserializeObject<List<Post>>(json);
                }
                return posts;
            }

            builder.HasData(SeedLargData());
        }
    }
}