using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using GameCore.Models;
using GameCore.Render;
using Newtonsoft.Json;

namespace GameCore.Objects
{
    public class MapObject: GameObject
    {
        private Vector2 _position;
        private Vector2 _size;
        private string _imageName;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                if (RenderPrimitive != null)
                {
                    RenderPrimitive.Position= value;
                }

                _position = value;

            }
        }

        public Vector2 Size
        {
            get { return _size; }
            set
            {
                if (RenderPrimitive != null)
                {
                    RenderPrimitive.Size = value;
                }

                _size = value;
            }
        }

        public string ImageName
        {
            get { return _imageName; }
            set
            {
                if (RenderPrimitive != null)
                    RenderPrimitive.ImageName = value;

                _imageName = value;
            }
        }

        [JsonIgnore]
        public IRenderPrimitive RenderPrimitive { get; set; }
        [JsonIgnore]
        public PhysicModel PhysicModel { get; set; }

        public override void OnAttachToWorld()
        {
            if (World.RenderManager != null)
            {
                RenderPrimitive = World.RenderManager.CreatePrimitive();
                if (RenderPrimitive != null)
                {
                    RenderPrimitive.Size = Size;
                    RenderPrimitive.Position = Position;
                    RenderPrimitive.ImageName = ImageName;
                }
            }

            PhysicModel = new PhysicslSphere
            {
                IsStatic = true,
                //Position = Position,
                Radius = Size.Length() / (float)2.5,
                MapObject = this
            };
            

            World.PhysicsManager.Models.Add(PhysicModel);
         }

        public override void OnDetach()
        {
            //if (World != null)
            //{
            World.PhysicsManager.Models.Remove(PhysicModel);

            if (World.RenderManager != null && RenderPrimitive != null)
            {
                World.RenderManager.DestroyPrimitive(RenderPrimitive);
            }

            base.OnDetach();
            //}
            
        }
    }
}
