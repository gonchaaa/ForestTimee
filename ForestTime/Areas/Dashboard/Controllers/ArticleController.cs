using ForestTime.Data;
using ForestTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ForestTime.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ArticleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public ArticleController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var tagList=_context.Tags.ToList();
            var categoryList=_context.Categories.ToList();
            ViewBag.Tags = new SelectList(tagList,"Id","TagName");
            ViewBag.Categories = new SelectList(categoryList,"Id","CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Article article,List<int> tagIds,int categoryId)
        {
            try
            {
                article.UserId =_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ;
                article.SeoUrl = "";
                article.CreatedDate = DateTime.Now;
                article.UpdatedDate = DateTime.Now;
                article.CategoryId=categoryId;
                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
                for (int i = 0; i < tagIds.Count; i++)
                {
                    ArticleTag articleTag = new()
                    {
                        TagId = tagIds[i],
                        ArticleId=article.Id
                    };
                   await _context.ArticleTags.AddAsync(articleTag);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View(article);
            }
        }
    }
}
