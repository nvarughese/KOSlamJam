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
    internal class Wrestler : Character
    {

        private SpriteFont _font;
        public Wrestler(Texture2D texture, int screenWidth, int screenHeight, SpriteFont font) : base(texture, screenWidth, screenHeight, font)
        {
            _type = "wrestler";
            _speed = 300;
            _resilienceMultiplier = 0.7f;
            Reset();
        }

        public override void Reset()
        {
            _position = new Vector2(_screenWidth * 1 / 3, _screenHeight * 1 / 3);
            _health = 200;
        }


    }
}
