using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Properties;

namespace TestCard.Domain.Helpers
{
    public static class FileHelper
    {
        public static void SaveImage(byte[] fileData, ref string fileName, ref string filePath)
        {
            do
            {
                fileName = Guid.NewGuid().ToString() + ".jpeg";
                filePath = System.IO.Path.GetFullPath(Config.FilePath + fileName);
            } while (System.IO.File.Exists(filePath));

            using (var file = System.IO.File.Open(filePath, System.IO.FileMode.OpenOrCreate))
            {
                fileData = Tools.ImageTool.AutoOrientImageFile(fileData);
                file.Write(fileData, 0, fileData.Length);
            }
        }

        public static void Delete(string filePath)
        {
            System.IO.File.Delete(filePath);
        }
    }
}
