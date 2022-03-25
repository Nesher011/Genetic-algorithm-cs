namespace genetic_algorithm
{
    internal class Crossover
    {
        double RateOfCrossover { get; set; }
        public Crossover()
        {
            RateOfCrossover = 0.9;
        }

        public void SinglePoint(Individual childOne, Individual childTwo)
        {
            Random random = new();
            int pointOfCrossover = random.Next(childOne.GenesList.Count);
            if (random.NextDouble() <= RateOfCrossover)
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
