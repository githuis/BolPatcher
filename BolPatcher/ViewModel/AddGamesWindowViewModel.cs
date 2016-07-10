using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolPatcher
{
    public class AddGamesWindowViewModel
    {
		public event EventHandler ListChanged;
		private WebHandler webHandler;
		StringBuilder sb;


		public AddGamesWindowViewModel()
		{
			webHandler = new WebHandler ();
			sb = new StringBuilder ();
		}

		public void AddGame(string hostPath)
		{
			string title = "Error finding title", version = "also error finding version";
			version =  webHandler.GetVersion (hostPath);
			title = webHandler.GetTitle (hostPath);

			if (GameLibrary.Instance.AddGame (title, GenerateGamePath(title), version, hostPath))
			{
				
				ListChanged?.Invoke (this, EventArgs.Empty);
				webHandler.DownloadGameData (title, hostPath);
			}
		}

		private string GenerateGamePath(string title)
		{

            return System.IO.Path.Combine(PathController.Instance.GamesPath, title);

			//sb.Clear ();
			//sb.Append (PathController.Instance.GamesPath).Append ("/").Append (title);
			//Console.WriteLine (sb.ToString ());
			//return sb.ToString ();
		}

		public void AddDownloadCompletedEvent(Gtk.Button b)
		{
			webHandler.AddDownloadCompletedEvent (b);
		}

    }
}