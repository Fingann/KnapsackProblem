using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents.DocumentStructures;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KnapsackProblem.Model;
using KnapsackProblem.Model.ItemModels;
using KnapsackProblem.Model.Knapsack;

namespace KnapsackProblem.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand SolveKnapsackCommand { get; set; }

        private ItemList items = new ItemList();

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ItemList Items
        {
            get
            {
                return items;
            }
            set
            {
                Set(ref items, value);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            SolveKnapsackCommand = new RelayCommand(ExecuteSolveKnapsack);
           MessengerInstance.Register<Item>(this, AddItemToCollection);
        }

        private void ExecuteSolveKnapsack()
        {
            var knapsack = new Knapsack();
            var items = new List<Item>();
            items.Add(new Item(3,5));
            items.Add(new Item(2,3));
            items.Add(new Item(2,2));
            items.Add(new Item(4,5));
            items.Add(new Item(3,4));
            items.Add(new Item(1,2));
            knapsack.Solve(items, 10);
            //var answer = knapsack.Solve();
            

        }

        private void AddItemToCollection(Item item)
        {
            Items.Add(item);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}