using System;
using System.Collections.Generic;
using System.Text;
using GameCore.Managers;
using Newtonsoft.Json;

namespace GameCore.Objects
{
    public abstract class GameObject
    {
        [JsonIgnore]
        public World World { get; set; }
        public string Name { get; set; }
        public bool IsNeedDestroy { get; set; }

        // вызывается каждый кадр, dt - время,
        // прошедшее с прошлого кадра
        public virtual void OnTick(float dt)
        {
        }

        public virtual void OnAttachToWorld()
        {
            
        }

        public virtual void OnDetach()
        {

        }

    }
}
