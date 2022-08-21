using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PostImageDTO
    {
        public int PostImageID { get; set; }
        public string ImageURL { get; set; }
        public int PostId { set; get; }
    }
}
