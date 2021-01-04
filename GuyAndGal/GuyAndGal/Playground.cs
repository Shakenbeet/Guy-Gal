using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace GuyAndGal
{
    class Playground : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        //dude's stuff
        Texture2D dude;
        Vector2 dudePosition;
        float dudeSpeed;

        //gal's stuff
        Texture2D gal;
        Vector2 galPosition;
        float galSpeed;

        //Extras
        private Song backMusic;

        public Playground(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            base.LoadContent();
            dude = Content.Load<Texture2D>("dude");
            gal = Content.Load<Texture2D>("gal");
            backMusic = Content.Load<Song>("back");
            MediaPlayer.Play(backMusic);
            MediaPlayer.Volume = 1f;

            dudePosition = new Vector2(Game._graphics.PreferredBackBufferWidth / 2,Game. _graphics.PreferredBackBufferHeight / 2 - 200);

            galPosition = new Vector2(Game._graphics.PreferredBackBufferWidth / 2, Game._graphics.PreferredBackBufferHeight / 2 + 200);

            dudeSpeed = 150f;
            galSpeed = 150f;
        }

        public override void Update(GameTime gameTime)
        {
            // controls
            #region dude
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
                dudePosition.Y -= dudeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.S))
                dudePosition.Y += dudeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.A))
                dudePosition.X -= dudeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.D))
                dudePosition.X += dudeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.LeftShift))
                dudeSpeed = 350;
            else
                dudeSpeed = 150;

            if (dudePosition.X > Game._graphics.PreferredBackBufferWidth - dude.Width / 2)
                dudePosition.X = Game._graphics.PreferredBackBufferWidth - dude.Width / 2;
            else if (dudePosition.X < dude.Width / 2)
                dudePosition.X = dude.Width / 2;

            if (dudePosition.Y > Game._graphics.PreferredBackBufferHeight - dude.Height / 2)
                dudePosition.Y = Game._graphics.PreferredBackBufferHeight - dude.Height / 2;
            else if (dudePosition.Y < dude.Height / 2)
                dudePosition.Y = dude.Height / 2;

            #endregion dude

            #region gal
            if (kstate.IsKeyDown(Keys.I))
                galPosition.Y -= galSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.K))
                galPosition.Y += galSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.J))
                galPosition.X -= galSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.L))
                galPosition.X += galSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.RightShift))
                galSpeed = 350;
            else
                galSpeed = 150;

            if (galPosition.X > Game._graphics.PreferredBackBufferWidth - gal.Width / 2)
                galPosition.X = Game._graphics.PreferredBackBufferWidth - gal.Width / 2;
            else if (galPosition.X < gal.Width / 2)
                galPosition.X = gal.Width / 2;

            if (galPosition.Y > Game._graphics.PreferredBackBufferHeight - gal.Height / 2)
                galPosition.Y = Game._graphics.PreferredBackBufferHeight - gal.Height / 2;
            else if (galPosition.Y < gal.Height / 2)
                galPosition.Y = gal.Height / 2;

            #endregion gal

            //cursor
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            Game._spriteBatch.Begin();

            //dude
            Game._spriteBatch.Draw(dude, dudePosition, null, Color.White, 0f, new Vector2(dude.Width / 2, dude.Height / 2), Vector2.One, SpriteEffects.None, 0f);

            //gal
            Game._spriteBatch.Draw(gal, galPosition, null, Color.White, 0f, new Vector2(gal.Width / 2, gal.Height / 2), Vector2.One, SpriteEffects.None, 0f);

            Game._spriteBatch.End();
        }
    }
}
