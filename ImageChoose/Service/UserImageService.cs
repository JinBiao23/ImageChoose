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
         List<UserImage> GetUserImages();
         ImageViewModel GetImageViewModel(string serverPath,string imageName);

    }

    public class UserImageService : IUserImageService
    {
        private IUserImageRepository repository;

        public UserImageService(IUserImageRepository repository)
        {
            this.repository = repository;
        }


        public List<UserImage> GetUserImages()
        {
            return null;
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
    }
}