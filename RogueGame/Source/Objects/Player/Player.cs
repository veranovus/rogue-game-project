using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame{

	public class Player : GameObject{

		// Properties


		// Movement
		public const int TileSize = 50;


		// Input
		KeyboardState keyboardState;


		// Sprite
		private Texture2D playerSprite;


		public Player(Vector2 position, Game game) : base(position.X, position.Y, TileSize, TileSize, ObjectTag.Player, game) { }


        // Load Sprites and Other Content
        protected override void LoadContent(){

			playerSprite = GameHolder.GameInstance.Content.Load<Texture2D>("Player/player_fighter");
        }


        public override void Init(){

		}


		public override void Destroy(){

			Console.WriteLine("Player being destroyed.");
		}


		public override void Update(GameTime gameTime){

			// Handle Imput
			HandleInput();
		}


		public override void Draw(GameTime gameTime){

			// Draw the player sprite
			if (playerSprite == null) return;
			Graphics._spriteBatch.Draw(playerSprite, rect, Color.White);
		}


		private void HandleInput(){

			// Get keyboard input from InputHandler
			keyboardState = InputHandler.GetKeyboardState();

			// Movement
			if (keyboardState.IsKeyDown(Keys.W)) { y -= TileSize; }
			if (keyboardState.IsKeyDown(Keys.S)) { y += TileSize; }
			if (keyboardState.IsKeyDown(Keys.A)) { x -= TileSize; }
			if (keyboardState.IsKeyDown(Keys.D)) { x += TileSize; }
		}
	}
}