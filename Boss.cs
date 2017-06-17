using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileEngine;

namespace DragonRescue
{
    public class Boss : Sprite
    {
        #region Declarations
        public int HP;
        private Rectangle Collision1;
        private Rectangle Collision2;
        private bool left = false;
        #endregion

        #region Constructor
        public Boss(Vector2 position, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4, Texture2D texture5, Texture2D texture6, Rectangle Frame, int frameCount, int hp, Rectangle collision1, Rectangle collision2)
            : base(position, texture1, texture2, texture3, texture4, texture5, texture6, Frame, Vector2.Zero)
        {
            for (int x = 1; x < frameCount; x++)
            {
                AddFrame(new Rectangle(Frame.X + (Frame.Width * x), Frame.Y, Frame.Width, Frame.Height));
                AnimateWhenStopped = false;
            }

            HP = hp;
            Collision1 = collision1;
            Collision2 = collision2;
        }
        #endregion

        #region Methods
        public void LineOfSite()
        {

            if (WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X < 0 || WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X > 0)
            {
                if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -300 && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 0)
                {
                    CurrentTexture = Texture5;
                    FrameTime = 0.25f;
                    LightningManager.AddShot(WorldLocation, new Vector2(-1,0));
                }

                else if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 300 && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > 0)
                {
                    CurrentTexture = Texture6;
                    FrameTime = 0.25f;
                    LightningManager.AddShot(WorldLocation, new Vector2(1,0));
                }                
            }
        }

        public void move()
        {
            if (left == false)
            {
                Velocity = new Vector2(-2, 0);
            }

            if (IsBoxColliding(Collision1))
            {
                Velocity = -Velocity;
                left = true;
                CurrentTexture = Texture2;
            }

            if (IsBoxColliding(Collision2))
            {
                left = false;
                CurrentTexture = Texture1;
            }

            WorldLocation += Velocity;
        }
        
        public void melee()
        {
            if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -100)
            {
                Velocity = new Vector2(-2, 0);
                CurrentTexture = Texture3;
            }

            if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 100)
            {
                Velocity = new Vector2(2, 0);
                CurrentTexture = Texture4;
            }

        }
        #endregion

        #region Update and Draw
        public override void Update(GameTime gameTime)
        {
            LineOfSite();
            melee();
            move();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
