using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Practice2.Models;
using Practice2.Security;
using Practice2.SolidPrinciple;

namespace Practice2.Controllers
{
    public class HomeController : Controller
    {
        //function
        //public List<Student> GetUserList()
        //{
        //    List<Student> s = new()
        //    {
        //        new Student{Id=1,Name="Ram Bahadur",Address="ktm"},
        //         new Student{Id=2,Name="Shyam Bahadur",Address="Bkt"},
        //          new Student{Id=3,Name="Hari Bahadur",Address="Chitwan"},
        //    };
        //    return s; 
        //}
        //declaration
        private readonly IStudentService _service;
        private readonly CrudPracticeContext _appContext;
        private readonly IDataProtector _protector;
        private readonly IWebHostEnvironment _env;


        public HomeController(IStudentService service, CrudPracticeContext context,
            DataSecurityProvider datakey, IDataProtectionProvider provider,IWebHostEnvironment env)
        {
            _service = service;
            _protector = provider.CreateProtector(datakey.dataKey);
            _appContext = context;
            _env = env;
        }
        public IActionResult Index()
        {
           //List<Student> std = GetUserList();
          // var std = GetUserList();
            //return Json(std);
            var s = _service.GetStudents();
            //return Json(s);
            var u = s.Select(e => new UserListEdit
            {
                UserId = e.userId,
                UserName = e.UserName,
                EmailAddress = e.EmailAddress,
                UserAddress = e.UserAddress,
                UserPassword = e.UserPassword,
                UserProfile = e.UserProfile,
                // EncId = _protector.Protect(e.UserId.ToString()),
                EncId = _protector.Protect(Convert.ToString(e.userId)),
               UserRole = e.UserRole,
            }).ToList();
            
            return View(u);
        }
        public IActionResult Details(string id)
        {
            //var std = GetUserList().Where(x => x.Id == id).First();
            //return Json(std);
           // return View(std);

            int userid = Convert.ToInt32(_protector.Unprotect(id));
            UserList std = _service.GetStdById(userid);
            return View(std);
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserListEdit edit)
        {
            //int maxid;
            //if (_service.GetStudents().Any())
            //   maxid = _service.GetStudents().Max(x => x.userId) + 1;
            //else
            //    maxid = 1;
            //edit.UserId = maxid;

            if (edit.UserFile != null)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(edit.UserFile.FileName);
                string filepath = Path.Combine(_env.WebRootPath, "UserProfile", filename);
                using (FileStream str = new FileStream(filepath, FileMode.Create))
                {
                    edit.UserFile.CopyTo(str);

                }
                edit.UserProfile = filename;
            }
            //Mapping
            UserList u = new()
            {
               //userId = edit.UserId,
                EmailAddress = edit.EmailAddress,
                UserAddress = edit.UserAddress,
                UserName = edit.UserName,
                UserPassword = edit.UserPassword,
                UserProfile = edit.UserProfile,
                UserRole = edit.UserRole,
                UserStatus = true,
            };
            if(u!= null)
            {
                try
                {

                    _service.AddStd(u);
                }
                catch(Exception ex)
                {
                    var error = ex;
                }
                return RedirectToAction("Create");
                //return Json("success");
                
            }
            else
            {
                return Json("Failed");      
            }
            //return Json("success");
        }

        [HttpGet]
        public IActionResult Edit(string encId)
        {
            int id = Convert.ToInt32( _protector.Unprotect(encId));
            var u = _appContext.UserLists.Where(x=>x.userId==id).FirstOrDefault();

            UserListEdit e = new()
            {
                UserId = u.userId,
                EmailAddress = u.EmailAddress,
                UserAddress = u.UserAddress,
                UserName = u.UserName,
                UserPassword = u.UserPassword,
                UserProfile = u.UserProfile,
                UserRole = u.UserRole,
                UserStatus = true,
            };

            return View(u);
        }

        [HttpPost]
        public IActionResult Edit(UserListEdit edit)
        {
            return Json("");
        }
    }
}
