using System;
using System.Collections.Generic;
using System.Linq;
using KnapsackProblem.Model.ItemModels;

namespace KnapsackProblem.Model.Knapsack
{
    public class Knapsack
    {

        public int Solve(IEnumerable<Item> weightValue,
            int capacity)
        {
            var weights = weightValue.Select(t => t.Weight).ToArray();
            var values = weightValue.Select(t => t.Value).ToArray();
            int[,] dp = new int[weightValue.Count() + 1, capacity + 1];

            //for 0 items total value is zero
            for (int i = 0; i <= capacity; i++)
            {
                dp[0, i] = 0;
            }
            //for 0 weight total value is zero
            for (int i = 0; i <= weightValue.Count(); i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i <= weightValue.Count(); i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (weights[i] <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i, w - weights[i]] + values[i]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[weightValue.Count(), capacity];
        }
    }
    //public class Knapsack
    //{
    //    public List<Item> Items { get; set; }
    //    public int WeightLimit { get; set; }
    //    public double BestValue { get; set; } = 0;

    //    public Knapsack(int weightLimit)
    //    {
    //        WeightLimit = weightLimit;
    //        Items = new List<Item>();
    //    }

    //    public Knapsack(int weightLimit, List<Item> items): this(weightLimit)
    //    {
    //        Items = items;
    //    }

    //    public void AddItems(List<Item> items)
    //    {
    //        Items = items;
    //    }

       
    //    bool[] bestItems;
    //    double[] itemValues;
    //    double[] itemWeights;

    //    void SolveRecursive(int depth, double currentWeight, double currentValue, double remainingValue)
    //    {
    //        if (currentWeight > WeightLimit) return;
    //        if (currentValue + remainingValue < BestValue) return;
    //        //if (depth == chosen.Length)
    //        //{
    //        //    BestValue = currentValue;
    //        //    System.Array.Copy(chosen, bestItems, chosen.Length);
    //        //    return;
    //        //}
    //        remainingValue -= Items[depth].Value;
    //        Items[depth].ItemChosen = false;
    //        SolveRecursive(depth + 1, currentWeight, currentValue, remainingValue);
    //        Items[depth].ItemChosen = true;
    //        currentWeight += Items[depth].Value;
    //        currentValue += Items[depth].Value;
    //        SolveRecursive(depth + 1, currentWeight, currentValue, remainingValue);
    //    }

    //    public List<Item> Solve()
    //    {

    //        double totalValue = Items.Aggregate(0.0, (current, item) => current + item.Value);

    //        SolveRecursive( 0, 0.0, 0.0, totalValue);
    //        return Items.Where(x => x.ItemChosen).ToList();
    //    }
    }
