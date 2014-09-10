/* Test is Ok - 
				6
				0 5 2 1 0 0
				5 0 0 4 0 6
				2 0 0 6 7 0
				1 4 6 0 2 3
				0 0 7 2 0 1
				0 6 0 3 1 0
*/

#include "algPrima.h"
#include <fstream>
#include <iostream>

using namespace std;

void print(int *a[], int n)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout.width(2);
 			cout << a[i][j] << " ";
		}
		cout << "\n\n";
	}
}

int main()
{
	ifstream input("graph.in");
	int num = 0;
	input >> num;
	int **graph = new int*[num];
	for (int i = 0; i < num; i++)
		graph[i] = new int[num];
	for (int i = 0; i < num; i++)
		for (int j = 0; j < num; j++)
		{
			input >> graph[i][j];	
			if (i != j && graph[i][j] == 0)
				graph[i][j] = 10000;
		}
		
	int **ost = prim(graph, num);
	print(ost, num);

	for (int i = 0; i < num; i++)
		delete[] graph[i];
	delete[] graph;

	for (int i = 0; i < num; i++)
		delete[] ost[i];
	delete[] ost;
	return 0;
}