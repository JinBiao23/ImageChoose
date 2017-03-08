using ImageChoose.DomainModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageChoose.Service
{
    public interface IUserImageRepository {
        IEnumerable GetUserImages();
        UserImage GetUserImage(int id);
        UserImage GetUserImageByImageName(string imageName);
        UserImage GetUserImageByImageName(string imageName, string userName);
        IEnumerable GetUserImages(bool likeImage, string userName);
    }

    public class UserImageRepository : IUserImageRepository
    {
        UserImageContext context = new UserImageContext();
         
        public IEnumerable GetUserImages()
        {
            throw new NotImplementedException();
        }

        public UserImage GetUserImage(int id)
        {
            throw new NotImplementedException();
        }

        public UserImage GetUserImageByImageName(string imageName)
        {
            throw new NotImplementedException();
        }


        public UserImage GetUserImageByImageName(string imageName, string userName)
        {
            return context.UserImages.FirstOrDefault(x => x.ImageName == imageName && x.UserName == userName);
        }

        public IEnumerable GetUserImages(bool likeImage, string userName)
        {
            return context.UserImages.Where(x => x.UserName == userName && x.LikeIt == likeImage).ToList();
        }
    }
}