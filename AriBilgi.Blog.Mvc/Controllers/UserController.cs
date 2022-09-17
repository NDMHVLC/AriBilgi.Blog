using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AriBilgi.Blog.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Add()
        {
            return View();
        }

        public List<UserRole> GetUserRoleList()
        {
            return _unitOfWork.UserRoles.GetAll();
        }

        [HttpPost]
        public bool AddUser([FromBody]User user)
        {
            try
            {
                _unitOfWork.Users.Add(user);
                _unitOfWork.SaveAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
            
        }
    }
}
