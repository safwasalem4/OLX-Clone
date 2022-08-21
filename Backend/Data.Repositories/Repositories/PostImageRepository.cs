using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repositories
{
    public class PostImageRepository : BaseRepository<PostImage>, IPostImageRepository
    {
        public PostImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<PostImage> GetAll(int id)
        {
            IEnumerable<PostImage> postimageList = this.DbContext.PostImages;
            postimageList = postimageList.Where(p => p.PostId == id);

            return postimageList;
        }
    }
}
