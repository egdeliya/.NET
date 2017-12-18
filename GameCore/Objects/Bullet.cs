using System.Numerics;

namespace GameCore.Objects
{
    public class Bullet: MapObject
    {
        public Vector2 Direction { get; set; }
        public float Speed{ get; set; }
        public float LifeTime { get; set; }
        public MapObject Owner { get; set; }

        public override void OnAttachToWorld()
        {
            base.OnAttachToWorld();
            if (RenderPrimitive != null)
            {
                RenderPrimitive.ImageName = "objects\\bullet";
                RenderPrimitive.Size = new Vector2(32, 32);
            }

            PhysicModel.IsCollision = false;
            PhysicModel.OnIntersection += PhysicsMOdel_OnIntersection;
        }

        private void PhysicsMOdel_OnIntersection(Models.PhysicModel a, Models.PhysicModel b)
        {
            if (b != Owner.PhysicModel)
            {
                b.MapObject.IsNeedDestroy = true;
                IsNeedDestroy = true;
            };
        }

        public override void OnTick(float dt)
        {
            base.OnTick(dt);

            LifeTime -= dt;
            if (LifeTime <= 0)
            {
                IsNeedDestroy = true;
                return;
            }

            Position += Direction * Speed * dt;
        }
    }
}