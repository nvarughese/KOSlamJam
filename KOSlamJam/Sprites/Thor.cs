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
    internal class Thor : Character
    {
        private Texture2D _textureR;
        private Texture2D _textureRA;
        private Texture2D _textureL;
        private Texture2D _textureLA;
        private Vector2 _hoverAdd;
        private float _hoverAddDistance;

        public Thor(int screenWidth, int screenHeight, SpriteFont font,
            Texture2D textureR, Texture2D textureRA, Texture2D textureL, Texture2D textureLA) : base(screenWidth, screenHeight, font, textureR)
        {
            _type = "thor";
            _speed = 500;
            _resilienceMultiplier = 0.9f;
            _textureR = textureR;
            _textureRA = textureRA;
            _textureL = textureL;
            _textureLA = textureLA;
            _hoverAddDistance = 15f;
            _animationCycleTime = 2000;
            Reset();
        }

        public override void Update(GameTime gameTime, string spriteType, List<Sprite> sprites)
        {
            base.Update(gameTime, spriteType, sprites);
            if (spriteType == _type)
            {
                _totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                float msThruAniCycle = (_totalTime * 1000) % _animationCycleTime;
                if (msThruAniCycle < (_animationCycleTime * 1 / 20)) {}
                else if (msThruAniCycle < (_animationCycleTime * 2 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.2f; _hoverAdd.Y = _hoverAddDistance * -0.2f; }
                else if (msThruAniCycle < (_animationCycleTime * 3 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.3f; _hoverAdd.Y = _hoverAddDistance * -0.5f; }
                else if (msThruAniCycle < (_animationCycleTime * 4 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.15f; _hoverAdd.Y = _hoverAddDistance * -0.8f; }
                else if (msThruAniCycle < (_animationCycleTime * 5 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.0f; _hoverAdd.Y = _hoverAddDistance * -0.9f; }
                else if (msThruAniCycle < (_animationCycleTime * 6 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.35f; _hoverAdd.Y = _hoverAddDistance * -0.6f; }
                else if (msThruAniCycle < (_animationCycleTime * 7 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.6f; _hoverAdd.Y = _hoverAddDistance * -0.2f; }
                else if (msThruAniCycle < (_animationCycleTime * 8 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.2f; _hoverAdd.Y = _hoverAddDistance * 0f; }
                else if (msThruAniCycle < (_animationCycleTime * 9 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.1f; _hoverAdd.Y = _hoverAddDistance * 0.1f; }
                else if (msThruAniCycle < (_animationCycleTime * 10 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.6f; _hoverAdd.Y = _hoverAddDistance * 0.4f; }
                else if (msThruAniCycle < (_animationCycleTime * 11 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.9f; _hoverAdd.Y = _hoverAddDistance * 0.7f; }
                else if (msThruAniCycle < (_animationCycleTime * 12 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.6f; _hoverAdd.Y = _hoverAddDistance * 0.75f; }
                else if (msThruAniCycle < (_animationCycleTime * 13 / 20)) { _hoverAdd.X = _hoverAddDistance * -0.2f; _hoverAdd.Y = _hoverAddDistance * 0.8f; }
                else if (msThruAniCycle < (_animationCycleTime * 14 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.3f; _hoverAdd.Y = _hoverAddDistance * 0.85f; }
                else if (msThruAniCycle < (_animationCycleTime * 15 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.3f; _hoverAdd.Y = _hoverAddDistance * 0.9f; }
                else if (msThruAniCycle < (_animationCycleTime * 16 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.6f; _hoverAdd.Y = _hoverAddDistance * 0.75f; }
                else if (msThruAniCycle < (_animationCycleTime * 17 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.9f; _hoverAdd.Y = _hoverAddDistance * 0.5f; }
                else if (msThruAniCycle < (_animationCycleTime * 18 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.5f; _hoverAdd.Y = _hoverAddDistance * 0.4f; }
                else if (msThruAniCycle < (_animationCycleTime * 19 / 20)) { _hoverAdd.X = _hoverAddDistance * 0.1f; _hoverAdd.Y = _hoverAddDistance * 0.3f; }
                else { _hoverAdd.X = _hoverAddDistance * 0.05f; _hoverAdd.Y = _hoverAddDistance * 0.15f; }
                if (_movingDirection == MovingDirection.Right) { _texture = _textureR; }
                else if (_movingDirection == MovingDirection.Left) { _texture = _textureL; }
            }
        }

        public void KeepWithinBounds()
        {
            if (_position.Y + _hoverAdd.Y < _texture.Height / 2)
            {
                _position.Y = _texture.Height / 2 - _hoverAdd.Y;
            }
            else if (_position.Y + _hoverAdd.Y > _screenHeight - _texture.Height / 2)
            {
                _position.Y = _screenHeight - _texture.Height / 2 - _hoverAdd.Y;
            }
            if (_position.X  + _hoverAdd.X < _texture.Width / 2)
            {
                _position.X = _texture.Width / 2 - _hoverAdd.X;
            }
            else if (_position.X + _hoverAdd.X > _screenWidth - _texture.Width / 2)
            {
                _position.X = _screenWidth - _texture.Width / 2 - _hoverAdd.X;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, string _activeCharacter)
        {
            // todo more the font to the constructor and store inside the class
            if (_activeCharacter == _type)
            {
                spriteBatch.Draw(_texture, _position + _hoverAdd, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else if (_health > 0)
            {
                spriteBatch.Draw(_texture, _position + _hoverAdd, null, Color.Black, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_texture, _position + _hoverAdd, null, Color.DarkRed, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(_font, ((int)_health).ToString(), new Vector2(_position.X + _hoverAdd.X - _texture.Width / 5, _position.Y + _hoverAdd.Y - _texture.Height / 2 - 20), Color.Blue);
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 1 / 2, _screenHeight * 2 / 3);
            _health = 200;
            _hoverAdd = Vector2.Zero;
        }
    }
}
