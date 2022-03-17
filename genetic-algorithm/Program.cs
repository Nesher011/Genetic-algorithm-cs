using genetic_algorithm;
WaterPumpStation waterPumpStation = new();
Algorithm algorithm = new Algorithm();


//Starting variables
int numberOfIndividuals = 40;
int numberOfGenes = 96;

Generation generation = new Generation(numberOfIndividuals);



List<Individual> sortedPopulation = generation.Population.OrderBy(x => x.FitnessValue).ToList();
foreach (Individual individual in sortedPopulation)
{
    Console.WriteLine(individual.FitnessValue);
}

Console.WriteLine(algorithm.TournamentSelection(generation).FitnessValue);
Individual selected1 = algorithm.TournamentSelection(generation);
Individual selected2 = algorithm.TournamentSelection(generation);
var (papa, xaxa) = algorithm.Crossover(selected1, selected2);