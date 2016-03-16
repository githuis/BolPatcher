using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Console.WriteLine ("AddGAmesWindowViewModel.cs - webhandler made");
		}

		public void AddGame(string hostPath)
		{
			string title = "Error finding title", version = "also on internet";
			version =  webHandler.GetVersion (hostPath);
			title = webHandler.GetTitle (hostPath);

			GameLibrary.Instance.AddGame (title, GenerateGamePath(title), version, hostPath);
			ListChanged?.Invoke (this, EventArgs.Empty);
		}

		private string GenerateGamePath(string title)
		{
			sb.Clear ();
			sb.Append (PathController.Instance.GamesPath).Append ("/").Append (title);
			Console.WriteLine (sb.ToString ());
			return sb.ToString ();
		}
    }
}