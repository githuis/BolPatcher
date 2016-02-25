using System;

namespace BolPatcher
{
	public class Game
	{
		private string _path;
		private string _version;
		private string _hostPath;

		public string Title {
			get;
			private set;
		}

		public Game (string title, string path, string version, string hostPath)
		{
			Title = title;
			_path = path;
			_hostPath = hostPath;
			_version = version;
		}

		public bool CompareVersion(string hostVersion)
		{
			return (_version == hostVersion);
		}

		public override string ToString ()
		{
			string s = (Title + " - Version: " + _version).Replace('\n', ' ');
			return s;
		}
	}
}