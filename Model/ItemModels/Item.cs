namespace KnapsackProblem.Model.ItemModels
{
    public class Item
    {
        private static int counter = 0;

        public Item(int weight, int value)
        {
            counter++;
            Weight = weight;
            Value = value;
            Name = "Item" + counter;
            
        }
        public int Weight { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public bool ItemChosen { get; set; } = false;

    }
}
