using Microsoft.AspNetCore.Http;
namespace MissionSystem.Helpers
{
    public class Helper
    {
        public static string UploadFiles(string root, string foldername, IFormFile image)
        {
            var fileName = DateTime.Now.Ticks + image.FileName;
            var fullpath = Path.Combine(root, foldername, fileName);
            if (!Directory.Exists(foldername))
                Directory.CreateDirectory(foldername);
            var stream = new FileStream(fullpath, FileMode.Create);
            image.CopyTo(stream);
            stream.Flush();
            stream.Close();
            return fileName;
        }

        public static byte[] GetImage(string root, string foldername, string image)
        {
            string filePath = root + foldername + image;
            return !File.Exists(filePath)
                ? File.ReadAllBytes(root + "Resources/Images/noimage.jpg")
                : File.ReadAllBytes(filePath);
        }
        public static string Image(string host, string path, string image) => $"{host}/api/Resources/Images/{path}/{image}";
    }
}
