using genetic_algorithm;
WaterPumpStation waterPumpStation = new();
Algorithm algorithm = new();

//Starting variables
int numberOfIndividuals = 40;
int generationNumber = 1;

Generation generation = new(numberOfIndividuals, generationNumber);

foreach(Individual individual in generation.Population)
{
    Console.WriteLine(individual.FitnessValue);
}
Console.WriteLine("przerwaprzerwaprzerwa");
algorithm.TournamentSelection(generation);

foreach (Individual individual in generation.Population)
{
    Console.WriteLine(individual.FitnessValue);
}

