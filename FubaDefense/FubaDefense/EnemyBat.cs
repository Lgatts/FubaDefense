using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FubaDefense
{
    class EnemyBat : Enemy
    {

        int animationSpeed = 100;
        int currentFrame = 1;
        int frameRow;
        int elapsedGameTime = 0;
        Rectangle frameRectangle = new Rectangle(0,0,32,32);



        public EnemyBat(Texture2D sprite, Point SpawnPoint, Vector2 speed, List<TrajectPoint> path) : base(sprite, SpawnPoint, speed, path)
        {
            drawRectangle.Width = sprite.Width / 2;
            drawRectangle.Height = sprite.Height / 2;
            drawRectangle.X = SpawnPoint.X - drawRectangle.Width / 2;
            drawRectangle.Y = -100;
        }

        public new void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            UpdateFrame(gameTime);
        }


        private void UpdateFrame(GameTime gameTime)
        {

            switch (this.direction)
            {
                case "Down":
                    frameRow = 0;
                    break;
                case "Up":
                    frameRow = 2;
                    break;
                case "Left":
                    frameRow = 3;
                    break;
            }

            elapsedGameTime += gameTime.ElapsedGameTime.Milliseconds;

            if (elapsedGameTime >= animationSpeed)
            {
                elapsedGameTime = 0;

                currentFrame++;
                if (currentFrame == 4)
                {
                    currentFrame = 1;
                }

                SetAnimationFrame();

            }
        }

        private void SetAnimationFrame()
        {
            // calculate X and Y based on frame number
            frameRectangle.X = (currentFrame) * 32;
            frameRectangle.Y = (frameRow) * 32;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, drawRectangle, frameRectangle, Color.White);
        }

    }
}
