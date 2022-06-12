using Microsoft.AspNetCore.Http;

namespace ImageSaveAndReadCoreMongoDB.Models
{
    public class FileUpload
    {
        public IFormFile file { get; set; }
        public string Employee { get; set; }
    }
}
