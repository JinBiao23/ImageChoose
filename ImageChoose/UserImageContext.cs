using ImageChoose.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageChoose
{
    public class UserImageContext :DbContext
    {
        public DbSet<UserImage> UserImages { get; set; }
    }
}