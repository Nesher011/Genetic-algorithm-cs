using genetic_algorithm;

Random random = new Random();
Generation generation=new Generation();
Water_Pump_Station waterPumpStation = new Water_Pump_Station();




List<Individual> sortedPopulation = generation.population.OrderBy(x => x.fitnessValue).ToList();
foreach (Individual individual in sortedPopulation)
{
    Console.WriteLine(individual.fitnessValue);
}

