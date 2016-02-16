using System;
using Gtk;

namespace BolPatcher
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			VersionChecker vc = new VersionChecker ();

			win.ShowAll();
			Application.Run ();
			Console.WriteLine ("S");
		}
	}
}
