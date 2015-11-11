#region Using Statements
using System;
using BallBox.Model;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

#endregion

namespace BallBox.View
{
	class BallView : BallSimulation
	{
		Camera camera;

		public BallView() 
		{
			camera = new Camera ();
		}
	}

}

