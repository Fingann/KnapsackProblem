using System.Collections.Generic;
using KnapsackProblem.Model.ItemModels;

namespace KnapsackProblem.Model.Knapsack
{
    public interface ISolver
    {

        List<Item> Solve(Knapsack knapsack);
    }
}
