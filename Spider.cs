using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileEngine;

namespace DragonRescue
{
    public class Spider : Sprite
    {
        #region Declarations
        public Vector2 player;
        private bool top;
        private float top1, bot;
        private int Offset;
        #endregion

        #region Constructor
        public Spider(Vector2 position, Texture2D texture1, Rectangle Frame, int frameCount, int offset)
            : base(position, texture1, Frame, Vector2.Zero)
        {
            for (int x = 1; x < frameCount; x++)
            {
                AddFrame(new Rectangle(Frame.X + (Frame.Width * x), Frame.Y, Frame.Width, Frame.Height));
                AnimateWhenStopped = true;
            }

            Offset = offset;
            top1 = position.Y;
            bot = position.Y + Offset;
        }
        #endregion

        #region Methods
        public void lineOfSite()
        {
            if (WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X < 0 || WorldLocation.X - PlayerManager.currentPlayer.WorldLocation.X > 0)
            {
                if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 150 && top == true && 
                    WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y > -200 && PlayerManager.currentPlayer.WorldLocation.Y > WorldLocation.Y)
                {
                    Velocity = new Vector2(0, 5);
                }

                if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -150 && top == true && 
                    WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y > -200 && PlayerManager.currentPlayer.WorldLocation.Y > WorldLocation.Y)
                {
                    Velocity = new Vector2(0, 5);
                }

                if (WorldLocation.Y == bot)
                {
                    top = false;
                }

                if (top == false && (PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < -150 || PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > 150))
                {
                    Velocity = new Vector2(0, -1);
                }

                if (WorldLocation.Y == top1)
                {
                     top = true;
                }

                if (top == true && (PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < -150 || PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > 150))
                {
                    Velocity = Vector2.Zero;
                }
            }
        }

        public void move()
        {
            if (WorldLocation.Y == bot)
            {
                if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 120)
                {
                    Velocity = new Vector2(2, 0);
                }

                if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -120)
                {
                    Velocity = new Vector2(-2, 0);
                }
            }

            WorldLocation += Velocity;
        }
        #endregion

        #region Update and Draw
        public override void Update(GameTime gameTime)
        {
            move();
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
    

 

