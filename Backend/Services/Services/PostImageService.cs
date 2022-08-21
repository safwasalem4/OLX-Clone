using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Microsoft.AspNetCore.Http;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostImageService : IPostImageService
    {
        private readonly IPostImageRepository _postimageRepository;
        private readonly IPostMapper _postMapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostImageService(IPostImageRepository postimageRepository, IPostMapper postMapper, IUnitOfWork unitOfWork)
        {
            _postimageRepository = postimageRepository;
            _postMapper = postMapper;
            _unitOfWork = unitOfWork;
        }
        public PostImageDTO Add(PostImageDTO postimageDTO)
        {
            var postimage = _postMapper.MapPostImageFromDTO(postimageDTO);
            PostImage addedPostImage = _postimageRepository.Add(postimage);
            PostImageDTO result = _postMapper.MapPostImageToDTO(addedPostImage);
            return result;
        }

        public void Delete(int id)
        {
            PostImage postimage = _postimageRepository.GetById(id);
            _postimageRepository.Delete(postimage);
        }

        public IEnumerable<PostImageDTO> GetAll()//all images of all posts
        {
            IEnumerable<PostImage> postimages = _postimageRepository.GetAll();
            IEnumerable<PostImageDTO> postimagesDTO = postimages.Select(postimage => _postMapper.MapPostImageToDTO(postimage));
            return postimagesDTO;
        }

        public PostImageDTO GetById(int id)
        {
            PostImage postimage = _postimageRepository.GetById(id);
            PostImageDTO postimageDTO = _postMapper.MapPostImageToDTO(postimage);
            return postimageDTO;
        }

        public void Update(int id, PostImageDTO postimageDTO)
        {
            PostImage postimage = _postMapper.MapPostImageFromDTO(postimageDTO);
            _postimageRepository.Update(id, postimage);
        }
        public bool ImageExists(int id)
        {
            PostImage postimage = _postimageRepository.GetById(id);
            return postimage != null;
        }
        public void SavePostImage()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<PostImageDTO> GetAll(int id)
        {
            IEnumerable<PostImage> postimages = _postimageRepository.GetAll(id);
            IEnumerable<PostImageDTO> postimagesDTO = postimages.Select(postimage => _postMapper.MapPostImageToDTO(postimage));
            return postimagesDTO;
        }

        public List<string> Upload(IFormFileCollection files)
        {
            var folderName = Path.Combine("Resorces", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var dbPaths = new List<string>();
            foreach (var file in files)
            {
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                dbPaths.Add(dbPath);

            }
            return dbPaths;
        }
    }
}
