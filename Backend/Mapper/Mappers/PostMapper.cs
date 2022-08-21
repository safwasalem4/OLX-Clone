using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Mapper.Mappers
{
    public class PostMapper : IPostMapper
    {
        public Post MapFromDTO(PostDTO postDTO)
        {
            Post post = new Post();
            post.PostId = postDTO.PostId;
            post.Title = postDTO.Title;
            post.Description = postDTO.Description;
            post.CreatedAt = postDTO.CreatedAt;
            post.Price = postDTO.Price;
            post.IsNew = postDTO.IsNew;
            post.IsAvailable = postDTO.IsAvailable == null ? true : postDTO.IsAvailable.Value;
            post.IsNegotiable = postDTO.IsNegotiable;
            post.SubCategoryId = postDTO.SubCategoryId == null ? 0 : postDTO.SubCategoryId.Value;
            post.UserID = postDTO.UserID == null ? 0 : postDTO.UserID.Value;
            post.LocationId = postDTO.LocationId == null ? 0 : postDTO.LocationId.Value;
            if (postDTO.PostImages != null)
            {
                List<PostImage> postImages = postDTO.PostImages.Select(postImageDTO => MapPostImageFromDTO(postImageDTO)).ToList();
                post.PostImages = postImages;
            }
            return post;
        }

        public PostDTO MapToDTO(Post post)
        {
            PostDTO postDTO = new PostDTO();
            postDTO.PostId = post.PostId;
            postDTO.Title = post.Title;
            postDTO.Description = post.Description;
            postDTO.CreatedAt = post.CreatedAt;
            postDTO.Price = post.Price;
            postDTO.IsNew = post.IsNew;
            postDTO.IsAvailable = post.IsAvailable;
            postDTO.IsNegotiable = post.IsNegotiable;
            postDTO.SubCategoryId = post.SubCategoryId;
            postDTO.UserID = post.UserID;
            postDTO.LocationId = post.LocationId;

            if (post.SubCategory != null)
                postDTO.SubCategoryName = post.SubCategory.SubCategoryName;

            if (post.User != null)
            {
                postDTO.FullName = post.User.FName + ' ' + post.User.LName;
                postDTO.PhoneNumber = post.User.PhoneNumber;
                postDTO.AboutMe = post.User.AboutMe;
            }

            if (post.Location != null)
                postDTO.CityName = post.Location.CityName;

            if (post.PostImages != null)
            {
                List<PostImageDTO> postImageDTOs = post.PostImages.Select(postImage => MapPostImageToDTO(postImage)).ToList();
                postDTO.PostImages = postImageDTOs;
            }
            return postDTO;
        }

        public PostImage MapPostImageFromDTO(PostImageDTO postimageDTO)
        {
            PostImage postimage = new PostImage();
            postimage.PostImageID = postimageDTO.PostImageID;
            postimage.ImageURL = postimageDTO.ImageURL;
            postimage.PostId = postimageDTO.PostId;
            return postimage;
        }

        public PostImageDTO MapPostImageToDTO(PostImage postimage)
        {
            PostImageDTO postimageDTO = new PostImageDTO();
            postimageDTO.PostImageID = postimage.PostImageID;
            postimageDTO.ImageURL = postimage.ImageURL;
            postimageDTO.PostId = postimage.PostId;
            return postimageDTO;
        }
    }
}
