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
		public PrimitiveGrid<int> tileGrid;
		public Tile[,] tiles;


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
			tileGrid = new PrimitiveGrid<int>(position, width, height, tileSize);
			tiles = new Tile[width, height];

			// Create Tiles
			CreateTiles();
		}


		// Create tiles acording the collision grid
		public void CreateTiles() {

			for (int x = 0; x < tileGrid.width; x++) {

				for (int y = 0; y < tileGrid.height; y++) {

					// Calculate tile position
					Vector2 tilePos = new Vector2(
						position.X + (x * tileSize), position.Y + (y * tileSize));

					if (tileGrid.gridArr[x, y] == 0) {

						tiles[x, y] = CreateTile(tilePos, false);
                    }
					else {

						tiles[x, y] = CreateTile(tilePos, true);
					}
                }
            }
		}


		// Create new tile
		private Tile CreateTile(Vector2 position, bool obstacle) {

			return new Tile(tileset, position, tileSize, obstacle);
		}


		// Draw tileset
		public void DrawTileset() {

			for (int x = 0; x < width; x++) {

				for (int y = 0; y < height; y++) {

					tiles[x, y].DrawTile();
                }
            }
        }
	}
}