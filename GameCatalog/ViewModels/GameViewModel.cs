using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GameCatalog
{
    public class GameViewModel
    {
        public ObservableCollection<Game> Games { get; set; }
        private GameRepository GameRepository { get; set; }

        public GameViewModel()
        {
            GameRepository = new GameRepository();
            Games = new ObservableCollection<Game>(GameRepository.gameRepository);
            Games.CollectionChanged += Games_CollectionChanged;
        }

        // Търсене за query string в колекцията

        public List<Game> searchInLibrary(string searchQuery)
        {

            // Временен списък за данните от опашката
            List<Game> GamesList =
                (from tempGame in Games
                 where tempGame.Title.Contains(searchQuery)
                 select tempGame).ToList();
            return GamesList;
        }
        public List<Game> showInLibrary(string showQuery)
        {
            List<Game> GamesList =
                (from tempGame in Games
                 select tempGame).ToList();
            return GamesList;
        }

        public void AddRecordToLibrary(Game game)
        {
            Games.Add(game);
        }

        public void DeleteRecordFromLibrary(int id)
        {
            int index = 0;
            while (index < Games.Count)
            {
                if (Games[index].Id == id)
                {
                    Games.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        // Променя базата данни ако са направени промени по Game Collection
        private void Games_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                GameRepository.addNewRecord(Games[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Game> tempListOfRemovedItems = e.OldItems.OfType<Game>().ToList();
                GameRepository.DeleteRecord(tempListOfRemovedItems[0].Id);
            }
        }
    }
}