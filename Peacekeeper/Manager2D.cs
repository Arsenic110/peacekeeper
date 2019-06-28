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
    class Manager2D
    { 
        SpriteBatch UI;
        GraphicsDevice graphicsDevice;
        public Manager2D(SpriteBatch UI, GraphicsDevice graphicsDevice)
        {
            this.UI = UI;
            this.graphicsDevice = graphicsDevice;
        }
        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="position">The drawing location on the screen or null if destinationRectangle.</param>
        /// <param name="destinationRectangle">The drawing bounds on screen or null if position.</param>
        /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full
        ///     texture.</param>
        /// <param name="origin">An optional center of rotation. Uses Microsoft.Xna.Framework.Vector2.Zero if
        ///     null.</param>
        /// <param name="rotation">An optional rotation of this sprite. 0 by default.</param>
        /// <param name="scale">An optional scale vector. Uses Microsoft.Xna.Framework.Vector2.One if null.</param>
        /// <param name="color">An optional color mask. Uses Microsoft.Xna.Framework.Color.White if null.</param>
        /// <param name="effects">The optional drawing modificators. Microsoft.Xna.Framework.Graphics.SpriteEffects.None
        ///     by default.</param>
        /// <param name="layerDepth">An optional depth of the layer of this sprite. 0 by default.</param>
        public void Draw(Texture2D texture, Vector2? position = null, Rectangle? destinationRectangle = null, Rectangle? sourceRectangle = null, Vector2? origin = null, float rotation = 0, Vector2? scale = null, Color? color = null, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
        {
            UI.Draw(texture, position, destinationRectangle, sourceRectangle, origin, rotation, scale, color, effects, layerDepth);
        }
        public void DrawWindow(object[] i)
        {
            Draw((Texture2D)i[0], (Vector2)i[1], null, null , (Vector2)i[4], (float)i[5], (Vector2)i[6], (Color)i[7], (SpriteEffects)i[8], (float)i[9]);
            Draw((Texture2D)i[10], (Vector2)i[11], null, null, (Vector2)i[14], (float)i[15], (Vector2)i[16], (Color)i[17], (SpriteEffects)i[18], (float)i[19]);
            Draw((Texture2D)i[20], (Vector2)i[21], null, null, (Vector2)i[24], (float)i[25], (Vector2)i[26], (Color)i[27], (SpriteEffects)i[28], (float)i[29]);
            UI.DrawString((SpriteFont)i[30], (string)i[31], (Vector2)i[32], (Color)i[33]);
            UI.DrawString((SpriteFont)i[34], (string)i[35], (Vector2)i[36], (Color)i[37]);
        }
        public object[] CalculateWindow(SpriteFont font, string title, string body, Vector2 location, Vector2 windowSize)
        {
            MouseState newstate, oldstate = Mouse.GetState();
            Rectangle mouseObject = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            Vector2 borderSize = new Vector2(windowSize.X, windowSize.Y);
            Vector2 bodySize = new Vector2((long)((windowSize.X / 100) * 90), (long)((windowSize.Y / 100) * 70));
            Vector2 titleSize = new Vector2((long)((windowSize.X / 100) * 90), (long)((windowSize.Y / 100) * 10));
            Vector2 mousePosSave = new Vector2(0, 0);
            long pixelCount = (long)(borderSize.X * borderSize.Y);
            long bodyPixelCount = (long)(bodySize.X * bodySize.Y);
            long titlePixelCount = (long)(titleSize.X * titleSize.Y);
            Color[] borderColor = new Color[pixelCount];
            Color[] bodyColor = new Color[bodyPixelCount];
            Color[] titleColor = new Color[titlePixelCount];
            Color testColor = Color.DimGray;
            Texture2D borderFill = new Texture2D(graphicsDevice, (int)borderSize.X, (int)borderSize.Y);
            Texture2D bodyFill = new Texture2D(graphicsDevice, (int)bodySize.X, (int)bodySize.Y);
            Texture2D titleFill = new Texture2D(graphicsDevice, (int)titleSize.X, (int)titleSize.Y);
            mousePosSave.X = Mouse.GetState().X;
            mousePosSave.Y = Mouse.GetState().Y;
            Vector2 bodyPosition = new Vector2(location.X + (windowSize.X - bodySize.X) / 2, location.Y + (titleSize.Y) * 2);
            Vector2 titlePosition = new Vector2(location.X + (windowSize.X - titleSize.X) / 2, location.Y + titleSize.Y / 2);
            Rectangle border = new Rectangle((int)location.X, (int)location.Y, (int)windowSize.X, (int)windowSize.Y);
            Rectangle bodyRectangle = new Rectangle((int)bodyPosition.X, (int)bodyPosition.Y, (int)bodySize.X, (int)bodySize.Y);
            Rectangle titleRectangle = new Rectangle((int)titlePosition.X, (int)titlePosition.Y, (int)windowSize.X, (int)windowSize.Y);
            if (border.Intersects(mouseObject)/* && !bodyRectangle.Intersects(mouseObject) && !titleRectangle.Intersects(mouseObject)*/)
            {
                Vector2 offset = new Vector2(-10,-10);
                
                testColor = Color.Black;
                newstate = Mouse.GetState();

                


                if (Mouse.GetState().LeftButton == ButtonState.Pressed && oldstate.LeftButton == ButtonState.Released)
                    offset = new Vector2(newstate.X - location.X, newstate.Y - location.Y);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    
                    location.X = Mouse.GetState().X + offset.X;
                    location.Y = Mouse.GetState().Y + offset.Y;
                }
                oldstate = newstate;
            }
            
            bodyPosition = new Vector2(location.X + (windowSize.X - bodySize.X) / 2, location.Y + (titleSize.Y) * 2);
            titlePosition = new Vector2(location.X + (windowSize.X - titleSize.X) / 2, location.Y + titleSize.Y / 2);

            

            for (long i = 0; i < borderColor.Length; i++)
                borderColor[i] = testColor; //Color.DimGray;
            for (long i = 0; i < bodyColor.Length; i++)
                bodyColor[i] = Color.White;
            for (long i = 0; i < titleColor.Length; i++)
                titleColor[i] = Color.White;
            borderFill.SetData(borderColor);
            bodyFill.SetData(bodyColor);
            titleFill.SetData(titleColor);

        
            return new object[]
            {
                borderFill, location, null, null, Vector2.Zero, 0f, Vector2.One, Color.White, SpriteEffects.None, 0f,
                bodyFill, bodyPosition, null, null, Vector2.Zero, 0f, Vector2.One, Color.White, SpriteEffects.None, 0f,
                titleFill, titlePosition, null, null, Vector2.Zero, 0f, Vector2.One, Color.White, SpriteEffects.None, 0f,
                font, title, titlePosition, Color.Black,
                font, body, bodyPosition, Color.Black
            };
            
        }
    }
}
