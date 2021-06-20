using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame {

	public static class Graphics{

		// Game Reference
		private static Game g;

		// Graphics
		public static GraphicsDeviceManager _graphics;
		public static SpriteBatch _spriteBatch;

		// Screen
		public static int ScreenWidth 	{ get; private set; }
		public static int ScreenHeight  { get; private set; }
		public static bool VSync 		{ get; private set; }
		public static string GameTitle = "Rogue Clone";

		// Dummy Texture
		private static Texture2D rect;

		// Gametime
		public static float fps, deltaTime;


		// Initialize the static Graphics class
		public static void Init(){

			// Set screen size
			ScreenWidth  = 800;
			ScreenHeight = 600;

			// Set Game Instance
			g = GameHolder.GameInstance;

			// Init Graphics
			_graphics = new GraphicsDeviceManager(GameHolder.GameInstance); 
		}


		// Don't call this method
		public static void _InitScreen(){

			// Init Graphics
			_graphics.PreferredBackBufferWidth = ScreenWidth;
			_graphics.PreferredBackBufferHeight = ScreenHeight;
			_graphics.SynchronizeWithVerticalRetrace = VSync;
			_graphics.ApplyChanges();
		}


		// Don't call this method
		public static void _CreateSpriteBatch(){

			_spriteBatch = new SpriteBatch(GameHolder.GameInstance.GraphicsDevice);
		}


		// Update
		public static void Update(GameTime gt){

			// Update the current fps
			deltaTime = (float)gt.ElapsedGameTime.TotalSeconds;
			fps = 1 / deltaTime;
		}


		// Clear the screen with a given color
		public static void Clear(Color color){

			GameHolder.GameInstance.GraphicsDevice.Clear(color);
		}


		// Draw a text in the middle of a rectangle
        public static void DrawCenteredText(Rectangle bounds, SpriteFont font, string text, Color color){
            Vector2 textSize = font.MeasureString(text);

            float xMargin = (bounds.Size.X - textSize.X);
            float yMargin = (bounds.Size.Y - textSize.Y);

            _spriteBatch.DrawString(font, text, new Vector2(bounds.X + xMargin / 2, bounds.Y + yMargin / 2), color);
        }


        // Draw a filled rectangle
        public static void FillRect(Rectangle bounds, Color color, float depth){

            if (rect == null) { rect = new Texture2D(g.GraphicsDevice, 1, 1); }

            rect.SetData(new[] { Color.White });
            _spriteBatch.Draw(rect, bounds, null, color, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }


        // Draw an empty rectangle
        public static void DrawEmptyRectamgle(Rectangle drawRect, int LineThickness, int RedValue, int GreenValue, int BlueValue){

            if (rect == null) { rect = new Texture2D(g.GraphicsDevice, 1, 1); }

            _spriteBatch.Draw(rect, new Rectangle(drawRect.Left - LineThickness, drawRect.Y, LineThickness, drawRect.Height),
                new Color((byte)RedValue, (byte)GreenValue, (byte)BlueValue, (byte)255));//This is the line on the Left

            _spriteBatch.Draw(rect, new Rectangle(drawRect.Right, drawRect.Y, LineThickness, drawRect.Height),
                new Color((byte)RedValue, (byte)GreenValue, (byte)BlueValue, (byte)255)); //This is the line on the Right

            _spriteBatch.Draw(rect, new Rectangle(drawRect.X, drawRect.Top - LineThickness, drawRect.Width, LineThickness),
                new Color((byte)RedValue, (byte)GreenValue, (byte)BlueValue, (byte)255)); //This is the line on the Top

            _spriteBatch.Draw(rect, new Rectangle(drawRect.X, drawRect.Bottom, drawRect.Width, LineThickness),
                new Color((byte)RedValue, (byte)GreenValue, (byte)BlueValue, (byte)255)); //This is the line on the Bottom
        }
	}
}