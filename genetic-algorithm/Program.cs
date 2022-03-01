using genetic_algorithm;

Random random = new Random();
Generation generation=new Generation();
Water_Pump_Station waterPumpStation = new Water_Pump_Station();
Algorithm algorithm=new Algorithm();




List<Individual> sortedPopulation = generation.population.OrderBy(x => x.fitnessValue).ToList();
foreach (Individual individual in sortedPopulation)
{
    Console.WriteLine(individual.fitnessValue);
}

Console.WriteLine(algorithm.tournamentSelection(generation, 3).fitnessValue);


