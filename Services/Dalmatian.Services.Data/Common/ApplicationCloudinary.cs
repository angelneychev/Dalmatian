namespace Dalmatian.Services.Data.Common
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public static class ApplicationCloudinary
    {
        public static async Task<string> UploadImage(Cloudinary cloudinary, IFormFile imagesUrl, string pedigreeName)
        {
            byte[] destinationImage;

            using  (var memoryStream = new MemoryStream())
            {
                await imagesUrl.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var ms = new MemoryStream(destinationImage))
            {
                pedigreeName = pedigreeName.Replace("&", "And").Replace(" ", "-").Replace("'s", "-s");

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imagesUrl.FileName, ms),
                    PublicId = pedigreeName,
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                return uploadResult.SecureUri.AbsoluteUri;
            }
        }

        public static void DeleteImage(Cloudinary cloudinary, string pedigreeName)
        {
            var delParams = new DelResParams()
            {
                PublicIds = new List<string>() { pedigreeName },
                Invalidate = true,
            };

            cloudinary.DeleteResourcesAsync(delParams);
        }
    }
}
