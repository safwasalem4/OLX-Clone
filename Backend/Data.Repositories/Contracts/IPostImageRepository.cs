using Data.Infrastructure;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Contracts
{
    public interface IPostImageRepository : IRepository<PostImage>
    {
        IEnumerable<PostImage> GetAll(int id);
    }
}
