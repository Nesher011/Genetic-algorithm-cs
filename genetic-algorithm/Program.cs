using genetic_algorithm;

Random random = new Random();
List<Individual> population = new List<Individual>();
Generation generation=new Generation();
float[] demand = { 60, 50, 40, 30, 40, 50, 60, 100, 120, 150, 160, 160, 160, 130, 130, 150, 150, 150, 140, 130, 120, 100, 80, 70 };
int[] pumpVolume = { 0, 10, 30, 40, 50, 60, 80, 90, 100, 110, 130, 140, 150, 160, 180, 190 };
int[] pumpElectricity = { 0, 12, 30, 42, 44, 56, 74, 86, 80, 92, 111, 124, 127, 141, 165, 182 };

float rateOfMutation = 1 / 96;//***TO DO***
float rateOfCrossover = 0.9F;

Water_Pump_Station waterPumpStation=new Water_Pump_Station(demand,pumpVolume,pumpElectricity);

generation.numberOfIndividuals = 40;
for (int i = 0; i < generation.numberOfIndividuals; i++)
{    
    Individual individual = new Individual(96);
    for (int j = 0; j < individual.numberOfGenes; j++)
    {
        individual.genesList.Add(random.NextDouble() >= 0.5);
    }
    population.Add(individual);
}



Console.WriteLine(population[0].waterLevelList());


