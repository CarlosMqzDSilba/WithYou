using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WithYou.Web.Helpers
{
    public class ImagenHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string nameFile, string folderName)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{nameFile}{guid}.png";
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{folderName}", file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"~/images/{folderName}/{file}";
        }
    }
}
