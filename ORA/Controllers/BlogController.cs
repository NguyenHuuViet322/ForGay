using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORA.Data;
using ORA.Models;

namespace ORA.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BlogController(BlogContext context, IHttpContextAccessor accessor) { 
            _context= context;
            httpContextAccessor = accessor;
        }
        public IActionResult Index()
        {
            return View(_context.blogs.ToList());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult newPost(string content, string title)
        {
            var userId = HttpContext.User.Identity.Name;
            var post = new Blog() { content = content, userMail = userId, title = title };    
            _context.blogs.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult newCmt(int postId, string name, string cmt)
        {
            var comment = new Comment() { userMail = name, content = cmt, dateCreated = DateTime.Now, postId = postId};
            _context.comments.Add(comment);
            _context.SaveChanges();
            return Redirect("Detail?id="+postId);
        }

        public IActionResult Remove(int cmtId, int postId)
        {
            var cmt = _context.comments.FirstOrDefault(p => p.id == cmtId);
            if (cmt != null)
            {
                _context.comments.Remove(cmt);
                _context.SaveChanges();
            }
            return Redirect("Detail?id=" + postId);
        }

        public IActionResult detail(int id)
        {
            return View(_context.blogs.FirstOrDefault(p => p.id == id));
        }
    }
}
