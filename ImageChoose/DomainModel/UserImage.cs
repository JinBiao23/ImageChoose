using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageChoose.DomainModel
{
    public class UserImage
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ImageName { get; set; }
        public bool LikeIt { get; set; }
    }
}