using ImageChoose.DomainModel;
using ImageChoose.Models;
using ImageChoose.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageChoose.Controllers
{
    public class HomeController : Controller
    {
        private IUserImageService userImageService;

        public HomeController(IUserImageService userImageService)
        {
            this.userImageService = userImageService;
        }
         
        public ActionResult Index()
        { 
            return View();
        }
         
        public ActionResult GetPicture()
        {
            Random rnd = new Random();
            var imageName = string.Format("image_{0}.jpg", rnd.Next(1, 6)); 
            return new JsonResult() { Data = userImageService.GetImageViewModel(Server.MapPath("~/Images/" + imageName), imageName), JsonRequestBehavior = JsonRequestBehavior.AllowGet }; 
        }

        public ActionResult SetImagePreference(string imageName, string userName, bool likeImage)
        {
            if (!string.IsNullOrEmpty(imageName) && !string.IsNullOrEmpty(userName))
            {
                var imageList = userImageService.GetUserImages();

                if (imageList.Any(x => x.ImageName == imageName && x.UserName == userName))
                {
                    var exsitingItem = userImageService.GetUserImageByImageNameAndUsername(imageName,userName);
                    if (exsitingItem.LikeIt != likeImage)
                    {
                        exsitingItem.LikeIt = likeImage;
                        userImageService.SaveChange();
                    }
                }
                else
                {
                    var userImage = new UserImage()
                    {
                        ImageName = imageName,
                        UserName = userName,
                        LikeIt = likeImage
                    };
                    userImageService.CreateNewUserImage(userImage);
                }

                var returnModel = new UserImage()
                {
                    ImageName = imageName,
                    UserName = userName,
                    LikeIt = likeImage
                };
                return new JsonResult() { Data = returnModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


                //using (var context = new UserImageContext())
                //{
                //    if (context.UserImages.Any(x => x.ImageName == imageName && x.UserName == userName))
                //    {
                //        var exsitingItem = context.UserImages.FirstOrDefault(x => x.ImageName == imageName && x.UserName == userName);
                //        if (exsitingItem.LikeIt != likeImage)
                //        {
                //            exsitingItem.LikeIt = likeImage;
                //            context.SaveChanges();
                //        }
                //    }
                //    else
                //    {
                //        var userImage = new UserImage()
                //        {
                //            ImageName = imageName,
                //            UserName = userName,
                //            LikeIt = likeImage
                //        };
                //        context.UserImages.Add(userImage);
                //        context.SaveChanges();
                //    }

                //    var returnModel = new UserImage()
                //    {
                //        ImageName = imageName,
                //        UserName = userName,
                //        LikeIt = likeImage
                //    };
                //    return new JsonResult() { Data = returnModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                //}
            }
            return null;
        }

        public ActionResult GetPreferencedImages(string userName, bool likedImage)
        {
            if (!string.IsNullOrEmpty(userName)) {
                using (var context = new UserImageContext())
                {
                    if (context.UserImages.Any(x => x.UserName == userName && x.LikeIt == likedImage)) {
                        var imageList = context.UserImages.Where(x => x.UserName == userName && x.LikeIt == likedImage).ToList();
                        var returnList = new List<ImageViewModel>();
                        foreach (var image in imageList) {
                            returnList.Add(new ImageViewModel()
                            {
                                ImageName = image.ImageName,
                                ImageArray = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath("~/Images/" + image.ImageName))))
                            });
                        }
                        return new JsonResult() { Data = returnList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    } 
                }
            } 
            return null;
        } 
    }
}