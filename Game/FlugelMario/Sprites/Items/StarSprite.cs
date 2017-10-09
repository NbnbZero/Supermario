﻿using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Items
{
    class StarSprite : Sprite
    {
        public StarSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = ItemSpriteFactory.Instance.StarWith;
            Height = ItemSpriteFactory.Instance.StarHeight;

            TextureX = (int)ItemSpriteFactory.Instance.StarAnimation1.X;
            TextureY = (int)ItemSpriteFactory.Instance.StarAnimation1.Y;

            TotalFrames = ItemSpriteFactory.Instance.StarAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}