#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

#endregion

namespace Chess
{
	class GameView
	{
		SpriteBatch spriteBatch;
		Texture2D chessTexture;

		// Coordinates in the sprite sheet
		Rectangle blackBrick = new Rectangle (0,0,64,64);
		Rectangle whiteBrick = new Rectangle (64,0,64,64);
		Rectangle piece = new Rectangle (128,0,64,64);

		GameModel model;
		Camera camera;

		public GameView(GameModel model, ContentManager content, GraphicsDevice device) 
		{
			this.model = model;
			chessTexture = content.Load<Texture2D> ("chess-sprite.png");
			spriteBatch = new SpriteBatch (device);
			camera = new Camera ();
		}

		public void DrawGame(GraphicsDevice device) 
		{
			
			spriteBatch.Begin();

			Vector2 scale = camera.getScale(device);
			//camera.setBorderSize ();
			//camera.setSizeOfTile ();

			// Draw white bricks
			for (int x = 0; x < 8; x += 1) {
				int a = 0;
				if (x % 2 == 1) {
					a = 1;
				}
					
				for (int y = a; y < 8; y += 2) {
					spriteBatch.Draw (chessTexture, camera.getVisualCoordinates (x, y), whiteBrick, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
					//spriteBatch.Draw (chessTexture, camera.getVisualCoordinates(x, y), whiteBrick, Color.White);
				}

			}
			// Draw black bricks
			for (int x = 0; x < 8; x += 1) {
				int a = 0;
				if (x % 2 == 0) {
					a = 1;
				}

				for (int y = a; y < 8; y += 2) {
					spriteBatch.Draw (chessTexture, camera.getVisualCoordinates (x, y), blackBrick, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
					//spriteBatch.Draw (chessTexture, camera.getVisualCoordinates(x, y), blackBrick, Color.White);
				}

			}



			// Normal camera view
			spriteBatch.Draw (chessTexture, camera.getVisualCoordinates (2,3), piece, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

			// Rotaded camera view
			spriteBatch.Draw (chessTexture, camera.getRotatedCameraView (2,3), piece, Color.White, 0, new Vector2(0,0), scale, SpriteEffects.None, 0);

			spriteBatch.End ();
		}
	}

}

