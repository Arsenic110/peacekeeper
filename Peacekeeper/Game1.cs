using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.IO;

namespace Peacekeeper
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch UI;
        Manager2D manager;
        KeyboardState newstate, oldstate;
        TerrainGenerator gen;

        #region Variables
        #region Textures
        private SpriteFont arial;
        Texture2D cursor;
        Texture2D randomTexture;
        #endregion
        public Vector2 mousePosition { get; private set; }
        Vector2 windowPos;
        Vector2 windowPos2;
        Vector2 mousePositionLocal;
        object[] storer;
        object[] storer2;
        int[] random;
        #endregion
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            UI = new SpriteBatch(GraphicsDevice);
            manager = new Manager2D(UI, GraphicsDevice);
            arial = Content.Load<SpriteFont>("arial");
            cursor = Content.Load<Texture2D>("Cursor1");
            randomTexture = new Texture2D(GraphicsDevice, 32, 32);
            gen = new TerrainGenerator(randomTexture);
            gen.GenerateRandomness();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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
            oldstate = Keyboard.GetState();
            mousePositionLocal.X = Mouse.GetState().X;
            mousePositionLocal.Y = Mouse.GetState().Y;
            mousePosition = mousePositionLocal;
            //if(storer[1] != null)
            //    windowPos = (Vector2)storer[1];

            //storer = manager.CalculateWindow(arial, "Test Window", "If this window is complete," +
            //    " you should\nbe able to move it around.", windowPos, new Vector2(300, 350));
            //storer2 = manager.CalculateWindow(arial, "Nya", "If this window is complete," +
            //    " you should\nbe able to move it around.", windowPos2, new Vector2(400, 200));
            //if (storer[1] != null)
            //    windowPos = (Vector2)storer[1];
            //if (storer2[1] != null)
            //    windowPos2 = (Vector2)storer2[1];
            newstate = Keyboard.GetState();
            oldstate = newstate;
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            UI.Begin();
            //manager.DrawWindow(storer);
            //manager.DrawWindow(storer2);

            UI.Draw(gen.MakeTexture(), new Vector2(0, 0), Color.White);
            UI.Draw(cursor, mousePositionLocal, null, Color.White, 0f, Vector2.Zero, new Vector2(0.08f),
                SpriteEffects.None, 0f);
            UI.End();

            base.Draw(gameTime);
        }
    }
}
