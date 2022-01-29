using genetic_algorithm;

Individual individual = new Individual(96);

Console.WriteLine(individual);
individual.genesList.Add(true);
//xd.Genes.Add(true);
 
Console.WriteLine(individual.genesList[0]);
Console.WriteLine(individual.numberOfGenes);

