#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SmokeAndInterpolation.View;

#endregion

namespace SmokeAndInterpolation.Model
{
	public class SmokeParticle
	{
		/**
		 * 1.0f is the size of the sizeOfWindow in the Camera class.
		 */
		private float size = 0.02f;

		public SmokeParticle(Random random)
		{
			
		}

		public void Draw(Camera camera, Texture2D particlesmoke, SpriteBatch spriteBatch)
		{
			int particleTextureWidth = particlesmoke.Bounds.Width;
			int particleTextureHeight = particlesmoke.Bounds.Height;

			// Sets the displacement to the center of the texture
			Vector2 smokeTextureCenterDisplacement = new Vector2 ((float)particleTextureWidth / 2, (float)particleTextureHeight / 2);

			// Sets the scale of the the texture independently of the resolution 
			Vector2 scale = camera.GetVisualParticleScale (particleTextureWidth, particleTextureHeight, this.size);

			spriteBatch.Draw (particlesmoke, camera.GetVisualCoordinates (0, 0.45f) 
				- smokeTextureCenterDisplacement * scale, 
				null, Color.White, 0f, Vector2.Zero, scale, 
				SpriteEffects.None, 0f);
		}
	}
}

