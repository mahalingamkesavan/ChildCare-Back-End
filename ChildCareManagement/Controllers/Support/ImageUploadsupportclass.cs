using businessServicess.models.RequestModels.ChildCare;
using Microsoft.Extensions.FileProviders;

namespace ChildCareAPI.Controllers.Support
{
    public class ImageUploadsupportclass
    {
        private readonly IFileProvider _provider;
        private readonly IWebHostEnvironment _webHost;

        public ImageUploadsupportclass(IFileProvider provider, IWebHostEnvironment webHost)
        {
            _provider = provider;
            _webHost = webHost;
        }

        public async Task<string> GetFilePath(ParentDTO model)
        {

            string? fileName = null;

            IFormFile formFileformFile = model.UserImageUrl;

            var Fullname = model.FirstName + model.LastName; 

             var extension = "." + formFileformFile.FileName.Split('.')[formFileformFile.FileName.Split('.').Length - 1];

            fileName = Fullname + extension;

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), _webHost.WebRootPath + "\\image\\");

            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            var exactpath = Path.Combine(Directory.GetCurrentDirectory(), _webHost.WebRootPath + "\\image\\" + fileName);

            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await model.UserImageUrl.CopyToAsync(stream);
            }

            return fileName;
        }
        public async Task<string> GetFilePathchild(ChildRequest model)
        {

            string? fileName = null;

            IFormFile formFileformFile = model.UserImageUrl;

            var Fullname = model.FirstName + model.LastName;

            var extension = "." + formFileformFile.FileName.Split('.')[formFileformFile.FileName.Split('.').Length - 1];

            fileName = Fullname + extension;

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), _webHost.WebRootPath + "\\image\\");

            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            var exactpath = Path.Combine(Directory.GetCurrentDirectory(), _webHost.WebRootPath + "\\image\\" + fileName);

            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await model.UserImageUrl.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
