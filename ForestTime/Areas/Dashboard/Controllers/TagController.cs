using ForestTime.Data;
using ForestTime.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForestTime.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TagController : Controller
    {

        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }   
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            try
            {

            tag.CreatedDate = DateTime.Now;
            tag.UpdatedDate = DateTime.Now;
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

             return View("Create");
            }
        }
    }
}
