using System;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public abstract class Scene{

		// Properties
		public Game GameInstance;
		public int sceneId;


		// Constructor
		public Scene(Game game, SceneId sceneId) {

			// Set scene id
			this.GameInstance = game;
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