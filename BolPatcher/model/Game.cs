using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace BolPatcher.model
{
	public class Game
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; private set; }
		public string Title { get; set;}
		public string Path { get; set;}
		public string Version { get; set;}
		public string HostPath { get; set;}

		//http://stackoverflow.com/questions/240171/launching-a-application-exe-from-c
		public void Launch()
		{

			try 
			{
				
				ProcessStartInfo start = new ProcessStartInfo ();
				string filePattern = Title + ".*";
                string[] names = Directory.GetFiles(Path, filePattern);

				if(names.Length == 1)
				{
					File.SetAttributes(names[0], (FileAttributes)((int) File.GetAttributes(names[0]) | 0x80000000));
					start.FileName = names[0];
				}
				else if(names.Length < 1)
                {
                    throw new ArgumentNullException();

                }
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
					

					exitCode = proc.ExitCode;
				}
			} 
			//catch (ArgumentNullException ex)
			//{
			//	Console.WriteLine ("Error running application, see error msg below " + ex.GetType().ToString());
			//	Console.WriteLine (ex.Message);
			//}
            catch (Win32Exception ex)
            {
                Console.WriteLine("Attempted to run a non-windows application on windows.\nError message is: " + ex.Message);
            }

        }

		public bool CompareVersion(string hostVersion)
		{
			return (Version == hostVersion);
		}

		public override int GetHashCode ()
		{
			return (Title + Version).GetHashCode ();
		}

		public override string ToString ()
		{
			return (Title + " - Version: " + Version).Replace('\n', ' ');
		}
	}
}