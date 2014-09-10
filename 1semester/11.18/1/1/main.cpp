/* Test is Ok:	9 12
				1 2 5
				2 3 3
				1 7 1
				2 8 2
				7 8 4
				3 8 7
				6 7 2
				6 5 3
				7 5 5
				3 4 2
				5 9 2
				4 9 1
				2
				7 4

				4 3
				1 2 1
				2 3 1
				3 4 1
				2
				1 2
	нумерация городов идет с 1!
*/
#include <fstream>
#include <iostream>
#include "graph.h"

using namespace std;

int main()
{
	ifstream fin("in.txt");
	int numberCity = 0;
	int numberRoad = 0;
	fin >> numberCity >> numberRoad;
	fin.close();

	int *country = new int[numberCity];
	int *city = new int[numberCity];
	for (int i = 0; i < numberCity; i++)
		city[i] = -1;

	int **road = create(country);
	for (int i = 0; country[i] != -1; i++)
		city[country[i]] = country[i];
	makeCountry(country, road, numberCity, city);
	
	print(city, country, numberCity);

	for (int i = 0; i < numberCity; i++)
		delete[] road[i];
	delete[] road;
	delete[] country;
	delete[] city;
	return 0;
}

