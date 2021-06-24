using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame{

	public class Tilemap : DrawableGameComponent {

		// Dimensions
		public Vector2 position;
		public int width, height;
		public int tileSize;

        // Texture
        private Texture2D tileset;

		// Properties
		public Grid<int> tileGrid;


		// Constructor
		public Tilemap(Game game, Vector2 position, int width, int height, int tileSize, string tileset) : base(game){

			// Dimensions
			this.position = position;
			this.width = width;
			this.height = height;
			this.tileSize = tileSize;

			// Texture
			this.tileset = game.Content.Load<Texture2D>(tileset);

			// Properties
			this.tileGrid = new Grid<int>(position, width, height, tileSize);
		}
	}
}