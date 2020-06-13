using Caliburn.Micro;
using GameManager.Models;
using GameManager.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameManager.ViewModels
{
    class MainViewModel : Conductor<object>
    {
		private BindableCollection<GameModel> _games = new BindableCollection<GameModel>();
		private GameModel _selectedGame;

		IWindowManager manager = new WindowManager();

		public MainViewModel()
		{
			Games.Add(new GameModel() {
				Title = "CSGO",
				Description = "Tactical shooter with russians.",
				Developer = "Valve",
				Path = @"steam://rungameid/730",
				Rating = 2,
				Genre = "FPS",
				Arguments = "-console -novid -high"
			});
			Games.Add(new GameModel()
			{
				Title = "League of Legends",
				Description = "Startegic moba for kids.",
				Developer = "RIOT Games",
				Path = @"",
				Rating = 3,
				Genre = "MOBA"
			});
			Games.Add(new GameModel() 
			{ 
				Title = "Assassins Creed Odyssey",
				Description = "Greek parkour.",
				Developer = "Ubisoft",
				Path = @"D:\Games\Assassins Creed Odyssey\ACOdyssey.exe",
				Rating = 4,
				Genre = "RPG"
			});
		}
		
		public BindableCollection<GameModel> Games
		{
			get {
				return _games;
			}
			set 
			{ 
				_games = value;
				NotifyOfPropertyChange(() => SelectedGame);
			}
		}

		public GameModel SelectedGame
		{
			get {
				return _selectedGame; }
			set 
			{ 
				_selectedGame = value;
				NotifyOfPropertyChange(() => Games);
				NotifyOfPropertyChange(() => SelectedGame);
			}
		}

		public void Add()
		{
			manager.ShowWindow(new GameViewModel(Games), null, null);
		}

		public void StartGame()
		{
			try
			{
				Process gameProcess = new Process();
				gameProcess.StartInfo.FileName = $"{SelectedGame.Path} {SelectedGame.Arguments}";
				gameProcess.Start();
				gameProcess.WaitForExit();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public bool CanStartGame(BindableCollection<GameModel> games)
		{
			if(!Object.Equals(SelectedGame, null)) {
				if (!String.IsNullOrWhiteSpace(SelectedGame.Path))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			return true;
		}

		public void SelectPath()
		{
			if (!Object.Equals(SelectedGame, null))
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.Filter = "All exes (*.exe)|*.exe";
				fileDialog.FilterIndex = 1;

				fileDialog.Multiselect = false;

				if (fileDialog.ShowDialog() == true)
				{
					string filePath = fileDialog.FileName;
					SelectedGame.Path = fileDialog.FileName;
					NotifyOfPropertyChange(() => SelectedGame);
					NotifyOfPropertyChange(() => Games);
				}
			}
		}
	}
}
