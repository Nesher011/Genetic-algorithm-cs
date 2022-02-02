using genetic_algorithm;
Random random = new Random();
List<Individual> population = new List<Individual>();
Generation generation=new Generation();
Water_Pump_Station waterPumpStation=new Water_Pump_Station();

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
waterPumpStation.waterDemand.ForEach(Console.WriteLine);
waterPumpStation.waterPumpVolume.ForEach(Console.WriteLine);
waterPumpStation.waterPumpElectricity.ForEach(Console.WriteLine);

foreach (Individual x in population)
{
    //x.genesList.ForEach(Console.WriteLine);
};

