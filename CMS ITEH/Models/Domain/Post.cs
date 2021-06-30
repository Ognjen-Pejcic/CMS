using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_ITEH.Models.Domain
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public byte[] FeaturedImage { get; set; }
        public string PostTextContent { get; set; }
        public User User { get; set; }
    }
}
