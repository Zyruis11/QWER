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

        int height;
        int width;

        KeyboardState oldState; 

        SpriteFont font; 

        Texture2D box1;
        Texture2D box2;
        Texture2D box3;
        Texture2D box4; 
        Vector2 pos1;
        Vector2 pos2;
        Vector2 pos3;
        Vector2 pos4;
        Vector2 scorePos;
        Vector2 livesPos; 
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

            height = graphics.GraphicsDevice.Viewport.Height;
            width = graphics.GraphicsDevice.Viewport.Width;
            Console.WriteLine("Width:" + width);
            Console.WriteLine("Height: " + height);
            pos1 = new Vector2((width / 4) - 150, (height / 2) - 50);
            pos2 = new Vector2((width / 2) - 150, (height / 2) - 50);
            pos3 = new Vector2((width /2) + 50, (height / 2) - 50);
            pos4 = new Vector2((width - 150) , (height / 2) - 50);
            scorePos = new Vector2(20,20);
            livesPos = new Vector2(730,20);
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
            font = Content.Load<SpriteFont>("font");
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
         
            KeyboardState newState = Keyboard.GetState();

            if (IsActive)
            {
                Console.WriteLine("Current Box: " + boxID);
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }

                switch(boxID)
                {
                    case 1:
                        box1.SetData<Color>(selectedBox);
                        if (oldState.IsKeyDown(Keys.Q) && newState.IsKeyDown(Keys.Q))
                        {
                            score++;
                            box1.SetData<Color>(colorData1);
                            boxID = RandNum(boxID);
                            Console.WriteLine("ID has changed");
                        }
                        oldState = newState;
                        break;
                    case 2:
                        box2.SetData<Color>(selectedBox);
                        if (oldState.IsKeyDown(Keys.W) && newState.IsKeyDown(Keys.W))
                        {
                            score++;
                            box2.SetData<Color>(colorData2);
                            boxID = RandNum(boxID);
                            Console.WriteLine("ID has changed");
                        }
                        oldState = newState;
                        break;
                    case 3:
                        box3.SetData<Color>(selectedBox);
                        if (oldState.IsKeyDown(Keys.E) && newState.IsKeyDown(Keys.E))
                        {
                            score++;
                            box3.SetData<Color>(colorData3);
                            boxID = RandNum(boxID);
                            Console.WriteLine("ID has changed");
                        }
                        oldState = newState;
                        break; 
                    case 4:
                        box4.SetData<Color>(selectedBox);
                        if (oldState.IsKeyDown(Keys.R) && newState.IsKeyDown(Keys.R))
                        {
                            score++;
                            box4.SetData<Color>(colorData4);
                            boxID = RandNum(boxID);
                            Console.WriteLine("ID has changed");
                        }
                        oldState = newState;
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
            spriteBatch.DrawString(font,"Score: " + score,scorePos,Color.Black);
            spriteBatch.DrawString(font,"Lives: " + lives,livesPos,Color.Black);
            spriteBatch.Draw(box1, pos1);
            spriteBatch.Draw(box2, pos2);
            spriteBatch.Draw(box3, pos3);
            spriteBatch.Draw(box4, pos4);
            spriteBatch.End();           
            base.Draw(gameTime);
        }

        /// <summary>
        /// Generates a random number between 1 and 5
        /// </summary>
        /// <param name="i">The int that is to be randomly generated</param>
        /// <returns></returns>
        public int RandNum(int i)
        {
            Random rand = new Random();
            i = rand.Next(1, 5);
            return i;
        }

    }
}
