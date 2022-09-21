using Agreement_Management.DTOs;
using Agreement_Management.Interface;
using Agreement_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agreement_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        private readonly IHttpContextAccessor _accessor;
        const string SessionName = "Kingsley";
        const string SessionEmail = "Kingsly.ozoemena@gmail.com";
        private readonly ILogger<UserController> _logger;

        public UserController(IUser user,IHttpContextAccessor accessor, ILogger<UserController> logger)
        {
            _user = user;
            _accessor = accessor;
            _logger = logger;
        }
        ServiceResponse apiResponse = new ServiceResponse();
        HttpResponseMessage response = new HttpResponseMessage();

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Register(RegisterDTO register)
        {
            HttpContext.Session.SetString(SessionName, register.Name);
            HttpContext.Session.SetString(SessionEmail, register.Email);
           // HttpContext.Session.SetInt32(SessionAge, 24);
            var response = _user.Register(register);
            if (response.Result != null)
            {
                return Index();
            }
            return Index();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDTO login)
        {
            HttpContext.Session.SetString(SessionEmail, login.Email);
            var response = _user.Login(login);
            if (response.Result != null)
            {
                return Home();
            }
            return Index();
        }
        [HttpGet]
        public ActionResult NewAgreement()
        {
            return View();
        }

        public ActionResult CreateProductGroup()
        {
            return View();
        }

        public ActionResult CreateProduct()
        {
            return View();
        }
        public ActionResult UpdateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAgreement(AgreementDTO agree)
        {
           var userId =  HttpContext.Session.GetString(SessionEmail);
            var response = _user.NewAgreement(agree, userId);
            if (response!= null)
            {
                return RedirectToAction("Index","Home");
            }
            return Index();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductDTO product)
        {
            var response = _user.CreateProduct(product);
            if (response != null)
            {
                return RedirectToAction("NewAgreement", "User");
            }
            return Home();
        }
        [HttpPost]
        public ActionResult CreateProductGroup(ProductGroupDTO pg)
        {
            var response = _user.CreateProductGroup(pg);
            if (response.Result != null)
            {
              return  RedirectToAction("CreateProduct", "User");
            }
            return Home();
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductDTO update)
        {
            var updated = _user.UpdateProduct(update);
            if(updated!= null)
            {
                return RedirectToAction("GetProduct", "User");
            }

            return RedirectToAction("GetProduct", "User");
        }
       
        [HttpGet]
        public ActionResult GetProductById(int id)
        {
            var result = _user.GetById(id);
            if (result == null)
            {
                return View();
            }
            return View(result);
        }


        public ActionResult GetAll()
        {
            var s = _user.GetAll();

            if (s==null)
            {
                return View();
            }
            return View(s);
        }

        [HttpDelete]
        public ActionResult DeleteProductById(int id)
        {
            var d = _user.DeleteProduct(id);
            if (d == null)
            {
                return View();
            }

            return View(d);
        }


        [HttpPost]
        public ActionResult UpdateProductGroup(ProductGroupDTO update)
        {
            var updated = _user.UpdateProductGroup(update);
            if (updated != null)
            {
                return Home();
            }

            return Home();
        }


       
    }
}
