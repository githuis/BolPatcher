using System;
using System.Collections.Generic;
using System.Linq;

namespace BolPatcher
{
	public sealed class GameLibrary
	{
		public static GameLibrary Instance
		{
			get { return _instance ?? (_instance = new GameLibrary ()); }
		}

		private static GameLibrary _instance;

		private List<Game> _games;

		private GameLibrary ()
		{
			//Init list for storing games
			_games = new List<Game>();

			//TODO Load library from save if any
		}

		public void AddGame(string title, string path, string version)
		{
			if (GameExistsInLibrary (title))
				return;
			_games.Add (new Game (title, path, version));
            Console.WriteLine("Added a game");
		}

		public void RemoveGame(string title)
		{
			if (!GameExistsInLibrary (title))
				return;
			
			_games.Remove (FindGameInLibrary (title));
		}

		public bool GameExistsInLibrary(string title)
		{
			var game = _games.Where(x => x.Title == title);
			if (game != null)
				return true;
			return false;
		}

		public Game FindGameInLibrary(string title)
		{
			return (Game) _games.First(x => x.Title == title);
		}
			
	}
}