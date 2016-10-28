using System.ComponentModel;
using BolPatcher.model;
using Gtk;

namespace BolPatcher.View
{
	[ToolboxItem (true)]
	public class MenuGameWidget : Bin
	{
		private Button _launchButton;
		private Button _updateButton;
		private Label _titleLabel;
		private Label _infoLabel;
		private Fixed _fix;

		private readonly Game _game;

		public MenuGameWidget (Game game)
		{
			//4this.Build ();

			_game = game;


		}

		private void AddGameToMenu()
		{
			//Initialize widgets
			_launchButton = new Button();
			_launchButton.Label = "Play";

			_updateButton = new Button ();
			_updateButton.Label = "Update";

			_titleLabel = new Label (_game.Title);
			_infoLabel = new Label (" ");
			_fix = new Fixed ();

			_fix.Add (_launchButton);
			_fix.Add (_updateButton);
			_fix.Add (_titleLabel);
			_fix.Add (_infoLabel);

			Add (_fix);
		}
	}
}

