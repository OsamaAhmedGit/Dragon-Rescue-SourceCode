using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TileEngine;

namespace DragonRescue
{
    public class Bat : Sprite
    {
        #region Constructor
        public Bat(Vector2 position, Texture2D texture1, Texture2D texture2, Rectangle Frame, int frameCount)
            : base(position, texture1, texture2, Frame, Vector2.Zero)
        {
            for (int x = 1; x < frameCount; x++)
            {
                AddFrame(new Rectangle(Frame.X + (Frame.Width * x), Frame.Y, Frame.Width, Frame.Height));
                AnimateWhenStopped = true;
            }
        }
        #endregion

        #region Methods
        public void lineOfSite()
        {

            if (WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X < 0 || WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X > 0)
            {
                if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 200)
                {
                    Velocity = new Vector2(3, 1);
                    CurrentTexture = Texture2;
                }

                if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -200)
                {
                    Velocity = new Vector2(-3, 1);
                    CurrentTexture = Texture1;
                }

                if (WorldLocation.Y == 790)
                {
                    if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 200)
                    {
                        Velocity = new Vector2(3, 0);
                        CurrentTexture = Texture2;
                    }

                    if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -200)
                    {
                        Velocity = new Vector2(-3, 0);
                        CurrentTexture = Texture1;
                    }
                }

                if (PlayerManager.currentPlayer.WorldLocation.Y < WorldLocation.Y)
                {
                    if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X)
                    {
                        Velocity = new Vector2(-3, -1);
                        CurrentTexture = Texture1;
                    }

                    if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X)
                    {
                        Velocity = new Vector2(3, -1);
                        CurrentTexture = Texture2;
                    }
                }

                if (PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > 200)
                {
                    Velocity = Vector2.Zero;
                }

                if (PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < -200)
                {
                    Velocity = Vector2.Zero;
                }
            }

            WorldLocation += Velocity;

            collisionRectangle = new Rectangle((int)WorldLocation.X, (int)WorldLocation.Y, 32, 32);
        }
        #endregion

        #region Update and Draw
        public override void Update(GameTime gameTime)
        {
            lineOfSite();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
