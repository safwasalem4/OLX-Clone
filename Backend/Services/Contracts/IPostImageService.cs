using Microsoft.AspNetCore.Http;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{

    public interface IPostImageService
    {
        IEnumerable<PostImageDTO> GetAll();//return all images
        IEnumerable<PostImageDTO> GetAll(int id);//return all images of one post
        PostImageDTO GetById(int id); //return one image by it's id
        PostImageDTO Add(PostImageDTO postimageDTO);
        void Update(int id, PostImageDTO postimageDTO);//do we need this?.. leave it for now
        void Delete(int id); //delete using postImage id... reminder: we need a delete using post id method or "cascade delete"
        bool ImageExists(int id);
        List<string> Upload(IFormFileCollection files);
        void SavePostImage();
    }
}
