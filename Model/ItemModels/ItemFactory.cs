namespace KnapsackProblem.Model.ItemModels
{
    public class ItemFactory
    {
        private int ItemNumber { get; set; } = 0;

        public Item CreateItem(int value, int weight)
        {
            ItemNumber++;
            var item = new Item(value, weight);
            item.Name = "Item" + ItemNumber;
            return item;
        }

    }
}
