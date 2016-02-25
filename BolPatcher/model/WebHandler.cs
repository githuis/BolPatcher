using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BolPatcher
{
	public class WebHandler
	{
		WebClient webClient;
		string versionResult;

		public WebHandler ()
		{
			webClient = new WebClient ();
		}

		private async Task<byte[]> AcquireVersion(string hostPath)
		{
			try
			{
				return await webClient.DownloadDataTaskAsync(SetHostPath(hostPath) + "info.version");	
			} catch (Exception) {
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
			return Encoding.UTF8.GetString(AcquireTitle (hostPath).Result);
		}

		private string SetHostPath(string curHostPath)
		{
			if (!(curHostPath [curHostPath.Length - 1] == '/'))
				return (curHostPath += "/");
			else
				return curHostPath;
		}
	}
}