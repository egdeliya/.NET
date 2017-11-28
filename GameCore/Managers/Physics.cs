using System;
using System.Collections.Generic;
using GameCore.Models;

namespace GameCore.Managers
{
    // физика, чтобы герой например не мог ходить через курст
    public class Physics
    {
        public List<PhysicModel> Models { get; set; }

        public Physics()
        {
            Models = new List<PhysicModel>();
        }

        // выполняет симуляию за один кадр
        public void OnTick(float dt)
        {
            foreach (var modelA in Models)
            {
                foreach (var modelB in Models)
                {
                    if (modelA == modelB)
                    {
                        continue;
                    }
                    if (modelA.IsStatic && modelB.IsStatic)
                    {
                        return;
                    }
                    modelA.Intersection(modelB);
                }
            }
        }
    }
}