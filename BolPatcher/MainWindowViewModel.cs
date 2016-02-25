using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BolPatcher
{
	public class MainWindowViewModel
	{
        public GameLibrary lib;

		private string _gameListString;
		public string GameListString
		{
			get { return _gameListString; }
			set {
				_gameListString = value;
			}
		}


		public IReadOnlyList<Game> GameList = GameLibrary.Instance.Games;

		public MainWindowViewModel ()
		{
			lib = GameLibrary.Instance;
        }

		public Game LoadGame(string title)
		{
			if (GameLibrary.Instance.GameExistsInLibrary(GameLibrary.Instance.FindGameInLibrary(title)))
				throw new ArgumentException ();
			return GameLibrary.Instance.FindGameInLibrary (title);
		}

	}
}

