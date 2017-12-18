using System.Numerics;

namespace GameCore.Models
{
    public class PhysicslSphere: PhysicModel
    {
        public float Radius { get; set; }

        public override void Intersection(PhysicModel modelB)
        {
            //base.Intersection(modelB);
            
            var delta = (MapObject.Position - modelB.MapObject.Position).Length();
            var radSum = Radius;

            if (modelB is PhysicslSphere sphere)
            {
                radSum += sphere.Radius;
            }
            //OnINtersection?.

            if (delta >= radSum)
                return;

            CallOnIntersection(modelB);

            //Console.WriteLine($"{modelA} coll {modelB}");

            if (IsCollision && modelB.IsCollision)
            {
                // отодвигание
                var firstModel = IsStatic ? modelB : this;
                var secondModel = firstModel == this ? modelB : this;

                var deltaVec = firstModel.MapObject.Position - secondModel.MapObject.Position;
                if (!deltaVec.Equals(Vector2.Zero))
                {
                    firstModel.MapObject.Position -= deltaVec / deltaVec.Length() * (delta - radSum);
                }
            }
            
        }
    }
}