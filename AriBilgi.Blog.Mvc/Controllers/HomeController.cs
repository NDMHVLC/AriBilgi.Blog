using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Shared.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       

        public IActionResult Index()
        {
            return View();
        }
        #region
        [HttpPost]
        public List<User> GetUserList()
        {
            return _unitOfWork.Users.GetAll();
        }

        [HttpPost]
        public List<Category> GetCategoryList()
        {
            return _unitOfWork.Categories.GetAll();
        }
        [HttpPost]
        public List<Article> GetArticleList()
        {
            return _unitOfWork.Articles.GetAll();
        }
        #endregion
    }
}
