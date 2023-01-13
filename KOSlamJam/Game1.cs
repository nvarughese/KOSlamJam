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

        // why does the active character start off as dark, weird as you can still move
        public static string _activeCharacter = "wrestler";

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

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

            _sprites = new List<Sprite>();

            Wrestler wrestler   = new Wrestler(_wrestlerTexture, ScreenWidth, ScreenHeight);
            Graffiti graffiti   = new Graffiti(_graffitiTexture, ScreenWidth, ScreenHeight);
            Thor thor           = new Thor(_thorTexture, ScreenWidth, ScreenHeight);
            Baddy baddy1        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight);
            Baddy baddy2        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight);
            Baddy baddy3        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight);
            Baddy baddy4        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight);
            Baddy baddy5        = new Baddy(_baddyTexture, ScreenWidth, ScreenHeight);
            _sprites.Add(wrestler);
            _sprites.Add(graffiti);
            _sprites.Add(thor);
            _sprites.Add(baddy1);
            _sprites.Add(baddy2);
            _sprites.Add(baddy3);
            _sprites.Add(baddy4);
            _sprites.Add(baddy5);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _currentKey = Keyboard.GetState();
            // move the farmer using the arrow keys
            if (_currentKey.IsKeyDown(Keys.Space) && !_previousKey.IsKeyDown(Keys.Space))
            {
                if (_activeCharacter == "wrestler"){ _activeCharacter = "graffiti"; }
                else if (_activeCharacter == "graffiti") { _activeCharacter = "thor"; }
                else if (_activeCharacter == "thor") { _activeCharacter = "wrestler"; }
            }
            _previousKey = _currentKey;
            foreach (Sprite sprite in _sprites)
            {
                sprite.Update(gameTime, _activeCharacter);
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
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


/*
 * todo
 * 
 * add in some baddies
 * make the baddies go gradually to the active characters
 * on connection reduce character health and make the character red colour
 * 
 * think about solidness, make character bounce off each other
 * also think about layering, show characters lower in the screen above higher characters
 * 
 * add in music
 * 
 * add in animation
 * 
 * do a display for health and time
 * make the display look nice, do bars for health and nicer timer in the box
 * 
 */