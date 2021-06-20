using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RogueGame
{
    public class Game1 : Game{

        // Debug Mode Toggle
        public static bool Debug = true;

        // Scenes
        public SceneGame sceneGame = new SceneGame(SceneId.Game); 


        public Game1(){

            // Set GameHolder's Game instance
            GameHolder.GameInstance = this;

            // Initialize Graphics
            Graphics.Init();

            Content.RootDirectory = "Content";
        }


        protected override void Initialize(){

            // Initialize Screen
            Graphics._InitScreen();

            // Window
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            Window.Title = Graphics.GameTitle;


            // Initialize SceneManager
            SceneManager.Init();

            // Initialize and Add Scenes to SceneManager
            SceneManager.AddScene(sceneGame);
            // Set the Starting Scene
            SceneManager.SetScene(SceneId.Game);

            base.Initialize();
        }


        protected override void LoadContent(){

            // Init Sprite Batch
            Graphics._CreateSpriteBatch();

            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime){

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update Graphics
            Graphics.Update(gameTime);
            // Set the title to show fps
            if (Debug) { Window.Title = Graphics.GameTitle + " - FPS : " + Convert.ToString((int)Graphics.fps); }
            
            // Update the current scene
            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime){

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the current scene
            SceneManager.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
