﻿using SuperMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsEnemies
{
    class GoombaKoopaCollisionLeft : ICollisionCommand
    {
        public GoombaKoopaCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba goomba = (Goomba)gameObject1;
            Koopa koopa = (Koopa)gameObject2;
            goomba.Location = new Vector2(goomba.Location.X - 1, goomba.Location.Y);

            if (!goomba.Alive)
                return;
            if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                koopa.Velocity.X != 0)
            {
                goomba.Terminate("LEFT");
                return;
            }
            goomba.ChangeDirection();
            koopa.ChangeDirection();
        }
    }
}
