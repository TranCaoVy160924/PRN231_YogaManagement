using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MimeKit.Utils;
using System.Reflection.Metadata;
using YogaCenterAPIV2.Utils;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Repositories;

namespace YogaCenterAPIV2.DAL
{
    public class BlogRepository : IRepository<Blog>
    {
        YogaCenterContext db = new YogaCenterContext();

        public BlogRepository() { }
        public async Task Add(Blog blog)
        {
            Blog newBlog = new Blog { UserId = blog.UserId, Date= blog.Date, Header= blog.Header, Content= blog.Content, Img= blog.Img };
            db.Blogs.Add(newBlog);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var blog = await db.Blogs.FindAsync(id);
            if (blog != null)
            {
               db.Blogs.Remove(blog);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<dynamic>> GetAll()
        {
            var blogList = await (from b in db.Blogs
                                  join a in db.Accounts on b.UserId equals a.Id
                                  select new 
                                  {
                                      BlogID = b.Id,
                                      FirstName = a.Firstname,
                                      LastName = a.Lastname,
                                      Date = b.Date,
                                      Header = b.Header,
                                      Content = b.Content,
                                      img = b.Img
                                  }).ToListAsync();
            return blogList.Cast<dynamic>().ToList();
        }

        public async Task<dynamic> GetById(int id)
        {
            var blog = await db.Blogs.FirstOrDefaultAsync(b => b.Id  == id);
            return blog;
        }

        public async Task Update(int id, Blog blogUpdate)
        {
            var blog = await db.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if(blog != null)
            {
                blog.Content = blogUpdate.Content;
                blog.Header = blogUpdate.Header;
                blog.Img = blogUpdate.Img;
            }
            await db.SaveChangesAsync();
        }

        internal Task GetById(int? userId)
        {
            throw new NotImplementedException();
        }
    }
}
