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
    public class PostBusinessLayer
    {
        public List<Post> Query()
        {
            using (var db = new BloggingContext())
            {
                //将数据转换为列表
                return db.Posts.ToList();
            }
        }
        public Post Query(int blogID)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(blogID);
            }
        }

        public void Add(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public void Update(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public List<Post> Query(string title)
        {
            using (var db = new BloggingContext())
            {
                // 查询所有包含字符串name的博客
                var post = from i in db.Posts
                           where i.Title.Contains(title)
                           select i;
                return post.ToList();
            }
        }

    }
}
