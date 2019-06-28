#pragma warning disable CS0618
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Peacekeeper
{
    class TerrainGenerator
    {
        Texture2D turf;
        int[] randomStorage = new int[32 * 32];
        int[] prev_randomStorage = new int[32 * 32];
        Color[] textureColor = new Color[32 * 32];
        int range = 3;
        Random random = new Random();
        public TerrainGenerator(Texture2D turf)
        {
            this.turf = turf;
        }
        public void GenerateRandomness()
        {
            for(int i = 0; i < randomStorage.Length; i++)
            {
                if(prev_randomStorage[i] != 0)
                    randomStorage[i] = random.Next(prev_randomStorage[i] - range, prev_randomStorage[i] + range);
                else
                    randomStorage[i] = random.Next(-range, range);
                try
                {
                    prev_randomStorage[i] = randomStorage[i--];
                }
                catch(Exception)
                {
                    prev_randomStorage[i] = 0;
                }
            }
        }
        public Texture2D MakeTexture()
        {
            for(int i = 0; i < textureColor.Length; i++)
            {
                textureColor[i] = new Color(randomStorage[i], randomStorage[i], randomStorage[i]);
                turf.SetData(textureColor);
            }
            return turf;
        }
    }
    
}
