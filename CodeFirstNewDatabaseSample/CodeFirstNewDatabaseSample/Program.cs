using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //selectBlog();
            QueryKey();
            Console.WriteLine("任意键退出");
            Console.ReadKey();
        }

        //博客和贴子总列表
        static void selectBlog()
        {
            Console.WriteLine("下列博客");
            QueryBlog();
            Console.WriteLine("请输入您要选择的功能编号:  1-增加博客    2-更新博客    3-删除博客    4-贴子列表   5-退出");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.Clear();
                    createBlog();
                    break;
                case 2:
                    Console.Clear();
                    Update();
                    break;
                case 3:
                    Console.Clear();
                    Delete();
                    break;
                case 4:
                    Console.Clear();
                    selectPost();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }

        static void selectPost()
        {
            Console.WriteLine("下列贴子");
            QuertPost();
            Console.WriteLine("请输入您要选择的功能编号:  1-增加贴子    2-更新贴子    3-删除贴子   4-博客列表   5-退出");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.Clear();
                    AddPost();
                    break;
                case 2:
                    Console.Clear();
                    UpdatePost();
                    break;
                case 3:
                    Console.Clear();
                    DeletPost();
                    break;
                case 4:
                    Console.Clear();
                    selectBlog();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }


        
        //增加贴子
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogID = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPost(blogID);
            //根据指定到博客信息创建新帖子      
            //CreatePost(blogID);

            Post post = new Post();
            post.BlogID = blogID;

            Console.WriteLine("请输入新的贴子名称");
            string title = Console.ReadLine();
            post.Title = title;

            Console.WriteLine("请输入新的贴子内容");
            string content = Console.ReadLine();
            post.Content = content;

            PostBusinessLayer pbl = new PostBusinessLayer();
            pbl.Add(post);
            Console.Clear();
            selectPost();
        }

        static int GetBlogId()
        {
            //提示用户输入id
            Console.WriteLine("用户请选择某个博客（id）");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            //中断返回，显示id
            return (id);
        }
        //显示选中博客的所有贴子
        static void DisplayPost(int blogID)
        {
            Console.WriteLine(blogID + "的贴子列表：");

            List<Post> list = null;
            //根据博客id获取博客
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogID);
                //根据博客导航属性，获取所有该博客到贴子
                list = blog.Posts;
            }
            //遍历所有贴子，显示贴子标题（博客好-帖子标题）
            foreach (var item in list)
            {
                Console.WriteLine("博客id：" + item.Blog.BlogID);
                Console.WriteLine("贴子id:" + item.PostId);
                Console.WriteLine("贴子名称:" + item.Title);
                Console.WriteLine("贴子内容:" + item.Content);
            }
        }
        //显示全部贴子
        static void QuertPost()
        {
            PostBusinessLayer pbl = new PostBusinessLayer();
            var posts = pbl.Query();
            foreach (var item in posts)
            {
                Console.WriteLine("博客id：" + item.BlogID);
                Console.WriteLine("贴子id:" + item.PostId);
                Console.WriteLine("贴子名称:" + item.Title);
                Console.WriteLine("贴子内容:" + item.Content);
                Console.WriteLine("");

            }
        }
        //更新贴子
        static void UpdatePost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogID = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPost(blogID);

            Console.WriteLine("输入需要修改到贴子id");
            int id = int.Parse(Console.ReadLine());
            PostBusinessLayer pbl = new PostBusinessLayer();
            Post post = pbl.Query(id);

            Console.WriteLine("请输入新的贴子名称");
            string title = Console.ReadLine();
            post.Title = title;

            Console.WriteLine("请输入新的贴子内容");
            string content = Console.ReadLine();
            post.Content = content;

            pbl.Update(post);
            Console.Clear();
            selectPost();
        }
        //删除贴子
        static void DeletPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogID = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPost(blogID);

            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("输入需要删除到贴子id");
            int id = int.Parse(Console.ReadLine());
            Post post = pbl.Query(id);
            pbl.Delete(post);
            Console.Clear();
            selectPost();
        }


        //增加博客
        static void createBlog()
        {
            QueryBlog();
            Console.WriteLine("请输入新的博客名");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
            Console.Clear();
            selectBlog();
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                //Console.Write(item.BlogID + " ");
                Console.WriteLine(item.BlogID + " " + item.Name);
            }
        }
        //更新博客
        static void Update()
        {
            QueryBlog();
            Console.WriteLine("请输入需要修改的博客id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入博客新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
            Console.Clear();
            selectBlog();
        }
        //删除博客
        static void Delete()
        {
            QueryBlog();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入需要删除到博客id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
            Console.Clear();
            selectBlog();
        }
        //查询博客
        static void QueryKey()
        {
            Console.WriteLine("输入要查询到微博名");
            string name = Console.ReadLine();
            PostBusinessLayer pbl = new BusinessLayer.PostBusinessLayer();
            var query = pbl.Query(name);
            foreach(var item in query)
            {
                Console.WriteLine(item.Title + "  " + item.Content);             
            }
        }
    }
}
