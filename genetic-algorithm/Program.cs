﻿using genetic_algorithm;

Random random = new Random();
Water_Pump_Station waterPumpStation = new Water_Pump_Station();
Algorithm algorithm=new Algorithm();


//Starting variables
int numberOfIndividuals = 40;
int numberOfGenes = 96;

Generation generation = new Generation(numberOfIndividuals);


//generate first generation: create a list of 4
//




List<Individual> sortedPopulation = generation.population.OrderBy(x => x.fitnessValue).ToList();
foreach (Individual individual in sortedPopulation)
{
    //Console.WriteLine(individual.fitnessValue);
}

Console.WriteLine(algorithm.TournamentSelection(generation).fitnessValue);
Individual selected1 = algorithm.TournamentSelection(generation);
Individual selected2 = algorithm.TournamentSelection(generation);
var (papa, xaxa)= algorithm.Crossover(selected1, selected2);
foreach(bool gene in papa.genesList){
    Console.WriteLine(gene);
}
foreach (bool gene in selected1.genesList)
{
    Console.WriteLine(gene);
}
Console.WriteLine(papa);

