using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game
{
    // для картинок и разных ресурсов
    public class ResourceManager
    {
        private Dictionary<string, ImageSource> textures = new Dictionary<string, ImageSource>();

        public ImageSource LoadTexture(string ImageName)
        {
            if (textures.ContainsKey(ImageName))
            {
                return textures[ImageName];
            }

            var img = new BitmapImage(new Uri("gamedata\\texture\\" + ImageName + ".png", UriKind.Relative));
            textures.Add(ImageName, img);

            return img;
        }

    }
}
