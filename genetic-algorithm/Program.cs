using genetic_algorithm;

//Starting variables
int numberOfIndividuals = 50;
int generationNumber = 1;
int numberOfGenerations = 10000;

Generation actualGeneration = new(numberOfIndividuals, generationNumber);
Individual bestCandidate = actualGeneration.Population[0];
decimal bestSolution = bestCandidate.FitnessValue;

for(int i = 1; i <= numberOfGenerations; i++)
{
    if (actualGeneration.GetBestIndividual().FitnessValue > bestSolution)
    {
        bestCandidate = new(actualGeneration.GetBestIndividual());
        bestSolution = bestCandidate.FitnessValue;
        Console.WriteLine($"Best fitness value found in gen {i}: {actualGeneration.GetBestIndividual().FitnessValue}");
        foreach(bool gene in bestCandidate.GenesList)
        {
            Console.Write(gene==false?"1, ":"0, ");
        }
        Console.WriteLine();
    }
    Generation nextGeneration = new(actualGeneration);
    actualGeneration = nextGeneration;
}