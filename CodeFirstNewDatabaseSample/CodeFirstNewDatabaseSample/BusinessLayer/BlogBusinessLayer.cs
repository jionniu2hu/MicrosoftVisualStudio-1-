using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using CodeFirstNewDatabaseSample.Models;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
    public class BlogBusinessLayer
    {
        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;
                return db.Blogs.ToList();
            }
        }
        //上下两种方法
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Add(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);
                //db.Entry(Blog).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        //Post的方法
        //public List<Post> Querya(int blogID)
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        //将数据转换为列表
        //        return db.Posts.ToList();
        //    }
        //}
    }
}
