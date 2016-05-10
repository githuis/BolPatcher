using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

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
		public string GamesPath { get{ return Path + "/games";
			}}

		public PathController ()
		{
			Path = Directory.GetCurrentDirectory ();
			Directory.CreateDirectory (GamesPath);
		}

		/// <summary>
		/// Creates the game directory
		/// </summary>
		/// <returns>The path of the directory.</returns>
		/// <param name="title">Game title</param>
		public string CreateGameDir(string title)
		{
			string path = GamesPath + "/" + title;
			Directory.CreateDirectory (path);

			return path;

		}
			
		//https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples#-unpack-a-zip-with-full-control-over-the-operation
		public void Extract(string title)
		{
			ZipFile zf = null;

			try
			{
				MakeFolderWritable(System.IO.Path.Combine(GamesPath, title));
				FileStream fs = File.OpenRead( System.IO.Path.Combine(GamesPath, title, "gamedata.zip"));
				zf = new ZipFile(fs);

				foreach (ZipEntry zipEntry in zf)
				{
					//if(!zipEntry.IsFile) //Ignore directories
					//{
					//	continue;
					//}	

					String emptyFileName = zipEntry.Name;

					byte[] buffer = new byte[4096];
					Stream zipStream = zf.GetInputStream(zipEntry);

					String fullZipToPath = System.IO.Path.Combine(GamesPath, title, emptyFileName);

					//Console.WriteLine("Path list: " + GamesPath +"\n"+ GamesPath+title+"\n" + fullZipToPath);
					//String directoryName = System.IO.Path.GetDirectoryName(fullZipToPath);
					String directoryName = fullZipToPath;
					if(directoryName.Length > 0)
						Directory.CreateDirectory(directoryName);

					using (FileStream streamWriter = File.Create(fullZipToPath))
					{
						StreamUtils.Copy(zipStream, streamWriter, buffer);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine ("Failed to extract: " + ex.ToString() + " - " + ex.Message);
			}
			finally {
				if (zf != null) {
					zf.IsStreamOwner = true;
					zf.Close ();
				}
			}
		}

		private void MakeFolderWritable(string folder)
		{
			System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(folder);
			oDir.Attributes = System.IO.FileAttributes.Normal;

		}
	}
}