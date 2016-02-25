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

		public IReadOnlyList<Game> Games { get { return _games.AsReadOnly(); }}

		private GameLibrary ()
		{
			//Init list for storing games
			_games = new List<Game>();

			//TODO Load library from save if any
		}

		public void AddGame(string title, string path, string version, string hostPath)
		{
			Game g = new Game (title, path, version, hostPath);
			if (GameExistsInLibrary (g))
				return;
			_games.Add (g);
		}

		public void RemoveGame(Game g)
		{
			if (!GameExistsInLibrary (g))
				return;
			
			_games.Remove (FindGameInLibrary (g.Title));
		}

		public bool GameExistsInLibrary(Game g)
		{
			if (_games.Contains (g))
				return true;
			return false;
		}

		public Game FindGameInLibrary(string title)
		{
			return (Game) _games.First(x => x.Title == title);
		}
			
	}
}