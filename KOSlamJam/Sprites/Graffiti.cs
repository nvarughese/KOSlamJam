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
    internal class Graffiti : Character
    {
        private Texture2D _textureR1;
        private Texture2D _textureR2;
        private Texture2D _textureR3;
        private Texture2D _textureRA;
        private Texture2D _textureL1;
        private Texture2D _textureL2;
        private Texture2D _textureL3;
        private Texture2D _textureLA;
        public Graffiti(int screenWidth, int screenHeight, SpriteFont font,
            Texture2D textureR1, Texture2D textureR2, Texture2D textureR3, Texture2D textureRA,
            Texture2D textureL1, Texture2D textureL2, Texture2D textureL3, Texture2D textureLA) : base(screenWidth, screenHeight, font, textureR1)
        {
            _type = "graffiti";
            _speed = 400;
            _resilienceMultiplier = 1.2f;
            _textureR1 = textureR1;
            _textureR2 = textureR2;
            _textureR3 = textureR3;
            _textureRA = textureRA;
            _textureL1 = textureL1;
            _textureL2 = textureL2;
            _textureL3 = textureL3;
            _textureLA = textureLA;
            _animationCycleTime = 250;
            Reset();
        }

        public override void Update(GameTime gameTime, string spriteType, List<Sprite> sprites)
        {
            base.Update(gameTime, spriteType, sprites);
            if (spriteType == _type)
            {
                _totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_movingDirection == MovingDirection.Right)
                {
                    float msThroughAnimationCycle = (_totalTime * 1000) % _animationCycleTime;
                    if (msThroughAnimationCycle < (_animationCycleTime * 1 / 4)) { _texture = _textureR1; }
                    else if (msThroughAnimationCycle < (_animationCycleTime * 2 / 4)) { _texture = _textureR2; }
                    else if (msThroughAnimationCycle < (_animationCycleTime * 3 / 4)) { _texture = _textureR1; }
                    else { _texture = _textureR3; }
                }
                else if (_movingDirection == MovingDirection.Left)
                {
                    float msThroughAnimationCycle = (_totalTime * 1000) % _animationCycleTime;
                    if (msThroughAnimationCycle < (_animationCycleTime * 1 / 4)) { _texture = _textureL1; }
                    else if (msThroughAnimationCycle < (_animationCycleTime * 2 / 4)) { _texture = _textureL2; }
                    else if (msThroughAnimationCycle < (_animationCycleTime * 3 / 4)) { _texture = _textureL1; }
                    else { _texture = _textureL3; }
                }
            }
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 2 / 3, _screenHeight * 1 / 3);
            _health = 200;
        }


    }
}
