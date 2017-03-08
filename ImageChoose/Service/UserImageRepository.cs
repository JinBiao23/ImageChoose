using ImageChoose.DomainModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageChoose.Service
{
    public interface IUserImageRepository {
        IEnumerable<UserImage> GetUserImages();
        UserImage GetUserImage(int id);
        void UpdateUserImage(UserImage userImage);
        void DeleteUserImage(int id);
        void CreateUserImage(UserImage userImage);
        void SaveChange();
    }

    public class UserImageRepository : IUserImageRepository
    {
        UserImageContext context = new UserImageContext();
         
        public IEnumerable<UserImage> GetUserImages()
        {
            return context.UserImages;
        }

        public UserImage GetUserImage(int id)
        {
            return context.UserImages.FirstOrDefault(x => x.Id == id);

        }

        public void UpdateUserImage(UserImage userImage)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserImage(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateUserImage(UserImage userImage)
        {
            context.UserImages.Add(userImage);
            SaveChange();
        }

        public void SaveChange()
        {
            context.SaveChanges();
        }
    }
}