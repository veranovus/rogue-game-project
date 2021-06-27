using System;
using Microsoft.Xna.Framework;

namespace RogueGame {

    public class AStarNode {

        // Dimensions
        public int x, y;

        // Properties
        public bool isWalkable;
        // Costs;
        public int hCost, gCost, fCost;
        public AStarNode parentNode;


        // Properties
        public AStarNode(int x, int y, bool isWalkable) {

            // Dimensions
            this.x = x;
            this.y = y;

            // Properties
            this.isWalkable = isWalkable;
        }


        // Prepare node to be used
        public void PrepareNode() {

            // SetCosts
            gCost = int.MaxValue;
            hCost = 0;
            SetFCost();

            // Set Parent to none
            parentNode = null;
        }


        // Set the FCost of this node
        public void SetFCost() {

            fCost = gCost + hCost;
        }


        // Get the World Coordinates of this node
        public Vector2 GetWorldPosition(Grid<AStarNode> parentGrid) {

            return parentGrid.GridToWorld(x, y);
        }
    }
}
