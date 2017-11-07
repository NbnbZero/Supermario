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
    class KoopaGoombaCollisionLeft : ICollisionCommand
    {
        public KoopaGoombaCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa koopa = (Koopa)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            Goomba goomba = (Goomba)gameObject2;

            if (!goomba.Alive)
                return;

            if (koopa.State.GetType() == typeof(KoopaDeadState) && 
                koopa.Velocity.X !=0)
            {
                goomba.Terminate("LEFT");
                return;
            }

            koopa.Location = new Vector2(koopa.Location.X - 1, koopa.Location.Y);
            koopa.ChangeDirection();
            goomba.ChangeDirection();
        }
    }
}
