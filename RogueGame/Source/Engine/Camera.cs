using System;
using Microsoft.Xna.Framework;
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


		// Constructor
		public Camera(Vector2 pos) { Position = pos; }


		// Update
		public void Update(Vector2 playerPos){

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