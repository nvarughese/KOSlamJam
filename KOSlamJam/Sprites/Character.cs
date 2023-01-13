using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace KOSlamJam.Sprites
{
    internal class Character : Sprite
    {

        private SpriteFont _font;
        public Character(Texture2D texture, int screenWidth, int screenHeight, SpriteFont font) : base(texture, screenWidth, screenHeight)
        {
            _font = font;
        }


        public override void Update(GameTime gameTime, string spriteType, List<Sprite> sprites)
        {
            if (spriteType == _type)
            {
                Move(gameTime.ElapsedGameTime.TotalSeconds);
                KeepWithinBounds();
                HandleCollisions(gameTime.ElapsedGameTime.TotalSeconds, sprites);
            }
        }

        public void HandleCollisions(double elapsedTime, List<Sprite> sprites)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite._type == "baddy")
                {
                    if (sprite.Rectangle.Intersects(this.Rectangle))
                    {
                        _health -= (float)elapsedTime * sprite._collisionDamage * this._resilienceMultiplier;
                        _health = Math.Max(0, _health);
                    }
                }
            }

        }

        public void Move(double elapsedTime)
        {
            _currentKey = Keyboard.GetState();
            // move the farmer using the arrow keys
            if (_currentKey.IsKeyDown(Keys.Up))
            {
                _position.Y -= (float)elapsedTime * _speed;
            }
            if (_currentKey.IsKeyDown(Keys.Down))
            {
                _position.Y += (float)elapsedTime * _speed;
            }
            if (_currentKey.IsKeyDown(Keys.Left))
            {
                _position.X -= (float)elapsedTime * _speed;
            }
            if (_currentKey.IsKeyDown(Keys.Right))
            {
                _position.X += (float)elapsedTime * _speed;
            }
        }

        public void KeepWithinBounds()
        {
            if (_position.Y < _texture.Height / 2)
            {
                _position.Y = _texture.Height / 2;
            }
            else if (_position.Y > _screenHeight - _texture.Height / 2)
            {
                _position.Y = _screenHeight - _texture.Height / 2;
            }
            if (_position.X < _texture.Width / 2)
            {
                _position.X = _texture.Width / 2;
            }
            else if (_position.X > _screenWidth - _texture.Width / 2)
            {
                _position.X = _screenWidth - _texture.Width / 2;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, string _activeCharacter)
        {
            // todo more the font to the constructor and store inside the class
            if (_activeCharacter == _type)
            {
                spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else if (_health > 0)
            {
                spriteBatch.Draw(_texture, _position, null, Color.Black, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_texture, _position, null, Color.DarkRed, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(_font, ((int)_health).ToString(), new Vector2(_position.X - _texture.Width / 2, _position.Y - _texture.Height / 2 - 50), Color.Blue);
        }


    }
}
