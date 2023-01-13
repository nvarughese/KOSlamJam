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
        public Thor(Texture2D texture, int screenWidth, int screenHeight, SpriteFont font) : base(texture, screenWidth, screenHeight, font)
        {
            _type = "thor";
            _speed = 500;
            _resilienceMultiplier = 0.9f;
            Reset();
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 1 / 2, _screenHeight * 2 / 3);
        }
    }
}
