using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;

namespace GearMVC.Controllers
{
    [Route("admin/[controller]")]
    public class ImageController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var size = 2097152;
            if (upload.Length > size)
            {
                var errorMessage = "Kích thước ảnh phải <= 2048MB";
                var error = new {  error = new { message = errorMessage } };
                return Json(error);
            }

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/images/products/products_description",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await upload.CopyToAsync(stream);

            }

            var url = $"{"/images/products/products_description/"}{fileName}";
            var successMessage = "Ảnh được upload thành công";
            var success = new { uploaded = 1, fileName, url, error = new { message = successMessage } };
            return Json(success);
        }
    }
}
