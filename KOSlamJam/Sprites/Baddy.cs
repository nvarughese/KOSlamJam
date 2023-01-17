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
        private Texture2D _textureR1;
        private Texture2D _textureR2;
        private Texture2D _textureRA;
        private Texture2D _textureRF;
        private Texture2D _textureL1;
        private Texture2D _textureL2;
        private Texture2D _textureLA;
        private Texture2D _textureLF;
        

        public Baddy(int screenWidth, int screenHeight, SpriteFont font,
            Texture2D textureR1, Texture2D textureR2, Texture2D textureRA, Texture2D textureRF,
            Texture2D textureL1, Texture2D textureL2, Texture2D textureLA, Texture2D textureLF) : base(screenWidth, screenHeight, font, textureR1)
        {
            _type = CharacterType.Baddy;
            _collisionDamage = 300;
            _textureR1 = textureR1;
            _textureR2 = textureR2;
            _textureRA = textureRA;
            _textureRF = textureRF;
            _textureL1 = textureL1;
            _textureL2 = textureL2;
            _textureLA = textureLA;
            _textureLF = textureLF;
            _animationCycleTime = 500f;
            _attackTimelimit = 0.5f;
            _attackResetTime = 2.0f;
            Reset();
        }


        public override void Update(GameTime gameTime, CharacterType activeCharacter, List<Sprite> sprites)
        {
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 characterPostion = Vector2.Zero;
            foreach (Sprite sprite in sprites)
            {
                if(sprite._type == activeCharacter) { characterPostion = sprite._position; }
            }
            Move(elapsedSeconds, characterPostion);
            _isReleasePause = false;
            checkIsAttacking(elapsedSeconds);
            KeepWithinBounds();
        }

        public void Move(float elapsedTime, Vector2 characterPosition)
        {
            if (_health <= 0) { 
                _texture = (_isFacingRight ? _textureRF : _textureLF);
                _adjust.Y = 50f;
                return; 
            }
            _totalTime += (float)elapsedTime;
            bool isAnimationOne = (_totalTime * 1000) % _animationCycleTime < (_animationCycleTime / 2); 
            Random rand = new Random();
            _direction.X = (float)elapsedTime * (characterPosition.X - _position.X) / 3;
            _direction.Y = (float)rand.Next(-50, 51) * (float)elapsedTime + (float)elapsedTime * (characterPosition.Y - _position.Y) / 3;

            _position.X += _direction.X * _speed * (float)elapsedTime;
            _position.Y += _direction.Y * _speed * (float)elapsedTime * _YMoveMultiplier;
            _isFacingRight = (_direction.X >= 0);
            if (Math.Abs(characterPosition.X - _position.X) + Math.Abs(characterPosition.Y - _position.Y) < 300)
            {
                _isTryingToAttack = true;
            }
            if (_isAttacking)
            {
                _texture = _direction.X >= 0 ? _textureRA : _textureLA;
            }
            else
            {
                _texture = _direction.X >= 0 ? (isAnimationOne ? _textureR1 : _textureR2) : (isAnimationOne ? _textureL1 : _textureL2);
            }
            if (_isHit) {
                if (_hitBy == CharacterType.Wrestler)
                {
                    _adjust.Y = 50f;
                    _texture = (_isFacingRight ? _textureRF : _textureLF);
                }
                if (_hitBy == CharacterType.Graffiti)
                {
                    _colour = Color.LightGreen;
                }
                if (_hitBy == CharacterType.Thor)
                {
                    bool isElectricutionOne = (_totalTime * 1000) % 200 < 100;
                    _colour = isElectricutionOne ? Color.Yellow : Color.Black;
                }
            }
            else { 
                _adjust.Y = 0f; 
                _colour = Color.White;
            }
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
            int startingWall = rand.Next(1, 5);
            if (startingWall == 1)
            {
                _position.X = _texture.Width / 2;
                _position.Y = rand.Next(_texture.Height / 2, (_screenHeight - _texture.Height / 2) + 1);
            }
            else if (startingWall == 2)
            {
                _position.X = _screenWidth - _texture.Width / 2;
                _position.Y = rand.Next(_texture.Height / 2, (_screenHeight - _texture.Height / 2) + 1);
            }
            else if (startingWall == 3)
            {
                _position.X = rand.Next(_texture.Width / 2, (_screenWidth - _texture.Width / 2) + 1);
                _position.Y = _texture.Height / 2;
            }
            else
            {
                _position.X = rand.Next(_texture.Width / 2, (_screenWidth - _texture.Width / 2) + 1);
                _position.Y = _screenHeight - _texture.Height / 2;
            }
            _direction.X = rand.Next(-5, 6);
            _direction.Y = rand.Next(-5, 6);
            _speed = rand.Next(50, 100);
            _health = 100f;
        }

        public override void Draw(SpriteBatch spriteBatch, CharacterType activeCharacter)
        {
            base.Draw(spriteBatch, activeCharacter);
            spriteBatch.DrawString(_font, ((int)_health).ToString(), new Vector2(_position.X - _texture.Width / 5, _position.Y - _texture.Height / 2 - 20), Color.LightBlue);
        }


    }
}
