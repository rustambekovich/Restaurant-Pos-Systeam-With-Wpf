using Restaurant_Pos_Systeam_With_Wpf.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Servise.ImageServises
{
    public static class CopyImage
    {
        public async static Task<string>  CopyImageAsync(string imagePath, string distinationDictionary)
        {
            if (!Directory.Exists(distinationDictionary))
                Directory.CreateDirectory(distinationDictionary);
           var imgName = ContentGenereteImagePaath.GeneretImagePath(imagePath);
           string path = Path.Combine(distinationDictionary, imgName);
            byte[] image = await File.ReadAllBytesAsync(imagePath);
            await File.WriteAllBytesAsync(path, image);
            return path;
        }
    }
}
