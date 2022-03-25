using genetic_algorithm;
WaterPumpStation waterPumpStation = new();
Algorithm algorithm = new();

//Starting variables
int numberOfIndividuals = 50;
int generationNumber = 1;
int numberOfGenerations = 100;

Generation firstGeneration = new(numberOfIndividuals, generationNumber);
Generation actualGeneration = firstGeneration;
for(int i = 0; i < numberOfGenerations; i++)
{
    Console.WriteLine(actualGeneration.GetBestIndividual().FitnessValue);
    Generation nextGeneration = new(actualGeneration);
    actualGeneration = nextGeneration;
}