using System;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public class SceneGame : Scene{

		// Game Camera
		public Camera gameCamera = new Camera(new Vector2(50, 50));


		// GameObject Manager
		ObjectManager objectManager = new ObjectManager();


		// Player
		public Player player;


		// Constructor
		public SceneGame(Game game, SceneId sceneId) : base(game, sceneId) {}


		// Initialize Scene
		public override void Init(){

			// Create GameObjects
			player = new Player(new Vector2(50, 50), GameInstance);

			// Add GameObjects to ObjectManager
			objectManager.AddObject(player);
		}


		// Update Scene
		public override void Update(GameTime gameTime){

			// Update Camera
			gameCamera.Update(player.Position);

            // Draw GameObjects
            objectManager.Update(gameTime);
		}


		// Draw Scene
		public override void Draw(GameTime gameTime){

			// Clear the Screen
			Graphics.Clear(Color.Black);

			// Begin
            Graphics._spriteBatch.Begin();

            // Draw GameObjects
            objectManager.Draw(gameTime);

			// End
			Graphics._spriteBatch.End();
		}
	}
}// transformMatrix: camera.Transform, samplerState: SamplerState.PointClamp