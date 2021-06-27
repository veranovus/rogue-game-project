using System;
using Microsoft.Xna.Framework;

namespace RogueGame {

    public class AStar {

        // Movement Costs
        public const int HORIZONTAL_MOVE = 10;
        public const int DIAGONAL_MOVE = 14;

        // Dimensions
        public Vector2 position;
        public int width, height;
        public int gridSize;

        // Properties
        Grid<AStarNode> aStarGrid;


        // Constructor
        public AStar(Vector2 position, int width, int height, int gridSize) {

            // Dimensions
            this.position = position;
            this.width = width;
            this.height = height;
            this.gridSize = gridSize;

            // Properties
            // Initialie AStarGrid
            aStarGrid = new Grid<AStarNode>(position, width, height, gridSize,
                (Grid<AStarNode> grid, int x, int y, bool obstacle) => new AStarNode(x, y, obstacle));
        }
    }
}
