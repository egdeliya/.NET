using System;
using System.Numerics;
using GameCore.Objects;

namespace GameCore.Models
{
    public abstract class PhysicModel
    {
        //public Vector2 Position { get; set; }
        
        // если статический, то нельзя двигать
        public bool IsStatic { get; set; }
        // ссылка на объект, которым управляем
        public MapObject MapObject { get; set; }

        public bool IsCollision { get; set; } = true;

        public event Action<PhysicModel, PhysicModel> OnIntersection;

        public virtual void Intersection(PhysicModel modelB)
        {
            
        }

        protected virtual void CallOnIntersection(PhysicModel arg1)
        {
            if (OnIntersection != null)
                OnIntersection.Invoke(this, arg1);
        }
    }
}