﻿using SuperMario.States.MarioStates;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using SuperMario.Enums;

namespace SuperMario.States.MarioStates
{
    public class DeadMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public DeadMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            this.MarioPosture = Posture.Dead;
            this.MarioDirection = Direction.Dead;
            this.MarioShape = Shape.Dead;
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }
        public override void Update()
        {
            if (MarioAttributes.MarioLife[0] == 0)
            {
                //...
            }
            else
            {
                //...
            }
        }
    }
}
