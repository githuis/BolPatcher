using System;
using Gtk;

namespace BolPatcher
{
    public partial class AddGamesWindow : Gtk.Window
    {
		private Entry _hostPathBox;
		public AddGamesWindowViewModel _agwViewModel;
		private BoolWrapper winOpen;
		public Button addGameButton;

		public AddGamesWindow(BoolWrapper windowOpen) : base(Gtk.WindowType.Toplevel)
        {
            _agwViewModel = new AddGamesWindowViewModel();
            SetWindowStats();
            AddWindowContent();            
			winOpen = windowOpen;
        }

		protected override void OnDestroyed ()
		{
			winOpen.Value = false;
		}

        private void SetWindowStats()
        {
            //Request size change
            SetSizeRequest(400, 250);

            //Change title
            Title = "Add Game - BolPatcher";

			//Try to set window position
			SetPosition(WindowPosition.Center);
        }

        private void AddWindowContent()
        {
            Label label = new Label("Add game"), titleLabel = new Label("Host address"), saveLabel = new Label("Save path");
            addGameButton = new Button();
            _hostPathBox = new Entry();
            _hostPathBox.SetSizeRequest(300, _hostPathBox.HeightRequest);
            Fixed fix = new Fixed();

            addGameButton.Label = "Add game";
            addGameButton.Clicked += OnAddGame;

            fix.Put(label, 5, 10);
            fix.Put(titleLabel, 5, 30);
            fix.Put(_hostPathBox, 5, 100);
            fix.Put(addGameButton, 5, 140);

            Add(fix);
        }

        private void OnAddGame(object s, EventArgs e)
        {
			try
			{
				addGameButton.Label = "Downloading Game";
				addGameButton.Sensitive = false;
				_agwViewModel.AddGame (_hostPathBox.Text);	
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}