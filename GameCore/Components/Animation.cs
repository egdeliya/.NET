using System;

namespace GameCore.Render
{
    // двигает картинку раз в период
    public class Animation
    {
        public int currentIndex;

        // время, которое прошло
        private float time;

        public string PathMask { get; set; }

        // количество текстурок для примитива
        public int ImageCount { get; set; }

        public float Speed { get; set; }

        public void OnTick(float dt, IRenderPrimitive SourcePrimitive)
        {
            time += dt;

            if (time >= Speed)
            {
                SetImageByIndex((currentIndex + 1) % ImageCount, SourcePrimitive);
                time -= Speed;
            }
        }

        public void SetImageByIndex(int index, IRenderPrimitive SourcePrimitive)
        {
            currentIndex = index;
            SourcePrimitive.ImageName = string.Format(PathMask, index + 1);
        }


    }
}