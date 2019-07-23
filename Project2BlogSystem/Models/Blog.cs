using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2BlogSystem.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }
        public DateTime DatePublished { get; set; }
    }

    public class BlogAppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public System.Data.Entity.DbSet<Project2BlogSystem.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Project2BlogSystem.Models.Tag> Tags { get; set; }
    }
}