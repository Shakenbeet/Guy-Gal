using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace GuyAndGal
{
    class Menu : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        private Texture2D menu;
        private Song theme;

        public Menu(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            base.LoadContent();
            menu = Game.Content.Load<Texture2D>("menuLogo");
            theme = Game.Content.Load<Song>("HatInTimeTheme");
            MediaPlayer.Play(theme);
            MediaPlayer.Volume = 0.1f;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Enter))
                Game.LoadLevel();

        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            Game._spriteBatch.Begin();
            Game._spriteBatch.Draw(menu, new Vector2(Game._graphics.PreferredBackBufferWidth / 2, Game._graphics.PreferredBackBufferHeight / 2), null, Color.White, 0f, new Vector2(menu.Width / 2, menu.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            Game._spriteBatch.End();
        }
    }
}
