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
        public float _YMoveMultiplier = 0.7f;
        public float _collisionDamage = 0;
        public float _resilienceMultiplier = 1;
        public bool _isHit = false;
        public CharacterType _hitBy;
        public float _health = 100f;
        // redo this using enums
        public CharacterType _type = CharacterType.Wrestler;
        public MovingDirection _movingDirection;
        public float _totalTime;
        public float _animationCycleTime = 500;  // in ms to complete animation cycle, lower is faster
        public bool _isAttacking = false;
        public bool _isAttackResetting = false;
        public bool _isTryingToAttack = false;
        public float _timer = 0;
        public float _attackTimelimit = 2;  // you can attack for this long (secs)
        public float _attackResetTime = 2;  // after you attack you have to wait this long until attacking again (secs)
        public bool _isReleasePause;  // this means you have to release attack to attack again
        public Vector2 _adjust = Vector2.Zero;

        public bool _isFacingRight = true;
        public Texture2D _texture;
        public SpriteFont _font;
        public Color _colour = Color.White;

        public Sprite(int screenWidth, int screenHeight, SpriteFont font, Texture2D texture)
        {
            _font = font;
            _texture = texture;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public virtual Rectangle Rectangle
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

        public void checkIsAttacking(float elapsedSeconds)
        {
            if (_isAttacking)
            {
                if (_isTryingToAttack)
                {
                    _timer += elapsedSeconds;
                    if (_timer > _attackTimelimit)
                    {
                        _timer = 0;
                        _isAttacking = false;
                        _isAttackResetting = true;
                        _isReleasePause = true;
                    }
                }
                else
                {
                    _isReleasePause = false;
                    _timer = 0;
                    _isAttacking = false;
                    _isAttackResetting = true;
                }
            }
            else if (_isAttackResetting)
            {
                if (!_isTryingToAttack) { _isReleasePause = false; }
                _timer += elapsedSeconds;
                if (_timer > _attackResetTime)
                {
                    _timer = 0;
                    _isAttackResetting = false;
                    if (_isTryingToAttack && !_isReleasePause) { _isAttacking = true; }
                }
            }
            else if (_isTryingToAttack)
            {
                if (!_isReleasePause)
                {
                    _timer = 0;
                    _isAttacking = true;
                }
            }
            else
            {
                _isReleasePause = false;
            }
        }
        public virtual void Update(GameTime gameTime, CharacterType activeCharacter, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, CharacterType activeCharacter)
        {
            if (_health > 0)
            {
                spriteBatch.Draw(_texture, _position + _adjust, null, _colour, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_texture, _position + _adjust, null, Color.DarkRed, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            
        }

        public virtual void Reset()
        {
        }
    }
}
