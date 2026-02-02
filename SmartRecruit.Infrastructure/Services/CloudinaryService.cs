using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Configurations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRecruit.Infrastructure.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> ManageFileAsync(Stream? fileStream, string? fileName, string? publicIdOrUrl)
        {
            // Case 1: UPDATE or DELETE (If publicIdOrUrl is provided, try to delete the old file first)
            if (!string.IsNullOrEmpty(publicIdOrUrl))
            {
                string publicId = GetPublicIdFromUrl(publicIdOrUrl);
                
                // If parsing fails, maybe it's already a publicId? Use as is if it looks like one (simple heuristic or just try)
                // For safety, assume if it doesn't match our URL pattern, treat it as public ID if user passed it directly? 
                // However, request says "publicIdOrUrl". 
                if (string.IsNullOrEmpty(publicId)) publicId = publicIdOrUrl; // Try treating input as ID directly if URL parse fails

                if (!string.IsNullOrEmpty(publicId))
                {
                    try
                    {
                        var deletionParams = new DeletionParams(publicId);
                        // Smart Delete Logic
                        if (publicId.Contains("SmartRecruit/Documents"))
                             deletionParams.ResourceType = ResourceType.Raw;
                        else
                             deletionParams.ResourceType = ResourceType.Image;

                        await _cloudinary.DestroyAsync(deletionParams);
                    }
                    catch
                    {
                        // Ignore delete errors (file might not exist)
                    }
                }

                // If no file provided, this was just a DELETE operation
                if (fileStream == null || fileStream.Length == 0)
                {
                    return "success";
                }
            }

            // Case 2: UPLOAD (or Update Part 2) - If file provided, upload it
            if (fileStream != null && fileStream.Length > 0 && !string.IsNullOrEmpty(fileName))
            {
                string extension = Path.GetExtension(fileName).ToLower();
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                string sanitizedFileName = SanitizeFileName(fileNameWithoutExt);
                string publicId = $"{sanitizedFileName}_{DateTime.Now:yyyyMMdd_HHmmss}";

                string folder = (extension == ".pdf") ? "SmartRecruit/Documents" : "SmartRecruit/Avatars";

                var uploadParamsObj = new
                {
                    File = new FileDescription(fileName, fileStream),
                    PublicId = publicId,
                    Folder = folder,
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };

                RawUploadParams uploadParams;

                if (extension == ".pdf")
                {
                    uploadParams = new RawUploadParams
                    {
                        File = uploadParamsObj.File,
                        PublicId = uploadParamsObj.PublicId,
                        Folder = uploadParamsObj.Folder,
                        UseFilename = uploadParamsObj.UseFilename,
                        UniqueFilename = uploadParamsObj.UniqueFilename,
                        Overwrite = uploadParamsObj.Overwrite
                    };
                }
                else
                {
                    uploadParams = new ImageUploadParams
                    {
                        File = uploadParamsObj.File,
                        PublicId = uploadParamsObj.PublicId,
                        Folder = uploadParamsObj.Folder,
                        UseFilename = uploadParamsObj.UseFilename,
                        UniqueFilename = uploadParamsObj.UniqueFilename,
                        Overwrite = uploadParamsObj.Overwrite
                    };
                }

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                        throw new Exception(uploadResult.Error.Message);
                }

                return uploadResult.SecureUrl.ToString();
            }

            return string.Empty; // Should not reach here if inputs are valid for one of the operations
        }

        private string GetPublicIdFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return string.Empty;
            try
            {
                var uri = new Uri(url);
                string path = uri.AbsolutePath; 
                string folderMarker = "SmartRecruit/";
                int index = path.IndexOf(folderMarker, StringComparison.OrdinalIgnoreCase);
                if (index == -1) return string.Empty;
                string fullPathWithExt = path.Substring(index);
                string publicId = fullPathWithExt;
                int lastDotIndex = publicId.LastIndexOf('.');
                if (lastDotIndex > 0) publicId = publicId.Substring(0, lastDotIndex);
                return System.Net.WebUtility.UrlDecode(publicId);
            }
            catch { return string.Empty; }
        }

        private string SanitizeFileName(string fileName)
        {
            string normalized = fileName.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();
            foreach (var c in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC).Replace(" ", "");
        }
    }
}
