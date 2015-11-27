#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Animation.Controller
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class AppController : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private View.Camera camera;
		private Model.ExplosionSystem model;
		private View.ExplosionView view;

		private const float MAX_TIMER = 0.2f;
		private float timer;

		public AppController ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			this.timer = MAX_TIMER;
			// TODO: Add your initialization logic here
			base.Initialize ();
				
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here
			this.camera = new View.Camera (GraphicsDevice);
			this.view = new View.ExplosionView (Content, GraphicsDevice, this.camera);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (this.timer < MAX_TIMER) {
				this.timer += elapsedTime;
			}
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			if (Keyboard.GetState ().IsKeyDown (Keys.Space)) {
				if(this.timer >= MAX_TIMER) {
					this.view.Start();
					this.timer = 0;
				}

			}
			#endif
					
			// TODO: Add your update logic here
			this.view.Update(elapsedTime);
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.White);
		
			//TODO: Add your drawing code here
			spriteBatch.Begin ();

			this.view.Draw (spriteBatch);

			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

