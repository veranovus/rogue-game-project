using System;
using Microsoft.Xna.Framework;

namespace RogueGame {

    public class PrimitiveGrid<TGridObject> {

        // Dimensions
        public Vector2 position;
        public int width, height;
        public int gridSize;

        // Properties
        public TGridObject[,] gridArr;


        // Constructor
        public PrimitiveGrid(Vector2 position, int width, int height, int gridSize) {

            // Dimensions
            this.position = position;
            this.width = width;
            this.height = height;
            this.gridSize = gridSize;

            // Properties
            gridArr = new TGridObject[width, height];
        }


        // Change the value of a TGridObject in gridArr
        public void SetGrid(int x, int y, TGridObject T) {

            if ((x < 0 || x >= width) || (y < 0 || y >= height)) { return; }

            gridArr[x, y] = T;
        }


        // Get a grid by x and y cordinates in gridArr
        public TGridObject GetGrid(int x, int y) {

            if ((x >= 0 && x < width) && (y >= 0 && y < height)) {

                return gridArr[x, y];
            }

            return default;
        }


        // Get a grid by its world positions
        public TGridObject GetGridByWorldPos(float x, float y) {

            int gridX = (int)MathF.Floor((x - position.X) / gridSize);
            int gridY = (int)MathF.Floor((y - position.Y) / gridSize);

            if ((gridX >= 0 && gridX < width) && (gridY >= 0 && gridY < height)) {

                return gridArr[gridX, gridY];
            }

            return default;
        }
    }
}
