using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FubaDefense
{
    class Waves
    {
        int waveNumber = 0;
        bool isSpawn = true;
        int spawnTime = 0;
        int spawnCount = 0;

        List<Enemy> listEnemies = new List<Enemy>();

        internal List<Enemy> ListEnemies
        {
            get
            {
                return listEnemies;
            }
        }

        public bool IsSpawn
        {
            get
            {
                return isSpawn;
            }

            set
            {
                isSpawn = value;
            }
        }

        public void update(int number, List<Texture2D> enemiesSprites, List<TrajectPoint> path, GameTime gameTime)
        {
            spawnTime += gameTime.ElapsedGameTime.Milliseconds;

            if (spawnTime >= 1500)
            {
                switch (number)
                {
                    case 0:
                        break;
                    case 1:

                        if (spawnCount < 6)
                        {

                            SpawnEnemies(enemiesSprites[1], path);
                            spawnCount++;

                        }
                        else
                        {
                            spawnCount = 0;
                            isSpawn = false;
                        }

                        break;
                }

                spawnTime = 0;

            }
        }

        private void SpawnEnemies(Texture2D type, List<TrajectPoint> path)
        {
            this.listEnemies.Add(new EnemyBat(type, new Point(736, 0), new Vector2(2), path));
        }

    }
}
