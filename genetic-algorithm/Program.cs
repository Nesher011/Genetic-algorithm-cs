using genetic_algorithm;
WaterPumpStation waterPumpStation = new();
Algorithm algorithm = new();

//Starting variables
int numberOfIndividuals = 50;
int generationNumber = 1;
int numberOfGenerations = 999999;

Generation firstGeneration = new(numberOfIndividuals, generationNumber);
Generation actualGeneration = firstGeneration;
Individual bestCandidate = actualGeneration.Population[0];
decimal bestSolution = bestCandidate.FitnessValue;
for(int i = 1; i <= numberOfGenerations; i++)
{
    if (actualGeneration.GetBestIndividual().FitnessValue > bestSolution)
    {
        bestCandidate = new(actualGeneration.GetBestIndividual());
        bestSolution = bestCandidate.FitnessValue;
        Console.WriteLine($"Best fitness value found in gen {i}: {actualGeneration.GetBestIndividual().FitnessValue}");
    }
    Generation nextGeneration = new(actualGeneration);
    actualGeneration = nextGeneration;
}