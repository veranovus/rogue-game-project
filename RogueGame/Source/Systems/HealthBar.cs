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
		private Rectangle bounds;


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


		public void Draw(){

			// If HealthBar's position is not equal to parent then return
			//if ((position.X - (32 - width) / 2) != attachedObject.Position.X) return;
			//else if ((position.Y + (4)) != attachedObject.Position.Y) return;

			// Draw the healthbar
			Graphics.FillRect(bounds, Color.Red, 0f);
		}


		// Update the HealthBar size
		public void UpdateHealthBar(float maxHealth, float currentHealth){

			float percentage = (currentHealth * 100) / maxHealth;

			currentWidth = (int)(width * (percentage / 100));
		}


		// Update the position of the HealthBar
		public void UpdatePosition(Vector2 position){

			this.position.X = position.X + ((32 - width) / 2); // Additional value is used to center it
			this.position.Y = position.Y - (2); // Additional value is margin

			// Set bounds
			bounds = new Rectangle((int)this.position.X, (int)this.position.Y, currentWidth, height);
		}		
	}
}