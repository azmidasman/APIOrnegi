using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajAPI.Repositories.Abstract;

namespace StajAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _cr;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _cr=categoryRepository;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_cr.GetAll());
        }
    }
}
