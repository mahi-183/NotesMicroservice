// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace CommanLayer
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    public class CloudinaryImage
    {
        public string UploadImageCloudinary(IFormFile file, int id)
        {
            try
            {
                var name = file.FileName;
                var stream = file.OpenReadStream();

                CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("bridgelabz-com", "921945993926817", "UcknrXKjOuFQAFZHwzoPxMFKELY");
                CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(name, stream)
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                var uploadUrl = uploadResult.Uri.ToString();

                return uploadUrl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
