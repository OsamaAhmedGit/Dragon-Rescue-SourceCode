using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileEngine;

namespace DragonRescue
{
    public class Archer : Sprite
    {
        #region Declarations
        private bool left = false;
        private Rectangle Collision1;
        private Rectangle Collision2;
        #endregion

        #region Constructor
        public Archer(Vector2 position, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4, Rectangle Frame, int frameCount, Rectangle collision1, Rectangle collision2)
            : base(position, texture1, texture2, texture3, texture4, Frame, Vector2.Zero)
        {
            for (int x = 1; x < frameCount; x++)
            {
                AddFrame(new Rectangle(Frame.X + (Frame.Width * x), Frame.Y, Frame.Width, Frame.Height));
                AnimateWhenStopped = true;
            }

            Collision1 = collision1;
            Collision2 = collision2;
        }
        #endregion

        #region Methods
        public void move()
        {
            if (left == false)
            {
                Velocity = new Vector2(-1, 0);
                CurrentTexture = Texture2;
            }

            else if (left == true)
            {
                Velocity = new Vector2(1, 0);
                CurrentTexture = Texture1;
            }

            if (IsBoxColliding(Collision1))
            {
                left = true;
            }

            if (IsBoxColliding(Collision2))
            {
                left = false;
            }

            WorldLocation += Velocity;
        }

        public void LineOfSite()
        {

            if (WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X < 0 || WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X > 0)
            {
                if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -300 &&
                    WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y < 200 && WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y > -200)
                {
                     CurrentTexture = Texture4;
                     FrameTime = 0.30f;
                     Velocity = Vector2.Zero;
                     ArrowManager.AddShot(new Vector2(WorldLocation.X, WorldLocation.Y + 9), new Vector2(-5, 0));
                }

                if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 300 && 
                    WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y < 200 && WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y > -200)
                {
                     CurrentTexture = Texture3;
                     FrameTime = 0.30f;
                     Velocity = Vector2.Zero;
                     ArrowManager.AddShot(new Vector2(WorldLocation.X, WorldLocation.Y + 9), new Vector2(5, 0));
                }

                if(PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < -300 || 
                    PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > 300 ||
                    PlayerManager.currentPlayer.WorldLocation.Y < WorldLocation.Y && PlayerManager.currentPlayer.WorldLocation.Y - WorldLocation.Y < -200 ||
                    PlayerManager.currentPlayer.WorldLocation.Y > WorldLocation.Y && PlayerManager.currentPlayer.WorldLocation.Y - WorldLocation.Y > 200)
                {
                    FrameTime = 0.1f;
                    move();
                }
            }

            
           
          }
         #endregion

        #region Update and Draw
        public override void Update(GameTime gameTime)
        {
            LineOfSite();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        #endregion
    }
}
