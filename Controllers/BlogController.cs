using CRUD.Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CRUD.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly Context _Db;

        public BlogController(ILogger<BlogController> logger, Context Db)
        {
            _Db = Db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _Db.Blogs.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _Db.Blogs.Where(i => i.Id == id).SingleOrDefaultAsync());
        }

        public async Task<IActionResult> AddOrEdite(CRUD.Blog.Models.Blog blog)
        {
            try
            {
                if (blog.Id == null)
                    await _Db.Blogs.AddAsync(blog);
                if (blog.Id != null)
                    _Db.Blogs.Update(blog);

                await _Db.SaveChangesAsync();
                TempData["success"] = true;
            }
            catch (System.Exception)
            {

                TempData["danger"] = true;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delte(Guid id)
        {
            try
            {
                var Blog = await _Db.Blogs.Where(i => i.Id == id).SingleOrDefaultAsync();
                if (Blog != null)
                {
                    _Db.Blogs.Remove(Blog);
                    await _Db.SaveChangesAsync();
                    TempData["success"] = true;
                }
                TempData["NotFound"] = true;
            }
            catch (System.Exception)
            {

                TempData["danger"] = true;
            }
            return RedirectToAction("Index");
        }
    }
}