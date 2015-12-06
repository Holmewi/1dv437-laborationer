#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace ActionsAndSound.Controller
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MasterController : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Model.BallSimulation ballSimulation;
		private View.Camera camera;
		private View.BallView ballView;
		private View.BoxView boxView;

		public MasterController ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = true;

			this.ballSimulation = new Model.BallSimulation ();
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
			this.IsMouseVisible = true;

			graphics.PreferredBackBufferWidth = 1200;
			graphics.PreferredBackBufferHeight = 700;
			graphics.ApplyChanges();

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
			this.ballView = new View.BallView (Content, ballSimulation, camera);
			this.boxView = new View.BoxView (GraphicsDevice, camera);

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			if (Mouse.GetState().LeftButton == ButtonState.Pressed) {

				Model.Ball bubble = this.ballSimulation.CheckBubbleHit (this.camera.GetLogicCoordinates(Mouse.GetState().X, Mouse.GetState().Y));

				if(bubble != null) {
					this.ballView.BurstBubble(bubble.Position, bubble.Radius);
				}
			}
			#endif
			// TODO: Add your update logic here	
			this.ballSimulation.Update(elapsedTime);
			this.ballView.Update (elapsedTime);

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
			this.boxView.DrawBox (spriteBatch);
			this.ballView.DrawBall (spriteBatch);
			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

