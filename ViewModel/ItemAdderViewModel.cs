using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KnapsackProblem.Model;
using KnapsackProblem.Model.ItemModels;

namespace KnapsackProblem.ViewModel
{
    public class ItemAdderViewModel: ViewModelBase
    {
        private string _weight;
        private string _value;

        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                RaisePropertyChanged();
            }
        }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        public ItemFactory ItemFactory { get; set; }

        public RelayCommand AddItemCommand { get; set; }

        public ItemAdderViewModel()
        {
            ItemFactory = new ItemFactory();
            AddItemCommand = new RelayCommand(ExecuteCreateItem);
        }

        private void ExecuteCreateItem()
        {
            int valueAsInt;
            int weightAsInt;
            var parsedInput = CheckAndParseInput();
            if (!parsedInput.Success) return;

            var item = ItemFactory.CreateItem(parsedInput.Value, parsedInput.Weight);
            SendItemMessage(item);
        }

        private (int Value, int Weight, bool Success) CheckAndParseInput()
        {
            bool success = true;
            var valueAsInt = int.MinValue;
            var weightAsInt = int.MinValue;
            //Check Value
            if (int.TryParse(Value, out int intValue))
            {
                valueAsInt = intValue;
            }
            else
            {
                //update UI
                Weight = "Invalid number";
                return (0,0,false);
            }
            //Check weight
            if (int.TryParse(Weight, out int intWeight))
            {
                weightAsInt = intWeight;
            }
            else
            { 
                //update UI
                Weight = "Invalid number";
                return (0, 0, false);
            }
            

            return (valueAsInt,weightAsInt,true);
        }

        private void SendItemMessage(Item item)
        {
            MessengerInstance.Send(item);
        }
    }
}
