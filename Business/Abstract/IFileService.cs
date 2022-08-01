using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IFileService
    {
        string SaveFileToServer(IFormFile file, string path);
        string SaveFileToFtp(IFormFile file);
        byte[] GetFileBinaryType(IFormFile file);
    }
}
