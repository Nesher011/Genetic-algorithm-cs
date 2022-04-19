namespace genetic_algorithm
{
    internal class Crossover
    {
        double RateOfCrossover { get; set; }
        public Crossover()
        {
            RateOfCrossover = 0.9;
        }

        public void SinglePoint(List<Individual> population)
        {
            for (int i = 0; i < Convert.ToInt32(population.Count / 2); i++)
            {
                Random random = new();
                Individual childOne = population[i];
                Individual childTwo = population[i + population.Count / 2];
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

        public void MultiplePoint(List<Individual> population, int crossoverPoints)
        {
            Random random = new();
            for( int i = 0; i < Convert.ToInt32(population.Count / 2); i++)
            {
                Individual childOne = population[i];
                Individual childTwo = population[i + population.Count / 2];
                List<bool> parentGenesOne = childOne.GenesList;
                List<bool> parentGenesTwo = childTwo.GenesList;
                childOne.GenesList.Clear();
                childTwo.GenesList.Clear();                
                List<int> pointsOfCrossover = new();
                for(int j=0; j < crossoverPoints; j++)
                {
                    pointsOfCrossover.Add(random.Next(childOne.GenesList.Count));
                    if (random.NextDouble() <= RateOfCrossover)
                    {
                        List<bool> childOnePart = parentGenesOne.GetRange(0, pointsOfCrossover[j]);
                        List<bool> childTwoPart = parentGenesTwo.GetRange(0, pointsOfCrossover[j]);
                        if (j % 2 == 0)
                        {
                            childOne.GenesList = childOne.GenesList.Concat(childOnePart).ToList();
                            childTwo.GenesList = childTwo.GenesList.Concat(childTwoPart).ToList();
                        }
                        else
                        {
                            childOne.GenesList = childOne.GenesList.Concat(childTwoPart).ToList();
                            childTwo.GenesList = childTwo.GenesList.Concat(childOnePart).ToList();
                        }
                    }
                    
                }
                
            }
        }
    }
}
