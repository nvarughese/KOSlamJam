using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOSlamJam.Sprites
{
    internal class Sprite
    {
        public int _screenWidth;
        public int _screenHeight;



        protected KeyboardState _currentKey;


        public Vector2 _position;
        public Vector2 _direction;
        public float _speed = 0f;
        public float _collisionDamage = 0;
        public float _resilienceMultiplier = 1;
        public float _health = 100;
        // redo this using enums
        public string _type = "wrestler";
        public bool _faceRight;

        public Texture2D _texture;
        public SpriteFont _font;

        public Sprite(int screenWidth, int screenHeight, SpriteFont font, Texture2D texture)
        {
            _font = font;
            _texture = texture;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public Rectangle Rectangle
        {
            get
            {
                if (_texture != null)
                {
                    return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
                }
                throw new Exception("Unknown sprite");
            }
        }
        public virtual void Update(GameTime gameTime, string activeCharacter, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, string activeCharacter)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }

        public virtual void Reset()
        {
        }
    }
}
