using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button_Masher
{
    public class Box
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Box NewBox { get; set; }

        public Box(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            //TODO: Add any update functionality for boxes
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position);
        }
    }

    
}
