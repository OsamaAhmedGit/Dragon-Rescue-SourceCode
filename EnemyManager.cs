using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileEngine;

namespace DragonRescue
{
    static class EnemyManager
    {
        #region Declarations
        static public List<Knight> knights = new List<Knight>();
        static public List<Paladin> paladins = new List<Paladin>();
        static public List<Bat> bats = new List<Bat>();
        static public List<Spider> spiders = new List<Spider>();
        static public List<Archer> archers = new List<Archer>();
        static public List<Boss> bosses = new List<Boss>();
        #endregion

        #region Initialization
        public static void Initialize(int levelNumber)
        {
            knights.Clear();
            paladins.Clear();
            bats.Clear();
            spiders.Clear();
            archers.Clear();
            bosses.Clear();

            //first level
            if (levelNumber == 1)
            {
                Knight knight1 = new Knight(new Vector2(TileMap.TileWidth * 133, TileMap.TileHeight * 55 + 16), TextureManager.knightRight,
                    TextureManager.knightLeft, TextureManager.knightAttackRight, TextureManager.knightAttackLeft,
                    new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 125, TileMap.TileHeight * 55, 48, 48), 
                    new Rectangle(TileMap.TileWidth * 133, TileMap.TileHeight * 55, 48, 48), 3);

                knights.Add(knight1);

                Paladin paladin1 = new Paladin(new Vector2(TileMap.TileWidth * 90, TileMap.TileHeight * 86 + 16), TextureManager.paladinRight,
                    TextureManager.paladinLeft, TextureManager.paladinAttackRight, TextureManager.paladinAttackLeft,
                    new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 77, TileMap.TileHeight * 86 + 16, 48, 48), 
                    new Rectangle(TileMap.TileWidth * 90, TileMap.TileHeight * 86 + 16, 48, 48), 2);

                Paladin paladin2 = new Paladin(new Vector2(TileMap.TileWidth * 37, TileMap.TileHeight * 45 + 16), TextureManager.paladinRight,
                    TextureManager.paladinLeft, TextureManager.paladinAttackRight, TextureManager.paladinAttackLeft,
                    new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 26, TileMap.TileHeight * 45 + 16, 48, 48),
                    new Rectangle(TileMap.TileWidth * 37, TileMap.TileHeight * 45 + 16, 48, 48), 2);

                paladins.Add(paladin1);
                paladins.Add(paladin2);

                Archer archer1 = new Archer(new Vector2(TileMap.TileWidth * 45, TileMap.TileHeight * 86 + 16), TextureManager.archerWalkRight, TextureManager.archerWalkLeft,
                    TextureManager.archerShootRight, TextureManager.archerShootLeft, new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 30, TileMap.TileHeight * 86 + 16, 48, 48),
                    new Rectangle(TileMap.TileWidth * 45, TileMap.TileHeight * 86 + 16, 48, 48));

                Archer archer2 = new Archer(new Vector2(TileMap.TileWidth * 127, TileMap.TileHeight * 44 + 16), TextureManager.archerWalkRight, TextureManager.archerWalkLeft,
                    TextureManager.archerShootRight, TextureManager.archerShootLeft, new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 117, TileMap.TileHeight * 44 + 16, 48, 48),
                    new Rectangle(TileMap.TileWidth * 127, TileMap.TileHeight * 44 + 16, 48, 48));

                archers.Add(archer1);
                archers.Add(archer2);
            }

            //CAVE
            if (levelNumber == 3)
            {
                Bat bat1 = new Bat(new Vector2(TileMap.TileWidth * 88, TileMap.TileHeight * 75), TextureManager.batLeft,
                    TextureManager.batRight, new Rectangle(0, 0, 32, 32), 3);

                bats.Add(bat1);

                Spider spider1 = new Spider(new Vector2(TileMap.TileWidth * 40, TileMap.TileHeight * 78), TextureManager.spiderOnWeb,
                    new Rectangle(0, 0, 32, 32), 2, 200);

                Spider spider2 = new Spider(new Vector2(TileMap.TileWidth * 63, TileMap.TileHeight * 81), TextureManager.spiderOnWeb,
                    new Rectangle(0, 0, 32, 32), 2, 200);

                Spider spider3 = new Spider(new Vector2(TileMap.TileWidth * 52, TileMap.TileHeight * 61), TextureManager.spiderOnWeb,
                    new Rectangle(0, 0, 32, 32), 2, 140);

                spiders.Add(spider1);
                spiders.Add(spider2);
                spiders.Add(spider3);
            }

            if (levelNumber == 4)
            {
                Boss boss1 = new Boss(new Vector2(TileMap.TileWidth * 115, TileMap.TileHeight * 41), TextureManager.bossWalkLeft, TextureManager.bossWalkRight,
                    TextureManager.bossMeleeLeft, TextureManager.bossMeleeRight, TextureManager.bossRangedLeft, TextureManager.bossRangedRight, new Rectangle(0, 0, 64, 64), 2, 10, new Rectangle(TileMap.TileWidth * 80, TileMap.TileHeight * 41, 64, 64),
                    new Rectangle(TileMap.TileWidth * 115, TileMap.TileHeight * 41, 64, 64));

                bosses.Add(boss1);

                Knight knight3 = new Knight(new Vector2(TileMap.TileWidth * 40, TileMap.TileHeight * 68 + 16), TextureManager.knightRight,
                    TextureManager.knightLeft, TextureManager.knightAttackRight, TextureManager.knightAttackLeft,
                    new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 20, TileMap.TileHeight * 68 + 16, 48, 48), new Rectangle(TileMap.TileWidth * 40, TileMap.TileHeight * 68 + 16, 48, 48), 3);

                knights.Add(knight3);

                Knight knight4 = new Knight(new Vector2(TileMap.TileWidth * 50, TileMap.TileHeight * 84 + 16), TextureManager.knightRight,
                    TextureManager.knightLeft, TextureManager.knightAttackRight, TextureManager.knightAttackLeft,
                    new Rectangle(0, 0, 48, 48), 3, new Rectangle(TileMap.TileWidth * 35, TileMap.TileHeight * 84 + 16, 48, 48), new Rectangle(TileMap.TileWidth * 50, TileMap.TileHeight * 84 + 16, 48, 48), 3);

                knights.Add(knight4);

            }
        }
        #endregion

        #region Update and Draw
        public static void Update(GameTime gameTime)
        {
            foreach (Knight knight in knights)
            {
                knight.Update(gameTime);
            }

            foreach (Paladin paladin in paladins)
            {
                paladin.Update(gameTime);
            }

            foreach (Bat bat in bats)
            {
                bat.Update(gameTime);
            }

            foreach (Spider spider in spiders)
            {
                spider.Update(gameTime);
            }

            foreach (Archer archer in archers)
            {
                archer.Update(gameTime);
            }

            foreach (Boss boss in bosses)
            {
                boss.Update(gameTime);
            }
        }
        static public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Knight knight in knights)
            {
                knight.Draw(spriteBatch);
            }

            foreach (Paladin paladin in paladins)
            {
                paladin.Draw(spriteBatch);
            }

            foreach (Bat bat in bats)
            {
                bat.Draw(spriteBatch);
            }

            foreach (Spider spider in spiders)
            {
                spider.Draw(spriteBatch);
            }

            foreach (Archer archer in archers)
            {
                archer.Draw(spriteBatch);
            }

            foreach (Boss boss in bosses)
            {
                boss.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
