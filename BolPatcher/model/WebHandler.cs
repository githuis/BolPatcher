using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Gtk;

namespace BolPatcher
{
	public class WebHandler
	{
		private WebClient webClient;
		string versionResult;
		private Button btn;

		public WebHandler ()
		{
			webClient = new WebClient ();
		}

		private async Task<byte[]> AcquireVersion(string hostPath)
		{
			try
			{
				return await webClient.DownloadDataTaskAsync(SetHostPath(hostPath) + "info.version");	
			} 
			catch (Exception)
			{
				return new byte[]{5};
			}

		}

		public string GetVersion(string hostPath)
		{
			return Encoding.UTF8.GetString(AcquireVersion (hostPath).Result);
		}

		private async Task<byte[]> AcquireTitle(string hostPath)
		{
			try
			{
				return await webClient.DownloadDataTaskAsync (SetHostPath (hostPath) + "info.title");
			} catch (Exception) {
				return new byte[]{};
			}
		}

		public string GetTitle(string hostPath)
		{
			return Strip(Encoding.UTF8.GetString (AcquireTitle (hostPath).Result), "\n");
		}

		private string Strip(string str, string toRemove)
		{
			return str.Replace (toRemove, "");
		}

		private string SetHostPath(string curHostPath)
		{
			if (!(curHostPath [curHostPath.Length - 1] == '/'))
				return (curHostPath += "/");
			else
				return curHostPath;
		}

		public void DownloadGameData(string title, string hostPath)
		{
			string gdata = "gamedata.zip";
			Uri u = new Uri (hostPath + gdata);
			Console.WriteLine ("Begin Download of " + title);
			webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;


			webClient.DownloadFileAsync (u, PathController.Instance.CreateGameDir(title) + "/" + gdata);
			webClient.DownloadFileCompleted += async (sender, e) =>
			{
			  await Task.Delay(500);
				PathController.Instance.UnzipAndDelete(title); // Unzip the file

				//Console.WriteLine("Download Finished, real yall");
			};

			//webClient.DownloadFile()	
		}

		private void WebClient_DownloadProgressChanged (object sender, DownloadProgressChangedEventArgs e)
		{
			double bytesIn = double.Parse(e.BytesReceived.ToString());
			double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
			double percentage = bytesIn / totalBytes * 100;

			Console.WriteLine ("Downloaded: " + int.Parse (Math.Truncate (percentage).ToString ()));
		}

		public void AddDownloadCompletedEvent(Button b)
		{
			btn = b;
			webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
		}

		private void RefreshButton()
		{
			btn.Sensitive = true;
			btn.Label = "Add Game";
		}

		private void WebClient_DownloadFileCompleted (object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			RefreshButton ();
		}

	}
}