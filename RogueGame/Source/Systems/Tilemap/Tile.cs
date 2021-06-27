using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueGame {

    public class Tile{

        // Dimensions
        public Vector2 position;
        public int tileSize;
        private Rectangle tileRect;

        // Properties
        public int tileIndex;
        public bool obstacle;

        // Sprite
        private Texture2D tilesetSprite;
        private Rectangle drawRect;


        // Constructor
        public Tile(Texture2D tilesetSprite, Vector2 position,
            int tileSize, bool obstacle){

            // Dimensions
            this.position = position;
            this.tileSize = tileSize;
            tileRect = new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);

            // Properties
            this.obstacle = obstacle;

            // Sprite
            this.tilesetSprite = tilesetSprite;
            SetTileTexture();
        }


        // Draw the tile
        public void DrawTile() {

            Graphics._spriteBatch.Draw(tilesetSprite, tileRect, drawRect, Color.White);
        }


        // Set the tile's TileSprite
        public void SetTileTexture() {

            if (!obstacle){

                drawRect = new Rectangle(0, 0, 32, 32);
            }
            else{

                drawRect = new Rectangle(32, 0, 32, 32);
            }
        }
    }
}