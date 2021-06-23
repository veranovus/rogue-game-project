using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RogueGame{

	public class Grid<TGridObject>{

		// Dimensions
		public Vector2 position;
		public int width, height;
		public int gridSize;

		// Properties
		public TGridObject[,] gridArr; 


		// Constructor
		public Grid(Vector2 position, int width, int height, int gridSize){

			// Dimensions
			this.position = position;
			this.width = width;
			this.height = height;
			this.gridSize = gridSize;

			// Properties
			gridArr = new TGridObject[width, height];
		}
	}
}