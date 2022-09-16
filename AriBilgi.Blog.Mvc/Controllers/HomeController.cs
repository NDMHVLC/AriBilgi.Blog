using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Mvc.Models.Home;
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
        public List<UserDTO> GetUserList()
        {
            List<User> userList = _unitOfWork.Users.GetAll();
            List<UserDTO> userDTOList = new List<UserDTO>();

            foreach (User user in userList)
            {
                userDTOList.Add(new UserDTO
                {
                    Id = user.Id,
                    NameSurname = user.Name + " " + user.Surname,
                    ArticleCount = _unitOfWork.Articles.Count(x=>x.UserId==user.Id),
                    CommentCount = _unitOfWork.Comments.Count(x=>x.UserId==user.Id),
                    Role=_unitOfWork.UserRoles.Get(x=>x.Id == user.UserRoleId).Title
                });
            }
            userList = null;
            return userDTOList;
        }

        [HttpPost]
        public List<CategoryDTO> GetCategoryList()
        {
            List<Category> categoryList = _unitOfWork.Categories.GetAll();
            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();

            foreach (Category category in categoryList)
            {
                categoryDTOList.Add(new CategoryDTO
                {
                    Id =category.Id,
                    Name = category.Title,
                    ArticleCount = _unitOfWork.Articles.Count(x=>x.CategoryId== category.Id),
                });
            };
            categoryList = null;
            return categoryDTOList;
        }
        [HttpPost]
        public List<Article> GetArticleList()
        {
            return _unitOfWork.Articles.GetAll();
        }
        #endregion
    }
}
