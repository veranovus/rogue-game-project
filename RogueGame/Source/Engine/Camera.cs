using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame{

	public class Camera{

		// Properties
		public Vector2 Position;
		public Matrix Transform { get; private set; }
		public bool lockPlayer = false;

		// Camera Zoom
		public float scale = 1f;
		private float maxZoom = 3f;
		private float minZoom = 0.75f;
		private Vector2 virtualCameraPos;
		// Mouse ScrollWheel
		private int postScrollWheelValue = 0;


		// Constructor
		public Camera(Vector2 pos) { Position = pos; }


		// Update
		public void Update(Vector2 playerPos){

			AdjustZoom();

			// Leave this at bottom of update
			UpdateCamera(playerPos);
		}


		// Update the camera properties
		private void UpdateCamera(Vector2 playerPos){

			if (lockPlayer){

				FollowPlayer(playerPos);
			}

			Transform = Matrix.CreateTranslation((int)-Position.X, -Position.Y, 0) * Matrix.CreateScale(scale);
		}


		// Follow the player
		private void FollowPlayer(Vector2 pos){

			// Move the camera to players position
			Position.X = ((pos.X) - (Graphics.ScreenWidth / 2) / scale);
			Position.Y = ((pos.Y) - (Graphics.ScreenHeight / 2) / scale);

			// Set virtual cameras position
			virtualCameraPos = pos;
		}


		private void AdjustZoom(){

			// Get mouse input from InputHandler
			MouseState mouseState = InputHandler.GetMouseState();

			if (mouseState.ScrollWheelValue != postScrollWheelValue){

				float change = mouseState.ScrollWheelValue - postScrollWheelValue;

				SetZoom(change);

				postScrollWheelValue = mouseState.ScrollWheelValue; 
			}
		}


		private void SetZoom(float value){

			// 0.75 is smoothing value
			scale += value * Graphics.deltaTime * 0.75f;

			if (scale > maxZoom) { scale = maxZoom; }
			else if (scale < minZoom) { scale = minZoom; }
		}


		// Set camera lock
		public void SetLockToPlayer(bool value){

			lockPlayer = value;
		}


		// Convert screen positions to world positions
        public Vector2 ScreenToWorld(float x, float y)
        {
            return Vector2.Transform(new Vector2(x, y), Matrix.Invert(Transform));
        }
	}
}