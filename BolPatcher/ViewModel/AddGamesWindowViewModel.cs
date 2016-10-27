using System;
using System.IO;
using System.Text;
using BolPatcher.model;
using Gtk;

namespace BolPatcher.ViewModel
{
    public class AddGamesWindowViewModel
    {
		public event EventHandler ListChanged;
		private readonly WebHandler _webHandler;
		StringBuilder _sb;


		public AddGamesWindowViewModel()
		{
			_webHandler = new WebHandler ();
			_sb = new StringBuilder ();
		}

		public void AddGame(string hostPath)
		{
			string title = "Error finding title", version = "also error finding version";
			version =  _webHandler.GetVersion (hostPath);
			title = _webHandler.GetTitle (hostPath);

			if (GameLibrary.Instance.AddGame (title, GenerateGamePath(title), version, hostPath))
			{
				
				ListChanged?.Invoke (this, EventArgs.Empty);
				_webHandler.DownloadGameData (title, hostPath);
			}
		}

		private string GenerateGamePath(string title)
		{

            return Path.Combine(PathController.Instance.GamesPath, title);

			//sb.Clear ();
			//sb.Append (PathController.Instance.GamesPath).Append ("/").Append (title);
			//Console.WriteLine (sb.ToString ());
			//return sb.ToString ();
		}

		public void AddDownloadCompletedEvent(Button b)
		{
			_webHandler.AddDownloadCompletedEvent (b);
		}

    }
}