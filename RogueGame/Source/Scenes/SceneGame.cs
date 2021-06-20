using System;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public class SceneGame : Scene{


		// Constructor
		public SceneGame(SceneId sceneId) : base(sceneId) {}


		// Initialize Scene
		public override void Init(){

		}


		// Update Scene
		public override void Update(GameTime gameTime){

		}


		// Draw Scene
		public override void Draw(GameTime gameTime){

			// Clear the Screen
			Graphics.Clear(Color.Black);

			// Begin
            Graphics._spriteBatch.Begin();

            // Draw stuff here ...

			// End
			Graphics._spriteBatch.End();
		}
	}
}// transformMatrix: camera.Transform, samplerState: SamplerState.PointClamp