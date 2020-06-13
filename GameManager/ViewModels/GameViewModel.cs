using Caliburn.Micro;
using GameManager.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameManager.ViewModels
{
    class GameViewModel : Conductor<object>
    {
        private GameModel _newGame = new GameModel();
        private BindableCollection<GameModel> _games;

        private List<int> _ratings = new List<int>() { 1 ,2 ,3 ,4 ,5 };

        private GameModel _selectedGame;

        public GameModel SelectedGame
        {
            get { return _selectedGame; }
            set { _selectedGame = value; }
        }


        public List<int> Ratings
        {
            get { return _ratings; }
        }

        public GameModel NewGame
        {
            get { return _newGame; }
            set { _newGame = value; }
        }

        public BindableCollection<GameModel> Games
        {
            get { return _games; }
            set { _games = value; }
        }

        public GameViewModel(BindableCollection<GameModel> games)
        {
            _newGame = new GameModel();
            Games = games;
        }

        public void Add()
        {
            if (!Games.Contains(NewGame))
            {
                Games.Add(NewGame);
            }
            else
            {
                TryClose();
            }
        }

        public void Cancel()
        {
            TryClose();
        }

    }
}
