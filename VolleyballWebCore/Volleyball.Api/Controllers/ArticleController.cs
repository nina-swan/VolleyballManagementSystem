using Microsoft.AspNetCore.Mvc;
using Volleyball.DbServices.Services;

namespace Volleyball.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleDbService articleDbService = new ArticleDbService();

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var result = await articleDbService.GetAllArticles();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var result = await articleDbService.GetArticle(id);
            return Ok(result);
        }
    }
}
