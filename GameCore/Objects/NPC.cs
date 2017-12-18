using System;
using System.Numerics;
using GameCore.Render;

namespace GameCore.Objects
{
    public class NPC: Character
    {
        //private float time;
        public AI Intellect { get; set; }

        //public NPC()
        //{
            
        //}

        public override void OnAttachToWorld()
        {
            base.OnAttachToWorld();
            Intellect = new AI(this);

        }

        public override void OnTick(float dt)
        {
            Intellect.OnTick(dt);
            base.OnTick(dt);
        }
    }
}