using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace KnapsackProblem.Model.ItemModels
{
    public class ItemList: ObservableCollection<Item>
    {
        public double BestValue
        {
            get
            {
                return this.Items.Where(item => item.ItemChosen).Aggregate<Item, double>(0, (current, item) => current + item.Value);
            }
        }

        public List<Item> ChosenItems
        {
            get
            {
                return Items.Where(item => item.ItemChosen).ToList();
                
            }
        }
    }
}
