using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2BlogSystem.Models
{
    public class Tag
    {
        public int TAGId { get; set; }
        public string TagName { get; set; }
        public Blog blog { get; set; }
    }
}