using ImageChoose.DomainModel;
using ImageChoose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageChoose.Service
{
    public interface IUserImageService
    {
        IEnumerable<UserImage> GetUserImages();
        ImageViewModel GetImageViewModel(string serverPath, string imageName);
        UserImage GetUserImageByImageName(string imageName);
        UserImage GetUserImageByImageNameAndUsername(string imageName, string userName);
        List<UserImage> GetUserImages(string userName, bool isLike);
        void SaveChange();
        void CreateNewUserImage(UserImage entity);

    }

    public class UserImageService : IUserImageService
    {
        private IUserImageRepository repository;

        public UserImageService(IUserImageRepository repository)
        {
            this.repository = repository;
        }

        public void CreateNewUserImage(UserImage entity)
        {
            repository.CreateUserImage(entity);
        }

        public ImageViewModel GetImageViewModel(string serverPath, string imageName)
        {
            //Random rnd = new Random();
            //var imageName = string.Format("image_{0}.jpg", rnd.Next(1, 6));
            return new ImageViewModel()
            {
                ImageName = imageName,
                ImageArray = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(System.IO.File.ReadAllBytes(serverPath)))
            };
        }

        public UserImage GetUserImageByImageName(string imageName)
        {
            throw new NotImplementedException();
        }

        public UserImage GetUserImageByImageNameAndUsername(string imageName, string userName)
        {
            return repository.GetUserImages().FirstOrDefault(x => x.ImageName == imageName && x.UserName == userName);
        }

        public IEnumerable<UserImage> GetUserImages()
        {
            return repository.GetUserImages();
        }

        public List<UserImage> GetUserImages(string userName, bool isLike)
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            repository.SaveChange();
        }
    }
}