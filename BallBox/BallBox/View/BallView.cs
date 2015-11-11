#region Using Statements
using System;
using BallBox.Model;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

#endregion

namespace BallBox.View
{
	class BallView
	{
		SpriteBatch spriteBatch;
		Texture2D ballTexture;

		BallSimulation ballSimulation;
		Camera camera;


		public BallView(BallSimulation ballSimulation, ContentManager content, GraphicsDevice device) 
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (device);

			ballTexture = content.Load<Texture2D> ("ball.png");

			this.ballSimulation = ballSimulation;
			camera = new Camera ();
		}

		public void DrawBall(GraphicsDevice device) 
		{
			spriteBatch.Begin ();

			Vector2 ballPosition = new Vector2 (0,0);
			spriteBatch.Draw (ballTexture, ballPosition, null);

			spriteBatch.End ();
		}
	}

}

