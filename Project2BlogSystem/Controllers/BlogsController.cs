using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2BlogSystem.Models;

namespace Project2BlogSystem.Controllers
{
    public class BlogsController : Controller
    {
        private BlogAppDbContext db = new BlogAppDbContext();

        public ActionResult ListOfTags()
        {
            var tags = db.Blogs.Select(b => b.Tag).Distinct().ToList();
            return View(tags);
        }

        public ActionResult BlogsByTags(string value)
        {
            var blogsByTag = db.Blogs.Where(b => b.Tag == value).ToList();
            return View(blogsByTag);
        }

        public ActionResult TagsWithMaxBlogs()
        {
            var tag = db.Blogs.GroupBy(x => x.Tag).OrderByDescending(x => x.Count()).FirstOrDefault().FirstOrDefault();
            return View(tag);
        }

        public ActionResult TagsWithCount()
        {
            var tags = db.Blogs.Select(b => b.Tag).Distinct().ToList();
            return View(tags);
        }

        // GET: Blogs
        public ActionResult BlogsByDate()
        {
            var model = db.Blogs.OrderByDescending(b => b.DatePublished).ToList();
            return View(model);
        }

        public ActionResult ShowByYear()
        {
            var years = db.Blogs.Select(b => b.DatePublished.Year.ToString()).Distinct().ToList();
            ViewBag.Years = years;
            return View();
        }

        public ActionResult year(int value)
        {
            var blogYear = db.Blogs.Where(b => b.DatePublished.Year == value).ToList();
            return View(blogYear);
        }
        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Content,Tag,DatePublished")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,Tag,DatePublished")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var model = db.Blogs.ToList();
            return View(model);
        }
    }
}
