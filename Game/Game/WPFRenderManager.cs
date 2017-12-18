using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Windows.Controls;
using GameCore.Render;

namespace Game
{
    public class WPFRenderManager : IRenderManager
    {
        public Camera ActiveCamera { get; set; }

        public Canvas WpfCanvas { get; set; }

        private readonly List<WPFRenderPrimitive> primitives = new List<WPFRenderPrimitive>();

        public WPFRenderManager(Canvas canvas)
        {
            WpfCanvas = canvas;
            ActiveCamera = new Camera();
        }

        public IRenderPrimitive CreatePrimitive()
        {

            var primitive = new WPFRenderPrimitive();
            WpfCanvas.Children.Add(primitive.WpfImage);
            primitives.Add(primitive);

            return primitive;
        }

        public void DestroyPrimitive(IRenderPrimitive primitive)
        {
            // проверяет, что primitive типа WPFRenderPrimitive
            // и кастует сразу же к нему
            if (primitive is WPFRenderPrimitive wpfRenderPrimitive)
            {
                WpfCanvas.Children.Remove(wpfRenderPrimitive.WpfImage);
                primitives.Remove(wpfRenderPrimitive);
            }
        }

        public void BeginRender()
        {
            if (ActiveCamera == null)
                return;

            WpfCanvas.Dispatcher.BeginInvoke((ThreadStart) delegate
            {
                // есть высота, которую мы задали, а есть которая реально получилась
                // мы не можем задань Hight и Width, можем только получить, для этого нужно использовать
                // ActualHieght и ActualWidth
                ActiveCamera.Resolution = new Vector2((float)WpfCanvas.ActualWidth, (float)WpfCanvas.ActualHeight);

                foreach (var primitive in primitives)
                {
                    primitive.Render(ActiveCamera);
                }
            });
            
        }

        public void RunInUIThread(Action action)
        {
            WpfCanvas.Dispatcher.BeginInvoke((ThreadStart) action.Invoke);
        }
    }
}