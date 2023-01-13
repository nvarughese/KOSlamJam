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
    internal class Baddy : Sprite
    {
        public Baddy(Texture2D texture, int screenWidth, int screenHeight) : base(texture, screenWidth, screenHeight)
        {
            
            _type = "baddy";
            _collisionDamage = 100;
            Reset();
        }


        public override void Update(GameTime gameTime, string sprite_type, List<Sprite> sprites)
        {
           
            Move(gameTime.ElapsedGameTime.TotalSeconds);
            KeepWithinBounds();
        }

        public void Move(double elapsedTime)
        {
            Random rand = new Random();
            _direction.X += (float)rand.Next(-1, 2) * (float)elapsedTime;
            _direction.Y += (float)rand.Next(-1, 2) * (float)elapsedTime;
            _position.X += _direction.X * _speed * (float)elapsedTime;
            _position.Y += _direction.Y * _speed * (float)elapsedTime;
        }

        public void KeepWithinBounds()
        {
            if (_position.Y < _texture.Height / 2)
            {
                _position.Y = _texture.Height / 2;
                _direction.Y = Math.Abs(_direction.Y);
            }
            else if (_position.Y > _screenHeight - _texture.Height / 2)
            {
                _position.Y = _screenHeight - _texture.Height / 2;
                _direction.Y = -Math.Abs(_direction.Y);
            }
            if (_position.X < _texture.Width / 2)
            {
                _position.X = _texture.Width / 2;
                _direction.X = Math.Abs(_direction.X);
            }
            else if (_position.X > _screenWidth - _texture.Width / 2)
            {
                _position.X = _screenWidth - _texture.Width / 2;
                _direction.X = -Math.Abs(_direction.X);
            }
        }


        public override void Reset()
        {
            Random rand = new Random();
            _position.X = rand.Next(_texture.Width / 2, (_screenWidth - _texture.Width / 2) + 1);
            _position.Y = rand.Next(_texture.Height / 2, (_screenHeight - _texture.Height / 2) + 1);
            _direction.X = rand.Next(-5, 6);
            _direction.Y = rand.Next(-5, 6);
            _speed = rand.Next(50, 501);
        }


    }
}
