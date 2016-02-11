using System;

namespace BolPatcher
{
	public class Game
	{
		private string _path;
		private string _version;

		public string Title {
			get;
			private set;
		}

		public Game (string title, string path, string version)
		{
			Title = title;
			_path = path;
			_version = version;
		}

		public bool CompareVersion(string hostVersion)
		{
			return (_version == hostVersion);
		}

	}
}

