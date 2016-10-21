using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FubaDefense
{
    class Enemy
    {
        #region Declarate Variables
        protected Texture2D sprite;
        protected int Health;
        protected Vector2 speed;
        protected Rectangle drawRectangle;
        protected List<TrajectPoint> path;
        protected String direction = "Down";
        #endregion

        #region Constructor
        public Enemy(Texture2D sprite, Point SpawnPoint, Vector2 speed, List<TrajectPoint> path)
        {
            this.sprite = sprite;
            this.drawRectangle = new Rectangle((SpawnPoint.X - sprite.Width/2), -20, sprite.Width, sprite.Height);            
            this.speed = speed;
            this.path = path;
        }
        #endregion

        public void Update(GameTime gameTime)
        {

            foreach (TrajectPoint pathPoint in path)
            {
                if (drawRectangle.Center == pathPoint.Point)
                {
                    this.direction = pathPoint.Direction;
                }
            }

            switch (direction)
            {
                case "Down":
                    drawRectangle.X += 0;
                    drawRectangle.Y += (int)speed.Y;
                    break;
                case "Up":
                    drawRectangle.X += 0;
                    drawRectangle.Y -= (int)speed.Y;
                    break;
                case "Left":
                    drawRectangle.X -= (int)speed.X;
                    drawRectangle.Y += 0;
                    break;
                case "Right":
                    drawRectangle.X += (int)speed.X;
                    drawRectangle.Y += 0; 
                    break;
            }




        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite,drawRectangle,Color.White);
        }


    }
}
