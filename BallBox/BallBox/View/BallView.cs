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


		public BallView(BallSimulation ballSimulation, ContentManager content, GraphicsDevice device, Camera camera) 
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			this.spriteBatch = new SpriteBatch (device);
			this.ballTexture = content.Load<Texture2D> ("ball.png");

			this.ballSimulation = ballSimulation;
			this.camera = camera;
		}

		public void DrawBall(GraphicsDevice device) 
		{
			// Sets the displacment to the center of the texture width and height
			Vector2 ballTextureDisplacement = new Vector2 ((float)ballTexture.Bounds.Width / 2, (float)ballTexture.Bounds.Height / 2);

			// Sets the scale of the the texture to 0.1 independent on the resolution 
			Vector2 scale = this.camera.getVisualBallScale (ballSimulation.getLogicBallRadius(), ballTexture.Bounds.Width, ballTexture.Bounds.Height);

			this.spriteBatch.Begin ();

			this.spriteBatch.Draw (ballTexture, camera.getVisualCoordinates (ballSimulation.getBallPositionX(), 
									ballSimulation.getBallPositionY()) - ballTextureDisplacement * scale, 
									null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

			this.spriteBatch.End ();
		}
	}

}

