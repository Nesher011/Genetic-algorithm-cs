using genetic_algorithm;

Random random = new Random();
Generation generation=new Generation();


double rateOfMutation = 1 / 96;//***TO DO***
double rateOfCrossover = 0.9;

Water_Pump_Station waterPumpStation=new Water_Pump_Station();

generation.numberOfIndividuals = 40;
for (int i = 0; i < generation.numberOfIndividuals; i++)
{    
    Individual individual = new Individual(96);
    generation.population.Add(individual);
}
Console.WriteLine(generation.population[0].CalculateCost(waterPumpStation));


