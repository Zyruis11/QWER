using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button_Masher
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int boxID;
        int score;
        int lives;

        Texture2D box1;
        Texture2D box2;
        Texture2D box3;
        Texture2D box4; 
        Vector2 pos1;
        Vector2 pos2;
        Vector2 pos3;
        Vector2 pos4;
        Color[] selectedBox;
        Color[] colorData1;
        Color[] colorData2;
        Color[] colorData3;
        Color[] colorData4;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsFixedTimeStep = false;
            this.graphics.SynchronizeWithVerticalRetrace = false; 
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            score = 0;
            lives = 3;
            box1 = new Texture2D(this.GraphicsDevice, 100, 100);
            box2 = new Texture2D(this.GraphicsDevice, 100, 100);
            box3 = new Texture2D(this.GraphicsDevice, 100, 100);
            box4 = new Texture2D(this.GraphicsDevice, 100, 100);
            colorData1 = new Color[100 * 100];
            colorData2 = new Color[100 * 100];
            colorData3 = new Color[100 * 100];
            colorData4 = new Color[100 * 100];
            selectedBox = new Color[100 * 100];

            for (int i = 0; i < 10000; i++)
            {
                colorData1[i] = Color.Red;
                colorData2[i] = Color.Green;
                colorData3[i] = Color.Blue;
                colorData4[i] = Color.Purple;
            }

            for(int i = 0; i < 10000; i++)
            {
                selectedBox[i] = Color.Orange;
            }

            box1.SetData<Color>(colorData1);
            box2.SetData<Color>(colorData2);
            box3.SetData<Color>(colorData3);
            box4.SetData<Color>(colorData4);

            pos1 = new Vector2(10, 10);
            pos2 = new Vector2(120, 10);
            pos3 = new Vector2(230,10);
            pos4 = new Vector2(340, 10);

            boxID = RandNum(boxID);
            

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
            if (IsActive)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }

                switch(boxID)
                {
                    case 1:
                        box1.SetData<Color>(selectedBox);
                        if (Keyboard.GetState().IsKeyDown(Keys.Q))
                        {
                            score++;
                            box1.SetData<Color>(colorData1);
                            boxID = RandNum(boxID);
                        }
                        break;
                    case 2:
                        box2.SetData<Color>(selectedBox);
                        if (Keyboard.GetState().IsKeyDown(Keys.W))
                        {
                            score++;
                            box2.SetData<Color>(colorData2);
                            boxID = RandNum(boxID);
                            break;
                        }
                        break;
                    case 3:
                        box3.SetData<Color>(selectedBox);
                        if (Keyboard.GetState().IsKeyDown(Keys.E))
                        {
                            score++;
                            box3.SetData<Color>(colorData3);
                            boxID = RandNum(boxID);
                            break;
                        }
                        break; 
                    case 4:
                        box4.SetData<Color>(selectedBox);
                        if (Keyboard.GetState().IsKeyDown(Keys.R))
                        {
                            score++;
                            box4.SetData<Color>(colorData4);
                            boxID = RandNum(boxID);
                            break;
                        }
                        break;
                }
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(box1, pos1);
            spriteBatch.Draw(box2, pos2);
            spriteBatch.Draw(box3, pos3);
            spriteBatch.Draw(box4, pos4);
            spriteBatch.End();           
            base.Draw(gameTime);
        }

        public int RandNum(int i)
        {
            Random rand = new Random();
            i = rand.Next(1, 4);
            return i;
        }

    }
}
