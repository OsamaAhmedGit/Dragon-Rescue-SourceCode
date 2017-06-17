using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileEngine;

namespace DragonRescue
{
    public class ArrowManager
    {
        #region Declarations
        static public List<Sprite> Arrow = new List<Sprite>();
        static private float shotTimer = 0f;
        static private float shotMinTimer = 0.9f;
        #endregion

        #region Properties
        static public float FireDelay
        {
            get
            {
                return shotMinTimer;
            }
        }
        static public bool CanFire
        {
            get
            {
                return (shotTimer >= FireDelay);
            }
        }
        #endregion

        #region Methods
        public static void AddShot(Vector2 position, Vector2 Velocity)
        {
            if (CanFire)
            {
                if (Velocity.X < 0)
                {
                    Sprite arrow1 = new Sprite(position, TextureManager.arrowLeft, new Rectangle(0, 0, 32, 32), new Vector2(-5, 0));
                    Arrow.Add(arrow1);
                    SoundManager.arrow.Play();
                }

                if (Velocity.X > 0)
                {
                    Sprite arrow1 = new Sprite(position, TextureManager.arrowRight, new Rectangle(0, 0, 32, 32), new Vector2(5, 0));
                    Arrow.Add(arrow1);
                    SoundManager.arrow.Play();
                }
                shotTimer = 0;
            }
        }
        public static void CheckLightningCollision()
        {
            foreach (Sprite sprite in Arrow)
            {
                if (!TileMap.HasRoomForRectangle(sprite.WorldRectangle))
                {
                    sprite.Expired = true;
                }

                for (int x = MovingPlatformManager.movingPlatforms.Count - 1; x >= 0; x--)
                {
                    if (sprite.IsBoxColliding(MovingPlatformManager.movingPlatforms[x].WorldRectangle))
                    {
                        sprite.Expired = true;
                    }
                }

                if (sprite.WorldLocation.X < 0 || sprite.WorldLocation.X > Camera.WorldRectangle.Width)
                {
                    sprite.Expired = true;
                }

                if (sprite.IsBoxColliding(PlayerManager.currentPlayer.WorldRectangle))
                {
                    PlayerManager.currentPlayer.HealthPoints--;
                    sprite.Expired = true;
                }





            }
        }
        #endregion

        #region Update and Draw
        static public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            shotTimer += elapsed;
            for (int x = Arrow.Count - 1; x >= 0; x--)
            {
                if (Arrow[x].Expired)
                {
                    Arrow.RemoveAt(x);
                }
            }
            CheckLightningCollision();
            foreach (Sprite sprite in Arrow)
            {
                sprite.WorldLocation += sprite.Velocity;
            }
        }
        static public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in Arrow)
            {
                sprite.Draw(spriteBatch);
            }
        }
        #endregion
    }
}

