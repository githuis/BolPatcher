using System;
using BolPatcher.model;
using BolPatcher.ViewModel;
using Gtk;

namespace BolPatcher.View
{
    public class AddGamesWindow : Window
    {
		private Entry _hostPathBox;
		public AddGamesWindowViewModel AgwViewModel;
		private readonly BoolWrapper _winOpen;
		public Button AddGameButton;

		public AddGamesWindow(BoolWrapper windowOpen) : base(WindowType.Toplevel)
        {
            AgwViewModel = new AddGamesWindowViewModel();
            SetWindowStats();
            AddWindowContent();            
			_winOpen = windowOpen;
        }

		protected override void OnDestroyed ()
		{
			_winOpen.Value = false;
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
            AddGameButton = new Button();
            _hostPathBox = new Entry();
            _hostPathBox.SetSizeRequest(300, _hostPathBox.HeightRequest);
            Fixed fix = new Fixed();

            AddGameButton.Label = "Add game";
            AddGameButton.Clicked += OnAddGame;

            fix.Put(label, 5, 10);
            fix.Put(titleLabel, 5, 30);
            fix.Put(_hostPathBox, 5, 100);
            fix.Put(AddGameButton, 5, 140);

            Add(fix);
        }

        private void OnAddGame(object s, EventArgs e)
        {
			try
			{
				AddGameButton.Label = "Downloading Game";
				AddGameButton.Sensitive = false;
				AgwViewModel.AddGame (_hostPathBox.Text);	
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}