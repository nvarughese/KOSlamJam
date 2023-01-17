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
        
        public Character(int screenWidth, int screenHeight, SpriteFont font, Texture2D texture) : base(screenWidth, screenHeight, font, texture)
        {
        }


        public override void Update(GameTime gameTime, CharacterType spriteType, List<Sprite> sprites)
        {
            if (spriteType == _type)
            {
                float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Move(elapsedSeconds);
                checkIsAttacking(elapsedSeconds);
                KeepWithinBounds();
                HandleCollisions(elapsedSeconds, sprites);
            }
        }

        

        public void HandleCollisions(float elapsedSeconds, List<Sprite> sprites)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite._type == CharacterType.Baddy && sprite._health > 0)
                {
                    if (sprite.Rectangle.Intersects(this.Rectangle))
                    {
                        if (_isAttacking)
                        {
                            sprite._isHit = true;
                            sprite._hitBy = _type;
                            
                            if (sprite._isAttacking)
                            {
                                _isHit = true;
                                _health -= elapsedSeconds * sprite._collisionDamage * this._resilienceMultiplier * 0.2f;
                                _health = Math.Max(0f, _health);
                                sprite._isHit = true;
                                sprite._health -= elapsedSeconds * _collisionDamage * sprite._resilienceMultiplier * 0.2f;
                                sprite._health = Math.Max(0f, sprite._health);
                                
                            }
                            else
                            {
                                sprite._isHit = true;
                                sprite._health -= elapsedSeconds * _collisionDamage * sprite._resilienceMultiplier;
                                sprite._health = Math.Max(0f, sprite._health);
                                sprite._hitBy = _type;
                            }
                        }
                        else
                        {
                            if (sprite._isAttacking)
                            {
                                _isHit = true;
                                _health -= elapsedSeconds * sprite._collisionDamage * this._resilienceMultiplier;
                                _health = Math.Max(0f, _health);
                            }
                            else
                            {
                                _isHit = true;
                                _health -= elapsedSeconds * sprite._collisionDamage * this._resilienceMultiplier * 0.2f;
                                _health = Math.Max(0f, _health);
                            }
                        }
                        
                    }
                }
            }

        }

        public void Move(float elapsedSeconds)
        {
            _currentKey = Keyboard.GetState();
            _movingDirection = MovingDirection.Still;
            // move the character using the arrow keys
            _isTryingToAttack = _currentKey.IsKeyDown(Keys.Z);
            if (_isAttacking && _type != CharacterType.Graffiti) { return; }

            if (_currentKey.IsKeyDown(Keys.Up))
            {
                _position.Y -= elapsedSeconds * _speed * _YMoveMultiplier;
            }
            if (_currentKey.IsKeyDown(Keys.Down))
            {
                _position.Y += elapsedSeconds * _speed * _YMoveMultiplier;
            }
            if (_currentKey.IsKeyDown(Keys.Left))
            {
                _position.X -= elapsedSeconds * _speed;
                _movingDirection = MovingDirection.Left;
            }
            if (_currentKey.IsKeyDown(Keys.Right))
            {
                _position.X += elapsedSeconds * _speed;
                _movingDirection = (_movingDirection == MovingDirection.Left) ? MovingDirection.Still :MovingDirection.Right;
            }
            if (_movingDirection != MovingDirection.Still) { _isFacingRight = (_movingDirection == MovingDirection.Right); }
        }

        public virtual void KeepWithinBounds()
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

        public override void Draw(SpriteBatch spriteBatch, CharacterType _activeCharacter)
        {
            // todo more the font to the constructor and store inside the class
            if (_activeCharacter == _type)
            {
                spriteBatch.Draw(_texture, _position, null, (_isHit ? Color.Red : Color.White), 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else if (_health > 0)
            {
                spriteBatch.Draw(_texture, _position, null, Color.Black, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_texture, _position, null, Color.DarkRed, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(_font, ((int)_health).ToString(), new Vector2(_position.X - _texture.Width / 5, _position.Y - _texture.Height / 2 - 20), Color.LightBlue);
        }


    }
}
