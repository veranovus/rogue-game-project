using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame{

	public class Player : GameObject{

		// Properties
		public int maxHealth = 100;
		public int currentHealth;

        // Children 
        public HealthBar healthBar;

		// Movement
		public const int TileSize = 32;
		private float movementCooldown = 0.15f;
		private float movementTimer;

		// Input
		KeyboardState keyboardState;

		// Sprite
		private Texture2D playerSprite;


		// Constructor
		public Player(Vector2 position, Game game) : base(position.X, position.Y, TileSize, TileSize, ObjectTag.Player, game) { }


        // Load Sprites and Other Content
        protected override void LoadContent(){

			playerSprite = GameHolder.GameInstance.Content.Load<Texture2D>("Player/player_sprite");
        }


        public override void Init(){

        	// Properties
        	currentHealth = maxHealth;

        	// Initialize Children
            healthBar = new HealthBar(this, Position);
		}


		public override void Destroy(){

			Console.WriteLine("Player being destroyed.");
		}


		public override void Update(GameTime gameTime){

			// Handle Imput
			HandleInput(gameTime);
		}


		public override void Draw(GameTime gameTime){

			// Draw the player sprite
			if (playerSprite == null) return;
			Graphics._spriteBatch.Draw(playerSprite, rect, Color.White);

			// Draw the HealthBar
			healthBar.Draw();
		}


		private void HandleInput(GameTime gameTime){

			// Get keyboard input from InputHandler
			keyboardState = InputHandler.GetKeyboardState();

			// Update the movement Timer;
			movementTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

			// Movement
			if (keyboardState.IsKeyDown(Keys.W)) { Move('y', -1); }
			if (keyboardState.IsKeyDown(Keys.S)) { Move('y', +1); }
			if (keyboardState.IsKeyDown(Keys.A)) { Move('x', -1); }
			if (keyboardState.IsKeyDown(Keys.D)) { Move('x', +1); }
		}


		private void Move(char axis, int direction){

			if ((movementTimer < movementCooldown)) { return; } 

			if (axis == 'x'){

				x += direction * TileSize;
			}
			else if (axis == 'y'){

				y += direction * TileSize;
			}

			// Reset the timer
			movementTimer = 0;

			// Update the HealthBar Position
			healthBar.UpdatePosition(Position);
		}


		private void TakeDamage(int value){

			currentHealth -= value;

			// Update healthbar to show correct health
			healthBar.UpdateHealthBar(maxHealth, currentHealth);
		}
	}
}
