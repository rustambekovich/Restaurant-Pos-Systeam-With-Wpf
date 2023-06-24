using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Helpers
{
    public class ContentGenereteImagePaath
    {
        public static string GeneretImagePath(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            return "IMG_" + Guid.NewGuid().ToString() + fileInfo.Extension;
        }
    }
}
