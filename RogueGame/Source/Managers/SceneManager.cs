using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public static class SceneManager{

		// Properties
		public static Scene[] scenes;
		public static int currentScene;


		// Initialize the SceneManager. Don't call this method during
		// runtime, call this function only once from the Init method
		// of the Game1 class before calling any other method from this.
		public static void Init(){

			// Set the scenes array
			scenes = new Scene[5];

			// Set current scene to default
			currentScene = -1;
		}


		// Set the current scene
		public static void SetScene(SceneId sceneId){

			currentScene = (int)sceneId;
		}


		// Add a new scene to scenes array
		public static void AddScene(Scene scene){

			scenes[scene.sceneId] = scene;
			scene.Init();
		}


		// Remove a scene from scenes array
		public static void RemoveScene(Scene scene){

			scenes[scene.sceneId] = null;
		}


		// Update the current scene
		public static void Update(GameTime gameTime){

			if (currentScene == -1) { return; }

			scenes[currentScene].Update(gameTime);
		}


		// Draw the current scene
		public static void Draw(GameTime gameTime){

			if (currentScene == -1) { return; }

			scenes[currentScene].Draw(gameTime);
		}
	}
}