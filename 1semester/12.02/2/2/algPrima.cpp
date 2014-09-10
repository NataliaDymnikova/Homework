#include "algPrima.h"
#include <iostream>

using namespace std;

bool min(int **road, bool *visit, int **graph, int num)
{
	int min = 10000;
	int previous = 0;
	int now = 0;
	for (int i = 0; i < num; i++)
		if (visit[i])
			for (int j = 0; j < num; j++)
			{
				if (!visit[j] && i != j && road[i][j] < min)
				{
					min = road[i][j];
					previous = i;
					now = j;
				}
			}
	if (min == 10000)
		return false;
	visit[now] = true;
	graph[previous][now] = road[previous][now];
	graph[now][previous] = road[previous][now];
	return true;
}


int **prim(int **road, int num)
{
	int b = 1000;
	bool *visit = new bool[num];
	for (int i = 0; i < num; i++)
		visit[i] = false;
	visit[0] = true;

	int **graph = new int*[num];
	for (int i = 0; i < num; i++)
		graph[i] = new int[num];
	for (int i = 0; i < num; i++)
		for (int j = 0; j < num; j++)
			graph[i][j] = 0;

	for (int i = 1; i < num; i++)
	{
		if (!min(road, visit, graph, num))
		{
			cout << "Error" << endl;
			break;
		}
	}
	delete[] visit;
	return graph;
}