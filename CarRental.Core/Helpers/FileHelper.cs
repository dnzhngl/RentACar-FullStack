using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CarRental.Core.Helpers
{
    /// <summary>
    /// Solution level file helper class that handles the file operations under the Uploads folder.
    /// </summary>
    public static class FileHelper
    {
        private static string LogoPath = "Defaults\\logo.jpg";
        private static string wwwroot = "wwwroot";
        private static string Uploads = "Uploads";
        private static DirectoryInfo solutionDirInfo;

        /// <summary>
        /// Gets the folder name  based on the given file extension.
        /// </summary>
        /// <param name="fileExtension">File extension must be given in form of string.</param>
        /// <returns>If the system does not support the given file extension it returns an ErrorDataResult with error message, else it returns SuccessDataResult with the data of folder name.</returns>
        private static IDataResult<string> GetRelatedFolderName(string fileExtension)
        {
            if (String.IsNullOrEmpty(fileExtension))
            {
                return new ErrorDataResult<string>(message:"The file extension parameter is null.");
            }
            switch (fileExtension)
            {
                case ".jpeg":
                case ".jpg":
                case ".gif":
                case ".png":
                    return  new SuccessDataResult<string>(data:"Images");
                case ".doc":
                case ".docx":
                case ".txt":
                case ".pdf":
                    return new SuccessDataResult<string>(data:"Files");
                default:
                    return new ErrorDataResult<string>(message:"Type of the file is not supported.");
            }
        }

        /// <summary>
        /// Gets the folder name, that the given file should be saved.
        /// </summary>
        /// <param name="file">File must be given in form of IFormFile.</param>
        /// <returns>If the system does not support the given file's type it returns an ErrorDataResult with error message, else it returns SuccessDataResult with the data of folder name.</returns>
        private static IDataResult<string> GetRelatedFolderName(IFormFile file)
        {
            if (file.Length == 0)
            {
                return new ErrorDataResult<string>(message:"The file is null.");
            }

            string fileType = file.ContentType;

            if (fileType.Contains("image"))
                return new SuccessDataResult<string>(data:"Images");
            else if (fileType.Contains("text"))
                return new SuccessDataResult<string>(data: "Files");
            else if (fileType.Contains("video"))
                return new SuccessDataResult<string>(data:"Videos");
            else
                return new ErrorDataResult<string>(message: "Type of the file is not supported.");
        }

        /// <summary>
        /// Gets solution directory.
        /// </summary>
        /// <param name="currentPath"></param>
        /// <returns>Returns DirectoryInfo of the solution.</returns>
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory()); // Returns the startup directory
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
        /// <summary>
        /// Get stratup project's directory info.
        /// </summary>
        /// <returns></returns>
        public static DirectoryInfo GetStartupDirectory()
        {
             return new DirectoryInfo(Directory.GetCurrentDirectory());
        }

        /// <summary>
        /// Gets destination path for the saving the file. It is located under the Uploads folder on the solution level with the given folder name.
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="fileName"></param>
        /// <returns>Returns SuccessDataResult with the data of the final path that involves file path and it's name with it's extension.</returns>
        private static IDataResult<string> GetDestinationPath(string foldername, string fileName)
        {
            //solutionDirInfo = TryGetSolutionDirectoryInfo();
            solutionDirInfo = GetStartupDirectory();
            var path = Path.Combine(wwwroot, Uploads, foldername);

            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            var newPath = solutionDirInfo.CreateSubdirectory(path).FullName;
            newPath = Path.Combine(newPath, fileName);
            return new SuccessDataResult<string>(data:newPath);
        }
        /// <summary>
        /// Generates file name in type of guid.
        /// </summary>
        /// <param name="file">File should be given in a form of IFormFile.</param>
        /// <returns>Returns the new guid name in type of string.</returns>
        private static string GenerateGuidFileName(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string newFileName = string.Format(@"{0}{1}", Guid.NewGuid(), fileExtension);
            return newFileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">File should be given in a form of IFormFile.</param>
        /// <param name="folderName">The foldername that the file will be stored must be given.</param>
        /// <returns>Returns the new guid name and the folder path in type of string.</returns>
        private static string FileNameWithPath(string folderName, string fileName )
        {
            return string.Format(@"{0}\{1}\{2}",Uploads, folderName, fileName);
        }

        /// <summary>
        /// Uploads file,
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static IDataResult<string> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var folderName = GetRelatedFolderName(file).Data;
                var newFileName = GenerateGuidFileName(file);
                var destinationPath = GetDestinationPath(folderName, newFileName);

                using (var stream = new FileStream(destinationPath.Data, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                //return new SuccessDataResult<string>(data: destinationPath.Data, message: "Dosya sisteme başarı ile yüklendi."); // path with file name and extension
                return new SuccessDataResult<string>(data: FileNameWithPath(folderName,newFileName) , message: "Dosya sisteme başarı ile yüklendi."); // path with file name and extension
            }
            return new ErrorDataResult<string>(message: "Dosya yüklenirken bir hata oluştu.");
        }

        /// <summary>
        /// Deletes given file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Return SuccessResult if delete operations completed successfully. If the file is not found, it returns ErrorReuslt with an error meesage. If the given file is null, it returns ErrorResult with an error message.</returns>
        public static IResult DeleteFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var folderName = GetRelatedFolderName(file);
                var sourcePath = GetDestinationPath(folderName.Data, file.FileName);
                if (File.Exists(sourcePath.Data))
                {
                    File.Delete(sourcePath.Data);
                    return new SuccessResult();
                }
                return new ErrorResult("Silinmek istenen dosya mevcut değil.");
            }
            return new ErrorResult("Dosya silme işlemi başlatılamadı.");
        }

        /// <summary>
        /// Delets the file that has the given file path.
        /// </summary>
        /// <param name="filePath">Path of the file must be given.</param>
        /// <returns>Return SuccessResult if delete operations completed successfully. If the file is not found, it returns ErrorReuslt with an error meesage. If the given file is null, it returns ErrorResult with an error message. </returns>
        public static IResult DeleteFile(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath);
            var fileName = Path.GetFileName(filePath);
            var folderName = GetRelatedFolderName(fileExtension);
            var sourcePath = GetDestinationPath(folderName.Data, fileName);
            if (sourcePath != null)
            {
                if (File.Exists(sourcePath.Data))
                {
                    File.Delete(sourcePath.Data);
                    return new SuccessResult();
                }
                return new ErrorResult("Silinmek istenen dosya mevcut değil.");
            }
            return new ErrorResult("Dosya silme işlemi başlatılamadı.");
        }

        /// <summary>
        /// Updates the file that has the given file path with the given IFormFile. 
        /// </summary>
        /// <param name="file">File path must be given of type string.</param>
        /// <param name="filePath">New file must be given of type IFormFile.</param>
        /// <returns>If result in success, returns SuccessDataResult with the unew path information and a success message. Else returns ErrorDataResult with an error message.</returns>
        public static IDataResult<string> UpdateFile(IFormFile file, string filePath)
        {
            var isUploaded = UploadFile(file);
            if (isUploaded.Success)
            {
                var isDeleted = DeleteFile(filePath);
                if (isDeleted.Success)
                {
                    return new SuccessDataResult<string>(isUploaded.Data, "Dosya başarı ile güncellendi.");
                }
                DeleteFile(file);
            }
            return new ErrorDataResult<string>(message: "Dosya güncelleme işlemi başarısız.");
        }

        /// <summary>
        /// Gets the company's logo image path.
        /// </summary>
        /// <returns>Returns the logo image path in type of string.</returns>
        public static string GetLogoPath()
        {
            var parentDir = TryGetSolutionDirectoryInfo();
            var path = Path.Combine(parentDir.FullName, Uploads, LogoPath);
            return path;
        }
    }
}
