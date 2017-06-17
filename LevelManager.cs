using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileEngine;

namespace DragonRescue
{
    static class LevelManager
    {
        #region Declarations
        private static ContentManager Content;
        private static int currentLevel;
        private static Vector2 respawnLocation;
        public static bool level1Completed = false;
        public static bool level2Part1Completed = false;
        public static bool level2Part2Completed = false;
        public static bool level3Part1Completed = false;
        public static bool level3Part2Completed = false;
        public static bool level4Completed = false;

        #endregion

        #region Properties
        public static int CurrentLevel
        {
            get { return currentLevel; }
        }

        public static Vector2 RespawnLocation
        {
            get { return respawnLocation; }
            set { respawnLocation = value; }
        }
        #endregion

        #region Initialization
        public static void Initialize(ContentManager content)
        {
            Content = content;
        }
        #endregion

        #region Public Methods
        public static void LoadLevel(int levelNumber)
        {
            TileMap.LoadMap((System.IO.FileStream)TitleContainer.OpenStream(@"Content\Maps\MAP" + levelNumber.ToString().PadLeft(2, '0') + ".MAP"));

            for (int x = 0; x < TileMap.MapWidth; x++)
            {
                for (int y = 0; y < TileMap.MapHeight; y++)
                {
                    if (TileMap.CellCodeValue(x, y) == "START")
                    {
                        if (PlayerManager.Fyro.Fruits < 10)
                        {
                            PlayerManager.Fyro.WorldLocation = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                        }
                        else
                        {
                            PlayerManager.Fyro.WorldLocation = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight - 16);
                        }
                        
                        if (levelNumber == 1 && !PlayerManager.Thomas.saved)
                        {
                            PlayerManager.Thomas.WorldLocation = new Vector2(115 * TileMap.TileWidth, 33 * TileMap.TileHeight);
                        }
                        else
                        {
                            PlayerManager.Thomas.WorldLocation = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                        }
                        Camera.Position = PlayerManager.Fyro.WorldLocation - new Vector2(Camera.ViewPortWidth / 2, Camera.ViewPortHeight / 2);
                    }
                }
            }

            currentLevel = levelNumber;
        }
        public static void ReloadLevel()
        {
            Vector2 saveRespawn = respawnLocation;
            LoadLevel(currentLevel);
            respawnLocation = saveRespawn;
            PlayerManager.Fyro.WorldLocation = respawnLocation;
        }
        #endregion
    }
}
