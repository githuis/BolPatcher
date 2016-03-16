using System;
using System.IO;

namespace BolPatcher
{
	public sealed class PathController
	{
		public static PathController Instance
		{
			get { return _instance ?? (_instance = new PathController ());}
		}

		private static PathController _instance;

		public string Path { get; private set;}
		public string GamesPath { get; private set;}

		public PathController ()
		{
			Path = Directory.GetCurrentDirectory ();
			GamesPath = Path + "/games";
			Directory.CreateDirectory (GamesPath);
		}

		public void CreateGameDir(string title)
		{
			Directory.CreateDirectory (GamesPath + "/" + title);
		}
	}
}