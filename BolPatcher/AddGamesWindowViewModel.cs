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
		private WebHandler webHandler = new WebHandler();


		public void AddGame(string path, string hostPath)
		{
			string title = "Error finding title", version = "also on internet";
			version =  webHandler.GetVersion (hostPath);
			title = webHandler.GetTitle (hostPath);

			GameLibrary.Instance.AddGame (title, path, version, hostPath);
			ListChanged?.Invoke (this, EventArgs.Empty);
		}
    }
}