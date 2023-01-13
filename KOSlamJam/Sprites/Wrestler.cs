using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOSlamJam.Sprites
{
    internal class Wrestler : Sprite
    {
        public Wrestler(Texture2D texture, int screenWidth, int screenHeight) : base(texture, screenWidth, screenHeight)
        {
            _speed = 300;
            _type = "wrestler";
            Reset();
        }


        public override void Update(GameTime gameTime, string spriteType)
        {
            if (spriteType == _type)
            {
                Move(gameTime.ElapsedGameTime.TotalSeconds);
                KeepWithinBounds();
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

        public override void Draw(SpriteBatch spriteBatch, string spriteType)
        {
            if (spriteType == _type)
            {
                spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_texture, _position, null, Color.Black, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 1 / 3, _screenHeight * 1 / 3);
        }


    }
}
