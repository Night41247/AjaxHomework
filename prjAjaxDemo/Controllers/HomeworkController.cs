using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using prjAjaxDemo.Models;
using System.Reflection.Metadata;
using static prjAjaxDemo.Models.Spot;


namespace prjAjaxDemo.Controllers
{
    [Route("api/[controller]")]
    public class HomeworkController : Controller
    {
       
        private readonly MyDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeworkController(MyDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Homework1()
        {
            return View();
          
        }

        [HttpPost("Homework2")]
        public IActionResult Homework2([FromBody] string name)
        {
            Member? member = _context.Members.Find(name);
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json(new { success = false, message = "請輸入姓名" });
            }

            var memberExists = _context.Members.Any(m => m.Name.ToLower() == name.ToLower());
            return Json(new { success = true, exists = memberExists });
        }

        [HttpPost("Homework3")]
        public IActionResult Homework3(Member member, IFormFile avatar)
        {
            if (string.IsNullOrEmpty(member.Name))
            {
                member.Name = "guest";
            }
            //實際路徑
            //string uploadPath = @"C:\Users\User\Documents\workspace\MSIT158Site\wwwroot\uploads\a.png";
            //WebRootPath：C: \Users\User\Documents\workspace\MSIT158Site\wwwroot
            //ContentRootPath：C:\Users\User\Documents\workspace\MSIT158Site
            string uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", avatar.FileName);
            string info = uploadPath;
            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                avatar.CopyTo(fileStream);
            }
            //檔案上傳轉成二進位
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                avatar.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }

            //寫進資料庫
            member.FileName = avatar.FileName;
            member.FileData = imgByte;
            _context.Members.Add(member);
            _context.SaveChanges();

            return Content(info, "text/plain", System.Text.Encoding.UTF8);
        }

        public IActionResult Homework4(string name)
        {
            return View();
        }
    }

   

        
}
