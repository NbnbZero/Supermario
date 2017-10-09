﻿using SuperMario.Interfaces;
using SuperMario.Sprites.Goomba;
using SuperMario.Sprites.Koopa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.SpriteFactories
{
    public class EnemySpriteFactory
    {
        public int GoombaSpriteSheetColumn { get; } = 3;
        public int GoombaSpriteSheetRows { get; } = 1;
        public int GoombaWalkTotalFrame { get; } = 2;
        public int KoopaSpriteSheetColumn { get; } = 5;
        public int KoopaSpriteSheetRows { get; } = 1;
        public int KoopaWalkTotalFrame { get; } = 2;

        private Texture2D enemyGoombaSpriteSheet;
        private Texture2D enemyKoopaSpriteSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            if (content != null)
            {
                enemyGoombaSpriteSheet = content.Load<Texture2D>("GoombaSheet");
                enemyKoopaSpriteSheet = content.Load<Texture2D>("TurtleSheet1");
            }
        }

        public int GoombaWidth
        {
            get
            {
                return enemyGoombaSpriteSheet.Width / GoombaSpriteSheetColumn;
            }
        }

        public int GoombaHeight
        {
            get
            {
                return enemyGoombaSpriteSheet.Height / GoombaSpriteSheetRows;
            }
        }

        public int KoopaWidth
        {
            get
            {
                return enemyKoopaSpriteSheet.Width / KoopaSpriteSheetColumn;
            }
        }

        public int KoopaHeight
        {
            get
            {
                return enemyKoopaSpriteSheet.Height / KoopaSpriteSheetRows;
            }
        }

        // TODO: Make this go bye bye
        public Sprite CreateGoombaSprite()
        {
            return new GoombaSprite(enemyGoombaSpriteSheet) { Color = Color.Red };
        }

        public Sprite CreateGoombaSprite(Vector2 location)
        {
            return new GoombaSprite(enemyGoombaSpriteSheet, location) { Color = Color.Red };
        }

        public Sprite CreateKoopaSprite(Vector2 location)
        {
            return new KoopaSprite(enemyKoopaSpriteSheet, location) { Color = Color.Red };
        }

        public Sprite CreateDeadGoombaSprite(Vector2 location)
        {
            return new DeadGoombaSprite(enemyGoombaSpriteSheet, location) { Color = Color.Red };
        }

        public Sprite CreateDeadKoopaSprite(Vector2 location)
        {
            return new DeadKoopaSprite(enemyKoopaSpriteSheet, location) { Color = Color.Red };
        }
        public Vector2 GoombaWalkCord { get; } = new Vector2(0, 0);
        public Vector2 GoombaDeadCord { get; } = new Vector2(2, 0);
        public Vector2 KoopaWalkCord { get; } = new Vector2(0, 0);
        public Vector2 KoopaDeadCord { get; } = new Vector2(2, 0);
    }
}
