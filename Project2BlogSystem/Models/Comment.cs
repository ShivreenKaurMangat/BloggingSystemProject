using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2BlogSystem.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public bool IsAccepted { get; set; }
        public string Email { get; set; }
    }
}