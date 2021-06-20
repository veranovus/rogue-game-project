using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public class ObjectManager{

		// Properties
		public List<GameObject> gameObjects;
		public int Count { get { return gameObjects.Count; } }	


		public ObjectManager(){

			// Initialize GameObject List
			gameObjects = new List<GameObject>();
		}


		// Call the update method of each object
		public void Update(GameTime gameTime){

			for (int i = 0; i < Count; i++){

				GameObject obj = gameObjects[i];

				if (obj.rendered){

					obj.SetBounds(obj.x, obj.y, obj.width, obj.height);
					obj.Update(gameTime);
				}
			}
		}


		// Call the draw method of each object
		public void Draw(GameTime gameTime){

			for (int i = 0; i < Count; i++){

				GameObject obj = gameObjects[i];

				if (obj.rendered && obj.visible){

					obj.Draw(gameTime);
				}
			}
		}
	}
}