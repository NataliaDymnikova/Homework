#include <fstream>
#include <iostream>
#include "graph.h"

using namespace std;

static int infinity = 10000;

int **create(int *country)
{
	ifstream fin("in.txt");
	int numberCity = 0;
	int numberRoad = 0;
	fin >> numberCity >> numberRoad;
	
	int **road = new int*[numberCity];
	for (int i = 0; i < numberCity; i++)
		road[i] = new int[numberCity];
	for (int i = 0; i < numberCity; i++)
		for (int j = 0; j < numberCity; j++)
			road[i][j] = infinity;
	int l = 0;
	int j = 0;
	for (int k = 0; k < numberRoad; k++)
	{
		fin >> l;
		fin >> j;
		fin >> road[l - 1][j - 1];	
		road[j - 1][l - 1] = road[l - 1][j - 1];
	}
	
	int numberCountry = 0;
	fin >> numberCountry;
	for (int i = 0; i < numberCity; i++)
		country[i] = -1;
	for (int i = 0; i < numberCountry; i++)
	{
		fin >> country[i];
		country[i]--;
	}
	fin.close();
	return road;
}

int minRoad(int numberCountry, int city[], int **road, int numberAllCity)
{
	int minRoad = infinity;
	int minCity = -1;
	for (int i = 0; i < numberAllCity; i++)
	{
		if (city[i] == numberCountry)
			for (int j = 0; j < numberAllCity; j++)
				if (minRoad > road[i][j] && city[j] == -1 && i != j)
				{
					minRoad = road[i][j];
					minCity = j;
				}
	}
	return minCity;
}

void makeCountry(int country[], int **floydGraph, int numberCity, int city[])
{
	int j = 0;
	int num = 0;
	int numCountry = 0;
	for (int i = 0; i < numberCity && country[i] != -1; i++)
		numCountry++;
	for (int i = 0; i < numberCity + num - numCountry; i++)
	{
		int min = minRoad(country[j], city, floydGraph, numberCity);
		if (min != -1)
			city[min] = country[j];
		else 
			num++;
		if (j + 1 >= sizeof(country) || country[j + 1] == -1)
			j = 0;
		else
			j++;
	}
}

void print(int city[], int country[], int numberCity)
{
	for (int i = 0; country[i] != -1; i++)
	{
		cout << "country " << i + 1 << ": ";
		for (int j = 0; j < numberCity; j++)
		{
			if (city[j] == country[i])
				cout << j + 1 << " ";
		}
		cout << endl;
	}
}