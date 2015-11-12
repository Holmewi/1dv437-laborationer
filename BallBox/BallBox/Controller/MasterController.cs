#region Using Statements
using System;
using BallBox.Model;
using BallBox.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

#endregion

namespace BallBox.Controller
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MasterController : Game
	{
		GraphicsDeviceManager graphics; 

		private BallSimulation ballSimulation;
		private Camera camera;
		private BallView ballView;
		private BoxView boxView;

		public MasterController ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;

			this.ballSimulation = new BallSimulation ();
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here

			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 500;
			graphics.ApplyChanges();

			base.Initialize ();
				
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			//TODO: use this.Content to load your game content here
			this.camera = new Camera (GraphicsDevice);
			this.ballView = new BallView (ballSimulation, Content, GraphicsDevice, camera);
			this.boxView = new BoxView (ballSimulation, Content, GraphicsDevice, camera);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif

			// TODO: Add your update logic here
			//this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 1000.0f);

			this.ballSimulation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.ForestGreen);
		
			//TODO: Add your drawing code here
			this.ballView.DrawBall ();
			this.boxView.DrawBox ();
			base.Draw (gameTime);
		}
	}
}

