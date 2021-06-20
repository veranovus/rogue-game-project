using System;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public abstract class Scene{

		// Properties
		public int sceneId;


		// Constructor
		public Scene(SceneId sceneId) {

			// Set scene id
			this.sceneId = (int)sceneId;
		}


		// Init
		public abstract void Init();

		// Update
		public abstract void Update(GameTime gameTime);

		// Draw
		public abstract void Draw(GameTime gameTime);		
	}
}