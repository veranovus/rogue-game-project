using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame{

	public abstract class GameObject : DrawableGameComponent {

		// Dimensions
		public float x, y;
		public Vector2 Position { get { return new Vector2(x, y);} set { x = value.X; y = value.Y; }}
		public int width, height;
		public Rectangle rect;

		// Properties
		public int tag;
		public bool visible, rendered;
		public bool collision, hover;


		// Constructor
		public GameObject(float x, float y, int width, int height, ObjectTag tag, Game game) : base(game){

			// Dimensions
			this.x = x;
			this.y = y;
			this.width  = width;
			this.height = height;
			this.rect 	= new Rectangle((int)x, (int)y, width, height);

			// Properties
			this.tag  = (int)tag;
			visible   = true;
			rendered  = true;
			collision = false;
			hover 	  = false;

			// Load Content
			LoadContent();
		}


		// Initialize
		public abstract void Init();

		// Destroy
		public abstract void Destroy();

		// Update
		public override abstract void Update(GameTime gameTime);

		// Draw
		public override abstract void Draw(GameTime gameTime);


		// Set
		public void SetPosition(float x, float y) { this.x = x; this.y = y;}
		public void SetSize(int width, int height) { this.width = width; this.height = height; }
		public void SetBounds(float x, float y, int width, int height) { rect = new Rectangle((int)x, (int)y, width, height); }


		// Get
		public Vector2 GetCenteredPos() { return new Vector2(x + width / 2, y + height / 2); }
		public float DistanceTo(Vector2 pos) { return Vector2.Distance(Position, pos); }
	}
}