using System;
using System.Diagnostics;
using System.IO;

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


		//http://stackoverflow.com/questions/240171/launching-a-application-exe-from-c
		public void Launch()
		{

			try 
			{
				ProcessStartInfo start = new ProcessStartInfo ();
				string filePattern = Path.Combine(_path, Title + ".*");
				string[] names = System.IO.Directory.GetFiles(_path, filePattern);
				if(names.Length == 1)
					start.FileName = names[0];
				else if(names.Length < 1)
					throw new ArgumentNullException();
				else if(names.Length >= 2)
				{
					throw new NotImplementedException();
				}
				start.UseShellExecute = false;
				//start.WindowStyle = ProcessWindowStyle.Hidden;
				//start.CreateNoWindow = true;
				int exitCode;

				using (Process proc = Process.Start(start))
				{
					proc.WaitForExit ();

					exitCode = proc.ExitCode;
				}
			} 
			catch (Exception ex)
			{
				Console.WriteLine ("Error running application, see error msg below");
				Console.WriteLine (ex.Message);
			}

		}

		public bool CompareVersion(string hostVersion)
		{
			return (_version == hostVersion);
		}

		public override string ToString ()
		{
			return (Title + " - Version: " + _version).Replace('\n', ' ');
		}
	}
}