using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        public byte[] GetFileBinaryType(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();
                //string fileString = Convert.ToBase64String(fileBytes);
                return fileBytes;
            }
        }

        public string SaveFileToFtp(IFormFile file)
        {
            var fileType = file.FileName.Substring(file.FileName.IndexOf('.'));
            fileType = fileType.ToLower();
            string fileName = Guid.NewGuid().ToString() + fileType;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp.abc.com/Content/Img/" + fileName);
            request.Credentials = new NetworkCredential("Kullanıcı adı", "Şifre");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream ftpStream = request.GetRequestStream())
            {
                file.CopyTo(ftpStream);
            }
            return fileName;
        }

        public string SaveFileToServer(IFormFile file, string path)
        {
            var fileType = file.FileName.Substring(file.FileName.IndexOf('.'));
            fileType = fileType.ToLower();
            string fileName = Guid.NewGuid().ToString() + fileType;
            path = path + fileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}
