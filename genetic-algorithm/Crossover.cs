namespace genetic_algorithm
{
    internal class Crossover
    {
        public static void SinglePoint(List<Individual> population, double rateOfCrossover)
        {
            for (int i = 0; i < Convert.ToInt32(population.Count / 2); i++)
            {
                Random random = new();
                Individual childOne = population[i];
                Individual childTwo = population[i + population.Count / 2];
                int pointOfCrossover = random.Next(childOne.GenesList.Count);
                if (random.NextDouble() <= rateOfCrossover)
                {
                    List<bool> childOnePartOne = childOne.GenesList.GetRange(0, pointOfCrossover);
                    List<bool> childOnePartTwo = childOne.GenesList.GetRange(pointOfCrossover, childOne.GenesList.Count - pointOfCrossover);
                    List<bool> childTwoPartOne = childTwo.GenesList.GetRange(0, pointOfCrossover);
                    List<bool> childTwoPartTwo = childTwo.GenesList.GetRange(pointOfCrossover, childTwo.GenesList.Count - pointOfCrossover);
                    childOne.GenesList = childOnePartOne.Concat(childTwoPartTwo).ToList();
                    childTwo.GenesList = childTwoPartOne.Concat(childOnePartTwo).ToList();
                }
            }
        }
    }
}