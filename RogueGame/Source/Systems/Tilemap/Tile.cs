using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame {

    public class Tile {

        // Dimensions
        public Vector2 position;
        public int tileSize;

        // Properties
        public int tileIndex;
        public bool obstacle;

        // Sprite
        private Texture2D tilesetSprite;


        // Constructor
        public Tile(Texture2D tilesetSprite, Vector2 position, int tileSize, bool obstacle) {

            // Dimensions
            this.position = position;
            this.tileSize = tileSize;

            // Properties
            this.obstacle = obstacle;

            // Sprite
            this.tilesetSprite = tilesetSprite;
        }


        public void DrawTile() {

            // Draw the tile here
        }


        public void SetTileTexture() {

            // Set the tile texture here after the dungeon is generated
        }
    }
}