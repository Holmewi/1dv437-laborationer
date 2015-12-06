#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ActionsAndSound.View
{
	class BallView
	{
		private List<View.GFX.BurstSystem> burstList = new List<View.GFX.BurstSystem>();
		private List<View.GFX.SplashSystem> splashList = new List<View.GFX.SplashSystem>();

		private Texture2D ballTexture;
		private Texture2D rainbowTexture;
		private Texture2D burstSpriteSheet;

		private Model.BallSimulation ballSimulation;
		private View.Camera camera;


		public BallView(ContentManager content, Model.BallSimulation ballSimulation, View.Camera camera) 
		{
			this.ballTexture = content.Load<Texture2D> ("bubble.png");
			this.rainbowTexture = content.Load<Texture2D> ("rainbow.png");
			this.burstSpriteSheet = content.Load<Texture2D> ("burst.png");

			this.ballSimulation = ballSimulation;
			this.camera = camera;
		}

		public void BurstBubble(Vector2 position, float radius)
		{
			this.burstList.Add(new View.GFX.BurstSystem (this.camera, position, radius, this.burstSpriteSheet));
			this.splashList.Add(new View.GFX.SplashSystem (this.camera, position, this.ballTexture, this.rainbowTexture));
		}

		public void Update(float elapsedTime)
		{
			foreach (View.GFX.BurstSystem burst in this.burstList.ToList()) {
				if (burst != null) {
					if (burst.IsDone ()) {
						this.burstList.Remove (burst);
					} else {
						burst.Update(elapsedTime);
					}
				}
			}

			foreach (View.GFX.SplashSystem splash in this.splashList.ToList()) {
				if (splash != null) {
					if (splash.IsDone ()) {
						this.splashList.Remove (splash);
					} else {
						splash.Update(elapsedTime);
					}
				}
			}
		}

		public void DrawBall(SpriteBatch spriteBatch) 
		{
			foreach (View.GFX.BurstSystem burst in this.burstList) {
				if (burst != null) {
					burst.Draw (spriteBatch);
				}
			}

			foreach (View.GFX.SplashSystem splash in this.splashList) {
				if (splash != null) {
					splash.Draw (spriteBatch);
				}
			}
				
			int ballTextureWidth = this.ballTexture.Bounds.Width;
			int ballTextureHeight = this.ballTexture.Bounds.Height;

			// Sets the displacment to the center of the texture width and height
			Vector2 ballTextureDisplacement = new Vector2 ((float)ballTextureWidth / 2, (float)ballTextureHeight / 2);

			foreach (Model.Ball ball in this.ballSimulation.Balls) {
				// Sets the scale of the the texture to a logic scale independently of the resolution
				float scale = this.camera.GetVisualScale (ball.Radius * 2, ballTextureWidth, ballTextureHeight);

				spriteBatch.Draw (ballTexture, this.camera.GetVisualCoordinates (ball.Position.X, 
					ball.Position.Y) - ballTextureDisplacement * scale, 
					null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

			}
		}
	}

}

