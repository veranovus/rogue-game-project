using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame{

	public class SceneGame : Scene{

		// Game Camera
		public Camera gameCamera = new Camera(new Vector2(50, 50));


		// GameObject Manager
		ObjectManager objectManager = new ObjectManager();


		// Player
		public Player player;


		// Tilemap
		public Tilemap tilemap;


		// Constructor
		public SceneGame(Game game, SceneId sceneId) : base(game, sceneId) {}


		// Initialize Scene
		public override void Init(){

			// Create GameObjects
			player = new Player(new Vector2(0, 0), GameInstance);

			// Create Tilemap
			tilemap = new Tilemap(GameInstance, new Vector2(0, 0), 20, 20, 32, "Tileset/tileset");

			// Add GameObjects to ObjectManager
			objectManager.AddObject(player);
		}


		// Update Scene
		public override void Update(GameTime gameTime){

			// Update Camera
			gameCamera.Update(player.GetCenteredPos());

            // Draw GameObjects
            objectManager.Update(gameTime);
		}


		// Draw Scene
		public override void Draw(GameTime gameTime){

			// Clear the Screen
			Graphics.Clear(Color.Black);

			// Begin
            Graphics._spriteBatch.Begin(transformMatrix: gameCamera.Transform, samplerState: SamplerState.PointClamp);

			// Draw Tilemap
			tilemap.DrawTileset();

            // Draw GameObjects
            objectManager.Draw(gameTime);

			// End
			Graphics._spriteBatch.End();
		}
	}
}