using System;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public class HealthBar{

		// Properties
		public GameObject attachedObject;

		// Dimensions
		public Vector2 position;
		public int width, height;
		public int currentWidth;


		// Constructor
		public HealthBar(GameObject parent, Vector2 position, int width=12, int height=2){

			// Properties
			attachedObject = parent;

			// Dimensions
			this.position = position;
			this.width = width;
			this.height = height;
			currentWidth = width;
		}


		public void Update(){

			// Update the position of the healthbar
			UpdatePosition();
		}


		public void Draw(){

			// Draw the healthbar
			Graphics.FillRect(new Rectangle((int)position.X, (int)position.Y, currentWidth, height), Color.Red, 0f);
		}


		// Update the HealthBar size
		public void UpdateHealthBar(float maxHealth, float currentHealth){

			float percentage = (currentHealth * 100) / maxHealth;

			currentWidth = (int)(width * (percentage / 100));
		}


		private void UpdatePosition(){

			position.X = attachedObject.Position.X + ((32 - width) / 2); // Additional value is used to center it
			position.Y = attachedObject.Position.Y + (4); // Additional value is margin
		}		
	}
}