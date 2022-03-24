using genetic_algorithm;
WaterPumpStation waterPumpStation = new();
Algorithm algorithm = new();

//Starting variables
int numberOfIndividuals = 160;
int generationNumber = 1;
int numberOfGenerations = 100000;

Generation generation = new(numberOfIndividuals, generationNumber);



for (int i = 1; i <= numberOfGenerations; i++)
{
    foreach(Individual individual in generation.Population)
    {
        individual.calculateIndividual();
    }
    Console.WriteLine($"Best Individual in generation {i}: {generation.GetBestIndividual().FitnessValue}");
    algorithm.TournamentSelection(generation);
    algorithm.Crossover(generation);
    algorithm.Mutation(generation);
}