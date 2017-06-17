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
    public class Knight : Sprite
    {
        #region Declarations
        private bool left = false;
        private Rectangle Collision1;
        private Rectangle Collision2;
        public int HP;
        #endregion

        #region Constructor
        public Knight(Vector2 position, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4, Rectangle Frame, int frameCount, Rectangle collision1, Rectangle collision2, int hp)
            : base(position, texture1, texture2, texture3, texture4, Frame, Vector2.Zero)
        {
            for (int x = 1; x < frameCount; x++)
            {
                AddFrame(new Rectangle(Frame.X + (Frame.Width * x), Frame.Y, Frame.Width, Frame.Height));
                AnimateWhenStopped = false;
            }

            Collision1 = collision1;
            Collision2 = collision2;
            CurrentTexture = Texture2;
            HP = hp;
        }
        #endregion

        #region Methods
        public void move()
        {
            if (left == false)
            {
                CurrentTexture = Texture2;
            }

            if (IsBoxColliding(Collision1))
            {
                Velocity = new Vector2(1, 0);
                left = true;
                CurrentTexture = Texture1;
            }

            if (IsBoxColliding(Collision2))
            {
                left = false;
                Velocity = new Vector2(-1, 0);
            }

            WorldLocation += Velocity;
        }


        public void LineOfSite()
        {

            if (PlayerManager.currentPlayer.WorldLocation.X < WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > -150 &&
                PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 0 && WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y < 200 &&
                WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y > -200)
            {
                CurrentTexture = Texture4;
                Velocity = new Vector2(-1, 0);
            }

            if (PlayerManager.currentPlayer.WorldLocation.X > WorldLocation.X && PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X < 150 &&
                PlayerManager.currentPlayer.WorldLocation.X - WorldLocation.X > 0 && WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y < 200 &&
                WorldLocation.Y - PlayerManager.currentPlayer.WorldLocation.Y > -200)
            {
                CurrentTexture = Texture3;
                Velocity = new Vector2(1, 0);
            }
        }
        #endregion

        #region Update and Draw
        public override void Update(GameTime gameTime)
        {
            move();
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
