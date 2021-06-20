using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RogueGame{

	public static class InputHandler{

		// Input Pools
		private static KeyboardState keyboardState;
		private static MouseState mouseState;


		// Update InputHandler
		public static void Update(){

			// Update keyboard state
			keyboardState = Keyboard.GetState();

			// Update mouse state
			mouseState = Mouse.GetState();
		}


		// Get Keyboard State
		public static KeyboardState GetKeyboardState(){

			return keyboardState;
		}


		// Get Mouse State
		public static MouseState GetMouseState(){

			return mouseState;
		}
	}
}