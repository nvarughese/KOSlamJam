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
        private Texture2D _wrestlerRight1Texture;
        private Texture2D _wrestlerRight2Texture;
        private Texture2D _wrestlerRight3Texture;
        private Texture2D _wrestlerRightAttackTexture;
        private Texture2D _wrestlerleft1Texture;
        private Texture2D _wrestlerleft2Texture;
        private Texture2D _wrestlerleft3Texture;
        private Texture2D _wrestlerleftAttackTexture;
        private Texture2D _graffitiRight1Texture;
        private Texture2D _graffitiRight2Texture;
        private Texture2D _graffitiRight3Texture;
        private Texture2D _graffitiRightAttackTexture;
        private Texture2D _graffitiLeft1Texture;
        private Texture2D _graffitiLeft2Texture;
        private Texture2D _graffitiLeft3Texture;
        private Texture2D _graffitiLeftAttackTexture;
        private Texture2D _thorRightTexture;
        private Texture2D _thorRightAttackTexture;
        private Texture2D _thorLeftTexture;
        private Texture2D _thorLeftAttackTexture;
        private Texture2D _baddyRight1Texture;
        private Texture2D _baddyRight2Texture;
        private Texture2D _baddyRightAttackTexture;
        private Texture2D _baddyRightFloorTexture;
        private Texture2D _baddyleft1Texture;
        private Texture2D _baddyleft2Texture;
        private Texture2D _baddyleftAttackTexture;
        private Texture2D _baddyleftFloorTexture;

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
            _wrestlerRight1Texture = Content.Load<Texture2D>("wrestler_right");
            _wrestlerRight2Texture = Content.Load<Texture2D>("wrestler_right2");
            _wrestlerRight3Texture = Content.Load<Texture2D>("wrestler_right3");
            _wrestlerRightAttackTexture = Content.Load<Texture2D>("wrestler_right_attack");
            _wrestlerleft1Texture = Content.Load<Texture2D>("wrestler_left");
            _wrestlerleft2Texture = Content.Load<Texture2D>("wrestler_left2");
            _wrestlerleft3Texture = Content.Load<Texture2D>("wrestler_left3");
            _wrestlerleftAttackTexture = Content.Load<Texture2D>("wrestler_left_attack");
            _graffitiRight1Texture = Content.Load<Texture2D>("graffiti_right");
            _graffitiRight2Texture = Content.Load<Texture2D>("graffiti_right2");
            _graffitiRight3Texture = Content.Load<Texture2D>("graffiti_right3");
            _graffitiRightAttackTexture = Content.Load<Texture2D>("graffiti_right_attack");
            _graffitiLeft1Texture = Content.Load<Texture2D>("graffiti_left");
            _graffitiLeft2Texture = Content.Load<Texture2D>("graffiti_left2");
            _graffitiLeft3Texture = Content.Load<Texture2D>("graffiti_left3");
            _graffitiLeftAttackTexture = Content.Load<Texture2D>("graffiti_left_attack");
            _thorRightTexture = Content.Load<Texture2D>("thor_right");
            _thorRightAttackTexture = Content.Load<Texture2D>("Thor_right_attack");
            _thorLeftTexture = Content.Load<Texture2D>("thor_left");
            _thorLeftAttackTexture = Content.Load<Texture2D>("Thor_left_attack");
            _baddyRight1Texture = Content.Load<Texture2D>("baddy_right");
            _baddyRight2Texture = Content.Load<Texture2D>("baddy_right2");
            _baddyRightAttackTexture = Content.Load<Texture2D>("baddy_right_attack");
            _baddyRightFloorTexture = Content.Load<Texture2D>("baddy_right_floor");
            _baddyleft1Texture = Content.Load<Texture2D>("baddy_left");
            _baddyleft2Texture = Content.Load<Texture2D>("baddy_left2");
            _baddyleftAttackTexture = Content.Load<Texture2D>("baddy_left_attack");
            _baddyleftFloorTexture = Content.Load<Texture2D>("baddy_left_floor");
            




        _healthFont = Content.Load<SpriteFont>("health font");
            _bigFont = Content.Load<SpriteFont>("big font");

            _sprites = new List<Sprite>();

            Wrestler wrestler   = new Wrestler(ScreenWidth, ScreenHeight, _healthFont,
                _wrestlerRight1Texture, _wrestlerRight1Texture, _wrestlerRight1Texture, _wrestlerRight1Texture,
                _wrestlerRight1Texture, _wrestlerRight1Texture, _wrestlerRight1Texture, _wrestlerRight1Texture);
            Graffiti graffiti   = new Graffiti(ScreenWidth, ScreenHeight, _healthFont,
                _graffitiRight1Texture, _graffitiRight2Texture, _graffitiRight3Texture, _graffitiRightAttackTexture,
                _graffitiLeft1Texture, _graffitiLeft2Texture, _graffitiLeft3Texture, _graffitiLeftAttackTexture);
            Thor thor           = new Thor(ScreenWidth, ScreenHeight, _healthFont,
                _thorRightTexture, _thorRightAttackTexture, _thorLeftTexture, _thorLeftAttackTexture);
            
            _sprites.Add(wrestler);
            _sprites.Add(graffiti);
            _sprites.Add(thor);
            for (int i = 1; i <= 4; i++)
            {
                _sprites.Add(new Baddy(ScreenWidth, ScreenHeight, _healthFont,
                    _baddyRight1Texture, _baddyRight2Texture, _baddyRightAttackTexture, _baddyRightFloorTexture,
                    _baddyleft1Texture, _baddyleft2Texture, _baddyleftAttackTexture, _baddyleftFloorTexture)
                    );
            }
            
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
 *      - make better baddy movement
 *      
 * collisions     
 *      - make the character red when there is a collision (1)
 *      - make health into a bar
 * 
 * solidness 
 *      - make character bounce off each other
 *      - make colision box only bottom part
 *      - make y movement slower than x movement
 *      - find a solution to layering, need to draw characters from top to bottom
 * 
 * music
 * 
 * animation
 *      - make a
 * 
 * screens and menus
 *      - make intro screen
 *      - make death screen
 *      
 * 
 * actual todo:
 * bring in all textures needed
 * put in animation for characters
 * add in attacks
 * fix collisions for attacks
 * 
 */