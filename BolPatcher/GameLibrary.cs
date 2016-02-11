using System;
using System.Collections.Generic;

namespace BolPatcher
{
	public class GameLibrary
	{
		private List<Game> _games;		
		public GameLibrary ()
		{
			//Init list for storing games
			_games = new List<Game>();

			//TODO Load library from save if any
		}

		~GameLibrary ()
		{
			//TODO Save games to save file
		}

		public void AddGame(string title, string path, string version)
		{
			//TODO check if game with name already exists
			_games.Add (new Game (title, path, version));
		}

		public void RemoveGame(string title)
		{
			
		}
	}
}