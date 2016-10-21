using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FubaDefense
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Textures
        Texture2D map;
        List<Texture2D> enemiesSprites;

        //Lists Objects
        List<Enemy> listEnemies;
        List<TrajectPoint> map1Path;
        Waves waves;

        //object controls
        bool waveActive = true;
        private int elapsedSpawnTime = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            enemiesSprites = new List<Texture2D>();

            map1Path = new List<TrajectPoint>{
            new TrajectPoint(new Point(736, 480), "Left"),
            new TrajectPoint(new Point(512, 480), "Up"),
            new TrajectPoint(new Point(512, 160), "Left"),
            new TrajectPoint(new Point(64, 160), "Down")
            };

            waves = new Waves();

            base.Initialize();



        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = Content.Load<Texture2D>(@"graphics\Teste");
            enemiesSprites.Add(Content.Load<Texture2D>(@"graphics\teddybear"));
            enemiesSprites.Add(Content.Load<Texture2D>(@"graphics\bat"));



        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (waves.IsSpawn)
            {
                waves.update(1, enemiesSprites, map1Path,gameTime);
                listEnemies = waves.ListEnemies;    
            }

            foreach (EnemyBat enemy in listEnemies)
            {
                enemy.Update(gameTime);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(map, new Rectangle(0, 0, map.Width, map.Height), Color.White);


            foreach (EnemyBat enemy in listEnemies)
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
