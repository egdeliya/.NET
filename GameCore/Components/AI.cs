using System;
using System.Numerics;
using System.Security.Authentication.ExtendedProtection;
using GameCore.Objects;

namespace GameCore.Render
{
    // интеллект нашей игры
    public class AI
    {
        private Character _character;
        private AIState state;
        private float time;

        public enum AIState
        {
            Default,
            Wait
        }

        public AI(Character character)
        {
            _character = character;
            state = AIState.Default;
        }


        public void OnTick(float dt)
        {
//            if (_character.World)
            if (state == AIState.Default)
            {
                time += dt;

                var dir = new Vector2((float)Math.Sin(time), (float)Math.Cos(time));

                _character.Velocity = dir * _character.Speed;
            }
            
        }
    }
}