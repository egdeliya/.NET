using System;
using System.Collections.Generic;
using System.Numerics;
using GameCore.Models;
using GameCore.Render;

namespace GameCore.Objects
{
    public class Player: Character
    {
        public float Speed { get; set; } = 150;
        private Vector2 lastDir = new Vector2(1, 0);

        // анимации для игрока
        public Dictionary<string, Animation> Animations;

        public override void OnTick(float dt)
        {
            Vector2 direction = new Vector2();
            var speed = Speed;


            if (World.InputManager.IsKeyDown(Key.Space))
            {
                var bullet = new Bullet
                {
                    Position = Position + new Vector2(40, -30),
                    Direction = lastDir,
                    LifeTime = 1.5f,
                    Owner = this,
                    Speed = 500
                };
                
                World.AddObject(bullet);
            }

            if (World.InputManager.IsKeyDown(Key.W))
            {
                direction += new Vector2(0, -1);
            }

            if (World.InputManager.IsKeyDown(Key.S))
            {
                direction += new Vector2(0, 1);
            }

            if (World.InputManager.IsKeyDown(Key.A))
            {
                direction += new Vector2(-1, 0);
            }

            if (World.InputManager.IsKeyDown(Key.D))
            {
                direction += new Vector2(1, 0);
            }


            if (World.InputManager.IsKeyDown(Key.LeftShift))
            {
                speed *= 1.5f;
            }

            if (direction != Vector2.Zero)
            {
                direction /= direction.Length();

                lastDir = direction;
            }
               

            Velocity = direction * speed;

            base.OnTick(dt);
            
            if (World.RenderManager != null)
                World.RenderManager.ActiveCamera.Position = new Vector3(Position, 0);

        }
    }
}