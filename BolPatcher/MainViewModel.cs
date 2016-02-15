using System;
using System.ComponentModel;

namespace BolPatcher
{
	public class MainViewModel : INotifyPropertyChanged
	{
        public GameLibrary lib;
		public MainViewModel ()
		{
			lib = GameLibrary.Instance;
        }

		public Game LoadGame(string title)
		{
			if (GameLibrary.Instance.GameExistsInLibrary (title))
				throw new ArgumentException ();
			return GameLibrary.Instance.FindGameInLibrary (title);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (propName));
		}
	}
}

