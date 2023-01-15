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
            Reset();
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 1 / 2, _screenHeight * 2 / 3);
            _health = 200;
        }
    }
}
