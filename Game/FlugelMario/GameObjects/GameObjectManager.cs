﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.HandleAllCollison;
using SuperMairo.Interfaces;
using SuperMairo.DisplayPanel;
using Microsoft.Xna.Framework;
using SuperMario.Display;

namespace SuperMario.GameObjects
{
    public class GameObjectManager 
    {
        public static List<IGameObject> pipeList;
        public static List<IGameObject> blockList;
        public static List<IGameObject> itemList;
        public static List<IGameObject> enemyList;
        public static List<IGameObject> objectList;

        private MarioObject mario;
        private Game1 game;

        private IDisplayPanel titleDisplayPanel;
        private IDisplayPanel gameOverDisplayPanel;
        private IDisplayPanel marioLifeDisplayPanel;
        private IDisplayPanel headsUpDisplayPanel;

        private const int BufferSize = 32;
        public GameObjectManager(Game1 Game, MarioObject Mario)
        {
            blockList = new List<IGameObject>();
            itemList = new List<IGameObject>();
            enemyList = new List<IGameObject>();
            pipeList = new List<IGameObject>();
            objectList = new List<IGameObject>();
            mario = Mario;
            game = Game;
            gameOverDisplayPanel = new GameOverDisplayPanel(game);
            titleDisplayPanel = new TitleDisplayPanel();
            marioLifeDisplayPanel = new MarioLifeDisplayPanel();
            headsUpDisplayPanel = new HeadsUpDisplayPanel();
        }

        public IDisplayPanel TitlePanel
        {
            get
            {
                return titleDisplayPanel;
            }
        }


        public void HandleCollisions()
        {
            HandleAllCollisions(mario, blockList, enemyList, itemList, pipeList);
        }

        public void Update()
        {
            bool updateHUD = true;

            if (GamePlayable())
            {
                HandleCollisions();
                foreach (IGameObject obj in itemList)
                {
                    obj.Update();
                }
                foreach (IGameObject obj in blockList)
                {
                    obj.Update();
                }
                foreach (IGameObject obj in enemyList)
                {
                    if (IsInView(obj))
                    {
                        obj.Update();
                    }                    
                }
                foreach (IGameObject obj in pipeList)
                {
                    obj.Update();
                }
                foreach (IGameObject obj in objectList)
                {
                    obj.Update();
                }

                mario.Update();

                Camera.Move(mario);
            }

            if (updateHUD)
            {
                titleDisplayPanel.Update();
                gameOverDisplayPanel.Update();
                marioLifeDisplayPanel.Update();
                headsUpDisplayPanel.Update();
            }           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in objectList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in itemList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in blockList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in enemyList)
            {               
                obj.Draw(spriteBatch);
            }
            foreach(IGameObject obj in pipeList)
            {
                obj.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);

            titleDisplayPanel.Draw(spriteBatch);
            gameOverDisplayPanel.Draw(spriteBatch);
            marioLifeDisplayPanel.Draw(spriteBatch);
            headsUpDisplayPanel.Draw(spriteBatch);
        }
        private static bool GamePlayable()
        {
            return Game1.State.Type == GameStates.Playing ||
                Game1.State.Type == GameStates.LevelComplete;
        }

        private static bool IsInView(IGameObject obj)
        {
            return (obj.Location.X >= Camera.CameraX - BufferSize) &&
                (obj.Location.X <= Camera.CameraX + 2 * Camera.CenterOfScreen) &&
                (obj.Location.Y <= 480);
        }






    }   
}
