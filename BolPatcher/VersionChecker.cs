using System;

namespace BolPatcher
{
	public class VersionChecker
	{
		private string _localPath;

		public VersionChecker ()
		{
			
		}

		public void SetLocalPath(string path)
		{
			_localPath = path;
		}

		public string GetLocalVersion()
		{
			return _localPath;
		}

		public string GetHostVersion()
		{
			return "";
		}
			
		public bool VersionsMatch()
		{
			return false;
		}

	}
}