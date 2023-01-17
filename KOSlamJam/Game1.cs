using KOSlamJam.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace KOSlamJam
{
    public enum MovingDirection
    {
        Left,
        Still,
        Right
    }

    public enum CharacterType
    {
        Wrestler,
        Graffiti,
        Thor,
        Baddy
    }
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
        private Texture2D _wrestlerLeft1Texture;
        private Texture2D _wrestlerLeft2Texture;
        private Texture2D _wrestlerLeft3Texture;
        private Texture2D _wrestlerLeftAttackTexture;
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

        private float _gameTimer;
        private bool _gameOver;
        private float _gameWonTime;
        private bool _gameWon;

        private float _baddyTimer;
        private int _numberNewBaddys;

        private Color _backgroundColour;

        public static CharacterType _activeCharacter = CharacterType.Wrestler;

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
            _gameTimer = 0f;
            _gameWonTime = 120f;
            _backgroundColour = new Color(50, 50, 50);
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
            _wrestlerLeft1Texture = Content.Load<Texture2D>("wrestler_left");
            _wrestlerLeft2Texture = Content.Load<Texture2D>("wrestler_left2");
            _wrestlerLeft3Texture = Content.Load<Texture2D>("wrestler_left3");
            _wrestlerLeftAttackTexture = Content.Load<Texture2D>("wrestler_left_attack");
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

            ResetGame();
        }
        private void ResetGame() { 

            _sprites = new List<Sprite>();

            Wrestler wrestler   = new Wrestler(ScreenWidth, ScreenHeight, _healthFont,
                _wrestlerRight1Texture, _wrestlerRight2Texture, _wrestlerRight3Texture, _wrestlerRightAttackTexture,
                _wrestlerLeft1Texture, _wrestlerLeft2Texture, _wrestlerLeft3Texture, _wrestlerLeftAttackTexture);
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

            _activeCharacter = CharacterType.Wrestler;
            _gameOver = false;
            _gameWon = false;
            _gameTimer = 0f;
            _baddyTimer = 0f;
            _numberNewBaddys = 0;


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // if game over then check for an enter press and reset
            if (_gameOver || _gameWon)
            {
                _currentKey = Keyboard.GetState();
                if (_currentKey.IsKeyDown(Keys.Enter))
                {
                    ResetGame();
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
                if (sprite._type == CharacterType.Wrestler) { wrestlerHealth = sprite._health; }
                else if (sprite._type == CharacterType.Graffiti) { graffitiHealth = sprite._health; }
                else if (sprite._type == CharacterType.Thor) { thorHealth = sprite._health; }
            }
            if (wrestlerHealth + graffitiHealth + thorHealth <= 0) 
            {
                _gameOver = true;
                base.Update(gameTime);
                return;
            }
            if (_gameTimer > _gameWonTime)
            {
                _gameWon = true;
                base.Update(gameTime);
                return;
            }

            _baddyTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_baddyTimer > 5)
            {
                _numberNewBaddys++;
                for (int i = 1; i <= _numberNewBaddys; i++)
                {
                    _sprites.Add(new Baddy(ScreenWidth, ScreenHeight, _healthFont,
                        _baddyRight1Texture, _baddyRight2Texture, _baddyRightAttackTexture, _baddyRightFloorTexture,
                        _baddyleft1Texture, _baddyleft2Texture, _baddyleftAttackTexture, _baddyleftFloorTexture)
                        );
                }
                _baddyTimer = 0;
            }

            _currentKey = Keyboard.GetState();
            if (_currentKey.IsKeyDown(Keys.Space) && !_previousKey.IsKeyDown(Keys.Space))
            {
                if (_activeCharacter == CharacterType.Wrestler) { _activeCharacter = graffitiHealth > 0 ? CharacterType.Graffiti : CharacterType.Thor; }
                else if (_activeCharacter == CharacterType.Graffiti) { _activeCharacter = thorHealth > 0 ? CharacterType.Thor : CharacterType.Wrestler; }
                else if (_activeCharacter == CharacterType.Thor) { _activeCharacter = wrestlerHealth > 0 ? CharacterType.Wrestler : CharacterType.Graffiti; }
            }
            else
            {
                if (_activeCharacter == CharacterType.Wrestler) { _activeCharacter = wrestlerHealth > 0 ? CharacterType.Wrestler : (graffitiHealth > 0 ? CharacterType.Graffiti : CharacterType.Thor); }
                else if (_activeCharacter == CharacterType.Graffiti) { _activeCharacter = graffitiHealth > 0 ? CharacterType.Graffiti : (thorHealth > 0 ? CharacterType.Thor : CharacterType.Wrestler); }
                else if (_activeCharacter == CharacterType.Thor) { _activeCharacter = thorHealth > 0 ? CharacterType.Thor : (wrestlerHealth > 0 ? CharacterType.Wrestler : CharacterType.Graffiti); }
            }
            _previousKey = _currentKey;
            foreach (Sprite sprite in _sprites)
            {
                sprite._isHit = false;
            }
            foreach (Sprite sprite in _sprites)
            {
                sprite.Update(gameTime, _activeCharacter, _sprites);
            }
            _gameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_healthFont, "Controls: move=arrows, attack=z, transition character=space, survive " + ((int)_gameWonTime).ToString() + " seconds to win", new Vector2(0, 0), Color.Yellow);
            foreach (Sprite sprite in _sprites)
            {
                sprite.Draw(_spriteBatch, _activeCharacter);
            }
            _spriteBatch.DrawString(_bigFont, ((int)_gameTimer).ToString(), new Vector2(ScreenWidth * 4 / 9, 0), Color.Yellow);
            if (_gameWon)
            {
                _spriteBatch.DrawString(_bigFont, " You Win!!", new Vector2(ScreenWidth / 8, ScreenHeight / 3), Color.Yellow);
                _spriteBatch.DrawString(_bigFont, "Press Enter", new Vector2(ScreenWidth / 8, ScreenHeight * 2 / 3), Color.Yellow);
            }
            if (_gameOver)
            {
                _spriteBatch.DrawString(_bigFont, "Game Over", new Vector2(ScreenWidth / 8, ScreenHeight / 3), Color.Red);
                _spriteBatch.DrawString(_bigFont, "Press Enter", new Vector2(ScreenWidth / 8, ScreenHeight * 2 / 3), Color.Red);
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
 * end the game
 * fix baddy movement
 * 
 * 
 * 
 * 
 */