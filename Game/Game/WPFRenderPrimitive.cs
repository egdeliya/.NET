using System.Numerics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameCore.Render;

namespace Game
{
    public class WPFRenderPrimitive: IRenderPrimitive
    {
        private static ResourceManager resourceManager = new ResourceManager();
        private string _imageName;

        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }

        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                WpfImage.Dispatcher.BeginInvoke((ThreadStart) delegate
                {
                    if (_imageName != null)
                    {
                        ((Rectangle) WpfImage).Fill = new ImageBrush(resourceManager.LoadTexture(ImageName));
                    }
                    else
                    {
                        ((Rectangle) WpfImage).Fill = null;

                    }
                });

            }
        }

        // базовый тип для всех элементов
        public  FrameworkElement WpfImage { get; set; }

        public WPFRenderPrimitive()
        {
            WpfImage = new Rectangle();
        }

        public void Render(Camera camera)
        {
            // для того чтобы отображалось в центре экрана
            var position = camera.Resolution / 2 - new Vector2(camera.Position.X, camera.Position.Y);
            position += Position;

            var size = Size; // * camera.Position.Z
            position -= size / 2;


            // устанавливаем значение X и Y у WpfImage
            Canvas.SetLeft(WpfImage, position.X);
            Canvas.SetTop(WpfImage, position.Y);

            WpfImage.Width = size.X;
            WpfImage.Height = size.Y;
        }
    }
}