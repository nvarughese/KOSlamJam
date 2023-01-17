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
        private Vector2 _hoverAdjust;
        private float _hoverAdjustDistance;
        private Vector2 _attackAdjust;

        public Thor(int screenWidth, int screenHeight, SpriteFont font,
            Texture2D textureR, Texture2D textureRA, Texture2D textureL, Texture2D textureLA) : base(screenWidth, screenHeight, font, textureR)
        {
            _type = CharacterType.Thor;
            _speed = 400;
            _collisionDamage = 400;
            _resilienceMultiplier = 0.9f;
            _textureR = textureR;
            _textureRA = textureRA;
            _textureL = textureL;
            _textureLA = textureLA;
            _hoverAdjustDistance = 15f;
            _animationCycleTime = 2000;
            _attackTimelimit = 2f;
            _attackResetTime = 2f;
            Reset();
        }

        public override void Update(GameTime gameTime, CharacterType spriteType, List<Sprite> sprites)
        {
            base.Update(gameTime, spriteType, sprites);
            if (spriteType == _type)
            {
                if (_isAttacking)
                {
                    _texture = _isFacingRight ? _textureRA : _textureLA;
                    _attackAdjust.X = (_isFacingRight ? 1.0f : -1.0f) * (_textureRA.Width - _textureR.Width) / 2;
                    _hoverAdjust = Vector2.Zero;
                    return;
                }
                else
                {
                    _attackAdjust.X = 0;
                }
                _totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                float msThruAniCycle = (_totalTime * 1000) % _animationCycleTime;
                if (msThruAniCycle < (_animationCycleTime * 1 / 20)) {}
                else if (msThruAniCycle < (_animationCycleTime * 2 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.2f; _hoverAdjust.Y = _hoverAdjustDistance * -0.2f; }
                else if (msThruAniCycle < (_animationCycleTime * 3 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.3f; _hoverAdjust.Y = _hoverAdjustDistance * -0.5f; }
                else if (msThruAniCycle < (_animationCycleTime * 4 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.15f; _hoverAdjust.Y = _hoverAdjustDistance * -0.8f; }
                else if (msThruAniCycle < (_animationCycleTime * 5 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.0f; _hoverAdjust.Y = _hoverAdjustDistance * -0.9f; }
                else if (msThruAniCycle < (_animationCycleTime * 6 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.35f; _hoverAdjust.Y = _hoverAdjustDistance * -0.6f; }
                else if (msThruAniCycle < (_animationCycleTime * 7 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.6f; _hoverAdjust.Y = _hoverAdjustDistance * -0.2f; }
                else if (msThruAniCycle < (_animationCycleTime * 8 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.2f; _hoverAdjust.Y = _hoverAdjustDistance * 0f; }
                else if (msThruAniCycle < (_animationCycleTime * 9 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.1f; _hoverAdjust.Y = _hoverAdjustDistance * 0.1f; }
                else if (msThruAniCycle < (_animationCycleTime * 10 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.6f; _hoverAdjust.Y = _hoverAdjustDistance * 0.4f; }
                else if (msThruAniCycle < (_animationCycleTime * 11 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.9f; _hoverAdjust.Y = _hoverAdjustDistance * 0.7f; }
                else if (msThruAniCycle < (_animationCycleTime * 12 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.6f; _hoverAdjust.Y = _hoverAdjustDistance * 0.75f; }
                else if (msThruAniCycle < (_animationCycleTime * 13 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * -0.2f; _hoverAdjust.Y = _hoverAdjustDistance * 0.8f; }
                else if (msThruAniCycle < (_animationCycleTime * 14 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.3f; _hoverAdjust.Y = _hoverAdjustDistance * 0.85f; }
                else if (msThruAniCycle < (_animationCycleTime * 15 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.3f; _hoverAdjust.Y = _hoverAdjustDistance * 0.9f; }
                else if (msThruAniCycle < (_animationCycleTime * 16 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.6f; _hoverAdjust.Y = _hoverAdjustDistance * 0.75f; }
                else if (msThruAniCycle < (_animationCycleTime * 17 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.9f; _hoverAdjust.Y = _hoverAdjustDistance * 0.5f; }
                else if (msThruAniCycle < (_animationCycleTime * 18 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.5f; _hoverAdjust.Y = _hoverAdjustDistance * 0.4f; }
                else if (msThruAniCycle < (_animationCycleTime * 19 / 20)) { _hoverAdjust.X = _hoverAdjustDistance * 0.1f; _hoverAdjust.Y = _hoverAdjustDistance * 0.3f; }
                else { _hoverAdjust.X = _hoverAdjustDistance * 0.05f; _hoverAdjust.Y = _hoverAdjustDistance * 0.15f; }
                if (_movingDirection == MovingDirection.Right) { _texture = _textureR; }
                else if (_movingDirection == MovingDirection.Left) { _texture = _textureL; }
                else
                {
                    _texture = _isFacingRight ? _textureR : _textureL;
                }
            }
        }

        public override void KeepWithinBounds()
        {
            if (_position.Y + _hoverAdjust.Y < _texture.Height / 2)
            {
                _position.Y = _texture.Height / 2 - _hoverAdjust.Y;
            }
            else if (_position.Y + _hoverAdjust.Y > _screenHeight - _texture.Height / 2)
            {
                _position.Y = _screenHeight - _texture.Height / 2 - _hoverAdjust.Y;
            }
            if (_position.X  + _hoverAdjust.X + _attackAdjust.X < _texture.Width / 2)
            {
                _position.X = _texture.Width / 2 - _hoverAdjust.X - _attackAdjust.X;
            }
            else if (_position.X + _hoverAdjust.X + _attackAdjust.X > _screenWidth - _texture.Width / 2)
            {
                _position.X = _screenWidth - _texture.Width / 2 - _hoverAdjust.X - _attackAdjust.X;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, CharacterType _activeCharacter)
        {
            // todo more the font to the constructor and store inside the class
            if (_activeCharacter == _type)
            {
                spriteBatch.Draw(_texture, _position + _hoverAdjust + _attackAdjust, null, (_isHit ? Color.Red : Color.White), 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else if (_health > 0)
            {
                spriteBatch.Draw(_texture, _position + _hoverAdjust + _attackAdjust, null, Color.Black, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_texture, _position + _hoverAdjust + _attackAdjust, null, Color.DarkRed, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(_font, ((int)_health).ToString(), new Vector2(_position.X + _hoverAdjust.X - _textureR.Width / 5, _position.Y + _hoverAdjust.Y - _texture.Height / 2 - 20), Color.LightBlue);
        }

        public override Rectangle Rectangle
        {
            get
            {
                if (_texture != null)
                {
                    return new Rectangle((int)_position.X + (int)_hoverAdjust.X + (int)_attackAdjust.X, (int)_position.Y + (int)_hoverAdjust.Y, _texture.Width, _texture.Height);
                }
                throw new Exception("Unknown sprite");
            }
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 1 / 2, _screenHeight * 2 / 3);
            _health = 500;
            _hoverAdjust = Vector2.Zero;
            _attackAdjust = Vector2.Zero;
        }
    }
}
