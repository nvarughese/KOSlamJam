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
        public Graffiti(Texture2D texture, int screenWidth, int screenHeight, SpriteFont font) : base(texture, screenWidth, screenHeight, font)
        {
            _type = "graffiti";
            _speed = 400;
            _resilienceMultiplier = 1.2f;
            Reset();
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 2 / 3, _screenHeight * 1 / 3);
        }


    }
}
