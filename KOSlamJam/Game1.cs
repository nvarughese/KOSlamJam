using KOSlamJam.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace KOSlamJam
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardState _previousKey;
        private KeyboardState _currentKey;

        private List<Sprite> _sprites;
        private Texture2D _wrestlerTexture;
        private Texture2D _graffitiTexture;
        private Texture2D _thorTexture;
        private Texture2D _baddyTexture;

        private SpriteFont _healthFont;
        private SpriteFont _bigFont;

        private bool _gameOver;

        public static string _activeCharacter = "wrestler";

        public static int ScreenWidth = 1350;
        public static int ScreenHeight = 900;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            this.Window.AllowUserResizing = false;
            this.Window.Title = "KO Slam Jam";
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _wrestlerTexture = Content.Load<Texture2D>("Wrestler_v1");
            _graffitiTexture = Content.Load<Texture2D>("Graffiti_v1");
            _thorTexture = Content.Load<Texture2D>("Thor_v1");
            _baddyTexture = Content.Load<Texture2D>("Baddy_v1");
            _healthFont = Content.Load<SpriteFont>("health font");
            _bigFont = Content.Load<SpriteFont>("big font");

            _sprites = new List<Sprite>();

            Wrestler wrestler   = new Wrestler(_wrestlerTexture, ScreenWidth, ScreenHeight, _healthFont);
            Graffiti graffiti   = new Graffiti(_graffitiTexture, ScreenWidth, ScreenHeight, _healthFont);
            Thor thor           = new Thor(_thorTexture, ScreenWidth, ScreenHeight, _healthFont);
            Baddy baddy1        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight, _healthFont);
            Baddy baddy2        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight, _healthFont);
            Baddy baddy3        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight, _healthFont);
            Baddy baddy4        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight, _healthFont);
            Baddy baddy5        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight, _healthFont);
            _sprites.Add(wrestler);
            _sprites.Add(graffiti);
            _sprites.Add(thor);
            _sprites.Add(baddy1);
            _sprites.Add(baddy2);
            _sprites.Add(baddy3);
            _sprites.Add(baddy4);
            _sprites.Add(baddy5);
            _gameOver = false;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // if game over then check for an enter press and reset
            if (_gameOver)
            {
                _currentKey = Keyboard.GetState();
                if (_currentKey.IsKeyDown(Keys.Enter))
                {
                    foreach (Sprite sprite in _sprites)
                    {
                        sprite.Reset();
                    }
                    _activeCharacter = "wrestler";
                    _gameOver = false;
                }
                else
                {
                    base.Update(gameTime);
                    return;
                }
            }
            float wrestlerHealth = 0;
            float graffitiHealth = 0;
            float thorHealth = 0;
            foreach (Sprite sprite in _sprites)
            {
                if (sprite._type == "wrestler") { wrestlerHealth = sprite._health; }
                else if (sprite._type == "graffiti") { graffitiHealth = sprite._health; }
                else if (sprite._type == "thor") { thorHealth = sprite._health; }
            }
            if (wrestlerHealth + graffitiHealth + thorHealth <= 0) 
            {
                _gameOver = true;
                base.Update(gameTime);
                return;
            }

            _currentKey = Keyboard.GetState();
            if (_currentKey.IsKeyDown(Keys.Space) && !_previousKey.IsKeyDown(Keys.Space))
            {
                if (_activeCharacter == "wrestler") { _activeCharacter = graffitiHealth > 0 ? "graffiti" : "thor"; }
                else if (_activeCharacter == "graffiti") { _activeCharacter = thorHealth > 0 ? "thor" : "wrestler"; }
                else if (_activeCharacter == "thor") { _activeCharacter = wrestlerHealth > 0 ? "wrestler" : "graffiti"; }
            }
            else
            {
                if (_activeCharacter == "wrestler") { _activeCharacter = wrestlerHealth > 0 ? "wrestler" : (graffitiHealth > 0 ? "graffiti" : "thor"); }
                else if (_activeCharacter == "graffiti") { _activeCharacter = graffitiHealth > 0 ? "graffiti" : (thorHealth > 0 ? "thor" : "wrestler"); }
                else if (_activeCharacter == "thor") { _activeCharacter = thorHealth > 0 ? "thor" : (wrestlerHealth > 0 ? "wrestler" : "graffiti"); }
            }
            _previousKey = _currentKey;
            foreach (Sprite sprite in _sprites)
            {
                sprite.Update(gameTime, _activeCharacter, _sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Sprite sprite in _sprites)
            {
                sprite.Draw(_spriteBatch, _activeCharacter);
            }
            if (_gameOver)
            {
                _spriteBatch.DrawString(_bigFont, "Game Over", new Vector2(ScreenWidth / 8, ScreenHeight / 3), Color.Red);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


/*
 * todo
 * 
 * baddies
 *      - make the baddies go gradually to the active characters
 *      
 * collisions     
 *      - fix up dead characters so you rotate over non dead ones
 *      - make the character red when there is a collision
 *      - make character dark red when dead and not moving
 *      - make health into a bar
 * 
 * think about solidness, make character bounce off each other
 * also think about layering, show characters lower in the screen above higher characters
 * 
 * music
 * 
 * animation
 * 
 * screens and menus
 *      - make intro screen
 *      - make death screen
 *      
 * 
 * 
 * 
 */