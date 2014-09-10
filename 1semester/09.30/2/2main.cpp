#include <stdio.h>
#include <stdlib.h>

#include "sort.h"

void printMas(int arraySize, int mas[], FILE *F)
{
	for (int i = 0; i < arraySize; i++)
		fprintf(F, "%d, ", mas[i]);
	fprintf(F, "\n");
}

int oftenElement(int arraySize, int mas[])
{
	int number = 1;
	int maxNum = 0;
	int maxElement = mas[0];
	for (int i = 1; i < arraySize; i++)
	{
		if (mas[i - 1] == mas[i])
			number++;
		else
			number = 1;
		
		if (number > maxNum)
		{
			maxElement = mas[i - 1];
			maxNum = number;
		}
	}
	return maxElement;
}

int main()
{
	FILE *fIn = fopen("in.txt", "r");
	FILE *fOut = fopen("out.txt", "w");
	
	if (!fOut && !fIn)
	{
		printf("bad!!!");
		return 1;
	}
	int arraySize = 0;
	
	fscanf(fIn, "%d", &arraySize);
	int *mas = new int[arraySize];
	
	for (int i = 0; i < arraySize; i++)
		fscanf(fIn, "%d", &mas[i]);
	
	qsort(mas, 0, arraySize - 1);
	printMas(arraySize, mas, fOut);
	fprintf(fOut, "element - %d\n", oftenElement(arraySize, mas));
	
	delete[] mas;
	fclose(fIn);
	fclose(fOut);
	return 0;
}